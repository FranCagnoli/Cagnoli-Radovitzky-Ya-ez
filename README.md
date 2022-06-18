# Cagnoli - Radovitzky - Yañez

Repositorio destinado al obligatorio de ingeniería de software agil 2

## Proceso de Ingeniería en el contexto de Kanban

Vamos a utilizar Behaviour-Driven Development (BDD) para desarrollar y documentar los cambios que le vamos haciendo al obigatorio y mejoras a aplicar. Definiremos cuales son estos cambios que le debemos hacer al proyecto y serán nuestras user stories.

Parte de esta reunión consistió en ponernos de acuerdo en la forma de trabajo, que utilizar para llevar seguimiento de las horas, que metricas vamos a aplicar, y definir la pipeline para esta primer entrega.

### Definición de la pipeline

El objetivo es no complejizar la pipeline más de lo necesario. Principalmente tendremos las columnas ToDo, Doing y Done, como es habitual. La columna Doing en realidad no va existir como tal, ya que va a ser desglosada en una serie de columnas distintas, mas especificas, que en conjunto forman el Doing. El objetivo de esta decisión es poder ser más precisos con las medidas de tiempo de cada tarea, asi sabremos el tiempo que nos cuesta cada aprte del proceso en particular para cada tarea, permitiendonos, utilizando las métricas, identificar problemas en nuestra pipeline, para asi resolverlos y optimizar los recursos que tenemos y lograr estimaciones más precisas.

Uno de los objetivos para esta primera entrega es dejar claro el scope del proyecto, poniendo todas las tareas que pensamos hacer como user stories en la columna de ToDo. Comprendemos que la mayor parte de las tareas a realizar van a ser descubiertas en el análisis exploratorio a realizar para esta primera entrega, pero logicamente contemplamos la posibilidad de encontrar nuevos problemas en el obligatorio a mejorar más adelante.

Vamos a separar Doing en RD, TCI, COD, Testing y refactor para las proximas entregas. 

Requirement Definition (RD) consistirá en pasar los bugs/issues a resolver como Issues de GitHub Actions.
Test Case Implementation (TCI)
Codificación (COD)
Testing
Refactor
### Métricas a Utilizar

- Story points
- Lead time
- Cycle time
- Deployment frequency
- Horas personas --> mide efuerzo
- Burndown charts

## Tecnologias a utilizar:

### Paymo

Hicimos uso de Paymo para poder trackear aproximadamente las horas que se invirtio en cada tarea.
Allí, cada persona que trabaja en el proyecto puede ingresar las horas y se puede ver la descomposición por cada usuario. A su vez, distintas métricas por tarea que pueden ayudar y dar información relevante, y reportes al final de cada mes o semana nos pueden otorgar informacion relevante.

### LiveShare

Para trabajar en la documentación del readme en conjunto se utiliza la extension de vs code LiveShare, que permite trabajar de manera simultanea, de manera remota en la computadora del host.

### IDE

Con los IDE decidimos estandarizar los IDE que utilizaremos en el desarollo. Para la parte del Front vamos a utilizar visual studio code, mientras que para el backend se va usar Visual Studio.

# Tareas:

- Setup del Proyecto.
- Analisis de codigo.
- Stand-up meeting para asignarlas.

## Setup del Proyecto

### FrontEnd

Para hacer el setup del front-end se necesita abrir una consola, ir al directorio de MinTurFrontEnd y realizar un `bash npm i`, luego de instalada las dependencias, se tiene que correr el comando npm start para que la applicacion se abra en el navegador y revisar que no haya ningun error con la misma.

### BackEnd

Como decidimos correr el proyecto en Visual studio, simplemente consto de abrirlo y selecionar como Start up project a la api y darle run.


## Stand-up meeting

Decidimos, en tener solamente una  stand-up meeting por semana, debido a que es un proyecto con una carga de 5 horas por integrante por semana, y al tener todos otras responsabilidades y distinos horarios nos seria dificl de poder realizarlas de manera diaria o inclusive dia de por medio.

## Links segundo informe

Links a grabaciones
<br>
[retrospectiva](https://youtu.be/2xH2zSNAtPY) <br>
[review](https://youtu.be/2xH2zSNAtPY)

<br>
[retrospectiva](https://youtu.be/8jRB-pX_oYg) <br>
[review](https://youtu.be/idre0ZTmAfo)
