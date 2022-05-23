Feature: Baja Punto de Carga
		Como Administrador del sistema
		Quiero eliminar un nuevo punto de carga
		Para poder verlo en el sistema

@borradoValida
Scenario: Se trata de eliminar un punto de carga con exito
Given un id 1 de un punto de carga existente
When se elimina el punto de carga
Then responde con un codigo 200
Then responde con un mensaje de exito: "Electric Charging Point 1 succesfully deleted"


@borradoIdInvalida
Scenario: Se trata de eliminar un punto de carga no existente
Given un id 1 de un punto de carga inexistente
When se elimina el punto de carga
Then arroja una excepcion indicando "Could not find specified Electric Charging Point"
	