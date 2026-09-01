<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="t_annual_procurement_plan.aspx.vb" Inherits="PLANNING_t_annual_procurement_plan"
    Title="Annual Procurement Plan" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">ANNUAL PROCUREMENT PLAN
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView Style="font-weight: normal" ID="gvheader" runat="server" Width="60%" SkinID="GridViewAA" CssClass="text"
                                DataKeyNames="year,isPosted,isApproved,isforRevision,status,isContinuing,isSupplemental,app_id" PageSize="5" BorderStyle="Solid"
                                AutoGenerateColumns="False" Font-Size="8pt">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" Visible="False">
                                        <ItemStyle HorizontalAlign="Center" Font-Underline="False" ForeColor="Blue" Width="5%"></ItemStyle>
                                    </asp:CommandField>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSelect" runat="server" OnClientClick="StartProgressBar();" Font-Underline="False" CssClass="LinkBtnSelect" Text="Select" CommandName="Select" OnClick="lnkSelect_Click"></asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="title" HeaderText="Title">
                                        <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Status">
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btncreate" runat="server" CssClass="CSButton" Width="150px" Text="CREATE NEW" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnPreview" runat="server" CssClass="CSButton" Width="150px" Text="PREVIEW APP" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnSupplemental" OnClick="btnSupplemental_Click" runat="server" Width="200px" Font-Size="9pt" Height="25px" Text="CREATE SUPPLEMENTAL" Visible="False"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle"> Signatories
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 100%">
                                <tbody>
                                    <%-- ADD THIS <tr> 02/12/2025 --%>
                                    <tr>
                                        <td style="width: 15%; height: 10px" class="column_RightBold">No. of BAC Signatories:</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddSearchOption" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Width="200px">
                                                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">7 BAC Signatories</asp:ListItem>
                                                <asp:ListItem Value="2">5 BAC Signatories</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 15%" class="column_RightBold"></td>
                                        <td style="width: 35%" class="column_Left">&nbsp;</td>
                                    </tr>
                                    <%-- REVISED CODE 02/12/2025 --%>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">BAC Member 1 :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBAC1" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td style="width: 15%" class="column_RightBold">BAC Vice Chairman :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBACVC" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">BAC Member 2 :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBAC2" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td style="width: 15%" class="column_RightBold">BAC Chairman :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBACC" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">BAC Member 3 :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBAC3" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td style="width: 15%" class="column_RightBold">Prepared By :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddPreparedBy" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">BAC Member 4 :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBAC4" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td style="width: 15%" class="column_RightBold">Approved By :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddApprovedBy" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">BAC Member 5 :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBAC5" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td style="width: 15%" class="column_RightBold"></td>
                                        <td style="width: 35%" class="column_Left"></td>
                                    </tr>
                                    <%-- END HERE --%>
                                </tbody>
                            </table>
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
                        <td style="width: 98%" class="DivTitle">Annual Procurement Plan Report Per Department 
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Allotment Class :</td>
                                    <td style="width: 25%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpAPPReport" CssClass="drpdownCSS" Width="60%">
                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="MOOE"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="MOOE Supplies"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Capital Outlay (CO)"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="All"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Department :</td>
                                    <td style="width: 40%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpDepartment" CssClass="drpdownCSS" Width="90%" AutoPostBack="true">
                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Year :</td>
                                    <td style="width: 25%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpYear" CssClass="drpdownCSS" Width="60%">
                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Function :</td>
                                    <td style="width: 40%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpFunction" CssClass="drpdownCSS" Width="90%" AutoPostBack="true">
                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold"></td>
                                    <td style="width: 25%" class="column_Left"></td>
                                    <td style="width: 15%" class="column_RightBold">PPA :</td>
                                    <td style="width: 40%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpPPA" CssClass="drpdownCSS" Width="90%" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98% ; text-align:center"><asp:Button runat="server" ID="btnPreview_APPDepartment" CssClass="CSButton" Text="Preview" Width="150px" Enabled="false" OnClientClick="StartProgressBar();" /></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle"> Project Procurement Management Plan
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Panel Style="text-align: center" ID="Panel2" runat="server" Width="100%" Font-Bold="True" CssClass="text">
                                <cc1:TabContainer Style="text-align: left" ID="TabContainer1" runat="server" ActiveTabIndex="0">
                                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            <span class="column_RightBold">Office Operational Expense </span>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <asp:GridView Style="font-weight: normal" ID="gvppmp" runat="server" Width="100%" AutoGenerateColumns="False"
                                                BorderStyle="Solid" SkinID="GridViewAA" AllowPaging="True">
                                                <Columns>
                                                    <asp:BoundField DataField="rc_name" HeaderText="Department">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Function_Desc" HeaderText="Function">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="GA_CODE2" HeaderText="Account Code">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Amount" DataFormatString="{0:N}" HeaderText="Amount" HtmlEncode="False">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
                                                    </asp:BoundField>
                                                </Columns>

                                                <FooterStyle HorizontalAlign="Center" BackColor="#2977DC"></FooterStyle>

                                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PageButtonCount="5" PreviousPageText="Previous"></PagerSettings>

                                                <PagerStyle HorizontalAlign="Center"></PagerStyle>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                    <cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
                                        <HeaderTemplate>
                                            <span class="column_RightBold">Programs, Activity, and Projects </span>

                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <asp:GridView Style="font-weight: normal" ID="gvPPA" runat="server" Width="100%" CssClass="text" BorderStyle="Solid"
                                                AutoGenerateColumns="False" SkinID="GridViewAA" AllowPaging="True" Font-Size="8pt">
                                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
                                                <Columns>
                                                    <asp:BoundField DataField="rc_name" HeaderText="Department">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Function_Desc" HeaderText="Function">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PPA" HeaderText="PPA">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="GA_CODE2" HeaderText="Account Code">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Amount" DataFormatString="{0:N}" HeaderText="Amount">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                    </asp:BoundField>
                                                </Columns>

                                                <FooterStyle BackColor="#2977DC"></FooterStyle>

                                                <PagerStyle HorizontalAlign="Center"></PagerStyle>
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
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnPosted" runat="server" CssClass="CSButton" Width="150px" Text="POST" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnApproved" runat="server" CssClass="CSButton" Width="150px" Text="APPROVE" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnExe" runat="server" CssClass="CSButton" Width="150px" Text="EXECUTE" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnClose" runat="server" CssClass="CSButton" Width="150px" Text="CLOSE" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnRevise" runat="server" CssClass="CSButton" Width="150px" Text="REVISE" Visible="False" Enabled="False"></asp:Button>
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


            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnPosted" ConfirmText="Do you want to post this APP?">
            </cc1:ConfirmButtonExtender>
            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btnApproved" ConfirmText="Do you want to approve this APP?">
            </cc1:ConfirmButtonExtender>
            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" TargetControlID="btnRevise" ConfirmText="Do you want to revise this APP?">
            </cc1:ConfirmButtonExtender>
            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server" TargetControlID="btnExe" ConfirmText="Do you want to execute this APP?">
            </cc1:ConfirmButtonExtender>
            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" TargetControlID="btnClose" ConfirmText="Do you want to close this APP?">
            </cc1:ConfirmButtonExtender>
            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender6" runat="server" TargetControlID="btncreate" ConfirmText="Are you sure you want to create a APP?">
            </cc1:ConfirmButtonExtender>

            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button> 
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
