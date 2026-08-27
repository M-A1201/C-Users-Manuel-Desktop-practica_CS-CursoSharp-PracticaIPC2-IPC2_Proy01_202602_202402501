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
                Console.WriteLine("3. Gestionar Pila (Push / Pop)");
                Console.WriteLine("4. Gestionar Cola (Encolar / Desencolar)");
                Console.WriteLine("5. Graficar Lista Doble (Graphviz)");
                Console.WriteLine("6. Graficar Pila (Graphviz)");
                Console.WriteLine("7. Graficar Cola (Graphviz)");
                Console.WriteLine("8. Salir");
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
                        Console.WriteLine("\n--- Opciones de Pila ---");
                        Console.WriteLine("1. Apilar (Push)");
                        Console.WriteLine("2. Desapilar (Pop)");
                        Console.Write("Selecciona: ");
                        string subPila = Console.ReadLine();
                        if (subPila == "1")
                        {
                            Console.Write("Ingresa el valor: ");
                            pila.Push(Console.ReadLine());
                        }
                        else if (subPila == "2")
                        {
                            pila.Pop();
                        }
                        Console.WriteLine("\nEstado actual de la Pila:");
                        pila.Mostrar();
                        Pausar();
                        break;

                    case "4":
                        Console.WriteLine("\n--- Opciones de Cola ---");
                        Console.WriteLine("1. Encolar");
                        Console.WriteLine("2. Desencolar");
                        Console.Write("Selecciona: ");
                        string subCola = Console.ReadLine();
                        if (subCola == "1")
                        {
                            Console.Write("Ingresa el valor: ");
                            cola.Encolar(Console.ReadLine());
                        }
                        else if (subCola == "2")
                        {
                            cola.Desencolar();
                        }
                        Console.WriteLine("\nEstado actual de la Cola:");
                        cola.Mostrar();
                        Pausar();
                        break;

                    case "5":
                        Console.WriteLine("\n--- Graficando Lista Doble ---");
                        Graficador.GenerarGraficaListaDoble(lista, "grafica_lista_doble");
                        Pausar();
                        break;

                    case "6":
                        Console.WriteLine("\n--- Graficando Pila ---");
                        Graficador.GenerarGraficaPila(pila, "grafica_pila");
                        Pausar();
                        break;

                    case "7":
                        Console.WriteLine("\n--- Graficando Cola ---");
                        Graficador.GenerarGraficaCola(cola, "grafica_cola");
                        Pausar();
                        break;

                    case "8":
                        salir = true;
                        Console.WriteLine("\nSaliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida.");
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