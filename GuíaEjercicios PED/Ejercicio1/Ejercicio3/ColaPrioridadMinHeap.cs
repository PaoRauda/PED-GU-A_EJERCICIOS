using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    public class ColaPrioridadMinHeap
    {
        private List<Paciente> heap;

        public ColaPrioridadMinHeap()
        {
            heap = new List<Paciente>();
        }

        public void Insertar(Paciente paciente)
        {
            heap.Add(paciente);
            Subir(heap.Count - 1);
        }

        public Paciente ExtraerMinimo()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("La cola está vacía.");

            Paciente minPaciente = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            Bajar(0);

            return minPaciente;
        }

        public int Count => heap.Count;

        private void Subir(int index)
        {
            int padre = (index - 1) / 2;
            if (index > 0 && heap[index].Prioridad < heap[padre].Prioridad)
            {
                Intercambiar(index, padre);
                Subir(padre);
            }
        }

        private void Bajar(int index)
        {
            int izquierda = 2 * index + 1;
            int derecha = 2 * index + 2;
            int menor = index;

            if (izquierda < heap.Count && heap[izquierda].Prioridad < heap[menor].Prioridad)
                menor = izquierda;
            if (derecha < heap.Count && heap[derecha].Prioridad < heap[menor].Prioridad)
                menor = derecha;

            if (menor != index)
            {
                Intercambiar(index, menor);
                Bajar(menor);
            }
        }

        private void Intercambiar(int i, int j)
        {
            Paciente temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}
