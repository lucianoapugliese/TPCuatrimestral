<%@ Page Title="Medicos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaMedicos.aspx.cs" Inherits="Clinica.Views.ListaMedicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" id="lista-medicos">
        <h1>Lista de Medicos</h1>
        <h4>... Filtros Varios ...</h4>
        <asp:Button Text="Filtrar" CssClass="btn btn-primary" runat="server" />
        <div class="mt-4">
            <asp:GridView ID="gvEjemplo1" 
                CssClass="table"
                DataKeyNames="IdProfecional"
                AutoGenerateColumns="false" 
                runat="server" >
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="IdProfecional" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="DNI" DataField="DNI" />
                    <asp:BoundField HeaderText="Especialidad" DataField="Especialidad" />
                    <asp:ButtonField ButtonType="Button" CommandName="seleccionProfecional" Text="Modificar" ControlStyle-CssClass="btn btn-outline-light"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
