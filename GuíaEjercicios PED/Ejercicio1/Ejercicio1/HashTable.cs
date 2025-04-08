using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class HashTable
    {
        private List<List<string>> table;
        private int size = 7; // modulo 7

        public HashTable()
        {
            // Se Inicializa la tabla con listas vacías
            table = new List<List<string>>(new List<string>[size]);
            for (int i = 0; i < size; i++)
            {
                table[i] = new List<string>();
            }
        }

        // Función hash que suma de valores ASCII y obtiene módulo 7
        private int Hash(string key)
        {
            int sum = 0;
            foreach (char c in key)
            {
                sum += (int)c;
            }
            return sum % size;
        }

        // Insertar un código de seguimiento en la tabla hash
        public void Insertar(string trackingCode)
        {
            int index = Hash(trackingCode);
            table[index].Add(trackingCode);
        }

        public void imprimirTabla()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Índice {i}: ");
                foreach (var code in table[i])
                {
                    Console.Write(code + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
