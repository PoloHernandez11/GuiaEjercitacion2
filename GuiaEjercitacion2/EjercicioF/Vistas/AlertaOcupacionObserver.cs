namespace EjercicioF
{
    // Avisa solo cuando quedan 2 lugares o menos.
    public class AlertaOcupacionObserver : IPlayaObserver
    {
        private const int Limite = 2;

        public void Actualizar(EventoPlaya evento)
        {
            if (evento.LugaresLibres <= Limite)
                Console.WriteLine($"  [Alerta] ¡Quedan {evento.LugaresLibres} lugares!");
        }
    }
}
