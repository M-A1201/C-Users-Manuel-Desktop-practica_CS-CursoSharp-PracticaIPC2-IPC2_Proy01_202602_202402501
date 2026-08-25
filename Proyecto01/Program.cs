using System;
class Program
{
    static void Main(string[]args)
    {
        Nodo nodo1=new Nodo("verificando que funcione la clase nodo");
        Console.WriteLine("Dato del nodo: " + nodo1
        .Dato);
         Console.WriteLine("Siguiente nodo: " + (nodo1.Siguiente == null ? "null" : "existe"));
    }
}