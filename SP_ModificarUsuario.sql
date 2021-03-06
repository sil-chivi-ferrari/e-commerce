

ALTER PROCEDURE SP_ModificarUsuario(

@Id bigint,
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

Update Usuarios set NombreUsuario =@NombreUsuario, Contraseña =@Contraseña,  IdTipoUsuario =@IdTipoUsuario, Estado =1 where Id = @Id



DECLARE @IdUsuario BIGINT
SET @IdUsuario = @@IDENTITY

Update DatosPersonales set IdUsuario =@IdUsuario, Nombre = @Nombre, Apellido=@Apellido, DNI=@DNI, FechaNac=@FechaNac, Genero=@Genero, Telefono=@Telefono, CP=@CP, Direccion=@Direccion, Ciudad=@Ciudad, Email=@Email where IdUsuario = @IdUsuario


COMMIT TRANSACTION
END TRY
BEGIN CATCH
PRINT 'No se pudo llevar a cabo la transaccion'
ROLLBACK TRANSACTION
END CATCH 
END