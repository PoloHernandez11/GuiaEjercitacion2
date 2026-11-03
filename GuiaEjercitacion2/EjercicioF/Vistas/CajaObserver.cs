namespace EjercicioF
{
    // Suma lo cobrado en cada egreso y muestra el total.
    public class CajaObserver : IPlayaObserver
    {
        private decimal _totalPlazaColon = 0;

        public void Actualizar(EventoPlaya evento)
        {
            if (evento.Tipo != TipoEvento.Egreso)
                return;

            _totalPlazaColon += evento.Importe;
            Console.WriteLine($"  [Caja] Cobrado $ {evento.Importe:N0} a {evento.Patente}. Recaudado: $ {_totalPlazaColon:N0}");
        }
    }
}
