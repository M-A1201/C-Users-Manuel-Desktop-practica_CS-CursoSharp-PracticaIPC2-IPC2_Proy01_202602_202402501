using System;
using System.IO;
using System.Diagnostics;

namespace Proyecto01
{
    class Graficador
    {
        // 1. Graficar Lista Doble
        public static void GenerarGraficaListaDoble(ListaDoble lista, string nombreArchivo)
        {
            string rutaDot = nombreArchivo + ".dot";
            string rutaPng = nombreArchivo + ".png";

            string contenidoDot = "digraph ListaDoble {\n";
            contenidoDot += "    rankdir=LR;\n";
            contenidoDot += "    node [shape=record, style=filled, fillcolor=lightblue];\n\n";

            NodoDoble actual = lista.Cabeza;

            if (actual == null)
            {
                contenidoDot += "    vacio [label=\"Lista Vacía\"];\n";
            }
            else
            {
                int contador = 0;
                while (actual != null)
                {
                    contenidoDot += $"    nodo{contador} [label=\"<ant> | <data> {actual.Dato} | <sig>\"];\n";
                    actual = actual.Siguiente;
                    contador++;
                }

                for (int i = 0; i < contador - 1; i++)
                {
                    contenidoDot += $"    nodo{i}:sig -> nodo{i + 1}:data;\n";
                    contenidoDot += $"    nodo{i + 1}:ant -> nodo{i}:data;\n";
                }
            }

            contenidoDot += "}\n";
            File.WriteAllText(rutaDot, contenidoDot);
            CompilarGraphviz(rutaDot, rutaPng);
        }

        // 2. Graficar Pila (LIFO - Orientación Vertical)
        public static void GenerarGraficaPila(Pila pila, string nombreArchivo)
        {
            string rutaDot = nombreArchivo + ".dot";
            string rutaPng = nombreArchivo + ".png";

            string contenidoDot = "digraph Pila {\n";
            contenidoDot += "    rankdir=TB;\n"; // Top to Bottom (Vertical)
            contenidoDot += "    node [shape=record, style=filled, fillcolor=lightyellow];\n\n";

            NodoDoble actual = pila.Tope;

            if (actual == null)
            {
                contenidoDot += "    vacio [label=\"Pila Vacía\"];\n";
            }
            else
            {
                int contador = 0;
                while (actual != null)
                {
                    contenidoDot += $"    nodo{contador} [label=\"{actual.Dato}\"];\n";
                    actual = actual.Siguiente;
                    contador++;
                }

                for (int i = 0; i < contador - 1; i++)
                {
                    contenidoDot += $"    nodo{i} -> nodo{i + 1};\n";
                }
            }

            contenidoDot += "}\n";
            File.WriteAllText(rutaDot, contenidoDot);
            CompilarGraphviz(rutaDot, rutaPng);
        }

        // 3. Graficar Cola (FIFO - Orientación Horizontal)
        public static void GenerarGraficaCola(Cola cola, string nombreArchivo)
        {
            string rutaDot = nombreArchivo + ".dot";
            string rutaPng = nombreArchivo + ".png";

            string contenidoDot = "digraph Cola {\n";
            contenidoDot += "    rankdir=LR;\n"; // Left to Right (Horizontal)
            contenidoDot += "    node [shape=record, style=filled, fillcolor=lightgreen];\n\n";

            NodoDoble actual = cola.Frente;

            if (actual == null)
            {
                contenidoDot += "    vacio [label=\"Cola Vacía\"];\n";
            }
            else
            {
                int contador = 0;
                while (actual != null)
                {
                    contenidoDot += $"    nodo{contador} [label=\"{actual.Dato}\"];\n";
                    actual = actual.Siguiente;
                    contador++;
                }

                for (int i = 0; i < contador - 1; i++)
                {
                    contenidoDot += $"    nodo{i} -> nodo{i + 1};\n";
                }
            }

            contenidoDot += "}\n";
            File.WriteAllText(rutaDot, contenidoDot);
            CompilarGraphviz(rutaDot, rutaPng);
        }

// 4. Graficar Matriz de la Ciudad (Mapa 2D)
public static void GraficarCiudad(Ciudad ciudad, string nombreArchivo = "grafica_ciudad")
{
    if (ciudad == null)
    {
        Console.WriteLine("\n[Error Graphviz] No hay ninguna ciudad cargada para graficar.");
        return;
    }

    string rutaDot = nombreArchivo + ".dot";
    string rutaPng = nombreArchivo + ".png";

    using (StreamWriter sw = new StreamWriter(rutaDot))
    {
        sw.WriteLine("digraph G {");
        sw.WriteLine("    node [shape=plaintext];");
        sw.WriteLine($"    label=\"Mapa: {ciudad.Nombre}\";");
        sw.WriteLine("    tablero [label=<");
        sw.WriteLine("        <TABLE BORDER=\"1\" CELLBORDER=\"1\" CELLSPACING=\"0\" CELLPADDING=\"4\">");

        for (int f = 0; f < ciudad.Filas; f++)
        {
            sw.WriteLine("            <TR>");
            for (int c = 0; c < ciudad.Columnas; c++)
            {
                Casilla casilla = ciudad.Tablero[f, c];
                string colorBg = "white"; 
                string texto = " ";

                if (casilla != null)
                {
                    if (casilla.CapacidadMilitar > 0)
                    {
                        colorBg = "red"; 
                        texto = casilla.CapacidadMilitar.ToString();
                    }
                    else
                    {
                        switch (casilla.Tipo)
                        {
                            case '*':
                                colorBg = "black";
                                break;
                            case 'E':
                                colorBg = "green";
                                texto = "E";
                                break;
                            case 'C':
                                colorBg = "dodgerblue";
                                texto = "C";
                                break;
                            case 'R':
                                colorBg = "yellow";
                                texto = "R";
                                break;
                            default:
                                colorBg = "white";
                                break;
                        }
                    }
                }

                string fontColor = (colorBg == "black") ? "white" : "black";
                sw.WriteLine($"                <TD BGCOLOR=\"{colorBg}\"><FONT COLOR=\"{fontColor}\"><B>{texto}</B></FONT></TD>");
            }
            sw.WriteLine("            </TR>");
        }

        sw.WriteLine("        </TABLE>");
        sw.WriteLine("    >];");
        sw.WriteLine("}");
    }

    CompilarGraphviz(rutaDot, rutaPng);
}




        private static void CompilarGraphviz(string rutaDot, string rutaPng)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "dot";
                psi.Arguments = $"-Tpng \"{rutaDot}\" -o \"{rutaPng}\"";
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                using (Process proceso = Process.Start(psi))
                {
                    proceso.WaitForExit();
                }

                Console.WriteLine($"\n[Graphviz] ¡Gráfica generada exitosamente en '{rutaPng}'!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[Error Graphviz] Asegúrate de tener Graphviz instalado y en el PATH.");
                Console.WriteLine($"Detalle: {ex.Message}");
            }
        }
    }
}