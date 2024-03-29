﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarnetsFCV
{
    public partial class Ingreso : System.Web.UI.Page
    {
        Logica.UsuarioLOG objLogica = new Logica.UsuarioLOG();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void getUsuarios()
        {
            var usuario = objLogica.getUsuarios(txtContraseña.Text, txtUsuario.Text);
            
            if (usuario != null)
            {
                Session["usuarioId"] = usuario.Id.ToString();
                Session["clubId"] = usuario.ClubId.ToString();
                Session["rolId"] = usuario.RolId.ToString();
                Session["usuario"] = usuario.NombreUsuario.ToString();
                
                if (usuario.PrimerIngreso == true)
                {
                    Response.Redirect("CambioContraseña.aspx");
                }
                else 
                {
                    Response.Redirect("Menu.aspx");
                }
            }
            else
            {
                lblError.Text = "El Usuario o la Contraseña son incorrectos";
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            getUsuarios();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtContraseña.Text = "";
            txtUsuario.Text = "";
            lblError.Text = "";
        }
    }
}