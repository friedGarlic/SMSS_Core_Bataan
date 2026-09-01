<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="t_abstract_of_canvass.aspx.vb" Inherits="t_abstract_of_canvass"
    Title="Abstract of Canvass" StylesheetTheme="SkinFile" EnableEventValidation="false" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">


</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">ABSTRACT OF CANVASS
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search By :</span>
                            &nbsp;<asp:DropDownList ID="ddSearch" runat="server" Width="120px" CssClass="drpdownCSS" OnSelectedIndexChanged="ddSearch_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="1">PR Number</asp:ListItem>
                                <asp:ListItem Value="2">OBR Number</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:Label runat="server" ID="lblSearchBy" Text="PR Nnumber :" class="column_RightBold"></asp:Label>
                            &nbsp;<asp:TextBox ID="txtSearchPR" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearchPR" OnClick="btnSearchPR_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="SEARCH"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdItemList" runat="server" Width="70%" OnSelectedIndexChanged="grdItemList_SelectedIndexChanged" OnPageIndexChanging="grdItemList_PageIndexChanging"
                                AllowPaging="True" SkinID="GridViewAA" AutoGenerateColumns="False" PageSize="8" DataKeyNames="prhdr_id,Hdr_ID,Canvass_Date,isReCanvass"
                                EmptyDataText="No Data Found.">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" Text="Select" Font-Underline="false" CssClass="LinkBtnSelect" OnClick="lnkSelect_Click" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="8%"/>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="PR Number">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" CausesValidation="False" Text='<%# bind("pr_no") %>' CommandName="Select" Font-Underline="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="center" Width="30%"></ItemStyle>
                                    </asp:TemplateField>--%>
                                     <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OBR_No" HeaderText="CAA Number">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="27%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NoBidder" HeaderText="No. of Bidder">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Canvass_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date of Canvass">
                                        <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>
                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List Of Goods
                        </td>
                        <td style="width: 1%"></td>
                    </tr >
                    <tr>
                        <td style="width: 1%"></td>
                         <td style="width: 98%; text-align:center" class="column_LeftBold">Bidders list : 
                             <asp:DropDownList ID="drpListOfBidders" CssClass="drpdownCSS" runat="server" Width="350px" OnSelectedIndexChanged="drpListOfBidders_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                         <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Width="98%" ScrollBars="Vertical" CssClass="PanelSize">
                                        <asp:GridView ID="grdList" runat="server" Width="100%" EmptyDataText="No Data Found." DataKeyNames="Item_ID" PageSize="8"
                                            AutoGenerateColumns="False" SkinID="GridViewAA">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDesc" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                                </asp:TemplateField>

                                                 <%--<asp:BoundField DataField="Item_Desc" HeaderText="Description" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="left" Width="40%"></ItemStyle>
                                                </asp:BoundField>--%>

                                                <asp:BoundField DataField="ApprovedBudget" DataFormatString="{0:N}" HeaderText="Approved Budget">
                                                    <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="List of Bidder">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddBidder" runat="server" Width="98%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddBidder_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="40%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Dtl_ID1">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDtl_ID1" runat="server" Text='<%# Bind("Dtl_ID1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <FooterStyle BackColor="#2977DC"></FooterStyle>
                                            <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                                        </asp:GridView>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr align="center">
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px">
                            <asp:Button ID="AddRemarks" runat="server" CssClass="CSButton"  Text="ADD REMARKS" Width="150px" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">BAC Signatories
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="98%">                                
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">BAC Member 1 :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="ddBAC1" runat="server" Width="90%" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold">BAC Member 4 :</td>
                                    <td style="width: 41%" align="left">
                                         <asp:DropDownList ID="ddBAC4" runat="server" CssClass="drpdownCSS" Width="90%">
                                         </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">BAC Member 2 :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="ddBAC2" runat="server" Width="90%" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold">BAC Vice Chair :</td>
                                    <td style="width: 41%" align="left">
                                        <asp:DropDownList ID="ddBACVC" runat="server" CssClass="drpdownCSS" Width="90%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">BAC Member 3 :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="ddBAC3" runat="server" Width="90%" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold">BAC Chairman :</td>
                                    <td style="width: 41%" align="left">
                                        <asp:DropDownList ID="ddBACC" runat="server" CssClass="drpdownCSS" Width="90%">
                                        </asp:DropDownList>
                                         <asp:Label ID="lblBAC_Pos" runat="server" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">Canvassed By :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="ddPreparedBy" runat="server" Width="90%" OnSelectedIndexChanged="ddPreparedBy_SelectedIndexChanged" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold">Approved By :</td>
                                    <td style="width: 41%" align="left">
                                        <asp:DropDownList ID="ddApprovedBy" runat="server" CssClass="drpdownCSS" Width="90%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold"></td>
                                    <td class="column_Left"></td>
                                    <td class="column_RightBold">&nbsp;</td>
                                    <td class="column_Left">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%; height: 26px;"></td>
                        <td style="width: 98%; height: 26px;" align="center">
                            <asp:Button ID="btnPreWinning" runat="server" CssClass="CSButton" Enabled="False" OnClientClick="StartProgressBar();" Text="Pre-Winning" Width="150px" />&nbsp;
                            <asp:Button ID="btnPrintPreAOQ" runat="server" CssClass="CSButton" Enabled="False"  OnClientClick="StartProgressBar();" Text="Preview Pre AOQ" Width="150px" />&nbsp;
                            <asp:Button ID="btnWinner" runat="server" CssClass="CSButton" Enabled="False" OnClick="btnWinner_Click" OnClientClick="StartProgressBar();" Text="DECLARE WINNER/S" Width="150px" />
                            &nbsp;&nbsp;<asp:Button ID="btnPreview" runat="server" CssClass="CSButton" Enabled="False" OnClick="btnPreview_Click" OnClientClick="StartProgressBar();" Text="PREVIEW AOQ" Width="150px" />
                            <asp:Button ID="btnNOA" runat="server" CssClass="CSButton" Enabled="False" OnClick="btnNOA_Click" OnClientClick="StartProgressBar();" Text="PREVIEW NOA" Visible="false" Width="150px" />
                        </td>
                        <td style="width: 1%; height: 26px;"></td>
                    </tr>
                    <tr align="center">
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                            &nbsp;</td>
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button> 
        

            
             <asp:Panel ID="popupParticular" runat="server" Width="800px" CssClass="Panel_Popup">
                 <table width="100%">
                     <tr>
                         <td>
                             <asp:GridView ID="grdSupplierRemarks" runat="server" BackColor="White" EmptyDataText="No Data Found." Font-Size="9pt" PageSize="12" SkinID="GridViewAA" Width="100%">
                                 <Columns>
                                     <asp:BoundField DataField="SuppName" HeaderText="Supplier">
                                     <HeaderStyle HorizontalAlign="Center" />
                                     <ItemStyle HorizontalAlign="Left" Width="50%" />
                                     </asp:BoundField>
                                     <asp:TemplateField HeaderText="Remarks">
                                         <ItemTemplate>
                                             <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("Remarks") %>' Width="97%"></asp:TextBox>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                 </Columns>
                             </asp:GridView>
                         </td>
                       
                     </tr>
                     <tr>
                         <td align="center">
                             <asp:Button ID="btnSaveSupplierRemarks" runat="server" CssClass="CSButton"  OnClientClick="StartProgressBar();" Text="SAVE" Width="150px" />&nbsp;
                             <asp:Button ID="btnCancelRemarks" runat="server" CssClass="CSButton"  OnClientClick="StartProgressBar();" Text="CLOSE" Width="150px" />
                         </td>
                     </tr>
                     <tr>
                         <td>
                             <asp:Label ID="Label3" runat="server" Text="" ></asp:Label>
                         </td>
                     </tr>
                 </table>
             </asp:Panel>
             <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" BackgroundCssClass="modalBackground" CancelControlID="ImageButton2" PopupControlID="popupParticular" TargetControlID="Label3">
             </cc1:ModalPopupExtender>
             <asp:Panel ID="popEditAOQ" runat="server" Width="800px" CssClass="Panel_Popup">
                 <table width="100%">
                   <tr>
                      <td class="DivTitle">Supplier Remarks</td>
                   </tr>
                   <tr>
                       <td>
                           <asp:GridView ID="grvSupplierRemarksEdit" runat="server" BackColor="White" EmptyDataText="No Data Found." Font-Size="9pt" PageSize="12" SkinID="GridViewAA" Width="100%">
                               <Columns>
                                   <asp:BoundField DataField="SuppName" HeaderText="Supplier">
                                       <HeaderStyle HorizontalAlign="Center" />
                                       <ItemStyle HorizontalAlign="Left" Width="50%" />
                                   </asp:BoundField>
                                   <asp:TemplateField HeaderText="Remarks">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtRemarksEdit" runat="server" Text='<%# Bind("Remarks") %>' Width="97%"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                               </Columns>
                           </asp:GridView>
                       </td>
                   </tr>
                   <tr>
                       <td class="DivTitle">Signatories</td>
                   </tr>
                   <tr>
                       <td>
                            <table width="100%">                                
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">BAC Member 1 :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="drpBM1" runat="server" Width="90%" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold">BAC Member 4 :</td>
                                    <td style="width: 41%" align="left">
                                         <asp:DropDownList ID="drpBM4" runat="server" CssClass="drpdownCSS" Width="90%">
                                         </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">BAC Member 2 :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="drpBM2" runat="server" Width="90%" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold">BAC Vice Chair :</td>
                                    <td style="width: 41%" align="left">
                                        <asp:DropDownList ID="drpBVC" runat="server" CssClass="drpdownCSS" Width="90%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">BAC Member 3 :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="drpBM3" runat="server" Width="90%" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold">BAC Chairman :</td>
                                    <td style="width: 41%" align="left">
                                        <asp:DropDownList ID="drpBC" runat="server" CssClass="drpdownCSS" Width="90%">
                                        </asp:DropDownList>
                                         <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">Canvassed By :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="drpEditCanvassed" runat="server" Width="90%"  CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold">Approved By :</td>
                                    <td style="width: 41%" align="left">
                                        <asp:DropDownList ID="drpApprovedByEdit" runat="server" CssClass="drpdownCSS" Width="90%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="height: 17px"></td>
                                    <td class="column_Left" style="height: 17px">
                                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="column_RightBold" style="height: 17px"></td>
                                    <td class="column_Left" style="height: 17px">
                                        </td>
                                </tr>
                            </table>
                       </td>
                   </tr>
                   <tr>
                       <td align="center">
                           
                                      <asp:Button ID="btnSavedEdit" runat="server" Width="120px" CssClass="CSButton" Text="Save" />
                                    &nbsp;
                                      <asp:Button ID="btnCancelEdit" runat="server" Width="120px" CssClass="CSButton" Text="Cancel" />
                       </td>
                   </tr>
                 </table>
             </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtenderEditAOQ" runat="server" BackgroundCssClass="modalBackground" CancelControlID="ImageButton2" PopupControlID="popEditAOQ" TargetControlID="Label4">
             </cc1:ModalPopupExtender>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

