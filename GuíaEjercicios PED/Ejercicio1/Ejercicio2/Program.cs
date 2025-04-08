using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Inicializacion de variables y se agregan datos
            var grafo = new Grafo();
            grafo.AgregarArista("A", "B", 5);
            grafo.AgregarArista("A", "C", 2);
            grafo.AgregarArista("B", "C", 1);
            grafo.AgregarArista("B", "D", 3);
            grafo.AgregarArista("C", "D", 4);
            grafo.AgregarArista("D", "E", 2);

            var distancias = grafo.Dijkstra("A");

            Console.WriteLine("Distancia más corta de A a E: " + distancias["E"]);

            var camino = grafo.ObtenerCaminoMasCorto("A", "E");
            Console.WriteLine("Camino más corto de A a E:");
            foreach (var ciudad in camino)
            {
                Console.Write(ciudad + " ");
            }
        }
    }
}
