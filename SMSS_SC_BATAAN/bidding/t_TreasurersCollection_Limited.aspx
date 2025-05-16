<%@ Page 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="t_TreasurersCollection_Limited.aspx.vb" 
    Inherits="bidding_t_TreasurersCollection_Limited" 
    StylesheetTheme="skinfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function SetMessage() {
            var traps;
            if (confirm("Do you want to remove this bidder?")) 
            { 
               traps = "Yes";
            }
            else
            {
               traps = "No";
            }

            document.getElementById("ctl00_ContentPlaceHolder1_txtTraps").value = traps;
        }

        </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">TREASURERS COLLECTION
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdListOfTransaction" runat="server" Width="80%" HorizontalAlign="Center" SkinID="GridViewAA" AllowPaging="True"
                                OnPageIndexChanging="grdListOfTransaction_PageIndexChanging" PageSize="5" DataKeyNames="pre_procurement_hdr_id,BidLocation,bid_docs,RefNumber,project_name">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <ItemStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" Font-Underline="False" ForeColor="#0033CC" CssClass="LinkBtnSelect"></ItemStyle>
                                    </asp:CommandField>

                                    <asp:BoundField DataField="RefNumber" HeaderText="Reference Number">
                                        <FooterStyle HorizontalAlign="Left"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="BidLocation" HeaderText="Bid Location">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="opening_date" DataFormatString="{0:d}" HeaderText="Bid Opening Date">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="TotalABC" DataFormatString="{0:N}" HeaderText="Total ABC">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Details
                        </td>
                        <td style="width: 1%"><asp:HiddenField ID="txtTraps" runat="server" /></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="80%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Project Name :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox runat="server" ID="lblProjectName" Width="90%" CssClass="txtbox_Remarks" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Location :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox runat="server" Width="90%" CssClass="txtbox_Var" ID="lbllocation"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Bid Document :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox runat="server" ID="lblBiddocument" Width="20%" CssClass="txtbox_Amt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold"></td>
                                    <td style="width: 80%" class="column_Left"></td>
                                </tr>
                            </table>
                            <table width="80%" id="tbSelectBidder" runat="server" visible="false">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Bidder Name :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="drpSupplierList" runat="server" Width="70%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="drpSupplierList_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <table width="80%" id="tbNewBidder" runat="server" visible="false">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Bidder Name :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="txtSuppName" runat="server" Width="70%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Address :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="txtAddress" runat="server" Width="70%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Contact Number :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="txtCNumber" runat="server" Width="20%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Contact Person :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="txtCPerson" runat="server" Width="50%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="2" align="center"></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnsupplier" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="SAVE BIDDER" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnNew" OnClick="btnNew_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="ADD NEW BIDDER" OnClientClick="StartProgressBar();"></asp:Button>

                            <asp:Button ID="btnCancel" runat="server" CssClass="CSButton" Visible="false" Enabled="False" OnClick="btnCancel_Click" OnClientClick="StartProgressBar();" Text="CANCEL" Width="150px" />

                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List Of Bidders
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdListOfSupplier" runat="server" Width="70%" HorizontalAlign="Center" SkinID="GridViewAA" PageSize="5"
                                DataKeyNames="Supplier_ID" EmptyDataText="No Data Found" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="suppname" HeaderText="Supplier Name">
                                        <ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" OnClientClick="StartProgressBar();return SetMessage(this.value);" CssClass="LinkBtnCancel" CommandArgument="Select" CommandName="Select" Font-Underline="False" Text="Remove"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                    </asp:TemplateField>
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
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>



            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:modalpopupextender id="ProgressBarModalPopupExtender" runat="server" targetcontrolid="ButtonProgress" backgroundcssclass="modalBackground" popupcontrolid="PanelProgress" behaviorid="ProgressBarModalPopupExtender"></cc1:modalpopupextender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        


        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

