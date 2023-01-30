﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="KnockoutWebformWithController0102.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="tabs">
        <ul>
            <li><a href="#tabs1">Insert</a></li>
            <li><a href="#tabs2">Display</a></li>
        </ul>
        <div id="tabs1">
        <div>
            <asp:Label ID="NameLabel" runat="server" Text="Enter Name: "></asp:Label><br />
            <asp:TextBox ID="NameText" runat="server" CssClass="txbox"></asp:TextBox><br /><br />
            <asp:Label ID="AgeLabel" runat="server" Text="Enter Age: "></asp:Label><br />
            <asp:TextBox ID="AgeText" runat="server" CssClass="txbox"></asp:TextBox><br /><br />
            <asp:Label ID="GenderLabel" runat="server" Text="Enter your gender: "></asp:Label><br />
            <asp:TextBox ID="GenderText" runat="server" CssClass="txbox"></asp:TextBox><br /><br />
            <asp:Label ID="AddressLabel" runat="server" Text="Enter Address: "></asp:Label><br />
            <asp:TextBox ID="AddressText" runat="server" CssClass="txbox"></asp:TextBox><br /><br />
            <asp:Button ID="FormButton" runat="server" Text="Submit" OnClick="Clickedbutton"  CssClass="button1"/><br /><br />
        </div>
    </div>
    <%--<div id="tabs2">
            <asp:GridView ID="grid1" runat="server" CssClass="gv" AutoGenerateColumns="false"  AutoGenerateEditButton="True" AutoGenerateDeleteButton="true" DataKeyNames="id" OnRowEditing="edithere" OnRowDeleting="deletehere" OnRowDeleted="RowDeleted">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                </Columns>
            </asp:GridView>
            
    </div>--%>
    </div>
    <asp:label ID="Message" forecolor="Red" runat="server"/>
    
    </form>
</body>
</html>