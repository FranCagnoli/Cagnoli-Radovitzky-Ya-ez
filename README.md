# Cagnoli - Radovitzky - Yañez

Repositorio destinado al obligatorio de ingeniería de software agil 2

## Proceso de Ingeniería en el contexto de Kanban

Vamos a utilizar Behaviour-Driven Development (BDD) para desarrollar y documentar los cambios que le vamos haciendo al obigatorio y mejoras a aplicar. Definiremos cuales son estos cambios que le debemos hacer al proyecto y serán nuestras user stories.

### Definición de la pipeline

El objetivo es no complejizar la pipeline más de lo necesario. Principalmente tendremos las columnas ToDo, Doing y Done, como es habitual. La columna Doing en realidad no va existir como tal, ya que va a ser desglosada en una serie de columnas distintas, mas especificas, que en conjunto forman el Doing. El objetivo de esta decisión es poder ser más precisos con las medidas de tiempo de cada tarea, asi sabremos el tiempo que nos cuesta cada aprte del proceso en particular para cada tarea, permitiendonos, utilizando las métricas, identificar problemas en nuestra pipeline, para asi resolverlos y optimizar los recursos que tenemos y lograr estimaciones más precisas.

Uno de los objetivos es dejar claro el scope del proyecto, poniendo todas las tareas que pensamos hacer como user stories en la columna de ToDo. Comprendemos que la mayor parte de las tareas a realizar van a ser descubiertas en el análisis exploratorio a realizar para esta primera entrega, pero logicamente contemplamos la posibilidad de encontrar nuevos problemas en el obligatorio a mejorar más adelante.

Vamos a separar Doing en RD, TCI, COD, Testing y refactor para las proximas entregas. 

Requirement Definition (RD)
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
Allí, cada persona que trabaja en el proyecto puede ingresar las horas y se puede ver la descomposición por cada usuario. A su vez, distintas métricas por tarea que pueden ayudar, y reportes al final de cada mes o semana nos pueden otorgar informacion relevante.

### LiveShare

Para trabajar en la documentación del readme en conjunto se utiliza la extension de vs code LiveShare, que permite trabajar de manera simultanea, de manera remota en la computadora del host.

### IDE

Decidimos estandarizar los IDE que utilizaremos en el desarollo. 
Para la parte del Front vamos a utilizar visual studio code, mientras que para el backend se va usar Visual Studio.

### Repositorio

La organización del proyecto y su documentación se realiza mediante el uso de un repositorio de Github, con un GitFlow adaptado a nuestra situación.
Crearemos ramas a partir de una rama develop, para cada feature necesaria (por ejemplo, feature/bug1). Dentro de esa rama, haremos los commits necesarios para terminar de desarrollar la misma. Cuando termine el feature, abriremos una pull request a develop y un desarrollador solicitará al PO que se le apruebe la misma. Luego para cada entrega mergearemos develop con master, y asi poder dejarla al dia.

Al final del proyecto, en master debería existir el archivo Readme en la ruta, que contendrá la documentación, y una carpeta por cada entrega dentro de (/Entregas).

# Tareas:

- Setup del Proyecto.
- Analisis de codigo.
- Stand-up meeting para asignarlas.

## Proyectos

### Frontend

Para hacer correr el front-end se necesita seguir los siguientes pasos dentro de la consola.

1. Ir al directorio de MinTurFrontEnd <br>
  `cd MinTurFrontEnd`
2. Instalar las dependencias <br>
  `npm install`
3. Correr el proyecto <br>
  `npm start`

La aplicación se abrirá en el navegador.

#### E2E Testing

Para correr los tests End-To-End de angular, realizar los siguientes pasos.
En una terminal:<br>
`webdriver-manager start`

Luego, abrir otra terminal y ejecutar:
```
cd MinTurFrontEnd/src/testing
protractor protractor.conf.js
```

### Backend

Como decidimos correr el proyecto en Visual studio, los pasos para correrlos son simples.

1. Seleccionar WebApi como start-up project
2. Correr el proyecto en modo Debug

#### Unit testing

Para correr los tests, simplemente hacer click en Tests -> Run All

## Stand-up meeting

Debido a que dos integrantes del equipo trabajan, y uno hace otra carrera en paralelo, decidimos tener solamente una instancia de stand-up meeting por semana. Al ser un proyecto con una carga de 5 horas por integrante/semanales, y con la variedad de horarios que compartimos, nos seria dificl poder realizarlas de manera diaria o inclusive dia de por medio.

## Links segundo informe

Links a grabaciones
<br>
### Entrega 2
[retrospectiva-2](https://youtu.be/2xH2zSNAtPY) 
<br>
[review-2](https://youtu.be/2xH2zSNAtPY)
<br>

### Entrega 3

[retrospectiva-3](https://youtu.be/2xH2zSNAtPY)
<br>
[review-3](https://youtu.be/idre0ZTmAfo)
<br>


