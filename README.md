# DoubleVPrueba
Mi Api rest FULL


Para el completo funcionamiento de la api realizar los siguientes pasos:
1- ejecutar este comando en la linea de power shield o cmd para la creacion de la base de datos en docker.
docker run --name sqlserver -p 1433:1433 -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Sql12345$' -d microsoft/mssql-server-windows-developer
2- Luego de que se cree el contenedor se procede a ejecutar la migracion de la base de datos generada mediante EF y la cual se ejecutara en el contenedor de SQL previamente creado, para ello ejecutar el siguiente comando en proyecto de Modelo en la consola de administrador de paquetes de nuget.
update-database -v.
3-ejecutar el proyecto desde visual studio.

