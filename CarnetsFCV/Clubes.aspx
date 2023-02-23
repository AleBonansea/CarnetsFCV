<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Clubes.aspx.cs" Inherits="CarnetsFCV.Clubes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    
    <div>
        <div style="background-color:#e44f1e">
            <br />
            <asp:Button ID="btnInicio" OnClick="btnInicio_Click" Text="Inicio" runat="server" /><br /><br />
            
        </div>

            <div class="divGrilla">

                <asp:GridView CssClass="grilla" ID="gvJugadores" runat="server" ShowHeaderWhenEmpty="True" Font-Names="Arial" Font-Size="12pt" GridLines="None" DataSourceID="llenarGvClubes">
                    
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
