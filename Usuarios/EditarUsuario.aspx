<%@ Page Title="Editar Usuario" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs"
    Inherits="SistemaCotizacionPrestamos.Web.Usuarios.EditarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="tarjeta">
        <h1 class="titulo-pagina">Editar Usuario</h1>
        <p>Modifique la información del usuario.</p>

        <asp:Label ID="lblMensaje" runat="server"></asp:Label>

        <asp:HiddenField ID="hfIdUsuario" runat="server" />

        <div class="form-grid">
            <div>
                <label class="etiqueta">Nombre de usuario</label>
                <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="campo"></asp:TextBox>
            </div>

            <div>
                <label class="etiqueta">Correo</label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="campo" TextMode="Email"></asp:TextBox>
            </div>

            <div>
                <label class="etiqueta">Nueva contraseña</label>
                <asp:TextBox ID="txtContrasena" runat="server" CssClass="campo" TextMode="Password"></asp:TextBox>
            </div>

            <div>
                <label class="etiqueta">Rol</label>
                <asp:DropDownList ID="ddlRol" runat="server" CssClass="campo"></asp:DropDownList>
            </div>
        </div>

        <asp:Button ID="btnGuardar" runat="server"
            Text="Guardar Cambios"
            CssClass="boton-principal"
            OnClick="btnGuardar_Click" />

        <asp:HyperLink ID="lnkCancelar" runat="server"
            NavigateUrl="~/Usuarios/ListaUsuarios.aspx"
            CssClass="boton-secundario">
            Cancelar
        </asp:HyperLink>
    </div>

</asp:Content>