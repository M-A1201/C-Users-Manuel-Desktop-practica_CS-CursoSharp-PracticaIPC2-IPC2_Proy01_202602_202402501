using System;

namespace Proyecto01
{
    class Program
    {
        // Variable para mantener en memoria la ciudad cargada del XML
        static Ciudad ciudadActual = null;
        static ListaDoble lista = new ListaDoble();
        static Pila pila = new Pila();
        static Cola cola = new Cola();

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("==========================================");
                Console.WriteLine("     SISTEMA DE ESTRUCTURAS - IPC2       ");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Cargar Archivo XML (Ciudad / Robots)");
                Console.WriteLine("2. Gestionar Lista Doble (Buscar/Eliminar)");
                Console.WriteLine("3. Gestionar Pila (Push / Pop)");
                Console.WriteLine("4. Gestionar Cola (Encolar / Desencolar)");
                Console.WriteLine("5. Graficar Lista Doble (Graphviz)");
                Console.WriteLine("6. Graficar Pila (Graphviz)");
                Console.WriteLine("7. Graficar Cola (Graphviz)");
                Console.WriteLine("8. Graficar Mapa 2D de la Ciudad (Graphviz)");
                Console.WriteLine("9. Salir");
                Console.WriteLine("==========================================");
                Console.Write("Selecciona una opcion: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("\n--- Cargar Archivo XML ---");
                        Console.Write("Ingrese el nombre del archivo XML: ");
                        string ruta = Console.ReadLine();
                        
                        // Guardamos la ciudad procesada en la variable global
                        ciudadActual = CargadorXML.CargarConfiguracion(ruta);
                        break;

                    case "5":
                        Graficador.GenerarGraficaListaDoble(lista, "grafica_lista_doble");
                        break;

                    case "6":
                        Graficador.GenerarGraficaPila(pila, "grafica_pila");
                        break;

                    case "7":
                        Graficador.GenerarGraficaCola(cola, "grafica_cola");
                        break;

                    case "8":
                        if (ciudadActual != null)
                        {
                            Graficador.GraficarCiudad(ciudadActual, "grafica_ciudad");
                        }
                        else
                        {
                            Console.WriteLine("\n[Error] Primero debes cargar un archivo XML con la Opción 1.");
                        }
                        break;

                    case "9":
                        salir = true;
                        continue;

                    default:
                        Console.WriteLine("\nOpción no válida.");
                        break;
                }

                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}