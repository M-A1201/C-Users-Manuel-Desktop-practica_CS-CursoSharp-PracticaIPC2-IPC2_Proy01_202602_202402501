using System;
using System.IO;

namespace Proyecto01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("    PRUEBAS DE LA SEMANA 3");
            Console.WriteLine("=======================================\n");

            // 1. Prueba de la estructura Cola (FIFO)
            Console.WriteLine("--- 1. Prueba de Cola (FIFO) ---");
            Cola colaPrueba = new Cola();
            colaPrueba.Encolar("Primer Turno - Cliente A");
            colaPrueba.Encolar("Segundo Turno - Cliente B");
            colaPrueba.Encolar("Tercer Turno - Cliente C");
            
            Console.WriteLine("Elementos en la Cola:");
            colaPrueba.Mostrar();
            Console.WriteLine($"Total en Cola: {colaPrueba.Contador}\n");

            // 2. Prueba del Gestor de Archivos (Carga Masiva)
            Console.WriteLine("--- 2. Prueba de Carga desde Archivo ---");
            ListaDoble listaArchivo = new ListaDoble();
            string rutaArchivo = "datos.txt";

            bool exito = GestorArchivos.CargarArchivo(rutaArchivo, listaArchivo);

            if (exito)
            {
                Console.WriteLine($"\n¡Archivo '{rutaArchivo}' cargado exitosamente!");
                Console.WriteLine("Contenido de la Lista Doble creada desde el archivo:");
                listaArchivo.MostrarAdelante();
                Console.WriteLine($"Total elementos leídos: {listaArchivo.Contador}");
            }
            else
            {
                Console.WriteLine("Ocurrió un problema al intentar leer el archivo.");
            }

            Console.WriteLine("\n=======================================");
            Console.WriteLine("    PRUEBAS COMPLETADAS CON ÉXITO");
            Console.WriteLine("=======================================");
        }
    }
}