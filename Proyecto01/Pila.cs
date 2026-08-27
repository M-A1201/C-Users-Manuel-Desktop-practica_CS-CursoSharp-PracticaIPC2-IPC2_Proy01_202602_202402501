using System;

namespace Proyecto01
{
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

        // Insertar elemento en la pila
        public void Push(object dato)
        {
            lista.Agregar(dato);
        }

        // Retirar el último elemento ingresado (Pop / Desapilar)
        public object Pop()
        {
            if (lista.Contador == 0)
            {
                Console.WriteLine("La Pila está vacía.");
                return null;
            }

            // Obtenemos el dato de la cola (último elemento) y lo eliminamos
            NodoDoble cola = lista.Cola;
            object valor = cola.Dato;
            lista.Eliminar(valor.ToString());
            return valor;
        }

        // Mostrar elementos de la pila
        public void Mostrar()
        {
            lista.MostrarAtras();
        }

        // Propiedad pública para permitir la lectura del tope desde el Graficador
        public NodoDoble Tope
        {
            get { return lista.Cola; } // El tope de la pila es el último elemento en la lista
        }
    }
}