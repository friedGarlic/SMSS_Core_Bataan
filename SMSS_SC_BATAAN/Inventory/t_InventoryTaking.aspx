<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_InventoryTaking.aspx.vb"
    Inherits="Inventory_t_InventoryTaking" Title="INVENTORY TAKING" EnableEventValidation="false" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script language="javascript" type="text/javascript">
        function Table2_onclick() {
        }
        function fun1(e, button1) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(button1);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 1010px">
                <tr>
                    <td align="center" style="width: 10px"></td>
                    <td align="center" class="PageTitle" style="width: 1000px">RFID INVENTORY TAKING</td>
                </tr>
                <tr>
                    <td align="center" style="width: 10px"></td>
                    <td align="center" style="width: 1000px">
                        <table style="width: 600px">
                            <tr>
                                <td align="left" colspan="2">
                                    <span style="font-size: 10pt; color: red; font-family: Arial"><strong><em>*
                            Select RFID scanned document</em></strong></span></td>
                            </tr>
                            <tr>
                                <td style="width: 20%"></td>
                                <td class="text5" style="width: 80%"></td>
                            </tr>
                            <tr>
                                <td style="width: 20%"></td>
                                <td class="text5" style="width: 80%">
                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" BackColor="#E0E0E0" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" /></td>
                            </tr>
                            <tr>
                                <td style="width: 20%"></td>
                                <td class="text5" style="width: 80%">
                                    <strong>Select Inventory Year :</strong>
                                    <asp:DropDownList ID="ddYear" runat="server" Width="150px">
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="width: 10px"></td>
                    <td align="center" style="width: 1000px">
                        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Calibri"
                            Font-Size="10pt" ForeColor="Red" Text="*  Scanned document has been successfully uploaded and saved. List of properties is now available for viewing."
                            Visible="False"></asp:Label></td>
                </tr>
                <tr>
                    <td align="center" style="width: 10px"></td>
                    <td align="center" style="width: 1000px"></td>
                </tr>
                <tr>
                    <td align="center" style="width: 10px"></td>
                    <td align="center" style="width: 1000px">
                        <asp:Button ID="Button1" Text="UPLOAD" OnClick="Upload" runat="server" Width="200px" OnClientClick="StartProgressBar();" /><asp:Button
                            ID="btnPreview" runat="server" OnClick="btnPreview_Click" Text="PREVIEW" Width="200px" Enabled="False" /></td>
                </tr>
            </table>
            <asp:Panel ID="PanelProgress" runat="server" Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc"
                Width="109px">
                <img src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BehaviorID="ProgressBarModalPopupExtender"
                PopupControlID="PanelProgress" TargetControlID="ButtonProgress">
            </cc1:ModalPopupExtender>
            <asp:Button ID="ButtonProgress" runat="server" Enabled="False" Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none"
                Width="16px" />


        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Button1" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

