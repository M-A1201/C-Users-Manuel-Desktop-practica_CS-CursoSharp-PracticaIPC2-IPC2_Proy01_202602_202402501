using System;

    public class NodoDoble
    {
        // Atributos privados para el manejo del dato y punteros doblemente enlazados
        private object dato;
        private NodoDoble siguiente;
        private NodoDoble anterior;

        // Constructor para inicializar el nodo con un dato
        public NodoDoble(object dato)
        {
            this.dato = dato;
            this.siguiente = null;
            this.anterior = null;
        }
        // Propiedad para obtener y modificar el valor almacenado
        public object Dato
        {
            get { return dato; }
            set { dato = value; }
        }

        // Propiedad para obtener y modificar la referencia al siguiente nodo
        public NodoDoble Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }

        // Propiedad para obtener y modificar la referencia al nodo anterior
        public NodoDoble Anterior
        {
            get { return anterior; }
            set { anterior = value; }
        }
    }
