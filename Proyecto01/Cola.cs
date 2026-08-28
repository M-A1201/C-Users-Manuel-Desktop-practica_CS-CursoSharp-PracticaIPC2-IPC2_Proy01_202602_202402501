using System;

namespace Proyecto01
{
    public class Cola
    {
        private ListaDoble lista;

        public Cola()
        {
            lista = new ListaDoble();
        }

        public int Contador
        {
            get { return lista.Contador; }
        }

        // Encolar: agrega al final de la cola
        public void Encolar(object dato)
        {
            lista.Agregar(dato);
        }

        // Desencolar: remueve el primer elemento ingresado
        public object Desencolar()
        {
            if (lista.Contador == 0)
            {
                Console.WriteLine("La Cola está vacía.");
                return null;
            }

            // Obtenemos el dato de la cabeza (primer elemento) y lo eliminamos
            NodoDoble cabeza = lista.Cabeza;
            object valor = cabeza.Dato;
            lista.Eliminar(valor.ToString());
            return valor;
        }

        // Mostrar elementos de la cola
        public void Mostrar()
        {
            lista.MostrarAdelante();
        }

        // Propiedad pública para permitir la lectura del frente desde el Graficador
        public NodoDoble Frente
        {
            get { return lista.Cabeza; } // El frente de la cola es la cabeza de la lista
        }
    }
}