<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="cosasLindas.Carrito" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   
<%--    <h3>Compraste: </h3>
    <h3>Gastaste: </h3>--%>

    <asp:Label Text="text" runat="server" />
          
         <div class="row">

         <table class="table">
        <%foreach (var item in listaCarrito)
            {%>
        <tr>
            
              <td><img src="<%=item.UrlImagen %>" class="card-img-top" width="200px" alt="..."></td>
            <td><%=item.Nombre %></td>
             <td> <a href="Carrito.aspx?idArticulo=<%=item.Id.ToString()%>&idExtra=<%=1.ToString()%>" class="btn btn-danger">Eliminar</a></td>
        </tr>
            
      <tr>
          <td> <a href="EliminarCarrito.aspx?idArticulo=<%=item.Id.ToString()%>" class="btn btn-danger">Eliminaraww</a></td>
          
      </tr>

            <% } %>
             </table>
         <a href="Default.aspx" class="btn btn-primary">Volver</a>
        </div>

</asp:Content>