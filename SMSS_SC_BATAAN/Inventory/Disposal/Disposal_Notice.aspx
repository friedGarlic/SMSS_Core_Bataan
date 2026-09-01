<%@ Page Title="Disposal - Notice" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Disposal_Notice.aspx.vb"
    Inherits="Inventory_Disposal_Disposal_Notice" StylesheetTheme="SkinFile" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript">
        function HighlightAll(txtObj) {
            txtObj.select();
        }
    </script>

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
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">DISPOSAL - NOTICE
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
                        <td style="width: 98%" align="center">

                            <table cellpadding="0px" cellspacing="0px" width="100%">
                                <tr>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab1" Width="100%" Text="Notice of Award" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab2" Width="100%" Text="Notice to Proceed" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab3" Width="100%" Text="JEV" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 40%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="4" class="PanelTabs">
                                        <asp:MultiView runat="server" ID="mvTabs">



                                            <asp:View runat="server" ID="vwTab1_NOA">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdNOA" SkinID="GridViewAA" Width="95%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="12"
                                                                DataKeyNames="IsspHdr_ID,QuotationHdr_ID,Supplier_ID,Issp_No,SuppName,BalanceAmt">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkSelect" Text="Select" CssClass="LinkBtnSelect" Visible='<%#Bind("isVisible") %>' CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="Abstract_Date" DataFormatString="{0:d}" HeaderText="Abstract Date" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="BidType" HeaderText="Bid Type" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="Issp_Date" DataFormatString="{0:d}" HeaderText="ISSP Date" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="Issp_No" HeaderText="ISSP Number" />
                                                                    <asp:BoundField ItemStyle-Width="45%" ItemStyle-HorizontalAlign="left" DataField="SuppName" HeaderText="Bidder Name" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Right" DataField="TotalBidAmt" DataFormatString="{0:N}" HeaderText="Total Bid Amount" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="80%">
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Date :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtDate_NOA" CssClass="txtbox_Date" Width="20%" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender" TargetControlID="txtDate_NOA" PopupButtonID="txtDate_NOA" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender" TargetControlID="txtDate_NOA" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                        &nbsp;&nbsp;

                                                                        
                                                                        <asp:TextBox runat="server" ID="txtNOAtime" CssClass="txtbox_Date" Width="10%" Text="8:00" Visible="false"></asp:TextBox>
                                                                        &nbsp;<asp:DropDownList runat="server" ID="drpNOAtime" CssClass="drpdownCSS" Width="8%" Visible="false">
                                                                            <asp:ListItem Selected="True" Value="1" Text="A.M."></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="P.M."></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Approved By :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpSignatory_NOA" CssClass="drpdownCSS" Width="60%"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold"></td>
                                                                    <td style="width: 80%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold"></td>
                                                                    <td style="width: 80%" class="column_Left"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnSave_NOA" CssClass="CSButton" Width="15%" Text="Save" OnClientClick="StartProgressBar();" Enabled="false" />
                                                            &nbsp;<asp:Button runat="server" ID="btnPreview_NOA" CssClass="CSButton" Width="15%" Text="Preview" OnClientClick="StartProgressBar();" Enabled="false" />
                                                            &nbsp;<asp:Button runat="server" ID="btnPreview_OP" CssClass="CSButton" Width="15%" Text="Order of Payment" OnClientClick="StartProgressBar();" Enabled="false" Visible="False" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>





                                            <asp:View runat="server" ID="vwTab2_NTP">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdNTP" SkinID="GridViewAA" Width="95%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="12"
                                                                DataKeyNames="IsspHdr_ID,QuotationHdr_ID,Supplier_ID,Issp_No">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkSelect" Text="Select" CssClass="LinkBtnSelect" Visible='<%#Bind("isVisible") %>' CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="Abstract_Date" DataFormatString="{0:d}" HeaderText="Abstract Date" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="BidType" HeaderText="Bid Type" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="Issp_Date" DataFormatString="{0:d}" HeaderText="ISSP Date" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="Issp_No" HeaderText="ISSP Number" />
                                                                    <asp:BoundField ItemStyle-Width="45%" ItemStyle-HorizontalAlign="left" DataField="SuppName" HeaderText="Bidder Name" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Right" DataField="TotalBidAmt" DataFormatString="{0:N}" HeaderText="Total Bid Amount" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdReceipt" Width="40%" SkinID="GridViewAA" EmptyDataText="No Data Found." AllowPaging="false">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="35%" HeaderText="OR Number">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox runat="server" ID="txtORNumb" CssClass="txtbox_Var" Width="95%" Text=""></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30%" HeaderText="OR Date">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox runat="server" ID="txtORDate" CssClass="txtbox_Date" Width="95%" Text="" MaxLength="10"></asp:TextBox>
                                                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtORDate" PopupButtonID="txtORDate" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender" TargetControlID="txtORDate" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="35%" HeaderText="Amount">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="lblOPAmt" Text='<%#Bind("op_amt", "{0:N}") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="70%">
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Date :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtNTP_Date" CssClass="txtbox_Date" Width="20%" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtenderNTP" TargetControlID="txtNTP_Date" PopupButtonID="txtNTP_Date" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtenderNTP" TargetControlID="txtNTP_Date" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Approved by :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpApproved_NTP" CssClass="drpdownCSS" Width="60%"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold"></td>
                                                                    <td style="width: 80%" class="column_Left"></td>
                                                                </tr>
                                                            </table>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 98%" align="center">
                                                            <asp:Button ID="btnSave" Enabled="false" runat="server" Width="12%" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                                                            &nbsp;<asp:Button ID="btnPreview_NTP" Enabled="false" runat="server" Width="12%" CssClass="CSButton" Text="PREVIEW" OnClientClick="StartProgressBar();"></asp:Button>
                                                            &nbsp;<asp:Button ID="btnNoticePrev" Enabled="false" runat="server" Width="22%" CssClass="CSButton" Text="PREVIEW NOTICE TO ACCOUNTING" OnClientClick="StartProgressBar();"></asp:Button>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 20px" align="center"></td>
                                                    </tr>
                                                </table>

                                            </asp:View>






                                            <asp:View runat="server" ID="vwTab3_Jev">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdJEV" SkinID="GridViewAA" Width="95%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="12"
                                                                DataKeyNames="IsspHdr_ID,QuotationHdr_ID,Supplier_ID,Issp_No">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkSelect" Text="Select" CssClass="LinkBtnSelect" Visible='<%#Bind("isVisible") %>' CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="Abstract_Date" DataFormatString="{0:d}" HeaderText="Abstract Date" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="BidType" HeaderText="Bid Type" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="Issp_Date" DataFormatString="{0:d}" HeaderText="ISSP Date" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="Issp_No" HeaderText="ISSP Number" />
                                                                    <asp:BoundField ItemStyle-Width="45%" ItemStyle-HorizontalAlign="left" DataField="SuppName" HeaderText="Bidder Name" />
                                                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Right" DataField="TotalBidAmt" DataFormatString="{0:N}" HeaderText="Total Bid Amount" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">

                                                            <table width="90%">                                                               
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">JEV Date :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                           <asp:TextBox runat="server" ID="txtJevdate" CssClass="txtbox_Date" Width="40%" MaxLength="10"></asp:TextBox>
                                                                        <span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender2" TargetControlID="txtJevdate" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtJevdate" PopupButtonID="txtJevdate" PopupPosition="TopLeft"></cc1:CalendarExtender>

                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">JEV Number :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                          <asp:TextBox runat="server" ID="txtjev_no" CssClass="txtbox_Var" Width="60%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 20px" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnSaveJev" CssClass="CSButton" Width="12%" Text="Save" Enabled="false" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 20px" align="center"></td>
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
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp; 
        

        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

