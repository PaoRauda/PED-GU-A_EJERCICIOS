using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashTable hashTable = new HashTable();
            string[] arrayCodigos = { "MZ123", "QK456", "PL789", "MN321", "QK654", "PL987", "MZ321" };

            //Se insertan los codigos
            foreach (var codigo in arrayCodigos)
            {
                hashTable.Insertar(codigo);
            }

            Console.WriteLine("Resultado de codigos guardados en Tabla Hash:");
            hashTable.imprimirTabla();

        }
    }
}
