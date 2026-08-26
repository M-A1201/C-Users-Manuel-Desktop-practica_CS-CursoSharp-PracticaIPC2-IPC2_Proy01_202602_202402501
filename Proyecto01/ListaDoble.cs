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
    }
}