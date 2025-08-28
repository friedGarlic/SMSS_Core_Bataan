<%@ Page Title="NOTICE OF DELIVERY" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_NoticeOfDelivery.aspx.vb"
    Inherits="MainReports_NoticeOfDelivery" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">NOTICE OF DELIVERY REPORT</td>
                <td style="width: 1%"></td>
            </tr>
          <%--  <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:LinkButton ID="lnkBack" runat="server" CssClass="LinkBtnSelect" Text="Back to Previous Page ..."></asp:LinkButton>
                </td>
                <td style="width: 1%"></td>
            </tr>--%>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">

                  <CR:CrystalReportSource ID="CrystalReportSource1" runat="server" />
                    <CR:CrystalReportViewer ID="NoticeOfDeliveryReport" runat="server"
                        AutoDataBind="true"
                        HasToggleGroupTreeButton="False"
                        HasCrystalLogo="False"
                        HasSearchButton="False"
                        HasDrilldownTabs="False"
                        BestFitPage="False"
                        BackColor="#ffffff"
                        Height="930px"
                        Width="980px"
                        BorderStyle="Solid"
                        BorderColor="#2977dc"
                        BorderWidth="1px"
                        ReportSourceID="CrystalReportSource1" />


                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%"></td>
                <td style="width: 1%"></td>
            </tr>
        </table>
    </div>

</asp:Content>
