<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectListAssigned.aspx.cs" Inherits="WebAppMidtermReview.GUI.ProjectListAssigned" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 63%;
        }
        .auto-style2 {
            width: 305px;
        }
        .auto-style3 {
            width: 786px;
        }
        .auto-style4 {
            width: 513px;
        }
        .auto-style5 {
            width: 786px;
            text-align: center;
        }
        .auto-style6 {
            width: 305px;
            height: 40px;
        }
        .auto-style7 {
            width: 786px;
            height: 40px;
        }
        .auto-style8 {
            width: 513px;
            height: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Student Id</td>
                <td class="auto-style3">
                    <asp:Label ID="LabelStudentId" runat="server"></asp:Label>
                </td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Student Name</td>
                <td class="auto-style3">
                    <asp:Label ID="LabelStudentName" runat="server"></asp:Label>
                </td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6"></td>
                <td class="auto-style7"></td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5"><strong>List of Projects Assigned</strong></td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">
                    <asp:GridView ID="GridViewProjectsAssigned" runat="server" Height="221px" Width="774px">
                    </asp:GridView>
                </td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
