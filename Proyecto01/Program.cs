using System;

namespace Proyecto01
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaDoble lista = new ListaDoble();
            Pila pila = new Pila();
            Cola cola = new Cola();

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("   SISTEMA DE ESTRUCTURAS - IPC2");
                Console.WriteLine("=======================================");
                Console.WriteLine("1. Cargar datos desde archivo (datos.txt)");
                Console.WriteLine("2. Gestionar Lista Doble (Buscar/Eliminar)");
                Console.WriteLine("3. Probador de Pila (LIFO)");
                Console.WriteLine("4. Probador de Cola (FIFO)");
                Console.WriteLine("5. Salir");
                Console.WriteLine("=======================================");
                Console.Write("Selecciona una opcion: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("\n--- Cargando Archivo ---");
                        bool exito = GestorArchivos.CargarArchivo("datos.txt", lista);
                        if (exito)
                        {
                            Console.WriteLine("\n¡Datos cargados a la Lista Doble con exito!");
                            lista.MostrarAdelante();
                        }
                        Pausar();
                        break;

                    case "2":
                        Console.WriteLine("\n--- Estado de la Lista Doble ---");
                        lista.MostrarAdelante();
                        Console.Write("\nIngresa el valor a buscar/eliminar: ");
                        string busqueda = Console.ReadLine();

                        if (lista.Buscar(busqueda))
                        {
                            Console.WriteLine($"\nEl elemento '{busqueda}' EXISTE en la lista.");
                            Console.Write("¿Deseas eliminarlo? (s/n): ");
                            if (Console.ReadLine().ToLower() == "s")
                            {
                                lista.Eliminar(busqueda);
                                Console.WriteLine("Elemento eliminado exitosamente.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"\nEl elemento '{busqueda}' NO existe.");
                        }
                        Pausar();
                        break;

                    case "3":
                        Console.WriteLine("\n--- Apilar Elemento ---");
                        Console.Write("Ingresa un valor para la Pila: ");
                        string valorPila = Console.ReadLine();
                        pila.Push(valorPila);
                        Console.WriteLine("\nEstado actual de la Pila:");
                        pila.Mostrar();
                        Pausar();
                        break;

                    case "4":
                        Console.WriteLine("\n--- Encolar Elemento ---");
                        Console.Write("Ingresa un valor para la Cola: ");
                        string valorCola = Console.ReadLine();
                        cola.Encolar(valorCola);
                        Console.WriteLine("\nEstado actual de la Cola:");
                        cola.Mostrar();
                        Pausar();
                        break;

                    case "5":
                        salir = true;
                        Console.WriteLine("\nSaliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("\nOpcion no valida.");
                        Pausar();
                        break;
                }
            }
        }

        static void Pausar()
        {
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}