<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FirstProject.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="nameLabel" runat="server" Text="Name"></asp:Label><br />
            <asp:TextBox ID="name" runat="server" ></asp:TextBox><br /><br />
            <asp:Label ID="addressLabel" runat="server" Text="Address"></asp:Label><br />
            <asp:TextBox ID="address" runat="server" ></asp:TextBox><br /><br />
            <asp:Button ID="myButton" runat="server" Text="Submit"  OnClick="Submitted" />
            
            <asp:Button ID="view" runat="server" Text="View Data" OnClick="View" /><br />
            <asp:Label ID="display1" runat="server"></asp:Label>
            <asp:DataGrid ID="mygrid" runat="server"></asp:DataGrid>

        </div>
    </form>
</body>
</html>
