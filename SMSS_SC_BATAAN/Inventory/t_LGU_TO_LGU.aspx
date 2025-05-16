<%@ Page Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="t_LGU_TO_LGU.aspx.vb"
    Inherits="t_LGU_TO_LGU" 
    Title="LGU TO LGU" 
    EnableEventValidation="false" 
    StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">DONATION L.G.U TO L.G.U
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr style="display:none">
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="left">
                            <asp:Button ID="btnRIS" OnClick="btnRIS_Click" runat="server" Width="250px" CssClass="Initial" Text="Supply Requisition and Issuance"></asp:Button>
                            <asp:Button ID="btnARE" OnClick="btnARE_Click" runat="server" Width="250px" CssClass="Initial" Text="Property Acknowledgement Receipt"></asp:Button>
                            <asp:Button ID="btnPerPO" runat="server" Width="250px" CssClass="Initial" Text="Issuance Per Purchase Order (PARE) "></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr style="display:none">
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search PO Number :</span>
                            &nbsp;<asp:TextBox ID="txtSearch" runat="server" Width="200px"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearch" runat="server" Width="120px" CssClass="CSButton" Text="Search"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdPOList" runat="server" Width="95%" DataKeyNames="POHdr_ID,Received_ID" OnSelectedIndexChanged="grdPOList_SelectedIndexChanged" HorizontalAlign="Center"
                                AllowPaging="True" SkinID="GridViewAA" OnPageIndexChanging="grdPOList_PageIndexChanging" OnRowDataBound="grdPOList_RowDataBound" EmptyDataText="No Data Found.">
                                <Columns>
                                    <asp:BoundField DataField="PO_No" HeaderText="PO Number">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContractPrice" DataFormatString="{0:N}" HeaderText="Amount">
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SuppName" HeaderText="Supplier">
                                        <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RC_Name" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List Of Items
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdPO_Items" runat="server" Width="95%" HorizontalAlign="Center" AllowPaging="True" SkinID="GridViewAA"
                                OnPageIndexChanging="grdPO_Items_PageIndexChanging" EmptyDataText="No Data Found.">
                                <Columns>
                                    <asp:BoundField DataField="Item_Desc" HeaderText="Description" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Cost">
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Details
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 970px; height: 100%" class="Text">
                                <tbody>
                                    <tr>
                                        <td style="height: 13px" align="center" colspan="3">
                                            <img alt="" src="../images/Edited%20Image/ReceivedButton.jpg" /></td>
                                        <td style="height: 13px" align="center" colspan="3">
                                            <img alt="" src="../images/Edited%20Image/ReceivedByButton.jpg" /></td>
                                    </tr>
                                    <tr style="display:none">
                                        <td style="width: 166px" class="column_RightBold">PARE Number :</td>
                                        <td class="column_Left" colspan="2">
                                            <asp:TextBox ID="txtMRE" runat="server" Width="180px" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                            <asp:CheckBox ID="CheckBox3" runat="server" Font-Bold="True" CssClass="rbCS_Vertical" Text="Old Property" Enabled="False" OnCheckedChanged="CheckBox3_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                        </td>
                                        <td style="width: 247px" class="column_RightBold"></td>
                                        <td style="height: 24px" class="column_Left" colspan="2"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 166px" class="column_RightBold">Department :</td>
                                        <td class="column_Left" colspan="2">
                                            <asp:DropDownList ID="ddFromDepartment" runat="server" Width="300px" CssClass="drpdownCSS" AppendDataBoundItems="True">
                                                <asp:ListItem>Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 247px" class="column_RightBold">Department :</td>
                                        <td class="column_Left" colspan="2">
                                            <asp:DropDownList ID="ddByDepartment" runat="server" Width="300px" CssClass="drpdownCSS" OnSelectedIndexChanged="ddByDepartment_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True" Visible="false">
                                                <asp:ListItem>Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:TextBox ID="TextBox1DepReceive" runat="server" CssClass="txtbox_Var" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 166px" class="column_RightBold">Issued<span style="font-size: 8pt"> By :</span></td>
                                        <td class="column_Left" colspan="2">
                                            <asp:DropDownList ID="ddFromProperty" runat="server" Width="300px" CssClass="drpdownCSS" AppendDataBoundItems="True">
                                                <asp:ListItem>Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 247px" class="column_RightBold"><span style="font-size: 8pt">Issued&nbsp;To :</span></td>
                                        <td class="column_Left" colspan="2">
                                            <asp:DropDownList ID="ddByAcknowledgement" runat="server" Width="300px" CssClass="drpdownCSS" AppendDataBoundItems="True" Visible="false">
                                                <asp:ListItem>Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtIssueReceive" runat="server" CssClass="txtbox_Var" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 166px" class="column_RightBold">Date :</td>
                                        <td style="width: 106px" class="column_Left">
                                            <asp:TextBox ID="txtDateReceivedFrom" runat="server" Width="100px" CssClass="txtbox_Date" AutoPostBack="True" OnTextChanged="txtDateReceivedFrom_TextChanged"></asp:TextBox>
                                        </td>
                                        <td style="width: 184px" class="column_Left">
                                            <asp:Image ID="Image1" runat="server" Width="20px" ImageUrl="~/images/calendar1.jpg" Height="15px"></asp:Image>
                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        </td>
                                        <td style="width: 247px" class="column_RightBold">Date :</td>
                                        <td style="width: 116px" class="column_Left">
                                            <asp:TextBox ID="txtDateReceivedBy" runat="server" Width="100px" CssClass="txtbox_Date" OnTextChanged="txtDateReceivedBy_TextChanged"></asp:TextBox>
                                        </td>
                                        <td style="width: 366px" class="column_Left">
                                            <asp:Image ID="Image2" runat="server" Width="20px" ImageUrl="~/images/calendar1.jpg" Height="15px"></asp:Image>
                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 166px" class="column_RightBold"></td>
                                        <td class="column_Left" colspan="2">
                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtDateReceivedFrom" PopupButtonID="txtDateReceivedFrom"></cc1:CalendarExtender>
                                        </td>
                                        <td style="width: 247px" class="column_RightBold"></td>
                                        <td class="column_Left" colspan="2">
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtDateReceivedBy" PopupButtonID="Image2"></cc1:CalendarExtender>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnsavedoc" OnClick="btnsavedoc_Click" runat="server" Width="150px" CssClass="CSButton" Text="SAVE" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btncancelDoc" OnClick="btncancelDoc_Click" runat="server" Width="150px" CssClass="CSButton" Text="CANCEL" Enabled="False"></asp:Button>
                            &nbsp;<asp:Button ID="btnpreviewAreDoc" OnClick="btnpreviewAreDoc_Click" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW" Enabled="False"></asp:Button>
                            &nbsp;<asp:Button ID="btnPreviewRIS" OnClick="btnPreviewRIS_Click" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW RIS" Enabled="False" Visible="false"></asp:Button>
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





            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


            <asp:Panel ID="Panel4" runat="server" Width="400px" Font-Bold="True" Height="150px" BackImageUrl="~/images/modalpopup_04.png">
                <table>
                    <tbody>
                        <tr>
                            <td style="background-color: #ff6600" class="column_RightBold" colspan="4">
                                <asp:Button ID="Cancel2" runat="server" Width="30px" ForeColor="White" CssClass="Close" Text="X" BorderColor="#FFC080" BorderStyle="None" BackColor="#FFC080"></asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="column_RightBold">Approve By</td>
                            <td style="width: 10px" class="column_LeftBold">:</td>
                            <td class="column_Left" colspan="2">
                                <asp:DropDownList ID="ddPrevMayor" runat="server" Width="225px" OnSelectedIndexChanged="ddPrevMayor_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="column_RightBold"></td>
                            <td style="width: 10px" class="column_LeftBold"></td>
                            <td style="width: 240px" class="column_Left"></td>
                            <td style="width: 40px"></td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top" class="column_RightBold"></td>
                            <td style="vertical-align: top; width: 10px" class="column_LeftBold"></td>
                            <td style="width: 240px" class="column_Left">
                                <asp:Button ID="btnOK" runat="server" Width="150px" Text="OK" OnClientClick="StartProgressBar();"></asp:Button>
                            </td>
                            <td style="width: 40px"></td>
                        </tr>
                    </tbody>
                </table>
                <asp:Label ID="Label2" runat="server" Width="86px" Text=" "></asp:Label>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" Enabled="True" TargetControlID="Label2" PopupControlID="Panel4" CancelControlID="btnClose"></cc1:ModalPopupExtender>
        </ContentTemplate>
    
    
    </asp:UpdatePanel>
</asp:Content>

