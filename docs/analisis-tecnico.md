# Análisis técnico

## Alternativas consideradas

| Decisión | Alternativas | Evaluación aplicada a NEXUS | Recomendación |
|---|---|---|---|
| Interfaz | WinForms / WPF / motor de juego | WinForms es requisito y ya existe `NEXUS.windowsforms/Form1`; permite completar menú, mapa y paneles como app Windows. WPF ofrece otro modelo de UI pero añade migración; un motor 3D excede el alcance narrativo y el código H3. | Mantener WinForms para el alcance solicitado; usar controles y dibujo 2D ligero. |
| Persistencia | SQL Server / JSON local / SQLite | SQL Server es requisito y da esquema relacional, integridad y transacciones. JSON es simple para prototipo offline, pero duplicaría estrategias de guardado y no cumple destino. SQL Server requiere instalación/configuración y manejo de fallos. | Diseñar repositorio SQL Server. Si el servidor aún no está disponible, usar repositorio en memoria para desarrollo, sin declarar JSON como entrega final. |
| Acceso a datos | `Microsoft.Data.SqlClient` directo desde formularios / repositorio / ORM | SQL directo en `Form1` acopla UI a SQL; repositorio concentra consultas y se alinea al pequeño dominio existente. ORM reduce mapeo repetitivo, pero añade paquete y conceptos. | `Microsoft.Data.SqlClient` dentro de Infrastructure detrás de interfaces; revaluar EF Core si el modelo crece. Parametrizar todas las entradas. |
| Organización | Seguir monolito `Program.cs` / separar en capas y proyectos | El monolito facilita la entrega H3 pero `SistemaNexus` mezcla `Console`, reglas y flujo. Separar primero dominio/aplicación habilita ambas UIs durante migración. | Extraer sin cambiar reglas y reemplazar llamadas `Console` por resultados explícitos; luego integrar formularios y persistencia. |
| Composición de WinForms | `new Form1()` con dependencias manuales / Generic Host y DI | El arranque actual es simple; uno o pocos servicios podrían instanciarse manualmente al principio. DI centraliza repositorios, configuración y logging al crecer. | Comenzar simple o añadir Generic Host cuando servicios/repositorios sean múltiples; no es requisito para el primer menú. |

## Recomendación y plan de transición

**Paso 1:** conservar `Program.cs` funcional y extraer `Personaje`, `Cadete`, `Robot`, `Enemigo`, `Objeto`, `Inventario`, `Zona` y `Mision` en `NEXUS.Domain`. Añadir identificadores y reglas explícitas contra recompensas duplicadas; corregir efectos incompletos solo con decisión de balance.

**Paso 2:** implementar casos de uso para explorar, resolver encuentro, usar objeto, consultar misión y extraer en `NEXUS.Application`. La consola puede llamar esos casos mientras WinForms se integra, evitando dos versiones divergentes de la regla.

**Paso 3:** cambiar los hotspots y `StartSimulation` de `Form1` para navegar a pantallas reales. El prototipo actual depende de encontrar un exe y ejecutar una consola separada; ese acoplamiento es un puente temporal y debe retirarse cuando la lógica sea invocable en proceso.

**Paso 4:** agregar repositorio e implementación SQL, definir catálogo/seed de las cuatro zonas y misión, y crear carga/guardado transaccional. Introducir fallos simulables de conexión y migraciones.

**Paso 5:** añadir misiones múltiples/expansiones solo después de validar el ciclo completo y la persistencia.

## Ventajas, costos y riesgos

Capas separadas evitan que la lógica de `SistemaNexus` se duplique en eventos WinForms, ayudan a cambiar pantallas sin modificar reglas y hacen posible conservar consola durante transición. Los costos son más archivos/proyectos, mapeo de datos, despliegue/configuración del SQL Server y disciplina al mantener el esquema. El mayor riesgo inmediato es implementar datos antes de fijar reglas que H3 hoy deja incompletas (efectos del escudo/ataque/analizador, repetición de recompensas, continuidad de encuentros). La UI debe dar estado claro si el guardado falla y no bloquear al jugador silenciosamente.

## Verificación de información asistida por IA

Las sugerencias se contrastaron con documentación primaria de Microsoft enlazada abajo. La documentación confirma que WinForms responde a eventos y ofrece controles/datos; Generic Host puede integrar DI/configuración/logging en WinForms pero es una opción de composición; `Microsoft.Data.SqlClient` admite parámetros tipados y recomienda separar valores SQL de la cadena del comando. El diagrama, el modelo y la elección de proyectos son decisiones de diseño para este repositorio, no afirmaciones atribuidas a Microsoft. Las rutas y reglas de H3 se comprobaron directamente en los archivos enumerados en [arquitectura actual](arquitectura-actual.md). Antes de implementación, comprobar en el entorno real la versión del SDK, disponibilidad de SQL Server, autenticación, carga de trabajo WinForms y soporte de paquetes.

## Fuentes técnicas

- [Windows Forms overview — Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/overview/): capacidades de interfaz de escritorio y eventos.
- [Events overview — Windows Forms](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/forms/events): modelo de eventos y manejadores.
- [Use the .NET Generic Host in a Windows Forms app — Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-use-host-builder): configuración, DI y logging opcionales en WinForms.
- [Configure parameters with Microsoft.Data.SqlClient — Microsoft Learn](https://learn.microsoft.com/en-us/sql/connect/ado-net/configure-parameters?view=sql-server-ver17): consultas parametrizadas y tipos SQL.
- [Dependency injection in .NET — Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection/overview): propósito de DI y composición de dependencias.

## Evidencias del repositorio

El mockup heredado se conserva en [evidencias](evidencias/). Los wireframes textuales y sus transiciones están en [diseño del juego](diseno-del-juego.md#pantallas-y-navegación). Los PDF recibidos están preservados junto a este documento como referencia histórica; esta versión Markdown relaciona las decisiones con el estado actual del código.
