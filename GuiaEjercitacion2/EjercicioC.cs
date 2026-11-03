// ============================================
// SECCIÓN C -- DETECTAR EL ERROR
// ============================================

// ============================================
// SECCIÓN C -- Ejercicio 1 (la alarma que se rompe sola)
// ¿Cuál es el error y de qué tipo es?: error de EJECUCIÓN. Compila, pero al
// sonar tira InvalidOperationException ("Collection was modified").
// ¿Por qué ocurre?: Sonar() recorre la lista original con foreach y, en el
// medio, AvisoUnico se desuscribe (Remove). C# no deja cambiar una lista
// mientras se la está recorriendo.
// ¿Cómo se corrige?: recorrer una copia con .ToList(). Si alguien se da de
// baja, se borra de la lista original y la copia sigue intacta.
// ============================================
namespace EjercicioC1
{
    public interface IAlarmaObserver
    {
        void Actualizar(Alarma alarma);
    }

    public class Alarma
    {
        private readonly List<IAlarmaObserver> _observadores = new List<IAlarmaObserver>();
        public void Suscribir(IAlarmaObserver o) => _observadores.Add(o);
        public void Desuscribir(IAlarmaObserver o) => _observadores.Remove(o);

        public void Sonar()
        {
            Console.WriteLine("¡Riiiing!");
            foreach (var o in _observadores.ToList()) // CORREGIDO: se recorre una copia
                o.Actualizar(this);
        }
    }

    public class AvisoUnico : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma)
        {
            Console.WriteLine("Me avisaron una vez y me doy de baja");
            alarma.Desuscribir(this);
        }
    }

    public class Luz : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma) => Console.WriteLine("Luz encendida");
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var alarma = new Alarma();
            alarma.Suscribir(new AvisoUnico());
            alarma.Suscribir(new Luz());
            alarma.Sonar();
            alarma.Sonar(); // la segunda vez solo se enciende la luz
        }
    }
}

// ============================================
// SECCIÓN C -- Ejercicio 2 (una "Strategy" sospechosa)
// ¿Cuál es el error y de qué tipo es?: error de DISEÑO. Compila y funciona,
// pero no es Strategy: hay una sola clase con un if que elige la fórmula
// según un texto. Es el mismo switch de siempre escondido detrás de una
// interfaz.
// ¿Qué pasa cuando llega "Bicicleta"?: hay que abrir Calcular() y agregar
// otro if. Se rompe Open/Closed. Y mientras tanto "Bicicleta" cae en el
// return del final y se cobra como envío común sin que nadie se entere.
// ¿Cómo se corrige?: una clase por cada forma de calcular, todas
// implementando IEnvioStrategy. Una tarifa nueva = una clase nueva.
// ============================================
namespace EjercicioC2
{
    public interface IEnvioStrategy
    {
        decimal Calcular(decimal pesoKg);
    }

    public class TarifaMotoMdp : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg) => 1500 + pesoKg * 100;
    }

    public class TarifaCamionMdp : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg) => 8000 + pesoKg * 40;
    }

    public class TarifaComun : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg) => 3000 + pesoKg * 70;
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            IEnvioStrategy envio = new TarifaMotoMdp();
            Console.WriteLine($"Moto, 10 kg: {envio.Calcular(10):0}");
            envio = new TarifaCamionMdp();
            Console.WriteLine($"Camión, 10 kg: {envio.Calcular(10):0}");
            envio = new TarifaComun();
            Console.WriteLine($"Común, 10 kg: {envio.Calcular(10):0}");
        }
    }
}

// ============================================
// SECCIÓN C -- Ejercicio 3 (la factory que no compila)
// ¿Cuál es el error y de qué tipo es?: error de COMPILACIÓN (CS0161: no
// todas las rutas de código devuelven un valor). Si canal no es "MAIL" ni
// "SMS", el método llega al final sin return.
// ¿Cómo se corrige?: al final se lanza una ArgumentException con un mensaje
// que diga qué canal llegó.
// ¿Por qué excepción y no null?: con null el error aparece más tarde, en otro
// lado, como NullReferenceException, y no se sabe de dónde vino. La
// excepción corta en el momento justo y dice cuál fue el canal inválido.
// ============================================
namespace EjercicioC3
{
    public interface INotificador
    {
        void Enviar(string destino, string mensaje);
    }

    public class NotificadorMail : INotificador
    {
        public void Enviar(string destino, string mensaje) =>
            Console.WriteLine($"Mail a {destino}: {mensaje}");
    }

    public class NotificadorSms : INotificador
    {
        public void Enviar(string destino, string mensaje) =>
            Console.WriteLine($"SMS a {destino}: {mensaje}");
    }

    public static class NotificadorFactory
    {
        public static INotificador Crear(string canal)
        {
            if (canal == "MAIL") return new NotificadorMail();
            if (canal == "SMS") return new NotificadorSms();
            throw new ArgumentException($"Canal desconocido: {canal}"); // CORREGIDO
        }
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            NotificadorFactory.Crear("MAIL").Enviar("ana@mail.com", "Hola");
            NotificadorFactory.Crear("SMS").Enviar("223-555-1234", "Hola");

            try { NotificadorFactory.Crear("FAX"); }
            catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); }
        }
    }
}
