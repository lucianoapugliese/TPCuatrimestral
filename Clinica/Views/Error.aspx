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
            <asp:Label ID="lblError" Text="Source: " runat="server"></asp:Label>
            <p>Info: <%: msg3 %></p>
            <p>Message: <%: msg %></p>
            <p>StackTrace: <%: msg2 %></p>
        </div>
    </form>
</body>
</html>
