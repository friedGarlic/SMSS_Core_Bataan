<%@ Page Title="Distribution List" Language="VB"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_distribution_list_rpt.aspx.vb" Inherits="Reports_and_Query_t_distribution_list_rpt"  StylesheetTheme="SkinFile" %>

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

    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>




            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">Distribution List
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="left">

                            <table width="100%">
                                <tr>
                                    <td style="width: 50%; height: 30px;" align="left">
                                        &nbsp;</td>
                                    <td style="width: 50%; height: 30px;" align="right">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>

                        <td style="width: 1%"></td>
                        <td align="center" style="width: 98%">
                        
                            <asp:GridView ID="distributionList" runat="server" Width="100%" CssClass="text" 
                                            DataKeyNames="prhdr_id,pr_no,quarter" AutoGenerateColumns="False" SkinID="GridViewAA">
                                <Columns>
                                    <asp:TemplateField>
                                         <ItemTemplate>
                                            <asp:LinkButton ID="lnkPreview" CssClass="LinkBtnPreview" runat="server" CausesValidation="False" Text="Preview" Font-Underline="False" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number" ItemStyle-HorizontalAlign="center" ItemStyle-Width="10%" />
                                    <asp:BoundField DataField="rc_name" HeaderText="Department" ItemStyle-HorizontalAlign="center" ItemStyle-Width="32%" />
                                    <asp:BoundField DataField="function_desc" HeaderText="Function" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" />
                                         <asp:BoundField DataField="PR_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="PR Date">
                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ABC" HeaderText="ABC" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                    <%--<asp:BoundField HeaderText="Total Amount" ItemStyle-HorizontalAlign="Right" DataField="TotalAmt" DataFormatString="{0:N}" ItemStyle-Width="15%" />--%><%--<asp:TemplateField HeaderText="Total Amount">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label runat="server" ID="lblTotalAmt" Text='<%#Bind("TotalAmt") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                            <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                 
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <table width="90%">
                               
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
                        <td align="center" style="width: 98%">
                            &nbsp;</td>
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






            <asp:Panel Style="background-color: transparent; text-align: center" ID="PanelProgress" runat="server" Width="100px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>



        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

