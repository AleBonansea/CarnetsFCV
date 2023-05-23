<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Jugadores.aspx.cs" Inherits="CarnetsFCV.Jugadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">  
        <div class="col-sm-1" style="margin-left:2%">
            <asp:Button CssClass="btnInicio" ID="btnInicio" OnClick="btnInicio_Click" Text="Inicio" runat="server" />
        </div>  
    </div>
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

         
            <div class="row" style="margin-left:5%">
                <!-- Button trigger modal -->
                <div class="col-xl-1" >   
                    <button  type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalAgregar">Agregar</button>
                </div>
                <div class="col-xl-1"">
                    <button  type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalModificar">Modificar</button>
                </div>
                <div class="col-xl-1">
                    <button  type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalEliminar">Eliminar</button>
                </div>
                <div class="col-xl-9" style="display: flex; justify-content: right; align-items: center;">
                    <asp:TextBox CssClass="buscador" ID="TextBox3" runat="server" />
                    <asp:ImageButton  class="btnBuscar" ID="ImageButton2" OnClick="btnBuscar_Click" ImageUrl="Imagenes/Lupa.png" runat="server" />
                </div>
            

            </div>
                <div class="divGrilla" style="overflow:auto" >

                    <asp:GridView CssClass="grilla"  ID="gvJugadores" runat="server" ShowHeaderWhenEmpty="True" Font-Names="Arial"  GridLines="None">
                    
                        <AlternatingRowStyle CssClass="grilla" BackColor="#CCCCCC" BorderStyle="Solid" BorderWidth="3px" Font-Names="Arial"/>
                        <EditRowStyle Font-Names="Arial" Font-Size="14pt" />
                        <HeaderStyle CssClass="grilla" BackColor="#e44f1e" Font-Bold="True" Font-Names="Arial"  Font-Strikeout="False" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#FFA420" />
                    </asp:GridView>
                </div>
   
    <div style="text-align:right">
    <asp:Button ID="btnCerrarSesion" OnClick="btnCerrarSesion_Click" class="btnCerrar" arial-label="Close" Text="Cerrar Sesión" runat="server"/>
    </div>

      <!-- Modal Agregar -->
        <div class="modal fade" id="ModalAgregar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content" style="background-color:#CCCCCC">
              <div class="modal-header" style="background-color:#e44f1e;">
                <h1 class="modal-title fs-5" style="color:white" id="staticBackdropLabel">Agregar Club</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body" style="display:flex; align-items:center">
                  <asp:Label Text="Club:" runat="server" />
                  <asp:TextBox BorderColor="#e44f1e" ID="txtClub" Style="width:35%; margin-left:2px;" class="form-control" type="text" placeholder="Default input" aria-label="default input example" runat="server" />
              </div>
              <div class="modal-footer">
                <button type="button" class="btnCancelar" data-bs-dismiss="modal">Cancelar</button>
                <button type="button" class="btnGuardar">Guardar</button>
              </div>
            </div>
          </div>
        </div>

    <!-- Modal Modificar -->
        <div class="modal fade" id="ModalModificar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
              <div class="modal-header">
                <h1 class="modal-title fs-5" id="staticBackdropLabel">Modificar Club</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body">
                  <asp:Label Text="Club" runat="server" />
                  <asp:TextBox ID="TextBox1" Style="width:35%" class="form-control" type="text" placeholder="Default input" aria-label="default input example" runat="server" />
              </div>
              <div class="modal-footer">
                <button type="button" class="btnCancelar"  data-bs-dismiss="modal">Cancelar</button>
                <button type="button" class="btnGuardar" >Modificar</button>
              </div>
            </div>
          </div>
        </div>

    <!-- Modal Eliminar -->
        <div class="modal fade" id="ModalEliminar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
              <div class="modal-header">
                <h1 class="modal-title fs-5" id="staticBackdropLabel">Eliminar Club</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body">
                  <asp:Label Text="Club" runat="server" />
                  <asp:TextBox ID="TextBox2" Style="width:35%" class="form-control" type="text" placeholder="Default input" aria-label="default input example" runat="server" />
              </div>
              <div class="modal-footer">
                <button type="button" class="btnCancelar" data-bs-dismiss="modal">Cancelar</button>
                <button type="button" class="btnGuardar">Eliminar</button>
              </div>
            </div>
          </div>
        </div>
</asp:Content>
