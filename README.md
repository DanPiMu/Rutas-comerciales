Daniel Pilligua Murillo

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


