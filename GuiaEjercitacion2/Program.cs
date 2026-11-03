using System.Globalization;
using System.Text;

// Punto de entrada: ejecuta cada ejercicio de la guía en orden.
Console.OutputEncoding = Encoding.UTF8;
CultureInfo.CurrentCulture = new CultureInfo("es-AR"); // para mostrar $ 3.600

Titulo("B1 - Singleton");
EjercicioB1.Demo.Ejecutar();

Titulo("B2 - Strategy");
EjercicioB2.Demo.Ejecutar();

Titulo("B3 - Observer");
EjercicioB3.Demo.Ejecutar();

Titulo("C1 - Alarma corregida");
EjercicioC1.Demo.Ejecutar();

Titulo("C2 - Strategy corregida");
EjercicioC2.Demo.Ejecutar();

Titulo("C3 - Factory corregida");
EjercicioC3.Demo.Ejecutar();

Titulo("D1 - Termómetro");
EjercicioD1.Demo.Ejecutar();

Titulo("D2 - Descuentos");
EjercicioD2.Demo.Ejecutar();

Titulo("F - Playa Plaza Colón");
EjercicioF.Demo.Ejecutar();

static void Titulo(string texto)
{
    Console.WriteLine();
    Console.WriteLine($"===== {texto} =====");
}
