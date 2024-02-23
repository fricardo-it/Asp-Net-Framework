<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="StateManagementASPNet.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="ButtonShowWebForm2" runat="server" OnClick="ButtonShowWebForm2_Click" Text="Button" />
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
