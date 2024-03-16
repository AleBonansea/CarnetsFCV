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


            if (rolId.Equals((int)RolesEnum.Jugador))
            {
                lblClub.Visible=true;
                lblClubJugador.Visible = true;
                lblSexoTit.Visible = true;
                lblSexo.Visible = true;
            }

            var datosCarnet = usuario.getCarnet(nombreUsuario, rolId);

            byte[] foto = datosCarnet.Foto;

            llenarCarnet(datosCarnet, rolId);
            
            if (foto != null)
            {
                cargarFoto(foto);
            }
            else
            {
                cargarImagenPredeterminada();
            }

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

        private void cargarImagenPredeterminada()
        {
            string rutaImagenPredeterminada = Server.UrlPathEncode("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAM1BMVEXk5ueutLeqsbTn6eqpr7PJzc/j5ebf4eLZ3N2wtrnBxsjN0NLGysy6v8HT1tissra8wMNxTKO9AAAFDklEQVR4nO2d3XqDIAxAlfivoO//tEOZWzvbVTEpic252W3PF0gAIcsyRVEURVEURVEURVEURVEURVEURVEURVEURVEURflgAFL/AirAqzXO9R7XNBVcy9TbuMHmxjN6lr92cNVVLKEurVfK/zCORVvW8iUBnC02dj+Wpu0z0Y6QlaN5phcwZqjkOkK5HZyPAjkIjSO4fIdfcOwFKkJlX4zPu7Ha1tIcwR3wWxyFhRG6g4Je0YpSPDJCV8a2Sv2zd1O1x/2WMDZCwljH+clRrHfWCLGK8REMiql//2si5+DKWKcWeAGcFMzzNrXC/0TUwQ2s6+LhlcwjTMlYsUIQzPOCb7YBiyHopyLXIEKPEkI/TgeuiidK/R9FniUDOjRDpvm0RhqjMyyXNjDhCfIMYl1gGjIMIuYsnGEYRMRZOMMunaLVwpWRW008v6fYKDIzxCwVAeNSO90BJW6emelYBRF/kHpYGVaoxTDAaxOFsfP9y8hpJ4xd7gOcij7JNGQ1EYFgkPJa1jQEiYZXRaRINKxSDUW9n+FT82lSKadkiru9/4XPqSLWOekGPoY05TAvLm9orm+YWuwHoBHkZKijNBJGmeb61eL6Ff/6q7bLr7yvv3vKGhpDRjvgjGaPz+gUg6YgcvpyAR2FIZ9U6nEEyZRTovmEU32KichpGn7C17XrfyH9gK/c0CMP05HZIM2uf9sEveizKveBy9/6Qt7o89ne33D525cfcIMW6ab+TMEukQbQbu+xu7X3A9bChmWaCeAkG17bpntwXgWxHaMzGPmUaR5dQZiKqRVeUZ3047fi3nAu28h4CHxCsZAgmEH8Y27jJAhm8c+5RQzRQNVGhVFSfxOYIjp/pP7RxzjevYXVGf4eLt+BJ1vCuLuLkrgABgCGXZ2wik5uty+oBvNirI6mkzhAf4Gsb58Hcm67Jzd+KwD10BYPLL3e0MjvKrgAULnOfveF/O4N2Xb9BZom3gJes3F9X5Zze8/6Yt09b4CrqsEjUv8oFBaR2rl+6CZr2xVrp24o/WitBKuGrrpl1+bFkmK2qXTON4VpbdfLa7o7y/WdLxG7lm2Lqh2clOwTegbvc/vj2U78CwhA87Bn8G5Nk3eOb0Nsr9flz3sG78UUtue4kpv1xvjg3TMay62BMlTlP+vrOMnJsRmt/ze0jsfkPPYdAH57hK+34PeOyc8XIXu5xT2HsUkdZz+adwg8HGFfQ3K5jtDvbUiO4Di9/ywHGrL88pDizZ++oTp+an+SMX/ndymUCwmHMdO7yuOx83pUx/eEMU0AvxWndwgidAqOZ8ypCwdEfvvEo6D9HwpA8wzvmOJEqAg9ySu8g4x0Hb9hSB/BANEKJ+LbPBU0lzbAJs4xt1AoshKkUGQmiH8/jJ0gdhTTLmSegHlPE0oOdXALnqDjKYh3px//fSgSWG8UqfrrIICzYYSJXRr9BSPbpNzw7gBjKjKOYI7ReIGqQRIap5+5MdjyvuDkExvGeXSlONWZAP3/AZBwJohU7QJRGU+cTVH18ELmRPNBmibW6MT/k1b0XhdkRBvyT6SB6EYv/GvhSmRNpGngRULsAlxMCGNXp7w3FfdEbTEEDdLI9TdIKRUzUesa3I461ER8cpNT7gMRhpKmYVS9ELOgCUQsa4SsulciKiLbY+AnHD8cpuhISsnxpamI84sbDq9qYJgf8wiiOBrC7Ml7M7ZECCqKoiiKoiiKoiiKoijv5AvJxlZRyNWWLwAAAABJRU5ErkJggg==");
            imgFoto.ImageUrl = rutaImagenPredeterminada;
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