# Plataformas de prueba / Test platformer
Plataformas básico hecho en Unity como test de conocimientos

//English
Basic platformer made with Unity as skills test

# Características planeadas / Planned features
Para esta tarea, planteo tres niveles de complejidad: el Nivel 1 (básico), el Nivel 2 (intermedio) y el Nivel 3 (avanzado). Para comenzar a implementar las características descritas en un nivel es necesario haber implementado todas las del nivel anterior. 

//English
For this assignment, I'm planning three complexity levels: Level 1 (basic), Level 2 (medium) and Level 3 (advanced). In order to implement the features described in a given level, it is necesary to have had implemented all the features in the level below.

## Nivel 1 / Level 1
- Nivel básico con colisiones
- Incluir un personaje con movimiento
- Controles adecuados para el móvil
- Menú inicial que permita acceder al nivel o cerrar el juego
- Botón de salir del nivel
- Muerte por caída
- Menú de muerte que permita salir o reiniciar el nivel
- Meta 

//English
- Basic level with colliders
- Basic character with movement
- Controls good for playing on mobile devices
- Start menu that allows the player to start or quit the game
- A button to quit the level
- Death by falling
- Death menu that allows the player to restart the level or quit the game
- Finish line

## Nivel 2 / Level 2
- Pinchos
- Enemigos que se muevan de forma fija
- Power ups
- Sistema de vidas

//English
- Spikes
- Enemies that move on a fixed line
- Power ups
- Limited lives system

## Nivel 3 / Level 3
- Enemigos cuya inteligencia se modele con una máquina de estados finita
- Mejorar la interfaz
- Añadir texturas

//English
- Enemies whose intelligence is ruled by a finite state machine
- Make the interface pretty
- Add textures

# Desarrollo / Development
## Movimiento de la cámara / Camera movement
He probado varios métodos para que la cámara siguiera al personaje jugador. El más obvio es hacerla su hija, pero eso hace que la cámara rote junto con él, cosa que no queda bien. Otra opción era asignarle la posición en el eje X del Cubo, pero este tiembla de forma imperceptible al chocar con la colisión del cubo, cosa que hacía que la cámara tuviera un efecto tembleque que no interesaba. Finalmente, decidí que el Cubo se encargara de informar a la cámara cuando se moviera de forma que esta lo siguiera.

//English
I have tested different methods so that the camera would follow the player. Firstly, I tested the obvious: make the main camera a child of the Cube. The problem with this was that the camera rotated along with the Cube, and it is not what I wanted. Second, I tried assigning the X value of the Cube's position to the camera. This didn't work either, as the Cube trembles a bit when hitting the floor, so this made everything tremble. Finally, I decided that the Cube would inform the camera whenever it moved so the camera would follow it. 
