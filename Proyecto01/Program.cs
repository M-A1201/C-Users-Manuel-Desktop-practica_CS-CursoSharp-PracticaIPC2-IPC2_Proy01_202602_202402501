using System;
class Program
{
    static void Main(string[]args)
    {
      ListaSimple lista1 = new ListaSimple();

            // Insertamos datos de prueba
            lista1.Agregar("Guatemala");
            lista1.Agregar("Escuintla");
            lista1.Agregar("Quetzaltenango");

            // Imprimimos el contenido y el contador
            Console.WriteLine("--- Elementos en la Lista ---");
            lista1.Mostrar();

            Console.WriteLine("\nTotal de elementos: " + lista1.Contador);  }
}