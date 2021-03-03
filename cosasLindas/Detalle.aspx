<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="cosasLindas.Detalle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-image: url('https://images.unsplash.com/photo-1560780552-ba54683cb263?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80'); background-size: cover; ">
    <form id="form1" runat="server">
        <div>
             <div class="card" style="width: 18rem;">
                    <img src="<%=producto.UrlImagen %>" class="card-img-top" width="600px" alt="..."/>
                    <div class="card-body">
                        <h5 class="card-title"><%=producto.Nombre %></h5>
                        <h5 class="card-title"><%=producto.Descripcion  %></h5>
                        <h5 class="card-title"><%=producto.Precio  %></h5>
                        <h5 class="card-title"><%=producto.Talle  %></h5>
                         <h5 class="card-title"><%=producto.Color  %></h5>
                         <h5 class="card-title"><%=producto.tipoProducto.Nombre  %></h5>
                    
                        <a href="Default.aspx" class="btn btn-primary">Volver</a>
                        <a href="Carrito.aspx?idArticulo=<%=producto.Id.ToString()%>" class="btn btn-primary">Agregar</a>

                    </div>
                </div>

        </div>
    </form>
</body>
</html>
