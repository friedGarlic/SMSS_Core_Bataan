<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_ListPropertyNo.aspx.vb"
    Inherits="Reports_and_Query_rpt_ListPropertyNo" Title="LIST OF PROPERTY NUMBER" EnableEventValidation="false" StylesheetTheme="SkinFile" %>



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



            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">List Of Property
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
                            <table style="width: 70%" class="panel_border">
                                <tr>
                                    <td class="column_RightBold" style="width: 15%">Year :</td>
                                    <td class="column_Left" style="width: 85%">
                                        <asp:DropDownList ID="ddYear" runat="server" Width="150px" CssClass="drpdownCSS">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 15%">Department :</td>
                                    <td class="column_Left" style="width: 85%">
                                        <asp:DropDownList ID="drpRC" runat="server" Width="350px" CssClass="drpdownCSS" AutoPostBack="true">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 15%">Function :</td>
                                    <td class="column_Left" style="width: 85%">
                                        <asp:DropDownList ID="drpFunction" runat="server" Width="350px" CssClass="drpdownCSS">
                                        </asp:DropDownList></td>
                                </tr>
                            </table>
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
                             <asp:Button ID="btnPreview" runat="server" OnClick="btnPreview_Click" Text="PREVIEW"  Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" />
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





            <asp:Panel ID="PanelProgress" runat="server" Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc"
                Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground"
                BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress">
            </cc1:ModalPopupExtender>
            <asp:Button ID="ButtonProgress" runat="server" Enabled="False" Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" Width="16px" />


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

