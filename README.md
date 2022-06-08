# CarDealership.Solution

* INSTRUCCIONES para la ejecucion de la solución:

1. Abrir la solución con Visual Studio > 2019
2. Ejecutar CarDealership.Api con IIS Express
	2.1 Automáticamente se abrirá una ventana en el explorador seleccionado para ello, con la interfaz de Swagger
	2.2 Autenticarse con ApiKey: gjhjJKHKJHKJHIYiIHGIG7GKUK77GJKGgjhgi7tjkI
	2.3 Si el usuario no se autentica, no podrá ejecutar los endpoints
3. Ejecución endpoints: 
	Métodos: Get, GetAll, Create, Update, Delete sobre un fichero .json
	

* CARDEALERSHIP SOLUTION

Se trata de una solución dividida en 4 capas orientadas al dominio:

01. API
	Contiene un API Rest cuyos endpoints exponen los métodos que aparecen en la pantalla inicial al ejecutar la solución. Realizan las operaciones necesarias para leer, escribir y borrar un fichero .json con datos.
		
02. Application
	Esta capa contiene un servicio que orquesta las peticiones recibidas por la API a través de MediatR, basándose en el patrón CQRS para discernir entre consultas y operaciones sobre los datos.
	
03. Domain
	Capa Core que recibe las peticiones orquestadas por la capa de Application, y que servirá de paso hacia la capa de datos, realizando la lógica que corresponda en cada caso. 
	El enlace entre esta capa y la capa de datos se realiza basándose en el patrón Repository, pero abstrayendo las interfaces de sus implementaciones de acceso a datos. De esta forma, esta capa contiene las interfaces de la capa de datos (principio Inversión de dependencias) para que sea la capa de datos la que dependa de este Dominio, y no al revés (CarDealership.Domain.DataInterfaces).
	
04. Infraestructure
	Última capa donde se encuentran/encontrarían los distintos accesos a datos (en el caso de que hubiera más de un tipo de acceso). En esta solución, se implementa una clase Repository con varios métodos, y su fuente de datos es unicamente un fichero .json con algunos datos simples.
	

* REQUIRIMIENTOS NO REALIZADOS

He intentado cumplir con todos ellos, pero no he podido terminar de realizar por completo los test unitarios por no demorarlo más, aunque he creado un test unitario para cada capa.

Comentarios sobre los principios utilizados y paquetes de terceros los he documentado en la solución, pero no en el 100% de las clases.
