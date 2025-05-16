<%@ Page Title="Summary of Supplies and Materials Used" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="summarysuppliedused.aspx.vb"
    Inherits="Reports_and_Query_AdditionalReports_summarysuppliesused" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager2" runat="server">
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
                        <td style="width: 98%" class="PageTitle">SUMMARY OF SUPPLIES AND MATERIALS ISSUED
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
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Date From  :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtDateFrom" CssClass="txtbox_Date" Width="30%" MaxLength="10" AutoPostBack="true"></asp:TextBox>
                                        <span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDateFrom" PopupButtonID="txtDateFrom" PopupPosition="BottomRight"></cc1:CalendarExtender>
                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtDateFrom" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Date To  :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtDateTo" CssClass="txtbox_Date"  Width="30%" MaxLength="10"></asp:TextBox>
                                        <span class="CalendarFormat">(MM/DD/YYYY)</span>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 10px" colspan="4"></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Gen. Account :</td>
                                    <td style="width: 50%" colspan="2" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpGenAccount" CssClass="drpdownCSS" Width="95%" AutoPostBack="true"></asp:DropDownList>
                                    </td>                                   
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpDepartment" Visible="false" CssClass="drpdownCSS" Width="95%" Enabled="false" AutoPostBack="true">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left">
                                         <asp:DropDownList runat="server" ID="drpFunction" Visible="false" CssClass="drpdownCSS" Width="95%" Enabled="false">
                                             <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                         </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 10px" colspan="4"></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Prepared By :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtPreparedby" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Posted in the SLC By :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtPostedby" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Certified By :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtCertifiedby" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                </tr>
                            </table>
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
                        <td style="width: 98%" align="center">
                            <asp:Button runat="server" ID="btnPreview" CssClass="CSButton" Text="Preview" Width="15%" OnClientClick="StartProgressBar();" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 20px"></td>
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>





</asp:Content>

