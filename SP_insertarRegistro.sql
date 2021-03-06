

create  PROCEDURE [sp_InsertarRegistro(

@IdTipo tinyint,
@Precio decimal(18,2),
@UrlImagen varchar(900),
@Nombre varchar (50),
@IdTalle tinyint,
@Descripcion varchar (100),

@IdColor  tinyint,
@StockMinimo int,
@StockActual int



)
AS
BEGIN
BEGIN TRANSACTION
BEGIN TRY
  INSERT INTO Producto(IdTipo,Precio,UrlImagen,Nombre,IdTalle,Descripcion,Estado,IdColor,StockMinimo,StockActual) 
  VALUES(@IdTipo,@Precio,@UrlImagen,@Nombre,@IdTalle,@Descripcion,1,@IdColor,@StockMinimo,@StockActual)



 COMMIT TRANSACTION
END TRY
BEGIN CATCH
PRINT 'No se pudo llevar a cabo la transaccion'
ROLLBACK TRANSACTION
END CATCH 
END