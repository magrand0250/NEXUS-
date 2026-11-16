# NEXUS

NEXUS es una aventura de exploración narrativa de ciencia ficción. El proyecto de Hito 3 ya implementa una misión de recuperación: el cadete atraviesa el Bosque de Cristal, las Ruinas de IRIS y la Zona de Anomalía para recuperar un núcleo y volver al punto de extracción. La evolución propuesta convierte esa lógica de consola en una experiencia gráfica de escritorio para Windows.

## Estado actual

- Simulación de consola en C#/.NET 8: exploración por zonas, encuentros, energía, vida, experiencia, inventario y objetivos de una misión.
- Prototipo inicial en C# Windows Forms/.NET 10 para Windows: menú con imagen, botones superpuestos para iniciar la simulación de consola, consultar mapas e información, cambiar el modo de ventana y salir.
- La partida todavía no se guarda y la interfaz gráfica aún no contiene el juego completo.

## Tecnologías

C#, .NET 8 para la aplicación de consola H3; Windows Forms sobre `net10.0-windows` para el prototipo gráfico; SQL Server queda propuesto para persistir partidas en una etapa posterior. La solución actual está en `nexus_v2.slnx`.

## Ejecución

En Windows, con el SDK de .NET 10 y la carga de trabajo de escritorio instalada, abre `nexus_v2.slnx` en Visual Studio y ejecuta el proyecto `NEXUS.windowsforms`. Para jugar directamente la versión H3, ejecuta `dotnet run --project nexus_v2.csproj` con el SDK .NET 8. El botón “Iniciar simulación” del prototipo gráfico busca el ejecutable de consola compilado en `bin/<configuración>/net8.0/nexus_v2.exe`; compila la solución completa antes de usarlo.

## Documentación

- [Diseño del juego](docs/diseno-del-juego.md)
- [Arquitectura actual H3](docs/arquitectura-actual.md)
- [Arquitectura propuesta](docs/arquitectura-propuesta.md)
- [Modelo de datos SQL Server](docs/modelo-de-datos-propuesto.md)
- [Análisis técnico y fuentes](docs/analisis-tecnico.md)
- [Evidencias y bocetos](docs/evidencias/)

Los PDF previos recibidos se conservan en `docs/` como material de referencia; los documentos Markdown de arriba son la documentación editable de referencia para las siguientes etapas.
