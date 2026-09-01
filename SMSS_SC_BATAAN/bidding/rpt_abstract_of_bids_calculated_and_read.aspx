<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="rpt_abstract_of_bids_calculated_and_read.aspx.vb" 
    Inherits="Reports_and_Query_rpt_abstract_of_bids_calculated" 
    title="Abstract of Bids" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 

<table style="width: 1015px">
    <tr>
        <td style="width: 1015px">
            <table style="width: 1000px">
    
                <tr>
                    <td align="left" style="width: 1000px">
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LinkBtnSelect" >Back to previous page...</asp:LinkButton>
                        <br>
                    </td>
                </tr>

        
                <tr>
                    <td align="left" style="width: 1000px; padding: 10px 0;">
                        <div style="display: flex; align-items: center; gap: 10px;">
                            <label for="ddlReportSelection" class="column_RightBold">Report Type:</label>
                            <asp:DropDownList ID="ddlReportSelection" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlReportSelection_SelectedIndexChanged"
                                style="width: 250px;">

                                <asp:ListItem Selected="True" Value="bidding_AOB" >ABSTRACT OF BIDS</asp:ListItem>
                                <asp:ListItem Value="bidding_read">BIDS AS READ</asp:ListItem>
                                <asp:ListItem Value="bidding" >BIDS AS CALCULATED</asp:ListItem>
                                
                              
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>

                <tr>
                    <td align="left" style="width: 1000px">
                        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                            BestFitPage="False" Height="800px" Width="980px" BorderColor="Silver"
                            BorderStyle="Solid" BorderWidth="1px" ToolPanelView="None"
                            HasExportButton="True" HasPrintButton="True" PrintMode="ActiveX" />

                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>
