# webAppWayni

Se creo el proyecto “WebAppWayni” el cual contiene la siguiente estructura:
- WebApiWayni: contiene el API rest en el cual se encuentran todos los métodos para consultar, agregar, editar y eliminar usuarios de la base de datos.
- WebAppWayni: contiene la aplicación web MVC que consume el API rest y presenta las vistas para ejecutar los métodos de listar, crear, editar y eliminar registros de usuarios.

Al ejecutar la aplicación, se debe ingresar al menú u opción “Usuario”.
- Una vez se da clic, se presenta el listado de registros y las distintas opciones disponibles, con sus respectivas validaciones como, no venir los campos vacíos o repetir el DNI.
- La aplicación permite crear nuevos usuarios, editar usuarios y eliminar usuarios.

**Configuración del Proyecto:**

Una ves descargado el proyecto, se deben realizar los siguientes pasos:

1. Clona el repositorio.
2. Abrir el archivo “WayniDB.sql” que se encuentra en el proyecto “WebApiWayni”, este archivo contiene el script para la creación de la base de datos de SQL Server “wayniDB”.
3. Buscar el archivo “appsettings.json” en el proyecto “WebApiWayni” y modificar la cadena de conexión o item “WayniDB” a la nueva conexión de base de datos.
4. Buscar el archivo “appsettings.json” en el proyecto “WebAppWayni” y modificar el item “ServiceUrl” con la url donde se ejecute el servicio API rest “WebApiWayni”, de igual forma modificar el item “UsuarioServiceUrl” con la url respectiva del servicio.
