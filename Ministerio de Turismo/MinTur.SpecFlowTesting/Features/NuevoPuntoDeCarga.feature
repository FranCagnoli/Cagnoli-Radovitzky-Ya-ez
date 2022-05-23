Feature: Nuevo Punto de Carga
		Como Administrador del sistema
		Quiero crear un nuevo punto de carga
		Para poder verlo en el sistema

@creacionValida
Scenario: Se trata de crear un punto de carga con exito
	Given un nombre "Punto de carga 1"
	And una direccion "Direccion del punto de carga 1"
	And un ID de Region 2 existente
	And una descripcion "Descripcion del putno de carga 1"
	When creo un punto de carga con esos valores
	Then responde con un codigo de exito 201
	And responde con el punto de carga creado.
	
@creacionNombreInvalida
Scenario: Crear un punto de carga sin nombre
	Given un nombre ""
	And una direccion "Direccion del punto de carga 1"
	And un ID de Region 2 existente
	And una descripcion "Descripcion del putno de carga 1"
	When creo un punto de carga con esos valores
	Then arroja una excepcion indicando "Invalid or missing Name. Only up to 20 characters allowed"

@creacionDireccionInvalida
Scenario: Crear un punto de carga sin direccion
	Given un nombre "Punto de carga 1"
	And una direccion ""
	And un ID de Region 2 existente
	And una descripcion "Descripcion del putno de carga 1"
	When creo un punto de carga con esos valores
	Then arroja una excepcion indicando "Invalid or missing Address. Only up to 30 characters allowed"

@creacionRegionInvalida
Scenario: Crear un punto de carga sin region
	Given un nombre "Punto de carga 1"
	And una direccion "Direccion del punto de carga 1"
	And un ID de Region 2 inexistente
	And una descripcion "Descripcion del putno de carga 1"
	When creo un punto de carga con esos valores
	Then arroja una excepcion indicando "Could not find specified region"

@creacionRegionInvalida
Scenario: Crear un punto de carga sin descripcion
	Given un nombre "Punto de carga 1"
	And una direccion "Direccion del punto de carga 1"
	And un ID de Region 2 existente
	And una descripcion ""
	When creo un punto de carga con esos valores
	Then arroja una excepcion indicando "Invalid or missing Description. Only up to 60 characters allowed"