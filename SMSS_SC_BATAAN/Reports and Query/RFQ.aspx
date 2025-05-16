<%@ Page Title="REQUEST FOR QUOTATION" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RFQ.aspx.vb"
    Inherits="Reports_and_Query_RFQ" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">REQUEST FOR QUOTATION
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">PR Number :</span>
                            &nbsp;<asp:TextBox ID="txtSearchPR" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearch" runat="server" Text="SEARCH" Width="120px" CssClass="CSButton" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdRFQ" runat="server" EmptyDataText="No Data Found." SkinID="GridViewAA" Width="98%" AllowPaging="True" 
                                DataKeyNames="prhdr_id,isRecanvass" PageSize="20">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton4" runat="server" CssClass="LinkBtnPreview" CommandName="Select" Font-Underline="False" OnClick="LinkButton4_Click" Text="Preview"  OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="PR Date" DataField="DateApproved" DataFormatString="{0:d}">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="ABC" DataField="ABC" DataFormatString="{0:N}">
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Remarks / Purpose" DataField="remarks">
                                        <ItemStyle HorizontalAlign="Left" Width="55%" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
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
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button> 
       

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

