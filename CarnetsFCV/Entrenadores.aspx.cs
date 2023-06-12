﻿using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarnetsFCV
{
    public partial class Entrenadores : System.Web.UI.Page
    {
        Logica.EntrenadorLOG entrenador = new Logica.EntrenadorLOG();
        Logica.UsuarioLOG usuario = new Logica.UsuarioLOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["rolId"] != null)
                {
                    CargarGrilla();

                }
                else
                {
                    Response.Redirect("Ingreso.aspx");
                }

            }
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
            gvEntrenadores.DataSource = entrenador.getTotalEntrenadores();
            gvEntrenadores.DataBind();
        }


        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            int clubId = Int32.Parse((string)Session["clubId"]);
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                gvEntrenadores.DataSource = entrenador.getBuscadorEntrenadores(txtBuscar.Text);
                gvEntrenadores.DataBind();
            }
            else
            {
                CargarGrilla();
            }
        }

        protected void modalGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int tamanioFoto = archivo.PostedFile.ContentLength;
                byte[] imagen = new byte[tamanioFoto];
                archivo.PostedFile.InputStream.Read(imagen, 0, tamanioFoto);

                int rolEntrenadorId = (int)RolesEnum.Entrenador;


                var usuarioExistente = usuario.validarUsuario(rolEntrenadorId, txtDNI.Text);

                if (usuarioExistente is null)
                {
                    var usuarioEntrenador = new Entidades.Usuarios();

                    usuarioEntrenador.RolId = rolEntrenadorId;
                    usuarioEntrenador.NombreUsuario = txtDNI.Text;
                    usuarioEntrenador.Contraseña = txtDNI.Text;

                    usuario.crearUsuarioEntrenador(usuarioEntrenador);

                    var nuevoEntrenador = new Entidades.Entrenadores();

                    nuevoEntrenador.UsuarioId = usuarioEntrenador.Id;
                    nuevoEntrenador.Nombre = txtNombre.Text;
                    nuevoEntrenador.Apellido = txtApellido.Text;
                    nuevoEntrenador.FechaNac = DateTime.Parse(txtFecNac.Text);
                    nuevoEntrenador.FechaEMMAC = DateTime.Parse(txtFecEMMAC.Text);
                    nuevoEntrenador.DNI = txtDNI.Text;
                    nuevoEntrenador.Email = txtEmail.Text;
                    nuevoEntrenador.Telefono = Int32.Parse((String)txtTel.Text);
                    nuevoEntrenador.Foto = imagen;
                    nuevoEntrenador.Habilitado = true;

                    entrenador.guardarEntrenador(nuevoEntrenador);

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El entrenador se ha registrado correctamente','','success')", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El entrenador ya existe','','info')", true);
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
                rdbSi.Checked = true;

                
            }
            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El entrenador no ha registrado correctamente','error')", true);                
            }

        }

        protected void modalModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["idEntrenadorSeleccionado"] != null)
                {
                    int idEntrenador = Int32.Parse((string)Session["idEntrenadorSeleccionado"]);

                    Entidades.Entrenadores entrenadorAModificar = entrenador.getEntrenador(idEntrenador);

                    int tamanioFoto = archivoModificar.PostedFile.ContentLength;
                    byte[] imagen = new byte[tamanioFoto];
                    archivo.PostedFile.InputStream.Read(imagen, 0, tamanioFoto);

                    entrenadorAModificar.Nombre = txtModificarNombre.Text;
                    entrenadorAModificar.Apellido = txtModificarApellido.Text;
                    entrenadorAModificar.FechaNac = DateTime.Parse(txtModificarFecNac.Text);
                    entrenadorAModificar.FechaEMMAC = DateTime.Parse(txtModificarFecEMMAC.Text);
                    entrenadorAModificar.DNI = txtModificarDNI.Text;
                    entrenadorAModificar.Email = txtModificarEmail.Text;
                    entrenadorAModificar.Telefono = Int32.Parse((String)txtModificarTel.Text);
                    if (rdbModificarSi.Checked)
                    {
                        entrenadorAModificar.Habilitado = true;
                    }
                    else
                    {
                        entrenadorAModificar.Habilitado = false;
                    }

                    byte[] sinImagen = new byte[0];

                    if (imagen.Equals(sinImagen))
                    {
                        entrenadorAModificar.Foto = imagen;
                    }


                    entrenador.modificarEntrenador(entrenadorAModificar);

                    CargarGrilla();

                    txtModificarNombre.Text = "";
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
                    "swal('El equipo se ha modificado correctamente','','success')", true);
            }
            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El equipo no se ha modificado','error')", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["idEntrenadorSeleccionado"] != null)
                {
                    int idEntrenador = Int32.Parse((string)Session["idEntrenadorSeleccionado"]);

                    entrenador.eliminarEntrenador(idEntrenador);
                    CargarGrilla();


                    Session["ultimaFilaSeleccionada"] = null;
                }

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('El entrenador se ha eliminado correctamente','','success')", true);
            }
            catch (Exception)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Error','El entrenador no se pudo eliminar','error')", true);
            }
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int idFilaSeleccionada = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;


            if (Session["ultimaFilaSeleccionada"] != null)
            {
                int ultimaFilaSeleccionada = Int32.Parse((string)Session["ultimaFilaSeleccionada"]);

                if (idFilaSeleccionada != ultimaFilaSeleccionada)
                {
                    ((CheckBox)gvEntrenadores.Rows[ultimaFilaSeleccionada].Cells[0].FindControl("chk")).Checked = false;
                }
            }


            int idEntrenador = Int32.Parse(gvEntrenadores.Rows[idFilaSeleccionada].Cells[1].Text);

            Entidades.Entrenadores entrenadorAModificar = entrenador.getEntrenador(idEntrenador);


            txtModificarNombre.Text = entrenadorAModificar.Nombre;
            txtModificarApellido.Text = entrenadorAModificar.Apellido;
            txtModificarFecNac.Text = entrenadorAModificar.FechaNac.ToString("yyyy-MM-dd");
            txtModificarFecEMMAC.Text = entrenadorAModificar.FechaEMMAC.ToString("yyyy-MM-dd");
            txtModificarDNI.Text = entrenadorAModificar.DNI;
            txtModificarEmail.Text = entrenadorAModificar.Email;
            txtModificarTel.Text = entrenadorAModificar.Telefono.ToString();

            if (entrenadorAModificar.Habilitado)
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
            Session["idEntrenadorSeleccionado"] = idEntrenador.ToString();
        }
    }
}