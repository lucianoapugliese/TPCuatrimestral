<%@ Page Title="Nuevo Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormUsuarios.aspx.cs" Inherits="Clinica.Views.FormUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Ingreso de Nuevo <%: Seleccion %></h2>
    <!-- Formulario -->
    <div class="row d-flex justify-content-center mb-5">
        <div class="col-6">
            <div class="mb-3">
                <%if (Request.QueryString["v"].ToString() == "medico"){%>
                    <label for="ddlTipo" class="form-label">Tipo</label>
                    <asp:DropDownList ID="ddlEspecialidad" CssClass="form-select" AutoPostBack="true" runat="server"></asp:DropDownList>
                <%}%>
            </div>
            <div>
                <div class="mb-3">
                    <label class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" ReadOnly="false" placeholder="pepito" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" CssClass="form-control" placeholder="navajas" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">DNI</label>
                    <asp:TextBox ID="txtDNI" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtMail" class="form-label">Mail</label>
                    <asp:TextBox ID="txtMail" CssClass="form-control" placeholder="ejemplo@mail.com" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtFecha" class="form-label">Fecha Nacimiento</label>
                    <asp:TextBox ID="txtFecha" TextMode="Date" CssClass="form-control" runat="server" />
                </div>
                <%if (Request.QueryString["v"] != null){%>
                    <div class="mb-3">
                        <label class="form-label">Nueva Contraseña</label>
                        <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" ></asp:TextBox>
                    </div>
                <%}%>
                <div class="m-3">
                    <asp:Button Text="Agregar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                    <asp:Button Text="Modificar" ID="btnModificar" CssClass="btn btn-primary" OnClick="btnModificar_Click"  runat="server" />
                </div>
                <div>
                     <a href="Default.aspx">Volver</a>
                </div>
                <asp:Label Text="" ID="lblAdvertencia" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
