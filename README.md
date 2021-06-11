WeatherWeb 
Aplicación web que realiza consultas de datos meteorológicos en la API Weatherstack que muestra el resultado y conserva el historial de consultas en un backend ASP .NET 4.5 con una base de datos SQL Server  
•	Tecnologías 
•	ASP .NET 4.5 
•	Entity Framework Core 
•	Swagger 
•	SQL Server 
•	Axios 
•	Boostrap 
•	Azure 
 Generé la base de datos a partir de la migración presente en el directorio MostraClima.API con el siguiente comando actualización de: 
dotnet ef database update  
Abra la solución MostraClima.API.sln y ejecute el servidor IIS Express Abra el archivo index.html presente en la carpeta MostraClima.Web  Vista previa en vivo Se implementó una versión back-end en Azure Show Weather API y una versión front-end en Github Pages Show Weather Web, ambas completamente funcional y conectada 
 ATENCIÓN: Para que la página funcione correctamente es necesario habilitar el contenido mixto (HTTP y HTTPS) dada una limitación del plan API gratuito Weatherstack.
