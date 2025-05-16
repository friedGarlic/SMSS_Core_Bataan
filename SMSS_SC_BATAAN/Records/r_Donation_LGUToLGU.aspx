<%@ Page Language="VB"
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false"
    EnableEventValidation="false" 
    CodeFile="r_Donation_LGUToLGU.aspx.vb"
    Inherits="Records_r_Donation_LGUToLGU"
    StylesheetTheme="SkinFile"
    Title="LGU To LGU"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="1020px">
                    <tr>
                       <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">L.G.U TO L.G.U REPORT</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td></td>
                         <td  align="center"> 
                             <CR:CrystalReportViewer ID="LGUToLGU_ReportViewer1" runat="server" AutoDataBind="true" ToolPanelView="None" />
                             <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                 <Report FileName="rpt_LGUtoLGU.rpt">
                                 </Report>
                             </CR:CrystalReportSource>
                        </td>
                         <td></td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
