namespace EjercicioF
{
    // Muestra cuántos lugares quedan, en cada ingreso y egreso.
    public class PantallaLugares : IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento)
        {
            Console.WriteLine($"  [Pantalla] Lugares libres: {evento.LugaresLibres}");
        }
    }
}
