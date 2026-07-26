using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaCotizacionPrestamos.Web.Clientes
{
    public partial class EditarCliente : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hfIdCliente.Value = Request.QueryString["id"];

                txtNombre.Text = "Kevin";
                txtApellido.Text = "Hernández";
                txtCorreo.Text = "kevin@correo.com";
                txtTelefono.Text = "8888-8888";
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "Cliente actualizado correctamente.";
            lblMensaje.CssClass = "mensaje-exito";
        }
    }
}