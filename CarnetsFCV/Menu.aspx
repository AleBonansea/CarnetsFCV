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
    
    <div class="row">
        <div class="col">
            <div style="Margin-top:8%; text-align:center" class="auto-style8">   
                <asp:Button ID="btnArbitros" OnClick="btnArbitros_Click" class="btnMenu" Text="Árbitros" runat="server" />
                <button ID="btnCarnet" runat="server"  type="button" class="btnMenu" data-bs-toggle="modal" data-bs-target="#ModalAgregar">Carnet</button>
                <%--<asp:Button ID="btnCarnet" OnClick="btnCarnet_Click" class="btnMenu" Text="Carnet" runat="server" />--%>
                <asp:Button ID="btnClubes" OnClick="btnClubes_Click" class="btnMenu" Text="Clubes" runat="server" />
                <asp:Button ID="btnEntrenadores" OnClick="btnEntrenadores_Click" class="btnMenu" Text="Entrenadores" runat="server" />
                <asp:Button ID="btnEquipos" OnClick="btnEquipos_Click" class="btnMenu" Text="Equipos" runat="server" />
                <asp:Button ID="btnJugadores" OnClick="btnJugadores_Click" class="btnMenu" Text="Jugadores" runat="server" />
                <asp:Button ID="btnHabilitaciones" OnClick="btnHabilitaciones_Click" class="btnMenu" Text="Habilitaciones" runat="server" />
                <asp:Button ID="btnAjustes" OnClick="btnAjustes_Click" class="btnMenu" Text="Ajustes" runat="server" />
            </div>
        </div>
    </div>
    
     <div class="row" >

            <div class="col">
                <asp:Button ID="btnCambioContraseña" OnClick="btnCambioContraseña_Click" class="btnCambioContraseña" arial-label="Close" Text="Modificar Contraseña" runat="server"/>
            </div>                

             <div class="col" style="text-align:right">
                <asp:Button ID="btnCerrarSesion" OnClick="btnCerrarSesion_Click" class="btnCerrar" arial-label="Close" Text="Cerrar Sesión" runat="server"/>                 
            </div>
    </div>

    <!-- Modal Roles -->
        <div class="modal fade" id="ModalAgregar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content" style="background-color:#CCCCCC">
              <div class="modal-header" style="background-color:#e44f1e;">
                <h1 class="modal-title fs-5" style="color:white" id="staticBackdropLabel">Seleccione Carnet</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body" style="align-items:center">
                  <asp:Button class="btnCancelar" ID="carnetArbitro" OnClick="carnetArbitro_Click" Text="Árbitro" Visible="false" runat="server" />
                  <asp:Button class="btnCancelar" ID="carnetEntrenador" OnClick="carnetEntrenador_Click" Text="Entrenador" Visible="false" runat="server" />
                  <asp:Button class="btnCancelar" ID="carnetJugador" OnClick="carnetJugador_Click" Visible="false" Text="Jugador" runat="server" />
              <div class="modal-footer">
                <button type="button" class="btnCancelar" data-bs-dismiss="modal">Cancelar</button>
              </div>
            </div>
          </div>
        </div>

</asp:Content>
