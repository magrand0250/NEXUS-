# Diseño del juego NEXUS

## 1. Visión del juego
NEXUS es una simulación de exploración de realidades anómalas. El jugador controla a un cadete que debe investigar zonas, administrar sus recursos, enfrentar entidades y regresar al punto de extracción.

## 2. Estado actual y alcance
La versión disponible es una aplicación de consola desarrollada en C# sobre .NET. Permite iniciar una misión, registrar el nombre del cadete, explorar cuatro zonas, administrar un inventario, resolver encuentros y consultar el estado de la misión.

Este documento describe el comportamiento actual y una dirección de diseño. No afirma que ya exista una interfaz gráfica ni una base de datos.

## 3. Ciclo principal de juego
1. Iniciar el sistema NEXUS.
2. Identificar al cadete.
3. Consultar el menú de acciones.
4. Explorar una zona.
5. Resolver eventos, encuentros o recoger objetos.
6. Revisar vida, energía, experiencia e inventario.
7. Completar los objetivos y regresar al punto de extracción.
8. Mostrar el resultado de la misión.

## 4. Mecánicas y reglas actuales
- **Vida:** comienza en 100. Si llega a cero, la misión falla.
- **Energía:** comienza en 60; se gasta durante algunas acciones y puede recuperarse con objetos de energía.
- **Experiencia:** se obtiene al explorar y resolver encuentros.
- **Inventario:** almacena objetos como células de energía, escudos, analizadores y módulos.
- **Encuentros:** el jugador puede atacar, escapar, usar un objeto o analizar una entidad.
- **Objetivos de misión:** llegar a la anomalía, encontrar el núcleo, sobrevivir y regresar a extracción.
- **Finalización:** la misión se completa al cumplir todos los objetivos; puede fallar si el cadete pierde toda su vida.

## 5. Zonas actuales
| Zona | Función en la misión |
|---|---|
| Bosque de Cristal | Encontrar una célula de energía y obtener experiencia. |
| Ruinas de IRIS | Encontrar un robot y resolver un encuentro. |
| Zona de Anomalía | Investigar la anomalía, combatir una entidad y recuperar el núcleo. |
| Punto de Extracción | Regresar cuando los objetivos necesarios estén cumplidos. |

## 6. Wireframes de baja fidelidad

Los siguientes bocetos son esquemas textuales de referencia, no pantallas implementadas.

### 6.1 Menú principal
```text
+--------------------------------------+
|               NEXUS                  |
|       SISTEMA DE INMERSION            |
+--------------------------------------+
| 1. Explorar                           |
| 2. Inventario                         |
| 3. Usar objeto                        |
| 4. Ver misión                         |
| 5. Ver estado                         |
| 0. Salir                              |
+--------------------------------------+
| Cadete: [nombre]  Vida: 100  Energia: 60 |
+--------------------------------------+
```

### 6.2 Exploración del mapa
```text
+--------------------------------------+
|          EXPLORACION                  |
+--------------------------------------+
| [1] Bosque de Cristal                 |
| [2] Ruinas de IRIS                    |
| [3] Zona de Anomalia                  |
| [4] Punto de Extraccion               |
| [0] Regresar                          |
+--------------------------------------+
| Zona elegida: [descripcion y evento]  |
+--------------------------------------+
```

### 6.3 Misiones
```text
+--------------------------------------+
|              MISION                   |
+--------------------------------------+
| [ ] Llegar a la zona de anomalia      |
| [ ] Encontrar el nucleo energetico    |
| [ ] Sobrevivir al encuentro           |
| [ ] Regresar a extraccion             |
+--------------------------------------+
| Progreso: objetivos completados / 4   |
+--------------------------------------+
```

### 6.4 Cadete e inventario
```text
+--------------------------------------+
|          ESTADO DEL CADETE            |
+--------------------------------------+
| Nombre: [nombre]                      |
| Vida: [valor]   Energia: [valor]      |
| Experiencia: [valor]                  |
+--------------------------------------+
| INVENTARIO                            |
| 1. Celula de energia                  |
| 2. Escudo portatil                    |
| 3. Analizador                         |
| [Usar] [Volver]                       |
+--------------------------------------+
```

## 7. Criterios de experiencia de usuario
- Mostrar claramente la opción seleccionada y los resultados de cada acción.
- Mantener visibles los valores de vida, energía y experiencia en el menú.
- Validar entradas vacías o no numéricas sin cerrar inesperadamente el programa.
- Explicar por qué una extracción está permitida o denegada.
- Evitar que el jugador pierda objetos sin recibir un mensaje de confirmación.
- Usar los mismos nombres para zonas, objetos y objetivos en todos los menús.

## 8. Restricciones y trabajo futuro
- La versión actual es de consola y no incluye mapa gráfico interactivo.
- El progreso se mantiene durante la ejecución; no se documenta persistencia en una base de datos.
- Los wireframes son propuestas visuales de baja fidelidad.
- Una futura interfaz Windows Forms y una futura base de datos SQL Server son propuestas, no funciones ya terminadas.
- Antes de ampliar el alcance, conviene corregir las reglas de combate, escape, uso de objetos y repetición de recompensas.
