<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormUsuarios.aspx.cs" Inherits="Clinica.Views.FormUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Ingreso de Nuevo Usuario</h2>
    <!-- Formulario -->
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="ddlColores" class="form-label">Tipo</label>
                <asp:DropDownList ID="ddlTipoFormUsuarios" CssClass="form-select" OnSelectedIndexChanged="ddlTipoFormUsuarios_SelectedIndexChanged" AutoPostBack="true" runat="server">
                    <asp:ListItem Text="Profesional" />
                    <asp:ListItem Text="Paciente" />
                </asp:DropDownList>
            </div>

            <%if (Seleccion == "Paciente"){%>
            <div>
                <div class="mb-3">
                    <label class="form-label">Nombre</label>
                    <asp:TextBox CssClass="form-control" ReadOnly="false" placeholder="pepito" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Apellido</label>
                    <asp:TextBox CssClass="form-control" placeholder="navajas" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">DNI</label>
                    <asp:TextBox CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="tbxFecha" class="form-label">Fecha Nacimiento</label>
                    <asp:TextBox TextMode="Date" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="tbxFecha" class="form-label">Mail</label>
                    <asp:TextBox CssClass="form-control" placeholder="ejemplo@mail.com" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-check-label">Algo ??</label>
                    <asp:CheckBox runat="server" />
                </div>
                <div class="m-3">
                    <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" runat="server" />
                    <a href="Default.aspx">Volver</a>
                </div>
                <asp:Label Text="" ID="lblAdvertencia" runat="server" />
            </div>
            <%}
              else {%> 
            <h3>Nada todavia XD</h3>
            <%}%>
        </div>
    </div>
</asp:Content>
