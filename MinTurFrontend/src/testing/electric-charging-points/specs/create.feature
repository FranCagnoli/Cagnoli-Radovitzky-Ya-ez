Feature: Create charging point

# Scenario:  Entrar a la pagina de crear un punto de carga
#  Given trato de cargar la pagina "/admin/charging-points-create"
#  When soy admin
#  Then el titulo de la pagina es "Create charging point"


Scenario: Se trata de crear un punto de carga con exito
Given un usuario loggeado de admin
And estoy en la pagina de agregar punto de carga para auto electrico
And un nombre "Punto de carga 1"
And una direccion "Direccion del punto de carga 1"
And una descripcion "Descripcion del punto de carga 1"
And un ID de Region existente "2"
When apreto el boton "Crear"
Then responde con un mensaje de "Charging station added"


Scenario: Crear un punto de carga sin nombre
Given un usuario loggeado de admin
And estoy en la pagina de agregar punto de carga para auto electrico
Given un nombre ""
And una direccion "Direccion del punto de carga 1"
And un ID de Region existente "2"
And una descripcion "Descripcion del putno de carga 1"
When apreto el boton "Crear"
Then aparece un mensaje de error "Invalid or missing Name. Only up to 20 characters allowed"


Scenario: Crear un punto de carga sin direccion
Given un usuario loggeado de admin
And estoy en la pagina de agregar punto de carga para auto electrico
And un nombre "Punto de carga 1"
And una direccion ""
And un ID de Region existente "2"
And una descripcion "Descripcion del putno de carga 1"
When apreto el boton "Crear"
Then aparece un mensaje de error "Invalid or missing Address. Only up to 30 characters allowed"

Scenario: Crear un punto de caga sin region
Given un usuario loggeado de admin
And estoy en la pagina de agregar punto de carga para auto electrico
And un nombre "Punto de carga 1"
And una direccion "Direccion del punto de carga 1"
And un ID de Region existente ""
And una descripcion "Descripcion del putno de carga 1"
When apreto el boton "Crear"
Then aparece un mensaje de error "Could not find specified region"

Scenario: Crear un punto de carga sin descripcion
Given un usuario loggeado de admin
And estoy en la pagina de agregar punto de carga para auto electrico
And un nombre "Punto de carga 1"
And una direccion "Direccion del punto de carga 1"
And un ID de Region existente "2"
And una descripcion ""
When apreto el boton "Crear"
Then aparece un mensaje de error "Invalid or missing Description. Only up to 60 characters allowed"
