
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Clinica.Views.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container p-4" id="login">
        <h1>CLINICA "MATA-SANOS"</h1>
        <h4>(todo esto es preeliminar)</h4>
        <!-- FILTROS -->
        <div class="row d-flex justify-content-center mb-5">
            <div class="col-3">
                <label class="form-label">Ingrese el tipo de usuario:</label>
                <div class="col">
                    <p>(usar solo Recepcionista)</p>
                    <asp:DropDownList ID="ddlTipoUsario" CssClass="form-control" OnSelectedIndexChanged="ddlTipoUsario_SelectedIndexChanged" runat="server">
                        <asp:ListItem Text="Recepcionista" />
                        <asp:ListItem Text="Profesional" />
                        <asp:ListItem Text="Admin" />
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <!-- INPUTS -->
        <div class="row d-flex justify-content-center" >
            <div class="col-3">
                <div class="input-group mb-3">
                    <span class="input-group-text">Usuario</span>
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
        <!-- Opciones: -->
        <%if (Seleccion == "Recepcionista")
            {%>
        <div class="row">
            <h4>Bienvenido
                <asp:Label ID="lblNombreUsuario" Text="" runat="server" />
            </h4>
            <div class="col">
                <a href="ListaTurnos.aspx" class="btn btn-primary">Ir a Lista Turnos</a>
                <a href="ListaPacientes.aspx" class="btn btn-primary">Ir a Lista Pacientes</a>
                <a href="ListaMedicos.aspx" class="btn btn-primary">Ir a Lista Medicos</a>
            </div>
        </div>
        <%}%>
    </div>
</asp:Content>
