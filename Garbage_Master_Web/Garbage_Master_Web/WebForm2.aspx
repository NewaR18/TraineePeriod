<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Garbage_Master_Web.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="wwwroot/css/home.css" />
    <link href="wwwroot/bootstrap/animate.min.css" rel="stylesheet" />
    <script src="wwwroot/js/jquery-3.6.3.js"></script>
    <link href="wwwroot/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="wwwroot/bootstrap/bootstrap-icons.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div>
            Your Name :
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <input id="btnGetTime" type="button" value="Show Current Time"
                onclick="ShowCurrentTime()" />
        </div>
    </form>
</body>
<script>
    function ShowCurrentTime() {
        $.ajax({
            type: "POST",
            url: "WebForm2.aspx/GetCurrentTime",
            data: '{name: "' + $("#<%=txtUserName.ClientID%>")[0].value + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
    }
    function OnSuccess(response) {
        alert(response.d);
    }
</script>
</html>
