// ============================================
// SECCIÓN A -- PREGUNTAS CONCEPTUALES
// ============================================

// ============================================
// SECCIÓN A -- Pregunta 1 (las tres reglas del Singleton)
// A1: c
// ¿Por qué?: el constructor private es lo único que impide escribir
// new AppLogger() desde otra clase. El campo y la propiedad solo guardan
// y entregan la instancia.
// Descarto d): una static class no se puede instanciar nunca, ni siquiera
// una vez, así que no sería un Singleton (no hay objeto).
// ============================================

// ============================================
// SECCIÓN A -- Pregunta 2 (lazy initialization)
// A2: a
// ¿Por qué?: "lazy" quiere decir que la instancia se crea recién la primera
// vez que alguien pide Instancia. Si nadie la pide, nunca se crea.
// Descarto c): si se creara una nueva cada vez, ya no sería Singleton.
// ============================================

// ============================================
// SECCIÓN A -- Pregunta 3 (qué resuelve Strategy)
// A3: d
// ¿Por qué?: Strategy saca cada variante del cálculo de un if/switch y la
// pone en su propia clase, todas detrás de la misma interfaz.
// Descarto a): eso es lo que resuelve Singleton, no Strategy.
// ============================================

// ============================================
// SECCIÓN A -- Pregunta 4 (el contexto en Strategy)
// A4: b
// ¿Por qué?: el contexto tiene guardada una estrategia (la interfaz) y le
// pide que calcule. No sabe cuál de todas es.
// ============================================

// ============================================
// SECCIÓN A -- Pregunta 5 (cuándo se justifica una factory)
// A5: c
// ¿Por qué?: el tipo llega como texto en tiempo de ejecución y el objeto se
// crea en varios lugares. La factory junta ese switch en un solo lugar.
// Descarto a): un repositorio que se crea una sola vez al arrancar no
// necesita factory, alcanza con pasarlo por constructor.
// ============================================

// ============================================
// SECCIÓN A -- Pregunta 6 (Simple Factory vs Factory Method)
// A6: a
// ¿Por qué?: en Factory Method hay una clase base con lógica de negocio que
// declara un método de creación abstracto, y cada subclase elige qué crear.
// La Simple Factory es solo una clase con un switch.
// ============================================

// ============================================
// SECCIÓN A -- Pregunta 7 (qué guarda el notificador)
// A7: b
// ¿Por qué?: guarda una lista de la interfaz (List<IObservador>), no de
// clases concretas. Así puede avisarle a cualquier clase que la implemente.
// ============================================

// ============================================
// SECCIÓN A -- Pregunta 8 (el suscriptor olvidado)
// A8: d
// ¿Por qué?: la lista sigue teniendo la referencia al formulario cerrado, así
// que le sigue avisando. Puede tirar excepción y el objeto no se libera.
// ============================================

// ============================================
// SECCIÓN A -- Pregunta 9 (Observer en WinForms)
// A9: b
// ¿Por qué?: el botón es el notificador; btnGuardar_Click es el método que
// se anotó (+=) para enterarse del clic, o sea el suscriptor.
// ============================================

// ============================================
// SECCIÓN A -- Pregunta 10 (Open/Closed en la práctica)
// A10: c
// ¿Por qué?: se agrega una clase nueva que implementa la interfaz y se
// suscribe en Program.cs. No se toca el controller (cerrado a modificación).
// ============================================
