namespace EjercicioF
{
    // $ 4.500 fijos, sin importar los minutos.
    public class TarifaNocturna : ITarifa
    {
        public string Nombre => "Nocturna";

        public decimal Calcular(int minutos) => 4500;
    }
}
