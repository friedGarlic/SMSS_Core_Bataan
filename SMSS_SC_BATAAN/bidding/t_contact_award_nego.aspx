<%@ 
    Page Language="VB"
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" 
    CodeFile="t_contact_award_nego.aspx.vb" 
    Inherits="bidding_t_contact_award_nego"
    Title="CONTRACT AWARD"
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
                        <td style="width: 98%" class="PageTitle">CONTRACT AWARDS</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date :</span>&nbsp;
                            <asp:TextBox runat="server" ID="txtDate" CssClass="txtbox_Date" Width="10%" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table cellpadding="0px" cellspacing="0px" width="100%">
                                <tr>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab1" Width="100%" Text="Resolution of Award" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab2" Width="100%" Text="Notice of Award" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab3" Width="100%" Text="Notice To Proceed" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 40%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="4" class="PanelTabs">
                                        <asp:MultiView runat="server" ID="mvTabs">
                                            <asp:View runat="server" ID="vwROA">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search By :</span>&nbsp;
                                                            <asp:DropDownList ID="drpSearch_ROA" runat="server" Width="12%" CssClass="drpdownCSS">
                                                                <asp:ListItem Value="1" Text="PR Number" Selected="True"></asp:ListItem>
                                                            </asp:DropDownList>&nbsp;
                                                            <asp:TextBox ID="txtSearch_Resolution" runat="server" Width="20%" CssClass="txtbox_Var"></asp:TextBox>&nbsp;
                                                            <asp:Button ID="btnSearch_Resolution" runat="server" Width="15%" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView ID="grdResolution" runat="server" Width="98%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="10" SkinID="GridViewAA" DataKeyNames="Hdr_ID, prhdr_id">
                                                                <Columns>
                                                                    <asp:BoundField DataField="MOP" HeaderText="Mode of Procurement">
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ABC" HeaderText="ABC" DataFormatString="{0:N}">
                                                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Resolution No">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtResoNo" runat="server" Width="95%" Visible='<%# Bind("isVisible") %>' CssClass="txtbox_Date"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Resolution Date">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtResolutionDate" runat="server" Width="95%" CssClass="txtbox_Date" Visible='<%# Bind("isVisible") %>' Text='<%# Bind("Canvass_Date", "{0:d}") %>'></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtResolutionDate" Enabled="true" PopupButtonID="txtResolutionDate"></cc1:CalendarExtender>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Resolve Date">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtResolveDate" runat="server" Width="95%" CssClass="txtbox_Date" Visible='<%# Bind("isVisible") %>' Text='<%# Bind("Canvass_Date", "{0:d}") %>'></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtResolveDate" Enabled="true" PopupButtonID="txtResolveDate"></cc1:CalendarExtender>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Quotation Date">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtQuotationDate" runat="server" CssClass="txtbox_Date" Visible='<%#Bind("isVisible") %>' Width="95%" Text='<%# bind ("Canvass_Date", "{0:d}") %>'></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtenderQD" runat="server" TargetControlID="txtQuotationDate" Enabled="True" PopupButtonID="txtQuotationDate"></cc1:CalendarExtender>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkViewReso" runat="server" OnClientClick="StartProgressBar();" CssClass="LinkBtnSelect" Font-Underline="False" OnClick="lnkViewReso_Click" Visible='<%#Bind("isVisible") %>' CommandName="Select">View</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 20px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>

                                            <asp:View runat="server" ID="vwNOA1">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search : </span>&nbsp;
                                                            <asp:DropDownList ID="drpSearch_NOA" runat="server" Width="15%" CssClass="drpdownCSS">
                                                                <asp:ListItem Value="1" Text="PR Number" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Supplier Name"></asp:ListItem>
                                                            </asp:DropDownList>&nbsp;
                                                            <asp:TextBox ID="txtSearch_NOA" runat="server" Width="20%" CssClass="txtbox_Var"></asp:TextBox>&nbsp;
                                                            <asp:Button ID="btnSearch_NOA" runat="server" Width="15%" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView ID="grdAbstract" runat="server" Width="100%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="10" SkinID="GridViewAA" DataKeyNames="Hdr_ID, Supplier_ID, PR_No, Total_Amt, prhdr_id">
                                                                <Columns>
                                                                    <asp:BoundField DataField="MOP" HeaderText="Mode of Procurement">
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="SuppName" HeaderText="Supplier Name">
                                                                        <ItemStyle HorizontalAlign="Left" Width="40%" />
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="Total_Amt" DataFormatString="{0:N}" HeaderText="Supplier ABC">
                                                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                    </asp:BoundField>

                                                                    <asp:TemplateField HeaderText="NOA Date">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtNOADate" runat="server" Width="95%" Text='<%# Bind("Canvass_Date", "{0:d}") %>' Visible='<%# Bind("isVisible") %>' CssClass="txtbox_Date"></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtNOADate" Enabled="true" PopupButtonID="txtNOADate"></cc1:CalendarExtender>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkView" runat="server" CommandName="Select" CssClass="LinkBtnSelect" Font-Underline="false" OnClick="lnkView_Click" OnClientClick="StartProgressBar();" Visible='<%# Bind("isVisible") %>'>View</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 20px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>

                                            <asp:View runat="server" ID="vwNTP">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search : </span>&nbsp;
                                                            <asp:DropDownList ID="drpSearchNTP" runat="server" Width="15%" CssClass="drpdownCSS">
                                                                <asp:ListItem Value="1" Text="PR Number" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Supplier Name"></asp:ListItem>
                                                            </asp:DropDownList>&nbsp;
                                                            <asp:TextBox ID="txtSearchNTP" runat="server" Width="20%" CssClass="txtbox_Var"></asp:TextBox>&nbsp;
                                                            <asp:Button ID="btnSearchNTP" runat="server" Width="15%" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();"></asp:Button>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdNTP" Width="90%" SkinID="GridViewAA" AllowPaging="true" PageSize="10" EmptyDataText="No Data Found." DataKeyNames="CanvassAward_ID, ProjectName, Supp_ABC, PO_No, SuppName">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkNTP_Select" CssClass="LinkBtnSelect" Text="Select" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <%--<asp:BoundField ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" DataField="rfq_no" HeaderText="Ref. Number" />--%>
                                                                    
                                                                    <asp:BoundField ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" DataField="PO_No" HeaderText="PO Number" />
                                                                    
                                                                    <asp:BoundField ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Left" DataField="SuppName" HeaderText="Supplier" />
                                                                    
                                                                    <asp:BoundField ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Right" DataField="Supp_ABC" HeaderText="Amount" DataFormatString="{0:N}" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Date :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtNTP_Date" CssClass="txtbox_Date" Width="30%" Text="" MaxLength="10"></asp:TextBox>&nbsp;
                                                                        <span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtNTP_Date" PopupButtonID="txtNTP_Date" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtNTP_Date" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Approved By :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpNTP_ApprovedBy" CssClass="drpdownCSS" Width="90%"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <div class="ReportBorderCSS" style="width: 90%">
                                                                <table width="90%">
                                                                    <tr>
                                                                        <td style="width: 100%; height: 10px"></td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <span class="ReportEncoding_Title">NOTICE TO PROCEED</span>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td style="width: 100%; height: 20px"></td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td style="width: 100%" class="column_Center">
                                                                            <asp:TextBox runat="server" ID="txtNTP_Content" Text="" CssClass="txtbox_ReportEncoding" Width="95%" Height="150px" TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td style="width: 100%; height: 20px"></td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td style="width: 100%" class="column_Center">
                                                                            <asp:Button runat="server" ID="btnNTP_Save" CssClass="CSButton" Width="15%" Text="Save & Preview" Enabled="false" OnClientClick="StartProgressBar();" />
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td style="width: 100%; height: 20px"></td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 20px"></td>
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

            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033CC; border-bottom-width: 1px; border-bottom-color: #0033CC; border-top-color: #0033CC; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033CC" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>

            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress"></cc1:ModalPopupExtender>

            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="false" />&nbsp;

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


