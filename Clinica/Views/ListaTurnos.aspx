<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaTurnos.aspx.cs" Inherits="Clinica.Views.ListaTurnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- FILTROS -->
    <h1>Lista de Turnos</h1>
    <div class="container">
        <div class="row">
            <div class="col">
                <label class="form-label">Seleccionar un Dia y un Medico (solo de ejemplo)</label>
                <div class="col">
                    <asp:DropDownList ID="ddlDiaTurnos" CssClass="form-control" OnSelectedIndexChanged="ddlDiaTurnos_SelectedIndexChanged" AutoPostBack="true" runat="server">
                        <asp:ListItem Text="Lunes" />
                        <asp:ListItem Text="Martes" />
                        <asp:ListItem Text="Miercoles" />
                        <asp:ListItem Text="Jueves" />
                        <asp:ListItem Text="Viernes" />
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <asp:DropDownList ID="ddlEspecialidad" CssClass="form-control" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" AutoPostBack="true" runat="server">
                        <asp:ListItem Text="Pediatria" />
                        <asp:ListItem Text="Dermatologia" />
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <asp:DropDownList ID="ddlMedicosTurnos" CssClass="form-control" OnSelectedIndexChanged="ddlMedicosTurnos_SelectedIndexChanged" AutoPostBack="true" runat="server">
                        <asp:ListItem Text="Medico1" />
                        <asp:ListItem Text="Medico2" />
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col" style="margin-top:5px">
                <asp:Button CssClass="btn btn-primary" Text="Buscar" runat="server" />
            </div>
        </div>
    </div>

    <!-- TURNOS -->
    <div class="row">
        <div class="col">
            <h3>Lista de Turnos Disponibles</h3>
            <p class="card-text"></p>
            <h4>Especialidad: <span class="badge bg-secondary"><%: EspecialidadElegida %></span></h4>
            <h4>Medico: <span class="badge bg-secondary"><%: MedicoElegido %></span></h4>
            <div class="row">
                <!-- REPITER -->
                <asp:Repeater ID="repListaTurnos" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-6">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title">HORARIO:<%# DataBinder.GetPropertyValue(Container.DataItem, "HoraTurno")%> hs</h5>
                                    <p class="card-text">
                                        <%# (bool)(DataBinder.Eval(Container.DataItem, "Ocupado"))? 
                                                                 "<span class=\"badge text-bg-success\">Libre</span>\r\n":"<span class=\"badge text-bg-warning\">Ocupado</span>\r\n"%>
                                    </p>
                                    <p class="card-text">MEDICO: xxxx </p>
                                    <p class="card-text">Info Paciente: xxxx </p>
                                    <a href="#" class="btn btn-primary">Tomar turno</a>
                                    <a href="#" class="btn btn-primary">Cancelar Turno</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- FIN REPITER -->
            </div>
        </div>
    </div>

</asp:Content>
