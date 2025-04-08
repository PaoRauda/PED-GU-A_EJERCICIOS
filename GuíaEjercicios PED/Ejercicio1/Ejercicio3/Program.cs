using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var colaPrioridad = new ColaPrioridadMinHeap();

            //Se crean los pacientes
            var paciente1 = new Paciente("Ana", 3);
            var paciente2 = new Paciente("Luis", 1);
            var paciente3 = new Paciente("Sofía", 2);
            var paciente4 = new Paciente("Marta", 1);
            var paciente5 = new Paciente("Pedro", 2);

            //Se insertan a la cola
            colaPrioridad.Insertar(paciente1);
            colaPrioridad.Insertar(paciente2);
            colaPrioridad.Insertar(paciente3);
            colaPrioridad.Insertar(paciente4);
            colaPrioridad.Insertar(paciente5);

            //Se re-ordenan
            Console.WriteLine("Orden de atención de los pacientes:");

            while (colaPrioridad.Count > 0)
            {
                var pacienteAtendido = colaPrioridad.ExtraerMinimo();
                Console.WriteLine($"{pacienteAtendido.Nombre} (Prioridad {pacienteAtendido.Prioridad})");
            }
        }
    }
}
