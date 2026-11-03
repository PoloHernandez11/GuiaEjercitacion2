namespace EjercicioF
{
    // Singleton: una sola bitácora para todo el sistema.
    public class Bitacora
    {
        private static Bitacora _instancia;                          // 2) campo estático
        private readonly List<string> _registros = new List<string>();

        private Bitacora() { }                                       // 1) constructor privado

        public static Bitacora Instancia                             // 3) propiedad Instancia (lazy)
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Bitacora();

                return _instancia;
            }
        }

        public void Registrar(string texto)
        {
            int numero = _registros.Count + 1;
            _registros.Add($"{numero:00}. {texto}");
        }

        public void MostrarTodo()
        {
            Console.WriteLine("--- Bitácora ---");
            foreach (var registro in _registros)
                Console.WriteLine(registro);
        }
    }
}
