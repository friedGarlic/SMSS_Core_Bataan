<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="boss_BudgetOOE.aspx.vb"
    Inherits="filemaintenance_boss_BudgetOOE" Title="FM - Budget OOE" StylesheetTheme="SkinFile" EnableEventValidation="false" %>

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
                        <td style="width: 98%" class="PageTitle">BUDGET FOR OFFICE OPERATIONAL EXPENSES (OOE)
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
                                        <asp:DropDownList ID="ddYear" runat="server" Width="15%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddYear_SelectedIndexChanged"></asp:DropDownList></td>
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
                                    <td style="width: 20%" class="column_RightBold">Allotment Class : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddAllotment" runat="server" Width="75%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddAllotment_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Fund (OOE) : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="drpFund" runat="server" Width="25%" CssClass="drpdownCSS" AutoPostBack="true">
                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="General Fund"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Special Educational Fund"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Trust Fund"></asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                            </table>
                        </td>
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
                            <table width="90%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Account :</td>
                                    <td style="width: 80%" align="left">
                                        <asp:DropDownList ID="ddAccounts" runat="server" Width="75%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddAccounts_SelectedIndexChanged" Enabled="False"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold"></td>
                                    <td style="width: 80%; height: 5px" align="left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Proposed Budget :</td>
                                    <td style="width: 80%" align="left">
                                        <asp:TextBox ID="txtProposed" runat="server" Width="15%" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox>
                                        &nbsp;<asp:Label ID="lblReminders" runat="server" Font-Bold="False" ForeColor="Red" Font-Size="8pt" Visible="False" Font-Italic="True" Text="* Adjust your PPMP"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Approved Budget :</td>
                                    <td style="width: 80%" align="left">
                                        <asp:TextBox ID="txtApproved" runat="server" Width="15%" CssClass="txtbox_Amt" AutoPostBack="True" Enabled="False" OnTextChanged="txtApproved_TextChanged" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789.," TargetControlID="txtApproved"></cc1:FilteredTextBoxExtender>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold"></td>
                                    <td style="width: 80%" align="left"></td>
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
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="CSButton" Width="150px" Text="SAVE BUDGET" OnClientClick="StartProgressBar();"></asp:Button>
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
                        <td style="width: 98%" class="DivTitle">TRANSACTION
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdAccounts" runat="server" Width="98%" OnSelectedIndexChanged="grdAccounts_SelectedIndexChanged"  SkinID="GridViewAA" AutoGenerateColumns="False" PageSize="15" AllowPaging="True"
                                DataKeyNames="RC_ID,Function_ID,Program_ID,Project_ID,Budget_Year,GA_ID,BGA_ID,ApprovedFinal,GA_CODE" EmptyDataText="No Data Found.">
                                <PagerSettings NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="false" CommandName="Select">
                                          <span class="LinkBtnSelect">Select</span>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="GA_Title2" HeaderText="Account">
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GA_Code2" HeaderText="Account Code">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ApprovedFinal" DataFormatString="{0:N}" HeaderText="Approved Budget (DEBIT)">
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                      <asp:BoundField DataField="PR_Amt" DataFormatString="{0:N}" HeaderText="Purchase Request (CREDIT)">
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Balance" DataFormatString="{0:N}" HeaderText="Balance">
                                        <ItemStyle HorizontalAlign="center" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                                <PagerStyle Font-Bold="True"></PagerStyle>
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
                        <td style="width: 98%" class="DivTitle">LIST OF PURCHASE REQUEST
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                     <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                           <asp:GridView ID="grdledger" runat="server" Width="98%" SkinID="GridViewAA" AutoGenerateColumns="False" 
    PageSize="15" AllowPaging="True" DataKeyNames="prhdr_id" EmptyDataText="No Data Found." 
    OnSelectedIndexChanged="grdledger_SelectedIndexChanged" ShowFooter="True" OnRowDataBound="grdledger_RowDataBound">
    <PagerSettings NextPageText="Next" PreviousPageText="Previous" />
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="Preview" runat="server" Font-Underline="true" CommandName="Select">
                    <span class="LinkBtnPreview">Preview</span>
                </asp:LinkButton>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="10%" />
        </asp:TemplateField>
        <asp:BoundField DataField="pr_no" HeaderText="PR No.">
            <ItemStyle HorizontalAlign="Left" Width="15%" />
        </asp:BoundField>
        <asp:BoundField DataField="Particulars" HeaderText="Particulars">
            <ItemStyle HorizontalAlign="Left" Width="20%" />
        </asp:BoundField>
        <asp:BoundField DataField="MOP" HeaderText="Mode of Procurement">
            <ItemStyle HorizontalAlign="Left" Width="18%" />
        </asp:BoundField>
        <asp:BoundField DataField="PO_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Purchase Order">
            <ItemStyle HorizontalAlign="Center" Width="8%" />
        </asp:BoundField>
        <asp:BoundField DataField="Received_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Received">
            <ItemStyle HorizontalAlign="Center" Width="8%" />
        </asp:BoundField>
        <asp:BoundField DataField="AIR_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Accepted">
            <ItemStyle HorizontalAlign="Center" Width="8%" />
        </asp:BoundField>
        <asp:BoundField DataField="ABC" DataFormatString="{0:N2}" HeaderText="PR_Amount">
            <ItemStyle HorizontalAlign="Right" Width="10%" />
            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
        </asp:BoundField>
    </Columns>
    <PagerStyle Font-Bold="True" />
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp; 
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

