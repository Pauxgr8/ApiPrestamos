<%@ Page Title="Catálogos" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ListaCatalogos.aspx.cs"
    Inherits="SistemaCotizacionPrestamos.Web.Catalogos.ListaCatalogos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="tarjeta">
        <h1 class="titulo-pagina">Catálogos</h1>
        <p>Seleccione el catálogo que desea administrar.</p>
    </div>

    <div class="dashboard">

        <a class="tarjeta-menu" href="/Catalogos/Generos.aspx">
            <h2>Géneros</h2>
            <p>Mantenimiento de géneros.</p>
            <span class="btn-card">Ingresar</span>
        </a>

        <a class="tarjeta-menu" href="/Catalogos/NivelesEducativos.aspx">
            <h2>Niveles Educativos</h2>
            <p>Mantenimiento de niveles educativos.</p>
            <span class="btn-card">Ingresar</span>
        </a>

        <a class="tarjeta-menu" href="/Catalogos/RangosEdad.aspx">
            <h2>Rangos de Edad</h2>
            <p>Mantenimiento de rangos de edad.</p>
            <span class="btn-card">Ingresar</span>
        </a>

        <a class="tarjeta-menu" href="/Catalogos/RangosIngresos.aspx">
            <h2>Rangos de Ingresos</h2>
            <p>Mantenimiento de rangos de ingresos.</p>
            <span class="btn-card">Ingresar</span>
        </a>

        <a class="tarjeta-menu" href="/Catalogos/TiposPrestamo.aspx">
            <h2>Tipos de Préstamo</h2>
            <p>Mantenimiento de tipos de préstamo.</p>
            <span class="btn-card">Ingresar</span>
        </a>

        <a class="tarjeta-menu" href="/Catalogos/Plazos.aspx">
            <h2>Plazos</h2>
            <p>Mantenimiento de plazos.</p>
            <span class="btn-card">Ingresar</span>
        </a>

        <a class="tarjeta-menu" href="/Catalogos/TasasInteres.aspx">
            <h2>Tasas de Interés</h2>
            <p>Mantenimiento de tasas de interés.</p>
            <span class="btn-card">Ingresar</span>
        </a>

        <a class="tarjeta-menu" href="/Catalogos/CapacidadesPago.aspx">
            <h2>Capacidades de Pago</h2>
            <p>Mantenimiento de capacidades de pago.</p>
            <span class="btn-card">Ingresar</span>
        </a>

        <a class="tarjeta-menu" href="/Catalogos/MediosContratacion.aspx">
            <h2>Medios de Contratación</h2>
            <p>Mantenimiento de medios de contratación.</p>
            <span class="btn-card">Ingresar</span>
        </a>

    </div>

</asp:Content>