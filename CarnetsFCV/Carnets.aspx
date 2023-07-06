<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Carnets.aspx.cs" Inherits="CarnetsFCV.Carnets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

    <div class="row">  
        <div class="col-sm-1" style="margin-left:2%">
            <asp:Button CssClass="btnInicio" ID="btnInicio" OnClick="btnInicio_Click" Text="Inicio" runat="server" />
        </div>  
    </div>    


        <div class="carnet" id="divQRContent" runat="server">
            <h1 class="tituloCarnet">Federación Cordobesa de Voleibol</h1>

            <div class="col-sm-6" >
                <div >
                    <label class="datosCarnet">Nombre:  </label>
                    <asp:Label class="datosCarnetBd" Text="" ID="lblNombre" runat="server" />
                    <br />
                    <label class="datosCarnet">Apellido:  </label>
                    <asp:Label class="datosCarnetBd" Text="" ID="lblApellido" runat="server" />
                    <br />
                    <label class="datosCarnet">Fecha Nacimiento:  </label>
                    <asp:Label class="datosCarnetBd" Text="" ID="lblFecNac" runat="server" />
                    <br />
                    <label class="datosCarnet">DNI:  </label>
                    <asp:Label class="datosCarnetBd" Text="" ID="lblDNI" runat="server" />
                    <br />
                    <label class="datosCarnet">Habilitado:  </label>
                    <asp:Label class="datosCarnetBd" Text="" ID="lblHabilitado" runat="server" />
                    <br />
                    <label class="datosCarnet">Fecha EMMAC:  </label>
                    <asp:Label class="datosCarnetBd" Text="" ID="lblEMMAC" runat="server" />
                    <br />
                    <asp:Label class="datosCarnet" Text="Sexo:  " ID="lblSexoTit"  visible="false" runat="server" />
                    <asp:Label class="datosCarnetBd" Text="" ID="lblSexo" visible="false" runat="server" />
                    <br />
                    <asp:Label class="datosCarnet" Text="Club:  " ID="lblClub"  visible="false" runat="server" />
                    <asp:Label class="datosCarnetBd" Text="" ID="lblClubJugador" visible="false"  runat="server" />
                </div>
                <div class="rolCarnet">
                    <asp:Label Text="" ID="lblRol" runat="server" />
                </div>
            </div>

            <div class="col-sm-6" >
                <div ID="divFoto" >
                    <asp:Image class="imgFoto" ID="imgFoto" runat="server" />
                </div>

                <div class="QR">
                    <asp:Image class="QR" ID="imgQRCode" runat="server" />
                </div>
            </div>
        </div>
</asp:Content>
