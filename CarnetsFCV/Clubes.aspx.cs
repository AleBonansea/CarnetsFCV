using Entidades.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarnetsFCV
{
    public partial class Clubes : System.Web.UI.Page
    {
        Logica.ClubLOG clubes = new Logica.ClubLOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Server.Transfer("Menu.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Response.Cookies.Clear();
            Response.Redirect("Ingreso.aspx");
        }

        public void CargarGrilla()
        {           
            gvClubes.DataSource = clubes.getTotalClubes();
            gvClubes.DataBind();
        }
                

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                gvClubes.DataSource = clubes.getBuscadorClubes(txtBuscar.Text);
                gvClubes.DataBind();
            }
            else
            {
                CargarGrilla();
            }
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {

        }
        protected void btnExportar_Click(object sender, ImageClickEventArgs e)
        {
            //try
            //{
            //    using (var workbook = new XLWorkbook())
            //    {
            //        int clubId = Int32.Parse((string)Session["clubId"]);

            //        List<EquipoDto> listaEquipos = equipo.getTotalEquipos(clubId);

            //        var worksheet = workbook.Worksheets.Add("Entrenadores");
            //        worksheet.Cell("A1").InsertTable(listaEquipos);
            //        worksheet.Cells("A1:F1").Style.Fill.BackgroundColor = XLColor.FromArgb(228, 79, 31);
            //        worksheet.Columns(1, 5).AdjustToContents();
            //        worksheet.Columns(1, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            //        workbook.SaveAs(@"C:\FCV\Equipos.xlsx");
            //    }
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
            //        "swal('El excel se ha descargado correctamente','','success')", true);
            //}

            //catch (Exception)
            //{
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
            //        "swal('Error','El excel no pudo ser descargado','error')", true);
            //}
        }
    }
}