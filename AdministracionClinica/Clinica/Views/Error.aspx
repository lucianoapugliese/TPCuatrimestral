<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Clinica.Views.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Error Inesperado</h1>
            <asp:TextBox ID="tbxError" Text="" runat="server"></asp:TextBox>
            <p><%: msg %></p>
        </div>
    </form>
</body>
</html>
