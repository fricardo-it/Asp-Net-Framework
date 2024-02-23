<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEmployee.aspx.cs" Inherits="Lab1_ASPNetConnectedMode.GUI.WebFormEmployee" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 164px;
        }
        .auto-style5 {
            width: 509px;
        }
        .auto-style6 {
            width: 172px;
        }
        .auto-style7 {
            text-align: center;
        }
        .auto-style9 {
            width: 698px;
        }
        .auto-style10 {
            width: 630px;
        }
        .auto-style11 {
            width: 164px;
            height: 52px;
        }
        .auto-style12 {
            width: 172px;
            height: 52px;
        }
        .auto-style13 {
            width: 630px;
            height: 52px;
        }
        .auto-style14 {
            width: 698px;
            height: 52px;
        }
        .auto-style15 {
            width: 509px;
            height: 52px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style7" colspan="4">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF9900" Text="Employee Maintenance"></asp:Label>
                </td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="Label1" runat="server" Text="Employee ID"></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:TextBox ID="TextBoxEmployeeId" runat="server" Width="154px"></asp:TextBox>
                </td>
                <td class="auto-style9">
                    <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Save" Width="250px" />
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="Label2" runat="server" Text="First Name"></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:TextBox ID="TextBoxFirstName" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td class="auto-style9">
                    <asp:Button ID="ButtonUpdate" runat="server" OnClick="ButtonUpdate_Click" Text="Update" Width="250px" />
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="Label3" runat="server" Text="Last Name"></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:TextBox ID="TextBoxLastName" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td class="auto-style9">
                    <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="Delete" Width="250px" />
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="Label4" runat="server" Text="Job Title"></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:TextBox ID="TextBoxJobTitle" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td class="auto-style9">
                    <asp:Button ID="ButtonListAll" runat="server" OnClick="ButtonListAll_Click" Text="List All Employees" Width="250px" />
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="Label6" runat="server" Text="Search by"></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:DropDownList ID="DropDownListSearchOption" runat="server" Width="224px" OnSelectedIndexChanged="DropDownListSearchOption_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style10">
                    <asp:Label ID="LabelDisplay" runat="server" Text="display"></asp:Label>
                </td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11"></td>
                <td class="auto-style12"></td>
                <td class="auto-style13">
                    <asp:TextBox ID="TextBoxInput" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="auto-style14">
                    <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="Search Employee" Width="250px" />
                </td>
                <td class="auto-style15"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style10">
                    <asp:Label ID="LabelDisplay2" runat="server" Text="display2"></asp:Label>
                </td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style10">
                    <asp:TextBox ID="TextBoxInput2" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style10">
                    <asp:GridView ID="GridViewEmployee" runat="server" Width="475px">
                    </asp:GridView>
                </td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
