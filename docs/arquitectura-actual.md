# Arquitectura actual de H3

## Inventario real del repositorio

| Ruta | Responsabilidad observada |
|---|---|
| `Program.cs` | Implementa en un único archivo todas las clases del juego de consola y su punto de entrada. |
| `nexus_v2.csproj` | Aplicación ejecutable .NET 8 con nullable e implicit usings; excluye el subárbol Windows Forms de la compilación de consola. |
| `nexus_v2.slnx` | Solución que incluye `NEXUS.windowsforms/NEXUS.windowsforms.csproj` y el proyecto de consola. |
| `NEXUS.windowsforms/Program.cs` | Punto de entrada WinForms; inicializa configuración y abre `Form1`. |
| `NEXUS.windowsforms/Form1.cs` | Prototipo: abre el ejecutable de consola en proceso separado, oculta/recupera ventana; muestra mapas e información en diálogos; cambia ventana/pantalla completa y desconecta. |
| `NEXUS.windowsforms/Form1.Designer.cs` | Construye el menú con cinco botones transparentes sobre imagen, posiciones proporcionales al tamaño de ventana y tecla Escape. |
| `NEXUS.windowsforms/Assets/nexus-main-menu.png` | Fondo del menú gráfico. |
| `NEXUS.windowsforms/NEXUS.windowsforms.csproj` | WinExe Windows Forms para `net10.0-windows`; copia el recurso del menú. |
| `docs/` | Documentos técnicos previos en PDF, imagen de mockups heredada y documentos Markdown actuales. |

El nombre del ejecutable/solución (`nexus_v2`) no altera el nombre de producto NEXUS. El README detalla las instrucciones de ejecución.

## Clases y reglas de `Program.cs`

- `Personaje` es abstracta: nombre, vida, daño y método polimórfico `Actuar(Cadete)`.
- `Cadete : Personaje`: vida inicial 100, energía 60, experiencia 0, inventario nuevo; controla gasto/recuperación de energía, XP y creación de escudos.
- `Robot` y `Enemigo : Personaje`: vida 50 y 70; su acción causa respectivamente 10 de daño más 5 energía o 15 de daño al cadete.
- `Objeto`: nombre, tipo y poder. `Inventario` contiene lista privada, agrega, muestra, consume por índice y aplica energía; escudo, ataque y analizador solo imprimen mensajes y el objeto es removido al usarse.
- `Zona`: nombre/descripción, sin identificador o estado persistente.
- `Mision`: estado booleano para anomalía, núcleo, supervivencia y regreso; una instancia de «La anomalia perdida» y evaluación de completitud.
- `SistemaNexus`: instancia misión y cuatro zonas, crea cadete y equipo inicial, gobierna menú, exploración, encuentros, recompensa y pausa mediante consola. El flujo del Bosque puede repetirse y agregar energía/XP cada vez.
- `Program.Main`: crea `SistemaNexus` e inicia el ciclo.

## Flujo actual y limitaciones

La partida se mantiene solo en memoria. `SistemaNexus` acopla reglas, navegación, presentación, entrada por teclado y creación de contenido; no hay capa de servicios/datos ni interfaces que permitan reutilizar las reglas desde WinForms. El encuentro recibe una sola acción y no conserva claramente una entidad enemiga entre visitas. Las zonas no se bloquean ni registran visitas; pueden repetirse recompensas. El escudo no mitiga daño; ataque y analizador tampoco implementan efectos. La misión está codificada como cuatro booleanos y una sola campaña. No hay guardado, carga, base de datos, pruebas automatizadas declaradas en la estructura listada, ni manejo de perfil múltiple.

El prototipo WinForms actual es una cáscara de navegación, no el videojuego final: lanzar simulación depende de hallar el exe de consola en una ruta calculada; los paneles de mapas e información son `MessageBox`, y no hay pantalla integrada de misión/inventario ni repositorio SQL. Las versiones objetivo son distintas (.NET 8 consola y .NET 10 Windows Forms), por lo que se debe acordar compatibilidad de modelos al separar lógica.

## Diagrama actual

```text
Program.Main
  └─ SistemaNexus (menú + reglas + presentación/Console)
      ├─ Cadete ─ Personaje
      │   └─ Inventario ─ Objeto
      ├─ Mision (4 booleanos)
      ├─ Zonas: Bosque / Ruinas / Anomalía / Extracción
      └─ Encuentros: Robot o Enemigo ─ Personaje

WinForms Program ─ Form1 ─ inicia otro proceso de consola
                         ├─ diálogos de mapas/información
                         └─ configuración/salida
```

La ruta de evolución concreta y los límites que deben conservarse están en [diseño del juego](diseno-del-juego.md) y [arquitectura propuesta](arquitectura-propuesta.md).
