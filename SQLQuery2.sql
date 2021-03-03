--Create Database Remeras_DB

--go
--use  Remeras_DB
--go


create table TipoUsuario (
Id tinyint not null primary Key identity (1,1),
Nombre varchar(50) not Null
)
go
 

create table Usuarios (
Id bigint not null primary Key identity (1,1),
NombreUsuario varchar(100) not Null,
Contraseña varchar (15) not null,
IdTipoUsuario tinyint not null foreign key references TipoUsuario(Id),
Estado bit not null
)
go



create table Estados (
Id tinyint not null primary Key identity (1,1),
NombreEstado varchar(20) not Null
)
go

create table TipoPagos (
Id tinyint not null primary Key identity (1,1),
Nombre varchar(50) not Null
)
go


create table TipoProducto (
Id tinyint not null primary Key identity (1,1),
Nombre varchar(50) not Null
)
go

create table DatosPersonales (
IdUsuario bigint not null primary Key,
Nombre varchar(100) not Null,
Apellido varchar(100) not Null,
DNI varchar (10) not null,
FechaNac date not null,
Genero varchar (20) null,
Telefono varchar(20) not null,
CP int not null,
Direccion varchar(100) not null,
Ciudad varchar(100) not null,
Email varchar (100) not null
)
go
alter table DatosPersonales
add constraint FK_DatosPersonales_IdUsuario foreign key (IdUsuario)references Usuarios (Id)
go


create table Pedidos (
Id bigint not null primary Key identity (1,1),
IdUsuario bigint not null,
IdEstado tinyint not null,  
Fecha date not null,
Importe money not null,
IdTipoPago tinyint not null,
Agregado varchar (20) not null

)
go

ALTER TABLE Pedidos
ALTER COLUMN Agregado VARCHAR(20) NULL;

alter table Pedidos
add constraint FK_Pedidos_TipoPagos foreign key (IdTipoPago)  references TipoPagos (Id)
GO

alter table Pedidos
add constraint FK_Pedidos_Estado foreign key (IdEstado)  references Estados (Id)
GO

alter table Pedidos
add constraint FK_Pedidos_Usuarios foreign key (IdUsuario) references  Usuarios (Id)
go

create table Talles (
Id tinyint not null primary Key identity (1,1),
Nombre varchar(50) not Null
)
go

create table Color (
Id tinyint not null primary Key identity (1,1),
Nombre varchar(50) not Null
)
go




create table Producto (
Id bigint not null primary Key identity (1,1),
IdTipo tinyint not null foreign key references TipoProducto (Id),
Precio money not  null,
UrlImagen varchar (900),
Nombre varchar(50) not Null,

--Talle Varchar(20) not null,
IdTalle  tinyint not null,

--Color varchar (50),
IdColor  tinyint not null,

Descripcion varchar (100) not null,
Estado bit not null,

StockMinimo int not null,
StockActual int not null

)
go

alter table Producto
add constraint FK_Productos_Talles foreign key (IdTalle) references  Talles (Id)
go

alter table Producto
add constraint FK_Productos_Color foreign key (IdColor) references  Color(Id)
go

create table Detalle (
--Id bigint not null primary Key identity (1,1),
IdProducto bigint not null ,
IdPedido bigint not null foreign key references Pedidos (Id),
PrecioActual money not  null,
CantidadPedida tinyint not null,
UrlImagen varchar (900),
Nombre varchar(50) not Null,
primary key (IdProducto, IdPedido)
)
go

alter table Detalle
add constraint FK_Detalle_IdProducto foreign key (IdProducto) references Producto (Id)
go



--create table Pagos (
--IdPedido bigint not null primary Key,
--IdTipoPago tinyint not null,
--Monto money not  null
--)
--go

--alter table Pagos
--add constraint FK_Pagos_IdPedido foreign key (IdPedido) references Pedidos (Id)
--go

--alter table Pagos
--add constraint FK_Pagos_TipoPagos foreign key (IdTipoPago)  references TipoPagos (Id)
--go

--alter table Pagos
--drop constraint FK_Pagos_TipoPagos

--drop table Pagos

alter table Usuarios 
add constraint NombreUsuario  unique (NombreUsuario)
------------------------------
Alter table Color 
Add Estado bit not null default 1

Alter table Talles 
Add Estado bit not null default 1

Alter table TipoProducto
Add Estado bit not null default 1

Alter table TipoUsuario
Add Estado bit not null default 1

Alter table Estados
Add Estado bit not null default 1


ALTER TABLE Producto ADD CONSTRAINT DF_Constraint DEFAULT 1 FOR Estado;

ALTER TABLE Usuarios ADD CONSTRAINT df_restricc DEFAULT 2 FOR IdTipoUsuario

--que la columna de stock no sea negativa
--ALTER TABLE producto
--ADD CONSTRAINT chk_Stock
--  CHECK (stockactual>=0); -- esta es la condicion
  





