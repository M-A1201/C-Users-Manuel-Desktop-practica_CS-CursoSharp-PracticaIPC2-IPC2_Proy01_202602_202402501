using System;

namespace Proyecto01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PRUEBA DE PILA (LIFO) ===");
            Pila pila = new Pila();
            pila.Push("Tarea 1");
            pila.Push("Tarea 2");
            pila.Push("Tarea 3");
            pila.Mostrar();

            Console.WriteLine("\n=== PRUEBA DE COLA (FIFO) ===");
            Cola cola = new Cola();
            cola.Encolar("Cliente A");
            cola.Encolar("Cliente B");
            cola.Encolar("Cliente C");
            cola.Mostrar();

            Console.WriteLine("\n=== PRUEBA BUSQUEDA Y ELIMINACION EN LISTA DOBLE ===");
            ListaDoble lista = new ListaDoble();
            lista.Agregar("Guatemala");
            lista.Agregar("Quetzaltenango");
            lista.Agregar("Escuintla");

            Console.WriteLine("¿Existe 'Escuintla'?: " + lista.Buscar("Escuintla"));
            lista.Eliminar("Quetzaltenango");
            Console.WriteLine("\nLista tras eliminar 'Quetzaltenango':");
            lista.MostrarAdelante();
        }
    }
}