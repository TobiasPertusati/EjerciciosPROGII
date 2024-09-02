using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4.Models
{
    public class Cuenta
    {
        public int IdCuenta { get; set; }
        public string? CBU { get; set; }
        public double Saldo { get; set; }
        public DateTime UltimoMovimiento { get; set; }
        public TipoCuenta? TipoCuenta { get; set; }
        public Cliente? Cliente { get; set; }

        public override string ToString()
        {

            return $"{CBU} | {TipoCuenta} \nSaldo: {Saldo} | Ultimo Movimiento: {UltimoMovimiento} \n{Cliente}";
        }

    }
}
