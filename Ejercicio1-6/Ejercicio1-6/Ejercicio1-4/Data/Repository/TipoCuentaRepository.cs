
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
    public class TipoCuentaRepository : ITipoCuentaRepository
    {
        public TipoCuenta Get(int id)
        {
            TipoCuenta aux = new TipoCuenta();
            try
            {
                var dataHelper = DataHelper.GetInstance();
                dataHelper.SetearParametros(id, "@id_tipo_cuenta");
                DataTable dt = dataHelper.EjecutarSPQuery("SP_GET_TIPO_CUENTA");
                foreach (DataRow dr in dt.Rows)
                {

                    aux.IdTipoCuenta = Convert.ToInt32(dr["id_tipo_cuenta"]);
                    aux.Nombre = dr["tipo_cuenta"].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return aux;
        }

        public List<TipoCuenta> GetAll()
        {
            List<TipoCuenta> cuentas = new();
            try
            {
                var dataHelper = DataHelper.GetInstance();
                DataTable dt = dataHelper.EjecutarSPQuery("SP_GETALL_TIPOS_CUENTAS");
                foreach (DataRow dr in dt.Rows)
                {
                    TipoCuenta aux = new TipoCuenta();
                    aux.IdTipoCuenta = Convert.ToInt32(dr["id_tipo_cuenta"]);
                    aux.Nombre = dr["tipo_cuenta"].ToString();
                    cuentas.Add(aux);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return cuentas;
        }
    }
}
