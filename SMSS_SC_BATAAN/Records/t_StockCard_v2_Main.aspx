<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="t_StockCard_v2_Main.vb" Inherits="Records_t_StockCard_v2" Title="Stock Card" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">



</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../Membership/MasterPage/js/autoCurrency.js"></script>
    <asp:ScriptManager ID="ScriptManagerStock" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle"><%--STOCK CARD--%><strong>Stock Card</strong>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr style="display:none;">
                        <td style="width: 1%"></td>
                        <td style="width: 98%; text-align:right;"class="column_RightBold" ><%--STOCK CARD--%>Date : 
                            <asp:TextBox ID="txtDate" runat="server" Width="100px"  CssClass="txtbox_Date" ></asp:TextBox>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table>
                            <%--    <tr>
                                    <td class="column_RightBold">Department :</td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="drpDepartment" CssClass="drpdownCSS" width="350px" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        <span class="column_RightBold">Classification:</span>
                                    </td>
                                    <td >
                                        <asp:DropDownList ID="ddClassification" runat="server" width="150px" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddClassification_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <span class="column_RightBold"> Sub Classification:</span>
                                    </td>
                                    <td >
                                        <asp:DropDownList ID="drpSubClass" width="150px" runat="server"  AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="drpSubClass_SelectedIndexChanged" ></asp:DropDownList>
                                    </td>

                                    <td>
                                        <span class="column_RightBold">General Account :</span>
                                    </td>
                                    <td colspan =" 2">
                                        <asp:DropDownList ID="ddGlAccount"  width="300px" runat="server" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">
                                        <span class="column_RightBold">Category :</span>
                                    </td>
                                    <td>
                                     
                                       <asp:DropDownList ID="ddCategory" runat="server" width="150px" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged" AppendDataBoundItems="True" >
                                          <asp:ListItem Value="0">All</asp:ListItem>
                                       </asp:DropDownList> 

                                    </td>
                                    <td class="column_RightBold">
                                        <span >Sub Category :</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddSubCategory" width="150px" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Enabled ="true" OnSelectedIndexChanged="ddSubCategory_SelectedIndexChanged"  AppendDataBoundItems="True">
                                             <asp:ListItem Value="0">All</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="column_RightBold">
                                         <span >Description :</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSearchStock" runat="server" Width="90%"  CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearchStock" OnClick="btnSearchStock_Click" Width="100px" runat="server" CssClass="CSButton" Text="Search"></asp:Button>
                        
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
                         <td style="width: 98%" class="DivTitle" colspan =" 2">LIST OF <asp:Label id="lblclass1" runat="server"></asp:Label>
                        </td>
                    </tr>   
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdStockList" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="Item_ID,GA_ID,reorderpt"
                                AllowPaging="True" OnPageIndexChanging="grdStockList_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="Item_ID" HeaderText="Item No.">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="description" HeaderText="UNIT">
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
                                 <PagerStyle Font-Bold="True" />
                            </asp:GridView>
                            
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                         <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnViewSIR" runat="server" Width="240px" CssClass="CSButton" Text="View Stock Inventory Report" OnClientClick="StartProgressBar();" OnClick="btnViewSIR_Click"></asp:Button>
                        </td>
                            <td style="width: 1%"></td>
                    </tr>
                    <tr >
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle"><%--Batch--%> INCOMING DELIVERIES
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr >
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdsupplies" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="POHdr_ID,StockID,GA_ID,Received_ID"
                                AllowPaging="True" OnPageIndexChanging="grdsupplies_PageIndexChanging" OnRowDataBound="grdmedicalsupplies_RowDataBound"
                                OnSelectedIndexChanged="grdmedicalsupplies_SelectedIndexChanged" PageSize="5" >
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
                                    <asp:BoundField DataField="qty" HeaderText="QUANTITY" DataFormatString="{0:n0}">
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
                                    <asp:BoundField DataField="SuppName" HeaderText="SUPPLIER">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">INVENTORY CARD<asp:Label ID="lblCategory" runat="server" Text=""></asp:Label>
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
                                                        <td style="width: 15%" class="column_RightBold" valign="top">Name :<asp:HiddenField ID="hdnItemNo" runat="server" /><asp:HiddenField ID="hdnGAId" runat="server" />
                                                        </td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblItemDesc1" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtItemDesc1" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false" ></asp:TextBox>
                                                            </td>
                                                        <td style="width: 15%" class="column_RightBold" valign="top">Unit :</td>
                                                        <td style="width: 35%" class="column_Left" valign="top">
                                                          <asp:Label ID="lblUnit1" runat="server" Text="" Width="98%" ></asp:Label> 
                                                           <asp:DropDownList ID="DropDownList29" runat="server" Width="40%" Visible="false"></asp:DropDownList>
                                                       </td>
                                                        <td style="width: 15%; display:none;" class="column_RightBold" >Category :</td>
                                                        <td style="width: 35%;display:none;" class="column_Left">
                                                            <asp:TextBox ID="txtCategory" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Brand Name :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblBrandName1" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtBrandName1" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Length :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                              <asp:Label ID="lblLenght" runat="server" Text="" Width="98%" ></asp:Label>
                                                          
                                                            <asp:TextBox ID="txtLenght" runat="server" Width="40%" CssClass="txtbox_Var" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="width: 35%;display:none;" >
                                                        <td style="width: 15%" class="column_RightBold">Supplier :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:LinkButton ID="lnksupplieroffice" runat="server" CssClass="LinkBtnSelect" Text=" Supplier"></asp:LinkButton>
                                                        </td>
                                                       
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Size :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                             <asp:Label ID="lblSize" runat="server" Text="" Width="98%" ></asp:Label>
                                                         
                                                            <asp:TextBox ID="txtSize" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>
                                                         <td style="width: 15%" class="column_RightBold">Width :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                           
                                                              <asp:Label ID="lblWidth" runat="server" Text="" Width="98%" ></asp:Label>
                                                          <asp:TextBox ID="txtWidth" runat="server" Width="40%" CssClass="txtbox_Var" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>
                                                       
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Color:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                              <asp:Label ID="lblColor" runat="server" Text="" Width="98%" ></asp:Label>
                                                        
                                                            <asp:TextBox ID="txtColor" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Height :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblHeight" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtHeight" runat="server" Width="40%" CssClass="txtbox_Var" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%;display:none;" class="column_RightBold">Dep. Rate :</td>
                                                        <td style="width: 35%;display:none;" class="column_Left">
                                                               <asp:Label ID="lblDepRate1" runat="server" Text="" Width="50%" ></asp:Label>
                                                        
                                                            <asp:TextBox ID="txtDepRate1" runat="server" Width="40%" CssClass="txtbox_Amt" ReadOnly="True"  Visible ="false"></asp:TextBox>Percent (%)
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Unit Cost :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                              <asp:Label ID="lblUnitPrice" runat="server" Text="" Width="98%" ></asp:Label>
                                                            
                                                              <asp:TextBox ID="txtUnitPrice" runat="server" Width="40%" CssClass="txtbox_Amt" ReadOnly="True" onchange="this.value=formatCurrency(this.value);"  Visible ="false"></asp:TextBox>
                                                        
                                                               </td>
                                                         <td style="width: 15%" class="column_RightBold">Weight :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                             <asp:Label ID="lblWeight" runat="server" Text="" Width="98%" ></asp:Label>
                                                            
                                                            <asp:TextBox ID="txtWeight" runat="server" Width="40%" CssClass="txtbox_Var" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td style="width: 15%;display:none;" class="column_RightBold">Dep. Value :</td>
                                                        <td style="width: 35%;display:none;" class="column_Left">
                                                               <asp:Label ID="lblDepValue1" runat="server" Text="" Width="98%" ></asp:Label>
                                                        
                                                           <asp:TextBox ID="txtDepValue1" runat="server" Width="40%" CssClass="txtbox_Amt" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                      </td>
                                                        <td style="width: 15%" class="column_RightBold">Quantity :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblQuantity" runat="server" Text="" Width="98%" ></asp:Label>
                                                            
                                                             <asp:TextBox ID="txtQuantity" runat="server" Width="40%" CssClass="txtbox_Amt" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        
                                                           </td>
                                                              <td style="width: 15%" class="column_RightBold">Reorder Pt. :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblReorderPoint" runat="server" Text="" Width="98%" ></asp:Label>
                                                            
                                                             <asp:TextBox ID="txtReorderPoint" runat="server" Width="40%" CssClass="txtbox_Amt" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        
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
                                                                             <asp:DropDownList ID="drpWarehouse" runat="server" Width="175px" AutoPostBack="True" CssClass="drpdownCSS" enabled ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Bay :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtBay" runat="server" Width="50px" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="drpBay" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Column :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                 <asp:TextBox ID="txtColumn" runat="server" Width="50px" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="drpColumn" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false" ></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Floor :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                <asp:TextBox ID="txtFloor" runat="server" Width="50px" CssClass="txtbox_Var" ReadOnly="True" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="drpFloor" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                     <tr>
                                                                         <td class="column_RightBold">Room :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtRoom" runat="server" Width="50px" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="drpRoom" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Shelves :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtShelves" runat="server" Width="50px" CssClass="txtbox_Var" ReadOnly="True" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="drpShelves" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Rack :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtRack" runat="server" Width="50px" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="drpRack" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                         
                                                                         <td class="column_RightBold">Bin :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtBin" runat="server" Width="50px" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
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
                                                <img alt="" height="160" src="../images/Default_Image.jpg" width="80%" /><br />
                                                <asp:Button ID="Button3" runat="server" Width="120px" CssClass="CSButton" Text="UPLOAD" OnClientClick="StartProgressBar();" Visible ="false"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan ="2" style="text-align:right;">
                                                  <asp:Button ID="btnSave" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();" OnClick="btnSave_Click" Visible ="false"></asp:Button>
                                               &nbsp; &nbsp; &nbsp;
                                                 <asp:Button ID="btnCancel" OnClick="btnEdit1_Click" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();" Visible ="false"></asp:Button>
                                          
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 70%" align="center">
                                                <asp:Button ID="btnEdit1" OnClick="btnEdit1_Click" runat="server" Width="120px" CssClass="CSButton" Text="EDIT" OnClientClick="StartProgressBar();" Visible =" false"></asp:Button>
                                                &nbsp;<asp:Button ID="btnUpdate1" OnClick="btnUpdate1_Click" runat="server" Width="120px" CssClass="CSButton" Text="UPDATE" OnClientClick="StartProgressBar();" Visible =" false"></asp:Button>
                                                &nbsp;<asp:Button ID="btnCancel1" OnClick="btnCancel1_Click" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();"  Visible =" false"></asp:Button>
                                            </td>
                                            <td style="width: 30%"></td>
                                        </tr>
                                    </table>
                                    <asp:Label ID="lblofficesuppliesdatetaken" runat="server" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="lblofficesuppliesuploadedby" runat="server" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="lblofficesuppliesposition" runat="server" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 70%" align="center">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Description :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtItemDesc2" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Form :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtForm" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Brand Name :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtBrandName2" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">OTC / Rx :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtOTC" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Supplier :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:LinkButton ID="lnksuppliermed" runat="server" Text="Supplier" CssClass="LinkBtnSelect"></asp:LinkButton>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Batch :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtBatch" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Dose :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtDose" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Lot :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtLot" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Dep. Rate :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtDepRate" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Mftg. Date :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtMDate" runat="server" Width="50%" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Dep. Value :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtDepValue" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Expiry Date :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtEDate" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold"></td>
                                                        <td style="width: 35%" class="column_Left"></td>
                                                        <td style="width: 15%" class="column_RightBold">Alert :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="txtAlert" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 30%" align="center">
                                                <img alt="" height="160" src="../images/Default_Image.jpg" width="80%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 70%" align="center">
                                                <asp:Button ID="btnEdit2" OnClick="btnEdit2_Click" runat="server" Width="120px" CssClass="CSButton" Text="EDIT" OnClientClick="StartProgressBar();"></asp:Button>
                                                &nbsp;<asp:Button ID="btnUpdateDetails2" OnClick="btnUpdateDetails2_Click" runat="server" Width="120px" CssClass="CSButton" Text="UPDATE" OnClientClick="StartProgressBar();"></asp:Button>
                                                &nbsp;<asp:Button ID="btnCancel2" OnClick="btnCancel2_Click" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();"></asp:Button>
                                            </td>
                                            <td style="width: 30%"></td>
                                        </tr>
                                    </table>

                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtMDate" Enabled="True" PopupButtonID="txtMDate"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEDate" Enabled="True" PopupButtonID="txtEDate"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtAlert" Enabled="True" PopupButtonID="txtAlert"></cc1:CalendarExtender>
                                    <asp:Label ID="lblmedicinedatetaken" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="lblmedicineUploadedby" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="lblmedicineposition" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label>




                                </asp:View>
                                     <asp:View ID="View3" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 70%" align="center">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold" valign="top">Name :</td>
                                                        <td style="width: 35%" class="column_Left"><asp:HiddenField ID="HiddenField1" runat="server" /><asp:HiddenField ID="HiddenField2" runat="server" />
                                                           <asp:Label ID="lblMROsuppliesName" runat="server" Text="" Width="98%" ></asp:Label>
                                                        
                                                            <asp:TextBox ID="txtMROsuppliesName" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible="false"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold" valign="top">Unit :</td>
                                                        <td style="width: 35%" class="column_Left" valign="top">
                                                          <asp:Label ID="lblMROsuppliesUnit" runat="server" Text="" Width="98%" ></asp:Label> 
                                                           <asp:DropDownList ID="drpUnit" runat="server" Width="40%" Visible="false"></asp:DropDownList>
                                                       </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Brand Name :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                              <asp:Label ID="lblMROsuppliesBrandName" runat="server" Text="" Width="98%" ></asp:Label>
                                                        
                                                            <asp:TextBox ID="txtMROsuppliesBrandName" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible="false"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Length :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblMROsuppliesLength" runat="server" Text="" Width="98%" ></asp:Label>
                                                        
                                                            <asp:TextBox ID="txtMROsuppliesLength" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style ="display:none;">
                                                        <td style="width: 15%" class="column_RightBold">Supplier :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Supplier" CssClass="LinkBtnSelect"></asp:LinkButton>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Height:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                           </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Size :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                                 <asp:Label ID="lblMROsuppliesSize" runat="server" Text="" Width="98%" ></asp:Label>
                                                        
                                                            <asp:TextBox ID="txtMROsuppliesSize" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible="false"></asp:TextBox>
                                                        </td>
                                                        
                                                        <td style="width: 15%" class="column_RightBold">Width  :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                             <asp:Label ID="lblMROsuppliesWidth" runat="server" Text="" Width="98%" ></asp:Label>
                                                        
                                                            <asp:TextBox ID="txtMROsuppliesWidth" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Color :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                             <asp:Label ID="lblMROsuppliesColor" runat="server" Text="" Width="98%" ></asp:Label>
                                                        
                                                            <asp:TextBox ID="txtMROsuppliesColor" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible="false"></asp:TextBox>
                                                        </td>
                                                        
                                                        <td style="width: 15%" class="column_RightBold">Weight:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                                <asp:Label ID="lblMROsuppliesWeight" runat="server" Text="" Width="98%" ></asp:Label>
                                                        
                                                            <asp:TextBox ID="txtMROsuppliesWeight" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td style="width: 15%" class="column_RightBold">Component of :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                               <asp:Label ID="lblMROsuppliesComponentof" runat="server" Text="" Width="98%" ></asp:Label>
                                                        
                                                            <asp:TextBox ID="txtMROsuppliesComponentof" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible="false"></asp:TextBox>
                                                        </td>
                                                         
                                                        <td style="width: 15%" class="column_RightBold">Height :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                             <asp:Label ID="lblMROsuppliesheight" runat="server" Text="" Width="98%" ></asp:Label>
                                                        
                                                           <asp:TextBox ID="txtMROsuppliesheight" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible="false"></asp:TextBox>
                                                          <asp:TextBox ID="TextBox9" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false" ></asp:TextBox>
                                                        </td>
                                                       
                                                    </tr>
                                                    <tr> 
                                                        <td style="width: 15%" class="column_RightBold">Unit Cost:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                             <asp:Label ID="lblMROsuppliesUnitPrice" runat="server" Text="" Width="98%" ></asp:Label>
                                                        
                                                            <asp:TextBox ID="txtMROsuppliesUnitPrice" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible="false"></asp:TextBox>
                                                        </td>
                                                            <td style="width: 15%" class="column_RightBold">Reorder Pt. :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblMROsuppliesReorderPt" runat="server" Text="" Width="98%" ></asp:Label>
                                                            
                                                             <asp:TextBox ID="txtMROsuppliesReorderPt" runat="server" Width="40%" CssClass="txtbox_Amt" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        
                                                           </td>

                                                        <td style ="display:none;" class="column_RightBold">Dep. Rate :</td>
                                                        <td style ="display:none;" class="column_Left">
                                                             <asp:Label ID="lblMROsuppliesDeprate" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtMROsuppliesDeprate" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True"  Visible="false"></asp:TextBox>
                                                        </td>
                                                       
                                                    </tr>
                                                    <tr>
                                                       <td style="width: 15%" class="column_RightBold">Quantity :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                               <asp:Label ID="lblMROsuppliesQuantity" runat="server" Text="" Width="98%" ></asp:Label>
                                                          
                                                            <asp:TextBox ID="txtMROsuppliesQuantity" runat="server" Width="50%" CssClass="txtboxinspection" ReadOnly="True"  Visible="false"  AutoPostBack ="true" OnTextChanged="txtMROsuppliesQuantity_TextChanged" ></asp:TextBox>
                                                           
                                                        </td>
                                                        <td style ="display:none;" class="column_RightBold">Dep. Value :</td>
                                                        <td  style ="display:none;" class="column_Left">
                                                               <asp:Label ID="lblMROsuppliesDepValue" runat="server" Text="" Width="98%" ></asp:Label>
                                                          
                                                            <asp:TextBox ID="txtMROsuppliesDepValue" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True" Visible="false"></asp:TextBox>
                                                        </td>
                                                        <td style ="display:none;" <%--style="width: 15%" class="column_RightBold"--%>>Expiry Date :</td>
                                                        <td style ="display:none;"<%-- style="width: 35%" class="column_Left"--%>>
                                                            <asp:TextBox ID="TextBox14" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                    </tr>
                                                    <tr style ="display:none;">
                                                        <td style="width: 15%" class="column_RightBold"></td>
                                                        <td style="width: 35%" class="column_Left"></td>
                                                        <td style="width: 15%" class="column_RightBold">Alert :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:TextBox ID="TextBox15" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True"></asp:TextBox>
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
                                                                             <asp:DropDownList ID="drpMROsuppliesWarehouse" runat="server" Width="90%" AutoPostBack="True" CssClass="drpdownCSS" Enabled =" false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Bay :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtMROsuppliesBay" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList2" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible ="false" ></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Column :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                 <asp:TextBox ID="txtMROsuppliesColumn" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList3" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Floor :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                <asp:TextBox ID="txtMROsuppliesFloor" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList4" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                     <tr>
                                                                         <td class="column_RightBold">Room :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtMROsuppliesRoom" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList5" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Shelves :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtMROsuppliesShelves" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList6" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Rack :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtMROsuppliesRack" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList7" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                         
                                                                         <td class="column_RightBold">Bin :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtMROsuppliesBin" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True" ></asp:TextBox>
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
                                                <br />
                                                 <asp:Button ID="btnUploadMROSupplies"  runat="server" Width="120px" CssClass="CSButton" Text="Upload" OnClientClick="StartProgressBar();" Enabled="false"></asp:Button>
                                               
                                            </td>
                                        </tr>
                                         <tr>
                                                                        <td colspan ="2" style="text-align:right;">
                                                                              <asp:Button ID="Button1" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();" OnClick="btnSave_Click" Visible =" false"></asp:Button>
                                                                           &nbsp; &nbsp; &nbsp;
                                                                             <asp:Button ID="Button2"  runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();" Visible =" false"></asp:Button>
                                          
                                                                        </td>
                                                                    </tr>
                                        <tr>
                                            <td colspan =" 2" style="width: 70%;display:none;" align="right">
                                                <asp:Button ID="btnEditMROSupplies"  OnClick="btnEditMROSupplies_Click" runat="server" Width="120px" CssClass="CSButton" Text="EDIT" OnClientClick="StartProgressBar();" Enabled="false" ></asp:Button>
                                                <%--&nbsp;<asp:Button ID="btnUpdateDetails2" OnClick="btnUpdateDetails2_Click" runat="server" Width="120px" CssClass="CSButton" Text="UPDATE" OnClientClick="StartProgressBar();"></asp:Button>--%>
                                                &nbsp;<asp:Button ID="btnCancelMROSupplies" OnClick="btnCancelMROSupplies_Click" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();" Enabled="false"></asp:Button></td>
                                            <td style="width: 30%">

                                            </td>
                                        </tr>
                                    </table>

                                    <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtMDate" Enabled="True" PopupButtonID="txtMDate"></cc1:CalendarExtender>--%>
                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtEDate" Enabled="True" PopupButtonID="txtEDate"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtAlert" Enabled="True" PopupButtonID="txtAlert"></cc1:CalendarExtender>
                                    <asp:Label ID="Label1" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="Label5" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="Label6" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label>


                                </asp:View>

                                <asp:View ID="View4" runat="server">
                                     <table width="100%">
                                        <tr>
                                            <td style="width: 70%" align="center">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Name :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                             <asp:Label ID="lblFoodName" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtFoodName" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>

                                                         <td  class="column_RightBold" style="width:100px;">Unit :</td>
                                                        <td style="width:200px;" class="column_Left">
                                                            <asp:Label ID="lblFoodUnit" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtFoodUnit" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        
                                                        <td style="width: 15%" class="column_RightBold">Brand Name :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                               <asp:Label ID="lblFoodBrandName" runat="server" Text="" Width="98%" ></asp:Label>
                                                       
                                                            <asp:TextBox ID="txtFoodBrandName" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>
                                                        <td colspan ="2" rowspan="5">
                                                            <fieldset>
                                                                            <legend  class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Mftg Info:</strong></legend>
                                                          <table>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Batch :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                    <asp:Label ID="lblFoodBatch" runat="server" Text="" Width="98%" ></asp:Label>
                                                                    <asp:TextBox ID="txtFoodBatch" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                     <td style="width: 15%" class="column_RightBold">Lot :</td>
                                                         <td style="width: 35%" class="column_Left">
                                                               <asp:Label ID="lblFoodLot" runat="server" Text="" Width="98%" ></asp:Label>
                                                       
                                                            <asp:TextBox ID="txtFoodLot" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                     <td style="width: 15%" class="column_RightBold">Mftg. Date :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                               <asp:Label ID="lblFoodMdate" runat="server" Text="" Width="50%"  ></asp:Label>
                                                       
                                                            <asp:TextBox ID="txtFoodMdate" runat="server" Width="50%" CssClass="txtboxinspection" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Expiry Date :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                               <asp:Label ID="lblFoodEdate" runat="server" Text="" Width="50%"  ></asp:Label>
                                                       
                                                            <asp:TextBox ID="txtFoodEdate" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    
                                                        <td style="width: 15%;color:red" class="column_RightBold">Alert :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                               <asp:Label ID="lblFoodAlert" runat="server" Text="" Width="50%"  ></asp:Label>
                                                       
                                                            <asp:TextBox ID="txtFoodAlert" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                                </tr>
                                                            </table>
                                                            </fieldset>
                                                       
                                                            <td>
                                                       
                                                    </tr>
                                                    <tr style="display:none">
                                                        <td style="width: 15%" class="column_RightBold">Dose :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                               <asp:Label ID="lblFoodDose" runat="server" Text="" Width="98%" ></asp:Label>
                                                       
                                                            <asp:TextBox ID="txtFoodDose" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Batch :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                               <asp:Label ID="lblFoodBatch1" runat="server" Text="" Width="98%" ></asp:Label>
                                                       
                                                            <asp:TextBox ID="txtFoodBatch1" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                       <%-- <td style="width: 15%" class="column_RightBold">Supplier :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Supplier" CssClass="LinkBtnSelect"></asp:LinkButton>
                                                        </td>--%>
                                                       <td style="width: 15%" class="column_RightBold">Form :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                              <asp:Label ID="lblFoodForm" runat="server" Text="" Width="98%" ></asp:Label>
                                                       
                                                            <asp:TextBox ID="txtFoodForm" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>
                                                       
                                                    </tr>
                                                    <tr>
                                                         <td style="width: 15%" class="column_RightBold">Unit Cost:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                               <asp:Label ID="lblFoodUnitprice" runat="server" Text="" Width="98%" ></asp:Label>
                                                       
                                                            <asp:TextBox ID="txtFoodUnitprice" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>
                                                       
                                                        
                                                    </tr>
                                                    <tr>
                                                         <td style="width: 15%;display:none" class="column_RightBold">Dep. Rate :</td>
                                                        <td style="width: 35%;display:none" class="column_Left">
                                                               <asp:Label ID="lblFoodDepRate" runat="server" Text="" Width="98%" ></asp:Label>
                                                       
                                                            <asp:TextBox ID="txtFoodDepRate" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>
                                                        
                                                        <td style="width: 15%" class="column_RightBold">Quantity :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                               <asp:Label ID="lblFoodQuantity" runat="server" Text="" Width="98%" ></asp:Label>
                                                       
                                                            <asp:TextBox ID="txtFoodQuantity" runat="server" Width="50%" CssClass="txtboxinspection" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                           
                                                        </td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Reorder Pt. :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                              <asp:Label ID="lblFoodReOrderPt" runat="server" Text="" Width="98%" ></asp:Label>
                                                       
                                                            <asp:TextBox ID="txtFoodReOrderPt" runat="server" Width="50%" CssClass="txtboxinspection" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        
                                                           </td>
                                                       <td style="width: 15%;display:none" class="column_RightBold">Dep. Value :</td>
                                                        <td style="width: 35%;display:none" class="column_Left">
                                                               <asp:Label ID="lblFoodDepValue" runat="server" Text="" Width="98%" ></asp:Label>
                                                       
                                                            <asp:TextBox ID="txtFoodDepValue" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td></td>

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
                                                                             <asp:DropDownList ID="drpFoodWarehouse" runat="server" Width="90%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Bay :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtFoodBay" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList1" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Column :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                 <asp:TextBox ID="txtFoodColumn" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList9" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Floor :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                <asp:TextBox ID="txtFoodFloor" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList10" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                     <tr>
                                                                         <td class="column_RightBold">Room :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtFoodRoom" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList11" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Shelves :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtFoodShelves" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList12" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Rack :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtFoodRack" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList13" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                         
                                                                         <td class="column_RightBold">Bin :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtFoodBin" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             <asp:DropDownList ID="DropDownList14" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
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
                                                                            <%--  <asp:Button ID="btnFoodSave" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();" OnClick="btnFoodSave_Click"></asp:Button>
                                                                           &nbsp; &nbsp; &nbsp;
                                                                             <asp:Button ID="btnFoodCancel"  runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();"></asp:Button>
                                          --%>
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

                                    <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtFoodMdate" Enabled="True" PopupButtonID="txtMDateConsOthers"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtFoodEdate" Enabled="True" PopupButtonID="txtEDateConsOthers"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txtFoodAlert" Enabled="True" PopupButtonID="txtAlertConsOthers"></cc1:CalendarExtender>
                                    <asp:Label ID="Label7" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="Label8" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="Label9" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label>

                                </asp:View>
                                <asp:View ID="View5" runat="server">
                                     <table width="100%">
                                        <tr>
                                            <td style="width: 70%" align="center">
                                                <table width="100%">
                                                    <tr>
                                                        <td  class="column_RightBold" style="width:120px;" valign="top">Generic Name :</td>
                                                        <td style="width:200px;" class="column_Left" valign="top">
                                                            <asp:Label ID="lblMedicineName" runat="server" Text="" Width="98%"  Visible =" false"></asp:Label>
                                                            <asp:Label ID="lblGenericName" runat="server" Text="" Width="98%"  ></asp:Label>
                                                            <asp:TextBox ID="txtMedicineName" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                        
                                                        <td  class="column_RightBold" style="width:100px;" valign="top">Unit :</td>
                                                        <td style="width:200px;" class="column_Left" valign="top">
                                                            <asp:Label ID="lblunit" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtunit" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                        <td style="width:300px;" rowspan="7" valign="top">
                                                            <fieldset>
                                                       <legend  class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Mftg. Info:</strong></legend>
                                                                <table>
                                                                  <tr>
                                                                       <td class="column_RightBold">Batch :</td>
                                                                        <td class="column_Left">
                                                                            <asp:Label ID="lblMedicineBatch1" runat="server" Text="" Width="98%" ></asp:Label>
                                                                            <asp:TextBox ID="txtMedicineBatch1" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                                        </td>
                                                                  </tr>
                                                                  <tr>
                                                                        <td class="column_RightBold">Lot :</td>
                                                                        <td  class="column_Left">
                                                                            <asp:Label ID="lblMedicineLot" runat="server" Text="" Width="98%" ></asp:Label>
                                                                            <asp:TextBox ID="txtMedicineLot" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                                        </td>
                                                                  </tr>
                                                                  <tr>
                                                                       <td  class="column_RightBold">Mftg. Date :</td>
                                                                        <td  class="column_Left">
                                                                            <asp:Label ID="lblMedicineMdate" runat="server" Text="" Width="50%"   ></asp:Label>
                                                                            <asp:TextBox ID="txtMedicineMdate" runat="server" Width="50%" CssClass="txtboxinspection" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                                     <%--       &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>--%>
                                                                        </td>
                                                                  </tr>
                                                                  <tr>
                                                                       <td class="column_RightBold">Expiry Date :</td>
                                                                        <td  class="column_Left">
                                                                            <asp:Label ID="lblMedicineEdate" runat="server" Text="" Width="50%"  ></asp:Label>
                                                                            <asp:TextBox ID="txtMedicineEdate" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                                            <%--&nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>--%>
                                                                        </td>
                                                                  </tr>
                                                                  <tr>
                                                                    <td style="color:red;" class="column_RightBold">Alert :</td>
                                                                    <td class="column_Left">
                                                                        <asp:Label ID="lblMedicineAlert" runat="server" Text="" Width="50%"  ></asp:Label>
                                                                        <asp:TextBox ID="txtMedicineAlert" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                                        &nbsp;<%--<span class="CalendarFormat">(MM/DD/YYYY)</span>--%></td>
                                                                  </tr>
                                                              </table>
                                         
                                                            </fieldset>
                                                          
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td  class="column_RightBold" valign="top">Brand Name :</td>
                                                        <td  class="column_Left" valign="top">
                                                            <asp:Label ID="lblMedicineBrandName" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtMedicineBrandName" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                        
                                                        <td class="column_RightBold" valign="top">Form :</td>
                                                        <td class="column_Left" valign="top">
                                                            <asp:Label ID="lblMedicineForm" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtMedicineForm" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" valign="top">Dosage :</td>
                                                        <td  class="column_Left">
                                                            <asp:Label ID="lblMedicineDose" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtMedicineDose" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                        
                                                        <td  class="column_RightBold" valign="top">OTC / RX :</td>
                                                        <td class="column_Left" valign="top">
                                                            <asp:Label ID="lblMedicineOTXRX" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtMedicineOTXRX" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                       <%-- <td style="width: 15%" class="column_RightBold">Supplier :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Supplier" CssClass="LinkBtnSelect"></asp:LinkButton>
                                                        </td>--%>
                                                           <td  class="column_RightBold" valign="top">Unit Cost:</td>
                                                        <td  class="column_Left" valign="top">
                                                            <asp:Label ID="lblMedicineUnitprice" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtMedicineUnitprice" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                        
                                                        <td class="column_RightBold" valign="top">BFAD No. :</td>
                                                        <td class="column_Left">
                                                            <asp:Label ID="lblBfadNo" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtBfadNo" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                           <td class="column_RightBold" valign="top">Selling Price:</td>
                                                        <td class="column_Left">
                                                            <asp:Label ID="lblSellingPrice" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtSellingPrice" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                      <td class="column_RightBold" valign="top">Item Code :</td>
                                                        <td class="column_Left">
                                                            <asp:Label ID="lblItemCode" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtItemCode" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                      
                                                        
                                                    </tr>
                                                    <tr>
                                                        
                                                        <td  class="column_RightBold" valign="top">Qty Balance :</td>
                                                        <td class="column_Left" valign="top">
                                                            <asp:Label ID="lblMedicineQuantity" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtMedicineQuantity" runat="server" Width="50%" CssClass="txtboxinspection" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                           
                                                        </td>
                                                       <td  class="column_RightBold" valign="top">Reorder Pt. :</td>
                                                        <td class="column_Left" valign="top">
                                                            <asp:Label ID="lblReorderPt" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtReorderPt" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                         <td style="width: 15%;display:none;" class="column_RightBold">Dep. Rate :</td>
                                                        <td style="width: 35%;display:none;" class="column_Left">
                                                            <asp:Label ID="lblMedicineDepRate" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtMedicineDepRate" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                      
                                                       <td style="width: 15%;display:none;" class="column_RightBold">Dep. Value :</td>
                                                        <td style="width: 35%;display:none;" class="column_Left">
                                                            <asp:Label ID="lblMedicineDepValue" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtMedicineDepValue" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                       
                                                     

                                                       
                                                    </tr>
                                                                         <tr>
                                                        <td colspan ="5" align="center" >
                                                            <fieldset id="fsPricePerQuantity" runat="server" style="width:50%;">
                                                                <legend class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Price per Quantity:</strong></legend>
                                                                    <table style="width: 300px">
                                                                        <tr>
                                                                            <td  align="center">
                                                                              <td style="width: 98%" align="center">
							<asp:GridView ID="GridPPQ" runat="server" Visible="true" Width="98%" SkinID="GridViewAA" 
								AllowPaging="True" PageSize="5" datakeynames="PPQ_ID,Item_id,QtyPack,Unit_cost,PPQ_Percent,Selling_Price" >
								<Columns>
                                    
                                     <%-- <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="false" CssClass="LinkBtnSelect" CommandName="Select" Text="Select">
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                       
                                    </asp:TemplateField>--%>
                                  
									<asp:BoundField DataField="QtyPack"  HeaderText="Qty./Pack">
										<ItemStyle HorizontalAlign="center"></ItemStyle>
									</asp:BoundField>
									<asp:BoundField DataField="Unit_cost" HeaderText="Unit Cost" Visible ="true">
										<ItemStyle HorizontalAlign="right"></ItemStyle>
									</asp:BoundField>
									<asp:BoundField DataField="PPQ_Percent" HeaderText="Percent" Visible ="true">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundField>
									<asp:BoundField DataField="Selling_price" HeaderText="Selling Price">
										<ItemStyle HorizontalAlign="right"></ItemStyle>
									</asp:BoundField>
								   
								</Columns>
							</asp:GridView>
						</td>
                                                                            </td>
                                                                            
                                                                            </tr>
                                                                        </table>
                                                            </fieldset>
                                                        </td>
                                                    </tr>
                         
                                                     <tr>
                                                        <td colspan="5">
                                                             <fieldset>
                                                                 <legend  class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Location:</strong></legend>
                                                                 <table width="100%">
                                                                     <tr>
                                                                         <td class="column_RightBold">Warehouse :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:DropDownList ID="drpMedicineWarehouse" runat="server" Width="90%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Bay :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtMedicineBay" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList15" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Column :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                 <asp:TextBox ID="txtMedicineColumn" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList16" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Floor :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                <asp:TextBox ID="txtMedicineFloor" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList17" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                     <tr>
                                                                         <td class="column_RightBold">Room :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtMedicineRoom" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList18" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Shelves :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtMedicineShelves" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList19" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Rack :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtMedicineRack" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList20" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                         
                                                                         <td class="column_RightBold">Bin :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtMedicineBin" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             <asp:DropDownList ID="DropDownList21" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                    
                                                                 </table>
                                                             </fieldset>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                       
                                            <td style="width: 30%;text-align:center" valign="top">
                                                <img alt="" height="160" src="../images/Default_Image.jpg" width="80%" />
                                            </td>
                                        </tr>
                                          <tr>
                                                                        <td colspan ="2" style="text-align:right;">
