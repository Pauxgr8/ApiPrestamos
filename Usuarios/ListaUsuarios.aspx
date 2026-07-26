<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs"
    Inherits="SistemaCotizacionPrestamos.Web.Usuarios.ListaUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="tarjeta">
        <h1 class="titulo-pagina">Usuarios</h1>
        <p>Administración de usuarios registrados en el sistema.</p>

        <asp:HyperLink ID="lnkNuevoUsuario" runat="server"
            NavigateUrl="~/Usuarios/NuevoUsuario.aspx"
            CssClass="boton-principal">
            Nuevo Usuario
        </asp:HyperLink>
    </div>

    <div class="tarjeta">
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>

        <asp:GridView ID="gvUsuarios" runat="server"
            AutoGenerateColumns="False"
            CssClass="tabla"
            EmptyDataText="No hay usuarios registrados.">

            <Columns>
                <asp:BoundField DataField="IdUsuario" HeaderText="ID" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                <asp:BoundField DataField="Correo" HeaderText="Correo" />
                <asp:BoundField DataField="Rol" HeaderText="Rol" />

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEditar" runat="server"
                            Text="Editar"
                            CssClass="boton-principal"
                            NavigateUrl='<%# "~/Usuarios/EditarUsuario.aspx?id=" + Eval("IdUsuario") %>'>
                        </asp:HyperLink>

                        <asp:LinkButton ID="btnEliminar" runat="server"
                            Text="Eliminar"
                            CssClass="boton-secundario"
                            CommandArgument='<%# Eval("IdUsuario") %>'
                            OnClick="btnEliminar_Click"
                            OnClientClick="return confirm('¿Desea eliminar este usuario?');">
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>

</asp:Content>