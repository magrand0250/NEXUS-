# Arquitectura propuesta para NEXUS

## 1. Objetivo
Organizar el proyecto para que pueda crecer sin mezclar la interfaz, las reglas del juego y el acceso a datos. La propuesta conserva C# como lenguaje y plantea Windows Forms y SQL Server como tecnologías futuras, sujetas a aprobación y disponibilidad del curso.

## 2. Arquitectura por capas propuesta
```text
NEXUS
├── Presentacion
│   └── Windows Forms (propuesta futura)
├── Aplicacion
│   └── Casos de uso: iniciar misión, explorar, usar objeto
├── Dominio
│   └── Cadete, Personaje, Objeto, Inventario, Zona, Mision
└── Infraestructura
    └── Repositorios y conexión SQL Server (propuesta futura)
```

La versión actual sigue siendo una aplicación de consola; este diagrama representa una organización futura.

## 3. Responsabilidades
- **Presentación:** mostrar pantallas, recibir entradas y presentar mensajes. En la versión actual, la consola cumple esta función.
- **Aplicación:** coordinar los casos de uso sin implementar detalles visuales.
- **Dominio:** contener las entidades y reglas del juego, por ejemplo límites de energía, combate y condiciones de misión.
- **Infraestructura:** guardar y recuperar datos si se implementa persistencia con SQL Server.

## 4. Clases y responsabilidades recomendadas
- Mantener `Personaje` como abstracción común para entidades con vida y comportamiento.
- Mantener `Cadete` responsable de sus estadísticas y su inventario.
- Mantener `Objeto` como entidad del inventario.
- Mantener `Mision` responsable de validar sus objetivos.
- Mantener `Zona` responsable de sus datos descriptivos.
- Reducir las responsabilidades de `SistemaNexus`; trasladar reglas de misión y combate a servicios o clases de dominio cuando el proyecto crezca.

## 5. Flujo propuesto
1. La interfaz solicita una acción.
2. La capa de aplicación valida y coordina el caso de uso.
3. El dominio aplica las reglas.
4. Si se habilita persistencia, infraestructura guarda el resultado.
5. La interfaz presenta el resultado al usuario.

## 6. Reglas de diseño
- No colocar SQL directamente en los formularios.
- No duplicar reglas de energía, vida o misión en varias pantallas.
- Validar entradas antes de ejecutar acciones.
- Mantener nombres coherentes en español.
- Usar interfaces para abstraer almacenamiento cuando realmente se implemente.
- Agregar pruebas a las reglas de misión y combate antes de introducir nuevas funciones.

## 7. Migración gradual
1. Documentar y probar el comportamiento actual de consola.
2. Separar reglas de negocio de la navegación.
3. Crear pruebas para combate, inventario y misión.
4. Diseñar formularios Windows Forms reutilizando las reglas del dominio.
5. Diseñar el esquema de SQL Server solo cuando la persistencia sea requisito.
6. Verificar que la versión de consola siga compilando mientras se migra.

## 8. Alcance
Esta arquitectura es una propuesta. No implica que Windows Forms, SQL Server, repositorios o pruebas automatizadas ya estén implementados.
