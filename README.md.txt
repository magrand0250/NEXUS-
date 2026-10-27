# NEXUS — Sistema de exploración de realidades

Proyecto académico de Programación II desarrollado en C# con programación orientada a objetos (POO).

> **Estado actual:** aplicación de consola. Windows Forms y SQL Server se describen únicamente como posibles mejoras futuras; no se presentan como funciones implementadas.

## Objetivo
Simular la exploración de zonas anómalas mediante un cadete que administra vida, energía, experiencia e inventario, resuelve encuentros y avanza en una misión.

## Funcionalidades identificadas
- Inicio del sistema y creación del cadete.
- Exploración de zonas.
- Inventario y uso de objetos.
- Encuentros con personajes y entidades.
- Seguimiento de objetivos de misión.
- Consulta del estado del cadete y de la misión.

## Tecnologías
- **Lenguaje:** C#
- **Tipo de aplicación:** consola
- **Proyecto:** `nexus_v2.csproj`
- **Solución:** `nexus_v2.slnx`
- **Entorno recomendado:** Visual Studio o .NET SDK compatible con el archivo del proyecto.

La versión exacta del SDK debe verificarse en el archivo `nexus_v2.csproj`; no se fija aquí una versión que no se haya confirmado.

## Cómo ejecutar
1. Clona o descarga este repositorio.
2. Abre `nexus_v2.slnx` o `nexus_v2.csproj` en Visual Studio.
3. Restaura las dependencias si Visual Studio lo solicita.
4. Selecciona el proyecto de consola como proyecto de inicio.
5. Ejecuta con **F5** o **Ctrl+F5**.

También puedes usar una terminal desde la carpeta del proyecto:
```bash
dotnet restore
dotnet run --project nexus_v2.csproj
```

Si el SDK instalado no coincide con el requerido por el proyecto, instala la versión indicada en el archivo `.csproj`.

## Estructura documental
- [Diseño del juego](docs/diseno-del-juego.md): ciclo de juego, reglas, zonas y wireframes de referencia.
- [Arquitectura actual](docs/arquitectura-actual.md): clases, relaciones POO y flujo observado en el código.
- [Arquitectura propuesta](docs/arquitectura-propuesta.md): separación por capas y mejoras futuras.
- [Modelo de datos propuesto](docs/modelo-de-datos-propuesto.md): modelo inicial para una posible persistencia.
- [Análisis técnico](docs/analisis-tecnico.md): tecnologías, restricciones, riesgos y criterios sugeridos.
- [Evidencias](docs/evidencias/README.md): lista de capturas y diagramas que se pueden añadir.

## Principios de documentación
- Se distingue entre las funciones observadas en el código y las propuestas futuras.
- Los wireframes son bocetos, no pantallas ya implementadas.
- El modelo de datos es una propuesta; no se afirma que exista una base SQL Server.
- Las evidencias visuales reales deben añadirse a `docs/evidencias/`.

## Mantenimiento
Actualizar este documento cuando cambien las funcionalidades, las tecnologías o las instrucciones de ejecución.
