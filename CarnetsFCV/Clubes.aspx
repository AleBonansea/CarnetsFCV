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
    <div class="row">  
        <div class="col-sm-1" style="margin-left:2%">
            <asp:Button CssClass="btnInicio" ID="btnInicio" OnClick="btnInicio_Click" Text="Inicio" runat="server" />
        </div>  
    </div>
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
                <asp:TextBox CssClass="buscador" ID="txtBuscar" runat="server" />
                <asp:ImageButton  class="btnBuscar" ID="btnBuscar" OnClick="btnBuscar_Click" ImageUrl="Imagenes/Lupa.png" runat="server" />
            </div>
            

    </div>

    <div class="row">
        <div class="col">
            <div class="divGrilla">

                <asp:GridView CssClass="grilla" ID="gvClubes"  runat="server" ShowHeaderWhenEmpty="True" Font-Names="Arial"  GridLines="None">

                    <AlternatingRowStyle CssClass="grilla" BackColor="#CCCCCC" BorderStyle="Solid" BorderWidth="3px" Font-Names="Arial"/>
                    <EditRowStyle Font-Names="Arial" Font-Size="14pt" />
                    <HeaderStyle CssClass="grilla" BackColor="#e44f1e" Font-Bold="True" Font-Names="Arial"  Font-Strikeout="False" VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#FFA420" />
                </asp:GridView>
            </div>
        </div>
    </div>
        <div class="row">
             <div style="text-align:right">
                <asp:Button ID="btnCerrarSesion" OnClick="btnCerrarSesion_Click" class="btnCerrar" arial-label="Close" Text="Cerrar Sesión" runat="server"/>
            </div>
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
