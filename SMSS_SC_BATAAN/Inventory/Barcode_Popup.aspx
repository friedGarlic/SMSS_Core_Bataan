<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Barcode_PopUp.aspx.vb" Inherits="Barcode_PopUp" Title="Barcode_Report" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>



<head>
    <title>Barcode Page</title>
</head>

<body>
    <form id="form1" runat="server">

        <div style="width: 880px; background-color: #808080; text-align: center; vertical-align: middle">
            <table style="width: 100%">
                <tr>
                    <td style="width: 100%; height: 10px"></td>
                </tr>
                <tr>
                    <td style="width: 100%; align-content: center">
                       
                        <CR:CrystalReportViewer ID="Barcode" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" HasSearchButton="False" HasDrilldownTabs="False"
                              GroupTreeImagesFolderUrl="/aspnet_client/system_web/2_0_50727/CrystalReportWebFormViewer3/images/tree/" ToolbarImagesFolderUrl="/aspnet_client/system_web/2_0_50727/CrystalReportWebFormViewer3/images/toolbar/"
                            BestFitPage="true" BackColor="#ffffff" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />


                        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                            <Report FileName="rptBarcode_final.rpt">
                            </Report>
                        </CR:CrystalReportSource>

                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 10px"></td>
                </tr>
            </table>
        </div>
    </form>
</body>




<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
</html>--%>
