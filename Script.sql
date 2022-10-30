CREATE DATABASE MVC

IF OBJECT_ID('[dbo].[REGISTROS]') IS NOT NULL  DROP TABLE [dbo].[REGISTROS]  
 GO
CREATE TABLE [dbo].[REGISTROS]
(
    [Id_Usuario] INT IDENTITY(1,1) NOT NULL,
    [Nombre] VARCHAR(50) NULL,
    [Correo] VARCHAR(100) NULL,
    [Edad] INT NULL,
    [Usuario] VARCHAR(50) NULL,
    [Clave] VARCHAR(50) NULL,
    CONSTRAINT   [PK__REGISTRO__63C76BE24AC42024]  PRIMARY KEY CLUSTERED([Id_Usuario] asc)
)

IF OBJECT_ID('[dbo].[sp_registrar]') IS NOT NULL  DROP  PROCEDURE [dbo].[sp_registrar]  
GO
CREATE PROCEDURE sp_registrar
    @Nombre varchar(50),
    @Correo varchar(100),
    @Edad int,
    @Usuario varchar(50),
    @Clave varchar(50)
as
BEGIN
    INSERT INTO REGISTROS
    VALUES(@Nombre, @Correo, @Edad, @Usuario, @Clave)
end
GO

IF OBJECT_ID('[dbo].[sp_login]') IS NOT NULL  DROP  PROCEDURE [dbo].[sp_login]  
  GO
CREATE PROCEDURE sp_login
    @Usuario varchar(50),
    @Clave varchar(50)
as
BEGIN
    SELECT *
    FROM REGISTROS
    WHERE Usuario=@Usuario and Clave=@Clave
end
  GO