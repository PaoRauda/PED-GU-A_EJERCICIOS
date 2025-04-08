using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    internal class ElementoColaPrioridad
    {
        public int Distancia { get; set; }
        public string Ciudad { get; set; }

        public ElementoColaPrioridad(int distancia, string ciudad)
        {
            Distancia = distancia;
            Ciudad = ciudad;
        }
    }
}
