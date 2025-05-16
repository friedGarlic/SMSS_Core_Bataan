<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_disposal_donation.aspx.vb" Inherits="t_disposal_donation"
    Title="Donation" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">DISPOSAL - DONATION
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
                                        <asp:RadioButtonList ID="rbChoice" runat="server" Width="220px"  CssClass="rbCS_Horizontal" OnSelectedIndexChanged="rbChoice_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal">
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
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 1%"></td>
                                            <td style="width: 98%" class="DivTitle">Properties
                                            </td>
                                            <td style="width: 1%"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 1%"></td>
                                            <td style="width: 98%" align="center">
                                                <asp:GridView ID="gvNEW" runat="server" Width="80%" SkinID="GridViewAA" AllowPaging="True" AutoGenerateColumns="False" CaptionAlign="Left"
                                                    DataKeyNames="IIRUPHdr_ID,IIRUP_Date" PageSize="5" EmptyDataText="No Data Found.">
                                                    <Columns>
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                    Font-Underline="True" CssClass="LinkBtnSelect" Text="Select"></asp:LinkButton>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IIRUPHdr_ID" HeaderText="Transaction ID">
                                                            <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="IIRUP_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date" HtmlEncode="False">
                                                            <ItemStyle HorizontalAlign="Center" Width="40%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>

                                                    <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                                                </asp:GridView>
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
                                                <asp:GridView ID="gvbody" runat="server" Width="100%" OnSelectedIndexChanged="gvbody_SelectedIndexChanged" SkinID="GridViewAA" AutoGenerateColumns="False"
                                                    EmptyDataText="No Data Found.">
                                                    <Columns>
                                                        <asp:TemplateField Visible="False">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Font-Bold="True" CssClass="rbCS_Horizontal" OnCheckedChanged="CheckBox2_CheckedChanged" Text="All" Width="50px" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                            <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="propertyNo" HeaderText="Property Number">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Property_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Property Date" HtmlEncode="False">
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
                                            <td style="width: 1%"></td>
                                        </tr>
                                    </table>

                                </asp:View>
                                <asp:View ID="vwSupply" runat="server">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 1000px" class="DivTitle" align="center">SUPPLIES</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1000px" align="center">
                                                    <asp:GridView Style="font-weight: normal" ID="grdSupply" runat="server" Width="80%" OnSelectedIndexChanged="grdSupply_SelectedIndexChanged" SkinID="GridViewAA" EmptyDataText="No Data Found." PageSize="5" DataKeyNames="IIRUS_ID" CaptionAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Font-Size="9pt">
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
                                                <td style="width: 1000px" class="DivTitle" align="center">INFORMATION</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1000px" align="center">
                                                    <asp:GridView Style="font-weight: normal" ID="grdSuppDtl" runat="server" Width="100%" SkinID="GridViewAA" EmptyDataText="No Data Found." AutoGenerateColumns="False" Font-Size="9pt">
                                                        <Columns>
                                                            <asp:TemplateField Visible="False">
                                                                <EditItemTemplate>
                                                                    <asp:CheckBox ID="CheckBox1" runat="server" />

                                                                </EditItemTemplate>
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="cbAllSupp" runat="server" Width="50px" Font-Bold="True" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" Text="All" AutoPostBack="True" OnCheckedChanged="cbAllSupp_CheckedChanged"></asp:CheckBox>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="cbSupp" runat="server" AutoPostBack="True" OnCheckedChanged="cbSupp_CheckedChanged"></asp:CheckBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Item_Desc" HeaderText="Item Description">
                                                                <ItemStyle HorizontalAlign="Left" Width="65%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AppraisedVal" DataFormatString="{0:N}" HeaderText="Appriasal Value" HtmlEncode="False">
                                                                <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
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
                        <td style="width: 98%"><br />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>

                     <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">DONATION INFORMATION
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 90%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Date : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="txtdate" runat="server" Width="100px" SkinID="text" CssClass="txtbox_Date"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Transfer To : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="txtTo" runat="server" Width="50%"></asp:TextBox>
                                        &nbsp;<span style="font-size: 7pt; color: #ff0000">(Name of Bureau or Office)</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="save" ControlToValidate="txtTo" ErrorMessage="* required field"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr style="color: #000000">
                                    <td style="width: 20%" class="column_RightBold">Receiving Accountable Officer: </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="txtRAO" runat="server" Width="50%" CssClass="txtbox_Var"></asp:TextBox>
                                        &nbsp;<asp:Label Style="position: relative" ID="lblRAO" runat="server" ForeColor="Red" Font-Size="9pt" Text="* required field" Visible="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Authorized By : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="txtBy" runat="server" Width="50%" CssClass="txtbox_Var"></asp:TextBox>
                                        &nbsp;<asp:Label Style="position: relative" ID="lblBy" runat="server" ForeColor="Red" Font-Size="9pt" Text="* required field" Visible="False"></asp:Label></td>
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
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnsave" runat="server" Width="150px" CssClass="CSButton" SkinID="ButtonImage" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                            <asp:Button ID="btnpreview" runat="server" Width="200px" SkinID="ButtonImage" Text="PREVIEW" Visible="False"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <asp:Button ID="btnnew" runat="server" SkinID="ButtonImage" Text="NEW" Visible="False"></asp:Button>
                            <asp:Button ID="btnopen" runat="server" SkinID="ButtonImage" Text="OPEN" Visible="False"></asp:Button>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to save this transaction?" TargetControlID="btnsave">
                            </cc1:ConfirmButtonExtender>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>






            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; left: 0px; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; top: 0px; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button><br />
       
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

