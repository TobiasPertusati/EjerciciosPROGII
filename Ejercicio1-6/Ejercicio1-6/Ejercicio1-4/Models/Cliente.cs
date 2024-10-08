﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Dni { get; set; }

        public override string ToString()
        {
            return $"{Nombre} | {Apellido} | {Dni}";
        }
    }
}
