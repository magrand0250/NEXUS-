# Análisis técnico de NEXUS

## 1. Tecnologías observadas
- **Lenguaje:** C#.
- **Tipo de aplicación observado:** consola.
- **Archivo principal consultado:** `Program.cs`.
- **Proyecto:** `nexus_v2.csproj`.
- **Solución:** `nexus_v2.slnx`.
- **Paradigma:** programación orientada a objetos.

No se declara aquí una versión exacta de .NET porque debe confirmarse en el archivo de proyecto antes de fijarla en la documentación.

## 2. Funcionalidades identificadas en el código
- Inicio del sistema y captura del nombre del cadete.
- Menú de exploración, inventario, uso de objetos, misión y estado.
- Zonas Bosque de Cristal, Ruinas de IRIS, Zona de Anomalía y Punto de Extracción.
- Estadísticas de vida, energía y experiencia.
- Encuentros con un robot y una entidad hostil.
- Seguimiento de cuatro objetivos de misión.
- Herencia, encapsulamiento, métodos virtuales y sobrescritura.

## 3. Riesgos y mejoras técnicas
- **Responsabilidad excesiva:** `SistemaNexus` coordina muchas funciones. Separar navegación, combate y misión mejoraría el mantenimiento.
- **Reglas de combate:** verificar que el escape, el daño y el uso de objetos produzcan resultados consistentes.
- **Validación:** centralizar la validación de entradas para evitar estados inesperados.
- **Objetos consumibles:** comprobar que el objeto se consuma solo cuando su uso sea válido y exitoso.
- **Pruebas:** añadir pruebas para límites de vida/energía y finalización de misión.
- **Persistencia:** actualmente no se observa almacenamiento permanente de progreso.
- **Documentación:** mantener una distinción clara entre características actuales y propuestas.

## 4. Restricciones del proyecto
- Mantener C# como lenguaje del proyecto.
- No describir funciones futuras como implementadas.
- Conservar la versión de consola mientras se validan las reglas actuales.
- Si se aprueba una interfaz gráfica, evaluar Windows Forms en C#.
- Si se exige persistencia, diseñar y validar el modelo de SQL Server antes de implementarlo.
- Documentar decisiones, cambios y evidencias en el repositorio.

## 5. Criterios de aceptación sugeridos
- El proyecto compila con el SDK indicado en el archivo de proyecto.
- Los valores de vida y energía no bajan de cero ni superan los límites definidos.
- La misión solo se completa cuando todos los objetivos requeridos están marcados.
- El inventario valida el número de objeto y no elimina elementos cuando la acción falla.
- El README explica cómo ejecutar el proyecto y enlaza la documentación.
- Los diagramas y wireframes se identifican como actuales o propuestos.
