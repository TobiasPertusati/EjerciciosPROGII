using Ejercicio1_4.Data.DataAccess;
using Ejercicio1_4.Data.Interfaces;
using Ejercicio1_4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
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
    }
}

