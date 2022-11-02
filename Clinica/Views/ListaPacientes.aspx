<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaPacientes.aspx.cs" Inherits="Clinica.Views.ListaPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista Pacientes</h1>
    <!-- Filtros -->
    <h3>(Aca faltan filtros)</h3>
    <p>....filtros varios....</p>

    <!-- Lista -->
    <h3>Lista:</h3>
    <asp:GridView ID="gvListaPacientes" 
        CssClass="table" 
        AutoGenerateColumns="false"
        runat="server">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="IdPaciente" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="DNI" DataField="DNI" />
            <asp:BoundField HeaderText="Mail" DataField="Mail" />
            <asp:BoundField HeaderText="Fecha Nacimiento" DataField="FechaNac" />
        </Columns>
    </asp:GridView>
    <!-- new Paciente(0, "Casimiro", "Tuerto", 123456789, "mimail@mail.com", DateTime.Parse("1/1/1900")) -->
</asp:Content>
