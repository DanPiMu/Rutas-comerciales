Daniel Pilligua Murillo

# Enunciado Prueba

Mi nombre es Wilhuff Tarkin comandante de la flota imperial. El mismísimo emperador Palpatin nos ha pedido tener información detallada de las rutas comerciales de la galaxia. Y necesitamos de tus servicios para aportar una solución técnica a este problema.

El caso de uso es el siguiente, necesitamos un servicio web(API) del que podamos obtener información de las rutas comerciales. - Para tener un mapa de vuelos comerciales se necesita el listado de rutas y la distancia entre ellas. En este caso necesitamos que la respuesta tenga el siguiente esquema

```sh
//El nombre de los planetas debe estar en un lenguaje entendible por todos los operadores
//La distancia debe estar en años lunares
[
    {
      "Origin": "Tatooine", 
      "Destination": "Alderaan",
      "Distance":  87.43 
    }
]
```
Para poder saber el coste en combustible de cada ruta necesitamos un servicio al que le pasemos dos parámetros, “Origin”, “Destination” y obtengamos como respuesta el precio total de la ruta y un desglose de los gastos de las rutas, en los que estará el precio por Día lunar, el coste en seguridad de cada planeta y el coste en seguridad de elite.

Para calcular el precio en seguridad se tendrá que tener en cuenta la influencia rebelde en los dos planetas, si la suma de la influencia de los dos planetas supera el 40% se deberá aplicar una tasa adicional “EliteStromTrooper” que será la diferencia entre la suma de los dos planetas y el 40%.
La forma correcta de calcular el precio total seria la siguiente: precio base = distancia *precio dia lunar, se suman los porcentajes en defensa y se calcula la tasa de defensa a raiz del precio base. Precio total = Precio Base + tasas.
Ejemplo de la petición
//El nombre de los planetas que se ingresen en la request debe ser en lenguaje entendible para los operadores
{
  "origin": "Tatooine", 
  "destination": "Aldeeran"
}
En este caso necesitamos que la respuesta tenga el siguiente esquema

{
  "totalAmount": 1235.12, 
  "pricesPerLunarDay": 12.35
  "taxes":{
      "originDefenseCost": 2.12,
      "destinationDefenseCost": 3.56,
      "eliteDefenseCost": 0.00
  }
}
El almirante Motti ha dejado las siguientes notas después de su investigación.

Hola comandante, investigando a fondo de donde obtener la información estática de los planetas que están dentro de las rutas comerciales y la distancia entre ellos, existen los siguientes servicios públicos del sindicato. * Planetas: https://otd-exams-data.vueling.app/sindicate/planets.json * Distancias: https://otd-exams-data.vueling.app/sindicate/distances.json

Estos servicios son del sindicato comercial por lo que cada consulta supone un coste para el imperio, mi recomendación es que esta información se persista de alguna forma para reducir costes. Para consultar el precio del combustible tenemos un servicio público del imperio en el que podemos obtener el precio del combustible por dia lunar. * Precio: https://otd-exams-data.vueling.app/empire/prices.json

Por último nuestra red de espías ha puesto a nuestra disposición este canal web para obtener el estado de la influencia rebelde en cada uno de los planetas. * Rebeldes: https://otd-exams-data.vueling.app/empire/spyreport.json

El imperio no deja solo a sus programadores, por lo que le daré los siguientes consejos:
El cambio de años a dias es el terraneo. año = 365 dias.
Estamos tratando con decimales, intenta no utilizar números con coma flotante.
Después de cada cálculo, el resultado debe ser redondeado a dos decimales.

# Aplicación .NET Core Web API

Esta es una aplicación .NET Core Web API desarrollada utilizando la arquitectura DDD y una estructura de N capas. Se ha aplicado el principio SOLID para mantener un diseño modular y escalable. El objetivo de la aplicación es obtener datos de una API externa, almacenarlos en una base de datos y proporcionar dos endpoints para acceder a los datos almacenados.

## Características implementadas

