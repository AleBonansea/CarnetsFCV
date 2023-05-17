<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Jugadores.aspx.cs" Inherits="CarnetsFCV.Jugadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div>
        <div style="background-color:#e44f1e">
            <br />
            <asp:Button CssClass="btnInicio" ID="btnInicio" OnClick="btnInicio_Click" Text="Inicio" runat="server" /><br /><br />
            
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

            <div style="text-align:right; background-color:#e44f1e" class="auto-style1">
                <div style="background-color:#e44f1e" class="auto-style3">

                    <asp:TextBox CssClass="buscador" ID="txtBuscar" runat="server" />
                    <asp:ImageButton class="btnBuscar" ID="ImageButton1" OnClick="btnBuscar_Click" ImageUrl="Imagenes/Lupa.png" runat="server" Height="23px" Width="23px" />
                </div>
                <!-- Button trigger modal -->
                <div style="float:left; margin-left:5%" >   
                    <button type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalAgregar">Agregar</button>
                    <button type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalModificar">Agregar</button>
                    <button type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalEliminar">Agregar</button>
                </div>
            </div>
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
    <!-- Modal -->
        <div class="modal fade" id="ModalAgregar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
              <div class="modal-header">
                <h1 class="modal-title fs-5" id="staticBackdropLabel">Agregar Jugador</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body">
                  <asp:Label Text="Club" runat="server" />
                  <asp:TextBox ID="Club" Style="width:35%" class="form-control" type="text" placeholder="Default input" aria-label="default input example" runat="server" />
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                <button type="button" class="btn btn-primary">Guardar</button>
              </div>
            </div>
          </div>
        </div>
    <div style="text-align:right">
    <asp:Button ID="btnCerrarSesion" OnClick="btnCerrarSesion_Click" class="btnCerrar" arial-label="Close" Text="Cerrar Sesión" runat="server"/>
    </div>
</asp:Content>
