<%@ Page Title="RPCPPE for Dispose Items" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PhysicalCount_DisposedItem_RepQuery.aspx.vb" Inherits="Reports_and_Query_PhysicalCount_DisposedItem"
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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

        function toPeso(objctrl) {
            //Get the Entered Value
            var number = objctrl.value.toString(),
                //Split the number between WholeNumber and Decimals
                php = number.split('.')[0], cents = (number.split('.')[1] || '') + '00';
            php = php.split('').reverse().join('').replace(/(\d{3}(?!$))/g, '$1,').split('').reverse().join('');
            //Concatenate the number 
            objctrl.value = php + '.' + cents.slice(0, 2);
        }

    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">PHYSICAL COUNT OF DISPOSED ITEM
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="80%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">As of (Date) :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtDate" CssClass="txtbox_Date" Width="15%" MaxLength="10"></asp:TextBox>
                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>

                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender" TargetControlID="txtDate" PopupButtonID="txtDate" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender" TargetControlID="txtDate" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Report Viewing :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpReportFormat" CssClass="drpdownCSS" Width="25%" AutoPostBack="true">
                                            <asp:ListItem Value="1" Text="Per Department" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Per Account"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Department :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpDepartment" CssClass="drpdownCSS" Width="80%" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Gen. Account :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpGenAccount" CssClass="drpdownCSS" Width="80%" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Fund Source :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpFund" CssClass="drpdownCSS" Width="25%">
                                            <asp:ListItem Value="1" Text="General Fund" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Special Education Fund"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Trust Fund"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
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
                            <table width="90%">
                                <tr>
                                    <td style="width: 100%" colspan="2" class="column_LeftBold">Prepared by :
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 10%"></td>
                                    <td style="width: 90%" class="column_Left">
                                        <span class="column_RightBold">Name :</span>
                                        &nbsp;<asp:TextBox runat="server" ID="txtPreparedBy1" CssClass="drpdownCSS" Width="30%"></asp:TextBox>
                                        &nbsp;&nbsp;<span class="column_RightBold">Designation :</span>
                                        &nbsp;<asp:TextBox runat="server" ID="txtPreparedBy1_Pos" CssClass="drpdownCSS" Width="30%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 10%"></td>
                                    <td style="width: 90%" class="column_Left">
                                        <span class="column_RightBold">Name :</span>
                                        &nbsp;<asp:TextBox runat="server" ID="txtPreparedBy2" CssClass="drpdownCSS" Width="30%"></asp:TextBox>
                                        &nbsp;&nbsp;<span class="column_RightBold">Designation :</span>
                                        &nbsp;<asp:TextBox runat="server" ID="txtPreparedBy2_Pos" CssClass="drpdownCSS" Width="30%"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="width: 10%"></td>
                                    <td style="width: 90%" class="column_Left">
                                        <span class="column_RightBold">Name :</span>
                                        &nbsp;<asp:TextBox runat="server" ID="txtPreparedBy3" CssClass="drpdownCSS" Width="30%"></asp:TextBox>
                                        &nbsp;&nbsp;<span class="column_RightBold">Designation :</span>
                                        &nbsp;<asp:TextBox runat="server" ID="txtPreparedBy3_Pos" CssClass="drpdownCSS" Width="30%"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="width: 10%"></td>
                                    <td style="width: 90%" class="column_Left">
                                        <span class="column_RightBold">Name :</span>
                                        &nbsp;<asp:TextBox runat="server" ID="txtPreparedBy4" CssClass="drpdownCSS" Width="30%"></asp:TextBox>
                                        &nbsp;&nbsp;<span class="column_RightBold">Designation :</span>
                                        &nbsp;<asp:TextBox runat="server" ID="txtPreparedBy4_Pos" CssClass="drpdownCSS" Width="30%"></asp:TextBox>
                                    </td>
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
                            <asp:Button runat="server" ID="btnPreview" CssClass="CSButton" Width="12%" Text="Preview" OnClientClick="StartProgressBar();" />
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
                        <td style="width: 98%; height: 30px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px" __designer:wfdid="w145">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" __designer:wfdid="w146" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False" __designer:wfdid="w147"></asp:Button>&nbsp; 
        

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
