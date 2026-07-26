<%@ Page Title="Nuevo Cliente" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="NuevoCliente.aspx.cs"
    Inherits="SistemaCotizacionPrestamos.Web.Clientes.NuevoCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="tarjeta">
        <h1 class="titulo-pagina">Nuevo Cliente</h1>
        <p>Complete la información del cliente.</p>

        <asp:Label ID="lblMensaje" runat="server"></asp:Label>

        <div class="form-grid">
            <div>
                <label class="etiqueta">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="campo"></asp:TextBox>
            </div>

            <div>
                <label class="etiqueta">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="campo"></asp:TextBox>
            </div>

            <div>
                <label class="etiqueta">Correo</label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="campo" TextMode="Email"></asp:TextBox>
            </div>

            <div>
                <label class="etiqueta">Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="campo"></asp:TextBox>
            </div>

            <div>
                <label class="etiqueta">Género</label>
                <asp:DropDownList ID="ddlGenero" runat="server" CssClass="campo"></asp:DropDownList>
            </div>

            <div>
                <label class="etiqueta">Nivel educativo</label>
                <asp:DropDownList ID="ddlNivelEducativo" runat="server" CssClass="campo"></asp:DropDownList>
            </div>

            <div>
                <label class="etiqueta">Rango de edad</label>
                <asp:DropDownList ID="ddlRangoEdad" runat="server" CssClass="campo"></asp:DropDownList>
            </div>

            <div>
                <label class="etiqueta">Rango de ingresos</label>
                <asp:DropDownList ID="ddlRangoIngresos" runat="server" CssClass="campo"></asp:DropDownList>
            </div>
        </div>

        <br />

        <asp:Button ID="btnGuardar" runat="server"
            Text="Guardar"
            CssClass="boton-principal"
            OnClick="btnGuardar_Click" />

        <asp:HyperLink ID="lnkCancelar" runat="server"
            NavigateUrl="~/Clientes/ListaClientes.aspx"
            CssClass="boton-secundario">
            Cancelar
        </asp:HyperLink>

    </div>

</asp:Content>