<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectAssignment.aspx.cs" Inherits="WebAppMidtermReview.GUI.ProjectAssignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
            font-size: large;
        }
        .auto-style3 {
            width: 243px;
        }
        .auto-style4 {
            width: 214px;
        }
        .auto-style5 {
            width: 416px;
        }
        .auto-style10 {
            width: 380px;
        }
        .auto-style13 {
            width: 380px;
            text-align: left;
        }
        .auto-style14 {
            width: 214px;
            text-align: left;
        }
        .auto-style16 {
            width: 416px;
            text-align: left;
        }
        .auto-style17 {
            width: 243px;
            text-align: left;
        }
    </style>
</head>
<body style="width: 1534px; height: 1060px;">
    <form id="form1" runat="server">
        <div>
        </div>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2" colspan="4"><strong>Project Assignment</strong></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">Teacher Id</td>
            <td class="auto-style5">
                <asp:Label ID="LabelTeacherId" runat="server"></asp:Label>
            </td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">Teacher Name</td>
            <td class="auto-style5">
                <asp:Label ID="LabelTeacherName" runat="server"></asp:Label>
            </td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">Select Student</td>
            <td class="auto-style5">
                <asp:DropDownList ID="DropDownListStudent" runat="server" Width="398px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="auto-style4">Select Project</td>
            <td class="auto-style10">
                <asp:DropDownList ID="DropDownListProject" runat="server" Width="398px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style4">
                <asp:Button ID="ButtonAssignProject" runat="server" Text="Assign Project" OnClick="ButtonAssignProject_Click" />
            </td>
            <td class="auto-style10">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style10">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">Assigned Date</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBoxAssignedDate" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style4">Submitted Date</td>
            <td class="auto-style10">
                <asp:TextBox ID="TextBoxSubmittedDate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style16">
                <asp:Calendar ID="CalendarAssignedDate" runat="server" OnSelectionChanged="CalendarAssignedDate_SelectionChanged"></asp:Calendar>
            </td>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">
                <asp:Calendar ID="CalendarSubmittedDate" runat="server" OnSelectionChanged="CalendarSubmittedDate_SelectionChanged"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style16">
                &nbsp;</td>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style16">
                <asp:Button ID="ButtonListProjectsByStudent" runat="server" Text="List Projects" OnClick="ButtonListProjectsByStudent_Click" />
            </td>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">
                <asp:Button ID="ButtonListStudentsByProject" runat="server" Text="List Students" OnClick="ButtonListStudentsByProject_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style16">
                <asp:GridView ID="GridViewProjects" runat="server">
                </asp:GridView>
            </td>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">
                <asp:GridView ID="GridViewStudents" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style16">
                <asp:Label ID="LabelHowManyProject" runat="server"></asp:Label>
            </td>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">
                <asp:Label ID="LabelHowManyStudents" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
    </body>
</html>
