using System;

namespace Proyecto01
{
    class ListaDoble
    {
        // Atributos privados para controlar el inicio, fin y tamaño de la lista
        private NodoDoble cabeza;
        private NodoDoble cola;
        private int contador;

        // Constructor para inicializar la lista doblemente enlazada vacía
        public ListaDoble()
        {
            this.cabeza = null;
            this.cola = null;
            this.contador = 0;
        }

        // Propiedad de solo lectura para obtener el total de elementos
        public int Contador
        {
            get { return contador; }
        }

// Método para agregar un elemento al final de la lista doble
        public void Agregar(object dato)
        {
            NodoDoble nuevo = new NodoDoble(dato);

            // Si la lista está vacía, el nuevo nodo es tanto la cabeza como la cola
            if (this.cabeza == null)
            {
                this.cabeza = nuevo;
                this.cola = nuevo;
            }
            else
            {
                // Conectamos la cola actual con el nuevo nodo y viceversa
                this.cola.Siguiente = nuevo;
                nuevo.Anterior = this.cola;
                this.cola = nuevo; // La cola pasa a ser el nuevo nodo
            }

            this.contador++;
        }





    }
}