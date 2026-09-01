<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_ppmp_popup.aspx.vb" Inherits="planning_rpt_ppmp_popup" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<head>
    <title>PROJECT PROCUREMENT MANAGEMENT PLAN</title>
</head>

<body style="background-color:#808080">
    <form runat="server" id="form_PPMP">
        <div style="background-color: #808080; text-align: center; vertical-align: middle">
            <table style="width: 100%">
                <tr>
                    <td style="width: 100%; height: 5px"></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" 
                            SeparatePages="False" ShowAllPageIds="True" HasCrystalLogo="False" BackColor="#ffffff" Width="1000px" Height="700px" />
                        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                        </CR:CrystalReportSource>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 5px"></td>
                </tr>
            </table>
        </div>
    </form>
</body>






<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PROJECT PROCUREMENT MANAGEMENT PLAN</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div title="PROJECT PROCUREMENT MANAGEMENT PLAN">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" DisplayGroupTree="False" Height="700px" SeparatePages="False" ShowAllPageIds="True" Width="1000px" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
           
        </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>--%>
