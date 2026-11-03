namespace EjercicioF
{
    // Observer: el contrato que cumplen todos los suscriptores de la playa.
    public interface IPlayaObserver
    {
        void Actualizar(EventoPlaya evento);
    }
}
