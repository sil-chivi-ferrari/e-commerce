
create PROCEDURE spAgregarCliente(

@NombreUsuario VARCHAR(100),
@Contraseña VARCHAR(15),
@IdTipoUsuario tinyint,
@Nombre VARCHAR (100),
@Apellido VARCHAR (100),
@DNI varchar (10),
@FechaNac date,
@Genero		VARCHAR (20),
@Telefono VARCHAR (20),
@CP int,
@Direccion VARCHAR (100),
@Ciudad VARCHAR (100),
@Email VARCHAR (100)

)
AS
BEGIN
BEGIN TRANSACTION
BEGIN TRY

-- Generamos el usuario
INSERT INTO Usuarios(NombreUsuario, Contraseña, IdTipoUsuario, Estado) VALUES (@NombreUsuario, @Contraseña, @IdTipoUsuario, 1)
-- Generamos la cuenta del usuario


DECLARE @IdUsuario BIGINT
SET @IdUsuario = @@IDENTITY

INSERT INTO DatosPersonales(IdUsuario, Nombre, Apellido, DNI, FechaNac, Genero, Telefono, CP, Direccion, Ciudad, Email) 
VALUES (@IdUsuario, @Nombre, @Apellido, @DNI, @FechaNac, @Genero, @Telefono, @CP,@Direccion,@Ciudad,@Email)

COMMIT TRANSACTION
END TRY
BEGIN CATCH
PRINT 'No se pudo llevar a cabo la transaccion'
ROLLBACK TRANSACTION
END CATCH 
END