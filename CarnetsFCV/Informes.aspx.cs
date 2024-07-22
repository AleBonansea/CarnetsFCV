using Entidades.Dto;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace CarnetsFCV
{
    public partial class Informes : System.Web.UI.Page
    {
        Logica.HabilitacionLOG habilitacion = new Logica.HabilitacionLOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Agregar ítems al DropDownList
                cmbEquipo.Items.Add(new ListItem("General", "General"));
                cmbEquipo.Items.Add(new ListItem("Femenino", "Femenino"));
                cmbEquipo.Items.Add(new ListItem("Masculino", "Masculino"));

                // Seleccionar el ítem "General"
                cmbEquipo.SelectedValue = "General";

                cargarInformeGeneral();
                
            }
        }


        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void cmbEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbEquipo.SelectedIndex)
            {
                case 0:
                    cargarInformeGeneral();
                        break;

                case 1:
                    cargarInformeFemenino();
                    break;

                case 2:
                    cargarInformeMasculino();
                    break;
            }
        }

        private void cargarInformeMasculino()
        {
            var habilitados = habilitacion.GetHabilitadosMasculinos();

            EnviarDatosACuadro(habilitados);
        }

        private void cargarInformeFemenino()
        {
            var habilitados = habilitacion.GetHabilitadosFemeninos();

            EnviarDatosACuadro(habilitados);
        }
        private void cargarInformeGeneral()
        {
            var habilitados = habilitacion.GetHabilitadosTotales();

            EnviarDatosACuadro(habilitados);
        }

        private void EnviarDatosACuadro(List<HabilitadosPorAnoDto> habilitados)
        {
            // Convertir los datos a JSON
            var jsonData = new JavaScriptSerializer().Serialize(habilitados);

            // Pasar los datos al HiddenField
            hfData.Value = jsonData;
        }
    }
}