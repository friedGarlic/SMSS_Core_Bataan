<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
    CodeFile="t_pre_procurement_public_bidding.aspx.vb" Inherits="t_pre_procurement_public_bidding"
    Title="Pre Procurement Public Bidding" StylesheetTheme="SkinFile" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <asp:UpdatePanel ID="upEmployeeDetail" runat="server">
        <ContentTemplate>

            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">PRE PROCUREMENT - PUBLIC BIDDING
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="left">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" CssClass="text5" Visible="False">
                                <asp:ListItem Selected="True">Goods</asp:ListItem>
                                <asp:ListItem>Public Infrastructure</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdPreProcurement" runat="server" Width="90%" OnSelectedIndexChanged="grdPreProcurement_SelectedIndexChanged"
                                AllowPaging="True" SkinID="GridViewAA" AutoGenerateColumns="False" DataKeyNames="obr_evaluation_hdr_id,TotalABC,isPublicInfra,isStraight,Transaction_type,PRCount"
                                OnPageIndexChanging="grdPreProcurement_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="DateEvaluated" DataFormatString="{0:d}" HeaderText="Date Evaluated">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="General Account">
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" Text='<%# Bind("GA_Title") %>' ID="TextBox2"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAccount" OnClick="lbAccount_Click" runat="server" Text='<%# Bind("GA_Title") %>' CommandName="Select" Font-Underline="False"></asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PRCount" HeaderText="No. of PR">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalABC" DataFormatString="{0:N}" HeaderText="Total ABC">
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Action">
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbCancel" OnClick="lbCancel_Click" runat="server" CssClass="LinkBtnCancel" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();" CommandName="Select" Font-Underline="False" Text="Return"></asp:LinkButton>
                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" TargetControlID="lbCancel" ConfirmText="Are you sure you want to return this PR to OBR Evaluation?"></cc1:ConfirmButtonExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>

                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Purchase Request
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <asp:GridView ID="gvIncomingPR" runat="server" Width="98%" OnSelectedIndexChanged="gvIncomingPR_SelectedIndexChanged" SkinID="GridViewAA" 
                                        AutoGenerateColumns="False" DataKeyNames="prhdr_id" EmptyDataText="No Data Found." ShowFooter="True" OnRowDataBound="gvIncomingPR_RowDataBound">
                                        <Columns>
                                            <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OBR_No" HeaderText="OBR Number">
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="rc_name" HeaderText="Department">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Function_Desc" HeaderText="Function">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Project Name">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("remarks") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <strong>TOTAL :</strong>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectName" runat="server" Text='<%# Bind("remarks") %>'></asp:Label>
                                                </ItemTemplate>

                                                <FooterStyle HorizontalAlign="Right"></FooterStyle>

                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ABC">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ABC") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalABC" runat="server"></asp:Label>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblABC" runat="server" Text='<%# Bind("ABC", "{0:N}") %>'></asp:Label>
                                                </ItemTemplate>

                                                <FooterStyle HorizontalAlign="Right"></FooterStyle>

                                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>

                                        <FooterStyle BackColor="#2977DC"></FooterStyle>
                                        <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                                    </asp:GridView>
                                </asp:View>

                                <asp:View ID="View2" runat="server">
                                    <asp:GridView ID="gvIncomingPR_infra" runat="server" Width="100%" OnSelectedIndexChanged="gvIncomingPR_infra_SelectedIndexChanged" DataKeyNames="prhdr_id,Project_ID,Program_id,pr_no,remarks,ABC,transaction_type,obr_evaluation_dtl_id,F_ID,isPublicInfra,isStraight" SkinID="GridViewAA" UseAccessibleHeader="False" Font-Size="9pt">
                                        <Columns>
                                            <asp:TemplateField HeaderText="OBR Number" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" Font-Underline="False" Text='<%#Bind("OBR_No") %>'
                                                        Visible='<%# bind("isVisible") %>' CausesValidation="False" CommandName="Select"></asp:LinkButton>

                                                </ItemTemplate>

                                                <ItemStyle Width="25%"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ABC">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ABC") %>'></asp:TextBox>

                                                </EditItemTemplate>
                                                <ItemTemplate>

                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ABC", "{0:N}") %>' Visible='<%# bind("isVisible") %>'></asp:Label>

                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="remarks" HeaderText="Project Name">
                                                <ItemStyle Width="60%"></ItemStyle>
                                            </asp:BoundField>
                                        </Columns>

                                        <FooterStyle BackColor="#2977DC"></FooterStyle>

                                        <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                                    </asp:GridView>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Information
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Reference Number (ITB No) :
                                    </td>
                                    <td style="width: 60%" class="column_Left">
                                        <asp:TextBox ID="txtProjectReferenceNumber2" runat="server" Width="60%" CssClass="drpdownCSS" OnTextChanged="txtProjectReferenceNumber2_TextChanged" Enabled="False"></asp:TextBox>
                                        <asp:TextBox ID="txtITBNumber" runat="server" Width="200px" CssClass="txtboxinspection" Visible="False" OnTextChanged="txtProjectReferenceNumber2_TextChanged" Enabled="False">ITBNumber</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Project / Contract Name :
                                    </td>
                                    <td style="width: 60%" class="column_Left">
                                        <asp:TextBox ID="txtContractName" runat="server" Width="60%" CssClass="txtbox_Remarks" TextMode="MultiLine" OnTextChanged="txtProjectReferenceNumber2_TextChanged" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Bid Document : 
                                    </td>
                                    <td style="width: 60%" class="column_Left">
                                        <asp:TextBox Style="text-align: right" ID="txtBidDoc" runat="server" Width="15%" CssClass="txtbox_Amt" OnTextChanged="txtBidDoc_TextChanged" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Date of Bid Opening :
                                    </td>
                                    <td style="width: 60%" class="column_Left">
                                        <asp:TextBox ID="txtDateReceive" runat="server" Width="15%" CssClass="txtbox_Date" Enabled="False"></asp:TextBox>
                                        &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Time of Bid Opening :
                                    </td>
                                    <td style="width: 60%" class="column_Left">
                                        <asp:TextBox ID="txtTime" runat="server" Width="15%" CssClass="txtbox_Date" Enabled="False" Text="1:00"></asp:TextBox>
                                        &nbsp;<asp:DropDownList ID="ddTime" runat="server" Width="10%" CssClass="drpdownCSS" Enabled="False">
                                            <asp:ListItem Value="1">A.M.</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="2">P.M.</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Place of Bid Opening :
                                    </td>
                                    <td style="width: 60%" class="column_Left">
                                        <asp:TextBox ID="txtOpeningVenue" runat="server" Width="60%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Project Location :
                                    </td>
                                    <td style="width: 60%" class="column_Left">
                                        <asp:TextBox ID="txtProjectLocation" runat="server" Width="60%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Bidding Category :
                                    </td>
                                    <td style="width: 60%" class="column_Left">
                                        <asp:RadioButtonList ID="rdisInfra" runat="server" Width="250px" RepeatDirection="Horizontal" CssClass="rbCS_Horizontal">
                                            <asp:ListItem Selected="True" Value="0">Goods</asp:ListItem>
                                            <asp:ListItem Value="1">Public Infrastructure</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold"></td>
                                    <td style="width: 60%" class="column_Left">
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtBidDoc" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateReceive" PopupButtonID="ImageButton1"></cc1:CalendarExtender>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDateReceive" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnsave" ConfirmText="Are you sure you want to save  this transaction?"></cc1:ConfirmButtonExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnsave" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="SAVE" OnClientClick="StartProgressBar();" ValidationGroup="savePublicBidding"></asp:Button>
                            &nbsp;<asp:Button ID="btnprintOP" OnClick="btnprintOP_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="PREVIEW OP"></asp:Button>
                            &nbsp;<asp:Button ID="btnBidForm" OnClick="btnBidForm_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="PREVIEW BID FORM"></asp:Button>
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

