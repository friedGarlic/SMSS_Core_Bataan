<%@ Page Title="BAC RESOLUTION" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RQ_BAC_Resolution.aspx.vb"
    Inherits="Reports_and_Query_RQ_BAC_Resolution" EnableEventValidation="false" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">BAC RESOLUTION REPORTS
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
                        <td style="width: 98%" align="left" valign="bottom">
                            <table cellpadding="0px" cellspacing="0px" width="100%">
                                <tr>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab1" Width="100%" Text="PUBLIC BIDDING" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab2" Width="100%" Text="AGENCY TO AGENCY" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
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
                                                            <span class="column_RightBold">Search By :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpSearch" Width="150px">
                                                                <asp:ListItem Value="1" Text="BAC Resolution"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="PR Number"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtSearch" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnSearch" CssClass="CSButton" Width="150px" Text="SEARCH" />
                                                        </td>
                                                    </tr>                                                 
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView ID="grdBACReso" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="pre_procurement_hdr_id,ResponsiveCount" PageSize="20"
                                                                SkinID="GridViewAA" Width="98%" EmptyDataText="No Data Found.">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" Text="Preview" Font-Underline="false" CssClass="LinkBtnPreview" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="resolution_number" HeaderText="BAC Resolution No.">
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="project_reference_no" HeaderText="Ref Number">
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="project_name" HeaderText="Project">
                                                                        <ItemStyle HorizontalAlign="Left" Width="45%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <FooterStyle BackColor="#2977DC" />
                                                                <HeaderStyle BackColor="#2977DC" ForeColor="White" />
                                                            </asp:GridView>
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
                                                            <span class="column_RightBold">Search By :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpAgencySearch" Width="150px" CssClass="drpdownCSS">
                                                                <asp:ListItem Selected="True" Value="1" Text="PR Number"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="BAC Resolution No."></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtAgencySearch" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnAgencySearch" Width="120px" CssClass="CSButton" Text="SEARCH" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView ID="grdAgency" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="prhdr_id" PageSize="20"
                                                                SkinID="GridViewAA" Width="98%" EmptyDataText="No Data Found." OnSelectedIndexChanged="grdAgency_SelectedIndexChanged"
                                                                OnPageIndexChanging="grdAgency_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" Text="Preview" Font-Underline="false" CssClass="LinkBtnPreview" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="DateApproved" HeaderText="Date" DataFormatString="{0:d}">
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="BACResolution_No" HeaderText="BAC Resolution No.">
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Remarks" HeaderText="Purpose">
                                                                        <ItemStyle HorizontalAlign="Left" Width="55%" />
                                                                    </asp:BoundField>

                                                                </Columns>
                                                                <FooterStyle BackColor="#2977DC" />
                                                                <HeaderStyle BackColor="#2977DC" ForeColor="White" />
                                                            </asp:GridView>
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

