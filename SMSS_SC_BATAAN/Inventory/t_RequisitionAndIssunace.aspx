<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_RequisitionAndIssunace.aspx.vb"
    EnableEventValidation="false" Inherits="Inventory_RIS" StylesheetTheme="SkinFile" Title="ISSUANCE" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript">
        // It is important to place this JavaScript code after ScriptManager1
        var xPos, yPos;
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        function BeginRequestHandler(sender, args) {
            if ($get('<%=Panel2.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPos = $get('<%=Panel2.ClientID%>').scrollLeft;
                yPos = $get('<%=Panel2.ClientID%>').scrollTop;
            }
        }



        function EndRequestHandler(sender, args) {
            if ($get('<%=Panel2.ClientID%>') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('<%=Panel2.ClientID%>').scrollLeft = xPos;
                $get('<%=Panel2.ClientID%>').scrollTop = yPos;
            }
        }


        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    </script>

    <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="true">
        <ContentTemplate>

            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">ISSUANCE
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
                            <asp:Button ID="btnRIS" OnClick="btnRIS_Click" runat="server" Width="250px" Text="Supply Requisition and Issuance" CssClass="Initial"></asp:Button>
                            <asp:Button ID="btnARE" OnClick="btnARE_Click" runat="server" Width="250px" Text="Property Acknowledgement Receipt" CssClass="Initial"></asp:Button>
                            <asp:Button ID="btnPerPO" OnClick="btnPerPO_Click" runat="server" Width="250px" Text="Issuance Per Purchase Order (PARE)" CssClass="Initial" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:MultiView ID="mvIssuance" runat="server">
                                <asp:View ID="vwRIS" runat="server">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <span class="column_RightBold">General Account :</span>
                                                    <asp:DropDownList ID="ddSupplies" runat="server" Width="350px" CssClass="drpdownCSS" OnSelectedIndexChanged="ddSupplies_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                    <asp:DropDownList ID="ddSuppliesSearch" runat="server" CssClass="drpdownCSS" Width="150px">
                                                        <asp:ListItem Selected="True" Value="1">Description</asp:ListItem>
                                                        <asp:ListItem Value="2">Item Code</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="txtSupplySearch1" runat="server" Width="150px" CssClass="txtbox_Var"></asp:TextBox>
                                                    <asp:Button ID="btnSupplySearch" OnClick="btnSupplySearch_Click" runat="server" CssClass="CSButton" Width="150px" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle">List Of Items</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView ID="gvSupplyList" runat="server" Width="95%" Font-Size="8pt" CssClass="text" SkinID="GridViewAA"
                                                        OnSelectedIndexChanged="gvSupplyList_SelectedIndexChanged" DataKeyNames="RC_ID,GA_ID,Item_Desc,Function_ID" AllowPaging="True"
                                                        OnRowDataBound="gvSupplyList_RowDataBound" EmptyDataText="No Data Found." OnPageIndexChanging="gvSupplyList_PageIndexChanging1">
                                                        <Columns>
                                                            <asp:BoundField DataField="Item_Code" HeaderText="Item Code">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                                <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Balance" HeaderText="Available Qty">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RC_Name" HeaderText="Department">
                                                                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RC_ID" HeaderText="RC_ID"></asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 10px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle">Details</td>
                                            </tr>

                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <table style="width: 90%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold">RIS Number : </td>
                                                                <td style="width: 80%" class="column_Left">
                                                                    <asp:TextBox runat="server" ID="txtCategoryCode" Width="40px" Visible="false" CssClass="txtbox_Var"></asp:TextBox>
                                                                    <asp:DropDownList runat="server" ID="drpCategoryCode" Width="50px" CssClass="drpdownCSS">
                                                                        <asp:ListItem Value="1" Text="OTS"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="OS"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="JS"></asp:ListItem>
                                                                        <asp:ListItem Value="4" Text="MS"></asp:ListItem>
                                                                        <asp:ListItem Value="5" Text="DS"></asp:ListItem>
                                                                        <asp:ListItem Value="6" Text="LS"></asp:ListItem>
                                                                        <asp:ListItem Value="7" Text="MDS"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;<span class="column_RightBold">-</span>
                                                                    &nbsp;<asp:TextBox ID="txtRIS" runat="server" Width="100px" ReadOnly="true" CssClass="txtbox_Var"></asp:TextBox>
                                                                    &nbsp;<span class="column_RightBold">Date :</span>
                                                                    &nbsp;<asp:TextBox ID="txtdate" runat="server" Width="100px" CssClass="txtbox_Date" AutoPostBack="true" OnTextChanged="txtdate_TextChanged"></asp:TextBox>
                                                                    &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                                                                    &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold">Department :</td>
                                                                <td style="width: 80%" class="column_Left">
                                                                    <asp:DropDownList ID="drpdept" runat="server" Width="60%" CssClass="drpdownCSS" AutoPostBack="True"></asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold">Function : </td>
                                                                <td style="width: 80%" class="column_Left">
                                                                    <asp:DropDownList ID="drpFunction" runat="server" Width="60%" CssClass="drpdownCSS" AutoPostBack="True"></asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold">Requested By :</td>
                                                                <td style="width: 80%" class="column_Left">
                                                                    <asp:DropDownList ID="ddmr" runat="server" Width="60%" CssClass="drpdownCSS" AutoPostBack="True"></asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold">Issued By :</td>
                                                                <td style="width: 80%" class="column_Left">
                                                                    <asp:DropDownList ID="ddIssuedby" runat="server" Width="60%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddIssuedby_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold">Received By : </td>
                                                                <td style="width: 80%" class="column_Left">
                                                                    <asp:DropDownList ID="ddReceive" runat="server" Width="60%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddReceive_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold">Purpose : </td>
                                                                <td style="width: 80%" class="column_Left">
                                                                    <asp:TextBox ID="txtremarks" runat="server" Width="60%" CssClass="txtbox_Remarks" SkinID="text" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtdate" Enabled="True" PopupButtonID="ImageButton1"></cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:Button ID="btnADD" OnClick="btnADD_Click" runat="server" CssClass="CSButton" Width="150px" Text="ADD ITEM" Enabled="False" SkinID="ButtonImage"></asp:Button>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle">List of Items</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Panel ID="Panel2" runat="server" Width="98%" Font-Bold="True" CssClass="PanelSize" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px" HorizontalAlign="Center" ScrollBars="Vertical">
                                                                <asp:GridView ID="gvbody" runat="server" Width="100%" SkinID="GridViewAA" EmptyDataText="No Data Found." AutoGenerateColumns="False" PageSize="20" ShowFooter="True">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="item_desc" HeaderText="Description">
                                                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>

                                                                        <asp:BoundField DataField="Description" HeaderText="Unit">
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                        </asp:BoundField>

                                                                        <asp:BoundField DataField="qty" HeaderText="Available Qty">
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                        </asp:BoundField>

                                                                        <asp:TemplateField HeaderText="Quantity">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtqty" runat="server" Width="90%" Text='<%# Bind("qty2") %>' CssClass="txtbox_Amt" AutoPostBack="True" OnTextChanged="txtqty_TextChanged1"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtqty" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Remarks">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtRemarks" runat="server" Width="90%" CssClass="txtbox_Remarks"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                        </asp:TemplateField>

                                                                        <asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Unit Cost" HtmlEncode="False">
                                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                        </asp:BoundField>

                                                                        <asp:BoundField DataField="total" DataFormatString="{0:N}" HeaderText="Total" HtmlEncode="False">
                                                                            <FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>
                                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                        </asp:BoundField>

                                                                    </Columns>
                                                                </asp:GridView>

                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:Button runat="server" ID="btnCopyValues" Width="150px" CssClass="CSButton" Text="Copy All Values" OnClientClick="StartProgressBar();" />
                                                    &nbsp;<asp:Button ID="btnsave" runat="server" CssClass="CSButton" Width="150px" Text="SAVE" OnClientClick="StartProgressBar();" SkinID="ButtonImage" ValidationGroup="1"></asp:Button>
                                                    &nbsp;<asp:Button ID="btnpreview" runat="server" CssClass="CSButton" Width="150px" CausesValidation="False" Text="PREVIEW RIS" Enabled="False" SkinID="ButtonImage"></asp:Button>
                                                    &nbsp;<asp:Button ID="btnPreviewICS" OnClick="btnPreviewICS_Click" runat="server" CssClass="CSButton" CausesValidation="False" Text="PREVIEW ICS" Enabled="False" SkinID="ButtonImage"></asp:Button>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:Button ID="btnnew" runat="server" CausesValidation="False" Visible="False" Text="NEW" SkinID="ButtonImage"></asp:Button><asp:Button ID="btnopen" runat="server" CausesValidation="False" Visible="False" Text="OPEN" SkinID="ButtonImage"></asp:Button></td>
                                            </tr>
                                        </tbody>
                                    </table>




                                    <%-- POP UP PANEL: LIST OF SUPPLIES TO BE ISSUE --%>
                                    <div>
                                        <asp:Panel ID="popup" runat="server" Width="800px" CssClass="Panel_Popup">
                                            <table width="100%" cellpadding="0px" cellspacing="0px">
                                                <tr>
                                                    <td style="width: 100%; height: 30px" class="DivTitle">Select Items
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%" align="center">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 1%"></td>
                                                                <td style="width: 98%" align="center">
                                                                    <span class="column_RightBold">Description :</span>
                                                                    &nbsp;<asp:TextBox ID="txtsearchitems" runat="server" Width="250px" CssClass="txtbox_Var" OnTextChanged="txtsearchitems_TextChanged"></asp:TextBox>
                                                                    &nbsp;<asp:Button ID="btnSearch" OnClick="btnSearch_Click1" runat="server" Width="120px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                                                                </td>
                                                                <td style="width: 1%"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 1%"></td>
                                                                <td style="width: 98%" align="center">
                                                                    <asp:GridView ID="gvitems" runat="server" Width="98%" SkinID="GridViewAA" OnSelectedIndexChanged="gvitems_SelectedIndexChanged3"
                                                                        DataKeyNames="Item_ID,Item_Desc,Description,Balance,total,cost" AllowPaging="True" PageSize="8"
                                                                        OnRowDeleting="gvitems_RowDeleting">
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="CheckBox2" runat="server" Text="All" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                            </asp:TemplateField>

                                                                            <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                                                <ItemStyle HorizontalAlign="Left" Width="65%"></ItemStyle>
                                                                            </asp:BoundField>

                                                                            <asp:BoundField DataField="Description" HeaderText="Unit">
                                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                            </asp:BoundField>

                                                                            <asp:BoundField DataField="Item_ID"></asp:BoundField>
                                                                            <asp:BoundField DataField="id" HeaderText="id"></asp:BoundField>

                                                                            <asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="Unit Cost">
                                                                                <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Balance" HeaderText="Balance">
                                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                            </asp:BoundField>

                                                                            <asp:TemplateField HeaderText="StockID">
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox runat="server" Text='<%# Bind("StockID") %>' ID="TextBox2"></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblStockID" runat="server" Text='<%# Bind("StockID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                                <td style="width: 1%"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 1%"></td>
                                                                <td style="width: 98%" align="center">
                                                                    <asp:Button ID="btnload" runat="server" Width="150px" CssClass="CSButton" Text="LOAD" SkinID="Button"></asp:Button>
                                                                    &nbsp;<asp:Button runat="server" ID="btnCloseGoods" Width="150px" CssClass="CSButton" Text="Close" />
                                                                </td>
                                                                <td style="width: 1%"></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%; height: 30px" align="center"></td>
                                                </tr>
                                            </table>
                                            <asp:Label runat="server" ID="lblPopItems"></asp:Label>
                                        </asp:Panel>
                                    </div>
                                    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground" TargetControlID="lblPopItems" PopupControlID="popup" Enabled="True"></cc1:ModalPopupExtender>

                                </asp:View>

                                <%--  FOR PROPERTY ACKNOWLEDGEMENT RECEIPT FOR EQUIPMENTS (PARE)  --%>
                                <asp:View ID="vwARE" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <span class="column_RightBold">General Accounts : </span>
                                                <asp:DropDownList ID="ddProperty" runat="server" CssClass="drpdownCSS" Width="320px" OnSelectedIndexChanged="ddProperty_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                &nbsp;<span class="column_RightBold">Description : </span>
                                                &nbsp;<asp:TextBox ID="txtSearchProperty" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox>
                                                &nbsp;<asp:Button ID="btnSearchProperty" OnClick="btnSearchProperty_Click" runat="server" CssClass="CSButton" Width="120px" Text="Search" OnClientClick="StartProgressBar();"></asp:Button>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" class="DivTitle">List of Items
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:GridView ID="gvsearchProperty" runat="server" Width="95%" SkinID="GridViewAA" DataKeyNames="Item_id,Item_Desc,GA_ID,ItemParticular,isDonated"
                                                    AllowPaging="True" HorizontalAlign="Center">
                                                    <Columns>
                                                        <asp:BoundField DataField="Item_Desc" HeaderText="Item Description" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Description" HeaderText="Unit">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:GridView ID="grListOfProperty" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="status,PropertyNo,Rc_name,rc_id,function_id,MREHdr_ID,Property_ID,PropertyDetai_ID,Item_Desc,Item_ID,MREDtl_ID,Cost,SerialNo"
                                                    AllowPaging="True" HorizontalAlign="Center">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="false" CssClass="LinkBtnSelect" CommandName="Select" Text="Select"></asp:LinkButton>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="Item_Desc" HeaderText="Item Description" HtmlEncode="false">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PropertyNo" HeaderText="Property Number">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AcquiredDate" HeaderText="Acq Date">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Amount">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="rc_name" HeaderText="Department">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="fullname" HeaderText=" Issued To">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DateIssued" DataFormatString="{0:d}" HeaderText="Date Issued">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MRE_Date" DataFormatString="{0:d}" HeaderText="Date Returned / Disposed">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Status" HeaderText="Status">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MRE_Hdr" HeaderText="MRE_Hdr">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:Button ID="btnADD_Item" OnClick="btnADD_Item_Click" runat="server" CssClass="CSButton" Width="150px" Text="ADD"></asp:Button>
                                                &nbsp;<asp:Button ID="btnPropNo" OnClick="btnPropNo_Click" runat="server" CssClass="CSButton" Width="150px" Text="EDIT PROPERTY NO."></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" class="DivTitle">List Of Properties To
                                                    <asp:Label ID="lblMODE" runat="server" Text="ISSUE"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:GridView ID="grdIssueItems" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="Item_Desc,PropertyNo,rc_id,function_id,Property_ID,PropertyDetai_ID,Item_ID,Cost,isDonated"
                                                    EmptyDataText="No Data Found." HorizontalAlign="Center">
                                                    <Columns>
                                                        <asp:BoundField DataField="Item_Desc" HeaderText="Item Description" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PropertyNo" HeaderText="Property Number">
                                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Amount">
                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="RC_Name" HeaderText="Department">
                                                            <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:Button ID="btnIssue" runat="server" CssClass="CSButton" Width="150px" Text="ISSUE" Enabled="False"></asp:Button>
                                                &nbsp;<asp:Button ID="btnviewProperty" OnClick="btnviewProperty_Click" runat="server" CssClass="CSButton" Width="150px" Text="VIEW PROPERTY CARD" Enabled="False"></asp:Button>
                                                &nbsp;<asp:Button ID="btnBarcode" OnClick="btnBarcode_Click" runat="server" CssClass="CSButton" Width="150px" Text="BARCODE"></asp:Button>
                                                &nbsp;<asp:Button ID="btnReturnProperty" OnClick="btnReturnProperty_Click2" runat="server" CssClass="CSButton" Width="150px" Text="RETURN" Enabled="False" Visible="false"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" class="DivTitle">Issuance
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <table style="width: 90%">
                                                    <tr>
                                                        <td align="center" colspan="2">
                                                            <img alt="" src="../images/Edited%20Image/ReceivedButton.jpg" width="200px" height="30px" /></td>
                                                        <td align="center" colspan="2">
                                                            <img alt="" src="../images/Edited%20Image/ReceivedByButton.jpg" width="200px" height="30px" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">PARE Number :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtMRE" runat="server" Width="180px" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;<asp:CheckBox ID="CheckBox3" runat="server" CssClass="rbCS_Horizontal" Text="Old Property" Enabled="False" AutoPostBack="True" OnCheckedChanged="CheckBox3_CheckedChanged"></asp:CheckBox></td>
                                                        <td style="width: 15%" class="column_RightBold"></td>
                                                        <td style="width: 35%" class="column_Left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Department :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:DropDownList ID="ddFromDepartment" runat="server" Width="300px" CssClass="drpdownCSS" AppendDataBoundItems="True">
                                                                <asp:ListItem>Select</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td style="width: 15%" class="column_RightBold">Department :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:DropDownList ID="ddByDepartment" runat="server" Width="300px" CssClass="drpdownCSS" OnSelectedIndexChanged="ddByDepartment_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True">
                                                                <asp:ListItem>Select</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Issued By :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:DropDownList ID="ddFromProperty" runat="server" Width="300px" CssClass="drpdownCSS" AppendDataBoundItems="True">
                                                                <asp:ListItem>Select</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td style="width: 15%" class="column_RightBold">Issued To :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:DropDownList ID="ddByAcknowledgement" runat="server" Width="300px" CssClass="drpdownCSS" AppendDataBoundItems="True">
                                                                <asp:ListItem>Select</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Date : </td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtDateReceivedFrom" runat="server" Width="115px" CssClass="txtbox_Date" AutoPostBack="True" OnTextChanged="txtDateReceivedFrom_TextChanged"></asp:TextBox>
                                                            &nbsp;<asp:Image ID="Image1" runat="server" Width="20px" ImageUrl="~/images/calendar1.jpg" Height="15px"></asp:Image>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span></td>
                                                        <td style="width: 15%" class="column_RightBold">Date : </td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtDateReceivedBy" runat="server" Width="115px" CssClass="txtbox_Date" OnTextChanged="txtDateReceivedBy_TextChanged"></asp:TextBox>
                                                            &nbsp;<asp:Image ID="Image2" runat="server" Width="20px" ImageUrl="~/images/calendar1.jpg" Height="15px"></asp:Image>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold"></td>
                                                        <td style="width: 35%" class="column_Left"></td>
                                                        <td style="width: 15%" class="column_RightBold"></td>
                                                        <td style="width: 35%" class="column_Left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Remarks : </td>
                                                        <td class="column_Left" colspan="3">
                                                            <asp:TextBox ID="txtARE_Remarks" runat="server" Width="500px" CssClass="txtbox_Remarks" TextMode="MultiLine"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateReceivedFrom" Enabled="True" PopupButtonID="txtDateReceivedFrom"></cc1:CalendarExtender>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateReceivedBy" Enabled="True" PopupButtonID="Image2"></cc1:CalendarExtender>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:Button ID="btnsavedoc" OnClick="btnsavedoc_Click" runat="server" CssClass="CSButton" Width="150px" Text="SAVE" OnClientClick="StartProgressBar();" Enabled="False"></asp:Button>
                                                &nbsp;<asp:Button ID="btncancelDoc" OnClick="btncancelDoc_Click" runat="server" CssClass="CSButton" Width="150px" Text="CANCEL" Enabled="False"></asp:Button>
                                                &nbsp;<asp:Button ID="btnpreviewAreDoc" OnClick="btnpreviewAreDoc_Click" runat="server" CssClass="CSButton" Width="150px" Text="PREVIEW PARE" Enabled="False"></asp:Button>
                                                &nbsp;<asp:Button ID="btnPreviewRIS" OnClick="btnPreviewRIS_Click" runat="server" CssClass="CSButton" Width="150px" Text="PREVIEW RIS" Enabled="False" Visible="false"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center"></td>
                                        </tr>
                                    </table>



                                    <asp:Panel ID="popReturn" runat="server" Width="400px" CssClass="Panel_Popup">
                                        <table width="100%" cellpadding="0px" cellspacing="0px">
                                            <tr>
                                                <td style="width: 100%; height: 30px" class="DivTitle">Return Details
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Return Date :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:TextBox ID="txtDateReturn" runat="server" Width="50%" CssClass="txtbox_Date"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Return To :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:DropDownList ID="ddReturnedTo" runat="server" Width="90%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddReturnedTo_SelectedIndexChanged" AutoPostBack="True">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Purpose :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:DropDownList ID="ddPurpose" runat="server" Width="50%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddPurpose_SelectedIndexChanged" AutoPostBack="True">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Return to Stock</asp:ListItem>
                                                                    <asp:ListItem Value="2">Dispose</asp:ListItem>
                                                                    <asp:ListItem Value="3">Repair</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Remarks :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:TextBox ID="txtReturnRemarks" runat="server" Width="90%" CssClass="txtbox_Remarks" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="width: 100%" colspan="2" align="center">
                                                                <asp:Button ID="btnReturnPro" OnClick="btnReturnPro_Click" runat="server" Width="120px" CssClass="CSButton" Text="Return" OnClientClick="StartProgressBar();"></asp:Button>
                                                                <asp:Button runat="server" ID="btnClose" CssClass="CSButton" Text="Close" Width="120px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 20px" align="center"></td>
                                            </tr>
                                        </table>

                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDateReturn" Enabled="True" PopupButtonID="txtDateReturn"></cc1:CalendarExtender>
                                        <asp:Label ID="Label1" runat="server" Width="86px" Text=" "></asp:Label>
                                    </asp:Panel>
                                    <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" BackgroundCssClass="modalBackground" TargetControlID="Label1" PopupControlID="popReturn" Enabled="True" DynamicServicePath="" CancelControlID="btnClose"></cc1:ModalPopupExtender>



                                    <asp:Panel ID="Panel4" runat="server" Width="400px" Font-Bold="True" BorderWidth="2px" BorderStyle="Solid" Height="150px" BorderColor="Gray" CssClass="Panel_Popup">
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td style="background-color: #ffffff" class="column_RightBold" colspan="4">
                                                        <asp:Button ID="Cancel2" runat="server" Width="30px" ForeColor="White" Text="X" CssClass="Close" BorderStyle="None" BackColor="#FFC080" BorderColor="#FFC080"></asp:Button>
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
                                                        <asp:Button ID="btnOK" runat="server" Width="150px" CssClass="CSButton" Text="OK" OnClientClick="StartProgressBar();"></asp:Button>
                                                    </td>
                                                    <td style="width: 40px"></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <asp:Label ID="Label2" runat="server" Width="86px" Text=" "></asp:Label>
                                    </asp:Panel>
                                    <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" BackgroundCssClass="modalBackground" TargetControlID="Label2" PopupControlID="Panel4" Enabled="True" DynamicServicePath="" CancelControlID="btnClose"></cc1:ModalPopupExtender>



                                    <asp:Panel ID="Panel1" runat="server" Width="400px" Font-Bold="True" BorderWidth="2px" BorderStyle="Solid" Height="150px"  CssClass="Panel_Popup">
                                        <table style="width: 400px">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 400px" align="center"><span style="font-size: 10pt; font-family: Arial">Edit Property Number&nbsp;</span></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 400px" align="center"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 400px" align="center"><span style="font-size: 9pt; font-family: Arial">Property No. :</span>
                                                        <asp:TextBox ID="txtPropNo" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 400px" align="center"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 400px" align="center">
                                                        <asp:Button ID="btnSaveProp" OnClick="btnSaveProp_Click" runat="server" Width="150px" Text="OK" OnClientClick="StartProgressBar();" CssClass="CSButton"></asp:Button>
                                                        <asp:Button ID="btnCancel" runat="server" Width="150px" Text="CANCEL" CssClass="CSButton"></asp:Button></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 400px" align="center"></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <asp:Label ID="Label4" runat="server" Width="86px" Text=" "></asp:Label>
                                    </asp:Panel>
                                    <cc1:ModalPopupExtender ID="ModalPopupExtender4" runat="server" BackgroundCssClass="modalBackground" TargetControlID="Label4" PopupControlID="Panel1" Enabled="True" DynamicServicePath="" CancelControlID="btnCancel">
                                    </cc1:ModalPopupExtender>
                                </asp:View>


                                <asp:View ID="vwAttch" runat="server">
                                    <table style="width: 100%" id="tbleScanDoc" runat="server">
                                        <tbody>
                                            <tr id="TR1" runat="server">
                                                <td style="width: 100%" id="TD2" align="center" runat="server">
                                                    <table id="Table6" class="DivTitle" onclick="return Table2_onclick()" width="950">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 1000px; height: 16px; text-align: left"><span style="font-size: 10pt; font-family: Verdana"><strong>SCANNED DOCUMENTS</strong></span></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="TR2" runat="server">
                                                <td style="width: 100%" id="TD3" align="center" runat="server">
                                                    <table style="width: 973px">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 581px; height: 430px" colspan="2">
                                                                    <fieldset style="width: 636px; height: 420px">
                                                                        <legend><span style="font-size: 9pt; font-family: Verdana"><strong>Document/s Submitted</strong></span></legend>
                                                                        <table style="width: 630px">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 630px; text-align: center" colspan="6">
                                                                                        <asp:HiddenField ID="hdfinspection" runat="server"></asp:HiddenField>
                                                                                        <input style="display: none" id="File2" type="file" onchange="Handlechange();" name="fileupload" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 110px" class="column_LeftBold">Document Name </td>
                                                                                    <td style="width: 5px" class="column_LeftBold">:</td>
                                                                                    <td style="width: 200px" class="column_Left">
                                                                                        <asp:TextBox ID="txtdocname" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 110px" class="column_LeftBold">Validated By </td>
                                                                                    <td style="width: 5px" class="column_LeftBold">:</td>
                                                                                    <td style="width: 200px" class="column_Left">
                                                                                        <asp:TextBox ID="txtValidatedBy" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 110px" class="column_LeftBold">Property No. </td>
                                                                                    <td style="width: 5px" class="column_LeftBold">:</td>
                                                                                    <td style="width: 200px" class="column_Left">
                                                                                        <asp:TextBox ID="txtPropertyNo" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 110px" class="column_LeftBold">Date Validated </td>
                                                                                    <td style="width: 5px" class="column_LeftBold">:</td>
                                                                                    <td style="width: 200px" class="column_Left">
                                                                                        <asp:TextBox ID="txtDatevalidated" runat="server" Width="116px" CssClass="txtboxinspection"></asp:TextBox>
                                                                                        &nbsp;<asp:Image ID="Image3" runat="server" Width="30px" ImageUrl="~/images/CalendarImage.jpg" Height="20px"></asp:Image>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDatevalidated" Enabled="True" PopupButtonID="Image3"></cc1:CalendarExtender>
                                                                        <table style="width: 628px">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 274px; height: 34px; text-align: right">
                                                                                        <input style="width: 147px; height: 32px" id="btninspectionBrowse" onclick="HandleBrowseClick();" type="submit" value="BROWSE" runat="server" onserverclick="btninspectionBrowse_ServerClick" />
                                                                                    </td>
                                                                                    <td style="width: 164px; height: 34px">
                                                                                        <asp:Button ID="btnAddDoc" OnClick="btnAddDoc_Click" runat="server" Width="169px" Text="ADD DOCUMENT" Height="32px" ValidationGroup="add"></asp:Button>
                                                                                    </td>
                                                                                    <td style="height: 34px">
                                                                                        <asp:Button ID="btndoccancel" OnClick="btndoccancel_Click" runat="server" Width="169px" Text="CANCEL" Height="32px"></asp:Button>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <br />
                                                                        <asp:GridView ID="gvDocumentAdded" runat="server" Width="628px" SkinID="GridViewGL" OnSelectedIndexChanged="gvDocumentAdded_SelectedIndexChanged" DataKeyNames="DocuID" AllowPaging="True" OnRowDataBound="gvDocumentAdded_RowDataBound" AutoGenerateColumns="False" PageSize="5" HorizontalAlign="Center">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="DocumentName" HeaderText="Document Name">
                                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="PropertyNo" HeaderText="Property No."></asp:BoundField>
                                                                                <asp:BoundField DataField="ValidatedBy" HeaderText="Validated By">
                                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="DateValidated" DataFormatString="{0:d}" HeaderText="Date Validated"></asp:BoundField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </fieldset>
                                                                </td>
                                                                <td style="width: 303px; height: 430px">
                                                                    <fieldset style="width: 302px; height: 420px">
                                                                        <legend class="text">Document Preview</legend>
                                                                        <table style="width: 296px; height: 402px">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 302px; height: 175px" align="center">
                                                                                        <asp:Image ID="imgDocPreview" runat="server" Width="302px" ImageUrl="~/images/BlankImage.jpg" Height="396px"></asp:Image>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </fieldset>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
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
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>




            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


            <asp:Panel ID="pConfOK" runat="server" Width="400px" CssClass="Panel_Popup">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td style="width: 100%; height: 30px" class="DivTitle">Barcode Image
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px" align="center"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Image ID="imgBarcode" runat="server" Width="80%"></asp:Image>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px" align="center"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Button ID="Button1" OnClick="btnOK_Click" runat="server" Width="120px" CssClass="CSButton" Text="OK"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 20px"></td>
                    </tr>
                </table>
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="mpeBarcode" runat="server" BackgroundCssClass="modalBackground" TargetControlID="Label3" PopupControlID="pConfOK" BehaviorID="mpeBarcode">
            </cc1:ModalPopupExtender>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

