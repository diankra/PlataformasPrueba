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
El salto es una mecánica complicada por el hecho de que tiene que haber una manera de saber si el personaje está saltando o no para ajustar las animaciones, los efectos de sonido y evitar que los jugadores se aprovechen de su mal funcionamiento para pasarse el nivel volando. Así, decidí que el salto comenzaría de dos maneras: la primera, presionando el botón de salto, y la segunda, cayéndose de una plataforma. Además, hay un contador que indica los saltos en el aire que se han realizado, de forma que permite el salto doble pero no el triple o cuádruple. 

## Controles / Controls
A la hora de adaptar los controles a la plataforma Android se me presentaron varias opciones. Por una parte, podía usar flechas visibles en la pantalla y un botón que permitiera saltar, pero eso no me parecía ergonómico. También podía usar un joystick virtual, pero era poco preciso para lo que quería hacer. Finalmente, opté por usar botones invisibles que cubrieran toda la pantalla, ya que me parecía la manera más natural de usar un móvil para jugar a un plataformas. Tocando en la mitad inferior de la pantalla permite moverse de izquierda a derecha y tocando la parte superior, permite saltar, como muestra el siguiente diagrama:

![Screen buttons](https://github.com/diankra/PlataformasPrueba/blob/master/Controles.png?raw=true)

## Menús / Menus
Para los menús opté por una interfaz sencilla y funcional. Opté por separar los tres menús (el inicial, el de muerte y el de victoria) en escenas diferentes a pesar de ser muy similares para que fuera más sencillo añadir elementos diferenciadores sin tener que pasar demasiadas variables al cambio de escena. 

## Enemigos y muerte / Enemies and death
Los enemigos siguen un movimiento sencillo de un lado a otro cuya velocidad y longitud se puede alterar fácilmente desde el editor de Unity, de forma que el diseñador de niveles no tiene que entrar a programar nada en C#. Al igual que el protagonista, tienen congelada la posición en Z para evitar que lleguen a puntos en los que no pueden alcanzarle. Para evitar que se queden encasquillados a la hora de encontrar un obstáculo en su camino (ya sea una plataforma o al mismo protagonista), cada vez que chocan con algo cambian de dirección, independientemente de si han terminado o no su recorrido. Cada vez que chocan con el protagonista, además, le quitan una vida, y este muere si se le acaban todas.
Para la muerte por caída, opté por ignorar las vidas y hacer que muriera directamente, que es lo que se hace en gran parte de los juegos de ordenador. Con más tiempo podría quitarse una vida, al igual que los enemigos, y hacer que volviera a un punto de control, ya que al morir se reinicia el nivel al completo. 

## Coleccionables / Collectables
En un principio tenía claro que había que incluir coleccionables, pero no tenía claro qué función podrían tener. Pensé que su recolección fuera necesaria para acabar el nivel, pero esa no es una mecánica que personalmente me entusiasme. Por tanto, decidí usar los coleccionables como premio a los jugadores que los cogieran: cada vez que se recojan un cierto número de ellos (configurable a través del editor de Unity), las vidas del jugador aumentan en 1, de forma similar a las monedas en Super Mario Bros.

## Power ups
También añadí power-ups, objetos que dan al protagonista poderes especiales. En este caso, son esferas que al recogerlas permiten que el jugador mate a los enemigos por un tiempo limitado de forma similar al Pac-Man. Estos power-ups se sitúan, idealmente, en lugares difíciles de acceder. La mecánica podría mejorar si los enemigos tuvieran algún tipo de IA que hiciera que persiguieran al personaje cuando estuviera cerca pero se alejaran cuando hubiera recogido el power-up. Esto se dejó fuera, sin embargo, por falta de tiempo. 

## Plataformas especiales / Special platforms
Se añadieron dos tipos nuevos de suelo para hacer las plataformas más interesantes: el trampolín y las plataformas resbaladizas. 
En el caso del trampolín, es una plataforma donde el personaje salta continuamente sin que pueda controlarlo. 
Las plataformas resbaladizas son plataformas sin fricción donde el personaje resbala cuando se deja de pulsar el botón de movimiento, cosa que hace complicado el movimiento de un lado a otro. 

## Puntos de salto / Jumping Points
Finalmente, los puntos de salto son puntos especiales del mapa que permiten un salto extra en el aire cuando se pasa al lado, basados en los puntos luminosos del juego de móvil Geometry Dash. Son la última mecánica que añadí, ya que me parecía que podría dar pie a niveles muy complejos e interesantes. 

## Mejoras para las que no hubo tiempo / Improvements for which there was no time
Me habría gustado mejorar el diseño del nivel, ya que podría explotar las mecánicas mejor. También, como he dicho anteriormente, habría añadido una sencilla inteligencia artificial a los enemigos para que huyeran del protagonista cuando este consumiera un power-up. Además, si hubiera habido más tiempo, habría mejorado el aspecto gráfico del juego con botones personalizados y, al menos, fondos 2D. Asimismo, con más horas, añadiría un tutorial para explicar las principales mecánicas y los controles de forma más clara a los jugadores nuevos, así como un menú de pausa.

# Conclusiones / Conclusions
Hasta ahora había hecho distintos proyectos en Unity, pero pocas veces me había parado a programar un juego completo, y menos en tan poco tiempo.
Considero que el resultado está poco pulido debido al poco tiempo, pero es una demo funcional que contiene las bases para desarrollarse y convertirse en algo mucho más atractivo si se le dedicaran más horas. 
Finalmente, este desarrollo exprés me ha servido para afianzar los conocimientos que ya tenía del entorno, ya que he puesto en práctica lo aprendido de varias fuentes distintas en un mismo proyecto. 

