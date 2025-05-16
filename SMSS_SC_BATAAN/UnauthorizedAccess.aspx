<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UnauthorizedAccess.aspx.vb" Inherits="UnauthorizedAccess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            Unauthorized Access</h2>
        <p>
            You have attempted to access a page that you are not authorized to view.
        </p>
        <p>
            If you have any questions, please contact the site administrator.
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/body.aspx">Back to Home</asp:HyperLink></p>
    
    </div>
    </form>
</body>
</html>
