using ClosedXML.Excel;
using Entidades;
using Entidades.Dto;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        Logica.RamaLOG rama = new Logica.RamaLOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            int rolId = Int32.Parse((string)Session["rolId"]);
            

            if (!IsPostBack)
            { 
                if (Session["rolId"] != null)
                {
                    CargarGrilla();
                    CargarRamas();
                    CargarDivisiones();
                    txtDNI.Enabled = false;
                    txtNombre.Enabled = false;
                    txtApellido.Enabled = false;
                    txtFecNac.Enabled = false;
                    txtFecEMMAC.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTel.Enabled = false;
                    btnAgregar.Disabled = true;

                }
                else
                {
                    Response.Redirect("Ingreso.aspx");
                }
                

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
        private void CargarRamas()
        {
            int clubId = Int32.Parse((string)Session["clubId"]);

            List<Ramas> ramas = rama.getRamasPorClub(clubId);

            if (ramas != null)
            {
                cmbRama.DataSource = ramas;
                cmbRama.DataTextField = "Descripcion";
                cmbRama.DataValueField = "Id";
                cmbRama.DataBind();
            }
        }

        private void CargarDivisiones()
        {
            int clubId = Int32.Parse((string)Session["clubId"]);

            List<Divisiones> divisiones = division.getDivisionesPorClub(clubId);
            cmbDiv.Items.Clear();

            if (divisiones != null)
            {
                cmbDiv.DataSource = divisiones;
                cmbDiv.DataTextField = "Descripcion";
                cmbDiv.DataValueField = "Id";
                cmbDiv.DataBind();
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
                List<EquipoDto> sinEquipos = new List<EquipoDto>();
                sinEquipos.Add(new EquipoDto() { NombreEquipo = "Sin Equipos", Id = 0 }); // Asignamos el valor 0 para indicar que no hay equipos

                List<ListItem> items = sinEquipos.ConvertAll(d =>
                {
                    return new ListItem()
                    {
                        Text = d.NombreEquipo,
                        Value = d.Id.ToString(),
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
                cmbSexoModal.DataSource = sexos;
                cmbSexoModal.DataTextField = "Descripcion";
                cmbSexoModal.DataValueField= "Id";
                cmbSexoModal.DataBind();

                cmbModificarSexoModal.DataSource = sexos;
                cmbModificarSexoModal.DataTextField = "Descripcion";
                cmbModificarSexoModal.DataValueField = "Id";
                cmbModificarSexoModal.DataBind();
            }
        }

        public void CargarGrilla()
        {
            int rolId = 2;

            if (rolId == 2)
            {
                int clubId = Int32.Parse((string)Session["clubId"]);
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
            cmbModificarEquipo.SelectedIndex = cmbModificarEquipo.SelectedIndex;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var usuarioJugador = new Entidades.Usuarios();

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

                    usuarioJugador.RolId = rolJugadorId;
                    usuarioJugador.NombreUsuario = txtDNI.Text;
                    usuarioJugador.Contraseña = txtDNI.Text;
                    usuarioJugador.PrimerIngreso = true;

                    usuario.crearUsuario(usuarioJugador);

                    var nuevoJugador = new Entidades.Jugadores();

                    nuevoJugador.UsuarioId = usuarioJugador.Id;
                    nuevoJugador.ClubId = clubId;
                    nuevoJugador.EquipoId = 
                        Int32.Parse((String)cmbEquiposModal.SelectedValue);
                    nuevoJugador.Nombre = txtNombre.Text;
                    nuevoJugador.Apellido = txtApellido.Text;
                    nuevoJugador.FechaNac = DateTime.Parse(txtFecNac.Text);
                    nuevoJugador.FechaEMMAC = DateTime.Parse(txtFecEMMAC.Text);
                    nuevoJugador.DNI = txtDNI.Text;
                    nuevoJugador.Email = txtEmail.Text;
                    nuevoJugador.Telefono = txtTel.Text;
                    nuevoJugador.SexoId = Int32.Parse((string)cmbSexoModal.SelectedValue);

                    

                    nuevoJugador.Habilitado = false;
                    
                    jugador.guardarJugador(nuevoJugador);

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El jugador se ha registrado correctamente','','success')", true);
                }
                else
                {
                    usuario.EliminarUsuario(usuarioJugador.Id);
                    
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

                    jugadorAModificar.EquipoId = Int32.Parse((String)cmbModificarEquipo.SelectedValue);
                    jugadorAModificar.Nombre = txtModificarNombre.Text;
                    jugadorAModificar.Apellido = txtModificarApellido.Text;
                    jugadorAModificar.FechaNac = DateTime.Parse(txtModificarFecNac.Text);
                    jugadorAModificar.FechaEMMAC = DateTime.Parse(txtModificarFecEMMAC.Text);
                    jugadorAModificar.DNI = txtModificarDNI.Text;
                    jugadorAModificar.Email = txtModificarEmail.Text;
                    jugadorAModificar.Telefono = txtModificarTel.Text;
                    jugadorAModificar.SexoId = Int32.Parse((string)cmbModificarSexoModal.SelectedValue);


                    if (tamanioFoto != 0)
                    {
                        jugadorAModificar.Foto = imagen;
                    }
                    else
                    {
                        jugadorAModificar.Foto = null;
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

                var jugadorAEliminar = jugador.getJugador(idJugador);

                jugador.eliminarJugador(idJugador);

                usuario.EliminarUsuario(jugadorAEliminar.UsuarioId);

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
            cmbModificarSexoModal.SelectedValue = jugadorAModificar.SexoId.ToString();
            Session["ultimaFilaSeleccionada"] = idFilaSeleccionada.ToString();
            Session["idJugadorSeleccionado"] = idJugador.ToString();
        }

        protected void btnValidarDNI_Click(object sender, EventArgs e)
        {
            try
            {
                int tamanioFoto = archivo.PostedFile.ContentLength;
                byte[] imagen = new byte[tamanioFoto];
                archivo.PostedFile.InputStream.Read(imagen, 0, tamanioFoto);

                var user = usuario.getUsuarioByNombre(txtValidarDni.Text);

                if (user != null)
                {
                    txtNombre.Text = user.Nombre;
                    txtApellido.Text = user.Apellido;
                    txtFecNac.Text = user.FechaNac.ToString("yyyy-MM-dd");
                    txtFecEMMAC.Text = user.FechaEMMAC.ToString("yyyy-MM-dd");
                    txtDNI.Text = user.DNI;
                    txtEmail.Text = user.Email;
                    txtTel.Text = user.Telefono;
                    archivo.PostedFile.InputStream.Read(user.Foto, 0, tamanioFoto);


                    btnAgregar.Disabled = false;


                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                        "swal('Se han encontrado datos para el DNI seleccionado y se han cargado. Ingrese al formulario Agregar.','','success')", true);

                }
                else
                {
                    txtNombre.Enabled = true;
                    txtApellido.Enabled = true;
                    txtFecNac.Enabled = true;
                    txtFecEMMAC.Enabled = true;
                    txtDNI.Enabled = true;
                    txtEmail.Enabled = true;
                    txtTel.Enabled = true;
                    txtDNI.Enabled = true;

                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtFecNac.Text = "";
                    txtFecEMMAC.Text = "";
                    txtDNI.Text = txtValidarDni.Text;
                    txtEmail.Text = "";
                    txtTel.Text = "";

                    btnAgregar.Disabled = false;

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                        "swal('El DNI ingresado no existe. Ingrese al formulario Agregar.','','info')", true);
                }
            }
            catch
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                        "swal('El usuario tiene problema de datos, comuniquese con su proveedor.','','error')", true);
            }
        }

        protected void ModalCancelar_click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtFecNac.Text = "";
            txtFecEMMAC.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtFecNac.Enabled = false;
            txtFecEMMAC.Enabled = false;
            txtEmail.Enabled = false;
            txtTel.Enabled = false;
            txtDNI.Enabled = false;

            btnAgregar.Disabled = true;
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            int clubId = Int32.Parse((string)Session["clubId"]);
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                gvJugadores.DataSource = jugador.getBuscadorJugadores(txtBuscar.Text, clubId);
                gvJugadores.DataBind();
            }
            else
            {
                CargarGrilla();
            }
        }

        protected void gvJugadores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Encuentra el control de imagen
                Image imgHabilitado = (Image)e.Row.FindControl("imgHabilitado");

                // Obtén el valor del campo Habilitado
                bool habilitado = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Habilitado"));

                // Asigna la imagen correspondiente según el valor del campo Habilitado
                if (habilitado)
                {
                    imgHabilitado.ImageUrl = "~/Imagenes/habilitado.png"; // Ruta a la imagen para habilitado
                    imgHabilitado.AlternateText = "Habilitado";
                }
                else
                {
                    imgHabilitado.ImageUrl = "~/Imagenes/no_habilitado.png"; // Ruta a la imagen para no habilitado
                    imgHabilitado.AlternateText = "No habilitado";
                }
            }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            var equipoId = Int32.Parse((String)cmbEquipo.SelectedValue);
            List<Entidades.Dto.JugadorDto> jugadoresEquipo = jugador.GetJugadoresEquipo(equipoId);

            if (jugadoresEquipo != null)
            {
                gvJugadores.Visible = true;
                gvJugadores.DataSource = jugadoresEquipo;
                gvJugadores.DataBind();
            }
        }

        protected void btnFiltros_Click(object sender, EventArgs e)
        {
            int clubId = Int32.Parse((string)Session["clubId"]);
            var divisionId = Int32.Parse((String)cmbDiv.SelectedValue);
            var ramaId = Int32.Parse((String)cmbRama.SelectedValue);

            List<Entidades.Equipos> listaEquipos = equipos.GetEquiposHabilitaciones(clubId, divisionId, ramaId);

            cmbEquipo.Items.Clear();

            if (listaEquipos.Any())
            {
                cmbEquipo.DataSource = listaEquipos;
                cmbEquipo.DataTextField = "Nombre";
                cmbEquipo.DataValueField = "Id";
                cmbEquipo.DataBind();
                lblEquipos.Visible = true;
                btnSeleccionar.Visible = true;
                cmbEquipo.Visible = true;
            }
            else
            {
                lblEquipos.Visible = false;
                btnSeleccionar.Visible = false;
                cmbEquipo.Visible = false;
                gvJugadores.Visible = false;

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('No existen equipos para el filtro seleccionado.','','info')", true);
            }
        }

        protected void LimpiarFiltros_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrilla();
            CargarRamas();
            CargarDivisiones();
            txtDNI.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtFecNac.Enabled = false;
            txtFecEMMAC.Enabled = false;
            txtEmail.Enabled = false;
            txtTel.Enabled = false;
            btnAgregar.Disabled = true;

            cmbDiv.SelectedIndex = 0;
            cmbRama.SelectedIndex = 0;
        }
    }
}