<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioABM.aspx.cs" Inherits="cosasLindas.FormularioABM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">   
            <div class="row">
            <div class="col">

         <table class="table">
              <tr>
               
                   <td><strong> Imagen: </strong></td>     
                  <td><strong>Nombre: </strong></td>
                        <td><strong>Id:</strong> </td>
                        <td><strong>Precio: </strong></td>
                  <td><strong>Descripción: </strong></td>
                  <td><strong>Color: </strong></td>
                  <td><strong>Talle: </strong> </td>
                   <td><strong>IdTipo:</strong> </td>
                        <td><strong>Acción:</strong> </td>
                    </tr>

        <%foreach (var item in ListaOriginal)
            {%>
        <tr>
            
            <td><%=item.Nombre %></td>
            <td><%=item.Id%></td>
            <td><%=item.Precio%></td>
            <td><%=item.Descripcion%></td>
            <td><%=item.Color%></td>
            <td><%=item.Talle%></td>
            <td><%=item.IdTipo%></td>
            <td><img src="<%=item.UrlImagen %>" class="card-img-top" style="width:10%;" alt="..."/></td>
            
             <td> <a href="FormularioRealABM.aspx" class="btn btn-primary">Agregar</a></td>
             <td> <a href="FormularioRealABM.aspx?idArticulo=<%=item.Id.ToString()%>" class="btn btn-danger">Modificar</a></td>
        </tr>
            
     

            <% } %>
             </table>
         <a href="Default.aspx" class="btn btn-primary">Volver</a>
               
                </div>
                </div>
        </div>

    </form>
</body>
</html>
