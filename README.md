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

//English
In order to finish the project, I worked every morning of the week.
On the fist day, I focused on roughly planning the project and I organized the tasks I had to do in difficulty levels, as seen above. 
When I had everything planned, I started programming. Some features were harder than others, but I managed to finish a playable demo. 
Finally, I dedicated the last two days to build a documentation and sum up the work on the README. 

## Movimiento / Movement
Quería que, a pesar del aspecto 3D del juego, el cubo solo se pudiera mover en 2D, por lo que aproveché las propiedades del Rigidbody para congelar su posición en Z. En un principio, programé el movimiento como siempre lo había hecho en clase: aplicando una transformación sobre las coordenadas del cubo y usando una fuerza de impulso sobre el Rigidbody para el salto. Sin embargo, la inclusión de plataformas resbaladizas hizo que tuviera que cambiar la forma en la que se desplazaba de izquierda a derecha y acabé usando fuerzas de aceleración para que el cubo fuera afectado por la fricción del suelo. De esta forma, me quedó un juego más basado en la física de lo que había planteado en un principio. 
El salto es una mecánica complicada por el hecho de que tiene que haber una manera de saber si el personaje está saltando o no para ajustar las animaciones, los efectos de sonido y evitar que los jugadores se aprovechen de su mal funcionamiento para pasarse el nivel volando. Así, decidí que el salto comenzaría de tres maneras: la primera, presionando el botón de salto, la segunda, cayéndose de una plataforma, y la tercera, tocando un trampolín. Además, hay un contador que indica los saltos en el aire que se han realizado, de forma que permite el salto doble pero no el triple o cuádruple. 

//English
In spite of the game's 3D aspect, I wanted the cube to only move in 2D, so I used the Rigidbody properties to freeze its Z position. At first, I programmed the movement as I had always done: applying a translation on the cube's coordinates and applying an impulse force on the cube for jumping. Everything changed when I included the slippery platforms. I had to change the way the cube moved from left to right so that friction would affect it, so I applied acceleration forces instead of simple transformations. This way, the game made more emphasis on physics than I initially intended. 
Jumping is a difficult feature because you have to know when the character is jumping to adjust animations, sound effects and to avoid exploits that would allow the player to finish the level by flying. So, for in-game purposes, I decided that there would be three ways to initiate a jump: pressing the Jump button, fallling from a platform and hitting a trampoline. Additionaly, there is a counter which counts the consecutive jumps, so that the game allows double jump but not triple or cuadruple. 

## Controles / Controls
A la hora de adaptar los controles a la plataforma Android se me presentaron varias opciones. Por una parte, podía usar flechas visibles en la pantalla y un botón que permitiera saltar, pero eso no me parecía ergonómico. También podía usar un joystick virtual, pero era poco preciso para lo que quería hacer. Finalmente, opté por usar botones invisibles que cubrieran toda la pantalla, ya que me parecía la manera más natural de usar un móvil para jugar a un plataformas. Tocando en la mitad inferior de la pantalla permite moverse de izquierda a derecha y tocando la parte superior, permite saltar, como muestra el siguiente diagrama:

//English
When I had to adapt the controls to the Android platform I was faced with several options. One of them was using visible arrows on the screen and a jump button, but that wasn't exactly ergonomic for the player. I could also use a virtual joystick, but that wasn't precise enough. Finally, I settled on invisible buttons which covered the whole screen, as for me it seemed the most natural way of playing a mmobile game. Touching the inferior part of the screen allows the player to move to the right or left and touching the superior half, allows them to jump as seen below:

