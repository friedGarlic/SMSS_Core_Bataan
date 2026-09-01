<%@ Page Title="ISSP Report" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_ISSP_EditContent.aspx.vb" Inherits="Inventory_Disposal_rpt_ISSP_EditContent"
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
    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">INVITATION TO SUBMIT SEALED PROPOSAL
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <div class="borderCSS_CurveEdge" style="width: 95%">
                                <table width="90%">
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_Center">Republic of the Philippines
                                          <br>
                                            Provincial Government of Cagayan
                                          <br>
                                            OFFICE OF THE CITY ADMINISTRATOR
                                          
                                        </<br>
                                            <td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_CenterBold">INVITATION TO SUBMIT SEALED PROPOSAL
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_CenterBold">
                                            <span>ISSP No. :</span>
                                            <asp:Label runat="server" ID="lbl_ISSPNo"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_Center">"As Is, Where Is Basis"
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_CenterBold">DISPOSAL OF UNSERVICEABLE PROPERTIES
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_Center">
                                            <asp:TextBox runat="server" ID="txtP1" CssClass="txtbox_Encoding" TextMode="MultiLine" Width="90%" Height="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" align="center">
                                            <asp:GridView runat="server" ID="grdIIRUP" SkinID="GridViewAA" Width="80%" ShowFooter="true" AllowPaging="true" PageSize="15" EmptyDataText="No Data Found.">
                                                <Columns>
                                                    <asp:BoundField HeaderText="IIRUP Number" DataField="IIRUP_No" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" />
                                                    <asp:BoundField HeaderText="Particulars" FooterText="Minimum Bid Offer : " FooterStyle-HorizontalAlign="Right" DataField="Particulars" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="40%" />
                                                    <asp:TemplateField HeaderText="Location" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="40%" FooterStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblLocation" Text='<%# Bind("Location") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                             <asp:Label runat="server" ID="lblMin_BidAmt" Text='<%# Bind("MinBidAmt", "{0:N}") %>'></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_Center">
                                            <asp:TextBox runat="server" ID="txtP2" CssClass="txtbox_Encoding" TextMode="MultiLine" Width="90%" Height="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_CenterBold">
                                            <asp:Label runat="server" ID="lblSignedBy"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_CenterBold">
                                            <asp:Label runat="server" ID="lblSignedBy_Pos"></asp:Label>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_Left">
                                            <asp:Label runat="server" ID="lblPublishedDate"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 30px"></td>
                                    </tr>
                                </table>
                            </div>
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
                        <td style="width: 98%" align="center">
                            <asp:Button runat="server" ID="btnSavePreview" CssClass="CSButton" Text="Save & Preview" Width="15%" OnClientClick="StartProgressBar();" />
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

            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

