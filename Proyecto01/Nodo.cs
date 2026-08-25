class Nodo
{
 //atributos de la clase
 private object dato;
 private Nodo siguiente;

 //propiedad para el atributo dato
 public object Dato
    {
        get{return dato;}
        set{dato=value;}
    }   

    //propiedad para el atributo siguiente
    public Nodo Siguiente
    {
        get{return siguiente;}
        set{siguiente=value;}
    }

    //constructor
    public Nodo(object dato)
    {
        this.dato=dato;
        this.siguiente=null;
    }
}