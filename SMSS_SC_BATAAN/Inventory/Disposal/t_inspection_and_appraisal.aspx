<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_inspection_and_appraisal.aspx.vb" Inherits="t_inspection_and_appraisal" Title="Inspection And  Appraisal" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">INSPECTION AND APPRAISAL
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="left">
                            <table width="100%">
                                <tr>
                                    <td style="width: 5%" class="column_RightBold">Goods :</td>
                                    <td style="width: 95%" align="left">
                                        <asp:RadioButtonList ID="rbChoice" runat="server" Width="220px" CssClass="rbCS_Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbChoice_SelectedIndexChanged" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Properties</asp:ListItem>
                                            <asp:ListItem Value="2">Supplies</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr style ="display:none;">
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Unserviceable Properties
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                     <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <asp:MultiView ID="mvCategory" runat="server">
                                <asp:View ID="vwProperty" runat="server">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle" colspan="2">PROPERTIES
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center" colspan="2">
                                                    <table width="100%">
                                                         <tr>
                                                            <td style="width: 1%">
                                                            </td>
                                                            <td style="width: 98%" align="center">
                                                                <asp:GridView ID="gvNEW" runat="server" Width="70%" SkinID="GridViewAA" DataKeyNames="IIRUPHdr_ID,IIRUP_Date" AutoGenerateColumns="False"
                                                                    PageSize="5" AllowPaging="True" CaptionAlign="Left" EmptyDataText="No Data Found.">
                                                                    <Columns>
                                                                        <asp:TemplateField ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" Text="Select" CssClass="LinkBtnSelect" Font-Underline="false" CommandName="Select" __designer:wfdid="w5"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Font-Underline="False" ForeColor="Blue" Width="10%"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="IIRUPHdr_ID" HeaderText="Transaction Number">
                                                                            <ItemStyle HorizontalAlign="Center" Width="40%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="IIRUP_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date" HtmlEncode="False">
                                                                            <ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                    </Columns>

                                                                    <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                                                                </asp:GridView>
                                                            </td>
                                                            <td style="width: 1%"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 1%"></td>
                                                            <td style="width: 98%" class="DivTitle">List of Goods
                                                            </td>
                                                            <td style="width: 1%"></td>
                                                        </tr>
                                                         <tr>
                                                            <td style="width: 1%"></td>
                                                            <td style="width: 98%" align="center">
                                                                <asp:GridView ID="gvbody" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="Property_ID,Item_Desc,PropertyNo"
                                                                    AutoGenerateColumns="False" EmptyDataText="No Data Found.">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                                            <ItemStyle HorizontalAlign="Left" Width="55%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="PropertyNo" HeaderText="Property Number">
                                                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="Mode of Disposal">
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="ddMD" runat="server" Width="99%" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddMD_SelectedIndexChanged">
                                                                                    <asp:ListItem Selected="True" Value="0">--SELECT--</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Public Auction</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Private Sale</asp:ListItem>
                                                                                    <asp:ListItem Value="3">Destroy</asp:ListItem>
                                                                                    <asp:ListItem Value="4">Donation</asp:ListItem>
                                                                                    <asp:ListItem Value="5">Cancel</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Appraised Value">
                                                                            <ItemTemplate>

                                                                                <asp:TextBox ID="txtappraisedval" runat="server" Width="98%" CssClass="txtbox_Amt" Text='<%# Bind("AppraisedVal", "{0:N}") %>' AutoPostBack="True" OnTextChanged="txtappraisedval_TextChanged"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtappraisedval" ValidChars="0123456789.,">
                                                                                </cc1:FilteredTextBoxExtender>

                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Net Book Value">
                                                                            <ItemTemplate>

                                                                                <asp:TextBox ID="txtNetBookValue" runat="server" Width="98%" CssClass="txtbox_Amt" Text='<%# Bind("netval", "{0:N}") %>' AutoPostBack="True" OnTextChanged="txtNetBookValue_TextChanged"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtNetBookValue" ValidChars="0123456789.,">
                                                                                </cc1:FilteredTextBoxExtender>


                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                            <td style="width: 1%"></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center" colspan="2"></td>
                                            </tr>

                                            <tr>
                                                <td style="width: 50%">
                                                    <asp:DropDownList ID="ddInspector" runat="server" Width="285px" Visible="False">
                                                    </asp:DropDownList></td>
                                                <td style="width: 50%">
                                                    <asp:TextBox ID="txtdate" runat="server" Width="100px" Visible="False" SkinID="text"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%">
                                                    <asp:DropDownList ID="ddappraiser" runat="server" Width="285px" Visible="False">
                                                    </asp:DropDownList></td>
                                                <td style="width: 50%"></td>
                                            </tr>

                                        </tbody>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwSupply" runat="server">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle">SUPPLIES</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView Style="font-weight: normal" ID="grdSupply" runat="server" Width="70%" Font-Size="9pt" SkinID="GridViewAA" OnSelectedIndexChanged="grdSupply_SelectedIndexChanged" DataKeyNames="IIRUS_ID" AutoGenerateColumns="False" PageSize="5" AllowPaging="True" CaptionAlign="Left" EmptyDataText="No Data Found.">
                                                        <Columns>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                        Font-Underline="True" ForeColor="Black" Text="Select"></asp:LinkButton>

                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="IIRUS_ID" HeaderText="TransactionID">
                                                                <ItemStyle HorizontalAlign="Center" Width="40%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="IIRUS_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date" HtmlEncode="False">
                                                                <ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
                                                            </asp:BoundField>
                                                        </Columns>

                                                        <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                             <tr>
                                                 <td style="width: 100%" class="DivTitle">List of Goods
                                                 </td>
                                             </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView Style="font-weight: normal" ID="grdSupplyInfo" runat="server" Width="98%" Font-Size="9pt" SkinID="GridViewAA" DataKeyNames="StockID" AutoGenerateColumns="False" EmptyDataText="No Data Found." __designer:wfdid="w11">
                                                        <Columns>
                                                            <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                                <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Mode of Disposal">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddDispose" runat="server" Width="99%" AutoPostBack="True" OnSelectedIndexChanged="ddDispose_SelectedIndexChanged">
                                                                        <asp:ListItem Selected="True" Value="0">--SELECT--</asp:ListItem>
                                                                        <asp:ListItem Value="1">Public Auction</asp:ListItem>
                                                                        <asp:ListItem Value="2">Private Sale</asp:ListItem>
                                                                        <asp:ListItem Value="3">Destroy</asp:ListItem>
                                                                        <asp:ListItem Value="4">Donation</asp:ListItem>
                                                                        <asp:ListItem Value="5">Cancel</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Appraised Value">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AppraisedVal") %>'></asp:TextBox>

                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:TextBox Style="text-align: right" ID="txtappraisedval" runat="server" Width="95%" AutoPostBack="True" OnTextChanged="txtappraisedval_TextChanged1">0.00</asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtappraisedval" ValidChars="0123456789.,">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="StockID">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox runat="server" Text='<%# Bind("StockID") %>' ID="TextBox3"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStockID" runat="server" Text='<%# Bind("StockID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
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
                        <td style="width: 98%" class="DivTitle">Details And Signatories
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Date :</td>
                                    <td style="width: 85%" align="left">
                                        <asp:TextBox ID="txtOpenDate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                        &nbsp;<span class="column_RightBold">Time :</span>
                                        &nbsp;<asp:DropDownList ID="ddHour" runat="server" CssClass="drpdownCSS" Width="50px">
                                            <asp:ListItem Selected="True">01</asp:ListItem>
                                            <asp:ListItem>02</asp:ListItem>
                                            <asp:ListItem>03</asp:ListItem>
                                            <asp:ListItem>04</asp:ListItem>
                                            <asp:ListItem>05</asp:ListItem>
                                            <asp:ListItem>06</asp:ListItem>
                                            <asp:ListItem>07</asp:ListItem>
                                            <asp:ListItem>08</asp:ListItem>
                                            <asp:ListItem>09</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<span class="column_RightBold">:</span>
                                        &nbsp;<asp:DropDownList ID="ddMinute" runat="server" Width="50px" CssClass="drpdownCSS">
                                            <asp:ListItem Selected="True">00</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>30</asp:ListItem>
                                            <asp:ListItem>45</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<asp:DropDownList ID="drpTime" runat="server" Width="50px" CssClass="drpdownCSS">
                                            <asp:ListItem Selected="True" Value="1">A.M.</asp:ListItem>
                                            <asp:ListItem Value="2">P.M.</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Location :</td>
                                    <td style="width: 85%">
                                        <asp:TextBox ID="txtLocation" runat="server" Width="60%" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Requested By :</td>
                                    <td style="width: 85%">
                                        <asp:DropDownList ID="ddRequestedBy" runat="server" Width="60%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddInspectedby_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Inspected By :</td>
                                    <td style="width: 85%">
                                        <asp:DropDownList ID="ddInspectedby" runat="server" Width="60%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddInspectedby_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Approved By :</td>
                                    <td style="width: 85%">
                                        <asp:DropDownList ID="ddApprovedBy" runat="server" Width="60%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddInspectedby_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Witness By :</td>
                                    <td style="width: 85%">
                                        <asp:DropDownList ID="ddWitnessBy" runat="server" Width="60%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddInspectedby_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 85%">
                                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtOpenDate" PopupButtonID="txtOpenDate" Enabled="True"></cc1:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnsave" runat="server" Width="150px" CssClass="CSButton" Text="SAVE" SkinID="ButtonImage" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnpreview" runat="server" Width="150px" CssClass="CSButton" Text="IIRUP" SkinID="ButtonImage" Enabled="False"></asp:Button>
                            &nbsp;<asp:Button ID="btnBidForm" OnClick="btnBidForm_Click" runat="server" Width="150px" CssClass="CSButton" Text="BID FORM" SkinID="ButtonImage" Enabled="False"></asp:Button>
                            &nbsp;<asp:Button ID="btnNotice" OnClick="btnNotice_Click" runat="server" Width="150px" CssClass="CSButton" Text="NOTICE OF PB" Enabled="False"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnnew" runat="server" Visible="False" Text="NEW" SkinID="ButtonImage"></asp:Button>
                            <asp:Button ID="btnopen" runat="server" Visible="False" Text="OPEN" SkinID="ButtonImage"></asp:Button>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnsave" ConfirmText="Are you sure you want to save this transaction?">
                            </cc1:ConfirmButtonExtender>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                          
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>



            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

