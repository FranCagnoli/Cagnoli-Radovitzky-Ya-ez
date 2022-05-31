Feature: Delete charging Points

Scenario: Entrar a la pagina de eliminar un punto de carga
Given voy a la pagina de listado de punto de carga
And un usuario loggeado de admin
Then Me deja ver la pagina

Scenario: Se elimina un punto de carga
Given voy a la pagina de listado de punto de carga
When se apreta el boton eliminar de uno de los puntos
Then responde con un mensaje de "Electric Charging Point 1 succesfully deleted"

Scenario: se trata de eliminar un punto de carga no existente
Given voy a la pagina de listado de punto de carga
When se apreta el boton eliminar de uno de los puntos no existentes
Then responde con un mensaje de "Could not find specified electric charging point"
