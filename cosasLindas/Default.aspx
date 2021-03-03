<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="cosasLindas._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">   
        <asp:TextBox  ID="txtBuscar" runat="server" />  
    
        <asp:Button ID="btnBuscar" OnClick="btnBuscar_Click" Text="Buscalo"  runat="server" />
       
    </div>
    <%if (Session["ListaBuscada"] == null)
        {%>

    <div class="row">

        <%foreach (var item in ListaProductos)
            {%>

      <div class="col-lg-4 d-flex align-items-stretch">
       <%--<div class="col-md-4">--%>
                <div class="card" style="width: 18rem; ">
                    <img src="<%=item.UrlImagen %>" class="card-img-top" style="width:200px;" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%=item.Nombre %></h5>
                        <h1>hola</h1>
                       <%-- <h5 class="card-title"><%=item.Precio %></h5>--%>
                        <a href="Detalle.aspx?idArticulo=<%=item.Id.ToString()%>" class="btn btn-primary">Ver detalle</a>
                        <a href="Carrito.aspx?idArticulo=<%=item.Id.ToString()%>" class="btn btn-primary">Carrito</a>

                    </div>
                </div>
            </div>


            <% }
                }
                else
                {
                %>

        <div class="row">

        <%foreach (var item in (List<Dominio.Producto>)Session["ListaBuscada"])
            {%>

      
       <div class="col-md-4">
                <div class="card" style="width: 18rem;">
                    <img src="<%=item.UrlImagen %>" class="card-img-top" width="200px" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%=item.Precio %></h5>
                       <%-- <h5 class="card-title"><%=item.Precio %></h5>--%>
                        <a href="Detalle.aspx?idArticulo=<%=item.Id.ToString()%>" class="btn btn-primary">Ver detalle</a>
                        <a href="Carrito.aspx?idArticulo=<%=item.Id.ToString()%>" class="btn btn-primary">Carrito</a>

                    </div>
                </div>
            </div>


            <% }

        } %>
            
        </div>
</asp:Content>
