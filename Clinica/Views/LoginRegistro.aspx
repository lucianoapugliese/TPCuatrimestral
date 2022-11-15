<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginRegistro.aspx.cs" Inherits="Clinica.Views.LoginRegistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- Inicio -->
    <asp:ScriptManager runat="server" />
    <!-- Formulario -->
    <div class="d-flex justify-content-center">
        <div class="container m-4 p-3" id="formulario-registro">
            <div class="row d-flex justify-content-around">
                <!-- Imputs: Id, Nombre, Apellido, Nivel, DNI, Especialidad -->
                <div class="col-3">
                    <div class="mb-3">
                        <label class="form-label" style="display:none">Id</label>
                        <asp:TextBox Text="" ID="txtId" Enabled="false" CssClass="form-control" style="display:none" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Nivel</label>
                        <asp:DropDownList ID="ddlNivel" CssClass="form-select" OnTextChanged="ddlNivel_TextChanged" AutoPostBack="true" runat="server">
                            <asp:ListItem Value="-1" Text="Paciente" />
                            <asp:ListItem Value="2" Text="Medico" />
                            <asp:ListItem Value="1" Text="Empleado" />
                            <asp:ListItem Value="0" Text="Administrador" />
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Especialidad</label>
                        <asp:DropDownList ID="ddlEspecialidad" Enabled="false" CssClass="form-select"  runat="server"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Nombre</label>
                        <asp:TextBox Text="" ID="txtNombre" CssClass="form-control" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Apellido</label>
                        <asp:TextBox Text="" ID="txtApellido" CssClass="form-control" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">DNI</label>
                        <asp:TextBox Text="" ID="txtDNI" CssClass="form-control" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Fecha Nacimiento</label>
                        <asp:TextBox Text="" ID="txtFecha" CssClass="form-control" runat="server" />
                    </div>
                </div>
                <!-- Imputs: Mail, Constraseña, Descripcion e Imagen -->
                <div class="col-3">
                    <div class="mb-3">
                        <label class="form-label">Email</label>
                        <asp:TextBox ID="txtMail" CssClass="form-control" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Contraseña</label>
                        <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Descripcion Medica</label>
                        <asp:TextBox ID="txaDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server" />
                    </div>
                    <div class="mb-3"> <!-- Dejar asi x ahora los imputs de img para usar como upload de arhcivos o avatars -->
                        <label class="form-label">Url Imagen</label>
                        <asp:UpdatePanel ID="UpdatePanelFormulario" runat="server">
                            <ContentTemplate>
                                <div>
                                    <asp:TextBox ID="txbUrlImg" Text="" CssClass="form-control" runat="server" />
                                </div>
                                <div style="margin-top: 5px">
                                    <asp:Image ID="imgFormulario" ImageUrl="../fonts/image-missing.png" Width="60%" runat="server" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <!-- Fin Formulario -->
            </div>
            <!-- Botones Agregar, Modificar, Borrar, Cancelar -->
                <div class="row">
                    <div class="mb-3">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div>
                                    <asp:Button ID="btnAgregar" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" runat="server" />
                                    <asp:Button ID="btnEliminar" Text="Eliminar" CssClass="btn btn-danger"  runat="server" />
                                    <asp:Button ID="btnEliminarLogica" Text="Dar de Baja" CssClass="btn btn-warning"  runat="server" />
                                    <asp:Button ID="btnAltaLogica" Text="Dar de Alta" CssClass="btn btn-warning"  runat="server" />
                                    <% if (true)
                                        {%>
                                    <div class="mb-3" style="margin-top: 5px">
                                        <asp:CheckBox ID="chkConfirmarEliminar" Text="Confirmar Eliminacion" runat="server" />
                                        <asp:Button ID="btnConfirmarEliminar" Text="Eliminar" CssClass="btn btn-outline-danger" runat="server" />
                                    </div>
                                    <%} %>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="mb-3">
                            <a href="Default.aspx" class="btn btn-link">Volver al Inicio</a>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <a href="LoginRegistro.aspx" class="btn-link">Cancelar</a>
                    </div>
                </div>
        </div>
    </div>
<!-- Fin -->
</asp:Content>
