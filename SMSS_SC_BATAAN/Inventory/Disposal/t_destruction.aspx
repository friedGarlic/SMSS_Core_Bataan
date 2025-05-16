<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="t_destruction.aspx.vb" Inherits="Inventory_Disposal_t_destruction"
    Title="Disposal Destruction" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">DISPOSAL DESTRUCTION

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
                                        <asp:RadioButtonList ID="rbChoice" runat="server" Width="220px" CssClass="rbCS_Horizontal" OnSelectedIndexChanged="rbChoice_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Properties</asp:ListItem>
                                            <asp:ListItem Value="2">Supplies</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:MultiView ID="mvCategory" runat="server">
                                <asp:View ID="vwProperty" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 100%" class="DivTitle">Transactions</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:GridView ID="gvNEW" runat="server" Width="80%" OnSelectedIndexChanged="gvNEW_SelectedIndexChanged" SkinID="GridViewAA" PageSize="5" DataKeyNames="IIRUPHdr_ID,IIRUP_Date" CaptionAlign="Left" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Data Found.">
                                                    <EmptyDataRowStyle ForeColor="Black"></EmptyDataRowStyle>
                                                    <Columns>
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Font-Underline="True" CssClass="LinkBtnSelect" Text="Select"></asp:LinkButton>

                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IIRUPHdr_ID" HeaderText="TransactionID">
                                                            <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="IIRUP_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date" HtmlEncode="False">
                                                            <ItemStyle HorizontalAlign="Center" Width="40%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>

                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" class="DivTitle">List of Properties</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:GridView ID="gvbody" runat="server" Width="100%" SkinID="GridViewAA" AutoGenerateColumns="False" EmptyDataText="No Data Found.">
                                                    <EmptyDataRowStyle ForeColor="Black"></EmptyDataRowStyle>
                                                    <Columns>
                                                        <asp:TemplateField Visible="False">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="CheckBox2" runat="server" Width="50px" Font-Bold="True" ForeColor="White" CssClass="rbCS_Horizontal" Text="All" OnCheckedChanged="CheckBox2_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                            <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="propertyNo" HeaderText="Property Number">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Property_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date of Purchased" HtmlEncode="False">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="qty" HeaderText="Quantity">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="val" DataFormatString="{0:N}" HeaderText="Unit Value" HtmlEncode="False">
                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </asp:View>

                                <asp:View ID="vwSupply" runat="server">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle" align="center">TRANSACTIONS</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView Style="font-weight: normal" ID="grdSupply" runat="server" Width="80%" Font-Size="9pt" OnSelectedIndexChanged="grdSupply_SelectedIndexChanged" SkinID="GridViewAA" PageSize="5" DataKeyNames="IIRUS_ID" CaptionAlign="Left" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Data Found.">
                                                        <EmptyDataRowStyle ForeColor="Black"></EmptyDataRowStyle>
                                                        <Columns>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                        Font-Underline="True" ForeColor="Black" Text="Select"></asp:LinkButton>

                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="IIRUS_ID" HeaderText="TransactionID">
                                                                <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="IIRUS_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date" HtmlEncode="False">
                                                                <ItemStyle HorizontalAlign="Center" Width="40%"></ItemStyle>
                                                            </asp:BoundField>
                                                        </Columns>

                                                        <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle" align="center">LIST OF SUPPLIES</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView Style="font-weight: normal" ID="grdSupplyItems" runat="server" Width="100%" Font-Size="9pt" SkinID="GridViewAA" AutoGenerateColumns="False" EmptyDataText="No Data Found.">
                                                        <EmptyDataRowStyle ForeColor="Black"></EmptyDataRowStyle>
                                                        <Columns>
                                                            <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                                <ItemStyle HorizontalAlign="Left" Width="55%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="qty" HeaderText="Quantity">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AppraisedVal" DataFormatString="{0:N}" HeaderText="Cost" HtmlEncode="False">
                                                                <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                            </asp:BoundField>
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
                        <td style="width: 98%">
                            <br />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">DESTRUCTION INFORMATION
                        </td>
                        <td style="width: 1%">

                        </td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 80%">
                                <tr>
                                    <td style="width: 18%" class="column_RightBold">Date : </td>
                                    <td style="width: 82%" class="column_Left">
                                        <asp:TextBox ID="txtdate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                        &nbsp;<asp:ImageButton ID="img" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 18%" class="column_RightBold">Accountable Officer : </td>
                                    <td style="width: 82%" class="column_Left">
                                        <asp:TextBox ID="txtAccountOfficer" runat="server" Width="350px" CssClass="txtbox_Var"></asp:TextBox>
                                        &nbsp;<asp:Label ID="req" runat="server" Font-Bold="True" ForeColor="#FF3366" Font-Size="Medium" Visible="False" Text="*"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 18%" class="column_RightBold">Authorized By : </td>
                                    <td style="width: 82%" class="column_Left">
                                        <asp:TextBox ID="txtAuthorizedBy" runat="server" Width="350px" CssClass="txtbox_Var"></asp:TextBox>
                                        &nbsp;<asp:Label ID="req2" runat="server" Font-Bold="True" ForeColor="#FF3366" Font-Size="Medium" Visible="False" Text="*"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 18%" class="column_RightBold">Remarks : </td>
                                    <td style="width: 82%" class="column_Left">
                                        <asp:TextBox ID="txtRemarks" runat="server" Width="350px" CssClass="txtbox_Remarks"></asp:TextBox></td>
                                </tr>
                            </table>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdate" PopupButtonID="img"></cc1:CalendarExtender>

                        </td>
                        <td style="width: 1%"></td>
                    </tr>
              <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <asp:Button ID="btnSAVE" OnClick="btnSAVE_Click" runat="server" Width="150px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                            <asp:Button ID="btnPREVIEW" runat="server" Width="150px" CssClass="CSButton" Visible="False" Text="PREVIEW" OnClientClick="StartProgressBar();"></asp:Button>
                            <asp:Button ID="btnSaveSupp" OnClick="btnSaveSupp_Click" runat="server" CssClass="CSButton"  Width="150px" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button><asp:Button ID="btnPreviewSupp" runat="server" Width="200px" Visible="False" Text="PREVIEW" OnClientClick="StartProgressBar();"></asp:Button></td>
                                           
                        </td>
                        <td style="width: 1%">

                        </td>
                    </tr>
                
                </table>
            </div>





            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img src="../../images/ajax-loader.gif" alt="loader" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

