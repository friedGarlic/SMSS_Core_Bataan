<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="boss_BudgetPPA.aspx.vb"
    Inherits="filemaintenance_boss_BudgetPPA" Title="FM - Budget PPA" StylesheetTheme="SkinFile" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">





</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblerror" runat="server"></asp:Label>


            <div>
             
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <asp:TextBox id="lblappstatus" visible= "false" runat="server"></asp:TextBox>
                        <td style="width: 98%" class="PageTitle">BUDGET FOR PROGRAMS / PROJECTS / ACTIVITIES (PPA)
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 90%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Budget Year : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddYear" runat="server" Width="15%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddYear_SelectedIndexChanged">
                                             <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                             <%--<asp:ListItem Value="1" Text="2023"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="2024"></asp:ListItem>
                                             --%>
                                        </asp:DropDownList></td>
                                    
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Department : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddDepartment" runat="server" Width="75%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddDepartment_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Function : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddFunction" runat="server" Width="75%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddFunction_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                               
                                
                                <tr>
                                    <td class="column_RightBold" style="width: 20%">Fund :</td>
                                    <td class="column_Left" style="width: 80%">
                                        <asp:DropDownList ID="drpFund" runat="server" Width="25%" CssClass="drpdownCSS" AutoPostBack="true">
                                           <%-- <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="General Fund"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Special Educational Fund"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Trust Fund"></asp:ListItem>--%>

                                        </asp:DropDownList>
                                        <asp:CheckBox ID="CBIsInfra" runat="server" CssClass="rbCS_Horizontal" Width="80px" Text="Infra" AutoPostBack="true" OnCheckedChanged="CBIsInfra_CheckedChanged"></asp:CheckBox>
                                    </td>
                                 
                                </tr>
                                <tr>
                                    <td class="column_RightBold">

                                        Fund Description :</td>
                                    <td class="column_Left">

                                        <asp:TextBox ID="txtTrustFundRemarks" runat="server" Width="75%" CssClass="txtbox_Remarks" Enabled="false"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 20%">PPA Description : 
                                    </td>
                                    <td class="column_Left" style="width: 80%">
                                        <asp:TextBox ID="txtPPA_Desc" runat="server" Width="75%" Height="40px" CssClass="txtbox_Remarks" TextMode="MultiLine"></asp:TextBox></td>
                                </tr>  

                                <tr>
                                    <td class="column_RightBold" style="width: 20%">Approved Budget :</td>
                                    <td class="column_Left" style="width: 80%">
                                        <asp:TextBox ID="txtApproved" runat="server" Width="15%" CssClass="txtbox_Amt" AutoPostBack="True" OnTextChanged="txtApproved_TextChanged" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);">0.00</asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789.," TargetControlID="txtApproved">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField ID="hndApprovedBudgetValue" runat="server" />
                            <asp:HiddenField ID="hndSelectedBudgetValue" runat="server" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnSavePPA" runat="server" CssClass="CSButton" Width="150px" OnClick="btnSavePPA_Click" OnClientClick="StartProgressBar();" Text="SAVE" />
                            &nbsp;<asp:Button ID="btnCancelPPA" runat="server" CssClass="CSButton" Width="150px" OnClick="btnCancelPPA_Click" Text="CANCEL" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List of PPA
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdPPA_List" runat="server" Width="90%"  DataKeyNames="RC_ID,Function_ID,Program_ID,Project_ID,Budget_Year,ApprovedFinal,PPA_Desc,F_ID" PageSize="5" AutoGenerateColumns="False"
                                OnSelectedIndexChanged="grdPPA_List_SelectedIndexChanged" OnPageIndexChanging="grdPPA_List_PageIndexChanging" SkinID="GridViewAA" EmptyDataText="No Data Found." AllowPaging="True">
                                <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                    NextPageText="Next" PreviousPageText="Previous" />--%>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="false" CssClass="LinkBtnSelect" CommandName="Select" Text="Select">
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                       
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PPA_Desc" HeaderText="PPA Description">
                                        <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ApprovedFinal" DataFormatString="{0:N}" HeaderText="Approved Budget">
                                        <ItemStyle HorizontalAlign="Right" Width="15%" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="FundSource" HeaderText="Fund Source">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    </asp:BoundField>
                                   
                                </Columns>
                                <PagerStyle Font-Bold="True" />
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Budget Details
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 90%">
                                <tr>
                                    <td class="column_RightBold" style="width: 20%">Allotment Class : 
                                    </td>
                                    <td class="column_Left" style="width: 80%">
                                        <asp:DropDownList ID="ddAllotment" runat="server" Width="75%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddAllotment_SelectedIndexChanged" Enabled="False"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 20%">Accounts :</td>
                                    <td class="column_Left" style="width: 80%">
                                        <asp:DropDownList ID="ddAccounts" runat="server" Width="75%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddAccounts_SelectedIndexChanged" Enabled="False"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 20%">Amount :
                                    </td>
                                    <td class="column_Left" style="width: 80%">
                                        <asp:TextBox ID="txtAccountAmt" runat="server" AutoPostBack="True" CssClass="txtbox_Amt" Enabled="False" OnTextChanged="txtAccountAmt_TextChanged" Width="15%" Text="0.00" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" ValidChars="0123456789.," TargetControlID="txtAccountAmt"></cc1:FilteredTextBoxExtender>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 20%"></td>
                                    <td class="column_Left" style="width: 80%"></td>
                                </tr>
                            </table>

                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="CSButton" Width="150px" OnClientClick="StartProgressBar();" Text="SAVE" Enabled="False"></asp:Button>
                            &nbsp;<asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" CssClass="CSButton" Width="150px" Text="CANCEL"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">TRANSACTION</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%; height: 148px;"></td>
                        <td style="width: 98%; height: 148px;" align="center">
                            <asp:GridView ID="grdAccounts" runat="server" Width="90%" DataKeyNames="RC_ID,Function_ID,Program_ID,Project_ID,Budget_Year,GA_ID,BGA_ID,ApprovedFinal,PPA_Desc,AllotmentClass_ID,GA_CODE" PageSize="12" AutoGenerateColumns="False" 
                                OnSelectedIndexChanged="grdAccounts_SelectedIndexChanged" SkinID="GridViewAA" EmptyDataText="No Data Found." ShowFooter="True" FooterStyle-Wrap="True">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server"  Font-Underline="false" CommandName="Select">
                                            <span class="LinkBtnSelect">Select</span>
                                            </asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="GA_Title2" FooterText="TOTAL :" FooterStyle-HorizontalAlign="Right" HeaderText="Account">
                                        <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                    </asp:BoundField>

                                 <%--   <asp:BoundField DataField="ApprovedFinal" DataFormatString="{0:N}" HeaderText="Approved Budget  (DEBIT)">
                                        <ItemStyle HorizontalAlign="Right" Width="17%"></ItemStyle>
                                    </asp:BoundField>--%>

                                    <asp:TemplateField HeaderText="Approved Budget  (DEBIT)" ItemStyle-Width="17%" ItemStyle-HorizontalAlign="Right">
                                           <ItemTemplate>
                                                  <asp:Label Style="text-align: right" ID="lblProvedBudget" runat="server" Text='<%# Bind("ApprovedFinal", "{0:N}") %>'></asp:Label>
                                           </ItemTemplate>
                                           <FooterTemplate>
                                                  <asp:Label Style="text-align: right" ID="lblTotalApprovedBudget" runat="server" Width="115px" Font-Bold="true" ForeColor="White" Text="0.00" Height="18px"></asp:Label>
                                           </FooterTemplate>
                                          <FooterStyle HorizontalAlign="Right" Font-Bold="False" ForeColor="White"></FooterStyle>
                                    </asp:TemplateField>


