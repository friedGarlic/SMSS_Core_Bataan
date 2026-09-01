<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="t_StockCard_v2_Medicines.aspx.vb" Inherits="Records_t_StockCard_v2_MRO" StylesheetTheme="SkinFile" Title="Encoding of Medicines"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">


</script>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	 <script type="text/javascript" src="../Membership/MasterPage/js/autoCurrency.js"></script>
	 
	<script type="text/javascript">
		  window.onbeforeunload = function (e) {
		 var e = e || window.event;
	  // For IE and FireFox
		 var value="There is some data to be saved!"
		 if (e) {
		 e.returnValue = value;
		 }

	  // For Safari
		 return value;
		 }

		$(document).ready(function () {
			$("btnMedicineAdd").click(function () {
				aler("Hello World");
			})
		})

		function correctQty(Integer) {
		var ROP = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtReOrderPt').value);
		var Qty = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtMedicineQuantity').value);
		if (Qty < ROP) {
			document.getElementById('ctl00_ContentPlaceHolder1_txtMedicineQuantity').value = ""
		   alert("Warning : Quantity should be higher that ROP")
		}
	}

	  

	</script>

    <script type="text/javascript">
    function validateMedicineAdd() {
        var qtyPack = document.getElementById('<%= txtQtyPack.ClientID %>').value.trim();
        var unitCost = document.getElementById('<%= txtUnitCost.ClientID %>').value.trim();
        var percent = document.getElementById('<%= txtpercent.ClientID %>').value.trim();
        var sellingPrice = document.getElementById('<%= txtSellingPrice1.ClientID %>').value.trim();

        if (qtyPack === "" || isNaN(qtyPack) || parseInt(qtyPack) < 0) {
            alert("Please enter a valid non-negative integer for Quantity Pack.");
            return false;
        }

        if (unitCost === "" || isNaN(unitCost) || parseFloat(unitCost) < 0) {
            alert("Please enter a valid non-negative number for Unit Cost.");
            return false;
        }

        if (percent === "" || isNaN(percent) || parseFloat(percent) < 0) {
            alert("Please enter a valid non-negative number for Percent.");
            return false;
        }

        if (sellingPrice === "" || isNaN(sellingPrice) || parseFloat(sellingPrice) < 0) {
            alert("Please enter a valid non-negative number for Selling Price.");
            return false;
        }

        return true; // Allow form submission
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
						<td style="width: 98%" class="PageTitle">Medicines</strong>
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
                                <table width="100%">
                                    <tr>
                                        <td class="column_RightBold" style="display:none; text-align: right; padding-right: 10px; vertical-align: middle;">
                                            <span>Classification :</span>
                                        </td>
                                        <td style="display:none; padding-right: 20px; vertical-align: middle;">
                                            <asp:DropDownList ID="ddClass" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddClass_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                        <td class="column_RightBold" style="width: 12%; text-align: right; padding-right: 10px; vertical-align: middle;">
                                            SubClassification:
                                        </td>
                                        <td style="width: 18%; padding-right: 20px; vertical-align: middle;">
                                            <asp:DropDownList ID="ddSubClass" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddSubClass_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                        <td class="column_RightBold" style="width: 12%; text-align: right; padding-right: 10px; vertical-align: middle;">
                                            General Account :
                                        </td>
                                        <td style="width: 18%; padding-right: 20px; vertical-align: middle;">
                                            <asp:DropDownList ID="ddGlAccount" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Enabled="false" OnSelectedIndexChanged="ddGlAccount_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                           <td class="column_RightBold" style="width: 10%; text-align: right; padding-right: 10px; vertical-align: middle;">
                                                <span>Category :</span>
                                            </td>
                                            <td style="width: 18%; vertical-align: middle;">
                                                <asp:DropDownList ID="ddCategory" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged"></asp:DropDownList>
                                            </td>
             
                                    </tr>

                                    <tr style="display:none">
                                        <td class="column_RightBold" style="width: 100%;">
                                            <span class="column_RightBold">Sub Category :</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddSubCategory" runat="server" AutoPostBack="True" Width="200px" CssClass="drpdownCSS" Enabled="false" OnSelectedIndexChanged="ddSubCategory_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td class="column_RightBold">
                                            <span>Description &nbsp; :</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSearchStock" runat="server" Width="100%" CssClass="txtbox_Var"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSearchStock" runat="server" Width="100%" CssClass="CSButton" Text="Search" OnClick="btnSearchStock_Click"></asp:Button>
                                        </td>
                                    </tr>
                                </table>

                                &nbsp;&nbsp;
                                &nbsp;

                                &nbsp;
                                &nbsp;
                            </td>
                            <td style="width: 1%"></td>
                        </tr>

					   <tr  style="display:none;">
						 <td style="width: 98%" class="DivTitle" colspan =" 2">LIST OF <asp:Label ID="lblClass1" runat="server" Text="Label"></asp:Label>
						</td>
					</tr>
						 <tr  style="display:none;">
						<td style="width: 1%"></td>
						<td style="width: 98%" align="center">
							<asp:GridView ID="grdStockList" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="Item_ID,GA_ID"
								AllowPaging="True" OnPageIndexChanging="grdStockList_PageIndexChanging"  OnRowDataBound="grdStockList_RowDataBound" OnSelectedIndexChanged="grdStockList_SelectedIndexChanged">
								<Columns>
									<asp:BoundField DataField="Item_ID" HeaderText="Item No.">
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:BoundField>
									<asp:BoundField DataField="Unit_ID" HeaderText="UNIT">
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
						<tr  style="display:none;">
						<td style="width: 1%"></td>
						<td style="width: 98%" class="DivTitle"><%--Batch--%> INCOMING DELIVERIES
						</td>
						<td style="width: 1%"></td>
					</tr>
					  <tr style="display:none;">
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
						<td style="width: 98%" class="DivTitle">INVENTORY CARD <asp:Label ID="lblcategory" runat="server" Text=" "></asp:Label>
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
											<td style=" width: 30%;text-align:center;" valign="top" >
												<table width="100%">
													<tr>
														<td class="column_RightBold" style="width:16%">Generic Name :</td>
														<td  class="column_Left" style="width:34%">
															<asp:DropDownList ID="drpGenericName" AutoPostBack ="true" runat="server" Width="98%" OnSelectedIndexChanged="drpGenericName_SelectedIndexChanged" ></asp:DropDownList>
															<asp:TextBox ID="txtMedicineName" runat="server" Width="90%"  CssClass="txtbox_Var" ReadOnly="True" Visible="false" ></asp:TextBox>
														</td>
														<td  class="column_RightBold" style="width:15%" >Unit :</td>
														<td class="column_Left" style="width:35%">
															<asp:TextBox ID="txtMedicineUnit" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True" Visible="false"></asp:TextBox>
															<asp:DropDownList ID="drpUnit" runat="server" Width="90%" Enabled ="true" Visible="True"></asp:DropDownList>
												   
														</td>
													  
													</tr>
													<tr>
														<td class="column_RightBold">Brand Name :</td>
														<td class="column_Left">
															<asp:TextBox ID="txtMedicineBrandName" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
														</td>
														<td class="column_RightBold">Form :</td>
														<td class="column_Left">
															<asp:TextBox ID="txtMedicineForm" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
														</td>
													</tr>
													<tr>
														<td class="column_RightBold">Dosage :</td>
														<td  class="column_Left">
															<asp:TextBox ID="txtMedicineDose" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
														</td>
														
														<td class="column_RightBold">OTC / RX :</td>
														<td class="column_Left">
															<asp:TextBox ID="txtMedicineOTXRX" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
														</td>
													</tr>
													<tr>
													   <%-- <td style="width: 15%" class="column_RightBold">Supplier :</td>
														<td style="width: 35%" class="column_Left">
															<asp:LinkButton ID="LinkButton1" runat="server" Text="Supplier" CssClass="LinkBtnSelect"></asp:LinkButton>
														</td>--%>

                                                            
														  <td class="column_RightBold">Unit Cost:</td>
														<td class="column_Left">
															<asp:TextBox ID="txtMedicineUnitprice" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox>
														</td>
														 <td class="column_RightBold">BFAD No. :</td>
														<td  class="column_Left">
															<asp:TextBox ID="txtBFADNo" runat="server" Width="90%" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox>
														   
														</td>
														
													   
													   
													</tr>
													<tr>
														 <td class="column_RightBold">Selling Price:</td>
														<td class="column_Left">
															<asp:TextBox ID="txtSellPrice" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"  Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" ></asp:TextBox>
														</td>
														<td class="column_RightBold">Item Code :</td>
														<td class="column_Left">
															<asp:TextBox ID="txtItemCode" runat="server" Width="90%" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox>
														   
														</td>
													   
													   
													   
													</tr>
													<tr>
														  <td class="column_RightBold">Reorder Pt. :</td>
														<td  class="column_Left">
															<asp:TextBox ID="txtReOrderPt" runat="server" CssClass="txtboxinspection" ReadOnly="True" Width="70%"></asp:TextBox>
															<asp:Button ID="btnROP" runat="server" cssClass="CSButton" OnClick="btnROP_Click" Text="R.O.P" Width="40" />
														   
														</td>
														   <td  class="column_RightBold">Qty Balance :</td>
														<td class="column_Left">
															<asp:TextBox ID="txtMedicineQuantity" runat="server" CssClass="txtboxinspection"  ReadOnly="True" Width="90%"></asp:TextBox>
														   
														</td>
														
														
														 
														<td style="width: 15%;display:none" class="column_RightBold">Dep. Rate :</td>
														<td style="width: 35%;display:none" class="column_Left">
															<asp:TextBox ID="txtMedicineDepRate" runat="server" Width="90%" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox>
														</td>
													</tr>
													<tr>
													   
														
														
													   <td  class="column_RightBold">Date :</td>
														<td  class="column_Left"><asp:TextBox ID="txtSellectDate" runat="server" CssClass="txtbox_Var"></asp:TextBox>
															 <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSellectDate" Enabled="True" PopupButtonID="txtSellectDate"></cc1:CalendarExtender>
														</td>
														 
													   <td style="display:none;">Dep. Value :</td>
														<td style="display:none;">
															<asp:TextBox ID="txtMedicineDepValue" runat="server" CssClass="txtbox_Amt" ReadOnly="True" Width="90%"></asp:TextBox>
														</td>
													</tr>
												  
													 </table>
											</td>
											<td style=" width: 30%;text-align:center;" valign="top"> 
															<fieldset>
																 <legend  class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Mftg Info:</strong></legend>
															<table style="width:100%">
																<tr>
																		<td  class="column_RightBold">Batch :</td>
																		<td  class="column_Left">
																			<asp:TextBox ID="txtMedicineBatch1" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
																		</td>
																</tr>
																<tr>
																	<td  class="column_RightBold">Lot :</td>
																	<td  class="column_Left">
																		<asp:TextBox ID="txtMedicineLot" runat="server" Width="90%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
																	</td>
																</tr>
																<tr>
																	<td class="column_RightBold" style="width:33%;">Mftg. Date :</td>
																	<td class="column_Left">
																		<asp:TextBox ID="txtMedicineMdate" runat="server" Width="90%" CssClass="txtbox_Date"></asp:TextBox>
																		<%--&nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>--%></td>
																</tr>
																<tr>
																	<td  class="column_RightBold" style="width:35%;">Expiry Date :</td>
																	<td class="column_Left">
																		<asp:TextBox ID="txtMedicineEdate" runat="server" Width="90%" CssClass="txtbox_Date" ></asp:TextBox>
<%--                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>--%>
																	</td>
																</tr>
																<tr>
																	 <td style="color:red;" class="column_RightBold">Alert :</td>
																	<td style="" class="column_Left">
																		<asp:TextBox ID="txtMedicineAlert" runat="server" Width="90%" CssClass="txtbox_Date"></asp:TextBox>
<%--                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>--%>
																	</td>        
																</tr>
															</table>    
															</fieldset>
														</td>          
											<td style="width: 40%; text-align:center;" valign="top" rowspan="3">

												<img alt="" height="160" src="../images/Default_Image.jpg" width="160px" style="border: 1px solid black" />
												<br><br>
												<asp:Button ID="btnUpload" runat="server" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="UPLOAD" Width="120px" />
																		  
											</td>
										</tr>
										   <tr>
														<td colspan ="2" align="center" >
															<fieldset id="fsPricePerQuantity" runat="server" style="width:70%;">
																<legend class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Price per Quantity:</strong></legend>
																	<table>
																		<tr>
																			<td  align="center">
																				<asp:Table ID="Table1" runat="server">
																					<asp:TableRow>
																						 <asp:TableCell CssClass="column_RightBold">
																						   Qty./Pack:
																						</asp:TableCell>
																					   <%-- <asp:TableCell>
																				   
																						</asp:TableCell>--%>
																					   
																						<asp:TableCell runat="server"  CssClass="column_CenterBold" HorizontalAlign="left">
																						   Unit Cost:
																						</asp:TableCell>
																					 <%--   <asp:TableCell>
																				   
																						</asp:TableCell>--%>
																						<asp:TableCell>
																				   
																						</asp:TableCell>
																						<asp:TableCell CssClass="column_RightBold">
																						   Selling Price:
																						</asp:TableCell>
																					</asp:TableRow>
																					<asp:TableRow>
																						<%--<asp:TableCell  CssClass="column_RightBold" >
																						   Qty./Pack :
																						</asp:TableCell>--%>
																						<asp:TableCell>
																						   <asp:TextBox id="txtQtyPack" runat="server" AutoPostBack="true" Width="50"></asp:TextBox>
																						</asp:TableCell>
																						<asp:TableCell >
																						   <asp:TextBox id="txtUnitCost" runat="server" AutoPostBack="true" Onchange="this.value=formatCurrency(this.value);" DataFormatString="{0:N}" Width="75"></asp:TextBox>
																						   </asp:TableCell>
																					<%--   <asp:TableCell  CssClass="column_RightBold">
																						   Qty./Pack :
																						</asp:TableCell>--%>
																						<asp:TableCell>
																						   <asp:TextBox id="txtpercent" runat="server" autopostback ="true" Width="30"></asp:TextBox>
																							%
																						</asp:TableCell>
																					   
																						<asp:TableCell >
																						   <asp:TextBox id="txtSellingPrice1" runat="server"  Onchange="this.value=formatCurrency(this.value);" DataFormatString="{0:N}" Width="75"></asp:TextBox>
																						   </asp:TableCell>
																						<asp:TableCell>
																							<asp:Button ID="Button1" runat="server" CssClass="CSButton" Text="ADD" 
                                                                                                OnClientClick="return validateMedicineAdd();" 
                                                                                                OnClick="btnMedicineAdd_Click"></asp:Button>

                                                                                            <nbsp;></nbsp>
                                                                                            <asp:Button ID="Button2" runat="server" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Remove" Enabled="false" OnClick="btnMedicineRemove_Click" />
                                                                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" TargetControlID="Button2" ConfirmText="Are you sure you want to remove this price?"></cc1:ConfirmButtonExtender>
																						   </asp:TableCell>
																					</asp:TableRow>
																					<asp:TableRow>
																					   <%-- <asp:TableCell  CssClass="column_RightBold">
																						   Qty./Pack :
																						</asp:TableCell>--%>
																					  <%--  <asp:TableCell>
																						   <asp:TextBox id="txtQtyPack2" runat="server" Width="50"></asp:TextBox>
																							
																						</asp:TableCell>
																						<asp:TableCell>
																						   <asp:TextBox id="txtSellingPrice2" runat="server" Width="75"></asp:TextBox>
																						   </asp:TableCell>--%>
																					  <%-- <asp:TableCell  CssClass="column_RightBold">
																						   Qty./Pack :
																						</asp:TableCell>--%>
																						<%--<asp:TableCell  >
																						   <asp:TextBox id="txtQtyPack3" runat="server" Width="30"></asp:TextBox>
																							%
																						</asp:TableCell>--%>
																					   <%-- <asp:TableCell>
																						   <asp:TextBox id="txtSellingPrice3" runat="server" Width="75"></asp:TextBox>
																						   </asp:TableCell>--%>
																					</asp:TableRow>
																				   <asp:Tablerow>
																						<%--<asp:TableCell>
																						   <asp:TextBox id="TextBox3" runat="server" Width="50"></asp:TextBox>
																							
																						</asp:TableCell>
																						<asp:TableCell>
																						   <asp:TextBox id="TextBox4" runat="server" Width="75"></asp:TextBox>
																						   </asp:TableCell>
																						<asp:TableCell  >
																						   <asp:TextBox id="TextBox5" runat="server" Width="30"></asp:TextBox>
																							%
																						</asp:TableCell>--%>
																						  


																				   </asp:Tablerow>
																				</asp:Table>
																			</td>
																			
																			</tr>
																		  <tr >
					   <%-- <td style="width: 1%"></td>--%>
						<td style="width: 98%" align="center">
							<asp:GridView ID="GridPPQ" runat="server" Visible="true" Width="98%" SkinID="GridViewAA" 
								AllowPaging="True" OnPageIndexChanging="GridPPQ_PageIndexChanging" PageSize="5" datakeynames="PPQ_ID,Item_id,QtyPack,Unit_cost,PPQ_Percent,Selling_Price" OnSelectedIndexChanged="GridPPQ_SelectedIndexChanged">
								<Columns>
                                    
                                      <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="false" CssClass="LinkBtnSelect" CommandName="Select" Text="Select">
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                       
                                    </asp:TemplateField>
                                  
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
						<td style="width: 1%"></td>
					</tr>
																		</table>

																 
																  
															</fieldset>
														</td>
											 
													</tr>
											 <tr>
														<td colspan="2" align="center">
															 <fieldset style="width:70%;">
																 <legend  class="column_Left" style =" font-family:Arial; color:#404040;"><strong>Location:</strong></legend>
																 <table width="100%">
																	 <tr>
																		 <td class="column_RightBold" >Warehouse :
																		 </td>
																		 <td  class="column_Left">
																			 <asp:DropDownList ID="drpMedicineWarehouse" runat="server" Width="98%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
																		 </td>

																		 <td class="column_RightBold">Bay :
																		 </td>
																		 <td  class="column_Left">
																			  <asp:TextBox ID="txtMedicineBay" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
																		  
																			 <asp:DropDownList ID="DropDownList2" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS" Visible ="false"></asp:DropDownList>
																		 </td>

																		 <td class="column_RightBold" style="width:15%">Column :
																		 </td>
																		 <td  class="column_Left">
																				 <asp:TextBox ID="txtMedicineColumn" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
																		  
																			 <asp:DropDownList ID="DropDownList3" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
																		 </td>

																		 <td class="column_RightBold" style="width:10%">Floor :
																		 </td>
																		 <td  class="column_Left">
																				<asp:TextBox ID="txtMedicineFloor" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
																		  
																			 <asp:DropDownList ID="DropDownList4" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
																		 </td>
																	 </tr>
																	 <tr>
																		 <td class="column_RightBold">Room :
																		 </td>
																		 <td  class="column_Left">
																			 <asp:TextBox ID="txtMedicineRoom" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
																			 
																			 <asp:DropDownList ID="DropDownList5" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
																		 </td>

																		 <td class="column_RightBold" style="width:10%">Shelves :
																		 </td>
																		 <td  class="column_Left">
																			  <asp:TextBox ID="txtMedicineShelves" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
																			 
																			 <asp:DropDownList ID="DropDownList6" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
																		 </td>

																		 <td class="column_RightBold">Rack :
																		 </td>
																		 <td  class="column_Left">
																			  <asp:TextBox ID="txtMedicineRack" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
																			 
																			 <asp:DropDownList ID="DropDownList7" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
																		 </td>
																		 
																		 <td class="column_RightBold">Bin :
																		 </td>
																		 <td  class="column_Left">
																			 <asp:TextBox ID="txtMedicineBin" runat="server" Width="90%" CssClass="txtbox_Var" ></asp:TextBox>
																				<table style="position:absolute; top:-999px; width:0px;">
																		   <tr>
																			   <td>
																				   <asp:TextBox ID="TextBox1" runat="server" Width="0px" Readonly="true"></asp:TextBox>
																		
																			   </td>
																		   </tr>
																	   </table>
																			 <asp:DropDownList ID="DropDownList8" runat="server" Width="100%" AutoPostBack="True" CssClass="drpdownCSS"  Visible ="false"></asp:DropDownList>
																		 </td>
																	 </tr>
																	
																 </table>
															 </fieldset>
														</td>
													</tr>
											
										  <tr>
																		<td colspan ="3" style="text-align:right;">
																			  <asp:Button ID="btnMedicineSave" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();" OnClick="btnMedicineSave_Click"></asp:Button>
              
																		   &nbsp; &nbsp; &nbsp;
																			 <asp:Button ID="btnFoodCancel"  runat="server" Width="120px" CssClass="CSButton" Text="CANCEL" OnClientClick="StartProgressBar();"></asp:Button>
										  
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

									<cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtMedicineMdate" Enabled="True" PopupButtonID="txtMedicineMdate"></cc1:CalendarExtender>
									<cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtMedicineEdate" Enabled="True" PopupButtonID="txtEDateConsOthers"></cc1:CalendarExtender>
									<cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtMedicineAlert" Enabled="True" PopupButtonID="txtAlertConsOthers"></cc1:CalendarExtender>
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
											<td style="width: 30%;" align="center" >
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
									<tr style="display:none;">
										<td style="width: 56%" class="column_CenterBold">
											<asp:Label ID="lblHistoryDetails" runat="server" Width="100%" Text="DETAILS" CssClass="borderCSS"></asp:Label></td>
										<td style="width: 14%" class="column_CenterBold">
											<asp:Label ID="Label2" runat="server" Width="100%" Text="DEBIT"  CssClass="borderCSS"></asp:Label></td>
										<td style="width: 15%" class="column_CenterBold">                                             
											<asp:Label ID="Label3" runat="server" Width="100%" Text="CREDIT" CssClass="borderCSS"></asp:Label></td>
										<td style="width: 15%" class="column_CenterBold">                                             
											<asp:Label ID="Label4" runat="server" Width="100%" Text="BALANCE" CssClass="borderCSS"></asp:Label></td>
									</tr>
									<tr>
										<td style="width: 100%" colspan="4">
											<asp:Panel ID="Panel2" runat="server" Width="100%" CssClass="PanelSize" ScrollBars="Vertical">
												<asp:GridView ID="grdLedger" runat="server" Width="100%" SkinID="GridViewAA">
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
														<asp:BoundField DataField="Trans_Type" HeaderText="PARTICULARS" >
															<HeaderStyle HorizontalAlign="Center" Height="30px" Width="50px"></HeaderStyle>

															<ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="46%"></ItemStyle>
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
							<asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW"></asp:Button>
						</td>
						<td style="width: 1%"></td>
					</tr>
				  </table>
			  </div>
				<asp:Panel ID="popupROP" runat="server" Width="350px" CssClass="Panel_Popup">
				  <table width="100%" >
					  <tr>
						 <td style="width: 100%; height: 30px; margin-left: 40px;" colspan="3" class="DivTitle">
							 REORDER POINT COMPUTATION
							  <asp:ImageButton ID="BtnImageClose" ImageUrl="~/images/Edited Image/CloseButton.png" runat="server" border="10px" Height="13px" Width="16px" />
						 </tr>
					  <tr>      
						  <td class="column_RightBold">
							  Demand Per Day :
							</td>
						  <td class="column_Left">
							 <asp:TextBox ID="DRP" runat ="server" CssClass="txtbox_Var" Width="150px" ></asp:TextBox>
						  </td>
					  </tr>
					   <tr>      
						  <td class="column_RightBold">
							  Lead Time for Delivery:
							</td>
						  <td class="column_Left">
							 <asp:TextBox ID="LTD" runat ="server" CssClass="txtbox_Var" Width="150px" ></asp:TextBox>

						  </td>
					  </tr>
					  <tr>
							<td class="column_RightBold"> </td>
						  <td>
							 
								<asp:Button ID="BtnCompute"  runat="server" Width="133px" CssClass="CSButton" Text="Compute" OnClick="BtnCompute_Click"></asp:Button>
						  </td>

					  </tr>
					  <tr>      
						  <td class="column_RightBold">
							  Reorder Point :
							</td>
						  <td class="column_Left">
							 <asp:TextBox ID="RP" runat ="server" CssClass="txtbox_Var"  Width="150px" ReadOnly ="true" ></asp:TextBox>

						  </td>
						  
					  </tr>
					   <tr>
						
							<td style="width: 50%; height: 10px">
								<asp:Label runat="server" ID="lblpopupROP"></asp:Label>
							</td>
						</tr>
				  </table>
				  
				  </asp:Panel>    
						 <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblpopupROP" PopupControlID="popupROP"  CancelControlID="BtnImageClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>     

				 <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label3" PopupControlID="popupParticular" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground">
			</cc1:ModalPopupExtender>
			  <asp:Panel ID="popupParticular" runat="server" Width="350px" CssClass="Panel_Popup">
				  <table width="100%">
					  <tr>
						 <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">
							 APPROVAL
						  </td>
					  </tr>
					  <tr>      
						  <td class="column_RightBold">
							  Approving Officer :
							</td>
						  <td class="column_Left">
							  <asp:DropDownList id="drpApprovedOfficer" runat="server" Width="150px" CssClass="ddropbox"></asp:DropDownList>
						  </td>
					  </tr>
					   <tr>      
						  <td class="column_RightBold">
							  Password :
							</td>
						  <td class="column_Left">
							 <asp:TextBox ID="txtApprovedPass" runat ="server" CssClass="txtbox_Var" Width="150px" TextMode="Password"></asp:TextBox>

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

			  <asp:Panel ID="popupNOTIF" runat="server"  CssClass="Panel_Popup" Width="300px" >
				  <table width="100%" >
					  <tr>
						 <td  class="rounded-corners" style="width: 100%;  height: 30px; background-color: red"  colspan="3" >
							 NOTIFICATION ALERT <asp:Image ID="Notif" runat="server" ImageUrl="~/images/POPUP/alert-notif.png" Width="20" />
							 
						 </tr>
				  
					  <tr>
						   <td   colspan="3" style="width: 100%; height: 30px; ">
							  You have reached the re-order point of this item. Order now. </td>
					  
						  
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
						 <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="lblNotif" PopupControlID="popupNOTIF"  CancelControlID="BtnImageClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>


				<asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
				<img alt="" src="../images/ajax-loader.gif" />
			</asp:Panel>
				  <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
		 <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
	   
		  </ContentTemplate>
		  </asp:UpdatePanel>

</asp:Content>

