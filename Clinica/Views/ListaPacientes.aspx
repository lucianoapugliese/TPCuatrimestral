<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaPacientes.aspx.cs" Inherits="Clinica.Views.ListaPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Filtros -->
    <div class="container-fluid" id="lista-pacientes">
        <div class="container">
            <div class="row">
                <div class="col">
                    <h1>Lista Pacientes</h1>
                    <h3>(Aca faltan filtros)</h3>
                    <p>....filtros varios....</p>
                </div>
            </div>
            <div class="row">
                        <p>ej filtro id:</p>
                <div class="row mb-5">
                    <div class="col-10 align-self-end">
                        <asp:TextBox ID="tbxId" CssClass="form-control" Text="" runat="server" />
                    </div>
                    <div class="col-1 align-self-end" style="margin-top:5px">
                        <asp:Button ID="btnFiltrar" Text="Filtrar" CssClass="btn btn-primary" OnClick="btnFiltrar_Click" runat="server" />
                    </div>
                </div>
            </div>
        </div>

        <!-- Lista -->
        <div class="row">
            <h3>Lista:</h3>
            <asp:GridView ID="gvListaPacientes"
                DataKeyNames="IdPaciente"
                CssClass="table"
                AutoGenerateColumns="false"
                OnRowCommand="gvListaPacientes_RowCommand"
                runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Numero de Paciente" DataField="IdPaciente" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="DNI" DataField="DNI" />
                    <asp:BoundField HeaderText="Mail" DataField="Mail" />
                    <asp:BoundField HeaderText="Fecha Nacimiento" DataField="FechaNac" />
                    <asp:ButtonField ButtonType="Button" CommandName="seleccionPaciente" Text="Seleccionar" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
