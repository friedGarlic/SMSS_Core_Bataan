<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Barcode_PopUp.aspx.vb" Inherits="Barcode_PopUp" title="Barcode_Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div title="Purchase Request Report">
        <CR:CrystalReportViewer ID="Barcode" runat="server" AutoDataBind="true"  GroupTreeImagesFolderUrl="/aspnet_client/system_web/2_0_50727/CrystalReportWebFormViewer3/images/tree/" ToolbarImagesFolderUrl="/aspnet_client/system_web/2_0_50727/CrystalReportWebFormViewer3/images/toolbar/" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="rptBarcode_final.rpt">
            </Report>
        </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>
