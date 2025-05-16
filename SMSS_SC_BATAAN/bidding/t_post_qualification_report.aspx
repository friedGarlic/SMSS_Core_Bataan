<%@ 
    Page Title="Post Qualification"
    Language="VB"
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" 
    CodeFile="t_post_qualification_report.aspx.vb" 
    Inherits="bidding_t_post_qualification_report"
    EnableEventValidation="false"
    StylesheetTheme="SkinFile"
%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">Notice of Post Qualification</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search By :</span>&nbsp;
		                    <asp:DropDownList runat="server" ID="drpSearch" Width="150px">
                                <asp:ListItem Value="1" Text="Reference Number"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Bid Location"></asp:ListItem>
                            </asp:DropDownList>&nbsp;
		                    <asp:TextBox runat="server" ID="txtSearch" Width="200px" CssClass="txtbox_Var"></asp:TextBox>&nbsp;
		                    <asp:Button runat="server" ID="btnSearch" CssClass="CSButton" Width="150px" Text="SEARCH" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdPostQualification" runat="server" Width="80%" OnPageIndexChanging="grdPostQualification_PageIndexChanging" SkinID="GridViewAA" AllowPaging="true" OnRowDataBound="grdPostQualification_RowDataBound" OnSelectedIndexChanged="grdPostQualification_SelectedIndexChanged" AutoGenerateColumns="false" PageSize="8" DataKeyNames="pre_procurement_hdr_id, TotalABC, CountSupplier, obr_evaluation_hdr_id, isPublicInfra">
                                <Columns>
                                    <asp:BoundField DataField="RefNumber" HeaderText="Reference Number">
                                        <ItemStyle HorizontalAlign="Center"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BidLocation" HeaderText="Bid Location">
                                        <ItemStyle HorizontalAlign="Left"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="countSupplier" HeaderText="No. of Bidders">
                                        <ItemStyle HorizontalAlign="Center"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalABC" DataFormatString="{0:N}" HeaderText="Total ABC">
                                        <ItemStyle HorizontalAlign="Right"/>
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="#2977DC"/>
                                <HeaderStyle BackColor="#2977DC" ForeColor="White"/>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">List of Suppliers</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdBidders1" runat="server" Width="90%" SkinID="GridViewAA" OnSelectedIndexChanged="grdBidders1_SelectedIndexChanged" AutoGenerateColumns="false" PageSize="8" DataKeyNames="bid_opening_hdr_id, Supplier_id, BidAmount" EmptyDataText="No Data Found.">
                                <Columns>
                                    <asp:BoundField DataField="SuppName" HeaderText="Bidder Name">
                    					<ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
                    				</asp:BoundField>
                    				<asp:BoundField DataField="NoItems" HeaderText="No. of Items">
                    					<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    				</asp:BoundField>
                    				<asp:BoundField DataField="BidAmount" DataFormatString="{0:N}" HeaderText="Total Bid Amount">
                    					<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                    				</asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="#2977DC" />
                                <HeaderStyle BackColor="#2977DC" ForeColor="White" />
                            </asp:GridView>
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
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnPQ" OnClick="btnPQ_Click" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW PQ" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
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

            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc;" ID="PanelProgress" runat="server" width="109px">
				<img alt="" src="../images/ajax-loader.gif"/>
			</asp:Panel>

			<cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>

			<asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none;" ID="ButtonProgress" runat="server" width="16px" Enabled="false"></asp:Button>
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>


