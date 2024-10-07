using Ejercicio2_7.DLL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_7.DLL.Repository
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly DB_TURNOSContext _context;

        public ServicioRepository(DB_TURNOSContext context)
        {
            _context = context;
        }

        //        ++ Crear un segundo proyecto de tipo librería (DLL) que exponga los servicios para:
        //        --registrar, consultar (con filtros), editar y registrar la baja lógica de servicios.

        public async Task<List<Servicio>> GetAllASYNC(string promo)
        {
            List<Servicio> servicios;
            if (string.IsNullOrWhiteSpace(promo))
                servicios = await _context.TServicios.ToListAsync();
            else
                servicios = await _context.TServicios.Where(s => s.EnPromocion == promo).ToListAsync();

            return servicios;
        }

        public async Task<Servicio> GetASYNC(int id)
        {
            return await _context.TServicios.FindAsync(id);
        }
        public async Task<bool> SaveASYNC(Servicio servicio)
        {
            if (servicio.Id == 0)
            {
                await _context.TServicios.AddAsync(servicio);
            }
            else
            {
                _context.TServicios.Update(servicio);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> LogicDeleteASYNC(int id)
        {
            Servicio s = await GetASYNC(id);
            //if (s != null && s.Estado != false)
            //{
            //    s.Estado = false;
            //}
            return await _context.SaveChangesAsync() > 0;

        }

    }
}
