
# SurisCodeTest

## Requisitos

- .NET 8 SDK
- Node.js (versión 14 o superior)
- SQL Server (o cualquier base de datos compatible con Entity Framework Core)

## Configuración del Proyecto

### 1. Clonar el Repositorio

git clone https://github.com/mpsuarez/SurisCodeTest.git

### 2. Configurar la Cadena de Conexión

Abre el archivo `appsettings.json` en el proyecto `SurisCodeTest.Api` y actualiza la cadena de conexión para que apunte a tu base de datos.

### 3. Ejecutar las Migraciones

Navega al directorio del proyecto `SurisCodeTest.Api` y ejecuta los siguientes comandos para aplicar las migraciones a la base de datos:

SurisCodeTest.Api dotnet ef database update

### 4. Ejecutar el Proyecto .NET

Asegúrate de estar en el directorio del proyecto `SurisCodeTest.Api` y ejecuta el siguiente comando para iniciar la API:

dotnet run

La API debería estar disponible en `https://localhost:5001` o `http://localhost:5000`.

## Ejecutar el Proyecto de React

### 1. Instalar Dependencias

Navega al directorio `web` y ejecuta el siguiente comando para instalar las dependencias del proyecto de React:

../web npm install


### 2. Ejecutar el Proyecto de React

Ejecuta el siguiente comando para iniciar el servidor de desarrollo de React:

npm start


La aplicación de React debería estar disponible en `http://localhost:3000`.

## Notas Adicionales

- Asegúrate de que el proyecto .NET y el proyecto de React estén ejecutándose simultáneamente para que la aplicación funcione correctamente.
- Si estás utilizando un entorno de producción, asegúrate de actualizar las configuraciones de conexión y otros parámetros según sea necesario.

## Contacto

Para cualquier pregunta o problema, por favor contacta a ing.psuarez@hotmail.com