<%--                                                                              <asp:Button ID="btnMedicineSave" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();" OnClick="btnMedicineSave_Click"></asp:Button>--%>
                                                                           &nbsp; &nbsp; &nbsp;
                                                                             <asp:Button ID="btnFoodCancel"  runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();" Visible =" false"></asp:Button>
                                          
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

                                    <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txtMedicineMdate" Enabled="True" PopupButtonID="txtMDateConsOthers"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtMedicineEdate" Enabled="True" PopupButtonID="txtEDateConsOthers"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txtMedicineAlert" Enabled="True" PopupButtonID="txtAlertConsOthers"></cc1:CalendarExtender>
                                    <asp:Label ID="Label10" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="Label11" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="Label12" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label>

                                </asp:View>

                                <asp:View ID="View6" runat="server">
                                     <table width="100%">
                                        <tr>
                                            <td style="width: 70%" align="center">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Name:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                             <asp:Label ID="lblConsOthersName" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtConsOthersName" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                       <td style="width: 15%" class="column_RightBold">Unit :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblConsOthersUnit" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtConsOthersUnit" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 15%" class="column_RightBold">Brand Name :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblConsOthersBrandName" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtConsOthersBrandName" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                         <td colspan ="2" rowspan ="5" style ="padding-left:50px; vertical-align:top;">
                                                               <fieldset>
                                                                   <legend  class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Mftg Info:</strong></legend>
                                                                      <table>
                                                                        <tr>
                                                                            <td style="width: 15%" class="column_RightBold">Batch :</td>
                                                                            <td style="width: 35%" class="column_Left">
                                                                                <asp:Label ID="lblConsOthersBatch" runat="server" Text="" Width="98%" ></asp:Label>
                                                                                <asp:TextBox ID="txtConsOthersBatch" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                          <tr>
                                                                            <td style="width: 15%" class="column_RightBold">Lot :</td>
                                                                              <td style="width: 35%" class="column_Left">
                                                                                <asp:Label ID="lblConsOthersLot" runat="server" Text="" Width="98%" ></asp:Label>
                                                                                <asp:TextBox ID="txtConsOthersLot" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                                            </td>
                                                                          </tr>
                                                                          <tr>
                                                                              
                                                        <td style="width: 15%" class="column_RightBold">Expiry Date :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblEDateConsOthers" runat="server" Text="" Width="50%" ></asp:Label>
                                                            <asp:TextBox ID="txtEDateConsOthers" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                                          </tr>
                                                                          <tr>
 <td style="width: 15%" class="column_RightBold">Mftg. Date :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblMDateConsOthers" runat="server" Text="" Width="50%" ></asp:Label>
                                                            <asp:TextBox ID="txtMDateConsOthers" runat="server" Width="50%" CssClass="txtboxinspection" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                                          </tr>
                                                                          <tr>
                                                                               <td style="width: 15%;color:red;" class="column_RightBold">Alert :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblAlertConsOthers" runat="server" Text="" Width="50%" ></asp:Label>
                                                            <asp:TextBox ID="txtAlertConsOthers" runat="server" Width="50%" CssClass="txtbox_Date" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                        </td>
                                                                          </tr>
                                                                      </table>
                                                               </fieldset>
                                                          </td>
                                                    </tr>
                                                    <tr style="display:none;">
                                                        <td style="width: 15%" class="column_RightBold">Dose :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblConsOthersDose" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtConsOthersDose" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15%" class="column_RightBold">Batch :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                           <asp:Label ID="lblConsOthersBatch1" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtConsOthersBatch1" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                       <%-- <td style="width: 15%" class="column_RightBold">Supplier :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Supplier" CssClass="LinkBtnSelect"></asp:LinkButton>
                                                        </td>--%> 
                                                         <td style="width: 15%" class="column_RightBold">Form :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblConsOthersForm" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtConsOthersForm" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                        
                                                    </tr>
                                                    <tr>
                                                       
                                                        
                                                         <td style="width: 15%" class="column_RightBold">Unit Cost:</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblConsOthersUnitPrice" runat="server" Text="" Width="98%" ></asp:Label>
                                                            <asp:TextBox ID="txtConsOthersUnitPrice" runat="server" Width="98%" CssClass="txtbox_Var" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                       
                                                       
                                                    </tr>
                                                    <tr>
                                                         <td style="width: 15%;display:none;" class="column_RightBold">Dep. Rate :</td>
                                                        <td style="width: 35%;display:none;" class="column_Left">
                                                           <asp:Label ID="lblConsOthersDepRate" runat="server" Text="" Width="50%" ></asp:Label>
                                                            <asp:TextBox ID="txtConsOthersDepRate" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                        </td>
                                                        
                                                         <td style="width: 15%" class="column_RightBold">Quantity :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblConsOthersQuantity" runat="server" Text="" Width="50%" ></asp:Label>
                                                            <asp:TextBox ID="txtConsOthersQuantity" runat="server" Width="50%" CssClass="txtboxinspection" ReadOnly="True" Visible ="false"></asp:TextBox>
                                                           
                                                        </td>
                                                        
                                                       
                                                    </tr>
                                                    <tr>
                                                            <td style="width: 15%" class="column_RightBold">Reorder Pt. :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                            <asp:Label ID="lblConsOthersReorderPoint" runat="server" Text="" Width="98%" ></asp:Label>
                                                            
                                                             <asp:TextBox ID="txtConsOthersReorderPoint" runat="server" Width="40%" CssClass="txtbox_Amt" ReadOnly="True"  Visible ="false"></asp:TextBox>
                                                        
                                                           </td>
                                                       <td style="width: 15%;display:none;" class="column_RightBold">Dep. Value :</td>
                                                        <td style="width: 35%;display:none;" class="column_Left">
                                                            <asp:Label ID="lblConsOthersDepValue" runat="server" Text="" Width="50%" ></asp:Label>
                                                            <asp:TextBox ID="txtConsOthersDepValue" runat="server" Width="50%" CssClass="txtbox_Amt" ReadOnly="True" Visible ="false"></asp:TextBox>
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
                                                                          
                                                                             <asp:DropDownList ID="DropDownList22" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Column :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                 <asp:TextBox ID="txtConsOthersColumn" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList23" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Floor :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                                <asp:TextBox ID="txtConsOthersFloor" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                          
                                                                             <asp:DropDownList ID="DropDownList24" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                     </tr>
                                                                     <tr>
                                                                         <td class="column_RightBold">Room :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtConsOthersRoom" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList25" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold" style="width:10%">Shelves :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtConsOthersShelves" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList26" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>

                                                                         <td class="column_RightBold">Rack :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                              <asp:TextBox ID="txtConsOthersRack" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             
                                                                             <asp:DropDownList ID="DropDownList27" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
                                                                         </td>
                                                                         
                                                                         <td class="column_RightBold">Bin :
                                                                         </td>
                                                                         <td  class="column_Left">
                                                                             <asp:TextBox ID="txtConsOthersBin" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
                                                                             <asp:DropDownList ID="DropDownList28" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
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
                                                 <asp:Button ID="btnConsOthersUpload"  runat="server" Width="120px" CssClass="CSButton" Text="Upload" OnClientClick="StartProgressBar();"  Enabled ="false"></asp:Button>
                                              
                                            </td>
                                        </tr>
                                          <tr>
                                                                        <td colspan ="2" style="text-align:right;">
                                                                             
                                                                            <asp:Button ID="btnConsOthersEdit" runat="server" Width="120px" CssClass="CSButton" Text="EDIT" OnClientClick="StartProgressBar();" Enabled ="false" OnClick="btnConsOthersEdit_Click" Visible =" false"></asp:Button>
                                                                           &nbsp; &nbsp; &nbsp;
                                                                             <asp:Button ID="btnConsOthersCancel"  runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();" Enabled ="false" OnClick="btnConsOthersCancel_Click" Visible =" false"></asp:Button>
                                          
                                                        
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

                                    <cc1:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txtMDateConsOthers" Enabled="True" PopupButtonID="txtMDateConsOthers"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="txtEDateConsOthers" Enabled="True" PopupButtonID="txtEDateConsOthers"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="txtAlertConsOthers" Enabled="True" PopupButtonID="txtAlertConsOthers"></cc1:CalendarExtender>
                                    <asp:Label ID="Label13" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="Label14" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label><asp:Label ID="Label15" runat="server" SkinID="LabelBorder" Visible="False" BorderWidth="1px" BorderStyle="Solid"></asp:Label>

                                </asp:View>
                                 <asp:View ID="View7" runat="server">
                                     <table>
                                         <tr>
                                             <td>
                                                    <table style="width: 100%;">
                                <tr>
                                    <td class="column_RightBold" style="width: 10%" valign="top">Name :

                                    </td>
                                    <td class="column_Left" style="width: 30%">

                                        <asp:Label ID="lblequipmentname" runat="server" Width="290px" SkinID="Label" Font-Italic="False" ></asp:Label>
                                        <asp:DropDownList ID="drpMROEquipmentName" AutoPostBack ="true" runat="server" Width="91%" Visible="false" ></asp:DropDownList>
                                                          
                                        <asp:TextBox ID="txtMROEquipmentName" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>

                                    <td class="column_RightBold" style="width: 10%">Unit :

                                    </td>
                                    <td class="column_Left" style="width: 30%">

                                        <asp:Label ID="lblMROEquipmentUnit" runat="server" Width="290px" SkinID="Label" Font-Italic="False" ></asp:Label>
                                        <asp:DropDownList ID="drpMROEquipmentUnit" AutoPostBack ="true" runat="server" Width="91%" Visible="false"></asp:DropDownList>
                                                          
                                        <asp:TextBox ID="TextBox4" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>
                                  
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%"  valign="top">Description :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentdesciption" runat="server" Width="290px" SkinID="Label" Font-Italic="False" ></asp:Label>
                                        <asp:TextBox ID="txtequipmentdesciption" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Visible="false"></asp:TextBox>

                                    </td>
                                    <td class="column_RightBold" style="width: 10%">Dimension :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentdimension" runat="server" Width="290px" SkinID="Label" Font-Italic="False" ></asp:Label>
                                        <asp:TextBox ID="txtequipmentdimension" runat="server" Width="89%" AutoPostBack="True" CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">Power Input :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentpowerinput" runat="server" Width="290px" SkinID="Label" Font-Italic="False" ></asp:Label>
                                        <asp:TextBox ID="txtequipmentpowerinput" runat="server" Width="89%"  CssClass="txtbox_Var" Visible="false"></asp:TextBox>

                                    </td>
                                    <td class="column_RightBold" style="width: 10%">Area Capacity :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentareacapacity" runat="server" Width="290px" SkinID="Label" Font-Italic="False" ></asp:Label>
                                        <asp:TextBox ID="txtequipmentareacapacity" runat="server" Width="89%"  CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                     <td class="column_RightBold" style="width: 10%">Model :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentmodel" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtequipmentmodel" runat="server" Width="89%"  CssClass="txtbox_Var" Visible="false"></asp:TextBox>

                                    </td>
                                    <td class="column_RightBold" style="width: 10%">Warranty :
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Label ID="lblequipmentwaranty" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtequipmentwaranty" runat="server" Width="89%"  CssClass="txtbox_Var" Visible="false"></asp:TextBox>

                                    </td>
                                   
                                </tr>
