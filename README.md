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
- Coleccionables
-Enemigos

//English
- Basic level with colliders
- Basic character with movement
- Controls good for playing on mobile devices
- Start menu that allows the player to start or quit the game
- A button to quit the level
- Death by falling
- Death menu that allows the player to restart the level or quit the game
- Finish line
- Collectables
- Enemies

## Nivel 2 / Level 2
- Plataformas resbaladizas
- Power ups
- Sistema de vidas
- Trampolines
- Doble salto

//English
- Slippery platforms
- Enemies that move on a fixed line
- Power ups
- Limited lives system
- Trampolines
- Double jump

## Nivel 3 / Level 3
- Enemigos cuya inteligencia se modele con una máquina de estados finita
- Mejorar la interfaz
- Añadir texturas

//English
- Enemies whose intelligence is ruled by a finite state machine
- Make the interface pretty
- Add textures

# Desarrollo / Development
Para llevar a cabo el proyecto, trabajé todas las mañanas de la semana. 
El primer día, me centré en planificar el proyecto a grandes rasgos y organizar en niveles las principales mecánicas que quería incluir. 
Estando todo planeado, comencé a trabajar en la programación. Algunas mecánicas resultaron más difíciles que otras, pero fui capaz de acabar con una demo jugable. 
Finalmente, los dos últimos días los dediqué a crear una buena documentación y a redactar el resumen. 

## Movimiento / Movement
Quería que, a pesar del aspecto 3D del juego, el cubo solo se pudiera mover en 2D, por lo que aproveché las propiedades del Rigidbody para congelar su posición en Z. En un principio, programé el movimiento como siempre lo había hecho en clase: aplicando una transformación sobre las coordenadas del cubo y usando una fuerza de impulso sobre el Rigidbody para el salto. Sin embargo, la inclusión de plataformas resbaladizas hizo que tuviera que cambiar la forma en la que se desplazaba de izquierda a derecha y acabé usando fuerzas de aceleración para que el cubo fuera afectado por la fricción del suelo. De esta forma, me quedó un juego más basado en la física de lo que había planteado en un principio. 

## Controles / Controls

