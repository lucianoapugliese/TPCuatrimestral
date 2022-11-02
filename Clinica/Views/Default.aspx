<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Clinica.Views.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>CLINICA "MATA-SANOS"</h1>
    <h4>(todo esto es preeliminar)</h4>
    <!-- FILTROS -->
    <div class="row">
        <div class="col-3">
            <label class="form-label">Ingrese el tipo de usuario:</label>
            <div class="col">
                <asp:DropDownList ID="ddlTipoUsario" CssClass="form-control" OnSelectedIndexChanged="ddlTipoUsario_SelectedIndexChanged" runat="server">
                    <asp:ListItem Text="Recepcionista" />
                    <asp:ListItem Text="Profecional" />
                    <asp:ListItem Text="Admin" />
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <!-- IMPUTS -->
    <div class="row">
        <div class="input-group mb-3">
            <span class="input-group-text">Usuario</span>
            <input type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" placeholder="Pepito">
            <span class="input-group-text">Contraseña</span>
            <input type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" placeholder="Navajas">
        </div>
        <div class="input-group">
            <asp:Button ID="btnIngreso" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnIngreso_Click" runat="server" />
        </div>
    </div>
    <%if(Seleccion == "Recepcionista"){%>
    <div class="row">
        <h4>Bienvenido Pepito Navajas</h4>
        <div class="col">
            <a href="#" class="btn btn-primary">Ir a Lista Turnos</a>
            <a href="ListaPacientes.aspx" class="btn btn-primary">Ir a Lista Pacientes</a>
            <a href="#" class="btn btn-primary">Ir a Lista Medicos</a>
        </div>
    </div>
    <%}%>

</asp:Content>
