<%@ Page Title="REPORTS FOR CANVASS AWARDS" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RQ_CanvassAwards.aspx.vb"
    Inherits="Reports_and_Query_RQ_CanvassAwards" EnableEventValidation="false" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">CANVASS AWARD REPORTS
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
                        <td style="width: 98%">

                            <table cellpadding="0px" cellspacing="0px" width="100%">
                                <tr>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab1" Width="100%" Text="RESOLUTION OF AWARD" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab2" Width="100%" Text="NOTICE OF AWARD" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 60%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="3" class="PanelMessage">
                                        <asp:MultiView runat="server" ID="mvTabs">
                                            <asp:View runat="server" ID="vwTab1">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table style="width: 100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <span class="column_RightBold">Search :</span>
                                                                            &nbsp;<asp:DropDownList ID="ddSearchResolution" runat="server" Width="150px" CssClass="drpdownCSS">
                                                                                <asp:ListItem Selected="True" Value="1">PR Number</asp:ListItem>
                                                                                <asp:ListItem Value="2">Supplier Name</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            &nbsp;<asp:TextBox ID="txtSearchResolution" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                                            &nbsp;<asp:Button ID="btnSearchResolution" OnClick="btnSearchResolution_Click" runat="server" Width="150px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:GridView ID="grdResolution" runat="server" Width="90%" EmptyDataText="No Data Found." SkinID="GridViewAA" PageSize="20"
                                                                                OnSelectedIndexChanged="grdResolution_SelectedIndexChanged" DataKeyNames="Hdr_ID,prhdr_id" AllowPaging="true" OnPageIndexChanging="grdResolution_PageIndexChanging">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkViewReso" runat="server" CssClass="LinkBtnPreview" OnClientClick="StartProgressBar();" Font-Underline="False" OnClick="lnkViewReso_Click" Visible='<%#Bind("isVisible") %>' CommandName="Select" Text="Preview"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                    </asp:TemplateField>

                                                                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                                    </asp:BoundField>

                                                                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                                                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                                                    </asp:BoundField>

                                                                                    <asp:TemplateField HeaderText="Resolution No">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtResoNo" runat="server" Width="98%" Visible='<%# Bind("isVisible") %>' CssClass="txtbox_Date" ReadOnly="True" Text='<%# bind("Resolution_No") %>'></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField HeaderText="Resolution Date">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtResolutionDate" runat="server" Width="98%" CssClass="txtbox_Date" Visible='<%# Bind("isVisible") %>' Text='<%# bind ("Reso_Date", "{0:MM/dd/yyyy}") %>' ReadOnly="True"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField HeaderText="Resolve Date">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtResolveDate" runat="server" Width="98%" CssClass="txtbox_Date" Visible='<%# Bind("isVisible") %>' Text='<%# bind ("Resolved_Date", "{0:MM/dd/yyyy}") %>' ReadOnly="True"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField HeaderText="Quotation Date">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtQuotationDate" runat="server" CssClass="txtbox_Date" Visible='<%# Bind("isVisible") %>' Width="98%" Text='<%# bind ("QuotationDate_Rcv", "{0:MM/dd/yyyy}") %>' ReadOnly="True"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                                    </asp:TemplateField>


                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>

                                            <asp:View runat="server" ID="vwTab2">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table style="width: 100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <span class="column_RightBold">Search :</span>
                                                                            &nbsp;<asp:DropDownList ID="ddSearchNOA" runat="server" Width="150px" CssClass="drpdownCSS">
                                                                                <asp:ListItem Selected="True" Value="1">PR Number</asp:ListItem>
                                                                                <asp:ListItem Value="2">Supplier Name</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            &nbsp;<asp:TextBox ID="txtSearchNOA" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                                            &nbsp;<asp:Button ID="btnSearchNOA" OnClick="btnSearchNOA_Click" runat="server" Width="150px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:GridView ID="grdAbstract" runat="server" Width="90%" EmptyDataText="No Data Found." SkinID="GridViewAA" OnSelectedIndexChanged="grdAbstract_SelectedIndexChanged"
                                                                                DataKeyNames="Hdr_ID,Supplier_ID,PR_No,Total_Amt,prhdr_id" AllowPaging="true" PageSize="20">
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkView" runat="server" CommandName="Select" Font-Underline="False" CssClass="LinkBtnPreview" OnClick="lnkView_Click" OnClientClick="StartProgressBar();" Visible='<%#Bind("isVisible") %>' Text="Preview"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                    </asp:TemplateField>

                                                                                    <asp:BoundField DataField="SuppName" HeaderText="Supplier Name">
                                                                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Total_Amt" DataFormatString="{0:N}" HeaderText="Supplier ABC">
                                                                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="Quotation Date">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtNOADate" runat="server" Width="98%" Text='<%# Bind("NOA_Date", "{0:MM/dd/yyyy}") %>' Visible='<%# bind ("isVisible") %>' CssClass="txtbox_Date" ReadOnly="True"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                                    </asp:TemplateField>

                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%"></td>
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
                </table>
            </div>



            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
