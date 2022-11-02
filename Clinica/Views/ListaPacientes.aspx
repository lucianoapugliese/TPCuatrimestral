<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaPacientes.aspx.cs" Inherits="Clinica.Views.ListaPacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista Pacientes</h1>

    <asp:DataGrid ID="formPacientes2" CssClass="table" runat="server">
    </asp:DataGrid>

</asp:Content>
