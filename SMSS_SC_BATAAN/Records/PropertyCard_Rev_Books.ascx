<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PropertyCard_Rev_Books.ascx.vb" Inherits="Records_PropertyCard_Rev_Books" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table width="100%">
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF LOCATION (BOOKS)
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvBooksLocationList" runat="server"
                Width="1000px" SkinID="GridViewAA" HorizontalAlign="Center"
                DataKeyNames="item_particular_id,Item_ID,DeclaredOwner,Barangay"
                AllowPaging="True" 
                OnPageIndexChanging="gvBooksLocationList_PageIndexChanging"
                OnSelectedIndexChanged="gvBooksLocationList_SelectedIndexChanged"
                OnRowDataBound="gvBooksLocationList_RowDataBound"
                AutoGenerateColumns="False" Font-Size="9pt"
                EnableSelection="True">
                <Columns>
                    <asp:BoundField DataField="Property_code" HeaderText="CODE" Visible="False"></asp:BoundField>
                    <asp:BoundField DataField="Item_ID" HeaderText="Item Code">
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Location" HeaderText="Location">
                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="DeclaredOwner" DataFormatString="{0:N}" HeaderText="Building">
                        <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Location" HeaderText="Address" Visible="false">
                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Area" HeaderText="Area" Visible="false">
                        <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="AcqDate" HeaderText="Acquisition Date">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="AcqCost" HeaderText="Acquisition Cost">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="MarketValue" HeaderText="Market Value">
                        <ItemStyle HorizontalAlign="Center" Width="14%"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>

    <%-- Add View PIR Button --%>
    <tr>
        <td style="text-align: center; padding: 10px;">
            <asp:Button ID="btnViewPIR" runat="server" Width="240px" CssClass="CSButton" 
                Text="View Perpetual Inventory Report" OnClientClick="window.open('rpt_view_propertycard_v4.aspx')"></asp:Button>
        </td>
    </tr>
    
    <%-- Add spacing --%>
    <tr>
        <td style="height: 20px;"></td>
    </tr>
    
    <%-- New Section Header --%>
    <tr>
        <td class="DivTitle" style="width: 100%">
            LIST OF BOOKS
        </td>
    </tr>
    
    <%-- Search Section --%>
    <tr>
        <td style="width: 1000px">
            <table style="width: 100%">
                <tbody>
                    <tr>
                        <td style="width: 30%" class="column_RightBold">SEARCH PROPERTY NUMBER :</td>
                        <td style="width: 40%" class="text5">
                            <asp:TextBox ID="txtBooksPropSearch" runat="server" Width="95%"></asp:TextBox></td>
                        <td style="width: 30%" class="text5">
                            <asp:Button ID="btnBooksPropSearch" CssClass="CSButton" OnClick="btnBooksPropSearch_Click" runat="server" Width="150px" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>
    
    <%-- Books GridView --%>
    <tr>
        <td style="width: 1000px">
            <asp:GridView ID="grdlistofBooks" runat="server" Width="1000px" SkinID="GridViewAA"
                OnPageIndexChanging="grdlistofBooks_PageIndexChanging" AllowPaging="True" HorizontalAlign="Center" 
                DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,useful_life,Received_Dtl_ID"
                OnRowDataBound="grdlistofBooks_RowDataBound" OnSelectedIndexChanged="grdlistofBooks_SelectedIndexChanged" Font-Size="9pt"
                OnDataBound="grdlistofBooks_ondatabound" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="PropertyNo" HeaderText="Property No." ControlStyle-CssClass="header">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Property_code" HeaderText="Property No." Visible="false">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="ItemDescription" HeaderText="Name">
                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Title" HeaderText="Title">
                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Author" HeaderText="Author">
                        <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                        <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="AcqDate" HeaderText="Acquisition Date">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="AcqCost" HeaderText="Acquisition Cost">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="MarketValue" HeaderText="Market Value">
                        <ItemStyle HorizontalAlign="Center" Width="14%"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <br />
        </td>
    </tr>

    <%-- Add spacing after books gridview --%>
    <tr>
        <td style="height: 20px;"></td>
    </tr>
    
    <%-- BOOKS INFORMATION Header --%>
    <tr>
        <td style="width: 1000px" class="DivTitle">BOOKS INFORMATION</td>
    </tr>
    
    <%-- Books Information Table --%>
    <tr>
        <td style="width: 1000px">
            <table width="100%">
                <tr>
                    <td style="width: 80%;" valign="top">
                        <table width="100%">
                            <tr>
                                <td align="center" style="width: 100%">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Name :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtbookName" runat="server" Width="89%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 10%">Unit :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <span class="column_RightBold">
                                                <asp:DropDownList ID="drpbookUnit" runat="server" CssClass="drpdownCSS" Width="100px" Enabled="False">
                                                </asp:DropDownList>
                                                &nbsp;Quantity :</span>
                                                <asp:TextBox ID="txtbookQuantity" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td align="center" rowspan="6" style="width: 20%" valign="middle">
                                                <asp:Image ID="Image16" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                                <br />
                                                <asp:Button ID="btnbookupload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Description :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtbookdesciption" runat="server" Width="89%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 10%">Price :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtBookPrice" runat="server" Width="25%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Classification :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtBookClassification" runat="server" Width="60%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                <asp:TextBox ID="txtBookClassificationCode" runat="server" Width="25%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold">ISBN :</td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtBookISBN" runat="server" Width="89%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Title :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtbookTitle" runat="server" Width="89%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold" style="width: 10%">Author :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtbookAuthor" runat="server" Width="89%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 10%">Pub. Date :</td>
                                            <td class="column_Left" style="width: 30%">
                                                <asp:TextBox ID="txtBookPublicationDate" runat="server" CssClass="txtbox_Var" ReadOnly="true" Enabled="False"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtBookPublicationDate" PopupButtonID="txtBookPublicationDate"></cc1:CalendarExtender>
                                            </td>
                                            <td></td>
                                            <td class="column_Left">
                                                <%-- View Property Information link removed as requested --%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <fieldset style="width: 90%;">
                                                    <legend class="column_LeftBold">Acquisition :</legend>
                                                    <table>
                                                        <tr>
                                                            <td class="column_RightBold">Acquisition Date :</td>
                                                            <td class="column_Left" style="width: 300px;">
                                                                <asp:TextBox ID="txtbookAcqDate" runat="server" CssClass="txtbox_Var" Enabled="False" onchange="return NoOfYearsBook(this.value);"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txtbookAcqDate" PopupButtonID="txtbookAcqDate"></cc1:CalendarExtender>
                                                                &nbsp;(MM/DD/YYYY)
                                                            </td>
                                                            <td class="column_RightBold">Market Value :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtbookMarketValue" runat="server" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Acquisition Cost :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtbookAcqCost" runat="server" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalValBook(this),getDepValRateBook(this);"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">No. of Years :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtbookNoYears" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Depreciated Rate :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtbookdepreciatedRate" runat="server" Width="100px" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True" Enabled="False"></asp:TextBox>&nbsp;(%) Percent
                                                            </td>
                                                            <td class="column_RightBold">Useful Life :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtbookUsefulLife" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False" onchange="return getDepValRateBook(this);"></asp:TextBox>
                                                                &nbsp;(Years)
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Depreciated Value :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtDepreciatedValueBookNew" runat="server" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Salvage Value : </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtbookSalvageValue" runat="server" CssClass="txtboxAmount" Enabled="False" Onchange="this.value=formatCurrency(this.value);" Onkeyup="javascript:this.value=Comma(this.value);" style="margin-bottom: 0px" Width="85%">0.00</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Depreciation Value :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtbookdepreciatedvalue" runat="server" Width="100px" CssClass="txtbox_Var" Enabled="False" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">&nbsp;</td>
                                                            <td class="column_Left">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <fieldset style="width: 93%;">
                                                    <legend class="column_Left" style="font-family: Arial; color: #404040;"><strong>Location:</strong></legend>
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="column_RightBold">Warehouse :</td>
                                                            <td class="column_Left">
                                                                <asp:DropDownList ID="drpbookWarehouse" runat="server" Width="98%" CssClass="drpdownCSS" Enabled="False"></asp:DropDownList>
                                                            </td>
                                                            <td class="column_RightBold">Bay :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtbookBay" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold" style="width: 15%">Column :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtbookColumn" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold" style="width: 10%">Floor :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtbookFloor" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold">Room :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtbookRoom" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold" style="width: 10%">Shelves :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtbookShelves" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Rack :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtbookRack" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold">Bin :</td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtbookBin" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </td>
                                            <td style="top:50px" class="column_Center"> 
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <asp:Button ID="btn_EditBooks" Visible="false" runat="server" CssClass="CSButton" Enabled="True" OnClientClick="StartProgressBar();" Text="Edit" Width="150px" />
                                            </td>
                                        </tr>
                                        <tr style="display:none">
                                            <td style="width:200px">
                                                <asp:Label ID="lbl_book_EquipInfoId" runat="server" Text="Label"></asp:Label>
                                                <asp:Label ID="lbl_book_Property_ID" runat="server" Text="Label"></asp:Label>
                                                <asp:Label ID="lbl_book_item_ID" runat="server" Text="Label"></asp:Label>
                                                <asp:Label ID="lbl_book_EquipmentId" runat="server" Text="Label"></asp:Label>
                                                <asp:TextBox ID="txtbookUnit" runat="server" CssClass="drpdownCSS" Width="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>

    <%-- Add spacing after Books Information Table --%>
    <tr>
        <td style="height: 20px;"></td>
    </tr>
    
    <%-- Ledger GridView Section --%>
    <tr>
        <td style="width: 1000px" class="DivTitle">TRANSACTIONS</td>
    </tr>
    
    <%-- Ledger GridView --%>
    <tr>
        <td style="width: 1000px" colspan="4">
            <asp:Panel ID="Panel1" runat="server" Width="1000px" CssClass="PanelSize" ScrollBars="Vertical">
                <asp:GridView ID="grdLedger" runat="server" Width="980px" SkinID="GridViewAA" Font-Size="8pt" OnDataBound="OnDataBound">
                    <Columns>
                        <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Trans_Type" HeaderText="Particulars">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Top" Width="46%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ref" HeaderText="Ref. No.">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="AccountablePerson" HeaderText="Accountable Person" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Department" HeaderText="Dept / Office" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="position" HeaderText="Position" Visible="False">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="acceptedby" HeaderText="Accepted By" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="inspectedby" HeaderText="Inspected By" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="DebitQty" HeaderText="Qty" SortExpression="DebitQty" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="DebitUnit" HeaderText="Unit" SortExpression="DebitUnit" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText=" " SortExpression="DebitCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CreditQty" HeaderText="Qty" SortExpression="CreditQty" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CreditUnit" HeaderText="Unit" SortExpression="CreditUnit" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText=" " SortExpression="CreditCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="BalQty" HeaderText="Qty" SortExpression="BalQty" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="BalanceUnit" HeaderText="Unit" SortExpression="BalUnit" Visible="false">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText=" " SortExpression="BalCost">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </td>
    </tr>
    
    <%-- Preview Button --%>
    <tr>
        <td style="width: 1000px" colspan="4">
            <asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="200px" Text="PREVIEW" Visible="false" CssClass="CSButton"></asp:Button>
            <asp:HiddenField ID="HdfLedgerReport" runat="server" />
        </td>
    </tr>
</table>