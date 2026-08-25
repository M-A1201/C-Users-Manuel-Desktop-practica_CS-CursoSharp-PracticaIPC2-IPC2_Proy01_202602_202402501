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
}
