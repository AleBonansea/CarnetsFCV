using Entidades.Enums;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CarnetsFCV
{
    public partial class Carnets : System.Web.UI.Page
    {
        Logica.UsuarioLOG usuario = new Logica.UsuarioLOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            int rolId = Int32.Parse((string)Session["rolId"]);

            string nombreUsuario = Session["usuario"].ToString();


            if (rolId.Equals(RolesEnum.Jugador))
            {
                lblClub.Visible=true;
                lblClubJugador.Visible = true;
                lblSexoTit.Visible = true;
                lblSexo.Visible = true;
            }

            var datosCarnet = usuario.getCarnet(nombreUsuario, rolId);

            byte[] foto = datosCarnet.Foto;

            llenarCarnet(datosCarnet, rolId);
            cargarFoto(foto);

                // Concateno los datos
                string contenidoCarnet = 
                "Nombre: " +datosCarnet.Nombre + Environment.NewLine +
                "Apellido: "+datosCarnet.Apellido + Environment.NewLine + 
                "DNI: "+datosCarnet.DNI + Environment.NewLine +
                "Fecha Nacimiento: "+datosCarnet.FechaNac.ToString("dd-MM-yyyy") + Environment.NewLine +
                "Fecha EMMAC: "+datosCarnet.FechaEMMAC.ToString("dd-MM-yyyy") + Environment.NewLine +
                "Habilitado: "+datosCarnet.Habilitado + Environment.NewLine +
                "Rol: " + datosCarnet.NombreRol;

            // Generar el código QR a partir del contenido del div
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(contenidoCarnet, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                using (Bitmap qrCodeImage = qrCode.GetGraphic(4))
                {
                    qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    string base64Image = Convert.ToBase64String(byteImage);
                    imgQRCode.ImageUrl = "data:image/png;base64," + base64Image;
                }
            }
        }

        private void llenarCarnet(Entidades.Dto.UsuarioDto datosCarnet, int rolId)
        {
            lblNombre.Text = datosCarnet.Nombre;
            lblApellido.Text = datosCarnet.Apellido;
            lblFecNac.Text = datosCarnet.FechaNac.ToString("dd-MM-yyyy");
            lblDNI.Text = datosCarnet.DNI;
            lblRol.Text = datosCarnet.NombreRol;
            lblEMMAC.Text = datosCarnet.FechaEMMAC.ToString("dd-MM-yyyy");
            
            if (datosCarnet.Habilitado)
            {
                lblHabilitado.Text = "Si";
            }
            else
            {
                lblHabilitado.Text = "No";
            }
            
            if (rolId == (int)RolesEnum.Jugador)
            {
                lblSexo.Text = datosCarnet.Sexo;
                lblClubJugador.Text = datosCarnet.Club;
            }
        }

        private void cargarFoto(byte[] foto)
        {
            string base64Imagen = Convert.ToBase64String(foto);

            imgFoto.ImageUrl = "data:image/jpeg;base64," + base64Imagen;
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}