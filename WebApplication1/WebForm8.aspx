<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm8.aspx.cs" Inherits="WebApplication1.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: Arial">
<table border="1">
    <tr>
        <td>
            Employee ID
        </td>
        <td>
            <asp:TextBox ID="txtEmployeeID" runat="server" Width="131px"></asp:TextBox>
            <asp:Button ID="btnGetEmployee" runat="server" Text="Load" 
                OnClick="btnGetEmployee_Click" style="margin-left: 4px" />
        </td>
    </tr>
    <tr>
        <td>
            Name
        </td>
        <td>
            <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Gender
        </td>
        <td>
            <asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem Text="Select Gender" Value="-1"></asp:ListItem>
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Salary
        </td>
        <td>
            <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                OnClick="btnUpdate_Click" />
            <asp:Label ID="lblStatus" runat="server" Font-Bold="true">
            </asp:Label>
        </td>
    </tr>
</table>
</div>
        </form>
</body>
</html>
