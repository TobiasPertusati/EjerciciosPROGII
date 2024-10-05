using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using PrimerParcial_1W3_412301.DLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial_1W3_412301.DLL.Data.Repository
{
    public class CriptomonedaRepository : ICriptomonedaRepository
    {
        private readonly db_criptomonedasContext _contex;
        public CriptomonedaRepository(db_criptomonedasContext contex)
        {
            _contex = contex;
        }
        // Solo es posible consultar monedas cuya última actualización no supere un día a la fecha.
        ///Por ejemplo, es posible indicar que el valor de ayer fue de x dólares, pero no el de antes de ayer.
        public async Task<List<Criptomoneda>> GetAllByCategoria(int categoria)
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);

            return await _contex.Criptomonedas
                   .Where(c => c.Categoria == categoria && c.UltimaActualizacion.Day >= yesterday.Day)
                   .ToListAsync();
        }

        public async Task<Criptomoneda> GetById(int id)
        {
            return await _contex.Criptomonedas.FindAsync(id);
        }

        public async Task<bool> LogicDelete(int id)
        {
            // Solo es posible registrar la baja(inhabilitación) de una moneda si su estado
            //es “H” (Habilitada).Los estados posibles son: “H”-Habilitada | “NH” – No
            //Habilitada.
            Criptomoneda c = await GetById(id);
            if (c != null && c.Estado != "NH")
            {
                c.Estado = "NH";
            }
            return await _contex.SaveChangesAsync() > 0;

        }
        //o PUT /cripto? simbolo = ETC; valorActual=20 |Permite actualizar el valor de la
        //moneda a partir del símbolo.
        // actualizar el valor actual(junto con la fecha/hora de la última
        //cotización) de una criptomoneda identificada por símbolo(por
        //ejemplo: BTC para Bitcoins)
        // Al momento de actualizar la cotización de una moneda la fecha/hora de la
        //última cotización no puede ser superior a un día.
        ///Por ejemplo, es posible indicar que el valor de ayer fue de x dólares, pero no el de antes de ayer.
        public async Task<bool> Update(string sim, double valor, DateTime fechaActualizacion)
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);
            DateTime tomorrow = DateTime.Today.AddDays(1);
            Criptomoneda c = await _contex.Criptomonedas.FirstAsync(c => c.Simbolo == sim);
            if (c != null && fechaActualizacion >= yesterday && fechaActualizacion < tomorrow)
            {
                c.ValorActual = valor;
                c.UltimaActualizacion = fechaActualizacion;
            }

            return await _contex.SaveChangesAsync() > 0;

        }
    }
}
