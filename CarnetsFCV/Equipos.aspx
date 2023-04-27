<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="CarnetsFCV.Equipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 38px;
        }
        .auto-style3 {
            float: right;
            width: 556px;
            margin-left: 210px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

    <div>
        <div style="background-color:#e44f1e">
            <asp:Button CssClass="btnInicio" ID="btnInicio" OnClick="btnInicio_Click" Text="Inicio" runat="server" />
            
            <div style="text-align:right; background-color:#e44f1e" class="auto-style1">
                <div style="float:left; margin-left:5%" >   
                    <asp:Button CssClass="btnCRUD" Text="Añadir" runat="server" />
                    <asp:Button CssClass="btnCRUD" Text="Modificar" runat="server"/>
                    <asp:Button CssClass="btnCRUD" Text="Eliminar" runat="server"/>
                </div>
                <div style="background-color:#e44f1e" class="auto-style3">

                    <asp:TextBox CssClass="buscador" ID="txtBuscar" runat="server" />
                    <asp:ImageButton class="btnBuscar" ID="btnBuscar" OnClick="btnBuscar_Click" ImageUrl="Imagenes/Lupa.png" runat="server" Height="23px" Width="23px" />
                </div>
            </div>

            
        </div>

            <div class="divGrilla">

                <asp:GridView CssClass="grilla" ID="gvEquipos" runat="server" ShowHeaderWhenEmpty="True" Font-Names="Arial" Font-Size="12pt" GridLines="None">
                    <AlternatingRowStyle BackColor="#CCCCCC" BorderStyle="Solid" BorderWidth="3px" Font-Names="Arial" Font-Size="12pt" />
                    <EditRowStyle Font-Names="Arial" Font-Size="14pt" />
                    <HeaderStyle BackColor="#999999" Font-Bold="True" Font-Names="Arial" Font-Size="14pt" Font-Strikeout="False" VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#FFCC66" />
                </asp:GridView>
            </div>
    </div>
    <div style="text-align:right">
    <asp:Button ID="btnCerrarSesion" OnClick="btnCerrarSesion_Click" class="btnCerrar" arial-label="Close" Text="Cerrar Sesión" runat="server"/>
    </div>

</asp:Content>
