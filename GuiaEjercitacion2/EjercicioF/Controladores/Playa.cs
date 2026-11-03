namespace EjercicioF
{
    // rev-PC2
    // Controlador y notificador: maneja ingresos y egresos y avisa a los suscriptores.
    // Solo conoce ITarifa e IPlayaObserver, nunca las clases concretas.
    public class Playa
    {
        private readonly int _capacidad;
        private readonly Dictionary<string, ITarifa> _vehiculos = new Dictionary<string, ITarifa>();
        private readonly List<IPlayaObserver> _observadores = new List<IPlayaObserver>();

        public Playa(int capacidad)
        {
            _capacidad = capacidad;
        }

        public int LugaresLibres => _capacidad - _vehiculos.Count;

        public void Suscribir(IPlayaObserver o) => _observadores.Add(o);
        public void Desuscribir(IPlayaObserver o) => _observadores.Remove(o);

        public void Ingresar(string patente, string codigoTarifa)
        {
            if (string.IsNullOrWhiteSpace(patente))
                throw new InvalidOperationException("La patente no puede estar vacía.");
            if (_vehiculos.ContainsKey(patente))
                throw new InvalidOperationException($"La patente {patente} ya está adentro.");
            if (LugaresLibres == 0)
                throw new InvalidOperationException("La playa está llena.");

            ITarifa tarifa = TarifaFactory.Crear(codigoTarifa);
            _vehiculos.Add(patente, tarifa);

            Notificar(new EventoPlaya(TipoEvento.Ingreso, patente, 0, LugaresLibres));
        }

        public decimal Egresar(string patente, int minutos)
        {
            if (!_vehiculos.ContainsKey(patente))
                throw new InvalidOperationException($"La patente {patente} no está en la playa.");

            decimal importe = _vehiculos[patente].Calcular(minutos);
            _vehiculos.Remove(patente);

            Notificar(new EventoPlaya(TipoEvento.Egreso, patente, importe, LugaresLibres));
            return importe;
        }

        private void Notificar(EventoPlaya evento)
        {
            foreach (var o in _observadores.ToList())   // se recorre una copia
                o.Actualizar(evento);
        }
    }
}
