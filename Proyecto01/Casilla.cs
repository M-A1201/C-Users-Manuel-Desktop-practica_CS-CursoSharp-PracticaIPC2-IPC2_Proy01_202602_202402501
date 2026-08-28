namespace Proyecto01
{
    public class Casilla
    {
        public int Fila { get; set; }
        public int Columna { get; set; }
        public char Tipo { get; set; } // '*', ' ', 'E', 'C', 'R'
        public int CapacidadMilitar { get; set; } // Valor n de unidades militares

        public Casilla(int fila, int columna, char tipo)
        {
            Fila = fila;
            Columna = columna;
            Tipo = tipo;
            CapacidadMilitar = 0;
        }
    }
}