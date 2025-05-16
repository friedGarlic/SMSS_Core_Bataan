<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="t_StockCard_v2.aspx.vb" Inherits="Records_t_StockCard_v2" Title="Encoding of Office Supplies" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../Membership/MasterPage/js/autoCurrency.js"></script>
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">


        window.onbeforeunload = function (e) {
            var e = e || window.event;
            // For IE and FireFox
            var value = "There is some data to be saved!"
            if (e) {
                e.returnValue = value;
            }

            // For Safari
            return value;

        }





        function correctQty(Integer) {
            //var ROP =  parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtReOrderPt').value);
            //var Qty =  parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtQuantity').value);
            //if (Qty < ROP) {
            //    document.getElementById('ctl00_ContentPlaceHolder1_txtQuantity').value = ""
            //    alert("Warning : Quantity should be higher that ROP")
            //}
        }

        function correctQtyElectrical(Integer) {
            //var ROP =  parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtReorderPointElectrical').value);
            //var Qty =  parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtQuantityElectrical').value);
            //if (Qty < ROP) {
            //    document.getElementById('ctl00_ContentPlaceHolder1_txtQuantityElectrical').value = ""
            //    alert("Warning : Quantity should be higher that ROP")
            //}
        }

        function SetMessage() {
            var traps;
            if (window.confirm("Do you want to save this transaction?")) {
                traps = "Yes";
            }
            else {
                traps = "No";
            }

            document.getElementById("ctl00_ContentPlaceHolder1_hndLoad").value = traps;
        }
    </script>


    <asp:ScriptManager ID="ScriptManagerStock" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle"><%--STOCK CARD--%><strong> Supplies</strong>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class=" column_LeftBold ">Sub Classification : 
                                 <asp:DropDownList ID="DrpSubClass" runat="server" Width="20%" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="DrpSubClass_SelectedIndexChanged"></asp:DropDownList>

                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr style="display: none;">
                        <td style="width: 1%"></td>
                        <td style="width: 98%; text-align: right;" class="column_RightBold"><%--STOCK CARD--%>Date : 
                            <asp:TextBox ID="txtDate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr style="display: none;">
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table>
                                <tr>
                                    <td>
                                        <span class="column_RightBold">General Account :</span>
                                    </td>
                                    <td colspan=" 6">
                                        <asp:DropDownList ID="ddGlAccount" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <span class="column_RightBold">Category :</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddCategory" runat="server" Width="200px" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <span class="column_RightBold">Sub Category :</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddSubCategory" runat="server" Width="200px" AutoPostBack="True" CssClass="drpdownCSS" Enabled=" false" OnSelectedIndexChanged="ddSubCategory_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <span class="column_RightBold">Description :</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSearchStock" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearchStock" OnClick="btnSearchStock_Click" runat="server" Width="100px" CssClass="CSButton" Text="Search"></asp:Button>

                                    </td>
                                </tr>
                            </table>

                            &nbsp;&nbsp;
                              &nbsp;
                           
                            &nbsp;
                            &nbsp;</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr style="display: none;">
                        <td style="width: 98%" class="DivTitle" colspan=" 2">LIST OF SUPPLIES
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdStockList" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="Item_ID,GA_ID"
                                AllowPaging="True" OnPageIndexChanging="grdStockList_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="Item_ID" HeaderText="Item No.">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="UNIT">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Item_Desc" HeaderText="ITEM DESCRIPTION">
                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Balance" HeaderText="CURRENT BALANCE">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="reorderPT" HeaderText="REORDER PT">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="QTY" Visible="False"></asp:BoundField>
                                    <asp:BoundField HeaderText="NO OF ORDERS/YEAR" Visible="False"></asp:BoundField>
                                    <asp:BoundField HeaderText="MIN QTY/ORDER" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="Location" HeaderText="LOCATION">
                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Item_ID" HeaderText="Item_ID" Visible="False"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr style="display: none;">
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle"><%--Batch--%> INCOMING DELIVERIES
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr style="display: none;">
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdsupplies" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="POHdr_ID,StockID,GA_ID,Received_ID"
                                AllowPaging="True" OnPageIndexChanging="grdsupplies_PageIndexChanging" OnRowDataBound="grdmedicalsupplies_RowDataBound"
                                OnSelectedIndexChanged="grdmedicalsupplies_SelectedIndexChanged" PageSize="5">
                                <Columns>
                                    <asp:BoundField DataField="PO_No" HeaderText="PO NUMBER">
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="batch" HeaderText="BATCH" Visible="FALSE">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="lot" HeaderText="LOT" Visible="FALSE">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="qty" HeaderText="QUANTITY">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="qtybox" HeaderText="QTY/BOX" Visible="False">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalPcs" HeaderText="TOTAL NO. OF PCS">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ActualPrice" DataFormatString="{0:N}" HeaderText="ACTUAL PRICE">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="deliverydate" HeaderText="DELIVERY DATE">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EpiryDate" HeaderText="SUPPLIER">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">INVENTORY CARD
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">


                                    <table width="100%">
                                        <tr>
                                            <td style="width: 70%" align="center">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Name :
                                                            <asp:HiddenField ID="hdnItemNo" runat="server" />
                                                            <asp:HiddenField ID="hdnGAId" runat="server" />

                                                        </td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:DropDownList ID="drpItemDesc1" AutoPostBack="true" runat="server" Width="98%" OnSelectedIndexChanged="drpItemDesc1_SelectedIndexChanged" Height="16px"></asp:DropDownList>
                                                            <asp:TextBox ID="txtItemDesc1" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible="false"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="SearchCustomers" MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtItemDesc1" FirstRowSelected="false"></cc1:AutoCompleteExtender>

                                                        </td>
                                                        <td style="width: 15%;" class="column_RightBold">Unit :</td>
                                                        <td style="width: 35%;" class="column_Left">
                                                            <asp:DropDownList ID="drpUnit" runat="server" Width="40%" Enabled="true"></asp:DropDownList>
                                                        </td>
                                                        <td style="width: 15%; display: none;" class="column_RightBold">Category :</td>
                                                        <td style="width: 35%; display: none;" class="column_Left">
                                                            <asp:TextBox ID="txtCategory" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Brand Name :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtBrandName1" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Length :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtLenght" runat="server" Width="40%" CssClass="txtbox_Var" ReadOnly="True" AutoPostBack="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="width: 35%; display: none;">
                                                        <td style="width: 15%" class="column_RightBold">Supplier :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:LinkButton ID="lnksupplieroffice" runat="server" CssClass="LinkBtnSelect" Text=" Supplier"></asp:LinkButton>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Size :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtSize" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" AutoPostBack="true"></asp:TextBox>
                                                        </td>

                                                        <td style="width: 15%" class="column_RightBold">Width :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtWidth" runat="server" Width="40%" CssClass="txtbox_Var" ReadOnly="True" AutoPostBack="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Color :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtColor" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" AutoPostBack="true"></asp:TextBox>
                                                        </td>

                                                        <td style="width: 15%" class="column_RightBold">Height :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtHeight" runat="server" Width="40%" CssClass="txtbox_Var" ReadOnly="True" AutoPostBack="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%; display: none;" class="column_RightBold">Dep. Rate :</td>
                                                        <td style="width: 35%; display: none;" class="column_Left">
                                                            <asp:TextBox ID="txtDepRate1" runat="server" Width="40%" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox>Percent (%)
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Unit Cost :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtUnitPrice" runat="server" Width="40%" CssClass="txtbox_Amt" ReadOnly="True" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" AutoPostBack="true"></asp:TextBox>

                                                        </td>

                                                        <td style="width: 15%" class="column_RightBold">Weight :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtWeight" runat="server" Width="40%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%; display: none;" class="column_RightBold">Dep. Value :</td>
                                                        <td style="width: 35%; display: none;" class="column_Left">
                                                            <asp:TextBox ID="txtDepValue1" runat="server" Width="40%" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Reorder Pt. :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtReOrderPt" runat="server" CssClass="txtbox_Amt" ReadOnly="true" Width="50px"></asp:TextBox>
                                                            <asp:Button ID="btnROP" runat="server" CssClass="CSButton" OnClick="btnROP_Click" Text="R.O.P" Width="40" />

                                                        </td>
                                                        <td style="width: 10%" class="column_RightBold">Quantity :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtbox_Amt" ReadOnly="True" Width="40%" onchange="return correctQty(this.value);" AutoPostBack="true"></asp:TextBox>


                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold">Date :</td>
                                                        <td class="column_Left">
                                                            <asp:TextBox ID="txtSellectDate" runat="server" CssClass="txtbox_Var0" AutoPostBack="true"></asp:TextBox></td>
                                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtSellectDate" PopupButtonID="txtSellectDate"></cc1:CalendarExtender>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <asp:HiddenField ID="hndLoad" Value="1" runat="server" />
                                                        </td>
                                                        <td></td>
                                                        <td></td>

                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <fieldset>
                                                                <legend class="column_Left" style="font-family: Arial; color: #404040;"><strong>Location:</strong></legend>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td class="column_RightBold">Warehouse :
                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:DropDownList ID="drpWarehouse" runat="server" Width="175px" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                                        </td>

                                                                        <td class="column_RightBold">Bay :
                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtBay" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>

                                                                            <asp:DropDownList ID="drpBay" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                        </td>

                                                                        <td class="column_RightBold" style="width: 10%">Column :
                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtColumn" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>

                                                                            <asp:DropDownList ID="drpColumn" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                        </td>

                                                                        <td class="column_RightBold" style="width: 10%">Floor :
                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtFloor" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>

                                                                            <asp:DropDownList ID="drpFloor" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold">Room :
                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtRoom" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>

                                                                            <asp:DropDownList ID="drpRoom" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                        </td>

                                                                        <td class="column_RightBold" style="width: 10%">Shelves :
                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtShelves" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>

                                                                            <asp:DropDownList ID="drpShelves" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                        </td>

                                                                        <td class="column_RightBold">Rack :
                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtRack" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>

                                                                            <asp:DropDownList ID="drpRack" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                        </td>

                                                                        <td class="column_RightBold">Bin :
                                                                        </td>
                                                                        <td class="column_Left">
                                                                            <asp:TextBox ID="txtBin" runat="server" Width="50px" CssClass="txtbox_Var"></asp:TextBox>
                                                                            <asp:DropDownList ID="drpBin" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible="false"></asp:DropDownList>
                                                                            <table style="position: absolute; top: -999px; width: 0px;">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBox1" runat="server" Width="0px" ReadOnly="true"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 30%" align="center">
                                                <img alt="" height="160" src="../images/Default_Image.jpg" width="80%" /><br />
                                                <asp:Button ID="Button3" OnClick="btnEdit1_Click" runat="server" Width="120px" CssClass="CSButton" Text="UPLOAD" OnClientClick="StartProgressBar();"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: right;">
                                                <asp:Button ID="btnSave" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();" OnClick="btnSave_Click"></asp:Button>
                                                &nbsp; &nbsp; &nbsp;
                                                 <asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();"></asp:Button>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 70%" align="center">
                                                <asp:Button ID="btnEdit1" OnClick="btnEdit1_Click" runat="server" Width="120px" CssClass="CSButton" Text="EDIT" OnClientClick="StartProgressBar();" Visible=" false"></asp:Button>
                                                &nbsp;<asp:Button ID="btnUpdate1" OnClick="btnUpdate1_Click" runat="server" Width="120px" CssClass="CSButton" Text="UPDATE" OnClientClick="StartProgressBar();" Visible=" false"></asp:Button>
                                                &nbsp;<asp:Button ID="btnCancel1" OnClick="btnAuthCancel_Click" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();" Visible=" false"></asp:Button>
                                            </td>
                                            <td style="width: 30%"></td>
                                        </tr>
                                    </table>
                                    <asp:Label ID="lblofficesuppliesdatetaken" runat="server" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="lblofficesuppliesuploadedby" runat="server" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="lblofficesuppliesposition" runat="server" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 77%" align="center">
                                                <table style="width: 101%">
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 11%; height: 24px;">Name : </td>
                                                        <td class="column_Left" style="width: 17%; height: 24px;">&nbsp;<asp:DropDownList ID="drpJanitorial" runat="server" CssClass="drpdownCSS" Width="175px" AutoPostBack="true"></asp:DropDownList></td>
                                                        <td class="column_RightBold" style="width: 9%; height: 24px;">Unit :</td>
                                                        <td class="column_Left" style="height: 24px; width: 15%;">
                                                            <asp:DropDownList ID="drpUnitMed" runat="server" AutoPostBack="true" CssClass="drpdownCSS" Width="100px">
                                                            </asp:DropDownList>
                                                        </td>

                                                        <td rowspan="6">
                                                            <fieldset>
                                                                <legend class="column_Left" style="font-family: Arial; color: #404040;"><strong>Mftg Info:</strong></legend>
                                                                <table>
                                                                    <tr>
                                                                        <td class="column_RightBold" style="width: 75px">Batch :</td>
                                                                        <td class="column_Left" style="width: 160px">
                                                                            <asp:TextBox ID="txtBatch" runat="server" CssClass="txtbox_Var" Width="130px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold" style="width: 75px">Lot :</td>
                                                                        <td class="column_Left" style="width: 160px">
                                                                            <asp:TextBox ID="txtLot" runat="server" CssClass="txtbox_Var" Width="130px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold" style="width: 75px">Mftg. Date :</td>
                                                                        <td class="column_Left" style="width: 160px">
                                                                            <asp:TextBox ID="txtMDate" runat="server" CssClass="txtboxinspection" Width="75px"></asp:TextBox>
                                                                            <span class="CalendarFormat">(MM/DD/YYYY)</span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold" style="width: 75px">Expiry Date :</td>
                                                                        <td class="column_Left" style="width: 160px">
                                                                            <asp:TextBox ID="txtEDate" runat="server" CssClass="txtbox_Date" Width="75px"></asp:TextBox>
                                                                            <span class="CalendarFormat">(MM/DD/YYYY)</span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="column_RightBold" style="width: 75px; color: red">Alert :</td>
                                                                        <td class="column_Left" style="width: 160px">
                                                                            <asp:TextBox ID="txtAlert" runat="server" CssClass="txtbox_Date" Width="75px"></asp:TextBox>
                                                                            <span class="CalendarFormat">(MM/DD/YYYY)</span></td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td style="width: 11%" class="column_RightBold">Description :</td>
                                                        <td style="width: 17%" class="column_Left">
                                                            <asp:TextBox ID="txtItemDesc2" runat="server" Width="175px" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 9%" class="column_RightBold">Form :</td>
                                                        <td style="width: 15%" class="column_Left">
                                                            <asp:TextBox ID="txtForm" runat="server" Width="130px" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>


                                                    </tr>
                                                    <tr>
                                                        <td style="width: 11%; height: 20px;" class="column_RightBold">Brand Name :</td>
                                                        <td style="width: 17%; height: 20px;" class="column_Left">
                                                            <asp:TextBox ID="txtBrandName2" runat="server" Width="175px" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 9%; height: 20px;" class="column_RightBold">OTC / Rx :</td>
                                                        <td style="width: 15%; height: 20px;" class="column_Left">
                                                            <asp:TextBox ID="txtOTC" runat="server" Width="130px" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>


                                                    </tr>
                                                    <tr>
                                                        <td style="width: 11%" class="column_RightBold">Dose :</td>
                                                        <td style="width: 17%" class="column_Left">
                                                            <asp:TextBox ID="txtDose" runat="server" CssClass="txtbox_Var" Width="175px"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 9%" class="column_RightBold">Unit Cost :</td>
                                                        <td style="width: 15%" class="column_Left">
                                                            <asp:TextBox ID="txtUnitCostMed" runat="server" CssClass="txtbox_Var" Width="130px" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
                                                        </td>


                                                    </tr>
                                                    <tr>
                                                        <td style="width: 11%; height: 23px;" class="column_RightBold">Size :</td>
                                                        <td style="width: 17%; height: 23px;" class="column_Left">
                                                            <asp:TextBox ID="txtSizeMed" runat="server" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 9%; height: 23px;" class="column_RightBold">Quantity :</td>
                                                        <td style="width: 15%; height: 23px;" class="column_Left">
                                                            <asp:TextBox ID="txtQuantityMed" runat="server" CssClass="txtbox_Var" Width="50px"></asp:TextBox>
                                                        </td>


                                                    </tr>
                                                    <tr>
                                                        <td style="width: 11%; height: 25px;" class="column_RightBold">Color :</td>
                                                        <td style="width: 17%; height: 25px;" class="column_Left">
                                                            <asp:TextBox ID="txtColorMed" runat="server" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 9%; height: 25px;" class="column_RightBold">Date :</td>
                                                        <td style="width: 15%; height: 25px;" class="column_Left">
                                                            <asp:TextBox ID="txtDateMed" runat="server" CssClass="txtbox_Amt" Enabled="true" Width="75%"></asp:TextBox>
                                                        </td>


                                                    </tr>
                                                    <tr>
                                                        <td style="width: 11%" class="column_RightBold">Reorder Pt. :</td>
                                                        <td style="width: 17%" class="column_Left">
                                                            <asp:TextBox ID="txtReorderPointMed" runat="server" CssClass="txtbox_Var" Enabled="false" Width="50px"></asp:TextBox>
                                                            <asp:Button ID="btnROPMed" runat="server" CssClass="CSButton" Text="R.O.P" Width="40" />
                                                        </td>
                                                        <td style="width: 9%" class="column_RightBold">&nbsp;</td>
                                                        <td style="width: 15%" class="column_Left">&nbsp;</td>
                                                        <td class="column_RightBold">
                                                            <asp:HiddenField ID="hndMed" runat="server" />
                                                            <asp:LinkButton ID="lnksuppliermed" runat="server" CssClass="LinkBtnSelect" Text="Supplier"></asp:LinkButton>
                                                            <asp:Button ID="btnEdit2" runat="server" CssClass="CSButton" OnClick="btnEdit2_Click" OnClientClick="StartProgressBar();" Text="EDIT" Visible="false" Width="120px" />
                                                        </td>

                                                    </tr>



                                                </table>
                                            </td>
                                            <td align="center" style="width: 10%">
                                                <img alt="" src="../images/Default_Image.jpg" style="height: 133px; width: 132px;" />
                                                <br />
                                                <asp:Button ID="Button6" runat="server" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="UPLOAD" Width="75px" />

                                                &nbsp;

                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <fieldset>
                                                    <legend class="column_Left" style="font-family: Arial; color: #404040;"><strong>Location:</strong></legend>
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="column_RightBold" style="width: 84px">Warehouse : </td>
                                                            <td class="column_Left">
                                                                <asp:DropDownList ID="drpWarehouseMedical" runat="server" CssClass="drpdownCSS" Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="column_RightBold" style="width: 60px">Bay : </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBayMedical" runat="server" CssClass="txtbox_Var" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold" style="width: 57px">Column : </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtColumnMedical" runat="server" CssClass="txtbox_Var" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold" style="width: 46px">Floor : </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtFloorMedical" runat="server" CssClass="txtbox_Var" Width="75px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold" style="width: 84px">Room : </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoodMedical" runat="server" CssClass="txtbox_Var" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold" style="width: 60px">Shelves : </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtShelvesMedical" runat="server" CssClass="txtbox_Var" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold" style="width: 57px">Rack : </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRackMedical" runat="server" CssClass="txtbox_Var" Width="75px"></asp:TextBox>
                                                            </td>
                                                            <td class="column_RightBold" style="width: 46px">Bin : </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBinMedical" runat="server" CssClass="txtbox_Var" Width="75px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td style="text-align: center">
                                                            <asp:Button ID="btnUpdateDetails2" runat="server" CssClass="CSButton" OnClick="btnUpdateDetails2_Click" OnClientClick="StartProgressBar();" Text="SAVE" Width="75px" />
                                                        </td>
                                                        <td style="text-align: center">
                                                            <asp:Button ID="btnCancel2" runat="server" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="CANCEL" Width="75px" />
                                                        </td>
                                                    </tr>
                                                </table>

                                            </td>
                                        </tr>
                                    </table>

                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtMDate" Enabled="True" PopupButtonID="txtMDate"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEDate" Enabled="True" PopupButtonID="txtEDate"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtAlert" Enabled="True" PopupButtonID="txtAlert"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtDateMed" Enabled="True" PopupButtonID="txtDateMed"></cc1:CalendarExtender>
                                    <asp:Label ID="lblmedicinedatetaken" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="lblmedicineUploadedby" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="lblmedicineposition" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label>


                                </asp:View>
                                <asp:View ID="View3" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td class="column_RightBold" style="width: 100px">Name : </td>
                                            <td class="column_Left" style="width: 100px">
                                                <asp:DropDownList ID="drpNameElectrical" runat="server" CssClass="drpdownCSS" Width="200px" AutoPostBack="true"></asp:DropDownList></td>
                                            <td class="column_RightBold" style="width: 100px">Unit : </td>
                                            <td class="column_Left">
                                                <asp:DropDownList ID="drpUnitElectrical" runat="server" CssClass="drpdownCSS" Width="100px"></asp:DropDownList></td>
                                            <td colspan="2" rowspan="7" align="center" style="width: 25%">
                                                <img alt="" height="160" src="../images/Default_Image.jpg" width="80%" />
                                                <asp:Button ID="Button1" runat="server" Text="UPLOAD" CssClass="CSButton" Width="100" />
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 100px">Brand Name : </td>
                                            <td class="column_Left" style="width: 233px">
                                                <asp:TextBox ID="txtBrandElectrical" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                            <td class="column_RightBold">Length : </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtLengthElectrical" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>

                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 100px">Size : </td>
                                            <td class="column_Left" style="width: 233px">
                                                <asp:TextBox ID="txtSizeElectrical" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                            <td class="column_RightBold">Width : </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtWidthElectrical" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>

                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 100px">Color : </td>
                                            <td class="column_Left" style="width: 233px">
                                                <asp:TextBox ID="txtColorElectrical" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                            <td class="column_RightBold">Weight : </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtWeightElectrical" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>

                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 100px">&nbsp;Unit Cost :</td>
                                            <td class="column_Left" style="width: 233px">
                                                <asp:TextBox ID="txtUnitCostElectrical" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox>
                                            </td>
                                            <td class="column_RightBold">Height : </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtHeightElectrical" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>

                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 100px">&nbsp;Reorder Point :</td>
                                            <td class="column_Left" style="width: 233px">
                                                <asp:TextBox ID="txtReorderPointElectrical" runat="server" CssClass="txtbox_Var" Width="100px" Enabled="False"></asp:TextBox>
                                                <asp:Button ID="Button2" runat="server" CssClass="CSButton" OnClick="btnROP_Click" Text="R.O.P" Width="40" />
                                                <asp:HiddenField ID="hdnROP" runat="server" />
                                            </td>
                                            <td class="column_RightBold">Quantity : </td>
                                            <td class="column_Left">
                                                <asp:TextBox ID="txtQuantityElectrical" runat="server" CssClass="txtbox_Var" Width="100px" onchange="return correctQtyElectrical(this.value);"></asp:TextBox>
                                                <asp:HiddenField ID="hdnApproval" Value="" runat="server" />
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="column_RightBold" style="width: 100px">&nbsp;Date :</td>
                                            <td class="column_Left" style="width: 233px">
                                                <asp:TextBox ID="txtDateElectrical" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                            <td class="column_RightBold">&nbsp;</td>
                                            <td class="column_Left">&nbsp;</td>
                                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtDateElectrical" PopupButtonID="txtDateElectrical"></cc1:CalendarExtender>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <fieldset>
                                                    <legend class="column_Left" style="font-family: Arial; color: #404040;"><strong>Location:</strong></legend>
                                                    <table>
                                                        <tr>
                                                            <td class="column_RightBold" style="width: 95px">Warehouse : </td>
                                                            <td class="column_Left">
                                                                <asp:DropDownList ID="drpWarehouseElectrical" runat="server" CssClass="drpdownCSS" Width="100px"></asp:DropDownList></td>
                                                            <td class="column_RightBold" style="width: 75px">Bay : </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBayElectrical" runat="server" Width="100px"> </asp:TextBox></td>
                                                            <td class="column_RightBold" style="width: 75px">Column : </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtColumnElectrical" runat="server" Width="100px"></asp:TextBox></td>
                                                            <td class="column_RightBold" style="width: 75px">Floor : </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtFloorElectrical" runat="server" Width="100px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="column_RightBold" style="width: 80px">Room : </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRoomElectrical" runat="server" Width="100px"></asp:TextBox></td>
                                                            <td class="column_RightBold" style="width: 75px">Shelves : </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtShelvesElectrical" runat="server" Width="100px"></asp:TextBox></td>
                                                            <td class="column_RightBold" style="width: 75px">Rack : </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtRackElectrical" runat="server" Width="100px"></asp:TextBox></td>
                                                            <td class="column_RightBold" style="width: 75px">Bin : </td>
                                                            <td class="column_Left">
                                                                <asp:TextBox ID="txtBinElectrical" runat="server" Width="100px"></asp:TextBox></td>
                                                        </tr>

                                                    </table>
                                                </fieldset>

                                            </td>
                                            <td align="center">
                                                <asp:Button ID="Button4" runat="server" CssClass="CSButton" Text="SAVE" Width="100" />
                                            </td>
                                            <td align="center">
                                                <asp:Button ID="Button5" runat="server" CssClass="CSButton" Text="CANCEL " Width="100" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="height: 1%" class="DivTitle"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 100%">
                                <tbody>
                                    <tr style="display: none;">
                                        <td style="width: 55%" class="column_CenterBold">
                                            <asp:Label ID="lblHistoryDetails" runat="server" Width="100%" Text="HISTORY DETAILS" CssClass="borderCSS"></asp:Label></td>
                                        <td style="width: 14%" class="column_CenterBold">
                                            <asp:Label ID="Label2" runat="server" Width="100%" Text="DEBIT" CssClass="borderCSS"></asp:Label></td>
                                        <td style="width: 14%" class="column_CenterBold">
                                            <asp:Label ID="Label3" runat="server" Width="100%" Text="CREDIT" CssClass="borderCSS"></asp:Label></td>
                                        <td style="width: 16%" class="column_CenterBold">
                                            <asp:Label ID="Label4" runat="server" Width="100%" Text="BALANCE" CssClass="borderCSS"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" colspan="4">
                                            <asp:Panel ID="Panel2" runat="server" Width="100%" CssClass="PanelSize" ScrollBars="Vertical">

                                                <asp:GridView ID="grdLedger" runat="server" Width="100%" SkinID="GridViewAA" OnRowDataBound="grdLedger_RowDataBound" DataKeyNames="Item_ID,StockID">
                                                    <Columns>
                                                        <asp:TemplateField>

                                                            <EditItemTemplate>
                                                                <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="true" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" Text="All"></asp:CheckBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbInspection" runat="server" AutoPostBack="True" OnCheckedChanged="cbInspection_CheckedChanged"></asp:CheckBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="10px"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Trans_Type" HeaderText="PARTICULARS">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Top" Width="46%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ref" HeaderText="Ref. No." Visible="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AccountablePerson" HeaderText="Accountable Person" Visible="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Department" HeaderText="Dept / Office" Visible="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="position" HeaderText="Position" Visible="False">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="acceptedby" HeaderText="Accepted By" Visible="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <%--   <asp:BoundField DataField="inspectedby" HeaderText="UNIT">--%>
                                                        <asp:BoundField DataField="BalanceUnit" HeaderText="UNIT">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="25px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Cost" HeaderText="UNIT PRICE" SortExpression="BalUnit">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DebitQty" HeaderText="Debit Qty" SortExpression="DebitQty">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText="Debit Cost" SortExpression="DebitCost">
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="9%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CreditQty" HeaderText="Credit Qty" SortExpression="CreditQty">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText="Credit Cost" SortExpression="CreditCost">
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="9%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BalQty" HeaderText="Balance Qty" SortExpression="BalQty">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText="Balance Cost" SortExpression="BalCost">
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="9%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
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
                            <asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW" Visible="false"></asp:Button>
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







            <%-- <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>--%>


            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label3" PopupControlID="popupParticular" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Panel ID="popupParticular" runat="server" Width="350px" CssClass="Panel_Popup">
                <table width="100%">
                    <tr>
                        <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">APPROVAL
                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold">Approving Officer :
                        </td>
                        <td class="column_Left">
                            <asp:DropDownList ID="drpApprovedOfficer" runat="server" Width="150px" CssClass="ddropbox"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold">Password :
                        </td>
                        <td class="column_Left">
                            <asp:TextBox ID="txtApprovedPass" runat="server" CssClass="txtbox_Var" Width="150px" TextMode="Password"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Button ID="btnProceedEdit" OnClick="btnProceedEdit_Click" runat="server" Width="150px" CssClass="CSButton" Text="PROCEED"></asp:Button>

                            <asp:Button ID="btnAuthCancel" OnClick="btnAuthCancel_Click" runat="server" Width="150px" CssClass="CSButton" Text="CANCEL"></asp:Button>
                        </td>
                    </tr>
                </table>

            </asp:Panel>


            <asp:Panel ID="popupROP" runat="server" Width="350px" CssClass="Panel_Popup">
                <table width="100%">
                    <tr>
                        <td style="width: 100%; height: 30px; margin-left: 40px;" colspan="3" class="DivTitle">REORDER POINT COMPUTATION
                              <asp:ImageButton ID="BtnImageClose" ImageUrl="~/images/Edited Image/CloseButton.png" runat="server" border="10px" Height="13px" Width="16px" />
                    </tr>
                    <tr>
                        <td class="column_RightBold">Demand Per Day :
                        </td>
                        <td class="column_Left">
                            <asp:TextBox ID="DRP" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold">Lead Time for Delivery:
                        </td>
                        <td class="column_Left">
                            <asp:TextBox ID="LTD" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold"></td>
                        <td>

                            <asp:Button ID="BtnCompute" runat="server" Width="133px" CssClass="CSButton" Text="Compute" OnClick="BtnCompute_Click"></asp:Button>
                        </td>

                    </tr>
                    <tr>
                        <td class="column_RightBold">Reorder Point :
                        </td>
                        <td class="column_Left">
                            <asp:TextBox ID="RP" runat="server" CssClass="txtbox_Var" Width="150px" ReadOnly="true"></asp:TextBox>

                        </td>

                    </tr>
                    <tr>

                        <td style="width: 50%; height: 10px">
                            <asp:Label runat="server" ID="lblpopupROP"></asp:Label>
                        </td>
                    </tr>
                </table>

            </asp:Panel>

            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblpopupROP" PopupControlID="popupROP" CancelControlID="BtnImageClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>


            <asp:Panel ID="popupNOTIF" runat="server" CssClass="Panel_Popup" Width="300px">
                <table width="100%">
                    <tr>
                        <td class="rounded-corners" style="width: 100%; height: 30px; background-color: red" colspan="3">NOTIFICATION ALERT
                            <asp:Image ID="Notif" runat="server" ImageUrl="~/images/POPUP/alert-notif.png" Width="20" />
                    </tr>

                    <tr>
                        <td colspan="3" style="width: 100%; height: 30px;">You have reached the re-order point of this item. Order now. </td>


                    </tr>
                    <tr>
                        <td class="center">
                            <asp:Button ID="BtnOK" runat="server" CssClass="CSButton" Text="CLOSE" Width="70px" />
                        </td>
                    </tr>

                    <tr>

                        <td style="width: 50%; height: 10px">
                            <asp:Label runat="server" ID="lblNotif"></asp:Label>
                        </td>
                    </tr>
                </table>

            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="lblNotif" PopupControlID="popupNOTIF" CancelControlID="BtnImageClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

