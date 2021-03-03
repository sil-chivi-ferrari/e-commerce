 set dateformat dmy

 insert into Estados(NombreEstado ) values ('Recibido' )
 insert into Estados(NombreEstado ) values ('En Preparacion' )
 insert into Estados(NombreEstado ) values ('En Camino' )
 

 insert into TipoUsuario (Nombre ) values ('Administrador' )
 insert into TipoUsuario (Nombre ) values ('Cliente' )

 insert into TipoPagos(Nombre ) values ('MercadoLibre' )
 
 insert into tipoProducto(Nombre ) values ('Escote V' )
 insert into tipoProducto(Nombre ) values ('Americana' )

    insert into Talles(Nombre,Estado ) values ('small' ,1 )
    insert into Talles(Nombre,Estado ) values ('medium',1 )
    insert into Talles(Nombre,Estado ) values ('extraLarge' ,1 )

	select * from Color

	insert into Talles(Nombre,Estado ) values ('Blanca' ,1 )
    insert into Talles(Nombre,Estado ) values ('Negra',1 )
    insert into Talles(Nombre,Estado ) values ('Azul' ,1 )
 
 insert into Producto (idTipo, Precio, Nombre, IdTalle, Descripcion, IdColor, UrlImagen, Estado, StockMinimo, StockActual) values('2','500','Remera 3', '1', 'Remerita divertidita', '1','https://risataweb.com.ar/wp-content/uploads/2018/07/remera-gaa.jpg', 1,50,100 )								
 insert into Producto (idTipo, Precio, Nombre, IdTalle, Descripcion, IdColor, UrlImagen, Estado, StockMinimo, StockActual) values('1','600','REMERA 2', '2', 'remera 2','2','https://sonder.com.ar/wp-content/uploads/2020/01/3441H86_a.jpg', 1,20,50)											   
 insert into Producto (idTipo, Precio, Nombre, IdTalle, Descripcion, IdColor, UrlImagen, Estado, StockMinimo, StockActual) values('1','800','REMERA 4', '1', 'Algodon peinado','2','https://horachy.com/wp-content/uploads/2019/11/remera-fear-negra.jpg', 1,15,100)
 insert into Producto (idTipo, Precio, Nombre, IdTalle, Descripcion, IdColor, UrlImagen, Estado, StockMinimo, StockActual) values('1','800','REMERA old school', '1', 'Polyester','1','https://d26lpennugtm8s.cloudfront.net/stores/001/162/505/products/remera-liza11-90a4e29a9fcdc7261215914147152652-1024-1024.png', 1,20,100)											   
 insert into Producto (idTipo, Precio, Nombre, IdTalle, Descripcion, IdColor, UrlImagen, Estado, StockMinimo, StockActual) values('2','750','REMERA vintage', '2', 'Diseño de autor','1','https://negrooscuro.com/wp-content/uploads/2020/11/DSC_5904-scaled.jpg', 1,30,100)											   
 insert into Producto (idTipo, Precio, Nombre, IdTalle, Descripcion, IdColor, UrlImagen, Estado, StockMinimo, StockActual) values('2','950','REMERA ultra', 'XL', 'Strech','Roja','https://dafitistaticar-a.akamaihd.net/p/puma-3846-153873-1-product.jpg', 1,30,100)											   
 insert into Producto (idTipo, Precio, Nombre, IdTalle, Descripcion, IdColor, UrlImagen, Estado, StockMinimo, StockActual) values('1','750','REMERA fit', 'XXL', 'Remera deportiva','Verde','https://i.pinimg.com/originals/39/cd/24/39cd24ee1f4b39c50db1636724e0ff7c.jpg', 1,10,100)






insert into Usuarios (NombreUsuario, Contraseña, IdTipoUsuario, Estado) values('SoyAdmin','SoyAdmin',1, 1 )
insert into Usuarios (NombreUsuario, Contraseña, IdTipoUsuario, Estado) values('Cliente1','SyUser',2, 1 ) 


 
 insert into DatosPersonales (  IdUsuario, Nombre, Apellido, Email, DNI, FechaNac, Genero, Telefono,CP, Direccion, Ciudad) 
values (1,'Silvano','Lopez','ESTEMAIL@MAIL.Com','21539557','20-02-1970','masculino','1155998384','1617','Austria Sur 196','Troncos del talar')
insert into DatosPersonales (  IdUsuario, Nombre, Apellido, Email, DNI, FechaNac, Genero, Telefono,CP, Direccion, Ciudad) 
values (2,'Cristina','Gonzales','MailUser2@MAIL.Com','41578679','21-03-1984','femenino','1158858814','1617','Austria Sur 196','Troncos del talar')
 