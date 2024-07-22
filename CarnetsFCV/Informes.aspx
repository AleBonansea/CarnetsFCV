<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="CarnetsFCV.Informes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/chartjs-plugin-datalabels"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div>
        <asp:Label ID="titulo" Text="Informes" CssClass="titulo" style="color:white" runat="server" />
    </div>
    <div class="row">  
        <div class="col-sm-1" style="margin-left:2%">
            <asp:Button CssClass="btnInicio" OnClick="btnInicio_Click" ID="btnInicio"  Text="Inicio" runat="server" />
        </div>  
    </div>
    <div class="row" style="margin-left: 4%; margin-top: 1%;">
        <div class="col-md-1">
            <asp:DropDownList CssClass="ddlCRUD" ID="cmbEquipo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbEquipo_SelectedIndexChanged">
            </asp:DropDownList> 
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <canvas id="habilitadosChart" width="400" height="350"></canvas>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfData" runat="server" />
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            // Obtener datos del servidor desde el HiddenField
            const data = JSON.parse(document.getElementById('<%= hfData.ClientID %>').value);

            const years = data.map(d => d.Year);
            const counts = data.map(d => d.Total);

            const ctx = document.getElementById('habilitadosChart').getContext('2d');
            const chart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: years,
                    datasets: [{
                        label: 'Jugadores Habilitados',
                        data: counts,
                        backgroundColor: 'rgba(228, 79, 30, 0.4)',
                        borderColor: 'rgba(228, 79, 30, 1)',
                        borderWidth: 2
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: {
                        datalabels: {
                            color: 'white',
                            anchor: 'end',
                            align: 'top',
                            formatter: function (value) {
                                return value;
                            }
                        },
                        legend: {
                            labels: {
                                color: 'white'
                            }
                        }
                    },
                    scales: {
                        y: {
                            beginAtZero: true,
                            suggestedMin: 0, // Valor mínimo sugerido en el eje Y
                            suggestedMax: Math.max(...counts) + 1, // Valor máximo sugerido en el eje Y
                            ticks: {
                                color: 'white', // Color de los números del eje Y
                                stepSize: 1, // Paso de 1 para asegurar enteros
                                precision: 0 // Precisión cero para asegurar que no haya decimales
                            }
                        },
                        x: {
                            ticks: {
                                color: 'white' // Color de las etiquetas del eje X
                            }
                        }
                    }
                },
                plugins: [ChartDataLabels]
            });
        });
    </script>
</asp:Content>