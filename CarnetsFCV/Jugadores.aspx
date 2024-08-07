﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Jugadores.aspx.cs" Inherits="CarnetsFCV.Jugadores" %>
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
        <asp:Label ID="titulo" Text="Jugadores" CssClass="titulo" style="color:white" runat="server" />
    </div>
    <div class="row">  
        <div class="col-sm-1" style="margin-left:2%">
            <asp:Button CssClass="btnInicio" ID="btnInicio" OnClick="btnInicio_Click" Text="Inicio" runat="server" />
        </div>  
    </div>

        <!-- Button trigger modal -->
    <div class="row" style="margin-left: 4%;">
        <div class="col-xl-2">   
            <button type="button" style="width:100%" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#btnBuscarFiltro" runat="server" ID="btnBuscador">Ingresar Filtros</button>
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

    
    <div class="col-md-1" style="margin-left: 5%;display:flex; justify-content:center; align-items:center">
        <asp:Button CssClass="btnCRUD" ID="btnSeleccionar" OnClick="btnSeleccionar_Click" Text="Seleccionar" runat="server" />
    </div>

    <div class="col-md-1" style="display:flex; justify-content:left; align-items:center">
        <asp:ImageButton  class="btnBuscar" OnClick="LimpiarFiltros_Click" ID="LimpiarFiltros" ImageUrl="Imagenes/X.png" runat="server" ClientIDMode="Static"/> 
    </div>
    <br />
    <br />
</div>


<!-- Button trigger modal -->
    <div class="row" style="margin-left:5%; margin-top: 1%;">
            <div class="col-xl-1" padding-right: 8%; >   
                <button  type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalValidarDNI"  runat="server" ID="Button1">Validar DNI</button>
            </div>
            <div class="col-xl-1" padding-right: 8%; >   
                <button  type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalAgregar"  runat="server" ID="btnAgregar">Agregar</button>
            </div>
            <div class="col-xl-1" padding-right: 8%;>
                <button  type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalModificar" runat="server" ID="btnModificar">Modificar</button>
            </div>
            <div class="col-xl-1" padding-right: 8%;>
                <button  type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalEliminar" runat="server" ID="btnEliminar">Eliminar</button>
            </div>
            <div class="col-xl-7" style=" display: flex; justify-content: right; align-items: center;">
                <asp:TextBox CssClass="buscador" ID="txtBuscar" runat="server" onkeypress="return handleKeyDown(event)"/>
                <asp:ImageButton  class="btnBuscar" ID="btnBuscar" OnClick="btnBuscar_Click" ImageUrl="Imagenes/Lupa.png" runat="server" ClientIDMode="Static"/>                
                <asp:ImageButton CssClass="btnBuscar" ImageUrl="Imagenes/excel.png" ID="btnExportar" OnClick="btnExportar_Click" runat="server" />
            </div>            

    </div>

    <div class="row">
        <div class="col">        
            
            <div class="divGrilla">
                <asp:HiddenField ID="filaSeleccionada" runat="server" />
                <asp:GridView AutoGenerateColumns="false" CssClass="grilla"  ID="gvJugadores" runat="server" ShowHeaderWhenEmpty="True" Font-Names="Arial" GridLines="None" OnRowDataBound="gvJugadores_RowDataBound">
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
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="Club" HeaderText="Club" />
                        <asp:BoundField DataField="Equipo" HeaderText="Equipo" />
                        <asp:BoundField DataField="División" HeaderText="División" />
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
        



<!-- Modal ValidarDNI -->
          

                <div class="modal fade" id="ModalValidarDNI" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                  <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content" style="background-color:#CCCCCC">
                      <div class="modal-header" style="background-color:#e44f1e;">
                        <h1 class="modal-title fs-5" style="color:white" id="staticBackdropLabel">Ingrese DNI</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                      </div>
                      <div class="modal-body" style="align-items:center">

                          <div class="row"style="display:flex;margin-top:2%; align-items:center">
                                <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                                    <asp:Label Text="DNI:" runat="server" />
                                </div>
                                <div class="col-sm-4" style="display:flex; align-items:center;">
                                    <asp:TextBox BorderColor="#e44f1e" ID="txtValidarDni" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" runat="server" />
                                </div>
                           </div>

                      <div class="modal-footer">
                          <button type="button" class="btnCancelar" data-bs-dismiss="modal">Cancelar</button>
                          <asp:Button ID="btnValidarDNI" class="btnGuardar" OnClick="btnValidarDNI_Click" Text="Validar" runat="server" />
                      </div>
                    </div>
                  </div>
                </div>
            </div>



