using System;


    class Pila
    {
        private ListaDoble lista;

        public Pila()
        {
            lista = new ListaDoble();
        }

        public int Contador
        {
            get { return lista.Contador; }
        }

        // Insertar elemento en el tope de la pila (Push)
        public void Push(object dato)
        {
            lista.Agregar(dato);
        }

        // Mostrar elementos de la pila
        public void Mostrar()
        {
            lista.MostrarAtras(); // La pila se lee del último ingresado hacia abajo
        }
    }
