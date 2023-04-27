<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Jugadores.aspx.cs" Inherits="CarnetsFCV.Jugadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div>
        <div style="background-color:#e44f1e">
            <br />
            <asp:Button ID="btnInicio" OnClick="btnInicio_Click" Text="Inicio" runat="server" /><br /><br />
            
            <asp:Label Text="Club: " runat="server" />
            <asp:DropDownList ID="cmbClub" runat="server" OnSelectedIndexChanged="cmbClub_SelectedIndexChanged1" AutoPostBack="True">
                <asp:ListItem Text="text1" />
                <asp:ListItem Text="text2" />
            </asp:DropDownList>

            <asp:Label Text="Rama: " runat="server" />
            <asp:DropDownList ID="cmbRama" runat="server">
                <asp:ListItem Text="M" Value="1" />
                <asp:ListItem Text="F" Value="2" />
            </asp:DropDownList>


            <asp:Label Text="Division: " runat="server" />
            <asp:DropDownList ID="cmbDiv" runat="server" Enabled="False">
                <asp:ListItem Text="text1" />
                <asp:ListItem Text="text2" />
            </asp:DropDownList>

             <asp:Label Text="Equipo: " runat="server" />
            <asp:DropDownList ID="cmbEquipo" runat="server" Enabled="False">
                <asp:ListItem Text="text1" />
                <asp:ListItem Text="text2" />
            </asp:DropDownList>

            <asp:Button ID="btnBuscar" OnClick="btnBuscar_Click" Text="Buscar" runat="server" />
            <br />
            <br />

        </div>

            <div class="divGrilla">

                <asp:GridView CssClass="grilla" ID="gvJugadores" runat="server" ShowHeaderWhenEmpty="True" Font-Names="Arial" Font-Size="12pt" GridLines="None">
                    
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
