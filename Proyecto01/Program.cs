using System;


    class Program
    {
        static void Main(string[] args)
        {
            // Pruebas de la Lista Simplemente Enlazada (Semana 1)
            ListaSimple lista1 = new ListaSimple();
            lista1.Agregar("Guatemala");
            lista1.Agregar("Escuintla");
            lista1.Agregar("Quetzaltenango");

            Console.WriteLine("=== PRUEBAS LISTA SIMPLE ===");
            lista1.Mostrar();

            // Pruebas de la Lista Doblemente Enlazada (Semana 2)
            Console.WriteLine("\n=== PRUEBAS LISTA DOBLE ===");
            ListaDoble listaDoble = new ListaDoble();
            listaDoble.Agregar("Manzana");
            listaDoble.Agregar("Bananos");
            listaDoble.Agregar("Naranja");

            Console.WriteLine("\nRecorrido hacia adelante (Cabeza -> Cola):");
            listaDoble.MostrarAdelante();

            Console.WriteLine("\nRecorrido hacia atras (Cola -> Cabeza):");
            listaDoble.MostrarAtras();

            Console.WriteLine("\nTotal de elementos en Lista Doble: " + listaDoble.Contador);
        }
    }
