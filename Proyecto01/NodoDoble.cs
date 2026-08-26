namespace Proyecto01
{
    class NodoDoble
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
    }
}