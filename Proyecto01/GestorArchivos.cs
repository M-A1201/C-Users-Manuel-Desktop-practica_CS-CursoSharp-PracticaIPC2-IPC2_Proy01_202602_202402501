using System;
using System.IO;

namespace Proyecto01
{
    class GestorArchivos
    {
        // Lee un archivo de texto plano linea por linea y llena la ListaDoble
        public static bool CargarArchivo(string ruta, ListaDoble listaTarget)
        {
            if (!File.Exists(ruta))
            {
                Console.WriteLine("Error: El archivo no existe en la ruta especificada.");
                return false;
            }

            try
            {
                string[] lineas = File.ReadAllLines(ruta);
                foreach (string linea in lineas)
                {
                    if (!string.IsNullOrWhiteSpace(linea))
                    {
                        listaTarget.Agregar(linea.Trim());
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return false;
            }
        }
    }
}