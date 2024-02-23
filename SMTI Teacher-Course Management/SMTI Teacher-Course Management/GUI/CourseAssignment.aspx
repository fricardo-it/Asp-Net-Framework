<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseAssignment.aspx.cs" Inherits="SMTI_Teacher_Course_Management.GUI.CourseAssignment" %>

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
        .auto-style18 {
            width: 243px;
            height: 40px;
        }
        .auto-style19 {
            width: 416px;
            height: 40px;
        }
        .auto-style20 {
            width: 214px;
            height: 40px;
        }
        .auto-style21 {
            width: 380px;
            height: 40px;
        }
        .auto-style22 {
            width: 243px;
            text-align: left;
            height: 239px;
        }
        .auto-style23 {
            width: 416px;
            text-align: left;
            height: 239px;
        }
        .auto-style24 {
            width: 214px;
            text-align: left;
            height: 239px;
        }
        .auto-style25 {
            width: 380px;
            text-align: left;
            height: 239px;
        }
    </style>
</head>
<body style="width: 1534px; height: 1060px;">
    <form id="form1" runat="server">
        <div>
        </div>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2" colspan="4"><strong>Course Assignment</strong></td>
        </tr>
        <tr>
            <td class="auto-style2">Employee Number</td>
            <td class="auto-style3">
                <asp:Label ID="LabelEmployeeNumber" runat="server"></asp:Label>
            </td>
            <td class="auto-style4">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Employee Name</td>
            <td class="auto-style3">
                <asp:Label ID="LabelEmployeeName" runat="server"></asp:Label>
            </td>
            <td class="auto-style4">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18"></td>
            <td class="auto-style19"></td>
            <td class="auto-style20"></td>
            <td class="auto-style21"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">Select Employee</td>
            <td class="auto-style5">
                <asp:DropDownList ID="DropDownListEmployee" runat="server" Width="398px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="auto-style4">Select Course</td>
            <td class="auto-style10">
                <asp:DropDownList ID="DropDownListCourse" runat="server" Width="398px" AutoPostBack="True">
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
                <asp:Button ID="ButtonAssignCourse" runat="server" Text="Assign Course" OnClick="ButtonAssignCourse_Click" />
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
                <asp:Button ID="ButtonListCoursesByEmployee" runat="server" Text="List Course Assigned" OnClick="ButtonListCoursesByEmployee_Click" />
            </td>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">
                <asp:Button ID="ButtonViewGroups" runat="server" Text="List Groups" OnClick="ButtonViewGroups_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style22"></td>
            <td class="auto-style23">
                <asp:GridView ID="GridViewCourses" runat="server">
                </asp:GridView>
            </td>
            <td class="auto-style24"></td>
            <td class="auto-style25">
                <asp:GridView ID="GridViewGroups" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style16">
                <asp:Label ID="LabelHowManyCourses" runat="server"></asp:Label>
            </td>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">
                &nbsp;</td>
        </tr>
    </table>
    </form>
    </body>
</html>