<tr>
                                     <td style="width: 15%" class="column_RightBold">Reorder Pt. :</td>
                                                        <td style="width: 35%" class="column_Left">
                                                             <asp:Label ID="lblequipmentReOrderPt" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                                     <asp:TextBox ID="txtequipmentReOrderPt" runat="server" Width="89%"  CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                                        
                                                           </td>
                               </tr>
                               
                                <tr>
                                    <td colspan ="4">
                                        <fieldset style="width:90%;">
                                            <legend class="column_LeftBold">Acquisition :</legend>
                                        <table >
 <tr>
                                     <td  class="column_RightBold">Acquisition Date :
                                    </td>
                                    <td class="column_Left" style="width:100px;">
                                        <asp:Label ID="lblEAcqDate" runat="server" ></asp:Label>
                                        <asp:TextBox ID="txtEAcqDate" runat="server"   CssClass="txtbox_Var" Visible="false" ></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender15" runat="server" TargetControlID="txtEAcqDate" PopupButtonID="txtEAcqDate"></cc1:CalendarExtender>


                                        &nbsp;(MM/DD/YYYY)</td>
                                   <td class="column_RightBold" >Market Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblEMarketValue" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtEMarketValue" runat="server"  CssClass="txtbox_Var" Visible="false"></asp:TextBox>

                                    </td>
                                    
                                    
                                </tr>
                                <tr>
                                    
                                    <td class="column_RightBold" >Acquisition Cost :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblEAcqCost" runat="server" ></asp:Label>
                                        <asp:TextBox ID="txtEAcqCost" runat="server"  CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>
                                    
                                    <td class="column_RightBold" >No. of Years :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblNoYears" runat="server"  ></asp:Label>
                                        <asp:TextBox ID="txtNoYears" runat="server"  CssClass="txtbox_Var" Visible="false"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                     <td class="column_RightBold" >Quantity:
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblEquipmentQuantity" runat="server" ></asp:Label>
                                        <asp:TextBox ID="txtEquipmentQuantity" runat="server"  CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    </td>
                                    <td class="column_RightBold">Useful Life :
                                    </td>
                                    <td class="column_Left">
                                        <asp:Label ID="lblUsefulLife" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtUsefulLife" runat="server" Width="100px"  CssClass="txtbox_Var" Visible="false"></asp:TextBox>

                                        &nbsp;(Years)</td>

                                </tr>


                                <tr>
                                    
                                    <td class="column_RightBold">Dep. Rate :
                                    </td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="lblequipmentdepreciatedRate" runat="server" Width="100px"  CssClass="txtboxAmount" MaxLength="5" ReadOnly="True" ></asp:TextBox>&nbsp;(%) Percent</td>

                                    
                                    
                                   <td class="column_RightBold">Salvage Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:TextBox ID="txtSalvageValue" runat="server" Width="85%"   CssClass="txtboxAmount" >0.00</asp:TextBox>

                                         

                                    </td>


                                </tr>
                                <tr>
                                    
                                    <td class="column_RightBold" >Dep. Value :
                                    </td>
                                    <td class="column_Left" >
                                        <asp:Label ID="lblequipmentdepreciatedvalue" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label>
                                        <asp:TextBox ID="txtequipmentdepreciatedvalue" runat="server" Width="100px"  CssClass="txtbox_Var" Visible="false"></asp:TextBox>
                                    <table style="position:absolute; top:-999px; width:0px;">
                                                                           <tr>
                                                                               <td>
                                                                                   <asp:TextBox ID="TextBox5" runat="server" Width="0px" Readonly="true"></asp:TextBox>
                                                                        
                                                                               </td>
                                                                           </tr>
                                                                       </table>
                                    </td>
                                </tr>
                                        </table>
                                        </fieldse>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">Specifications :
                                    </td>
                                    <td class="column_Left" colspan="3">
                                        <asp:Label ID="lblSpecification" runat="server" CssClass="text3"></asp:Label>
                                        <asp:TextBox ID="txtSpecification" runat="server" Width="95%" Height="25px" TextMode="MultiLine"  CssClass="txtbox_Var" Rows="2" Visible="false"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                    <td class="column_RightBold" colspan="3"></td>
                                    <td>
                                     <%--   <asp:Button ID="btnEquipmentSave" runat="server" Width="48%" CssClass="CSButton" Text="SAVE" Enabled="false" OnClick="btnEquipmentSave_Click" OnClientClick="StartProgressBar();"></asp:Button>
                                        <asp:Button ID="btnEquipmentCancel" runat="server" Width="48%" CssClass="CSButton" Text="CANCEL" Enabled="false"></asp:Button>
                                   --%> </td>
                                </tr>
                            </table>
                                             </td>
                                              <td align="center" style="width: 20%" valign="middle" >
                                        <asp:Image ID="Image3" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" />
                                        <br />
                                               <asp:Button ID="btnupload" runat="server" Width="48%" CssClass="CSButton" Text="UPLOAD" Enabled="false"></asp:Button>
                                
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
                        <td style="height: 1%" class="DivTitle">
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 100%">
                                <tbody>
                                    <tr style="display:none;">
                                        <td style="width: 56%" class="column_CenterBold">
                                            <asp:Label ID="lblHistoryDetails" runat="server" Width="100%" Text="HISTORY DETAILS" CssClass="borderCSS"></asp:Label></td>
                                        <td style="width: 14%" class="column_CenterBold">
                                            <asp:Label ID="Label2" runat="server" Width="100%" Text="DEBIT"  CssClass="borderCSS"></asp:Label></td>
                                        <td style="width: 14%" class="column_CenterBold">                                             
                                            <asp:Label ID="Label3" runat="server" Width="100%" Text="CREDIT" CssClass="borderCSS"></asp:Label></td>
                                        <td style="width: 15%" class="column_CenterBold">                                             
                                            <asp:Label ID="Label4" runat="server" Width="100%" Text="BALANCE" CssClass="borderCSS"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 159px;" colspan="4">
                                            <asp:Panel ID="Panel2" runat="server" Width="100%" CssClass="PanelSize" ScrollBars="Vertical">
                                                <asp:GridView ID="grdLedger" runat="server" Width="100%"    SkinID="GridViewAA" OnDataBound = "OnDataBound">
                                                    <Columns>
                                                        <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Trans_Type" HeaderText="PARTICULARS" >
                                                            <HeaderStyle HorizontalAlign="Center" Height="30px" Width="40px"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="46%"></ItemStyle>
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

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="20%"></ItemStyle>
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
                            <asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW"></asp:Button>
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


            


            



            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
  

             <asp:Panel ID="popupNOTIF" runat="server"  CssClass="Panel_Popup" Width="300px" >
                  <table width="100%" >
                      <tr>
                         <td  class="rounded-corners" style="width: 100%;  height: 30px; background-color: red"  colspan="3" >
                             NOTIFICATION ALERT <asp:Image ID="Notif" runat="server" ImageUrl="~/images/POPUP/alert-notif.png" Width="20" />
                             
                         </tr>
                  
                      <tr>
                           <td   colspan="3" style="width: 100%; height: 30px; ">
                              You have reached the re-order point on selected items. Order now. </td>
                      
                          
                      </tr>
                       <tr>
                           <td class="center">

                               <asp:Button ID="BtnList" runat="server" CssClass="CSButton" Text="List of Items" Width="100px" OnClick="BtnList_Click" />
                               <asp:Button ID="BtnOK" runat="server" CssClass="CSButton" Text="CLOSE" Width="100px" />
                               
                                
                           </td>
                      </tr>
                  
                       <tr>
                        
                            <td style="width: 50%; height: 10px">
                                <asp:Label runat="server" ID="lblNotif"></asp:Label>
                            </td>
                        </tr>
                  </table>
                  
                  </asp:Panel>    
                         <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="lblNotif" PopupControlID="popupNOTIF"  CancelControlID="BtnOK" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>  


             <asp:Panel ID="lblPanelList" runat="server"  CssClass="Panel_Popup" Width="800px" >
                  <table width="100%" cellpadding="0px" cellspacing="0px" >
                      <tr>
                         <td  class="DivTitle" >
                                LIST OF ITEMS
                             
                         </tr>
                      <tr>
                          <td style="width: 100%" align="center">
                              <asp:Panel ID="Panel1" runat="server" Width="98%" CssClass="PanelSize_Popup" ScrollBars="Vertical">
                          <asp:GridView ID="grdItemROP" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames=""
                                AllowPaging="True" OnPageIndexChanging="grdItemROP_PageIndexChanging"  >
                                <Columns>
                                    <asp:BoundField DataField="Item_Code" HeaderText="Item Code">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="description" HeaderText="UNIT">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Item_Desc" HeaderText="ITEM DESCRIPTION">
                                        <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Balance" HeaderText="CURRENT BALANCE">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ReorderPt" HeaderText="REORDER PT">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                   
                                </Columns>
                            </asp:GridView>
                                   </asp:Panel>
                              </td>
                      
                  </tr>
                       <tr>
                           <td class="center">

                               
                               <asp:Button ID="btnListClose" runat="server" CssClass="CSButton" Text="CLOSE" Width="100px" />
                               
                                
                           </td>
                      </tr>
                  
                       <tr>
                        
                            <td style="width: 50%; height: 10px">
                                <asp:Label runat="server" ID="lblList"></asp:Label>
                            </td>
                        </tr>
                  </table>
                  
                  </asp:Panel>    
                         <cc1:ModalPopupExtender ID="ModalPopupExtender5" runat="server" TargetControlID="lblList" PopupControlID="lblPanelList"  CancelControlID="btnListClose" ></cc1:ModalPopupExtender> 
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

