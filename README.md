# ToDo
App Blazor 
Pasos para la ejecuci�n del
1.- En el proyecto SIslas.ToDo.App.Server, abrir el archivo appsettings.json y cambiar la cadena de conexi�n AppDB por la conexi�n local

2.- En el proyecto SIslas.ToDo.App.Repository ejecutar el siguiente comando para la migraci�n
> dotnet ef database update --startup-project ../Server

> dotnet ef migrations add InitialCreate --startup-project ../Server

