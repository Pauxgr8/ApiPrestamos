<%@ Page Title="Editar Cliente" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="EditarCliente.aspx.cs"
    Inherits="SistemaCotizacionPrestamos.Web.Clientes.EditarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="tarjeta">
        <h1 class="titulo-pagina">Editar Cliente</h1>
        <p>Modifique la información del cliente.</p>

        <asp:Label ID="lblMensaje" runat="server"></asp:Label>

        <asp:HiddenField ID="hfIdCliente" runat="server" />

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
        </div>

        <asp:Button ID="btnGuardar" runat="server"
            Text="Guardar Cambios"
            CssClass="boton-principal"
            OnClick="btnGuardar_Click" />

        <asp:HyperLink ID="lnkCancelar" runat="server"
            NavigateUrl="~/Clientes/ListaClientes.aspx"
            CssClass="boton-secundario">
            Cancelar
        </asp:HyperLink>
    </div>

</asp:Content>