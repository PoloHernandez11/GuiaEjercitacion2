namespace EjercicioF
{
    // $ 1.200 por hora o fracción.
    public class TarifaHora : ITarifa
    {
        private const decimal PrecioHora = 1200;

        public string Nombre => "Por hora";

        public decimal Calcular(int minutos)
        {
            int horas = (int)Math.Ceiling(minutos / 60.0);
            return horas * PrecioHora;
        }
    }
}
