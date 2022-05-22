Feature: Nuevo Punto de Carga
		Como Administrador del sistema
		Quiero crear un nuevo punto de carga
		Para poder verlo en el sistema

@creacionValida
Scenario: Se trata de crear un punto de carga con exito
	Given un usuario loggeado como admin
	And un nombre "Punto de carga 1"
	And una direccion "Direccion del punto de carga 1"
	And un ID de Region 2 (existente)
	And una descripcion "Descripcion del putno de carga 1"
	When creo un punto de carga con esos valores
	Then responde con un codigo de exito 201
	And responde con el punto de carga creado.
	