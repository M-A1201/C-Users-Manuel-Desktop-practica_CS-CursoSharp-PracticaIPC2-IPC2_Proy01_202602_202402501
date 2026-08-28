using System;
using System.Xml;

namespace Proyecto01
{
    class CargadorXML
    {
        public static Ciudad CargarConfiguracion(string rutaArchivo)
        {
            Ciudad ciudadCargada = null;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(rutaArchivo);

                // 1. Leer Ciudades
                XmlNodeList listaCiudades = doc.SelectNodes("//ciudad");
                foreach (XmlNode nodoCiudad in listaCiudades)
                {
                    XmlNode nombreNodo = nodoCiudad.SelectSingleNode("nombre");
                    string nombre = nombreNodo.InnerText.Trim();
                    int filas = int.Parse(nombreNodo.Attributes["filas"].Value);
                    int columnas = int.Parse(nombreNodo.Attributes["columnas"].Value);

                    ciudadCargada = new Ciudad(nombre, filas, columnas);

                    // Leer Filas del Mapa
                    XmlNodeList listaFilas = nodoCiudad.SelectNodes("fila");
                    foreach (XmlNode nodoFila in listaFilas)
                    {
                        int numFila = int.Parse(nodoFila.Attributes["numero"].Value) - 1; // Ajuste a base 0
                        string contenido = nodoFila.InnerText.Trim().Trim('"');

                        for (int col = 0; col < contenido.Length && col < columnas; col++)
                        {
                            ciudadCargada.Tablero[numFila, col] = new Casilla(numFila + 1, col + 1, contenido[col]);
                        }
                    }

                    // Leer Unidades Militares
                    XmlNodeList unidadesMilitares = nodoCiudad.SelectNodes("unidadMilitar");
                    foreach (XmlNode um in unidadesMilitares)
                    {
                        int f = int.Parse(um.Attributes["fila"].Value) - 1;
                        int c = int.Parse(um.Attributes["columna"].Value) - 1;
                        int capacidad = int.Parse(um.InnerText.Trim());

                        if (f >= 0 && f < filas && c >= 0 && c < columnas)
                        {
                            ciudadCargada.Tablero[f, c].CapacidadMilitar = capacidad;
                        }
                    }

                    Console.WriteLine($"[OK] Ciudad cargada: {ciudadCargada.Nombre} ({ciudadCargada.Filas}x{ciudadCargada.Columnas})");
                }

                // 2. Leer Robots
                XmlNodeList listaRobots = doc.SelectNodes("//robot");
                foreach (XmlNode nodoRobot in listaRobots)
                {
                    XmlNode nombreNodo = nodoRobot.SelectSingleNode("nombre");
                    string nombreRobot = nombreNodo.InnerText.Trim();
                    string tipo = nombreNodo.Attributes["tipo"].Value;
                    int capacidad = 0;

                    if (nombreNodo.Attributes["capacidad"] != null)
                    {
                        capacidad = int.Parse(nombreNodo.Attributes["capacidad"].Value);
                    }

                    Robot robot = new Robot(nombreRobot, tipo, capacidad);
                    Console.WriteLine($"[OK] Robot cargado: {robot.Nombre} | Tipo: {robot.Tipo} | Capacidad: {robot.CapacidadCombate}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar el archivo XML: {ex.Message}");
            }

            return ciudadCargada;
        }
    }
}