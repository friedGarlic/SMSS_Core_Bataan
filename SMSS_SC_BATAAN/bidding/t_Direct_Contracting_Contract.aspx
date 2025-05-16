<%@ Page
    Language="VB" 
    Title="Contarct"
    AutoEventWireup="false"
    MasterPageFile="~/MasterPage.master" 
    CodeFile="t_Direct_Contracting_Contract.aspx.vb" 
    Inherits="bidding_t_Direct_Contracting_Contract"
    StylesheetTheme="SkinFile"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <script type="text/javascript">
      function SetMessage() {
            var traps;
            if (window.confirm("Do you want to return this transaction?")) 
            { 
               traps = "Yes";
            }
            else
            {
               traps = "No";
            }

            document.getElementById("ctl00_ContentPlaceHolder1_txtTraps").value = traps;
        }

            function SetMessage1() {
            var traps1;
            if (window.confirm("Do you want to Approve this transaction?")) 
            { 
               traps1 = "Yes";
            }
            else
            {
               traps1 = "No";
            }

            document.getElementById("ctl00_ContentPlaceHolder1_txtTraps1").value = traps1;
        }

        </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">ABSTRACT OF CANVASS - APPROVAL
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date :</span>
                            &nbsp;<asp:TextBox ID="txtDate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                         <asp:HiddenField ID="txtTraps" runat="server" />
                        <asp:HiddenField ID="txtTraps1" runat="server" />
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search By :</span>
                            &nbsp;<asp:DropDownList ID="ddSearchAbstract" runat="server" AutoPostBack="True" Width="120px" CssClass="drpdownCSS" OnSelectedIndexChanged="ddSearchAbstract_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="1">PR Number</asp:ListItem>
                                <asp:ListItem Value="2">Department</asp:ListItem>
                                <asp:ListItem Value="3">OBR Number</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:Label runat="server" ID="lblSearch" Text="PR Number :" CssClass="column_RightBold"></asp:Label>
                            &nbsp;<asp:TextBox ID="txtSearch" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox>
                            <asp:DropDownList ID="drpDepartment" runat="server" CssClass="drpdownCSS" Width="200px" Visible="false"></asp:DropDownList>

                            &nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" OnClientClick="StartProgressBar();" Text="SEARCH" Width="150px" CssClass="CSButton" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdAbstractCanvass" runat="server" Width="98%" OnPageIndexChanging="grdAbstractCanvass_PageIndexChanging"
                                AllowPaging="True" SkinID="GridViewAA" AutoGenerateColumns="False" PageSize="8" DataKeyNames="Supplier_ID,Hdr_ID,prhdr_id,Canvass_Date"
                                OnSelectedIndexChanged="grdAbstractCanvass_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSelect" OnClick="lnkSelect_Click" runat="server" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%#Bind("isVisible") %>' Font-Underline="False">Select</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OBR_No" HeaderText="CAA Number">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RC_Name" HeaderText="Requesting Department">
                                        <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SuppName" HeaderText="Supplier">
                                        <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
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
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Panel ID="Panel1" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical">
                                <asp:GridView ID="grdItemList" runat="server" Width="100%" SkinID="GridViewAA" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="Item_Desc" HeaderText="Item Description">
                                            <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Unit" HeaderText="Unit">
                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ApprovedBudget" DataFormatString="{0:N}" HeaderText="Approved Budget">
                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CanvassPrice" DataFormatString="{0:N}" HeaderText="Canvass Price">
                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Total" DataFormatString="{0:N}" HeaderText="Total Amount">
                                            <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#2977DC"></FooterStyle>
                                    <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                        <td style="width: 1%"></td>


                    </tr>
                            <tr align="center">
                            <td style="width: 1%"></td>
                            <td style="width: 98%" >
                                <table >
                                    <tr align="center">
                                        <td class="column_RightBold">Approved By : </td>
                                        <td class="column_Left">
                                            <asp:DropDownList ID="ddApprovedBy" runat="server" Width="250px" CssClass="drpdownCSS"  AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        <td style="width: 1%"></td>


                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnApproved" OnClick="btnApproved_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();return SetMessage1(this.value);" Enabled="False" Text="APPROVE"></asp:Button>
                            &nbsp;<asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();return SetMessage(this.value);" Enabled="False" Text="RETURN"></asp:Button>
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button> 
        
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
