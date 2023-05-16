<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="CarnetsFCV.Ingreso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content  ID="Content2" ContentPlaceHolderID="Contenido"  runat="server">
    <h1 style="background-color:#020202;" class="bienvenidos" >Bienvenidos !</h1>
   
    <div class="formulario">
        <div class="formH1">
        <h1>Ingreso</h1>
        </div>
        <div >
            <div>
                <label>Usuario:</label>
                <asp:TextBox placeHolder="Ingrese Usuario" class="input" type="text" id="txtUsuario" value="" runat="server"/>
                
            </div>
            <div>
                <label>Contraseña:</label>
                <asp:TextBox  placeHolder="Ingrese Contraseña" class="input" type="password"  id="txtContraseña" value="" runat="server"/>
            </div>
            <asp:Label Text="" ID="lblError" style="margin-left:10px" ForeColor="Red" Font-Bold="true" Font-Size="16px" runat="server" />
            <div style="text-align:right;">
                <asp:Button style="margin-right:5px" id="btnIngresar" OnClick="btnIngresar_Click" class="btnIngresar" Text="Ingresar" runat="server" />
                <asp:Button style="margin-left:5px" id="btnCancelar" OnClick="btnCancelar_Click" class="btnIngresar" Text="Cancelar"  runat="server" />
            </div>
        </div>
        
    </div>
    <div >
    </div>


</asp:Content>
