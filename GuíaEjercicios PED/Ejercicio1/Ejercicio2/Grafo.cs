using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public class Grafo
    {
        private Dictionary<string, List<(string, int)>> listaNodos;

        public Grafo()
        {
            listaNodos = new Dictionary<string, List<(string, int)>>();
        }

        public void AgregarArista(string ciudad1, string ciudad2, int peso)
        {
            if (!listaNodos.ContainsKey(ciudad1))
                listaNodos[ciudad1] = new List<(string, int)>();
            if (!listaNodos.ContainsKey(ciudad2))
                listaNodos[ciudad2] = new List<(string, int)>();

            listaNodos[ciudad1].Add((ciudad2, peso));
            listaNodos[ciudad2].Add((ciudad1, peso));
        }


        public Dictionary<string, int> Dijkstra(string inicio) //Se implementa algoritmo
        {
            var distancias = new Dictionary<string, int>();
            var anteriores = new Dictionary<string, string>();
            var colaPrioridad = new SortedSet<ElementoColaPrioridad>(Comparer<ElementoColaPrioridad>.Create((x, y) =>
            {
                if (x.Distancia == y.Distancia)
                    return x.Ciudad.CompareTo(y.Ciudad);
                return x.Distancia.CompareTo(y.Distancia);
            }));

            foreach (var ciudad  in listaNodos.Keys)
            {
                distancias[ciudad] = int.MaxValue; // Inicializacion de distancias con infinito
                anteriores[ciudad] = null;
                colaPrioridad.Add(new ElementoColaPrioridad(distancias[ciudad], ciudad));
            }

            distancias[inicio] = 0; //Inicializacion de distancia propia
            colaPrioridad.Add(new ElementoColaPrioridad(0, inicio));

            while (colaPrioridad.Count > 0)
            {
                var actual = colaPrioridad.Min; // Se Obtiene el nodo con la distancia más corta
                colaPrioridad.Remove(actual);

                string ciudadActual = actual.Ciudad;
                int distanciaActual = actual.Distancia;

                if (distanciaActual == int.MaxValue)
                    break;

                foreach (var (vecino, peso) in listaNodos[ciudadActual])
                {
                    int nuevaDistancia = distanciaActual + peso;

                    if (nuevaDistancia < distancias[vecino])
                    {
                        colaPrioridad.Remove(new ElementoColaPrioridad(distancias[vecino], vecino));
                        distancias[vecino] = nuevaDistancia;
                        anteriores[vecino] = ciudadActual;
                        colaPrioridad.Add(new ElementoColaPrioridad(nuevaDistancia, vecino));
                    }
                }
            }

            return distancias;
        }

        // Método para obtener el camino más corto
        public List<string> ObtenerCaminoMasCorto(string inicio, string fin)
        {
            var camino = new List<string>();
            var anteriores = new Dictionary<string, string>();
            var distancias = Dijkstra(inicio);

            string actual = fin;
            while (actual != null)
            {
                camino.Insert(0, actual);
                actual = anteriores.ContainsKey(actual) ? anteriores[actual] : null;
            }

            return camino;
        }
    }
}