<!-- Modal Agregar -->

        <div class="modal fade" id="ModalAgregar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content" style="background-color:#CCCCCC">
              <div class="modal-header" style="background-color:#e44f1e;">
                <h1 class="modal-title fs-5" style="color:white" id="staticBackdropLabel">Nuevo Jugador</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body" style="align-items:center">

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="DNI:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox BorderColor="#e44f1e" ID="txtDNI" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" runat="server" />
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2"style="display:flex; align-items:center; width:35%;">
                            <asp:Label Text="Equipo:" runat="server" /> 
                        </div>
                        <div class="col-sm-4"style="display:flex; align-items:center">
                            <asp:DropDownList ID="cmbEquiposModal" Style=" margin-left:2%; width:auto; margin-left:2px;"  OnSelectedIndexChanged="cmbEquipos_SelectedIndexChanged"  class="btn btn-secondary btn-sm dropdown-toggle" runat="server" AutoPostBack="False">
                                </asp:DropDownList>
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
                        <div class="col-sm-2"style="display:flex; align-items:center; width:35%;">
                            <asp:Label Text="Sexo:" runat="server" /> 
                        </div>
                        <div class="col-sm-4"style="display:flex; align-items:center">
                            <asp:DropDownList ID="cmbSexoModal" Style=" margin-left:2%; width:auto; margin-left:2px;"  OnSelectedIndexChanged="cmbEquipos_SelectedIndexChanged"  class="btn btn-secondary btn-sm dropdown-toggle" runat="server" AutoPostBack="False">
                                </asp:DropDownList>
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
                  <asp:Button class="btnGuardar" OnClick="btnGuardar_Click" Text="Guardar" runat="server" />
              </div>
            </div>
          </div>
        </div>




 <!-- Modal Modificar -->
        <div class="modal fade" id="ModalModificar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content" style="background-color:#CCCCCC">
              <div class="modal-header" style="background-color:#e44f1e;">
                <h1 class="modal-title fs-5" style="color:white" id="staticBackdropLabel">Modificar Jugador</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body">

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2" style="display:flex; align-items:center;width:35%;">
                            <asp:Label Text="DNI:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox BorderColor="#e44f1e" ID="txtModificarDNI" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" runat="server" />
                        </div>
                   </div>

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-2"style="display:flex; align-items:center; width:35%;">
                            <asp:Label Text="Equipo:" runat="server" /> 
                        </div>
                        <div class="col-sm-4"style="display:flex; align-items:center">
                            <asp:DropDownList ID="cmbModificarEquipo" Style=" margin-left:2%; width:auto; margin-left:2px;" OnSelectedIndexChanged="cmbMoficarEquipo_SelectedIndexChanged"  class="btn btn-secondary btn-sm dropdown-toggle" runat="server" AutoPostBack="False">
                                </asp:DropDownList>
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
                        <div class="col-sm-2"style="display:flex; align-items:center; width:35%;">
                            <asp:Label Text="Sexo:" runat="server" /> 
                        </div>
                        <div class="col-sm-4"style="display:flex; align-items:center">
                            <asp:DropDownList ID="cmbModificarSexoModal" Style=" margin-left:2%; width:auto; margin-left:2px;"  OnSelectedIndexChanged="cmbEquipos_SelectedIndexChanged"  class="btn btn-secondary btn-sm dropdown-toggle" runat="server" AutoPostBack="False">
                                </asp:DropDownList>
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
                <h1 class="modal-title fs-5" style="color:white" id="staticBackdropLabel">Eliminar Jugador</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body">
                  
                      <div class="row"style="display:flex;margin-top:2%; align-items:center">
                          <h4>¿Seguro desea eliminar el Jugador?</h4>                                                  
                      </div>

              <div class="modal-footer">
                <button type="button" class="btnCancelar"  data-bs-dismiss="modal">Cancelar</button>
                <asp:Button class="btnGuardar" OnClick="btnEliminar_Click" Text="Eliminar" runat="server" />
              </div>
            </div>
          </div>
        </div>
        </div>

            <!-- Modal Buscar -->
          

                <div class="modal fade" id="btnBuscarFiltro" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                  <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content" style="background-color:#CCCCCC">
                      <div class="modal-header" style="background-color:#e44f1e;">
                        <h1 class="modal-title fs-5" style="color:white" id="staticBackdropLabel">Seleccione Equipo</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                      </div>
                      <div class="modal-body" style="align-items:center">
                                                    
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
            

            <script type="text/javascript">
                function handleKeyDown(event) {
                    // Si la tecla presionada es Enter (código 13), realizar la búsqueda
                    if (event.keyCode === 13) {
                        event.preventDefault(); // Evita que el formulario se envíe
                        document.getElementById('btnBuscar').click(); // Simula el clic en el botón de búsqueda
                        return false; // Evita el comportamiento predeterminado de la tecla Enter
                    }
                }
                // Agrega un listener para el evento keydown en el campo de búsqueda
                document.getElementById('<%= txtBuscar.ClientID %>').addEventListener('keydown', handleKeyDown);
            </script>


</asp:Content>
