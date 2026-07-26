using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaCotizacionPrestamos.Web.Usuarios
{
    public partial class ListaUsuarios : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        private void CargarUsuarios()
        {
            var usuarios = new List<dynamic>
            {
                new
                {
                    IdUsuario = 1,
                    NombreUsuario = "admin",
                    Correo = "admin@correo.com",
                    Rol = "Administrador"
                }
            };

            gvUsuarios.DataSource = usuarios;
            gvUsuarios.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "Usuario eliminado correctamente.";
            lblMensaje.CssClass = "mensaje-exito";
        }
    }
}