- [Serilog](https://serilog.net/): Se ha integrado la biblioteca Serilog para el registro de eventos y logs en la aplicación.

- Versionado: Se ha implementado la versión de la API para permitir la evolución y compatibilidad con versiones anteriores.

- Control de errores: Se ha utilizado el manejo de excepciones mediante bloques `try-catch` para capturar y gestionar los errores de manera controlada.

- Pruebas unitarias: Se han desarrollado pruebas unitarias utilizando el framework de pruebas MSTest y la biblioteca Moq para simular dependencias.

## Estructura de la aplicación

La aplicación sigue una arquitectura de N capas, lo que permite una separación clara de responsabilidades y una mayor mantenibilidad y escalabilidad.

- **Capa de presentación (API)**: Esta capa contiene los controladores de la API y se encarga de recibir las solicitudes HTTP, procesarlas y devolver las respuestas adecuadas.

- **Capa de aplicación**: Esta capa contiene los servicios de aplicación que se encargan de orquestar las operaciones y aplicar la lógica de negocio. Aquí se definen las interfaces y las implementaciones de los servicios.

- **Capa de dominio**: En esta capa se encuentran las entidades y las reglas de negocio del dominio de la aplicación. Aquí se definen las interfaces de los repositorios y los servicios de dominio.

- **Capa de infraestructura**: Esta capa contiene la implementación concreta de los repositorios y otros componentes de infraestructura, como acceso a datos, servicios externos, etc.

## Puntos destacados

- La inserción de datos desde la API externa se realiza al iniciar la aplicación, utilizando la interfaz `IHostedService`. Esto asegura que los datos estén disponibles antes de que la aplicación comience a atender solicitudes.

- Las URL de las APIs externas se almacenan en el archivo de configuración `appsettings.json`. Esto permite una fácil configuración y modificaciones sin necesidad de cambiar el código fuente.

## Configuración de la base de datos

Al iniciar la aplicación, se comprueba si la base de datos ya existe. Si no se encuentra la base de datos, se crea automáticamente junto con la inserción de todos los datos obtenidos de las APIs externas. Esto asegura que la base de datos esté correctamente configurada y poblada antes de que la aplicación comience a funcionar.

## Flujo de trabajo con Git

Durante el desarrollo de esta aplicación, se utilizó el flujo de trabajo Git Flow para gestionar las ramas y las versiones del código. Se siguieron los principios de Git Flow, como el uso de las ramas `develop` y `feature` para implementar nuevas funcionalidades, y la rama `master` para las versiones estables del código.


## Áreas de mejora

- En la implementación actual, se ha trabajado directamente con las entidades en lugar de utilizar DTOs y modelos. Si la aplicación crece en complejidad, sería recomendable implementar DTOs y modelos para mantener una separación clara entre la capa de presentación y el dominio.

- El segundo endpoint mencionado en el proyecto aún no ha sido completamente implementado y solo se ha desarrollado la lógica de negocio correspondiente. Se requerirá la implementación adicional para completar el endpoint.

- A medida que la aplicación crece, podría ser beneficioso considerar la implementación de un repositorio genérico para evitar la repetición de código en los repositorios concretos. Sin embargo, actualmente no se ha visto la necesidad de implementar esta abstracción.

- La relación con las tablas de la base de datos parece no estar funcionando correctamente, ya que los datos no se insertan al iniciar la aplicación. Será necesario revisar la configuración y las relaciones entre las entidades y las tablas para solucionar este problema.

## Próximos pasos


1. Completar la implementación del segundo endpoint según los requisitos especificados.

2. Revisar y corregir la configuración y las relaciones con las tablas de la base de datos para asegurar que los datos se inserten correctamente.

3. Si la aplicación sigue creciendo y se vuelven necesarios, considerar la implementación de DTOs, modelos y AutoMapper para mejorar la separación entre la capa de presentación y el dominio.

4. Implementar pruebas unitarias adicionales para garantizar la calidad y la robustez del código.

5. Considerar la implementación de un repositorio genérico si se observa una repetición significativa de código en los repositorios concretos.


## Pruebas unitarias

La aplicación incluye pruebas unitarias para asegurar la calidad del código y la funcionalidad correcta de los diferentes componentes. Estas pruebas se encuentran en el proyecto de pruebas unitarias.




