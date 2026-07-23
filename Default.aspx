<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="SistemaCotizacionPrestamos.Web._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="hero">
        <div>
            <h1>Sistema de Cotización para Préstamos</h1>
            <p>Gestión de clientes, encuestas, catálogos y usuarios mediante Web Forms conectado a API.</p>
        </div>
        <div class="fecha-sistema">
            <strong>Fecha:</strong> <asp:Label ID="lblFecha" runat="server"></asp:Label>0


        </div>
    </section>

   <section class="estadisticas">


    <div class="stat-card stat-clientes">

    <div class="stat-icono">
        <img src="/Images/Cliente.png" alt="Clientes" />
    </div>
    <span>Clientes</span>
    <strong>0</strong>
    <small>Registrados</small>
</div>


    <div class="stat-card stat-encuestas">

        <div class="stat-icono">
    <img src="/Images/Encuestas.png" alt="Encuestas" />
</div>
        <span>Encuestas</span>
        <strong>0</strong>
        <small>Realizadas</small>
    </div>


    <div class="stat-card stat-usuarios">

       <div class="stat-icono">
    <img src="/Images/Usuarios.png" alt="Usuarios" />
</div>
        <span>Usuarios</span>
        <strong>0</strong>
        <small>Activos</small>
    </div>


    <div class="stat-card stat-catalogos">

        <div class="stat-icono">
    <img src="/Images/Catalogos.png" alt="Catálogos" />
</div>
        <span>Catálogos</span>
        <strong>0</strong>
        <small>Disponibles</small>
    </div>


</section>


    <section class="dashboard">

        <a class="tarjeta-menu" href="/Clientes/ListaClientes.aspx">
            <div class="icono">
    <img src="/Images/Cliente.png" class="img-dashboard" alt="Clientes" />
</div>
            <h2>Clientes</h2>
            <p>Administrar información registrada de clientes.</p>
            <span class="btn-card">Ingresar</span>
        </a>



        <a class="tarjeta-menu" href="/Encuestas/FormularioEncuesta.aspx">
            <div class="icono">
   <img src="/Images/Encuestas.png" class="img-dashboard" alt="Encuestas" />
</div>
            <h2>Encuestas</h2>
            <p>Registrar formularios de cotización para préstamos.</p>
            <span class="btn-card">Ingresar</span>
        </a>



        <a class="tarjeta-menu" href="/Catalogos/ListaCatalogos.aspx">
            <div class="icono">
    <img src="/Images/Catalogos.png" class="img-dashboard" alt="Catálogos" />
</div>
            <h2>Catálogos</h2>
            <p>Mantenimiento de datos generales del sistema.</p>
            <span class="btn-card">Ingresar</span>
        </a>



        <a class="tarjeta-menu" href="/Usuarios/ListaUsuarios.aspx">
            <div class="icono">
    <img src="/Images/Usuarios.png" class="img-dashboard" alt="Usuarios" />
</div>
            <h2>Usuarios</h2>
            <p>Administrar usuarios, roles y accesos.</p>
            <span class="btn-card">Ingresar</span>
        </a>

    </section>

</asp:Content>