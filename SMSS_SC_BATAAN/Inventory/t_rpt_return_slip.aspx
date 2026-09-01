<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
CodeFile="t_rpt_return_slip.aspx.vb" Inherits="Inventory_t_rpt_return_slip" 
title="Property Return Slip" StylesheetTheme="SkinFile"  %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Contetnt1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 


<script language="javascript" type="text/javascript">
</script>
    <table width="800">
        <tr>
            <td style="background-color: transparent; text-align: left;">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" style="background-color: white" HasToggleGroupTreeButton="False" />
                <CR:CrystalReportViewer ID="ReturnSlipReports" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" HasSearchButton="False" HasDrilldownTabs="False"
                                        BestFitPage="true" BackColor="#ffffff" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />
                <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                                        <Report FileName="rpt_Temp_PRS.rpt">
                                        </Report>
                                    </CR:CrystalReportSource>
                 <CR:CrystalReportViewer ID="PRS_EndUser" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" HasSearchButton="False" HasDrilldownTabs="False"
                                        ToolPanelView="None" BestFitPage="true" BackColor="#ffffff" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />
            </td>
        </tr>
    </table>
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
       <%-- <Report FileName="PRS.rpt">--%>
             <Report FileName="PRS_v2.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

