class ListaSimple
{
    // Atributos privados de la clase Lista Simple
    private Nodo cabeza;
    private int contador;

    // Propiedades públicas para encapsulamiento
    public Nodo Cabeza
    {
        get { return cabeza; }
    }
    //metodo contador
    public int Contador
    {
        get { return contador; }
    }

    // Constructor
    public ListaSimple()
    {
        this.cabeza = null;
        this.contador = 0;
    }

    // Método para agregar un elemento al final de la lista
    public void Agregar(object dato)
    {
        Nodo nuevo = new Nodo(dato);

        if (this.cabeza == null)
        {
            this.cabeza = nuevo;
        }
        else
        {
            Nodo actual = this.cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }

        this.contador++;
    }

    // Método para imprimir los elementos de la lista
    public void Mostrar()
    {
        Nodo actual = this.cabeza; 

        while (actual != null)
        {
            Console.WriteLine("- " + actual.Dato);
            actual = actual.Siguiente;
        }
    }

    // Método para buscar si un dato existe en la lista
    public bool Buscar(object dato)
    {
        Nodo actual = this.cabeza;

        while (actual != null)
        {
            if (actual.Dato.Equals(dato))
            {
                return true; // Encontrado
            }
            actual = actual.Siguiente;
        }

        return false; // No encontrado
    }

    // Método para eliminar la primera ocurrencia de un dato
    public bool Eliminar(object dato)
    {
        if (this.cabeza == null) return false;

        // Caso 1: El dato a eliminar está en la cabeza
        if (this.cabeza.Dato.Equals(dato))
        {
            this.cabeza = this.cabeza.Siguiente;
            this.contador--;
            return true;
        }

        // Caso 2: El dato está en el cuerpo o al final
        Nodo actual = this.cabeza;
        while (actual.Siguiente != null)
        {
            if (actual.Siguiente.Dato.Equals(dato))
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                this.contador--;
                return true;
            }
            actual = actual.Siguiente;
        }

        return false;
    }
}
