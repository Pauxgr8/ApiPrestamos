<%@ Page Title="Nuevo Usuario" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="NuevoUsuario.aspx.cs"
    Inherits="SistemaCotizacionPrestamos.Web.Usuarios.NuevoUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="tarjeta">
        <h1 class="titulo-pagina">Nuevo Usuario</h1>
        <p>Complete la información del usuario.</p>

        <asp:Label ID="lblMensaje" runat="server"></asp:Label>

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
                <label class="etiqueta">Contraseña</label>
                <asp:TextBox ID="txtContrasena" runat="server" CssClass="campo" TextMode="Password"></asp:TextBox>
            </div>

            <div>
                <label class="etiqueta">Rol</label>
                <asp:DropDownList ID="ddlRol" runat="server" CssClass="campo"></asp:DropDownList>
            </div>
        </div>

        <asp:Button ID="btnGuardar" runat="server"
            Text="Guardar"
            CssClass="boton-principal"
            OnClick="btnGuardar_Click" />

        <asp:HyperLink ID="lnkCancelar" runat="server"
            NavigateUrl="~/Usuarios/ListaUsuarios.aspx"
            CssClass="boton-secundario">
            Cancelar
        </asp:HyperLink>
    </div>

</asp:Content>