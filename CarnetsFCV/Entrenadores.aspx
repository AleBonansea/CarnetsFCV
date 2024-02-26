<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Entrenadores.aspx.cs" Inherits="CarnetsFCV.Entrenadores" %>
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
            <div class="col-xl-9" style="padding-right:6%; display: flex; justify-content: right; align-items: center;">
                <asp:TextBox CssClass="buscador" ID="txtBuscar" runat="server" />
                <asp:ImageButton  class="btnBuscar" ID="btnBuscar" OnClick="btnBuscar_Click" ImageUrl="Imagenes/Lupa.png" runat="server" />
                <asp:ImageButton CssClass="btnBuscar" ImageUrl="Imagenes/excel.png" ID="ImageButton1" OnClick="btnExportar_Click" runat="server" />
            </div>
    </div>
    <div class="row">
        <div class="col">        
            
            <div class="divGrilla">
                <asp:HiddenField ID="filaSeleccionada" runat="server" />
                <asp:GridView  CssClass="grilla"  ID="gvEntrenadores" runat="server" ShowHeaderWhenEmpty="True" Font-Names="Arial" GridLines="None">
                    <AlternatingRowStyle CssClass="grilla" BackColor="#CCCCCC" BorderStyle="Solid" BorderWidth="3px" Font-Names="Arial"/>
                    <EditRowStyle Font-Names="Arial" Font-Size="14pt" />
                    <HeaderStyle CssClass="grilla" BackColor="#e44f1e" Font-Bold="True" Font-Names="Arial"  Font-Strikeout="False" VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#FFA420" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:CheckBox ID="chk" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" runat="server" BorderStyle="None" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
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
                <h1 class="modal-title fs-5" style="color:white" id="staticBackdropLabel">Nuevo Entrenador</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body" style="align-items:center">

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="DNI:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox OnTextChanged="txtDNI_TextChanged" AutoPostBack="true" BorderColor="#e44f1e" ID="txtDNI" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" runat="server" />
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center; width:35%;">
                            <asp:Label Text="Nombre:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox BorderColor="#e44f1e" ID="txtNombre" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" runat="server" />
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="Apellido:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox BorderColor="#e44f1e" ID="txtApellido" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" runat="server" />
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="Fecha Nacimiento:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox  ID="txtFecNac" class="form-control" type="text" aria-label="default input example" runat="server" TextMode="Date" />                           
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="Fecha EMMAC:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox BorderColor="#e44f1e" ID="txtFecEMMAC" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" TextMode="Date" runat="server" />
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="Email:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox BorderColor="#e44f1e" ID="txtEmail" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" runat="server" />
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="Teléfono:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox BorderColor="#e44f1e" ID="txtTel" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" runat="server" />
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="Habilitado:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center; justify-content:center;">
                            <div class="col-sm-2" style="display:flex; align-items:center; width:auto;margin-left:25%; margin-right:30%;">
                                <asp:RadioButton GroupName="habilitado" Checked="true" ID="rdbSi" margin-rigth="25%" Text="Si" runat="server" />
                            </div>
                            <div class="col-sm-2" style="display:flex; align-items:center;width:auto;">
                                <asp:RadioButton GroupName="habilitado" ID="rdbNo" Text="No" runat="server" />
                            </div>
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="Foto:" runat="server" />
                        </div>
                   </div>
                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-4">
                            <asp:FileUpload ID="archivo" runat="server" style="width:auto; margin-left:50%" CssClass="form-control" /> 
                        </div>
                      </div>
              </div>
              <div class="modal-footer">
                <asp:button OnClick="ModalCancelar_click" class="btnCancelar" data-bs-dismiss="modal" Text="Cancelar" runat="server" />
                  <asp:Button class="btnGuardar" OnClick="modalGuardar_Click" Text="Guardar" runat="server" />
              </div>
            </div>
          </div>
        </div>

    <!-- Modal Modificar -->
        <div class="modal fade" id="ModalModificar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content" style="background-color:#CCCCCC">
              <div class="modal-header" style="background-color:#e44f1e;">
                <h1 class="modal-title fs-5" style="color:white" id="staticBackdropLabel">Modificar Equipo</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>

                <div class="modal-body" style="align-items:center">

                <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="DNI:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox BorderColor="#e44f1e" ID="txtModificarDNI" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" runat="server" />
                        </div>
                </div>

                     <div class="row"style="display:flex;margin-top:2%; align-items:center">
                         <div class="col-sm-2" style="display:flex; align-items:center; width:35%;">
                            <asp:Label Text="Nombre:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox BorderColor="#e44f1e" ID="txtModificarNombre" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" runat="server" />
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="Apellido:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox BorderColor="#e44f1e" ID="txtModificarApellido" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" runat="server" />
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="Fecha Nacimiento:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox  ID="txtModificarFecNac" class="form-control" type="text" aria-label="default input example" runat="server" TextMode="Date" />                           
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="Fecha EMMAC:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox BorderColor="#e44f1e" ID="txtModificarFecEMMAC" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" TextMode="Date" runat="server" />
                        </div>
                   </div>                  

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="Email:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox BorderColor="#e44f1e" ID="txtModificarEmail" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" runat="server" />
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="Teléfono:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox BorderColor="#e44f1e" ID="txtModificarTel" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" runat="server" />
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="Habilitado:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center; justify-content:center;">
                            <div class="col-sm-2" style="display:flex; align-items:center; width:auto;margin-left:25%; margin-right:30%;">
                                <asp:RadioButton GroupName="habilitado" Checked="true" ID="rdbModificarSi" margin-rigth="25%" Text="Si" runat="server" />
                            </div>
                            <div class="col-sm-2" style="display:flex; align-items:center;width:auto;">
                                <asp:RadioButton GroupName="habilitado" ID="rdbModificarNo" Text="No" runat="server" />
                            </div>
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="Foto:" runat="server" />
                        </div>
                   </div>
                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-4">
                            <asp:FileUpload ID="archivoModificar" runat="server" style="width:auto; margin-left:50%" CssClass="form-control" /> 
                        </div>
                      </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btnCancelar"  data-bs-dismiss="modal">Cancelar</button>
                <asp:Button class="btnGuardar" OnClick="modalModificar_Click" Text="Guardar" runat="server" />
              </div>
            </div>
          </div>
        </div>

    <!-- Modal Eliminar -->
        <div class="modal fade" id="ModalEliminar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content" style="background-color:#CCCCCC">
              <div class="modal-header" style="background-color:#e44f1e;">
                <h1 class="modal-title fs-5" style="color:white" id="staticBackdropLabel">Eliminar Equipo</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body">
                  
                      <div class="row"style="display:flex;margin-top:2%; align-items:center">
                          <h4>¿Seguro desea eliminar el equipo?</h4>                                                  
                      </div>

              <div class="modal-footer">
                <button type="button" class="btnCancelar"  data-bs-dismiss="modal">Cancelar</button>
                <asp:Button class="btnGuardar" OnClick="btnEliminar_Click"  Text="Eliminar" runat="server" />
              </div>
            </div>
          </div>
        </div>
</asp:Content>
