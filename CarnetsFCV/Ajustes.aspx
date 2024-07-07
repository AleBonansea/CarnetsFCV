<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Ajustes.aspx.cs" Inherits="CarnetsFCV.Ajustes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

<div>
    <asp:Label ID="titulo" Text="Ajustes" CssClass="titulo" style="color:white" runat="server" />
</div>
<div class="row">
    <div class="col-sm-1" style="margin-left: 2%">
        <asp:Button CssClass="btnInicio" ID="btnInicio" OnClick="btnInicio_Click" Text="Inicio" runat="server" />
    </div>
</div>
<div class="row" style="margin-left: 4%;">
    <div class="col-md-2">
        <asp:DropDownList CssClass="ddlCRUD" ID="cmbAjustes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbAjustes_SelectedIndexChanged">            
            <asp:ListItem Text="Divisiones" Id="ddlDivisiones" />
            <asp:ListItem Text="Ramas" Id="ddlRamas" />
            <asp:ListItem Text="Sexos" Id="ddlSexos" />
        </asp:DropDownList>         
    </div>
<!-- Button trigger modal -->
    <div class="col-md-1" >   
        <button  type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalAgregar">Agregar</button>
    </div>
    <div class="col-md-1"">
        <button  type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalModificar">Modificar</button>
    </div>
    <div class="col-md-1">
        <button  type="button" class="btnCRUD" data-bs-toggle="modal" data-bs-target="#ModalEliminar">Eliminar</button>
    </div>
</div>

 <div class="row">
     <div class="col">

         <div class="divGrilla">
             <asp:HiddenField ID="filaSeleccionada" runat="server" />
             <asp:GridView AutoGenerateColumns="false" CssClass="grillaChica" ID="gvAjustes" runat="server" ShowHeaderWhenEmpty="True" Font-Names="Arial" GridLines="None" DataKeyNames="Id">
                 <AlternatingRowStyle CssClass="grillaChica" BackColor="#CCCCCC" BorderStyle="Solid" BorderWidth="3px" Font-Names="Arial" />
                 <EditRowStyle Font-Names="Arial" Font-Size="14pt" />
                 <HeaderStyle CssClass="grillaChica" BackColor="#e44f1e" Font-Bold="True" Font-Names="Arial" Font-Strikeout="False" VerticalAlign="Middle" />
                 <SelectedRowStyle BackColor="#FFA420" />
                 <Columns>
                     <asp:TemplateField>
                         <ItemTemplate>
                             <asp:CheckBox ID="chk" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" runat="server" BorderStyle="None"/>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="Id" HeaderText="Id" />
                     <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />                     
                 </Columns>
             </asp:GridView>
         </div>
     </div>
 </div>

    <!-- Modal Agregar -->
    <div class="modal fade" id="ModalAgregar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content" style="background-color:#CCCCCC">
          <div class="modal-header" style="background-color:#e44f1e;">
            <h1 class="modal-title fs-5" style="color:white" id="staticBackdropLabel">Nuevo</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body" style="align-items:center">

                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                          <div class="col-sm-3" style="display:flex; align-items:center;">
                              <asp:Label Text="Descripción:" runat="server" />
                          </div>
                          <div class="col-sm-4" style="display:flex; align-items:center;">
                              <asp:TextBox BorderColor="#e44f1e" ID="txtDescripcion" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" runat="server" />
                          </div>
                    </div>
              
              </div>
          <div class="modal-footer">
              <button type="button" class="btnCancelar" data-bs-dismiss="modal">Cancelar</button>
              <asp:Button ID="btnGuardar" class="btnGuardar" OnClick="btnGuardar_Click" Text="Guardar" runat="server" />
          </div>
        </div>
      </div>
    </div>

<!-- Modal Modificar -->
    <div class="modal fade" id="ModalModificar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content" style="background-color:#CCCCCC">
          <div class="modal-header" style="background-color:#e44f1e;">
            <h1 class="modal-title fs-5" style="color:white" id="staticBackdropLabel">Modificar</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
              
                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                        <div class="col-sm-3" style="display:flex; align-items:center;">
                            <asp:Label Text="Descripción:" runat="server" />
                        </div>
                        <div class="col-sm-4" style="display:flex; align-items:center;">
                            <asp:TextBox BorderColor="#e44f1e" ID="txtModificarDescripcion" Style=" margin-left:2%; width:auto; margin-left:2px;" class="form-control" type="text" aria-label="default input example" runat="server" />
                        </div>
                  </div>
          
          </div>
          <div class="modal-footer">
            <button type="button" class="btnCancelar"  data-bs-dismiss="modal">Cancelar</button>
            <asp:Button ID="btnModificar" class="btnGuardar" OnClick="btnModificar_Click" Text="Guardar" runat="server" />
          </div>
        </div>
      </div>
    </div>

<!-- Modal Eliminar -->
    <div class="modal fade" id="ModalEliminar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content" style="background-color:#CCCCCC">
          <div class="modal-header" style="background-color:#e44f1e;">
            <h1 class="modal-title fs-5" style="color:white" id="staticBackdropLabel">Eliminar</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
              
                  <div class="row"style="display:flex;margin-top:2%; align-items:center">
                      <h4>¿Seguro desea eliminar?</h4>                                                  
                  </div>

          <div class="modal-footer">
            <button type="button" class="btnCancelar"  data-bs-dismiss="modal">Cancelar</button>
            <asp:Button ID="btnEliminar" class="btnGuardar" OnClick="btnEliminar_Click" Text="Eliminar" runat="server" />
          </div>
        </div>
      </div>
    </div>

</asp:Content>
