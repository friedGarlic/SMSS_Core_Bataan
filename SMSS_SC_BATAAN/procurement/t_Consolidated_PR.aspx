<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_Consolidated_PR.aspx.vb"
    Inherits="procurement_t_Consolidated_PR" Title="Consolidated Purchase Request" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


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
                        <td style="width: 98%" class="PageTitle">CONSOLIDATED PURCHASE REQUEST
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date : </span>
                            &nbsp;<asp:TextBox ID="txtDate" runat="server" CssClass="txtbox_Date" ReadOnly="True" Width="100px"></asp:TextBox>
                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="left">


                            <table cellpadding="0px" cellspacing="0px" width="100%">
                                <tr>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab1" Width="100%" Text="CONSOLIDATION APPROVAL" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab2" Width="100%" Text="CONSOLIDATED PURCHASE REQUEST" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 60%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="3" class="PanelMessage">
                                        <asp:MultiView runat="server" ID="mvTabs">
                                            <asp:View runat="server" ID="vwTab1">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView ID="grdPurchaseRequest" runat="server" SkinID="GridViewAA" EmptyDataText="No Data Found."
                                                                Width="98%" DataKeyNames="GA_ID,prhdr_id" OnSelectedIndexChanged="grdPurchaseRequest_SelectedIndexChanged">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" Font-Underline="False"
                                                                                OnClick="lnkSelect_Click" OnClientClick="StartProgressBar();" Visible='<%# Bind("isVisible") %>'>Select</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Date_Submitted" DataFormatString="{0:d}" HeaderText="Date Submitted">
                                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="GA_Title" HeaderText=" Account">
                                                                        <ItemStyle HorizontalAlign="Left" Width="60%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Cnt" HeaderText="No. of PR">
                                                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ABC" HeaderText="Total ABC" DataFormatString="{0:N}">
                                                                        <ItemStyle HorizontalAlign="Right" Width="15%" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button ID="btnUpdate" runat="server" Enabled="False" Text="UPDATE" Width="150px" CssClass="CSButton" OnClick="btnUpdate_Click" OnClientClick="StartProgressBar();" />
                                                            &nbsp;<asp:Button ID="btnApproved" runat="server" Enabled="False" Text="APPROVE" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" OnClick="btnApproved_Click" />
                                                            &nbsp;<asp:Button ID="btnCancel" runat="server" Enabled="False" Text="CANCEL" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" OnClick="btnCancel_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">List Of P.R. With The Same Account For OBR Evaluation
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView ID="grdPRList" runat="server" AutoGenerateColumns="False" DataKeyNames="prhdr_id,pr_no"
                                                                SkinID="GridViewAA" Width="90%" EmptyDataText="No Data Found.">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Enabled="False" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                                                        <ItemStyle HorizontalAlign="Right" Width="15%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="OBR_No" HeaderText="OBR Number">
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="rc_name" HeaderText="Department">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Left" Width="50%" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <FooterStyle BackColor="#2977DC" />
                                                                <HeaderStyle BackColor="#2977DC" ForeColor="White" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View runat="server" ID="vwTab2">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView ID="grdApproved_PR" runat="server" SkinID="GridViewAA" EmptyDataText="No Data Found." Width="98%">
                                                                <Columns>
                                                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="pr_Date" DataFormatString="{0:d}" HeaderText="Date Approved">
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="GA_Title" HeaderText=" Account">
                                                                        <ItemStyle HorizontalAlign="Left" Width="50%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Cnt" HeaderText="No. of PR">
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ABC" HeaderText="ABC" DataFormatString="{0:N}">
                                                                        <ItemStyle HorizontalAlign="Right" Width="15%" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                        </asp:MultiView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtDate" TargetControlID="txtDate"></cc1:CalendarExtender>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>

                </table>
            </div>





            <asp:Panel ID="PanelProgress" runat="server" Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress">
            </cc1:ModalPopupExtender>
            <asp:Button ID="ButtonProgress" runat="server" Enabled="False" Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" Width="16px" />



            <asp:Panel ID="pnl_PrNumb" runat="server" BackColor="White" CssClass="Panel_Popup" BorderStyle="Solid" BorderWidth="2px" Style="display: none; text-align: center" Width="217px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 217px; text-align: left">
                    <tbody>
                        <tr>
                            <td colspan="3" style="font-weight: bold; color: white; height: 21px; background-color: #ffa016">&nbsp;Purchase Request Number</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                <div style="text-align: center">
                                    <table style="width: 100%; text-align: center">
                                        <tbody>
                                            <tr>
                                                <td align="center" style="width: 100%; text-align: center">
                                                    <asp:Label ID="txtPRNumber" runat="server" CssClass="txtbox_Var"
                                                        BorderWidth="1px" Width="179px"></asp:Label><br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 100%; text-align: center">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; text-align: center">
                                                    <asp:Button ID="Button3" runat="server" Text="CLOSE" CssClass="CSButton" /></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <asp:Label ID="lblPopPR" runat="server"></asp:Label>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnl_PrNumb" TargetControlID="lblPopPR">
            </cc1:ModalPopupExtender>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

