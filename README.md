# ApiTest

Pasos para el funcionamiento del aplicativo

--Dentro de la solución se encuentra una carpeta llamada "UtilidadesDelAplicativo" la cual contiene el archivo "ApiTest_Script" y "Utilidades" la cual explica los mismos pasos que se describen aquí.
--Ejecutar el script "ApiTest_Script" para crear la base de datos llamada ApiTest, 
si ya cuenta con la base de datos entonces debe adicionar 2 campos a la tabla owner
ALTER TABLE [Owner]
	ADD
	[Email] [nvarchar](255) NULL,
	[Password] [nvarchar](max) NULL

--Abrir el proyecto ApiTest
--Posteriormente en la solucion buscar el archivo "appsettings.json" y cambiar el apuntamiento de la cadena de conexion si utiliza credenciales o si cambio el nombre de la base de datos
--Ejecutar el proyecto ApiTest para que se publique en el IIS  la solcion y quede accesible para que sea invocada por el proyecto de Angular


--Para el Proyecto de Angular
--Verifique el archivo "api.service.ts" en la variable "apiEndPoint" la url debe ser la misma que esta publicada para el ApiRest, si es necesario modifique el puerto donde se publicó
--Ejecute la aplicación
--Para crear un usuario debe Registrarse primero, dento del menu se encuentra la opción "Register"
--Posteriormente ingresar al Login con el email y pasword que ingresó al momento de registrarse
--Estará visible una nueva opción en el menu "Properties" la cual le permitirá visualizar las propiedades creadas de usuario, crearlas y modificarlas segun sean sus necesidades




 
 
