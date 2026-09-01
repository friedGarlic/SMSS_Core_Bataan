<%@ Page Title="Summary of Report of Inspection" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="summaryinspection.aspx.vb"
    Inherits="Reports_and_Query_AdditionalReports_summaryinspection" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">SUMMARY REPORT OF INSPECTION
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                     <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%;height:10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">

                            <span class="column_RightBold">Date From :</span>
                            <asp:TextBox runat="server" ID="txtDateFrom" CssClass="txtbox_Date" Width="10%" MaxLength="10"></asp:TextBox>
                            <span class="CalendarFormat">(MM/DD/YYYY)</span>
                            <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDateFrom" PopupButtonID="txtDateFrom" PopupPosition="TopLeft"></cc1:CalendarExtender>
                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtDateFrom" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;<span class="column_RightBold">Date To :</span>
                            <asp:TextBox runat="server" ID="txtDateTo" CssClass="txtbox_Date" Width="10%" MaxLength="10"></asp:TextBox>
                            <span class="CalendarFormat">(MM/DD/YYYY)</span>
                            <cc1:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtDateTo" PopupButtonID="txtDateTo" PopupPosition="TopLeft"></cc1:CalendarExtender>
                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender2" TargetControlID="txtDateTo" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>

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
                                      
                                            <CR:CrystalReportViewer ID="InspectionReports" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" HasSearchButton="False" HasDrilldownTabs="False" 
                                                BestFitPage="False" BackColor="#ffffff" Height="930px" Width="980px" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />


                                            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                                <Report FileName="rpt_summaryinspection.rpt"></Report>
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


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp; 
       

        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>

