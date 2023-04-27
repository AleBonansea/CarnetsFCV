<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="CarnetsFCV.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
         .auto-style8 {
             width: 70%;
             height: 392px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    
    
    <div style="margin-top:8%; text-align:center" class="auto-style8">   
        <asp:Button ID="btnArbitros" class="btnMenu" Text="Árbitros" runat="server" />
        <asp:Button ID="btnCarnet" class="btnMenu" Text="Carnet" runat="server" />
        <asp:Button ID="btnClubes" class="btnMenu" Text="Clubes" runat="server" />
        <asp:Button ID="btnDelegados" class="btnMenu" Text="Delegados" runat="server" />
        <asp:Button ID="btnEntrenadores" class="btnMenu" Text="Entrenadores" runat="server" />
        <asp:Button ID="btnEquipos" class="btnMenu" Text="Equipos" runat="server" />
        <asp:Button ID="btnJugadores" OnClick="btnJugadores_Click" class="btnMenu" Text="Jugadores" runat="server" />

    </div>
    <div style="text-align:right">
    <asp:Button ID="btnCerrarSesion" OnClick="btnCerrarSesion_Click" class="btnCerrar" arial-label="Close" Text="Cerrar Sesión" runat="server"/>
    </div>
</asp:Content>
