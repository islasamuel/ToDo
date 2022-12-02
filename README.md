# ToDo
App Blazor 
Pasos para la ejecución del
1.- En el proyecto SIslas.ToDo.App.Server, abrir el archivo appsettings.json y cambiar la cadena de conexión AppDB por la conexión local

2.- En el proyecto SIslas.ToDo.App.Repository ejecutar el siguiente comando para la migración
> dotnet ef database update --startup-project ../Server

> dotnet ef migrations add InitialCreate --startup-project ../Server

