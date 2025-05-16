<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
CodeFile="time.aspx.vb" Inherits="Roles_time" title="Untitled Page" StylesheetTheme="SkinFile"%>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 

<script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="../Scripts/calendar-en.min.js" type="text/javascript"></script>

    <asp:Button ID="Button1" runat="server" Text="Button" /><%--<link href="~/Styles/calendar-blue.css" type="text/css" />--%>

 
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtDate.ClientID %>").dynDateTime({
            showsTime: true,
            weekNumbers: false,
            timeFormat: "12",
            ifFormat: "%m/%d/%Y %H:%M",
            daFormat: "%l;%M %p, %e %m, %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });
    });
</script>


 
<asp:TextBox ID="txtDate" runat="server" ReadOnly = "true"></asp:TextBox>
<img src="../calender.png"  alt="Select Date and Time"/>
<asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />



</asp:Content>

