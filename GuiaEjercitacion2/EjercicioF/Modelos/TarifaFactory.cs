namespace EjercicioF
{
    // Simple Factory: el único lugar del sistema que hace new de las tarifas.
    public static class TarifaFactory
    {
        public static ITarifa Crear(string codigo)
        {
            switch (codigo)
            {
                case "HORA": return new TarifaHora();
                case "ESTADIA": return new TarifaEstadia();
                case "NOCHE": return new TarifaNocturna();
                default: throw new ArgumentException($"Código de tarifa desconocido: {codigo}");
            }
        }

        public static List<string> CodigosDisponibles()
        {
            return new List<string> { "HORA", "ESTADIA", "NOCHE" };
        }
    }
}
