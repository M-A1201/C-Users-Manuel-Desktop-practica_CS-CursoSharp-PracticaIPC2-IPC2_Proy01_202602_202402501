namespace Proyecto01
{
    public class Ciudad
    {
        public string Nombre { get; set; }
        public int Filas { get; set; }
        public int Columnas { get; set; }
        public Casilla[,] Tablero { get; set; }

        public Ciudad(string nombre, int filas, int columnas)
        {
            Nombre = nombre;
            Filas = filas;
            Columnas = columnas;
            Tablero = new Casilla[filas, columnas];
        }
    }
}