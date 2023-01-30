<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaptureCam.aspx.cs" Inherits="MyWebCamImage.CaptureCam" %>

<!DOCTYPE html>

<html >
<head runat="server">
<title>Capture Image from Cam</title>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <script src="JavaScript_Webcam_Plugin/jquery.webcam.js"></script>
<script type="text/javascript">
var pageUrl = "Default.aspx";
$(function () {
   jQuery("#webcam").webcam({
      width: 320,
      height: 240,
      mode: "save",
       swffile: "JavaScript_Webcam_Plugin/jscam.swf",
      debug: function (type, status) {
         $('#camStatus').append(type + ": " + status +'<br /><br />');
      },
      onSave: function (data) {
         $.ajax({
            type: "POST",
            url: pageUrl + "/GetCapturedImage",
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
               $("[id*=MyimgCapture]").css("visibility","visible");
               $("[id*=MyimgCapture]").attr("src", r.d);
            },
            failure: function (response) {
               alert(response.d);
            }
         });
      },
      onCapture: function () {
         webcam.save(pageUrl);
      }
   });
});
function Capture() {
   webcam.capture();
   return false;
}
</script>
</head>
<body>
   <form id="form1" runat="server">
<table border="0" cellpadding="0" cellspacing="0">
   <tr>
      <td align="center">
         <u>My Live Camera</u>
      </td>
      <td>
      </td>
      <td align="center">
         <u>My Captured Picture</u>
      </td>
   </tr>
   <tr>
      <td>
         <div id="webcam">
         </div>
      </td>
      <td>
      </td>
      <td>
         <asp:Image ID="MyimgCapture" runat="server" Style="visibility: hidden; width: 320px; height: 240px" />
      </td>
   </tr>
</table>
<br />
<asp:Button ID="btnCapture" Text="Capture" runat="server" OnClientClick="return Capture();" />
<br />
<span id="camStatus"></span>
</form>
</body>
</html>