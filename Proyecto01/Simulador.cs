using System;

namespace Proyecto01
{
    public class Simulador
    {
        public static void EjecutarMision(Ciudad ciudad, Robot robot, Cola colaPasos, Pila pilaHistorial)
        {
            if (ciudad == null || robot == null)
            {
                Console.WriteLine("\n[Error] Debe cargar una ciudad y tener un robot seleccionado.");
                return;
            }

            Console.WriteLine($"\n==========================================");
            Console.WriteLine($"   INICIANDO SIMULACIÓN DE MISIÓN");
            Console.WriteLine($"==========================================");
            Console.WriteLine($"Robot: {robot.Nombre} | Tipo: {robot.Tipo}");
            Console.WriteLine($"Capacidad Inicial: {robot.CapacidadCombate}");

            int capacidadInicial = robot.CapacidadCombate;
            int capacidadActual = robot.CapacidadCombate;

            // Buscar posición de entrada 'E'
            int inicioFila = -1, inicioCol = -1;
            for (int f = 0; f < ciudad.Filas; f++)
            {
                for (int c = 0; c < ciudad.Columnas; c++)
                {
                    if (ciudad.Tablero[f, c] != null && ciudad.Tablero[f, c].Tipo == 'E')
                    {
                        inicioFila = f;
                        inicioCol = c;
                        break;
                    }
                }
                if (inicioFila != -1) break;
            }

            if (inicioFila == -1)
            {
                Console.WriteLine("\n[Error] No se encontró punto de Entrada 'E' en el mapa.");
                return;
            }

            Console.WriteLine($"\nPunto de partida: Entrada E ({inicioFila}, {inicioCol})");
            
            // Simulación paso a paso
            bool exitoMision = true;
            for (int f = 0; f < ciudad.Filas; f++)
            {
                for (int c = 0; c < ciudad.Columnas; c++)
                {
                    Casilla casilla = ciudad.Tablero[f, c];
                    if (casilla != null)
                    {
                        // Regla para Robot de Combate
                        if (casilla.CapacidadMilitar > 0)
                        {
                            if (robot.Tipo.ToLower().Contains("fighter") || robot.Tipo.ToLower().Contains("combate"))
                            {
                                Console.WriteLine($"\nEncuentro militar en ({f},{c}) con poder: {casilla.CapacidadMilitar}");
                                if (capacidadActual >= casilla.CapacidadMilitar)
                                {
                                    capacidadActual -= casilla.CapacidadMilitar;
                                    Console.WriteLine($"-> Unidad enemiga eliminada. Capacidad restante: {capacidadActual}");
                                    
                                    string paso = $"Combate ({f},{c}) - Drenado: {casilla.CapacidadMilitar}";
                                    colaPasos.Encolar(paso);
                                    pilaHistorial.Push(paso);
                                }
                                else
                                {
                                    Console.WriteLine("-> [MISIÓN FALLIDA] Capacidad insuficiente para vencer a la unidad enemiga.");
                                    exitoMision = false;
                                    break;
                                }
                            }
                        }
                        // Regla para Rescate de Civiles
                        else if (casilla.Tipo == 'C')
                        {
                            Console.WriteLine($"\n[Civil Localizado] Casilla ({f},{c})");
                            string paso = $"Rescate Civil en ({f},{c})";
                            colaPasos.Encolar(paso);
                            pilaHistorial.Push(paso);
                        }
                        // Regla para Recolección de Recursos
                        else if (casilla.Tipo == 'R')
                        {
                            Console.WriteLine($"\n[Recurso Extraído] Casilla ({f},{c})");
                            string paso = $"Extracción Recurso en ({f},{c})";
                            colaPasos.Encolar(paso);
                            pilaHistorial.Push(paso);
                        }
                    }
                }
                if (!exitoMision) break;
            }

            Console.WriteLine($"\n------------------------------------------");
            Console.WriteLine($"         RESUMEN DE LA MISIÓN             ");
            Console.WriteLine($"------------------------------------------");
            Console.WriteLine($"Estado: {(exitoMision ? "EXITOSA" : "FALLIDA")}");
            Console.WriteLine($"Capacidad Inicial : {capacidadInicial}");
            Console.WriteLine($"Capacidad Final   : {capacidadActual}");
            Console.WriteLine($"==========================================\n");
        }
    }
}