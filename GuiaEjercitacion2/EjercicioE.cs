// ============================================
// SECCIÓN E -- ¿QUÉ PATRÓN USARÍAS?
// ============================================

// ============================================
// SECCIÓN E -- Escenario 1 (delivery: moto, bici, auto y después dron)
// Patrón: Strategy (y Factory para crear la tarifa según lo que eligió el usuario).
// ¿Por qué?: hay varias FORMAS de calcular lo mismo (el costo del envío) y
// el mes que viene se suma otra (dron). Con una clase por vehículo, el dron
// es una clase nueva y no se toca lo que ya anda. Como el vehículo lo elige
// el usuario al confirmar, una factory traduce esa opción en la estrategia.
// ============================================

// ============================================
// SECCIÓN E -- Escenario 2 (pedido "listo": cocina, mozo, caja y WhatsApp)
// Patrón: Observer.
// ¿Por qué?: cuando cambia el estado del pedido se tienen que ENTERAR varias
// partes, y van a aparecer más (WhatsApp). El pedido avisa a una lista de
// suscriptores y el aviso nuevo es una clase más que se suscribe.
// ============================================

// ============================================
// SECCIÓN E -- Escenario 3 (configuración que cada pantalla crea por su cuenta)
// Patrón: Singleton.
// ¿Por qué?: tiene que haber UNA sola configuración. Hoy cada formulario hace
// su propio new y por eso al cambiar la sucursal en una pantalla las otras
// siguen viendo la vieja. Con un Singleton todas leen el mismo objeto.
// ============================================

// ============================================
// SECCIÓN E -- Escenario 4 (pagos en JSON con el medio como texto)
// Patrón: Factory (y Strategy para el recargo de cada medio).
// ¿Por qué?: el medio llega como TEXTO ("TARJETA", "EFECTIVO", "QR") y hay
// que crear el objeto correcto al leer el archivo. La factory es el único
// lugar con ese switch. Cada objeto creado sabe calcular su propio recargo.
// ============================================

// ============================================
// SECCIÓN E -- Escenario 5 (factory para un repositorio que se crea una vez)
// Patrón: ninguno.
// ¿Por qué?: el repositorio se crea UNA vez al arrancar y nunca cambia, y ya
// se pasa por constructor (inyección de dependencias). Una factory no
// decidiría nada: sería una indirección gratuita, una clase más que hay que
// leer sin ganar nada.
// ============================================
