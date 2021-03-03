create procedure Sp_Busqueda (
@Busqueda varchar(20),
@Color tinyint,
@Talle tinyint,
@Tipo  tinyint
)
as
begin

select * from Producto where (IdTalle = @Talle or @Talle is null) and
(IdColor = @Color or @Color is null) and
(IdTipo = @Tipo  or @Tipo is null ) and
 (Nombre LIKE '%' + @Busqueda + '%' or  Descripcion LIKE '%' + @Busqueda + '%' or @Busqueda  is null)



end
