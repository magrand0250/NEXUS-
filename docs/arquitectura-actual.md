# Arquitectura actual de NEXUS

## 1. Resumen
El repositorio contiene una aplicación de consola en C# para .NET. La lógica principal observada en `Program.cs` está organizada mediante clases y objetos. La aplicación se inicia creando un objeto `SistemaNexus` y llamando a `Iniciar()`.

## 2. Componentes identificados
| Clase | Responsabilidad observada |
|---|---|
| `Program` | Punto de entrada; crea e inicia el sistema. |
| `SistemaNexus` | Coordina menús, exploración, encuentros, misión y zonas. |
| `Personaje` | Clase abstracta con nombre, vida, información, daño y acción abstracta. |
| `Cadete` | Personaje del jugador; administra energía, experiencia e inventario. |
| `Robot` | Tipo de personaje que actúa contra el cadete. |
| `Enemigo` | Entidad hostil que puede causar daño al cadete. |
| `Objeto` | Representa objetos del inventario con nombre, tipo y poder. |
| `Inventario` | Guarda una lista de objetos y permite agregarlos, mostrarlos y usarlos. |
| `Zona` | Contiene el nombre y la descripción de una zona. |
| `Mision` | Registra el avance de los objetivos de la misión. |

## 3. Relaciones y POO
- **Herencia:** `Cadete`, `Robot` y `Enemigo` heredan de `Personaje`.
- **Polimorfismo:** las clases derivadas redefinen `MostrarInformacion()` y `Actuar()`.
- **Encapsulamiento:** varias propiedades usan setters privados o protegidos; `Inventario` mantiene su lista como campo privado.
- **Composición/uso de objetos:** `Cadete` crea y mantiene un `Inventario`; `SistemaNexus` mantiene objetos `Mision` y `Zona`.
- **Colecciones:** `Inventario` usa `List<Objeto>`.

## 4. Flujo de ejecución
1. `Program.Main()` crea `SistemaNexus`.
2. `SistemaNexus.Iniciar()` muestra la pantalla inicial.
3. Se crea el cadete y se agregan objetos iniciales.
4. El menú permite explorar, revisar o usar objetos y consultar la misión.
5. Las acciones modifican las estadísticas y el progreso.
6. El ciclo termina al salir, perder toda la vida o completar la misión.

## 5. Limitaciones observables
- La interfaz es de consola.
- La lógica de interacción, navegación y reglas está concentrada en `SistemaNexus`, por lo que la clase tiene muchas responsabilidades.
- No se observa persistencia de datos en una base de datos.
- Las zonas se presentan como opciones de texto y no como un mapa visual.
- Deben revisarse los límites y consistencia de las reglas de combate y de uso de objetos.

## 6. Base documental
Este documento se elaboró a partir de la lectura de `Program.cs` en la rama principal. Los archivos de documentación describen lo que se observa en el código y separan explícitamente las propuestas futuras.
