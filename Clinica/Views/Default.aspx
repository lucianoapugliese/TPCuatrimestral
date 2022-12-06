<%@ Page Title="Clinica" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Clinica.Views.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- INICIO -->
    <div class="container p-4" id="login">
        <h1>CLINICA "MATA-SANOS"</h1>

        <!-- INPUTS -->
        <%if (!Logeado)
            {%>
        <div class="row d-flex justify-content-center mb-5">
            <div class="col-3">
                <h4>Bienvenido, por favor Ingresa tu DNI y tu Contraseña para acceder</h4>
                <asp:Label ID="lblNoLog" Text="" runat="server" />
            </div>
        </div>
        <div class="row d-flex justify-content-center">
            <div class="col-3">
                <div class="input-group mb-3">
                    <span class="input-group-text">DNI</span>
                    <asp:TextBox ID="tbxUsuario" CssClass="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" runat="server" />
                </div>
                <div class="input-group mb-3">
                    <span class="input-group-text">Contraseña</span>
                    <asp:TextBox ID="tbxContraseña" TextMode="Password" CssClass="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" runat="server" />
                </div>
                <div class="input-group d-flex justify-content-center">
                    <asp:Button ID="btnIngreso" Text="Ingresar" CssClass="btn btn-primary btn-lg" OnClick="btnIngreso_Click" runat="server" />
                </div>
            </div>
        </div>
        <%}
            else
            {%>
        <!-- Opciones: -->
        <div class="col">
            <div class="row">
                <h4>Bienvenido 
                    <asp:Label ID="lblNombreUsuario" Text="" runat="server" />
                </h4>
                <div class="col d-flex justify-content-center">
                    <%if (Clinica.Helpers.Helper.TypeUser(this) == 1)
                        {%>
                    <a href="ListaTurnos.aspx" class="btn btn-primary my-4 py-3">Ir a Lista Turnos</a>
                    <a href="ListaPacientes.aspx" class="btn btn-primary my-4 py-3">Ir a Lista Pacientes</a>
                    <a href="ListaMedicos.aspx" class="btn btn-primary my-4 py-3">Ir a Lista Medicos</a>
                    <%}
                        else if (Clinica.Helpers.Helper.TypeUser(this) == 2)
                        { %>
                    <a href="ListaTurnos.aspx" class="btn btn-primary my-4 py-3">Ir a Lista Turnos</a>
                    <a href="ListaPacientes.aspx" class="btn btn-primary my-4 py-3">Ir a Lista Pacientes</a>
                    <%}
                        else if (Clinica.Helpers.Helper.TypeUser(this) == 0)
                        { %>
                    <div class="col-8 d-flex justify-content-center flex-column">
                            <a href="ListaTurnos.aspx" class="btn btn-primary my-4 py-3">Ir a Lista Turnos</a>
                            <a href="ListaPacientes.aspx" class="btn btn-primary my-4 py-3">Ir a Lista Pacientes</a>
                            <a href="ListaMedicos.aspx" class="btn btn-primary my-4 py-3">Ir a Lista Medicos</a>
                            <a href="LoginRegistro.aspx" class="btn btn-primary my-4 py-3">Ir a Opciones de Usuarios</a>
                    </div>
                    <%}%>
                </div>
            </div>
        </div>
        <%--<div class="row">
            <%--<a href="#">Perfil</a>
        </div> --%>
        <%}%>
    </div>
</asp:Content>
