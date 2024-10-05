using Clase24_09.DLL.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase24_09.DLL.Data.Repository
{
    public class TurnoRepository : ITurnoRepository
    {
        private DB_TURNOSContext _context;
        public TurnoRepository(DB_TURNOSContext context)
        {
            _context = context;
        }

        public List<Turno> GetAll()
        {
            return _context.TTurnos.ToList();
        }

        public bool Save(Turno turno)
        {
            _context.TTurnos.Add(turno);
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(Turno turno)
        {
            _context.TTurnos.Update(turno);
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(int id)
        {
            Turno turno = _context.TTurnos.Find(id);
            if (turno != null)
            {
                _context.TTurnos.Remove(turno);
            }
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