![Screen buttons](https://github.com/diankra/PlataformasPrueba/blob/master/Controles.png?raw=true)

## Menús / Menus
Para los menús opté por una interfaz sencilla y funcional. Opté por separar los tres menús (el inicial, el de muerte y el de victoria) en escenas diferentes a pesar de ser muy similares para que fuera más sencillo añadir elementos diferenciadores sin tener que pasar demasiadas variables al cambio de escena. 

//English
For the menus I used a simple and functional interface. I chose to separate the three game menus (the start menu, the death menu and the victory menu) in different scened even though they are quite similar. This was done in order to make them more distinct if needed without having to send too many variables when changing scene. 

## Enemigos y muerte / Enemies and death
Los enemigos siguen un movimiento sencillo de un lado a otro cuya velocidad y longitud se puede alterar fácilmente desde el editor de Unity, de forma que el diseñador de niveles no tiene que entrar a programar nada en C#. Al igual que el protagonista, tienen congelada la posición en Z para evitar que lleguen a puntos en los que no pueden alcanzarle. Para evitar que se queden encasquillados a la hora de encontrar un obstáculo en su camino (ya sea una plataforma o al mismo protagonista), cada vez que chocan con algo cambian de dirección, independientemente de si han terminado o no su recorrido. Cada vez que chocan con el protagonista, además, le quitan una vida, y este muere si se le acaban todas.
Para la muerte por caída, opté por ignorar las vidas y hacer que muriera directamente, que es lo que se hace en gran parte de los juegos de ordenador. 

//English
The enemies follow a simple movement from left to right which can be easily altered in lenght and speed in the Unity menu, so that the level designer doesn't have to open the C# scripts. They have the Z position frozen, same as the main cube, so that they don't reach places where they can no longer hit it. They turn back when hitting an obstacle (be it environmental or the protagonist itself), so that they don't get stuck, even if they haven't finished their route. When they hit the protagonist, they take a life from him also. 
For the fall death mechanic, I chose to ignore the lives the main character has and kill it instantly, which is done in the vast majority of games. 
## Coleccionables / Collectables
En un principio tenía claro que había que incluir coleccionables, pero no tenía claro qué función podrían tener. Pensé que su recolección fuera necesaria para acabar el nivel, pero esa no es una mecánica que personalmente me entusiasme. Por tanto, decidí usar los coleccionables como premio a los jugadores que los cogieran: cada vez que se recojan un cierto número de ellos (configurable a través del editor de Unity), las vidas del jugador aumentan en 1, de forma similar a las monedas en Super Mario Bros.

//English
It was clear from the beggining that I had to include collectables, but their function wasn't clear to me at first. I thought that they could be the key to finishing the levels, but that isn't a feature I personally enjoy. That way, I decided to use them as a prize for dedicated players: each time a certain number of them (that can be changed through the Unity editor) are collected the character earns a life, the same feature used for coins on Super Mario Bros. 
## Power ups
También añadí power-ups, objetos que dan al protagonista poderes especiales. En este caso, son esferas que al recogerlas permiten que el jugador mate a los enemigos por un tiempo limitado de forma similar al Pac-Man. Estos power-ups se sitúan, idealmente, en lugares difíciles de acceder. La mecánica podría mejorar si los enemigos tuvieran algún tipo de IA que hiciera que persiguieran al personaje cuando estuviera cerca pero se alejaran cuando hubiera recogido el power-up. Esto se dejó fuera, sin embargo, por falta de tiempo. 

//English
I also added power-ups, objects which give special powers to the character. In this case, they are spheres that allow the player to kill the enemies for a limited time after taking them, similar to Pac-Man. These power-ups would be in difficult  places. This feature could improve by adding an AI to the enemies so that they pursue the character but run from it when it takes a power-up. This couldn't be added due to lack of time. 

## Plataformas especiales / Special platforms
Se añadieron dos tipos nuevos de suelo para hacer las plataformas más interesantes: el trampolín y las plataformas resbaladizas. 
En el caso del trampolín, es una plataforma donde el personaje salta continuamente sin que pueda controlarlo. 
Las plataformas resbaladizas son plataformas sin fricción donde el personaje resbala cuando se deja de pulsar el botón de movimiento, cosa que hace complicado el movimiento de un lado a otro. 

//English
I added two kinds of special platforms: trampolines and slippery platforms. 
Trampolines are platforms where the character jumps continuously without control. 
Slippery platforms are platforms without friction, so that the character slips when the movement button stops being pressed, so movement is a bit more complicated. 

## Puntos de salto / Jumping Points
Finalmente, los puntos de salto son puntos especiales del mapa que permiten un salto extra en el aire cuando se pasa al lado, basados en los puntos luminosos del juego de móvil Geometry Dash. Son la última mecánica que añadí. 

//English
Finally, jumping points are special points that allow for an extra jump mid-air when the character is close. They are inspired by the shiny points in Geometry Dash. This is the last feature I added. 

## Mejoras para las que no hubo tiempo / Improvements for which there was no time
Me habría gustado mejorar el diseño del nivel, ya que podría explotar las mecánicas mejor. También, como he dicho anteriormente, habría añadido una sencilla inteligencia artificial a los enemigos para que huyeran del protagonista cuando este consumiera un power-up. Además, si hubiera habido más tiempo, habría mejorado el aspecto gráfico del juego con botones personalizados y, al menos, fondos 2D. Asimismo, con más horas, añadiría un tutorial para explicar las principales mecánicas y los controles de forma más clara a los jugadores nuevos, así como un menú de pausa.

//English
I would have liked to improve the level design to better explore its features. Also, as previously said, I would have liked to program the enemies so that they had a simple AI system so that they would run from the protagonist when it consumed a power-up. Additionaly, if I had had more time, I would have improved the aspect of the game with personalized buttons and, at least, 2D backgrounds. I would have also added a tutorial to explain the main features and controls in a simple way to new players and a pause menu.

# Documentación / Docs
He creado una documentación para el proyecto usando un plugin Doxyfile para Unity a partir de los comentarios del código. Para acceder a ella, hay que entrar en Plataformas/Docs/html/index.html

//English
I have created docs for the project using a Doxyfile for Unity file that creates docs from the comments in the code. To see it, you have to open the file Plataformas/Docs/html/index.html

# Conclusiones / Conclusions
Hasta ahora había hecho distintos proyectos en Unity, pero pocas veces me había parado a programar un juego completo.
Considero que el resultado está poco pulido debido al poco tiempo, pero es una demo funcional que contiene las bases para desarrollarse y convertirse en algo mucho más atractivo si se le dedicaran más horas. 
Finalmente, este desarrollo exprés me ha servido para afianzar los conocimientos que ya tenía del entorno, ya que he puesto en práctica lo aprendido de varias fuentes distintas en un mismo proyecto. 

//English
Until now I have made simple projects on Unity, but I haven't had many opportunities to make a full game.
I consider the result to be a little rough due to the lack of time, but I have managed to finish a functional demo that contains the basis for a future development that could turn the game in something more attractive. 
Finally, this fast development has allowed me to be more confident on the knowledge of Unity I had already adquired. I have put in practice what I have learned from various sources and that has made me more confident for future projects. 

