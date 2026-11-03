namespace EjercicioF
{
    // Strategy: el contrato que cumplen todas las tarifas.
    public interface ITarifa
    {
        string Nombre { get; }
        decimal Calcular(int minutos);
    }
}
