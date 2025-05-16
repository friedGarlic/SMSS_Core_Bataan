<%@ Page 
    Language="VB" 
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" 
    CodeFile="rpt_vSummaryDonationLGUtoLGU.aspx.vb" 
    Inherits="Records_rpt_vSummaryDonationLGUtoLGU"
    Title="Summary of LGU to LGU"
    StylesheetTheme="SkinFile" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="1020px">
                    <tr>
                        <td></td>
                         <td>
                              <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ToolPanelView="None" />
                                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                    <Report FileName="rpt_SummaryOfLGUToLGU.rpt">
                                    </Report>
                                </CR:CrystalReportSource>

                         </td>
                         <td></td>
                    </tr>
                </table>
               
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>

