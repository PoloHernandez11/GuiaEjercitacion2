namespace EjercicioF
{
    // Anota cada ingreso y egreso en la bitácora única (el Singleton).
    // No muestra nada en pantalla: la bitácora se ve al final con MostrarTodo().
    public class BitacoraObserver : IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento)
        {
            if (evento.Tipo == TipoEvento.Ingreso)
                Bitacora.Instancia.Registrar($"Ingresó {evento.Patente}");
            else
                Bitacora.Instancia.Registrar($"Egresó {evento.Patente} - $ {evento.Importe:N0}");
        }
    }
}
