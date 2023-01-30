<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebcamPage.aspx.cs" Inherits="WebcamExample.WebcamPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Webcam Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="webcamImage" runat="server" />
        </div>
    </form>
</body>
</html>