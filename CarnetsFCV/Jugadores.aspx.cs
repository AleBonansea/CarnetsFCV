using ClosedXML.Excel;
using Entidades;
using Entidades.Dto;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarnetsFCV
{
    public partial class Jugadores : System.Web.UI.Page
    {
        Logica.JugadorLOG jugador = new Logica.JugadorLOG();
        Logica.ClubLOG clubes = new Logica.ClubLOG();
        Logica.EquipoLOG equipos = new Logica.EquipoLOG();
        Logica.DivisionLOG division = new Logica.DivisionLOG();
        Logica.UsuarioLOG usuario = new Logica.UsuarioLOG();
        Logica.SexoLOG sexo = new Logica.SexoLOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            int rolId = Int32.Parse((string)Session["rolId"]);
            

            if (!IsPostBack)
            { 
                if (Session["rolId"] != null)
                {
                    CargarGrilla();
                    CargarClubes();

                }
                else
                {
                    Response.Redirect("Ingreso.aspx");
                }
                CargarDivisiones();
                CargarRamas();
                

                if (rolId == 2)
                {
                    CargarEquiposModal();
                    CargarSexosModal();
                }
                else
                {
                    btnAgregar.Disabled = true;
                    btnModificar.Disabled = true;
                    btnEliminar.Disabled = true;
                }

            }
        }

        private void CargarEquiposModal()
        {
            int clubId = Int32.Parse((string)Session["clubId"]);
            List<Entidades.Dto.EquipoDto> listaEquipos = equipos.getTotalEquipos(clubId);

            if (listaEquipos != null)
            {
                cmbEquiposModal.DataSource = listaEquipos;
                cmbEquiposModal.DataTextField = "NombreEquipo";
                cmbEquiposModal.DataValueField = "Id";
                cmbEquiposModal.DataBind();

                cmbModificarEquipo.DataSource = listaEquipos;
                cmbModificarEquipo.DataTextField = "NombreEquipo";
                cmbModificarEquipo.DataValueField = "Id";
                cmbModificarEquipo.DataBind();
            }
            else
            {
                List<EquipoDto> sinDivision = new List<EquipoDto>();
                List<ListItem> items = sinDivision.ConvertAll(d =>

                {
                    return new ListItem()
                    {
                        Text = "Sin Equipos",
                        Value = "1",
                        Selected = false
                    };
                });

                cmbEquiposModal.DataSource = items;
                cmbEquiposModal.DataBind();

                cmbModificarEquipo.DataSource = items;
                cmbModificarEquipo.DataBind();

            }
        }

        private void CargarSexosModal()
        {
            List<Sexos> sexos= sexo.getSexos();

            if (sexos != null)
            {
                List<ListItem> items = sexos.ConvertAll(d =>

                {
                    return new ListItem()
                    {
                        Text = d.Descripcion,
                        Value = d.Id.ToString(),
                        Selected = false
                    };
                });

                cmbSexoModal.DataSource = items;
                cmbSexoModal.DataBind();
            }
        }

        private void CargarRamas()
        {
        }

        private void CargarDivisiones()
        {

            List<DivisionDto> divisiones = division.getComboDivisiones(cmbClub.SelectedIndex +1, cmbRama.SelectedIndex +1);

            if (divisiones != null)
            {
            List<ListItem> items = divisiones.ConvertAll(d =>

            {
                return new ListItem()
                {
                    Text = d.Descripcion,
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            cmbDiv.DataSource = items;
            cmbDiv.DataBind();
            }
            else
            {
                List<DivisionDto> sinDivision = new List<DivisionDto>();
                List<ListItem> items = sinDivision.ConvertAll(d =>

                {
                    return new ListItem()
                    {
                        Text = "Sin Division",
                        Value = "1",
                        Selected = false
                    };
                });

                cmbDiv.DataSource = items;
                cmbDiv.DataBind();

            }
        }

        private void CargarEquipos(int clubId)
        {
            List<EquipoDto> listaEquipos = equipos.getComboEquipos();
            List<ListItem> items = listaEquipos.ConvertAll(e =>
            {
                return new ListItem()
                {
                    Text = e.NombreEquipo,
                    Value = e.Id.ToString(),
                    Selected = false
                };
            });


            cmbEquipo.DataSource = items;
            cmbEquipo.DataBind();
        }

        private void CargarClubes()
        {

            int rolId = Int32.Parse((string)Session["rolId"]);
            

            List<ClubDto> listaClubes = clubes.getComboClubes();


            List<ListItem> items = listaClubes.ConvertAll(c =>
            {
                return new ListItem()
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString(),
                    Selected = false
                };
            });

            cmbClub.DataSource = items;
            cmbClub.DataBind();

            if (rolId == 2)
            {
                int clubId = Int32.Parse((string)Session["clubId"]);
                cmbClub.SelectedIndex = clubId - 1;
            }
            else
            {
                cmbClub.SelectedIndex = 0;
            }
        }

        public void CargarGrilla()
        {
            int rolId = 2;

            if (rolId == 2)
            {
                int clubId = 1;
                gvJugadores.DataSource = jugador.getGVJugadores(clubId);
                gvJugadores.DataBind();
            }
            else
            {
                gvJugadores.DataSource = jugador.getGVJugadoresTotales();
                gvJugadores.DataBind();
            }
        }
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void cmbClub_SelectedIndexChanged1(object sender, EventArgs e)
        {
            cmbDiv.Enabled = true;
            CargarDivisiones();

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Response.Cookies.Clear();
            Response.Redirect("Ingreso.aspx");
        }

        protected void btnExportar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    int rolId = Int32.Parse((string)Session["rolId"]);

                    List<JugadorDto> listaJugadores = new List<JugadorDto>();

                    if (rolId == 2)
                    {
                        int clubId = Int32.Parse((string)Session["clubId"]);
                        listaJugadores = jugador.getGVJugadores(clubId);
                    }
                    else
                    {
                        listaJugadores = jugador.getGVJugadoresTotales();
                    }


                    var worksheet = workbook.Worksheets.Add("Jugadores");
                    worksheet.Cell("A1").InsertTable(listaJugadores);
                    worksheet.Cells("A1:M1").Style.Fill.BackgroundColor = XLColor.FromArgb(228, 79, 31);
                    worksheet.Columns(1, 13).AdjustToContents();
                    worksheet.Columns(1, 13).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    workbook.SaveAs(@"C:\FCV\Jugadores.xlsx");
                }
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El excel se ha descargado correctamente','','success')", true);
            }

            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El excel no pudo ser descargado','error')", true);
            }
        }

        protected void cmbEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEquiposModal.SelectedIndex = cmbEquiposModal.SelectedIndex;
        }
        protected void cmbMoficarEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbModificarEquipo.SelectedIndex = cmbModificarEquipo.SelectedIndex + 1;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int clubId = Int32.Parse((string)Session["clubId"]);

                int tamanioFoto = archivo.PostedFile.ContentLength;
                byte[] imagen = new byte[tamanioFoto];
                archivo.PostedFile.InputStream.Read(imagen, 0, tamanioFoto);

                int rolJugadorId = (int)RolesEnum.Jugador;


                var usuarioExistente = usuario.validarUsuario(rolJugadorId, txtDNI.Text);

                if (usuarioExistente is null)
                {
                    var usuarioJugador = new Entidades.Usuarios();

                    usuarioJugador.RolId = rolJugadorId;
                    usuarioJugador.NombreUsuario = txtDNI.Text;
                    usuarioJugador.Contraseña = txtDNI.Text;
                    usuarioJugador.PrimerIngreso = true;

                    usuario.crearUsuario(usuarioJugador);

                    var nuevoJugador = new Entidades.Jugadores();

                    nuevoJugador.UsuarioId = usuarioJugador.Id;
                    nuevoJugador.ClubId = clubId;
                    nuevoJugador.EquipoId = Int32.Parse((String)cmbEquiposModal.SelectedValue);
                    nuevoJugador.Nombre = txtNombre.Text;
                    nuevoJugador.Apellido = txtApellido.Text;
                    nuevoJugador.FechaNac = DateTime.Parse(txtFecNac.Text);
                    nuevoJugador.FechaEMMAC = DateTime.Parse(txtFecEMMAC.Text);
                    nuevoJugador.DNI = txtDNI.Text;
                    nuevoJugador.Email = txtEmail.Text;
                    nuevoJugador.Telefono = txtTel.Text;
                    nuevoJugador.SexoId = Int32.Parse((string)cmbSexoModal.SelectedValue);

                    nuevoJugador.Foto = imagen;
                    if (rdbSi.Checked)
                    {
                        nuevoJugador.Habilitado = true;
                    }
                    else
                    {
                        nuevoJugador.Habilitado = false;
                    }

                    jugador.guardarJugador(nuevoJugador);

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El jugador se ha registrado correctamente','','success')", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El jugador ya existe','','info')", true);
                }
                CargarGrilla();

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtFecNac.Text = "";
                txtFecEMMAC.Text = "";
                txtDNI.Text = "";
                txtEmail.Text = "";
                txtTel.Text = "";
                rdbNo.Checked = false;
                rdbSi.Checked = false;


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void modalModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["idJugadorSeleccionado"] != null)
                {
                    int idJugador = Int32.Parse((string)Session["idJugadorSeleccionado"]);

                    Entidades.Jugadores jugadorAModificar = jugador.getJugador(idJugador);

                    int tamanioFoto = archivoModificar.PostedFile.ContentLength;
                    byte[] imagen = new byte[tamanioFoto];
                    archivoModificar.PostedFile.InputStream.Read(imagen, 0, tamanioFoto);

                    jugadorAModificar.EquipoId = Int32.Parse((String)cmbModificarEquipo.SelectedValue) - 1;
                    jugadorAModificar.Nombre = txtModificarNombre.Text;
                    jugadorAModificar.Apellido = txtModificarApellido.Text;
                    jugadorAModificar.FechaNac = DateTime.Parse(txtModificarFecNac.Text);
                    jugadorAModificar.FechaEMMAC = DateTime.Parse(txtModificarFecEMMAC.Text);
                    jugadorAModificar.DNI = txtModificarDNI.Text;
                    jugadorAModificar.Email = txtModificarEmail.Text;
                    jugadorAModificar.Telefono = txtModificarTel.Text;
                    jugadorAModificar.SexoId = Int32.Parse((string)cmbModificarSexoModal.SelectedValue);

                    if (rdbModificarSi.Checked)
                    {
                        jugadorAModificar.Habilitado = true;
                    }
                    else
                    {
                        jugadorAModificar.Habilitado = false;
                    }

                    byte[] sinImagen = new byte[0];

                    if (imagen != sinImagen)
                    {
                        jugadorAModificar.Foto = imagen;
                    }


                    jugador.modificarJugador(jugadorAModificar);

                    CargarGrilla();

                    txtModificarNombre.Text = "";
                    txtModificarApellido.Text = "";
                    txtModificarFecNac.Text = "";
                    txtModificarFecEMMAC.Text = "";
                    txtModificarDNI.Text = "";
                    txtModificarEmail.Text = "";
                    txtModificarTel.Text = "";
                    rdbModificarSi.Checked = false;
                    rdbModificarNo.Checked = false;
                    archivoModificar = null;

                }

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El jugador se ha modificado correctamente','','success')", true);
            }
            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El jugador no se ha modificado','error')", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
           
                if (Session["idJugadorSeleccionado"] != null)
                {
                    int idJugador = Int32.Parse((string)Session["idJugadorSeleccionado"]);

                    jugador.eliminarJugador(idJugador);
                    CargarGrilla();


                    Session["ultimaFilaSeleccionada"] = null;

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                        "swal('El jugador se ha eliminado correctamente','','success')", true);
                }

           
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El jugador no se pudo eliminar. Compruebe haber seleccionado uno.','error')", true);
            
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int idFilaSeleccionada = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;


            if (Session["ultimaFilaSeleccionada"] != null)
            {
                int ultimaFilaSeleccionada = Int32.Parse((string)Session["ultimaFilaSeleccionada"]);

                if (idFilaSeleccionada != ultimaFilaSeleccionada)
                {
                    ((CheckBox)gvJugadores.Rows[ultimaFilaSeleccionada].Cells[0].FindControl("chk")).Checked = false;
                }
            }


            int idJugador = Int32.Parse(gvJugadores.Rows[idFilaSeleccionada].Cells[1].Text);

            Entidades.Jugadores jugadorAModificar = jugador.getJugador(idJugador);

            cmbModificarEquipo.SelectedValue = jugadorAModificar.EquipoId.ToString();
            txtModificarNombre.Text = jugadorAModificar.Nombre;
            txtModificarApellido.Text = jugadorAModificar.Apellido;
            txtModificarFecNac.Text = jugadorAModificar.FechaNac.ToString("yyyy-MM-dd");
            txtModificarFecEMMAC.Text = jugadorAModificar.FechaEMMAC.ToString("yyyy-MM-dd");
            txtModificarDNI.Text = jugadorAModificar.DNI;
            txtModificarEmail.Text = jugadorAModificar.Email;
            txtModificarTel.Text = jugadorAModificar.Telefono.ToString();

            if (jugadorAModificar.Habilitado)
            {
                rdbModificarSi.Checked = true;
                rdbModificarNo.Checked = false;
            }
            else
            {
                rdbModificarSi.Checked = false;
                rdbModificarNo.Checked = true;
            }

            Session["ultimaFilaSeleccionada"] = idFilaSeleccionada.ToString();
            Session["idJugadorSeleccionado"] = idJugador.ToString();
        }
    }
}