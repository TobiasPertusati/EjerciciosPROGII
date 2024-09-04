using Ejercicio1_4.Data.DataAccess;
using Ejercicio1_4.Data.Interfaces;
using Ejercicio1_4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public bool EliminarCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public Cliente Get(int id)
        {
            Cliente aux = new Cliente();
            try
            {
                var dataHelper = DataHelper.GetInstance();
                dataHelper.SetearParametros(id, "@id_cliente");
                DataTable dt = dataHelper.EjecutarSPQuery("SP_GET_CLIENTES");
                foreach (DataRow dr in dt.Rows)
                {
                    aux.IdCliente = Convert.ToInt32(dr["id_cliente"]);
                    aux.Nombre = dr["nombre"].ToString();
                    aux.Apellido = dr["apellido"].ToString();
                    aux.Dni = dr["dni"].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return aux;
        }

        public List<Cliente> GetAll()
        {
            List<Cliente> clientes = new();
            try
            {
                var dataHelper = DataHelper.GetInstance();
                DataTable dt = dataHelper.EjecutarSPQuery("SP_GETALL_CLIENTES");
                foreach (DataRow dr in dt.Rows)
                {
                    Cliente aux = new();
                    aux.IdCliente = Convert.ToInt32(dr["id_cliente"]);
                    aux.Nombre = dr["nombre"].ToString();
                    aux.Apellido = dr["apellido"].ToString();
                    aux.Dni = dr["dni"].ToString();
                    clientes.Add(aux);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return clientes;
        }

        public bool ModificarCliente(Cliente cliente)
        {
            bool res;
            try
            {
                var helper = DataHelper.GetInstance();
                helper.SetearParametros(cliente.IdCliente, "@ID");
                helper.SetearParametros(cliente.Nombre, "@NOMBRE");
                helper.SetearParametros(cliente.Apellido, "@APELLIDO");
                helper.SetearParametros(cliente.Dni, "@DNI");
                res = helper.EjecutarSPDML("SP_MODIFICAR_CLIENTES");
            }
            catch (SqlException)
            {
                res = false;

            }
            return res;
        }

        public bool NuevoCliente(Cliente cliente)
        {
            bool res = true;
            var helper = DataHelper.GetInstance();
            SqlTransaction t = null;
            SqlConnection cnn = helper.GetConnection();
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();

                var cmd = new SqlCommand("SP_CREAR_CLIENTES", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NOMBRE", cliente.Nombre);
                cmd.Parameters.AddWithValue("@APELLIDO", cliente.Apellido);
                cmd.Parameters.AddWithValue("@DNI", cliente.Dni);

                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                int clienteid = (int)param.Value;

                var cmdCuentas = new SqlCommand("SP_UPSERT_CUENTA", cnn, t);
                cmdCuentas.CommandType = CommandType.StoredProcedure;
                foreach (Cuenta c in cliente.Cuentas)
                {
                    cmdCuentas.Parameters.Clear();
                    cmdCuentas.Parameters.AddWithValue("@id_cuenta", c.IdCuenta);
                    cmdCuentas.Parameters.AddWithValue("@cliente", clienteid);
                    cmdCuentas.Parameters.AddWithValue("@saldo", c.Saldo);
                    cmdCuentas.Parameters.AddWithValue("@cbu", c.CBU);
                    cmdCuentas.Parameters.AddWithValue("@ultimo_mov", c.UltimoMovimiento);
                    cmdCuentas.Parameters.AddWithValue("@tipo_cuenta", c.TipoCuenta.IdTipoCuenta);
                    cmdCuentas.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                res = false;
            }
            finally { cnn.Close(); }
            return res;
        }
    }
}

