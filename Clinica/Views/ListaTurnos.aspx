<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaTurnos.aspx.cs" Inherits="Clinica.Views.ListaTurnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista de Turnos</h1>
    <div class="row">
        <div class="col-3">
            <label class="form-label">Seleccionar un Dia y un Medico (solo de ejemplo)</label>
            <div class="col">
                <asp:DropDownList ID="ddlDiaTurnos" CssClass="form-control" runat="server">
                    <asp:ListItem Text="Lunes" />
                    <asp:ListItem Text="Martes" />
                    <asp:ListItem Text="Miercoles" />
                    <asp:ListItem Text="Jueves" />
                    <asp:ListItem Text="Viernes" />
                </asp:DropDownList>
            </div>
            <div class="col">
                <asp:DropDownList ID="ddlEspecialidad" CssClass="form-control" runat="server">
                    <asp:ListItem Text="Pediatria" />
                    <asp:ListItem Text="Dermatologia" />
                </asp:DropDownList>
            </div>
            <div class="col">
                <asp:DropDownList ID="ddlMedicosTurnos" CssClass="form-control" runat="server">
                    <asp:ListItem Text="Medico1" />
                    <asp:ListItem Text="Medico2" />
                </asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col">
            <h3>Lista de Turnos Disponibles</h3>
            <div class="row">
                <div class="col-sm-6">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">HORARIO: xxx hs</h5>
                            <p class="card-text">LIBRE o OCUPADO</p>
                            <p class="card-text">ESPECIALIDAD</p>
                            <p class="card-text">MEDICO: xxxx </p>
                            <p class="card-text">Info Paciente: xxxx </p>
                            <a href="#" class="btn btn-primary">Tomar turno</a>
                            <a href="#" class="btn btn-primary">Cancelar Turno</a>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">HORARIO: xxx hs</h5>
                            <p class="card-text">LIBRE o OCUPADO</p>
                            <p class="card-text">ESPECIALIDAD</p>
                            <p class="card-text">MEDICO: xxxx </p>
                            <p class="card-text">Info Paciente: xxxx </p>
                            <a href="#" class="btn btn-primary">Tomar turno</a>
                            <a href="#" class="btn btn-primary">Cancelar Turno</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
