using System;
class Program
{
    static void Main(string[]args)
    {
      ListaSimple lista1 = new ListaSimple();

            lista1.Agregar("Guatemala");
            lista1.Agregar("Escuintla");
            lista1.Agregar("Quetzaltenango");

            Console.WriteLine("--- Lista Inicial ---");
            lista1.Mostrar();

            // Prueba de Búsqueda
            Console.WriteLine("\n¿Existe Escuintla?: " + lista1.Buscar("Escuintla"));
            Console.WriteLine("¿Existe Petén?: " + lista1.Buscar("Petén"));

            // Prueba de Eliminación
            Console.WriteLine("\nEliminando 'Escuintla'...");
            lista1.Eliminar("Escuintla");

            Console.WriteLine("\n--- Lista Tras Eliminar ---");
            lista1.Mostrar();
            Console.WriteLine("Total de elementos: " + lista1.Contador);
         }
}