<%--                                <asp:BoundField DataField="PR_Amt" DataFormatString="{0:N}" HeaderText="Purchase Request (CREDIT)">
                                        <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
                                    </asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="Purchase Order (CREDIT)" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Right">
                                           <ItemTemplate>
                                                  <asp:Label Style="text-align: right" ID="lblPurchaseRequest" runat="server" Text='<%# Bind("PR_Amt", "{0:N}") %>'></asp:Label>
                                           </ItemTemplate>
                                           <FooterTemplate>
                                                  <asp:Label Style="text-align: right" ID="lblTotalPurchaseRequest" runat="server" Width="115px" Font-Bold="true" ForeColor="White" Text="0.00" Height="18px"></asp:Label>
                                           </FooterTemplate>
                                           <FooterStyle HorizontalAlign="Right" Font-Bold="False" ForeColor="White"></FooterStyle>
                                    </asp:TemplateField>


                                    <%--<asp:BoundField DataField="Balance" DataFormatString="{0:N}" HeaderText="BALANCE">
                                        <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
                                    </asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="BALANCE" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Right">
                                           <ItemTemplate>
                                                  <asp:Label Style="text-align: right" ID="lblPPABalance" runat="server" Text='<%# Bind("Balance", "{0:N}") %>'></asp:Label>
                                           </ItemTemplate>
                                             <FooterTemplate>
                                                  <asp:Label Style="text-align: right" ID="lblTotalPPABalance" runat="server" Width="115px" Font-Bold="true" ForeColor="White" Text="0.00" Height="18px"></asp:Label>
                                           </FooterTemplate>
                                           <FooterStyle HorizontalAlign="Right" Font-Bold="False" ForeColor="White"></FooterStyle>
                                    </asp:TemplateField>


                                      
                                </Columns>

                                <PagerStyle Font-Bold="True"></PagerStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%; height: 148px;"></td>
                    </tr>
                     <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">LIST OF PURCHASE ORDER
                        </td>
                       
                    </tr>
                    
                     <tr>
                        <td style="width: 1%; height: 148px;" </td>
                        <td style="width: 98%; height: 148px;" valign="top" align="center">
                            <asp:GridView ID="GrdLedger" runat="server" Width="100%" DataKeyNames="prhdr_id" PageSize="12" AutoGenerateColumns="False" 
                                 SkinID="GridViewAA" EmptyDataText="No Data Found." OnSelectedIndexChanged="GrdLedger_SelectedIndexChanged">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
                                <Columns>
                                     <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Preview" runat="server" Font-Underline="true" CommandName="Select">
                                            <span class="LinkBtnPreview">Preview</span>
                                            </asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                   <asp:BoundField DataField="pr_no" HeaderText="PR No.">
                                        <ItemStyle HorizontalAlign="Left" Width= "15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Particulars" HeaderText="Particulars">
                                        <ItemStyle HorizontalAlign="Left" Width= "20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N2}" HeaderText="Amount">
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MOP" HeaderText="Mode of Procurement">
                                  <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                  </asp:BoundField>
                                  <asp:BoundField DataField="PO_Date" DataFormatString="{0:&quot;MM/dd/yyyy&quot;}" HeaderText="Purchase Order">
                                  <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                  </asp:BoundField>
                                  <asp:BoundField DataField="Received_Date" DataFormatString="{0:&quot;MM/dd/yyyy&quot;}" HeaderText="Received">
                                  <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                  </asp:BoundField>
                                  <asp:BoundField DataField="AIR_Date" DataFormatString="{0:&quot;MM/dd/yyyy&quot;}" HeaderText="Accepted">
                                  <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                  </asp:BoundField>
                                                                  </Columns>

                                <PagerStyle Font-Bold="True"></PagerStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%; height: 148px;"></td>
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
       
            
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

