<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Clinica.Views.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>BIENVENIDOS</h1>
    <div class="row">
        <div class="mb-3">
            <label for="exampleFormControlInput1" class="form-label">Nombre</label>
            <input type="email" class="form-control" id="" placeholder="">
        </div>
        <div  class="mb-3">
            <label for="exampleFormControlInput1" class="form-label">Email address</label>
            <input type="email" class="form-control" id="" placeholder="name@example.com">
        </div>
        <div class="mb-3">
            <label for="exampleFormControlInput1" class="form-label">Password</label>
            <input type="email" class="form-control" id="" placeholder="">
        </div>
    </div>
</asp:Content>
