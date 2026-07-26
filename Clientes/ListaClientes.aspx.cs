using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaCotizacionPrestamos.Web.Clientes
{
    public partial class ListaClientes : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        private void CargarClientes()
        {
            var clientes = new List<dynamic>
            {
                new
                {
                    IdCliente = 1,
                    Nombre = "Kevin",
                    Apellido = "Hernández",
                    Correo = "kevin@correo.com",
                    Telefono = "8888-8888"
                }
            };

            gvClientes.DataSource = clientes;
            gvClientes.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "Cliente eliminado correctamente.";
            lblMensaje.CssClass = "mensaje-exito";
        }
    }
}