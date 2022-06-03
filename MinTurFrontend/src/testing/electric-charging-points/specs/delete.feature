Feature: Delete charging Points

Scenario: Entrar a la pagina de eliminar un punto de carga
Given un usuario loggeado de admin
And voy a la pagina de listado de punto de carga
And un usuario loggeado de admin
Then Me deja ver la pagina

Scenario: Se elimina un punto de carga
Given un usuario loggeado de admin
And voy a la pagina de listado de punto de carga
When se apreta el boton eliminar de uno de los puntos
Then responde con un mensaje de "Electric Charging Point 1 succesfully deleted"

Scenario: se trata de eliminar un punto de carga no existente
Given un usuario no loogeado de admin
And voy a la pagina de listado de punto de carga
Then no se visualiza la pagina.
