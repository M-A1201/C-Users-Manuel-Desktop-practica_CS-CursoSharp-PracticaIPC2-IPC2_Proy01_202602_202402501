using System;

namespace Proyecto01
{
    class Program
    {
        static Ciudad ciudadActual = null;
        static Robot robotSeleccionado = null;
        static ListaDoble lista = new ListaDoble();
        static Pila pilaHistorial = new Pila();
        static Cola colaPasos = new Cola();

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
                Console.WriteLine("2. Seleccionar Robot y Ejecutar Misión");
                Console.WriteLine("3. Gestionar Lista Doble (Buscar/Eliminar)");
                Console.WriteLine("4. Gestionar Pila de Pasos (Push / Pop)");
                Console.WriteLine("5. Gestionar Cola de Acciones (Encolar / Desencolar)");
                Console.WriteLine("6. Graficar Lista Doble (Graphviz)");
                Console.WriteLine("7. Graficar Pila (Graphviz)");
                Console.WriteLine("8. Graficar Cola (Graphviz)");
                Console.WriteLine("9. Graficar Mapa 2D de la Ciudad (Graphviz)");
                Console.WriteLine("10. Salir");
                Console.WriteLine("==========================================");
                Console.Write("Selecciona una opcion: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("\n--- Cargar Archivo XML ---");
                        Console.Write("Ingrese el nombre del archivo XML: ");
                        string ruta = Console.ReadLine();
                        
                        ciudadActual = CargadorXML.CargarConfiguracion(ruta);
                        break;

                    case "2":
                        if (ciudadActual == null)
                        {
                            Console.WriteLine("\n[Error] Primero debe cargar el archivo XML de la ciudad (Opción 1).");
                        }
                        else
                        {
                            Console.WriteLine("\n--- SELECCIÓN DE ROBOT ---");
                            Console.WriteLine("1. robotRescue01 (ChapinRescue - Capacidad: 0)");
                            Console.WriteLine("2. robotFighter01 (ChapinFighter - Capacidad: 100)");
                            Console.WriteLine("3. robotFighter03 (ChapinFighter - Capacidad: 200)");
                            Console.Write("Seleccione el robot a desplegar (1-3): ");
                            string opRobot = Console.ReadLine();

                            if (opRobot == "1")
                                robotSeleccionado = new Robot("robotRescue01", "ChapinRescue", 0);
                            else if (opRobot == "2")
                                robotSeleccionado = new Robot("robotFighter01", "ChapinFighter", 100);
                            else if (opRobot == "3")
                                robotSeleccionado = new Robot("robotFighter03", "ChapinFighter", 200);

                            if (robotSeleccionado != null)
                            {
                                Simulador.EjecutarMision(ciudadActual, robotSeleccionado, colaPasos, pilaHistorial);
                            }
                        }
                        break;

                    case "6":
                        Graficador.GenerarGraficaListaDoble(lista, "grafica_lista_doble");
                        break;

                    case "7":
                        Graficador.GenerarGraficaPila(pilaHistorial, "grafica_pila");
                        break;

                    case "8":
                        Graficador.GenerarGraficaCola(colaPasos, "grafica_cola");
                        break;

                    case "9":
                        if (ciudadActual != null)
                        {
                            Graficador.GraficarCiudad(ciudadActual, "grafica_ciudad");
                        }
                        else
                        {
                            Console.WriteLine("\n[Error] Primero debes cargar un archivo XML con la Opción 1.");
                        }
                        break;

                    case "10":
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