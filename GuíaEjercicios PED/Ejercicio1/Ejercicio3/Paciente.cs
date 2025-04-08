using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    public class Paciente
    {
        public string Nombre { get; set; }
        public int Prioridad { get; set; }

        public Paciente(string nombre, int prioridad)
        {
            Nombre = nombre;
            Prioridad = prioridad;
        }
    }
}
