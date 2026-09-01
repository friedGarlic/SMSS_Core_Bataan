<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="t_purchase_request_Approval.aspx.vb"
    Inherits="t_purchase_request_Approval" StylesheetTheme="SkinFile" Title="Purchase Request Approval" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">


</script>



<asp:Content ID="Contetnt1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">PURCHASE REQUEST APPROVAL
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="left">
                            <asp:Panel ID="Panel1" runat="server" Width="100%">
                                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" AutoPostBack="True" OnActiveTabChanged="TabContainer1_ActiveTabChanged">
                                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            <span class="column_RightBold">Received</span>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <table style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Department :</span>
                                                            &nbsp;<asp:DropDownList ID="ddDepartment" runat="server" Width="350px" CssClass="drpdownCSS" AutoPostBack="True"></asp:DropDownList>
                                                            &nbsp;<asp:Button ID="btnRcvSearch" OnClick="btnRcvSearch_Click" runat="server" Width="150px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView ID="gvIncomingPR" runat="server" Width="100%" SkinID="GridViewAA" DataKeyNames="prhdr_id,rc_id,function_id,isVarious" AutoGenerateColumns="False"
                                                                AllowPaging="True" PageSize="15" EmptyDataText="No Data Found.">
                                                                <Columns>
                                                                    <asp:BoundField DataField="rc_name" HeaderText="Department">
                                                                        <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                   <%-- <asp:BoundField DataField="GA_Code" HeaderText="Account Code">
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                    </asp:BoundField>--%>

                                                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                                                        <HeaderStyle CssClass="GridHeaderAlignment"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:TemplateField HeaderText="PR Type">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPTType" runat="server" 
                                                                                       Text='<%# GetPRType(Eval("IsNonPPMP"), Eval("prhdr_id")) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:TemplateField>




                                                                    <asp:TemplateField HeaderText="Report">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkview" OnClick="lnkview_Click" runat="server" CssClass="LinkBtnPreview" OnClientClick="StartProgressBar();" Font-Underline="False" Visible='<%#Bind("isVisible") %>' CommandName="Select">View</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle CssClass="GridHeaderAlignment"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnApprove" OnClick="btnApprove_Click" runat="server" Width="80px" CssClass="LinkBtnSelect" Text="Approve" OnClientClick="StartProgressBar();" Visible='<%#Bind("isvisible") %>' CommandName="Select"></asp:Button>
                                                                            &nbsp;<asp:TextBox ID="txtApproveDate" runat="server" Width="70px" CssClass="txtbox_Date" Text='<%# Bind("Date_Submitted", "{0:MM/dd/yyyy}") %>' Visible='<%# bind("isvisible") %>'></asp:TextBox>
                                                                            &nbsp;<asp:ImageButton ID="btncal1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" OnClientClick="checkDate" Visible='<%#Bind("isvisible") %>'></asp:ImageButton>
                                                                            &nbsp;<asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Width="80px" CssClass="LinkBtnCancel" Text="Return" OnClientClick="StartProgressBar();" Visible='<%#Bind("isvisible") %>' CommandName="Select"></asp:Button>
                                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtApproveDate" PopupButtonID="btncal1">
                                                                            </cc1:CalendarExtender>
                                                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btnApprove" ConfirmText="Are you sure you want to approve  this transaction?">
                                                                            </cc1:ConfirmButtonExtender>
                                                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" TargetControlID="Button2" ConfirmText="Are you sure you want to return  this PR?">
                                                                            </cc1:ConfirmButtonExtender>
                                                                        </ItemTemplate>

                                                                        <ItemStyle HorizontalAlign="Center" Font-Size="8pt" Width="30%"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </ContentTemplate>
                                    </cc1:TabPanel>

                                    <cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
                                        <HeaderTemplate>
                                            <span class="column_RightBold">General Fund</span>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <table style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table style="width: 100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="vertical-align: top; width: 10%" class="column_RightBold">Search By : </td>
                                                                        <td style="vertical-align: top; width: 20%" class="column_Left">
                                                                            <asp:DropDownList ID="ddSearchGF" runat="server" Width="90%" OnSelectedIndexChanged="ddSearchGF_SelectedIndexChanged" CssClass="drpdownCSS" AutoPostBack="True">
                                                                                <asp:ListItem Selected="True" Value="1">PR Number</asp:ListItem>
                                                                                <asp:ListItem Value="2">Department</asp:ListItem>
                                                                                <asp:ListItem Value="3">Date Approved</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="width: 70%" class="column_Left">
                                                                            <asp:MultiView ID="MultiView1" runat="server">
                                                                                <asp:View ID="View1" runat="server">
                                                                                    <table style="width: 100%">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td style="width: 100%" align="left">
                                                                                                    <span class="column_RightBold">PR Number :</span>
                                                                                                    &nbsp;<asp:TextBox ID="txtPRNo" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                                                                    &nbsp;<asp:Button ID="btnSearchPRNumb" OnClick="btnSearchPRNumb_Click" runat="server" CssClass="CSButton" Width="120px" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </asp:View>
                                                                                <asp:View ID="View2" runat="server">
                                                                                    <table style="width: 100%">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td style="width: 100%" align="left">
                                                                                                    <span class="column_RightBold">Department :</span>
                                                                                                    &nbsp;<asp:DropDownList ID="ddDept" runat="server" Width="350px" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                                                                    &nbsp;<asp:Button ID="btnSearchDept" OnClick="btnSearchDept_Click" runat="server" CssClass="CSButton" Width="120px" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </asp:View>
                                                                                <asp:View ID="View3" runat="server">
                                                                                    <table style="width: 100%">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td style="width: 100%">
                                                                                                    <span class="column_RightBold">Date From :</span>
                                                                                                    &nbsp;<asp:TextBox ID="txtFrom" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                                                                                    &nbsp;<asp:ImageButton ID="image1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                                                                                                    &nbsp;<span class="column_RightBold">Date To :</span>
                                                                                                    &nbsp;<asp:TextBox ID="txtTo" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                                                                                    &nbsp;<asp:ImageButton ID="Image2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                                                                                                    &nbsp;<asp:Button ID="btnSearchDate" OnClick="btnSearchDate_Click" runat="server" Width="120px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </asp:View>
                                                                            </asp:MultiView>

                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView ID="gvApprovedPR" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="prhdr_id,isGasoline,pr_period_key_id,rc_id,function_id,isVarious"
                                                                SkinID="GridViewAA" Width="98%">
                                                                <Columns>
                                                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                                                        <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="rc_name" HeaderText="Department">
                                                                        <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                                                        <HeaderStyle CssClass="GridHeaderAlignment"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>


                                                                    <asp:TemplateField HeaderText="PR Type">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPTType" runat="server" 
                                                                                       Text='<%# GetPRType(Eval("IsNonPPMP"), Eval("prhdr_id")) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:TemplateField>



                                                                    <asp:TemplateField HeaderText="Date Approved">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("DateApproved_PR_Mayor", "{0:MM/dd/yyyy}") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
                                                                            &#160;                            
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Report">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkview2" runat="server" CommandName="Select" CssClass="LinkBtnPreview" Font-Underline="False" OnClick="lnkview2_Click" Visible='<%#Bind("isVisible") %>'>View</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="6%"></ItemStyle>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCancel" runat="server" CssClass="LinkBtnCancel" CommandName="Select" Font-Underline="False" OnClick="lnkCancel_Click" Visible='<%#Bind("isVisible") %>'>Cancel</asp:LinkButton>
                                                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtenderlnkCancel" runat="server" TargetControlID="lnkCancel" ConfirmText="Are you sure you want to cancel  this transaction?">
                                                                            </cc1:ConfirmButtonExtender>
                                                                         </ItemTemplate>
                                                                      
                                                                        <ItemStyle HorizontalAlign="Center" Width="6%"></ItemStyle>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReturnGF" runat="server" CssClass="LinkBtnCancel" CommandName="Select" Font-Underline="False" OnClick="lnkReturnGF_Click" OnClientClick="StartProgressBar();" Visible='<%#Bind("isVisible") %>'>Return</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="6%"></ItemStyle>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" PopupButtonID="image1" TargetControlID="txtFrom"></cc1:CalendarExtender>
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" PopupButtonID="image2" TargetControlID="txtTo"></cc1:CalendarExtender>

                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </ContentTemplate>
                                    </cc1:TabPanel>

                                    <cc1:TabPanel runat="server" HeaderText="TabPanel3" ID="TabPanel3">
                                        <HeaderTemplate>
                                            <span class="column_RightBold">Special Educational Fund</span>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <asp:GridView ID="grdApprovedSEF" runat="server" Width="98%" OnSelectedIndexChanged="grdApprovedSEF_SelectedIndexChanged" SkinID="GridViewAA" DataKeyNames="prhdr_id"
                                                AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grdApprovedSEF_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                                        <HeaderStyle CssClass="GridHeaderAlignment"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="rc_name" HeaderText="Department">
                                                        <HeaderStyle CssClass="GridHeaderAlignment"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Justify" Width="39%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                                        <HeaderStyle CssClass="GridHeaderAlignment"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                    </asp:BoundField>


                                                    <asp:TemplateField HeaderText="PR Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPTType" runat="server" 
                                                                       Text='<%# GetPRType(Eval("IsNonPPMP"), Eval("prhdr_id")) %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                    </asp:TemplateField>




                                                    <asp:TemplateField HeaderText="Date Approved">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("DateApproved_PR_Mayor", "{0:MM/dd/yyyy}") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="GridHeaderAlignment"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Report">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkViewSEF" runat="server" OnClientClick="StartProgressBar();" CssClass="LinkBtnPreview" Font-Underline="False" Visible='<%#Bind("isVisible") %>' OnClick="lnkViewSEF_Click" CommandName="Select">View</asp:LinkButton>&nbsp; 
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="GridHeaderAlignment"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkCancelSEF" OnClick="lnkCancelSEF_Click" CssClass="LinkBtnCancel" runat="server" OnClientClick="StartProgressBar();" Font-Underline="False" Visible='<%#Bind("isVisible") %>' CommandName="Select">Cancel</asp:LinkButton>
                                                      <cc1:ConfirmButtonExtender ID="ConfirmButtonExtenderlnkCancelSEF" runat="server" TargetControlID="lnkCancelSEF" ConfirmText="Are you sure you want to cancel  this transaction?">
                                                      </cc1:ConfirmButtonExtender>
                                                         </ItemTemplate>
                                                        <HeaderStyle CssClass="GridHeaderAlignment"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkReturn" runat="server" CssClass="LinkBtnCancel" OnClientClick="StartProgressBar();" Font-Underline="False" Visible='<%#Bind("isVisible") %>' OnClick="lnkReturn_Click" CommandName="Select">Return</asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </cc1:TabPanel>

                                    <cc1:TabPanel runat="server" HeaderText="TabPanel4" ID="TabPanel4">
                                        <HeaderTemplate>
                                            <span class="column_RightBold">Trust Fund</span>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <asp:GridView ID="grdApprovedTF" runat="server" Width="98%" OnSelectedIndexChanged="grdApprovedTF_SelectedIndexChanged"
                                                SkinID="GridViewAA" DataKeyNames="prhdr_id" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grdApprovedTF_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                                        <HeaderStyle CssClass="GridHeaderAlignment"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="rc_name" HeaderText="Department">
                                                        <HeaderStyle CssClass="GridHeaderAlignment"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left" Width="41%"></ItemStyle>
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                                        <HeaderStyle CssClass="GridHeaderAlignment"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                    </asp:BoundField>


                                                    <asp:TemplateField HeaderText="PR Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPTType" runat="server" 
                                                                       Text='<%# GetPRType(Eval("IsNonPPMP"), Eval("prhdr_id")) %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                    </asp:TemplateField>




                                                    <asp:TemplateField HeaderText="Date Approved">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("DateApproved_PR_Mayor", "{0:MM/dd/yyyy}") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="GridHeaderAlignment"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Report">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkViewTF" OnClick="lnkViewTF_Click" runat="server" CssClass="LinkBtnPreview" Font-Underline="False" Visible='<%#Bind("isVisible") %>' CommandName="Select">View</asp:LinkButton>&nbsp; 
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="GridHeaderAlignment"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkCancelTF" OnClick="lnkCancelTF_Click" runat="server" CssClass="LinkBtnCancel" Font-Underline="False" Visible='<%#Bind("isVisible") %>' CommandName="Select">Cancel</asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="GridHeaderAlignment"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkReturnTF" OnClick="lnkReturnTF_Click" runat="server" CssClass="LinkBtnCancel" Font-Underline="False" Visible='<%#Bind("isVisible") %>' Font-Strikeout="False" CommandName="Select">Return</asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                </cc1:TabContainer>
                            </asp:Panel>
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


            <asp:Panel ID="pnl_PrNumb" runat="server" Width="250px" CssClass="Panel_Popup">
                <div>
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">PR Number
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <%--<asp:Label ID="txtPRNumber" runat="server" Width="70%" CssClass="column_CenterBold"></asp:Label>--%>
                                <asp:TextBox runat="server" ID="txtPRNumber" Width="70%" CssClass="column_CenterBold"></asp:TextBox>
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
                                 <asp:Button ID="Button3" runat="server" Width="100px" Text="OK" CssClass="CSButton"></asp:Button>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                    </table>
                </div>
                <asp:Label ID="lblPopPR" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel Style="display: none; text-align: center" ID="pnl_pr_pop_up" runat="server" Width="500px"  CssClass="Panel_Popup" BorderWidth="2px" BorderStyle="Solid">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table style="width: 490px">
                            <tbody>
                                <tr>
                                    <%--<td style="font-weight: bold; font-size: 10pt; width: 100%; color: white; font-family: Verdana; background-color: #00FFFF" align="center">INPUT REMARKS
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="ok" ErrorMessage="*" ControlToValidate="txtremarks"></asp:RequiredFieldValidator></td>--%>
                                    <td style="width: 100%" align ="center" class="DivTitle">Reason for Cancellation</td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" align="center">
                                        <asp:TextBox Style="text-align: left" ID="txtremarks" runat="server" Width="100%" Height="115px" TextMode="MultiLine"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" align="center">
                                    <asp:Button ID="btnOK1" runat="server" Width="100px" Text="OK" ValidationGroup="ok" OnClick="btnOK1_Click" CssClass="CSButton" OnClientClick="StartProgressBar(); "></asp:Button>
                                        &nbsp;
                                  <%--  <asp:Button ID="btnCancel" runat="server" Width="100px" Text="CANCEL"></asp:Button>--%>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Label ID="pr_pop_up" runat="server"></asp:Label>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="pr_pop_up" PopupControlID="pnl_pr_pop_up"  BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnl_PrNumb" TargetControlID="lblPopPR"></cc1:ModalPopupExtender>


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


            <asp:Panel ID="Panel2" runat="server" Width="300px" CssClass="Panel_Popup">
                <table width="100%">
                    <tr>
                        <td style="width: 100%" class="DivTitle">Return
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px"></td>
                    </tr>
                    <tr>
                    <td style="width: 100%" align="center">
                        <asp:Label ID="lblReturnRemarks" runat="server" Text="Remarks:" CssClass="column_RightBold"></asp:Label>
                        <asp:TextBox ID="txtReturn_remarks" runat="server" Width="150px" CssClass="txtbox_Date" Placeholder="Enter reason for return"></asp:TextBox>
                    </td>

                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Button ID="btnReceiveDoc" runat="server" Width="100px" CssClass="CSButton" Text="Return" OnClientClick="StartProgressBar();" Height="22px" OnClick="btnReceiveDoc_Click"></asp:Button>
                            &nbsp;<asp:Button ID="btnCancelReceiveDoc" runat="server" Width="100px" CssClass="CSButton" Text="Cancel"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%"></td>
                    </tr>
                </table>

                <%--<cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDateReceive" PopupButtonID="ImageButton1">
                </cc1:CalendarExtender>--%>
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnReceiveDoc" ConfirmText="Are you sure you have this document?">
                </cc1:ConfirmButtonExtender>
                <asp:Button Style="background-color: transparent" ID="btn" runat="server" BorderStyle="None" Enabled="False"></asp:Button>

            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender123" runat="server" BackgroundCssClass="modalBackground" PopupControlID="Panel2" TargetControlID="btn" CancelControlID="btnCancelReceiveDoc">
            </cc1:ModalPopupExtender>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
