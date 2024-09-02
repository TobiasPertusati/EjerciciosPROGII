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
    public class CuentaRepository : ICuentaRepository
    {
        public bool Delete(int id)
        {
            var helper = DataHelper.GetInstance();
            helper.SetearParametros(id, "@id_cuenta");
            return helper.EjecutarSPDML("SP_DELETE_CUENTA");
        }

        public Cuenta Get(int id)
        {
            Cuenta cuenta = new Cuenta();
            try
            {
                TipoCuentaRepository t = new TipoCuentaRepository();
                ClienteRepository c = new ClienteRepository();
                var helper = DataHelper.GetInstance();
                helper.SetearParametros(id, "@id_cuenta");
                DataTable dt = helper.EjecutarSPQuery("SP_GET_CUENTA");
                foreach (DataRow r in dt.Rows)
                {
                    cuenta.IdCuenta = Convert.ToInt32(r["id_cuenta"]);
                    cuenta.CBU = r["cbu"].ToString();
                    cuenta.Saldo = Convert.ToDouble(r["saldo"]);
                    cuenta.UltimoMovimiento = Convert.ToDateTime(r["ultimo_mov"]);
                    cuenta.TipoCuenta = t.Get(Convert.ToInt32(r["tipo_cuenta"]));
                    cuenta.Cliente = c.Get(Convert.ToInt32(r["cliente"]));
                }

            }
            catch (Exception)
            {
                throw;
            }
            return cuenta;
        }

        public List<Cuenta> GetAll()
        {
            List<Cuenta> list = new List<Cuenta>();
            try
            {
                TipoCuentaRepository t = new TipoCuentaRepository();
                ClienteRepository c = new ClienteRepository();
                var helper = DataHelper.GetInstance();
                DataTable dt = helper.EjecutarSPQuery("SP_GETALL_CUENTAS");
                foreach (DataRow r in dt.Rows)
                {
                    Cuenta cuenta = new Cuenta();
                    cuenta.IdCuenta = Convert.ToInt32(r["id_cuenta"]);
                    cuenta.CBU = r["cbu"].ToString();
                    cuenta.Saldo = Convert.ToDouble(r["saldo"]);
                    cuenta.UltimoMovimiento = Convert.ToDateTime(r["ultimo_mov"]);
                    cuenta.TipoCuenta = t.Get(Convert.ToInt32(r["tipo_cuenta"]));
                    cuenta.Cliente = c.Get(Convert.ToInt32(r["cliente"]));
                    list.Add(cuenta);
                }

            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public bool Upsert(Cuenta cuenta)
        {
            var helper = DataHelper.GetInstance();
            helper.SetearParametros(cuenta.IdCuenta, "@id_cuenta");
            helper.SetearParametros(cuenta.CBU, "@cbu");
            helper.SetearParametros(cuenta.Saldo, "@saldo");
            helper.SetearParametros(cuenta.UltimoMovimiento, "@ultimo_mov");
            helper.SetearParametros(cuenta.Cliente.IdCliente, "@cliente");
            helper.SetearParametros(cuenta.TipoCuenta.IdTipoCuenta, "@tipo_cuenta");
            return helper.EjecutarSPDML("SP_UPSERT_CUENTA");
        }
    }
}
