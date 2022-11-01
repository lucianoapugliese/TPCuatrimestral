<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaMedicos.aspx.cs" Inherits="Clinica.Views.ListaMedicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Medicos</h1>
    <asp:GridView ID="gvEjemplo1" CssClass="table" runat="server"></asp:GridView>
</asp:Content>
