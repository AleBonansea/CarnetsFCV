<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="PruebaBootstrap.aspx.cs" Inherits="CarnetsFCV.PruebaBootstrap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="jumbotron text-center">
        <h1  style="color:white">Implementando Bootstrap</h1>
        <p  style="color:white">Redimensión responsive</p>        
    </div>

    <div class="container">
        <div class="row">
            <div class="col-sm-4" style="color:white">
                <h3>Columna 1</h3>
                <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Quo quos nobis velit dolorem assumenda hic eligendi laborum sit voluptate sint impedit debitis harum maxime, mollitia vitae, dicta, ratione neque deleniti.</p>
            </div>
            <div class="col-sm-4"style="color:white">
                <h3>Columna 2</h3>
                <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Quo quos nobis velit dolorem assumenda hic eligendi laborum sit voluptate sint impedit debitis harum maxime, mollitia vitae, dicta, ratione neque deleniti.</p>
            </div>
            <div class="col-sm-4"style="color:white">
                <h3>Columna 3</h3>
                <p>Algo algo algo</p>
            </div>
        </div>
    </div>
</asp:Content>
