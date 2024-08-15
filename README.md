# Logs - Aplicación de Gestión de Eventos

## Descripción del Proyecto

Logs es una aplicación de gestión de eventos diseñada para facilitar el registro, consulta y filtrado de eventos en una base de datos SQL Server. Desarrollada utilizando ASP.NET Core MVC y Entity Framework Core, esta aplicación permite a los usuarios registrar eventos manualmente a través de un formulario intuitivo o a través de una API REST. Además, ofrece la capacidad de consultar los eventos registrados, con opciones de filtrado por tipo de evento y rango de fechas.

## Requisitos Previos

- **.NET 6 SDK** o superior
- **SQL Server** (local o remoto)
- **Visual Studio 2022** o superior (opcional pero recomendado)

## Configuración de la Base de Datos

### 1. Configurar la Cadena de Conexión

1. Abre el archivo `appsettings.json` en la raíz del proyecto.
2. Modifica la cadena de conexión `DefaultConnection` para que apunte a tu instancia de SQL Server.

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=TU_SERVIDOR_SQL;Database=Registration;Trusted_Connection=True;"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "AllowedHosts": "*"
   }

  Reemplaza TU_SERVIDOR_SQL con el nombre de tu servidor SQL Server.
  Asegúrate de que el nombre de la base de datos (Registration) sea el que deseas utilizar.

 ### 2. Crear la base de datos

 1. Crear la base de datos utilizando Entity Framework Core
    Abre una terminal en el directorio raíz del proyecto y ejecuta los siguientes comandos para aplicar las migraciones y crear la base de datos:

       COMANDOS
    -- dotnet ef migrations add InitialCreate
    -- dotnet ef database update

2. Si prefieres, crear la base de datos manualmente:
   - Abre SQL Server Management Studio (SSMS).
   - Conéctate a tu servidor SQL Server.
   - Crea una nueva base de datos llamada Registration.
   - Luego, ejecuta la aplicación para que Entity Framework Core cree las tablas automáticamente cuando se acceda por primera vez.
  
### 3. Configuración del entorno

1. Clonar el repositorio:

     COMANDOS
  -- git clone https://github.com/tu-repositorio/logs.git
  -- cd logs

2. Aplicar las migraciones a la base de datos (si no lo has hecho en el paso anterior):

      COMANDOS
   -- dotnet ef database update


### 4. Ejecucion de la aplicación 

1. Compilar y ejecutar la aplicación:
   En la terminal, dentro del directorio del proyecto, ejecuta:

      COMANDO
   -- dotnet run

   O, si estás utilizando Visual Studio, simplemente presiona F5 o haz clic en Run.


### Caracteristicas principales

1. Registro de Eventos: Utiliza el formulario disponible en https://localhost:7061/CreateEvent para registrar nuevos eventos en la base de datos.
2. Consulta de Eventos: Visita https://localhost:7061/EventListModel para ver todos los eventos registrados. Puedes filtrar los resultados por tipo de evento y rango de fechas.
3. API REST: La aplicación también expone endpoints API para registrar y consultar eventos, los cuales puedes probar usando Swagger en https://localhost:7061/swagger/.

Contacto
Si tienes alguna pregunta o necesitas soporte adicional, puedes contactarme en cresrugi@gmail.com.










