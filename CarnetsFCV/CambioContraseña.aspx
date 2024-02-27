<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="CambioContraseña.aspx.cs" Inherits="CarnetsFCV.CambioContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
     <div class="row">
     <div class="col">            
         <h1 style="background-color:#020202;" class="bienvenidos" >Modificación de Contraseña !</h1>
     </div>
 </div>
<div class="row">
     <div class="col">  
 <div class="formulario">
     <div class="formH1">
     <h1>Nueva contaseña</h1>
     </div>
     <div >
         <div>
             <label>Contraseña:</label>
             <asp:TextBox placeHolder="Ingrese Contraseña" class="input" type="password" id="txtContraseña" value="" runat="server"/>
             
         </div>
         <div>
             <label>Verificación:</label>
             <asp:TextBox  placeHolder="Repita Contraseña" class="input" type="password"  id="txtRepetirContraseña" value="" runat="server"/>
         </div>
         <asp:Label Text="" ID="lblError" style="margin-left:10px" ForeColor="Red" Font-Bold="true" Font-Size="16px" runat="server" />
         <div style="text-align:right;">
             <asp:Button style="margin-right:5px" id="btnGuardar" OnClick="btnGuardar_Click" class="btnIngresar" Text="Guardar" runat="server" />             
         </div>
     </div>
     
 </div>
           </div>
 </div>
     <div class="row" >             
         <div class="col" style="text-align:right">
            <asp:Button ID="btnSalir" OnClick="btnSalir_Click" class="btnCerrar" arial-label="Close" Text="Salir" runat="server"/>                 
        </div>
</div>
</asp:Content>
