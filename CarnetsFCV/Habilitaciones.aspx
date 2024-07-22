<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Habilitaciones.aspx.cs" Inherits="CarnetsFCV.Habilitaciones" %>

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
        <asp:Label ID="titulo" Text="Habilitaciones" CssClass="titulo" style="color:white" runat="server" />
    </div>
    <div class="row">
        <div class="col-sm-1" style="margin-left: 2%">
            <asp:Button CssClass="btnInicio" ID="btnInicio" OnClick="btnInicio_Click" Text="Inicio" runat="server" />
        </div>
    </div>
    <div class="row" style="margin-left: 4%;">
    <!-- Button trigger modal -->
    <div class="col-xl-2">   
        <button type="button" style="width:100%" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#btnBuscar" runat="server" ID="btnBuscador">Ingresar Filtros</button>
    </div>  
        <div class="col-xl-8 d-flex justify-content-end">
            <div class="me-3">
                <asp:Button CssClass="btnCRUD" ID="btnHabilitar" Text="Habilitar" OnClick="btnHabilitar_Click" Enabled="false" runat="server" />
            </div>
            <div>
                <asp:Button CssClass="btnCRUD" ID="btnDeshabilitar" Text="Deshabilitar" OnClick="btnDeshabilitar_Click" Enabled="false" runat="server" />
            </div>
        </div>
    </div>

    <div class="row" style="margin-left: 4%; margin-top: 1%;">
        <div class="col-md-1" style="display:flex; justify-content:center;">
            <asp:Label ID="lblEquipos" style="color:white; display:flex; align-items:center; justify-content:center;" CssClass="ddlLabel" Text="Equipos: " runat="server" />            
        </div>

        <div class="col-md-1">
            <asp:DropDownList CssClass="ddlCRUD" ID="cmbEquipo" runat="server">
            </asp:DropDownList> 
        </div>

        
        <div class="col-md-1" style="margin-left: 5%;display:flex; justify-content:center;">
            <asp:Button CssClass="btnCRUD" ID="btnSeleccionar" OnClick="btnSeleccionar_Click" Text="Seleccionar" runat="server" />
        </div>
        <br />
        <br />
    </div>

    <br />


    <div class="row">
        <div class="col">

            <div class="divGrilla">
                <asp:HiddenField ID="filaSeleccionada" runat="server" />
                <asp:GridView AutoGenerateColumns="false" CssClass="grilla" ID="gvJugadores" runat="server" ShowHeaderWhenEmpty="True" Font-Names="Arial" GridLines="None" DataKeyNames="Id"  OnRowDataBound="gvJugadores_RowDataBound">
                    <AlternatingRowStyle CssClass="grilla" BackColor="#CCCCCC" BorderStyle="Solid" BorderWidth="3px" Font-Names="Arial" />
                    <EditRowStyle Font-Names="Arial" Font-Size="14pt" />
                    <HeaderStyle CssClass="grilla" BackColor="#e44f1e" Font-Bold="True" Font-Names="Arial" Font-Strikeout="False" VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#FFA420" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" runat="server" BorderStyle="None"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="FechaNac" HeaderText="FechaNac" />
                        <asp:BoundField DataField="FechaEMMAC" HeaderText="FechaEMMAC" />
                        <asp:BoundField DataField="DNI" HeaderText="DNI" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                        <asp:TemplateField HeaderText="Habilitado">
                            <ItemTemplate>
                                <asp:Image ID="imgHabilitado" CssClass="imgHabilitado" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    


<!-- Modal Buscar -->
          

                <div class="modal fade" id="btnBuscar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                  <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content" style="background-color:#CCCCCC">
                      <div class="modal-header" style="background-color:#e44f1e;">
                        <h1 class="modal-title fs-5" style="color:white" id="staticBackdropLabel">Seleccione Equipo</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                      </div>
                      <div class="modal-body" style="align-items:center">

                          <div class="row"style="display:flex;margin-top:5%; align-items:center">
                                <div class="col-sm-2" style="display:flex; align-items:center; margin-left:10%">
                                    <asp:Label CssClass="ddlLabel" Text="Club: " runat="server" />
                                </div>
                                <div class="col-sm-6" style="display:flex; align-items:center; margin-left:10%">
                                    <asp:DropDownList CssClass="ddlCRUD" ID="cmbClub" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                          <div class="row"style="display:flex;margin-top:2%; align-items:center">
                                <div class="col-sm-2" style="display:flex; align-items:center; margin-left:10%">
                                    <asp:Label CssClass="ddlLabel" Text="Rama: " runat="server" />
                                </div>
                                    <div class="col-sm-6" style="display:flex; align-items:center; margin-left:10%">
                                    <asp:DropDownList CssClass="ddlCRUD" ID="cmbRama" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row"style="display:flex;margin-top:2%; align-items:center">
                                <div class="col-sm-2" style="display:flex; align-items:center; margin-left:10%">
                                    <asp:Label CssClass="ddlLabel" Text="División: " runat="server" />
                                </div>
                                <div class="col-sm-6" style="display:flex; align-items:center; margin-left:10%">
                                    <asp:DropDownList CssClass="ddlCRUD" ID="cmbDiv" runat="server">
                                    </asp:DropDownList>
                                </div>
                           </div>

                      <div class="modal-footer">
                          <button type="button" class="btnCancelar" data-bs-dismiss="modal">Cancelar</button>
                          <asp:Button ID="btnFiltros" class="btnGuardar" OnClick="btnFiltros_Click" Text="Buscar" runat="server" />
                      </div>
                    </div>
                  </div>
                </div>
            </div>

</asp:Content>
