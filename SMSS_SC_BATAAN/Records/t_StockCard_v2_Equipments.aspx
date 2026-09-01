<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="t_StockCard_v2_Equipments.aspx.vb" Inherits="Records_t_StockCard_v2_MRO" StylesheetTheme="SkinFile" Title="Stock Card"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">








</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:ScriptManager ID="ScriptManagerStock" runat="server">
    </asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
              <div>
                  <table width="1020px">
                      <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle"><%--STOCK CARD--%><strong><asp:Label ID="lblClass" runat="server" Text="Label"></asp:Label></strong>
                        </td>
                        <td style="width: 1%"></td>
                      </tr>
                        <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; text-align:right;"class="column_RightBold" ><%--STOCK CARD--%>Date : 
                            <asp:TextBox ID="txtDate" runat="server" Width="100px"  CssClass="txtbox_Date" ></asp:TextBox>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                       <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center" >
                            <table>
                                <tr>
                                    <td  class="column_RightBold" style="width: 25%" >
                                        <span class="column_RightBold" >Classification :</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddClass" runat="server" Width="200px" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddClass_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td class="column_RightBold" style ="width:100%;">
                                        General Account :
                                    </td>
                                    <td colspan =" 5">
                                        <asp:DropDownList ID="ddGlAccount" runat="server" Width="525px" AutoPostBack="True" CssClass="drpdownCSS" enabled ="false" OnSelectedIndexChanged="ddGlAccount_SelectedIndexChanged" ></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">
                                        <span class="column_RightBold">Category :</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddCategory" runat="server"  AutoPostBack="True"  Width="200px" CssClass="drpdownCSS" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged" ></asp:DropDownList> 
                                    </td>
                                    <td class="column_RightBold" style ="width:100%; display:none;">
                                        <span class="column_RightBold">Sub Category :</span>
                                    </td>
                                    <td  style ="width:100%; display:none;"> 
                                        <asp:DropDownList ID="ddSubCategory" runat="server" AutoPostBack="True"  Width="200px" CssClass="drpdownCSS" Enabled =" false" OnSelectedIndexChanged="ddSubCategory_SelectedIndexChanged" ></asp:DropDownList>
                                    </td>
                                    <td class="column_RightBold">
                                         <span >Description &nbsp; :</span>
                                    </td>
                                    <td >
                                    <asp:TextBox ID="txtSearchStock" runat="server"  Width="95%" CssClass="txtbox_Var"> </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearchStock"  runat="server" Width="100%" CssClass="CSButton" Text="Search" OnClick="btnSearchStock_Click"></asp:Button>
                        
                                    </td>
                                </tr>
                            </table>
                           
                            &nbsp;&nbsp;
                              &nbsp;
                           
                            &nbsp;
                            &nbsp;</td>
                        <td style="width: 1%"></td>
                    </tr>
                       <tr>
                         <td style="width: 98%" class="DivTitle" colspan =" 2">LIST OF <asp:Label ID="lblClass1" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                         <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdStockList" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="Item_ID,GA_ID"
                                AllowPaging="True" OnPageIndexChanging="grdStockList_PageIndexChanging"  OnRowDataBound="grdStockList_RowDataBound" OnSelectedIndexChanged="grdStockList_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="Item_ID" HeaderText="Item No.">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="unit" HeaderText="UNIT">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Item_Desc" HeaderText="ITEM DESCRIPTION">
                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Balance" HeaderText="CURRENT BALANCE">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                      <asp:BoundField HeaderText="NO. OF ORDER/YEAR">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                       <asp:BoundField HeaderText="MIN QTY/YEAR">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="reorderPT" HeaderText="REORDER PT">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Qty" HeaderText="QTY" Visible="False"></asp:BoundField>
                                    <asp:BoundField HeaderText="NO OF ORDERS/YEAR" Visible="False"></asp:BoundField>
                                    <asp:BoundField HeaderText="MIN QTY/ORDER" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="Location" HeaderText="LOCATION" Visible="False">
                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Item_ID" HeaderText="Item_ID" Visible="False"></asp:BoundField>
                                  
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                      <tr>
                          <td colspan ="3">
                                 <table style="width: 100%">
                                        <tr>
                                            <td align="center" class="DivTitle" style="width: 100%">List Of Equipments</td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <span class="column_RightBold">Serial Number :</span>
                                                &nbsp;<asp:TextBox ID="txtSerialSearch" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                &nbsp;<asp:Button ID="btnEquipmentSerialSearch"  runat="server" Width="120px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <asp:GridView ID="grdlistofEuipment" runat="server" Width="98%" SkinID="GridViewAA" OnPageIndexChanging="grdlistofEuipment_PageIndexChanging"
                                                    AllowPaging="True" HorizontalAlign="Center" DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,useful_life,Received_Dtl_ID,barcode"
                                                    OnRowDataBound="grdlistofEuipment_RowDataBound" OnSelectedIndexChanged="grdlistofEuipment_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:BoundField DataField="Type" HeaderText="TYPE OF EQUIPMENT">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="barcode" HeaderText="SERIAL NO.">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DatePurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AcquisitionCost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MarketValue" HeaderText="MARKET VALUE">
                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Condition" HeaderText="CONDITION">
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Location" HeaderText="LOCATION">
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Status" HeaderText="STATUS">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="DivTitle" style="width: 100%">Details</td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Name :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblequipmentname" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Dimension :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblequipmentdimension" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td align="center" rowspan="9" style="width: 20%">
                                                            <asp:Image ID="Image3" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Description :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblequipmentdesciption" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Area Capacity :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblequipmentareacapacity" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Power Input :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblequipmentpowerinput" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Model :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblequipmentmodel" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Dep. Rate :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:TextBox ID="lblequipmentdepreciatedRate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True" OnTextChanged="lblequipmentdepreciatedRate_TextChanged"></asp:TextBox>&nbsp;(%) Percent</td>
                                                        <td class="column_RightBold" style="width: 10%">Warranty :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblequipmentwaranty" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Salvage Value :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:TextBox ID="txtSalvageValue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" OnTextChanged="txtSalvageValue_TextChanged">0.00</asp:TextBox></td>
                                                        <td class="column_RightBold" style="width: 10%">Dep. Value :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblequipmentdepreciatedvalue" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Useful Life :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblUsefulLife" runat="server"></asp:Label>&nbsp;(Years)</td>
                                                        <td class="column_RightBold" style="width: 10%">No. of Years :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblNoYears" runat="server" Width="290px"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                                        <td class="column_Left" style="width: 30%"></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 30%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Specifications :
                                                        </td>
                                                        <td class="column_Left" colspan="3">
                                                            <asp:Label ID="lblSpecification" runat="server" CssClass="text3"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                                        <td class="column_Left" colspan="3"></td>
                                                    </tr>
                                                </table>
                                                <asp:Label ID="lblEquipDateTaken" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label>
                                                <asp:Label ID="lblEquipUploadedBy" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label>
                                                <asp:Label ID="lblEquipPosition" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="column_Left" style="width: 100%">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="column_Left" style="width: 100%">
                                                <asp:Button ID="btnEquipmentLedger" runat="server" Width="180px" CssClass="Initial" Text="Ledger"></asp:Button>
                                                <asp:Button ID="btnequipmentrepairs" runat="server" Width="180px" CssClass="Initial" Text="Repairs and Maintenance"></asp:Button>
                                                <asp:Button ID="btnequipmentattachdoc" runat="server" Width="180px" CssClass="Initial" Text="Document Attached"></asp:Button></td>
                                        </tr>
                                    </table>
                          </td>
                         
                      </tr>
                        <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle"><%--Batch--%> LIST OF EQUIPMENT
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                      <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdsupplies" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="POHdr_ID,StockID,GA_ID,Received_ID"
                                AllowPaging="True" PageSize="5">
                                <Columns>
                                    <asp:BoundField DataField="PO_No" HeaderText="PO NUMBER">
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="batch" HeaderText="BATCH" Visible ="FALSE">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="lot" HeaderText="LOT" Visible ="FALSE">
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
                        <td style="width: 98%" class="DivTitle">LEDGER CARD
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
                                                        <td style="width: 15%" class="column_RightBold">Name:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersName" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Form :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersForm" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Brand Name :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersBrandName" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Batch :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersBatch" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="display:none;">
                                                        <td style="width: 15%" class="column_RightBold">Dose :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersDose" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Batch :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersBatch1" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                       <%-- <td style="width: 15%" class="column_RightBold">Supplier :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Supplier" CssClass="LinkBtnSelect"></asp:LinkButton>
                                                        </td>--%>
                                                         <td style="width: 15%" class="column_RightBold">Unit Cost:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersUnitPrice" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Lot :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersLot" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Quantity :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersQuantity" runat="server" Width="50%" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox>
                                                           
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Mftg. Date :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtMDateConsOthers" runat="server" Width="50%" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                         <td style="width: 15%" class="column_RightBold">Dep. Rate :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersDepRate" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Expiry Date :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtEDateConsOthers" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                       <td style="width: 15%" class="column_RightBold">Dep. Value :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtConsOthersDepValue" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Alert :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtAlertConsOthers" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td colspan="4">
                                                             <fieldset>
                                                                 <legend  class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Location:</strong></legend>
                                                                 <table width="100%">
                                                                     <tr>
                                                                         <td class="column_RightBold">Warehouse :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:DropDownList ID="drpMROConsOthersWarehouse" runat="server" Width="90%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Bay :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtConsOthersBay" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList2" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Column :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                 <asp:TextBox ID="txtConsOthersColumn" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList3" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Floor :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                <asp:TextBox ID="txtConsOthersFloor" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList4" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                     <tr>
                                                                         <td class="column_RightBold">Room :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtConsOthersRoom" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList5" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Shelves :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtConsOthersShelves" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList6" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Rack :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtConsOthersRack" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList7" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                         
                                                                         <td class="column_RightBold">Bin :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtConsOthersBin" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             <asp:DropDownList ID="DropDownList8" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                    
                                                                 </table>
                                                             </fieldset>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 30%" align="center">
                                                <img alt="" height="160" src="../images/Default_Image.jpg" width="80%" />
                                            </td>
                                        </tr>
                                          <tr>
                                                                        <td colspan ="2" style="text-align:right;">
                                                                              <asp:Button ID="btnConsOthersSave" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();" OnClick="btnConsOthersSave_Click"></asp:Button>
                                                                           &nbsp; &nbsp; &nbsp;
                                                                             <asp:Button ID="Button2"  runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();"></asp:Button>
                                          
                                                                        </td>
                                                                    </tr>
                                        <tr>
                                            <td style="width: 70%" align="center">
                                               <%-- <asp:Button ID="btnEdit2" OnClick="btnEdit2_Click" runat="server" Width="120px" CssClass="CSButton" Text="EDIT" OnClientClick="StartProgressBar();"></asp:Button>
                                                &nbsp;<asp:Button ID="btnUpdateDetails2" OnClick="btnUpdateDetails2_Click" runat="server" Width="120px" CssClass="CSButton" Text="UPDATE" OnClientClick="StartProgressBar();"></asp:Button>
                                                &nbsp;<asp:Button ID="btnCancel2" OnClick="btnCancel2_Click" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();"></asp:Button>--%>
                                            </td>
                                            <td style="width: 30%"></td>
                                        </tr>
                                    </table>

                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtMDateConsOthers" Enabled="True" PopupButtonID="txtMDateConsOthers"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtEDateConsOthers" Enabled="True" PopupButtonID="txtEDateConsOthers"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtAlertConsOthers" Enabled="True" PopupButtonID="txtAlertConsOthers"></cc1:CalendarExtender>
                                    <asp:Label ID="Label1" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="Label5" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="Label6" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label>

                                </asp:View>
                                   <asp:View ID="View2" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 70%" align="center">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Name :</td>
                                                        <td style="width: 35%" class="column_Left"><asp:HiddenField ID="hdnItemNo" runat="server" /><asp:HiddenField ID="hdnGAId" runat="server" />
                                                            <asp:TextBox ID="txtItemDesc2" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Length :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtLenght" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Brand Name :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtBrandName2" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Width  :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtWidth" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style ="display:none;">
                                                        <td style="width: 15%" class="column_RightBold">Supplier :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:LinkButton ID="lnksuppliermed" runat="server" Text="Supplier" CssClass="LinkBtnSelect"></asp:LinkButton>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Height:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                           </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Size :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtSize" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Weight:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtWeight" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Color :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtColor" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Height :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                           <asp:TextBox ID="txtHeight" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                          <asp:TextBox ID="TextBox2" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false" ></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td style="width: 15%" class="column_RightBold">Component of :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtComponentof" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Unit Cost:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtUnitPrice" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Dep. Rate :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtDepRate" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Quantity :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtQuantity" runat="server" Width="50%" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox>
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Dep. Value :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtDepValue" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style ="display:none;" <%--style="width: 15%" class="column_RightBold"--%>>Expiry Date :</td>
                                                        <td style ="display:none;"<%-- style="width: 35%" class="column_Left"--%>>
                                                            <asp:TextBox ID="txtEDate" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                    </tr>
                                                    <tr style ="display:none;">
                                                        <td style="width: 15%" class="column_RightBold"></td>
                                                        <td style="width: 35%" class="column_Left"></td>
                                                        <td style="width: 15%" class="column_RightBold">Alert :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtAlert" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td colspan="4">
                                                             <fieldset>
                                                                 <legend  class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Location:</strong></legend>
                                                                 <table width="100%">
                                                                     <tr>
                                                                         <td class="column_RightBold">Warehouse :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:DropDownList ID="drpWarehouse" runat="server" Width="90%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Bay :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtBay" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="drpBay" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Column :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                 <asp:TextBox ID="txtColumn" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="drpColumn" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Floor :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                <asp:TextBox ID="txtFloor" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="drpFloor" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                     <tr>
                                                                         <td class="column_RightBold">Room :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtRoom" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="drpRoom" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Shelves :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtShelves" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="drpShelves" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Rack :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtRack" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="drpRack" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                         
                                                                         <td class="column_RightBold">Bin :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtBin" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             <asp:DropDownList ID="drpBin" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                    
                                                                 </table>
                                                             </fieldset>
                                                        </td>
                                                    </tr>
                                                    
                                                </table>
                                            </td>
                                            <td style="width: 30%" align="center">
                                                <img alt="" height="160" src="../images/Default_Image.jpg" width="80%" />
                                            </td>
                                        </tr>
                                         <tr>
                                                                        <td colspan ="2" style="text-align:right;">
                                                                              <asp:Button ID="btnSave" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();" OnClick="btnSave_Click"></asp:Button>
                                                                           &nbsp; &nbsp; &nbsp;
                                                                             <asp:Button ID="btnCancel"  runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();"></asp:Button>
                                          
                                                                        </td>
                                                                    </tr>
                                        <tr>
                                            <td style="width: 70%" align="center">
                                                <%--<asp:Button ID="btnEdit2" OnClick="btnEdit2_Click" runat="server" Width="120px" CssClass="CSButton" Text="EDIT" OnClientClick="StartProgressBar();"></asp:Button>--%>
                                                <%--&nbsp;<asp:Button ID="btnUpdateDetails2" OnClick="btnUpdateDetails2_Click" runat="server" Width="120px" CssClass="CSButton" Text="UPDATE" OnClientClick="StartProgressBar();"></asp:Button>--%>
                                                &nbsp;<%--<asp:Button ID="btnCancel2" OnClick="btnCancel2_Click" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();"></asp:Button>--%></td>
                                            <td style="width: 30%">

                                            </td>
                                        </tr>
                                    </table>

                                    <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtMDate" Enabled="True" PopupButtonID="txtMDate"></cc1:CalendarExtender>--%>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEDate" Enabled="True" PopupButtonID="txtEDate"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtAlert" Enabled="True" PopupButtonID="txtAlert"></cc1:CalendarExtender>
                                    <asp:Label ID="lblmedicinedatetaken" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="lblmedicineUploadedby" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="lblmedicineposition" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label>


                                </asp:View>
                            </asp:MultiView>
                            </td>

                        </tr>
                       <tr>
                        <td style="width: 1%"></td>
                        <td style="height: 1%" class="DivTitle">
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                      <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 100%">
                                <tbody>
                                    <tr>
                                        <td style="width: 38%" class="column_CenterBold">
                                            <asp:Label ID="lblHistoryDetails" runat="server" Width="100%" Text="DETAILS" CssClass="borderCSS"></asp:Label></td>
                                        <td style="width: 19%" class="column_CenterBold">
                                            <asp:Label ID="Label2" runat="server" Width="100%" Text="DEBIT"  CssClass="borderCSS"></asp:Label></td>
                                        <td style="width: 19%" class="column_CenterBold">                                             
                                            <asp:Label ID="Label3" runat="server" Width="100%" Text="CREDIT" CssClass="borderCSS"></asp:Label></td>
                                        <td style="width: 21%" class="column_CenterBold">                                             
                                            <asp:Label ID="Label4" runat="server" Width="100%" Text="BALANCE" CssClass="borderCSS"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" colspan="4">
                                            <asp:Panel ID="Panel2" runat="server" Width="100%" CssClass="PanelSize" ScrollBars="Vertical">
                                                <asp:GridView ID="grdLedger" runat="server" Width="100%" SkinID="GridViewAA">
                                                    <Columns>
                                                        <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Trans_Type" HeaderText="PARTICULARS" >
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ref" HeaderText="Ref. No." Visible ="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AccountablePerson" HeaderText="Accountable Person" Visible ="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Department" HeaderText="Dept / Office" Visible ="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="position" HeaderText="Position" Visible="False" >
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="acceptedby" HeaderText="Accepted By" Visible ="FALSE">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                     <%--   <asp:BoundField DataField="inspectedby" HeaderText="UNIT">--%>
                                                            <asp:BoundField DataField="BalanceUnit" HeaderText="UNIT">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="25px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Cost" HeaderText="UNIT PRICE" SortExpression="BalUnit">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DebitQty" HeaderText="Debit Qty" SortExpression="DebitQty">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText="Debit Cost" SortExpression="DebitCost">
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CreditQty" HeaderText="Credit Qty" SortExpression="CreditQty">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText="Credit Cost" SortExpression="CreditCost">
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BalQty" HeaderText="Balance Qty" SortExpression="BalQty">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText="Balance Cost" SortExpression="BalCost">
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%"></ItemStyle>
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
                  </table>
              </div>
                <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
                  <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
         <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
       
          </ContentTemplate>
          </asp:UpdatePanel>
</asp:Content>

