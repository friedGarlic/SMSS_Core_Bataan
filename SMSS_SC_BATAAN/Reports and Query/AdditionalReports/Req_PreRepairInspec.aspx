<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Req_PreRepairInspec.aspx.vb" Inherits="Reports_and_Query_AdditionalReports_Req_PreRepairInspec" 
    MasterPageFile="~/MasterPage.master" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


     <script type="text/javascript"> 
        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) {
                return false;
            }
        }
        document.onkeypress = stopRKey;
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">REQUEST FOR PRE-REPAIR INSPECTION
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                     <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Year :</span>
                            &nbsp;<asp:DropDownList runat="server" ID="drpYear" CssClass="drpdownCSS" Width="10%">
                                <asp:ListItem Value="1" Text="2020" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<span class="column_RightBold">As of :</span>
                            <asp:TextBox runat="server" ID="txtDate" CssClass="txtbox_Date" Width="10%" MaxLength="10"></asp:TextBox>
                            <span class="CalendarFormat">(MM/DD/YYYY)</span>
                            <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDate" PopupButtonID="txtDate" PopupPosition="TopLeft"></cc1:CalendarExtender>
                            &nbsp;<asp:Button runat="server" ID="btnPreview" CssClass="CSButton" Text="Preview" Width="12%" OnClientClick="StartProgressBar();" />

                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                     <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <div style="width: 100%; text-align: center; vertical-align: middle">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" align="center">

                                            <CR:CrystalReportViewer ID="PreRepair" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" HasSearchButton="False" HasDrilldownTabs="False"
                                                BestFitPage="true" BackColor="#ffffff" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />

                                            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                                <Report FileName="rpt_PreRepairInspection.rpt"></Report>
                                            </CR:CrystalReportSource>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                </table>
                            </div>
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
            </ContentTemplate>
        </asp:UpdatePanel>

      </asp:Content>