using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SistemaCotizacionPrestamos.Web.Usuarios
{
    public partial class NuevoUsuario : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlRol.Items.Clear();
                ddlRol.Items.Add("-- Seleccione --");
                ddlRol.Items.Add("Administrador");
                ddlRol.Items.Add("Consultor");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                ddlRol.SelectedIndex == 0)
            {
                lblMensaje.Text = "Debe completar todos los campos obligatorios.";
                lblMensaje.CssClass = "mensaje-error";
                return;
            }

            lblMensaje.Text = "Usuario registrado correctamente.";
            lblMensaje.CssClass = "mensaje-exito";
        }
    }
}