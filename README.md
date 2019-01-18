# Selenium
Ejemplos Selenium &amp; Phanthomjs

## Inicializar proyecto 

### 1-Crear directorio y clonar proyecto con git 
    
#### 1.1-Con Visual Studio 

     1.1.1 Ir a Menú Compilar->Compilar Solucion
     1.1.2 En la consola digitar Update-Package 
     1.1.3 Mas documentación en https://docs.microsoft.com/en-us/nuget/consume-packages/reinstalling-and-updating-packages
     1.1.4 Ir a Menú Proyecto->Agregar Nuevo Elemento->Elementos de Visual C#->Archivo de configuracion de aplicaciones
     1.1.4 Nombrar el archivo del punto anterior como "ConnectionString.config" y guardar.
     1.1.5 Con visual studio, desde el explorador de soluciones, Abrir archivo "ConnectionString.config" (doble click).
     1.1.6 Agregar entre los tag <configuration></configuration>, una conexion a base de datos valida. 
     1.1.7 Mas documentación en https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files
     1.1.8 Ejemplo del punto 1.1.6 
           <add name="con" connectionString="Data Source=localhost;Initial Catalog=mydatabase;User ID=myuser;Password=mypass" providerName="System.Data.SqlClient" />
     
      




