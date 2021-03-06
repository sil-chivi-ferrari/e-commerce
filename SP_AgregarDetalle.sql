
create procedure SP_AgregarDetalle (
@idPedido bigint,
@idProducto bigint,
@CantidadPedida tinyint, 
@UrlImagen varchar (900),
@Nombre varchar (50),
@PrecioActual money 
)
as 
begin --arranca la wea

begin try -- arranca el try
	begin transaction 
	insert into Detalle (IdPedido, IdProducto, CantidadPedida, UrlImagen, Nombre, PrecioActual)
	values
	(@idPedido,@idProducto,@CantidadPedida,@UrlImagen,@Nombre,@PrecioActual)
	update Producto set StockActual = StockActual-@CantidadPedida  
	where id= @idProducto
	IF @@ROWCOUNT  = 0
	BEGIN RAISERROR('No se pudo guardar el detalle',16,1)
	
	END
	
	Commit transaction
end try--termina el try

begin catch--arranca el catch

raiserror('No se pudo guardar el detalle', 16,1)

end catch--termina el catch

end --termina el P_A