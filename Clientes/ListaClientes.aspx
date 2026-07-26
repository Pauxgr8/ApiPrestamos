<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ListaClientes.aspx.cs"
    Inherits="SistemaCotizacionPrestamos.Web.Clientes.ListaClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="tarjeta">
        <h1 class="titulo-pagina">Clientes</h1>

        <p>
            Administración de clientes registrados en el sistema.
        </p>

        <asp:HyperLink ID="lnkNuevoCliente" runat="server"
            NavigateUrl="~/Clientes/NuevoCliente.aspx"
            CssClass="boton-principal">
            Nuevo Cliente
        </asp:HyperLink>
    </div>

    <div class="tarjeta">

        <asp:Label ID="lblMensaje" runat="server"></asp:Label>

        <asp:GridView ID="gvClientes" runat="server"
            AutoGenerateColumns="False"
            CssClass="tabla"
            EmptyDataText="No hay clientes registrados.">

            <Columns>
                <asp:BoundField DataField="IdCliente" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Correo" HeaderText="Correo" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEditar" runat="server"
                            Text="Editar"
                            CssClass="boton-principal"
                            NavigateUrl='<%# "~/Clientes/EditarCliente.aspx?id=" + Eval("IdCliente") %>'>
                        </asp:HyperLink>

                        <asp:LinkButton ID="btnEliminar" runat="server"
                            Text="Eliminar"
                            CssClass="boton-secundario"
                            CommandArgument='<%# Eval("IdCliente") %>'
                            OnClick="btnEliminar_Click"
                            OnClientClick="return confirm('¿Desea eliminar este cliente?');">
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>

    </div>

</asp:Content>