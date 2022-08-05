<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="upload.aspx.vb" Inherits="ermes_web_20.upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
    <div>
    <asp:fileupload accept=".zip" runat="server" ID="uploadFile"></asp:fileupload>    
        <asp:Button ID="invia" runat="server" Text="invia" />
    </div>
    </form>
</body>
</html>
