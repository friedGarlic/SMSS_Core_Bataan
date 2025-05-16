<%@ Page 
    Language="VB" 
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" 
    CodeFile="rpt_VSummaryOfDonationToLGU.aspx.vb" 
    Inherits="Records_rpt_VSummaryOfDonationToLGU"
    Title="Summary of Donation To LGU"
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ToolPanelView="None" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="rpt_SummaryOfDonationToLGU.rpt">
                    </Report>
                </CR:CrystalReportSource>
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>