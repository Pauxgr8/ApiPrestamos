using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaCotizacionPrestamos.Web.Clientes
{
    public partial class NuevoCliente : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCatalogos();
            }
        }

        private void CargarCatalogos()
        {
            ddlGenero.Items.Clear();
            ddlGenero.Items.Add("-- Seleccione --");
            ddlGenero.Items.Add("Masculino");
            ddlGenero.Items.Add("Femenino");
            ddlGenero.Items.Add("Otro");

            ddlNivelEducativo.Items.Clear();
            ddlNivelEducativo.Items.Add("-- Seleccione --");
            ddlNivelEducativo.Items.Add("Primaria");
            ddlNivelEducativo.Items.Add("Secundaria");
            ddlNivelEducativo.Items.Add("Universitario");

            ddlRangoEdad.Items.Clear();
            ddlRangoEdad.Items.Add("-- Seleccione --");
            ddlRangoEdad.Items.Add("18 a 25 años");
            ddlRangoEdad.Items.Add("26 a 35 años");
            ddlRangoEdad.Items.Add("36 a 50 años");

            ddlRangoIngresos.Items.Clear();
            ddlRangoIngresos.Items.Add("-- Seleccione --");
            ddlRangoIngresos.Items.Add("Menos de ₡300.000");
            ddlRangoIngresos.Items.Add("₡300.000 a ₡600.000");
            ddlRangoIngresos.Items.Add("Más de ₡600.000");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                ddlGenero.SelectedIndex == 0 ||
                ddlNivelEducativo.SelectedIndex == 0 ||
                ddlRangoEdad.SelectedIndex == 0 ||
                ddlRangoIngresos.SelectedIndex == 0)
            {
                lblMensaje.Text = "Debe completar todos los campos obligatorios.";
                lblMensaje.CssClass = "mensaje-error";
                return;
            }

            lblMensaje.Text = "Cliente registrado correctamente.";
            lblMensaje.CssClass = "mensaje-exito";
        }
    }
}