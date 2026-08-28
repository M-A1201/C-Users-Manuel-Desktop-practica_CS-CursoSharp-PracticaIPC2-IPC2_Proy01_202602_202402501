namespace Proyecto01
{
    class Robot
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; } // "ChapinRescue" o "ChapinFighter"
        public int CapacidadCombate { get; set; }

        public Robot(string nombre, string tipo, int capacidadCombate)
        {
            Nombre = nombre;
            Tipo = tipo;
            CapacidadCombate = capacidadCombate;
        }
    }
}