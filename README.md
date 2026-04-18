# Aiming Arcade - Clase 9
Alumno: Federico Bazán
Fecha: Abril 2026

---

## Descripción
Juego de galería de tiro en primera persona. El jugador maneja una pistola de agua y debe disparar a dianas que cruzan la pantalla de derecha a izquierda. El objetivo es eliminar todas las dianas antes de que escapen. Si las eliminás todas, ganás. Si alguna escapa, el juego muestra cuántas lograste romper.

---

## Controles
- Rueda del mouse: Rotar el arma horizontalmente para apuntar
- Click izquierdo: Disparar proyectil

---

## Mecánicas
- Las dianas spawnean desde la derecha y se mueven hacia la izquierda a velocidad constante
- El jugador dispara proyectiles que al impactar desactivan la diana
- El juego lleva un conteo de progreso en consola (ej: `Progreso: 3/6`)
- Al eliminar todas → `You Win!`
- Si alguna escapa sin ser golpeada → `Rompiste X/6, has perdido!`

---

## Estructura de la escena
- Entorno armado con assets de Synty (POLYGON Starter Pack)
- Fondo con montañas, árboles y cielo low poly
- Piso de baldosas
- Watergun en primer plano (vista en primera persona)
- Spawner posicionado a la derecha de la escena

---

## Scripts

**Scripts/MovimientoDianas.cs**
- Mueve la diana hacia la izquierda usando `transform.Translate` con `Space.World`
- Usa `Time.deltaTime` para movimiento independiente del framerate
- Al salir del límite de la escena (`x < -15`) desactiva el objeto y llama a `CheckFinish`

**Scripts/Spawner.cs**
- Usa una **Coroutine** para spawnear las dianas con separación espacial entre ellas
- Asigna al vuelo la referencia al `GunGameManager` a cada diana instanciada
- Registra todas las dianas en el array del manager al momento de spawnear

**Scripts/RotacionArma.cs**
- Captura el input de la rueda del mouse con `Input.GetAxis("Mouse ScrollWheel")`
- Rota el arma en el eje Y según la sensibilidad configurada

**Scripts/GunGameManager.cs**
- Controla el estado global del juego
- Método `CheckFinish()` que cuenta dianas desactivadas vs total
- Método `DianaRota()` que trackea cuántas fueron eliminadas por disparo (vs escapadas)
- Condición de victoria: todas eliminadas por disparo → `You Win!`
- Condición de derrota: todas desactivadas pero no todas rotas → `Rompiste X/6, has perdido!`

**Scripts/Proyectil.cs**
- Se mueve hacia adelante con `transform.Translate` y `Time.deltaTime`
- Al colisionar con tag `Diana` via `OnTriggerEnter`:
  - Usa `transform.root` para obtener el objeto raíz de la diana
  - Desactiva la diana
  - Llama a `DianaRota()` y `CheckFinish()` del manager
  - Se destruye a sí mismo

**Scripts/Disparar.cs**
- Detecta click izquierdo con `Input.GetMouseButtonDown(0)`
- Instancia el prefab del proyectil en el `PuntoDisparo`
- Le pasa la referencia al `GunGameManager` al proyectil instanciado

---

## Assets utilizados
- POLYGON Starter Pack - Art by Synty (gratuito): https://assetstore.unity.com/packages/essentials/tutorial-projects/polygon-starter-pack-art-by-synty-156819

---

## Bugs resueltos
- **Diana no se desactivaba correctamente:** el proyectil colisionaba con el hijo del prefab en vez del padre — resuelto usando `transform.root.gameObject`
- **You Win prematuro:** el array de dianas estaba vacío al inicio (`0/0`), haciendo que `desactivadas == dianas.Length` fuera verdadero — resuelto trackeando dianas rotas por disparo por separado con `DianaRota()`
