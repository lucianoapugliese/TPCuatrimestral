<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginRegistro.aspx.cs" Inherits="Clinica.Views.LoginRegistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" />
    <!-- Formulario -->
    <div class="d-flex justify-content-center">
        <div class="container m-4 p-3" id="formulario-registro">

            <div class="row justify-content-center" style="margin-bottom: 10px">
                <div class="col">
                    <asp:Button Text="Ver Todos los Usuarios" ID="btnListaUsuarios" CssClass="btn btn-primary" AutoPostback="false" runat="server" />
                </div>
            </div>
            <!-- Botones Collapse -->
            <div class="row">
                <div class="col">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <p>
                                <asp:Button Text="Opciones Usuarios" ID="btnBuscarFiltro" CssClass="btn btn-primary" type="button" data-bs-toggle="collapse" data-bs-target="#filtrosDeBusqueda" aria-expanded="false" aria-controls="filtrosDeBusqueda" runat="server" />
                                <asp:Button Text="Agregar Usuario" ID="btnAgregarFiltro" CssClass="btn btn-primary" type="button" data-bs-toggle="collapse" data-bs-target="#multiCollapseExample2" aria-expanded="false" aria-controls="multiCollapseExample2" OnClick="btnAgregarFiltro_Click" runat="server" />
                                <a class="btn btn-secondary" href="LoginRegistro.aspx">Resetear Filtros</a>
                            </p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <div class="collapse multi-collapse" id="filtrosDeBusqueda">

                        <!-- filtros de busqueda: ID, DNI -->
                        <div class="row d-flex justify-content-around">
                            <div class="col-3 d-flex flex-column justify-content-between">
                                <div class="mb-3">
                                    <label class="form-label">Id</label>
                                    <asp:TextBox Text="" ID="txtBuscarID" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                            <div class="col-3 d-flex flex-column justify-content-between">
                                <div class="mb-3">
                                    <label class="form-label">DNI</label>
                                    <asp:TextBox Text="" ID="txtBuscarDNI" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                            <div class="col-3 d-flex flex-column justify-content-between">
                                <div class="mb-3">
                                    <label class="form-label">Nivel</label>
                                    <asp:DropDownList ID="ddlTipoBuscar" CssClass="form-select" runat="server">
                                        <asp:ListItem Value="-1" Text="Paciente" />
                                        <asp:ListItem Value="2" Text="Medico" />
                                        <asp:ListItem Value="1" Text="Empleado" />
                                        <asp:ListItem Value="0" Text="Administrador" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="row justify-content-center">
                                        <div class="col-4">
                                            <asp:Button Text="Buscar" ID="btnBuscarFiltroExp" CssClass="btn btn-primary" OnClick="btnBuscarFiltroExp_Click" runat="server" />
                                            <asp:Button Text="Modificar" ID="btnModificarFiltro" CssClass="btn btn-primary" OnClick="btnModificarFiltro_Click" runat="server" />
                                            <asp:Button Text="Eliminar" ID="btnEliminarFiltro" CssClass="btn btn-primary" OnClick="btnEliminarFiltro_Click" runat="server" />
                                            <button class="btn btn-secondary" type="button" data-bs-toggle="collapse" data-bs-target="#multiCollapseExample2" aria-expanded="false" aria-controls="multiCollapseExample2">Expandir</button>
                                        </div>
                                        <asp:Label Text="" ID="lblResultadoBusqueda" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <!-- fin filtros -->

                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <div class="collapse multi-collapse" id="multiCollapseExample2">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>

                                <!-- Entradas: Id, Nombre, Apellido, Nivel, DNI, Especialidad -->
                                <div class="row d-flex justify-content-around">
                                    <div class="col-3 d-flex flex-column justify-content-between">
                                        <div class="mb-3" style="display: none">
                                            <label class="form-label">Id</label>
                                            <asp:TextBox Text="" ID="txtId" Enabled="false" CssClass="form-control" runat="server" />
                                        </div>
                                        <div class="mb-3">
                                            <label class="form-label">Nivel</label>
                                            <asp:DropDownList ID="ddlNivel" CssClass="form-select" OnTextChanged="ddlNivel_TextChanged" AutoPostBack="true" runat="server">
                                                <asp:ListItem Value="-2" Text="" />
                                                <asp:ListItem Value="-1" Text="Paciente" />
                                                <asp:ListItem Value="2" Text="Medico" />
                                                <asp:ListItem Value="1" Text="Empleado" />
                                                <asp:ListItem Value="0" Text="Administrador" />
                                            </asp:DropDownList>
                                        </div>
                                        <%if (flagMedico) {%> 
                                        <div class="mb-3">
                                            <asp:Label Text="Especialidad" ID="lblEspecialidad" CssClass="form-label" runat="server" />
                                            <asp:DropDownList ID="ddlEspecialidad" Enabled="false" CssClass="form-select" runat="server"></asp:DropDownList>
                                            <asp:Button Text="Agregar Otra Especialidad" ID="btnAgregarEspecialidad" CssClass="btn btn-terciary" runat="server" />
                                        </div>
                                        <div class="mb-3">
                                            <asp:DataGrid ID="listGridEsp" CssClass="table" runat="server">
                                            </asp:DataGrid>
                                        </div>
                                        <%}%>
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
                                    </div>
                                    <div class="col-3 d-flex flex-column justify-content-between">
                                        <!-- Inputs: Mail, fecha, horario de trabajo (solo medicos), Constraseña, Descripcion e Imagen -->
                                        <div class="mb-3">
                                            <label class="form-label">Fecha Nacimiento</label>
                                            <asp:TextBox Text="" ID="txtFecha" TextMode="Date" CssClass="form-control" runat="server" />
                                        </div>
                                        <div class="mb-3">
                                            <label class="form-label">Email</label>
                                            <asp:TextBox ID="txtMail" CssClass="form-control" runat="server" />
                                        </div>
                                        <div class="mb-3">
                                            <asp:Label Text="Contraseña" ID="lblPass" CssClass="form-label" runat="server" />
                                            <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" />
                                        </div>
                                        <%if(flagMedico) {%> 
                                        <div class="mb-3">
                                            <label class="form-label">Turno de Trabajo</label>
                                            <asp:TextBox Text="" ID="txtHorario" TextMode="Time" CssClass="form-control" runat="server" />
                                            <asp:Button Text="Agregar Otro Horario de Trabajo" CssClass="btn btn-terciary" runat="server" />
                                        </div>
                                        <%}%>
                                        <div class="mb-3">
                                            <asp:Label Text="Descripcion Medica" ID="lblDescripcion" CssClass="form-label" runat="server" />
                                            <asp:TextBox ID="txaDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-3 d-flex flex-column justify-content-end">
                                        <div class="mb-3">
                                            <!-- Dejar asi x ahora los imputs de img para usar como upload de arhcivos o avatars -->
                                            <asp:UpdatePanel ID="UpdatePanelFormulario" runat="server">
                                                <ContentTemplate>
                                                    <div style="margin-top: 5px">
                                                        <asp:Image ID="imgFormulario" ImageUrl="../fonts/image-missing.png" Width="60%" runat="server" />
                                                    </div>
                                                    <label class="form-label">Url Imagen</label>
                                                    <div>
                                                        <asp:TextBox ID="txbUrlImg" Text="" CssClass="form-control" runat="server" />
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <!-- Fin Entradas -->

                                <!-- Botones Agregar, Modificar, Borrar, Cancelar -->
                                <div class="container mt-3 pt-3" id="botones">
                                    <div class="row">
                                        <div class="mb-3">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <div>
                                                        <div class="col d-flex justify-content-evenly mb-3">
                                                            <div class="d-grid col-2">
                                                                <asp:Button ID="btnAgregar" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" runat="server" />
                                                            </div>
                                                            <div class="d-grid col-2">
                                                                <asp:Button ID="btnModificar" Text="Modificar" CssClass="btn btn-primary" OnClick="btnModificar_Click" Enabled="false" runat="server" />
                                                            </div>
                                                            <div class="d-grid col-2">
                                                                <asp:Button ID="btnEliminar" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                                                            </div>
                                                            <div class="d-grid col-2">
                                                                <asp:Button ID="btnEliminarLogica" Text="Dar de Baja" CssClass="btn btn-warning" runat="server" />
                                                            </div>
                                                            <div class="d-grid col-2">
                                                                <asp:Button ID="btnAltaLogica" Text="Dar de Alta" CssClass="btn btn-warning" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col impar">
                                                            <% if (flagEliminarbtn)
                                                                {%>
                                                            <div class="mb-2 d-flex justify-content-evenly pt-1 pb-1" style="margin-top: 5px">
                                                                <div class="d-flex align-self-center">
                                                                    <asp:CheckBox ID="chkConfirmarEliminar" Text=" Confirmar Eliminacion" runat="server" />
                                                                </div>
                                                                <div>
                                                                    <asp:Button ID="btnConfirmarEliminar" OnClick="btnConfirmarEliminar_Click" Text="Eliminar" CssClass="btn btn-outline-danger" runat="server" />
                                                                </div>
                                                            </div>
                                                            <%} %>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <div class="col">
                                                <a href="Default.aspx" class="btn btn-link">Volver al Inicio</a>
                                            </div>
                                            <div class="container">
                                                <div class="row">
                                                    <div class="col impar">
                                                        <a href="LoginRegistro.aspx" class="btn-link">Cancelar</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Fin Botones Agregar, Modificar, Borrar, Cancelar -->

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- Fin Formulario -->
</asp:Content>
