<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioRealABM.aspx.cs" Inherits="cosasLindas.FormularioRealABM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous" />
    <%--<link rel="stylesheet" href="../css/FormAlta.css" />--%>
</head>
<body style="background-image: url('https://previews.123rf.com/images/viaire/viaire1706/viaire170600008/80959550-patr%C3%B3n-sin-fisuras-old-school-tattoo-style-con-elementos-rosa-coraz%C3%B3n-labios-cr%C3%A1neo-fuego-rayo-cristal-ancla.jpg'); background-size: cover; ">
    
   <%-- <script>    
        function Validar() {
            var Nombre = document.getElementById("<% =txtNombre.ClientID%>").Validar;
            if (Nombre == "") {
                alert("Completa el campo che");
                return false;
            }
            return true;
        }
    </script>--%>
    <div class="container" style="background-color:dimgray;width:45%; height:40%">
      
    <form id="form1" runat="server">
        <div>
             <div class="container" style="width:10%; height:40%; margin-top:40px;" >


            <div>
                <asp:Label Text="Nombre" ID="lblNombre" runat="server" />
                <asp:TextBox ID="txtNombre" runat="server" />
            </div>
        
            <div>
                <asp:label text="idtipo" id="lblidtipo" runat="server" />
                <asp:textbox id="txtidtipo" runat="server" />
            </div>
                <%-- <div class="form-group">
                      <asp:Label Text="IdTipo" ID="lblIdTipo" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlTipo" CssClass="form-control">
                       
                     </asp:DropDownList>
                 </div>--%>


            <div>
                <asp:Label Text="Precio" ID="lblPrecio" runat="server" />
                <asp:TextBox ID="txtPrecio" runat="server" />
            </div>
            <div>
                <asp:Label Text="Color" ID="lblColor" runat="server" />
                <asp:TextBox ID="txtColor" runat="server" />
            </div>
            <div>
                <asp:Label Text="Descripcion" ID="lblDescripcion" runat="server" />
                <asp:TextBox ID="txtDescripcion" runat="server" />
            </div>
            <div>
                <asp:Label Text="Imagen" ID="lblImagen" runat="server" />
                <asp:TextBox ID="txtImagen" runat="server" />
            </div>
            <div>
                <asp:Label Text="Talle" ID="lblTalle" runat="server" />
                <asp:TextBox ID="txtTalle" runat="server" />

            </div>
                 <div>
                <asp:Label Text="Estado" ID="lblEstado" runat="server" />
                <asp:TextBox ID="txtEstado" runat="server" />

            </div>
                 <div>
                <asp:Label Text="Stock Minimo" ID="lblStockMinimo"  runat="server" />
                <asp:TextBox ID="txtStockMini" runat="server" />

            </div>
                   <div>
                <asp:Label Text="Stock Actual" ID="lblStockActual" runat="server" />
                <asp:TextBox ID="txtStockActual" runat="server" />

            </div>
                 <asp:Button Text="Guardar" id="btnGuardar" OnClick="btnGuardar_Click" runat="server" />
                 <%--OnClientClick="return Validar()"--%>
        </div>
        </div>
    </form>
        </div>
</body>
</html>
