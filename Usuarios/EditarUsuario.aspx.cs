using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaCotizacionPrestamos.Web.Usuarios
{
    public partial class EditarUsuario : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hfIdUsuario.Value = Request.QueryString["id"];

                ddlRol.Items.Clear();
                ddlRol.Items.Add("-- Seleccione --");
                ddlRol.Items.Add("Administrador");
                ddlRol.Items.Add("Consultor");

                txtNombreUsuario.Text = "admin";
                txtCorreo.Text = "admin@correo.com";
                ddlRol.SelectedIndex = 1;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                ddlRol.SelectedIndex == 0)
            {
                lblMensaje.Text = "Debe completar los campos obligatorios.";
                lblMensaje.CssClass = "mensaje-error";
                return;
            }

            lblMensaje.Text = "Usuario actualizado correctamente.";
            lblMensaje.CssClass = "mensaje-exito";
        }
    }
}