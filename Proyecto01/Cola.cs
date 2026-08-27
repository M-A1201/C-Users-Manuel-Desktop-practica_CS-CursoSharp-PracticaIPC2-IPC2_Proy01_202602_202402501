using System;

namespace Proyecto01
{
    class Cola
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

        // Mostrar elementos de la cola (de primero a último ingresado)
        public void Mostrar()
        {
            lista.MostrarAdelante();
        }
    }
}