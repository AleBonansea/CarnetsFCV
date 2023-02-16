<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="CarnetsFCV.Ingreso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form action="/" method="post">
        <div>   
            <asp:Label Text="IdUsuario" runat="server" />
            <asp:Label Id="lblIdUsuario" runat="server" />
            <br />
            <asp:Label Text="Nombre Usuario" runat="server" />
            <asp:Label Id="lblNombreUsuario" runat="server" />
            <br />
            <asp:Label Text="Nro de Rol" runat="server" />
            <asp:Label Id="lblNrodeRol" runat="server" />
        </div>

    </form>

</asp:Content>
