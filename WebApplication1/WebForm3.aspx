<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Employee Name"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 10px" Width="120px"></asp:TextBox>
    
    </div>
        <asp:Label ID="Label2" runat="server" Text="Gender"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" style="margin-left: 65px" Width="95px">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Salary"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 70px" Width="87px"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 51px" Text="Button" Width="80px" />
        <br />
        <asp:Label ID="Label4" runat="server"></asp:Label>
    </form>
</body>
</html>
