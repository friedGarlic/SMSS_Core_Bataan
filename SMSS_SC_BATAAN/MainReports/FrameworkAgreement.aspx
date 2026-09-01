<%@ Page Title="Framework Agreement" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrameworkAgreement.aspx.vb" 
    Inherits="MainReports_FrameworkAgreement" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    
    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">FRAMEWORK AGREEMENT REPORTS
                </td>
                <td style="width: 1%"></td>
            </tr>          
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <CR:CrystalReportViewer ID="FrameWorkAgreement" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                        HasSearchButton="False" HasDrilldownTabs="False" BestFitPage="true" BackColor="#ffffff"
                        BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />


                    <CR:CrystalReportSource ID="Crystalreportsource1" runat="server">
                        <Report FileName="rpt_FrameworkAgreement2.rpt">
                        </Report>
                    </CR:CrystalReportSource>                  

                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%"></td>
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

