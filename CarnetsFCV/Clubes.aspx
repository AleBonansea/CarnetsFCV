<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Clubes.aspx.cs" Inherits="CarnetsFCV.Clubes" %>
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
        <div>
            <asp:Button CssClass="btnInicio" ID="btnInicio" OnClick="btnInicio_Click" Text="Inicio" runat="server" />
            
            <div style="text-align:right;" class="auto-style1">
                <!-- Button trigger modal -->
                <div style="float:left; margin-left:5%" >   
                    <button type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalAgregar">Agregar</button>
                    <button type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalModificar">Modificar</button>
                    <button type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalEliminar">Eliminar</button>
                </div>
                <div class="auto-style3">

                    <asp:TextBox CssClass="buscador" ID="txtBuscar" runat="server" />
                    <asp:ImageButton class="btnBuscar" ID="btnBuscar" OnClick="btnBuscar_Click" ImageUrl="Imagenes/Lupa.png" runat="server" Height="23px" Width="23px" />
                </div>
            </div>

            
        </div>

            <div class="divGrilla">

                <asp:GridView CssClass="grilla" ID="gvClubes" runat="server" ShowHeaderWhenEmpty="True" Font-Names="Arial" Font-Size="12pt" GridLines="None">
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

    <!-- Modal Agregar -->
        <div class="modal fade" id="ModalAgregar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
              <div class="modal-header">
                <h1 class="modal-title fs-5" id="staticBackdropLabel">Agregar Club</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body">
                  <asp:Label Text="Club" runat="server" />
                  <asp:TextBox ID="Club" Style="width:35%" class="form-control" type="text" placeholder="Default input" aria-label="default input example" runat="server" />
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                <button type="button" class="btnIngresar">Guardar</button>
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
                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                <button type="button" class="btnIngresar">Modificar</button>
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
                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                <button type="button" class="btnIngresar">Eliminar</button>
              </div>
            </div>
          </div>
        </div>
</asp:Content>
