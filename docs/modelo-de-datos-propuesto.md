# Modelo de datos propuesto para NEXUS

## 1. Estado
El programa actual mantiene el estado en objetos de C# durante la ejecución. No se ha confirmado una base de datos implementada. El siguiente modelo es una propuesta si el docente requiere persistencia con SQL Server.

## 2. Entidades propuestas
| Entidad | Campos principales propuestos | Propósito |
|---|---|---|
| Cadete | CadeteId, Nombre, Vida, Energia, Experiencia | Guardar el estado del explorador. |
| Mision | MisionId, Nombre, Estado, FechaInicio, FechaFin | Registrar una misión y su resultado. |
| ObjetivoMision | ObjetivoId, MisionId, Descripcion, Completado | Registrar cada objetivo de una misión. |
| Zona | ZonaId, Nombre, Descripcion | Catálogo de zonas explorables. |
| Objeto | ObjetoId, Nombre, Tipo, Poder | Catálogo de objetos disponibles. |
| InventarioCadete | InventarioId, CadeteId, ObjetoId, Cantidad | Relacionar cadetes con objetos. |
| Exploracion | ExploracionId, CadeteId, ZonaId, Fecha, Resultado | Registrar visitas a zonas. |

Los nombres y tipos de datos deberán ajustarse a los requisitos definitivos del docente.

## 3. Relaciones
- Un cadete puede participar en varias misiones.
- Una misión puede contener varios objetivos.
- Un cadete puede explorar varias zonas y una zona puede ser explorada por varios cadetes.
- Un cadete puede tener varios objetos y un mismo tipo de objeto puede estar en inventarios distintos; por eso se propone una tabla intermedia `InventarioCadete`.

## 4. Diagrama conceptual textual
```text
Cadete 1 ─── N Mision
Mision 1 ─── N ObjetivoMision
Cadete 1 ─── N Exploracion N ─── 1 Zona
Cadete 1 ─── N InventarioCadete N ─── 1 Objeto
```

## 5. Reglas de integridad recomendadas
- Usar claves primarias para identificar cada registro.
- Usar claves foráneas para las relaciones.
- Restringir vida y energía a valores entre 0 y 100, si esas reglas se mantienen.
- Evitar cantidades negativas en inventario.
- Registrar fechas con tipos de fecha y hora adecuados.
- Definir si el progreso de una misión se guarda automáticamente o solo al finalizar.

## 6. Advertencia
Este documento no representa una base de datos existente. Es un modelo inicial de diseño que debe validarse antes de crear tablas SQL Server.
