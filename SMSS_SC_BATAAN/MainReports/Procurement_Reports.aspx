 <%@ Page Title="PROCUREMENT REPORTS" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Procurement_Reports.aspx.vb"
    Inherits="MainReports_Procurement_Reports" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>



    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">
                    <asp:Label runat="server" ID="lblTitle" Text="REPORTS"></asp:Label>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%; height: 10px"></td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="column_LeftBold">
                    <asp:LinkButton ID="LnkPrevious" runat="server" CssClass="LinkBtnSelect" Text="Back to Previous Page ..."></asp:LinkButton>
                </td>
                 <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%; height: 10px">
                         <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="98%" CssClass="rbCS_Vertical" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="1">Purchase Request</asp:ListItem>
                                <asp:ListItem Value="2" Visible="false">CAFOA</asp:ListItem>
                            </asp:RadioButtonList>
                    
                     </td>
                <td style="width: 1%"></td>
            </tr>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <table runat="server" id="tbPR" width="50%">
                        <tr>
                            <td style="width: 5%"></td>
                            <td style="width: 95%" class="column_Left">
                                <span class="column_RightBold">Report Size :</span>
                                &nbsp;<asp:DropDownList runat="server" ID="drpReportFormat" Width="100px" CssClass="drpdownCSS" AutoPostBack="true">
                                    <asp:ListItem Selected="True" Value="1" Text="Short"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Long"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <div style="width: 850px; background-color: #808080; text-align: center; vertical-align: middle">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%; height: 5px"></td>
                            </tr>
                            <tr>
                                <td style="width: 100%" align="center">
                                    <CR:CrystalReportViewer ID="ProcurementReports" runat="server" AutoDataBind="true"  HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                                        BackColor="#ffffff" BestFitPage="true" ToolPanelView="None" PrintMode="ActiveX" />

                                    <CR:CrystalReportViewer ID="ProcurementReport" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                                        BackColor="#ffffff" BestFitPage="false" ToolPanelView="None" PrintMode="ActiveX" />

                                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server"></CR:CrystalReportSource>
                                    <CR:CrystalReportSource ID="CrystalReportSource2" runat="server"></CR:CrystalReportSource>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%; height: 5px"></td>
                            </tr>
                        </table>
                    </div>


                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%;height:20px" class="column_CenterBold">
                   -- Obligation Request Report --
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <div style="width: 850px; background-color: #808080; text-align: center; vertical-align: middle">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%; height: 5px"></td>
                            </tr>
                            <tr>
                                <td style="width: 100%" align="center">
                                    <CR:CrystalReportViewer ID="OBR_Report" runat="server" AutoDataBind="true"  HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                                        BackColor="#ffffff" BestFitPage="true" ToolPanelView="None" PrintMode="ActiveX" />                                                                     

                                    <CR:CrystalReportSource ID="CrystalReportSource3" runat="server"></CR:CrystalReportSource>
                                </td>
                            </tr>

                                <tr>
                                <td style="width: 100%" align="center">
                                    <CR:CrystalReportViewer ID="CAFOA" runat="server" AutoDataBind="true"  HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                                        BackColor="#ffffff" BestFitPage="true" ToolPanelView="None" PrintMode="ActiveX" />                                                                     

                                    <CR:CrystalReportSource ID="RPT_CAFOA" runat="server"></CR:CrystalReportSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%; height: 5px"></td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 1%"></td>
            </tr>
              <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%">
                </td>
                <td style="width: 1%"></td>
            </tr>
        </table>
    </div>

</asp:Content>

