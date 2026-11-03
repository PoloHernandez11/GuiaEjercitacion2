// ============================================
// SECCIÓN F -- Playa de estacionamiento "Plaza Colón"
//
// JUSTIFICACIÓN DE LOS PATRONES
//
// Singleton (Bitacora): la playa necesita UNA sola bitácora con todo lo que
// pasó. Si cada clase hiciera new Bitacora(), cada una tendría su propia
// lista y al final MostrarTodo() mostraría solo una parte de los movimientos.
//
// Strategy (ITarifa y sus tres clases): hay tres formas de cobrar (hora,
// estadía, noche). Sin Strategy, Egresar tendría un switch por código que
// habría que abrir cada vez que aparezca una tarifa nueva (por ejemplo MOTO).
//
// Factory (TarifaFactory): el código de tarifa llega como TEXTO que carga el
// operador. La factory es el único lugar que traduce "HORA" en new
// TarifaHora(). Sin ella, el switch de textos quedaría metido en Playa.
//
// Observer (IPlayaObserver): en cada ingreso o egreso se tienen que enterar
// la pantalla, la caja, la alerta y la bitácora. Sin Observer, Playa tendría
// que llamar a cada una a mano y cada aviso nuevo obligaría a modificarla.
//
// MVC: Modelos = tarifas, factory, EventoPlaya y Bitacora (datos y reglas).
// Controladores = Playa (recibe las órdenes y avisa). Vistas = los
// suscriptores que muestran cosas por consola.
// ============================================
namespace EjercicioF
{
    public static class Demo
    {
        public static void Ejecutar()
        {
            var playa = new Playa(10);
            var pantalla = new PantallaLugares();
            playa.Suscribir(pantalla);
            playa.Suscribir(new CajaObserver());
            playa.Suscribir(new AlertaOcupacionObserver());
            playa.Suscribir(new BitacoraObserver());

            Console.WriteLine("Tarifas disponibles: " + string.Join(", ", TarifaFactory.CodigosDisponibles()));

            // ingresan 8 vehículos con distintos códigos de tarifa
            playa.Ingresar("AB123CD", "HORA");
            playa.Ingresar("AC456EF", "ESTADIA");
            playa.Ingresar("AD789GH", "NOCHE");
            playa.Ingresar("AE111AA", "HORA");
            playa.Ingresar("AF222BB", "ESTADIA");
            playa.Ingresar("AG333CC", "NOCHE");
            playa.Ingresar("AH444DD", "HORA");
            playa.Ingresar("AI555EE", "HORA");

            playa.Egresar("AB123CD", 150);   // HORA, 2 h 30 min -> $ 3.600
            playa.Egresar("AC456EF", 900);   // ESTADIA, 15 h    -> $ 9.600
            playa.Desuscribir(pantalla);     // la pantalla deja de mostrar
            playa.Egresar("AD789GH", 600);   // NOCHE            -> $ 4.500

            // código de tarifa inválido
            try { playa.Ingresar("AZ999ZZ", "SEMANAL"); }
            catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); }

            // patente repetida
            try { playa.Ingresar("AE111AA", "HORA"); }
            catch (InvalidOperationException ex) { Console.WriteLine("Error: " + ex.Message); }

            Bitacora.Instancia.MostrarTodo();
        }
    }
}
