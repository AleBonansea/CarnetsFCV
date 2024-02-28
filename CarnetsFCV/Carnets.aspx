<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Carnets.aspx.cs" Inherits="CarnetsFCV.Carnets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

<div class="container">
    <div class="col-sm-1" style="margin-left:2%">
        <asp:Button CssClass="btnInicio" ID="btnInicio" OnClick="btnInicio_Click" Text="Inicio" runat="server" />
    </div>  
    <div class="row">  
        <div class="col-md-6 foto-container">
            <div class="form-group text-center foto-container">
                <asp:Image class="img-fluid rounded-circle" ID="imgFoto" runat="server" />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12 text-center">
            <h1 class="tituloCarnet">Federación Cordobesa de Voleibol</h1>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label for="txtNombre">Nombre:</label>
                <asp:Label class="form-control" ID="lblNombre" runat="server" />
            </div>
            
            <div class="form-group">
                <label for="txtDNI">DNI:</label>
                <asp:Label class="form-control" ID="lblDNI" runat="server" />
            </div>
            
            
            <div class="form-group">
                <label for="txtEMMAC">Fecha EMMAC:</label>
                <asp:Label class="form-control" ID="lblEMMAC" runat="server" />
            </div>
            <div class="form-group" id="divRolCarnet">
                <asp:Label ID="lblRolTit" runat="server" Text="Rol:"  />
                <asp:Label class="form-control" Text="" ID="lblRol" runat="server" />
            </div>
            <div class="form-group" id="divSexo">
                <asp:Label ID="lblSexoTit" Visible="false" runat="server" Text="Sexo:" />
                <asp:Label class="form-control" ID="lblSexo" runat="server" Visible="false" />
            </div>
        </div>

        <div class="col-md-3">
            <div class="form-group">
                <label for="txtApellido">Apellido:</label>
                <asp:Label class="form-control" ID="lblApellido" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtFecNac">Fecha Nacimiento:</label>
                <asp:Label class="form-control" ID="lblFecNac" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtHabilitado">Habilitado:</label>
                <asp:Label class="form-control" ID="lblHabilitado" runat="server" />
            </div>
            <div class="form-group" id="divClubJugador">
                <asp:Label ID="lblClub" Visible="false" runat="server" Text="Club:"  />
                <asp:Label class="form-control" ID="lblClubJugador" runat="server" Visible="false" />
            </div>   
        </div>
        <div >            
            <br />

            <div class="row">  
                <div class="col-md-6 ">
                    <div class="form-group text-center ">
                        <asp:Image class="img-fluid" ID="imgQRCode" runat="server" />
                    </div>
                </div>
            </div>        
                <br />
        </div>
    </div>
</div>


</asp:Content>

