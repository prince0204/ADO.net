<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm9.aspx.cs" Inherits="WebApplication1.WebForm9" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family:Arial">
        <asp:Button ID="btnGetDataFromDB" runat="server" Text="Get Data from Database" 
        onclick="btnGetDataFromDB_Click" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Undo" />
        <asp:gridview ID="gvEmployees" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeId" OnRowCancelingEdit="gvEmployees_RowCancelingEdit" OnRowDeleting="gvEmployees_RowDeleting" OnRowEditing="gvEmployees_RowEditing" OnRowUpdating="gvEmployees_RowUpdating">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" InsertVisible="False" ReadOnly="True" SortExpression="EmployeeId" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:BoundField DataField="Salary" HeaderText="Salary" SortExpression="Salary" />
            </Columns>
        </asp:gridview>
        <asp:Button ID="btnUpdateDatabaseTable" runat="server" Text="Update Database Table" OnClick="btnUpdateDatabaseTable_Click" />
        <br />
        <asp:Label ID="lblStatus" Font-Bold="true" runat="server"></asp:Label>


    </div>
    </form>
</body>
</html>

