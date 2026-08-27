using System;

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

// Propiedad para obtener el último nodo (cola/fin) de la lista doble
public NodoDoble Cola
{
    get { return cola; } // Si llamaste 'ultimo' a la variable privada, pon: return ultimo;
}

    // Propiedad para que el Graficador lea la cabeza
public NodoDoble Cabeza
{
    get { return cabeza; }
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

    // Recorrido desde la cabeza hacia la cola (inicio a fin)
    public void MostrarAdelante()
    {
        NodoDoble actual = this.cabeza;
        while (actual != null)
        {
            Console.WriteLine("- " + actual.Dato);
            actual = actual.Siguiente;
        }
    }

    // Recorrido desde la cola hacia la cabeza (fin a inicio)
    public void MostrarAtras()
    {
        NodoDoble actual = this.cola;
        while (actual != null)
        {
            Console.WriteLine("- " + actual.Dato);
            actual = actual.Anterior;
        }
    }

    // --- NUEVOS MÉTODOS SEMANA 3 ---

    // Método para buscar si un dato existe en la lista
    public bool Buscar(object dato)
    {
        NodoDoble actual = this.cabeza;
        while (actual != null)
        {
            if (actual.Dato != null && actual.Dato.Equals(dato))
            {
                return true;
            }
            actual = actual.Siguiente;
        }
        return false;
    }

    // Método para eliminar un elemento de la lista por valor
    public bool Eliminar(object dato)
    {
        NodoDoble actual = this.cabeza;

        while (actual != null)
        {
            if (actual.Dato != null && actual.Dato.Equals(dato))
            {
                // Caso 1: Es el único nodo o es la Cabeza
                if (actual == this.cabeza)
                {
                    this.cabeza = this.cabeza.Siguiente;
                    if (this.cabeza != null)
                    {
                        this.cabeza.Anterior = null;
                    }
                    else
                    {
                        this.cola = null; // La lista quedó vacía
                    }
                }
                // Caso 2: Es la Cola
                else if (actual == this.cola)
                {
                    this.cola = this.cola.Anterior;
                    this.cola.Siguiente = null;
                }
                // Caso 3: Está en medio
                else
                {
                    actual.Anterior.Siguiente = actual.Siguiente;
                    actual.Siguiente.Anterior = actual.Anterior;
                }

                this.contador--;
                return true; // Eliminado con éxito
            }
            actual = actual.Siguiente;
        }

        return false; // No se encontró el elemento
    }





}
