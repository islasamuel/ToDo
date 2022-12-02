# ToDo Blazor
App Blazor 
Pasos para la ejecución del proyecto

1.- En el proyecto SIslas.ToDo.App.Server, abrir el archivo appsettings.json y cambiar la cadena de conexión AppDB por la conexión local

![CadenaDeConexion](https://user-images.githubusercontent.com/20864100/205207014-b4308392-3bd6-472e-9aa1-8545e5c44668.png)

2.- En el proyecto SIslas.ToDo.App.Repository ejecutar el siguiente comando para la migración
> dotnet ef database update --startup-project ../Server

![UpdateBase](https://user-images.githubusercontent.com/20864100/205207065-3ce04436-2785-4f39-be69-ed700e691ec9.png)
