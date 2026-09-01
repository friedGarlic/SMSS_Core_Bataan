<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="t_inventory_Donation.aspx.vb"
    Inherits="t_inventory_Donation" Title="Donation" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">DONATIONS TO THE L.G.U.
                        </td>
                        <td style="width: 1%"></td>
                    </tr>



                         <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 90%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">General Account: </td>
                                    <td style="width: 40%" class="column_Left">
                                         <asp:DropDownList ID="ddGA" runat="server" Width="95%" AutoPostBack="true" CssClass="drpdownCSS"></asp:DropDownList></td>
                                    <td style="width: 40%" class="column_Left" rowspan="4">
                                        <asp:Button ID="btnadd" OnClick="btnadd_Click" runat="server" Width="50%" CssClass="CSButton" Text="ADD ITEMS"></asp:Button></td>
                                </tr>
                         
                                <tr>
                                    <td style="width: 20%" class="column_RightBold"></td>
                                    <td style="width: 40%" class="column_Left">
                                       
                                </tr>

                           
                            </table>
                            
                        </td>
                        <td style="width: 1%"></td>
                    </tr>



                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List of Items
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="gvbody" runat="server" Width="98%" SkinID="GridViewAA" ShowFooter="True" EmptyDataText="No Data Found." PageSize="5"
                                CaptionAlign="Left" AutoGenerateColumns="False" DataKeyNames="Item_ID">
                                <Columns>
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:Label Style="text-align: left" ID="lbldesc" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Unit">
                                        <ItemTemplate>
                                            <asp:Label ID="lblunit" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:TextBox Style="text-align: right" ID="txtqty" runat="server" Width="95%" CssClass="text" SkinID="text" Text='<%# Bind("Qty") %>' OnTextChanged="txtqty_TextChanged" AutoPostBack="True"></asp:TextBox><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtqty" ValidChars="1234567890"></cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Unit Price">
                                        <ItemTemplate>
                                            <asp:TextBox Style="text-align: right" ID="txtcost" runat="server" Width="95%" CssClass="text" SkinID="text" Text='<%# Bind("Price", "{0:N}") %>' OnTextChanged="txtcost_TextChanged" AutoPostBack="True"></asp:TextBox><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtcost" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="total" DataFormatString="{0:N}" HeaderText="Total Amount">
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>

                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>

                                <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>



                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 90%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Reference Number : </td>
                                    <td style="width: 40%" class="column_Left">
                                        <asp:TextBox ID="txtRef" runat="server" Width="60%" ReadOnly="True" CssClass="txtbox_Var" Enabled="False"></asp:TextBox></td>
                                   
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Date : </td>
                                    <td style="width: 40%" class="column_Left">
                                        <asp:TextBox ID="txtprdate" runat="server" Width="30%" CssClass="txtbox_Date" Enabled="False"></asp:TextBox>
                                        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton></td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Accepted / Received by : </td>
                                    <td style="width: 40%" class="column_Left">
                                        <asp:DropDownList ID="ddReceivedBy" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList></td>
                                </tr>

                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Remarks : </td>
                                    <td style="width: 40%" class="column_Left">
                                        <asp:TextBox ID="txtremarks" runat="server" Width="95%" CssClass="txtbox_Remarks" Enabled="False" TextMode="MultiLine"></asp:TextBox></td>
                                </tr>
                            </table>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ImageButton2" TargetControlID="txtprdate"></cc1:CalendarExtender>

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
                            <asp:Button ID="btnSave" runat="server" Width="150px" Enabled="False" Text="SAVE" CssClass="CSButton" OnClientClick="StartProgressBar();" EnableTheming="True"></asp:Button>
                            &nbsp;<asp:Button ID="btnReceiving" OnClick="btnReceiving_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="PREVIEW RECEIVING"></asp:Button>
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
                        <td style="width: 98%" class="DivTitle">List of Donated Properties
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Reference No. :</span>
                            &nbsp;<asp:TextBox ID="txtSearchREF" runat="server" Width="300px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnRefSearch" OnClick="btnRefSearch_Click" runat="server" Width="150px" Text="SEARCH" CssClass="CSButton" EnableTheming="True" ValidationGroup="save"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdDonationDtl" runat="server" Width="90%" SkinID="GridViewAA" EmptyDataText="No Records Found." PageSize="12"
                                CaptionAlign="Left" AutoGenerateColumns="False" DataKeyNames="Item_Desc,PropertyNo,Item_ID,PropertyDetai_ID,GA_ID"
                                OnSelectedIndexChanged="grdDonationDtl_SelectedIndexChanged" OnRowDataBound="grdDonationDtl_RowDataBound"
                                OnPageIndexChanging="grdDonationDtl_PageIndexChanging" AllowPaging="True">
                                <Columns>
                                    <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                        <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PropertyNo" HeaderText="Property No.">
                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="unit" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="price" DataFormatString="{0:N}" HeaderText="Price">
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
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
                        <td style="width: 98%" class="DivTitle">Details
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="100%">
                                <tr>
                                    <td style="width: 35%; background-color: #b1abab; font-weight: bolder; font-family: Arial; font-size: 9pt" align="center">Item Details</td>
                                    <td style="width: 30%; background-color: #b1abab; font-weight: bolder; font-family: Arial; font-size: 9pt" align="center">Expiry Details</td>
                                    <td style="width: 35%; background-color: #b1abab; font-weight: bolder; font-family: Arial; font-size: 9pt" align="center">Donor Details</td>
                                </tr>
                                <tr>
                                    <td style="width: 35%" class="borderCSS" align="center">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 30%" class="column_RightBold">Item Description :</td>
                                                <td style="width: 70%" class="column_Left">
                                                    <asp:TextBox ID="txtItemDesc" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%" class="column_RightBold">Brand Name :</td>
                                                <td style="width: 70%" class="column_Left">
                                                    <asp:TextBox ID="txtBrandName" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%" class="column_RightBold">Serial No.:</td>
                                                <td style="width: 70%" class="column_Left">
                                                    <asp:TextBox ID="txtSerialNo" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%" class="column_RightBold">Storage :</td>
                                                <td style="width: 70%" class="column_Left">
                                                    <asp:TextBox ID="txtStorage" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%" class="column_RightBold">Dep. Rate :</td>
                                                <td style="width: 70%" class="column_Left">
                                                    <asp:TextBox ID="txtDepRate" runat="server" Width="50%" CssClass="txtbox_Amt">0.00</asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%" class="column_RightBold">Dep. Value :</td>
                                                <td style="width: 70%" class="column_Left">
                                                    <asp:TextBox ID="txtDepValue" runat="server" Width="50%" CssClass="txtbox_Amt">0.00</asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 30%" class="borderCSS" align="center">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 35%" class="column_RightBold">Form:</td>
                                                <td style="width: 65%" class="column_Left">
                                                    <asp:TextBox ID="txtForm" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 35%" class="column_RightBold">QTC/Rx:</td>
                                                <td style="width: 65%" class="column_Left">
                                                    <asp:TextBox ID="txtQTCRx" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 35%" class="column_RightBold">Mftg. Date:</td>
                                                <td style="width: 65%" class="column_Left">
                                                    <asp:TextBox ID="txtMftg" runat="server" Width="98%" CssClass="txtbox_Date"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 35%" class="column_RightBold">Batch:</td>
                                                <td style="width: 65%" class="column_Left">
                                                    <asp:TextBox ID="txtBatch" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 35%" class="column_RightBold">Lot:</td>
                                                <td style="width: 65%" class="column_Left">
                                                    <asp:TextBox ID="txtLot" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 35%" class="column_RightBold">Expiry Date:</td>
                                                <td style="width: 65%" class="column_Left">
                                                    <asp:TextBox ID="txtExpire" runat="server" Width="98%" CssClass="txtbox_Date"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 35%" class="column_RightBold">Alert:</td>
                                                <td style="width: 65%" class="column_Left">
                                                    <asp:TextBox ID="txtAlert" runat="server" Width="98%" CssClass="txtbox_Date"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 35%" class="borderCSS" align="center">
                                        <table style="width: 99%">
                                            <tr>
                                                <td style="width: 20%" class="column_RightBold">Type : </td>
                                                <td style="width: 80%" class="column_Left">
                                                    <asp:TextBox ID="txtDonationType" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%" class="column_RightBold">Name : </td>
                                                <td style="width: 80%" class="column_Left">
                                                    <asp:TextBox ID="txtDonorName" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%" class="column_RightBold">Address :</td>
                                                <td style="width: 80%" class="column_Left">
                                                    <asp:TextBox ID="txtAddress" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%" class="column_RightBold">Tel. No : </td>
                                                <td style="width: 80%" class="column_Left">
                                                    <asp:TextBox ID="txtTelephone" runat="server" Width="50%" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%" class="column_RightBold">Email : </td>
                                                <td style="width: 80%" class="column_Left">
                                                    <asp:TextBox ID="txtEmail" runat="server" Width="50%" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnSaveDonationDtl" OnClick="btnSaveDonationDtl_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="SAVE" OnClientClick="StartProgressBar();" EnableTheming="True" ValidationGroup="save"></asp:Button>
                            &nbsp;<asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" Width="150px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();" EnableTheming="True" ValidationGroup="save"></asp:Button>
                            <asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="PREVIEW" Visible="False"></asp:Button>
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
            

            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnadd" CancelControlID="ImageButton3" PopupControlID="popup" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="popup" runat="server" Width="750px" CssClass="Panel_Popup">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">
                            <table width="100%">
                                <tr>
                                    <td class ="column_left"> Items</td>
                                    <td class ="column_Right">
                                      <asp:Button id="btnclosemodalitems" runat="server" class="ButtonExit" ForeColor="white" BorderColor ="White"  Text ="X"/>

                                    </td>
                                </tr>
                            </table>
                           
                        </td>
                      
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Description :</span>
                            &nbsp;<asp:TextBox ID="txtsearchitems" runat="server" Width="40%" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Width="100px" CssClass="CSButton" Text="SEARCH"></asp:Button>
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
                            <asp:GridView ID="gvitems" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="item_id" OnPageIndexChanging="gvitems_PageIndexChanging"
                                AllowPaging="True" PageSize="8">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="CheckBox2" runat="server" Width="50px" Font-Bold="True" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" Text="All" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" Width="50px"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                        <ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItem_ID" runat="server" Text='<%# Bind("Item_id") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10px"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblGA_ID" runat="server" Text='<%# Bind("GA_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblGA_code" runat="server" Text='<%# Bind("GA_code") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
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
                            <asp:Button ID="Button4" runat="server" Width="150px" CssClass="CSButton" Text="LOAD" SkinID="Button" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>

                <%--

                <table id="TablepopUP" height="486" cellspacing="0" cellpadding="0" width="747" border="0">
                    <tbody>
                        <tr>
                            <td colspan="2">
                                <img height="1" alt="" src="../images/modalpopup_01.png" width="747" /></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_02.png); width: 772px; height: 39px"></td>
                            <td style="width: 46px; height: 39px">
                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../images/modalpopup_03.png"></asp:ImageButton></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_04.png); vertical-align: top; width: 772px" id="Td3">
                                <table style="width: 705px; height: 336px" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="vertical-align: top; width: 4%; text-align: center"></td>
                                            <td style="vertical-align: top; width: 100%; text-align: center">
                                                <table style="width: 100%" class="text" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 100%" colspan="3">
                                                                <table style="width: 100%">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="width: 20%" class="column_RightBold">Search Description :</td>
                                                                            <td style="width: 50%"></td>
                                                                            <td style="width: 30%" class="column_Left"></td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>

                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 4%; text-align: center"></td>
                                            <td style="width: 100%; text-align: center">
                                                </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td style="background-image: url(../images/modalpopup_05.png); width: 46px; height: 446px"></td>
                        </tr>
                    </tbody>
                </table>--%>
            </asp:Panel>




            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
        </ContentTemplate>
    </asp:UpdatePanel>


    <script language="javascript" type="text/javascript">

        function Table2_onclick() { }
        function fun1(e, button1) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(button1);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
    </script>
</asp:Content>

