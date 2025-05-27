<%@ Page Title="For Acceptance"
    Language="VB"
    AutoEventWireup="false"
    MasterPageFile="~/MasterPage.master"
    CodeFile="t_for_Acceptance.aspx.vb"
    EnableEventValidation="false"
    Inherits="Inventory_t_for_Acceptance"
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">


</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        // Add these event handlers for the ScriptManager when the page loads
        Sys.Application.add_load(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(beginRequest);  // Called when a partial postback starts
            prm.add_endRequest(endRequest);      // Called when the partial postback ends
        });

        // Function that runs when the postback starts (show the loading GIF)
        function beginRequest(sender, args) {
            document.getElementById("loadingDiv").style.display = "block"; // Show the loading GIF
        }

        // Function that runs when the postback ends (hide the loading GIF)
        function endRequest(sender, args) {
            document.getElementById("loadingDiv").style.display = "none";  // Hide the loading GIF
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div id="loadingDiv" style="display: none; text-align: center;">
                <img src="~/images/loading.gif" alt="Loading..." />
            </div>

            <div>
                <table width="100%">
                    <tr>
                        <td class="PageTitle" style="width: 98%">
                            <strong>
                                <asp:Label ID="lblClass" runat="server" Text="For Acceptance"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 98%">
                            <table style="width: 100%">
                                <tbody>
                                    <tr>
                                        <td style="width: 30%" class="column_RightBold">Search By : </td>
                                        <td style="width: 20%" class="column_left">
                                            <asp:DropDownList ID="ddSearch" runat="server" Width="80%" OnSelectedIndexChanged="ddSearch_SelectedIndexChanged" AutoPostBack="True" CssClass="drpdownCSS">
                                                <asp:ListItem Selected="True" Value="1">ALL</asp:ListItem>
                                                <asp:ListItem Value="3">Purchase Order</asp:ListItem>
                                                <asp:ListItem Value="4">Supplier / Bidder</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="txtTraps" runat="server" />
                                            <asp:HiddenField ID="txtHidenQTY" runat="server" />
                                            <asp:HiddenField ID="txtHiddenReceiveQty" runat="server" />
                                        </td>


                                        <td class="column_Left" style="width: 50%">
                                            <asp:MultiView ID="mvSearch" runat="server">
                                                <asp:View ID="vwAccount" runat="server">
                                                    <table id="tb_Account" runat="server" style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="True" CssClass="rbCS_Horizontal" RepeatDirection="Horizontal" Width="150px">
                                                                        <asp:ListItem Value="1">MOOE</asp:ListItem>
                                                                        <asp:ListItem Value="2">Capital Outlay</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="column_RightBold" style="width: 20%">Account Code :</td>
                                                                <td align="left" style="width: 80%">
                                                                    <asp:DropDownList ID="ddAccount" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Width="90%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:View>
                                                <asp:View ID="vwPO" runat="server">
                                                    <table id="tb_PO" runat="server" style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td class="column_RightBold" style="width: 20%">PO Number :</td>
                                                                <td style="width: 80%">
                                                                    <asp:TextBox ID="txtPO" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox>
                                                                    &nbsp;<asp:Button ID="btnSearchPO" runat="server" CssClass="CSButton" OnClick="btnSearchPO_Click" OnClientClick="StartProgressBar();" Text="Search" Width="100px" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:View>
                                                <asp:View ID="vwSupp" runat="server">
                                                    <table id="tb_Supplier" runat="server" style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td class="column_RightBold" style="width: 20%">Supplier Name :</td>
                                                                <td style="width: 80%">
                                                                    <asp:DropDownList ID="ddSupplier" runat="server" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddSupplier_SelectedIndexChanged" Width="90%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="column_RightBold" style="width: 20%"></td>
                                                                <td style="width: 80%">
                                                                    <asp:Button ID="btnSupplier" runat="server" CssClass="CSButton" OnClick="btnSupplier_Click" Text="Search" Visible="False" Width="100px" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:View>
                                                <asp:View ID="vwALL" runat="server">
                                                    <asp:RadioButtonList ID="rbALL" runat="server" AutoPostBack="True" CssClass="rbCS_Horizontal" OnSelectedIndexChanged="rbALL_SelectedIndexChanged" RepeatDirection="Horizontal" Visible="False" Width="200px">
                                                        <asp:ListItem Value="2">MOOE</asp:ListItem>
                                                        <asp:ListItem Value="3">Capital Outlay</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </asp:View>
                                            </asp:MultiView>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="grdAIR" runat="server" Width="100%" OnSelectedIndexChanged="grdAIR_SelectedIndexChanged"
                                SkinID="GridViewAA" AllowPaging="True" DataKeyNames="POHdr_ID,PO_No,PO_Date,ContractPrice,SuppName,RC_ID,Function_ID,RC_Name,Function_Desc,GA_ID,Supplier_Id,pre_procurement_hdr_id"
                                OnRowDataBound="grdAIR_RowDataBound" OnPageIndexChanging="grdAIR_PageIndexChanging" Font-Size="8pt" EmptyDataText="No Data Found.">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

                                <Columns>
                                    <asp:BoundField DataField="PO_No" HeaderText="PO No.">
                                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PO_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="PO Date">
                                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContractPrice" DataFormatString="{0:N}" HeaderText="PO Amount">
                                        <ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SuppName" HeaderText="Supplier">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="220px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RC_Name" HeaderText="Requesting Dept">
                                        <ItemStyle HorizontalAlign="Left" Width="210px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProjectName" HeaderText="Project Name">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OBR_No" HeaderText="OBR No.">
                                        <ItemStyle HorizontalAlign="Center" Width="130px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dvno" HeaderText="DV No." Visible="False">
                                        <ItemStyle Width="70px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="checkno" HeaderText="Check No." Visible="False">
                                        <ItemStyle Width="70px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="amountpaid" DataFormatString="{0:N}" HeaderText="Amount Paid" Visible="False">
                                        <ItemStyle HorizontalAlign="Right" Width="75px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="jevno" HeaderText="JEV No." Visible="False">
                                        <ItemStyle Width="70px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RespCenter" HeaderText="RespCenter" Visible="False"></asp:BoundField>
                                </Columns>

                                <PagerStyle HorizontalAlign="Center"></PagerStyle>

                                <EditRowStyle BorderColor="White"></EditRowStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnReturn" runat="server" Enabled="False" OnClick="btnReturn_Click" OnClientClick="StartProgressBar();" Text="RETURN" CssClass="CSButton" Width="150px" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" TargetControlID="btnReturn" ConfirmText="Are you sure you want to return this transaction?"></cc1:ConfirmButtonExtender>
                        </td>
                    </tr>

                    <tr>
                        <td class="DivTitle" style="width: 98%; height: 26px;">
                            <strong>
                                <asp:Label ID="Label4" runat="server" Text="Details"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <table>
                                <tbody>
                                    <tr>
                                        <td class="column_RightBold">Supplier Name :</td>
                                        <td class="column_Left" style="width: 250px">
                                            <asp:TextBox ID="txtSupplierName" CssClass="txtbox_Var" runat="server" Width="200px"></asp:TextBox></td>

                                        <td class="column_RightBold">Invoice Number :</td>
                                        <td class="column_Left">
                                            <asp:TextBox ID="txtInvoiceNumber" CssClass="txtbox_Var" runat="server"></asp:TextBox></td>

                                    </tr>
                                    <tr>
                                        <td class="column_RightBold">PO Number :</td>
                                        <td class="column_Left" style="width: 250px">
                                            <asp:TextBox ID="txtPoNumber" CssClass="txtbox_Var" runat="server"></asp:TextBox></td>

                                        <td class="column_RightBold" style="width: 200px">Invoice Date :</td>
                                        <td class="column_Left">
                                            <asp:TextBox ID="txtInvoiceDate" CssClass="txtbox_Var" runat="server"></asp:TextBox>&nbsp;(MM/DD/YYYY)
                                              <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtInvoiceDate" PopupButtonID="txtbox_Var"></cc1:CalendarExtender>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="column_RightBold">PO Date :</td>
                                        <td class="column_Left" style="width: 250px">
                                            <asp:TextBox ID="txtPodate" CssClass="txtbox_Var" runat="server"></asp:TextBox>&nbsp;(MM/DD/YYYY)
                                              <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPodate" PopupButtonID="txtbox_Var"></cc1:CalendarExtender>
                                        </td>

                                        <td class="column_RightBold" style="width: 200px">Remarks :</td>
                                        <td class="column_Left" style="width: 250px">
                                            <asp:TextBox ID="txtRemakrs" CssClass="txtbox_Var" runat="server" Width="250px"></asp:TextBox></td>

                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>


                    <tr>
                        <td class="DivTitle" style="width: 98%; height: 26px;">
                            <strong>
                                <asp:Label ID="Label1" runat="server" Text="For Acceptance"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="grdInspection" runat="server" Width="100%" SkinID="GridViewAA">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

                                <EmptyDataRowStyle BorderColor="Gray" BorderStyle="Solid"></EmptyDataRowStyle>
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="true" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" AutoPostBack="true" Text="All" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox>
                                        </HeaderTemplate>

                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbInspection" runat="server" AutoPostBack="True" Visible='<%#Bind("isVisible") %>' OnCheckedChanged="cbInspection_CheckedChanged"></asp:CheckBox>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10px"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date Received">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRcvDate" runat="server" Text='<%# Bind("Received_Date", "{0:d}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>


                                    <asp:BoundField DataField="Item_Desc" HeaderText="Description" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" Text='<%# Bind("Qty_Accepting") %>' ID="TextBox4"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtActQty" runat="server" Enabled="False" Width="50px" AutoPostBack="True" CssClass="txtbox_Amt" Text='<%# Bind("Qty_Accepting") %>' Visible='<%# bind("isVisible") %>' OnTextChanged="txtActQty_TextChanged"></asp:TextBox>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Acquisition Cost">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MarketValue" DataFormatString="{0:N}" HeaderText="Market Value" Visible="False">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Condition" HeaderText="Condition">
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Location" HeaderText="Location">
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Status">
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" Text='<%# Bind("Status1") %>' ID="TextBox2"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" ForeColor="Red" Text='<%# Bind("Status1") %>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#669933"></FooterStyle>

                                <PagerStyle HorizontalAlign="Center" BorderColor="Gray" BorderStyle="None"></PagerStyle>

                                <SelectedRowStyle BorderColor="Transparent"></SelectedRowStyle>

                                <HeaderStyle BorderColor="Transparent" BorderStyle="Dotted"></HeaderStyle>

                                <EditRowStyle BorderColor="White"></EditRowStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td class="column_RightBold">Requisitioning Department :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtDepartment" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                    <td class="column_RightBold">Function :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtFunction" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox></td>
                                </tr>
                                <tr style="display: none">
                                    <td style="width: 20%" class="column_RightBold">Requisitioning Department :</td>
                                    <td style="width: 30%" class="column_Left">
                                        <asp:DropDownList ID="ddDepartment" runat="server" Width="99%" OnSelectedIndexChanged="ddDepartment_SelectedIndexChanged" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList></td>
                                    <td style="width: 10%" class="column_RightBold">Function :</td>
                                    <td style="width: 30%" class="column_Left">
                                        <asp:DropDownList ID="ddFunction" runat="server" Width="99%" CssClass="drpdownCSS" Style="margin-top: 0px"></asp:DropDownList></td>

                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>

                        <td>
                            <%--removed startprogressbar--%>
                            <asp:Button ID="returnItemBtn" runat="server" Enabled="False" OnClick="btnReturnItem_Click" OnClientClick="return confirm('Are you sure you want to return this transaction?');" Text="RETURN ITEM" CssClass="CSButton" Width="150px" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="returnItemBtn" ConfirmText="Are you sure you want to return this transaction?"></cc1:ConfirmButtonExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="DivTitle" style="width: 98%; height: 26px;">
                            <strong>
                                <asp:Label ID="Label2" runat="server" Text="Item Details"></asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:MultiView ID="mvAccounts" runat="server">
                                <asp:View ID="vwOfficeSupplies" runat="server">
                                    <tr align="center">
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td class="column_RightBold">Description :</td>
                                                                    <td colspan="3" class="column_Left">
                                                                        <asp:TextBox ID="txtOSDescription" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold" style="width: 100px;">Category :</td>
                                                                    <td colspan="3">
                                                                        <asp:TextBox ID="txtOSCategory" CssClass="txtbox_Var" runat="server" Width="200px"></asp:TextBox>
                                                                    </td>


                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Brand Name :</td>
                                                                    <td colspan="3" class="column_Left">
                                                                        <asp:TextBox ID="txtOSBrandName" CssClass="txtbox_Var" runat="server" Width="200px"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Length :</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtOSLength" Width="73px" CssClass="txtbox_Var" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Width :</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtOSWidth" CssClass="txtbox_Var" Width="73" runat="server"></asp:TextBox>
                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Size :</td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtOSSize" CssClass="txtbox_Var" runat="server" Width="73px"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Color :</td>
                                                                    <td class="column_Left">
                                                                        <asp:TextBox ID="txtOSColor" CssClass="txtbox_Var" runat="server" Width="73px"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Height :</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtOSHeight" CssClass="txtbox_Var" Width="73" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="column_RightBold">Weight</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtOSWeight" CssClass="txtbox_Var" Width="73px" runat="server"></asp:TextBox>
                                                                    </td>

                                                                </tr>

                                                            </tbody>
                                                        </table>
                                                    </td>
                                                    <td>

                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Image ID="Image1" runat="server" CssClass="textimage2" Height="120px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="150px" />

                                                                </td>

                                                            </tr>
                                                            <tr align="center">
                                                                <td>
                                                                    <asp:Button ID="btnOfficeSupplyUpload" runat="server" Width="100px" CssClass="CSButton" Text="Upload" />
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </td>
                                                </tr>
                                            </table>



                                        </td>
                                    </tr>
                                </asp:View>

                                <asp:View ID="vwOtherSupplies" runat="server">
                                    <tr>
                                        <td>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td align="center" style="vertical-align: top; width: 70%; text-align: center">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td colspan="2" style="font-weight: bold; font-size: 9pt; font-family: Arial; background-color: lightgrey; text-align: center">ITEM INFORMATION</td>
                                                                <td colspan="2" style="font-weight: bold; font-size: 9pt; font-family: Arial; background-color: lightgrey; text-align: center">EXPIRY DETAILS</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="column_RightBold" style="width: 15%">Description :
                                                                </td>
                                                                <td class="column_Left" style="width: 35%">
                                                                    <asp:TextBox ID="txtMOOE_Description" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                <td class="column_RightBold" style="width: 15%">Form :
                                                                </td>
                                                                <td class="column_Left" style="width: 35%">
                                                                    <asp:TextBox ID="txtMOOE_Form" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="column_RightBold" style="width: 15%">Brand Name :
                                                                </td>
                                                                <td class="column_Left" style="width: 35%">
                                                                    <asp:TextBox ID="txtMOOE_Brand" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                <td class="column_RightBold" style="width: 15%">OTC / Rx :
                                                                </td>
                                                                <td class="column_Left" style="width: 35%">
                                                                    <asp:TextBox ID="txtMOOE_OTCRx" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="column_RightBold" style="width: 15%">Dose : 
                                                                </td>
                                                                <td class="column_Left" style="width: 35%">
                                                                    <asp:TextBox ID="txtDose" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                <td class="column_RightBold" style="width: 15%">Batch :
                                                                </td>
                                                                <td class="column_Left" style="width: 35%">
                                                                    <asp:TextBox ID="txtMOOE_Batch" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="column_RightBold" style="width: 15%">Dep Rate :
                                                                </td>
                                                                <td class="column_Left" style="width: 35%">
                                                                    <asp:TextBox ID="txtMOOE_DepRate" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                <td class="column_RightBold" style="width: 15%">Lot :
                                                                </td>
                                                                <td class="column_Left" style="width: 35%">
                                                                    <asp:TextBox ID="txtMOOE_Lot" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="column_RightBold" style="width: 15%">Dep Value :
                                                                </td>
                                                                <td class="column_Left" style="width: 35%">
                                                                    <asp:TextBox ID="txtMOOE_DepValue" runat="server" Width="98%" CssClass="txtbox_Amt">0.00</asp:TextBox></td>
                                                                <td class="column_RightBold" style="width: 15%">Mftg Date :
                                                                </td>
                                                                <td class="column_Left" style="width: 35%">
                                                                    <asp:TextBox ID="txtMOOE_MftgDate" runat="server" Width="50%" CssClass="txtboxinspection"></asp:TextBox>
                                                                    &nbsp;<asp:ImageButton ID="ImageButton9" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="column_RightBold" style="width: 15%">Remarks :
                                                                </td>
                                                                <td class="column_Left" style="width: 35%">
                                                                    <asp:TextBox ID="txtMOOE_Remarks" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                <td class="column_RightBold" style="width: 15%">Expiry Date :
                                                                </td>
                                                                <td class="column_Left" style="width: 35%">
                                                                    <asp:TextBox ID="txtMOOE_ExpiryDate" runat="server" Width="50%" CssClass="txtboxinspection"></asp:TextBox>
                                                                    &nbsp;<asp:ImageButton ID="ImageButton10" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="column_RightBold" style="width: 15%"></td>
                                                                <td class="column_Left" style="width: 35%"></td>
                                                                <td class="column_RightBold" style="width: 15%">Alert :
                                                                </td>
                                                                <td class="column_Left" style="width: 35%">
                                                                    <asp:TextBox ID="txtMOOE_AlertDate" runat="server" Width="50%" CssClass="txtboxinspection"></asp:TextBox>
                                                                    &nbsp;<asp:ImageButton ID="ImageButton11" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td align="center" style="vertical-align: middle; width: 30%; text-align: center">
                                                        <asp:Image ID="Image2" runat="server" CssClass="textimage2" Height="120px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="150px" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtMOOE_MftgDate" PopupButtonID="ImageButton9"></cc1:CalendarExtender>
                                            <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtMOOE_ExpiryDate" PopupButtonID="ImageButton10"></cc1:CalendarExtender>
                                            <cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtMOOE_AlertDate" PopupButtonID="ImageButton11"></cc1:CalendarExtender>
                                        </td>
                                    </tr>
                                </asp:View>

                                <asp:View ID="vwEquipments" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center" style="vertical-align: top; width: 70%; text-align: center">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td colspan="4" style="font-weight: bold; font-size: 9pt; font-family: Arial; background-color: lightgrey; text-align: center">ITEM INFORMATION</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Name :
                                                        </td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_Name" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                        <td class="column_RightBold" style="width: 15%">Dimension :
                                                        </td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_Dimension" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Description :
                                                        </td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_Description" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                        <td class="column_RightBold" style="width: 15%">Area Capacity :
                                                        </td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_AreaCap" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Power Input :
                                                        </td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_PowerIn" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                        <td class="column_RightBold" style="width: 15%">Model :
                                                        </td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_Model" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Dep Rate :
                                                        </td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_DepRate" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                        <td class="column_RightBold" style="width: 15%">Warranty :
                                                        </td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtWarranty" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Dep Value :</td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_DepValue" runat="server" Width="98%" CssClass="txtbox_Amt">0.00</asp:TextBox></td>
                                                        <td class="column_RightBold" style="width: 15%"></td>
                                                        <td class="column_Left" style="width: 35%">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%"></td>
                                                        <td class="column_Left" style="width: 35%">&nbsp;</td>
                                                        <td class="column_RightBold" style="width: 15%"></td>
                                                        <td class="column_Left" style="width: 35%">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Specification :
                                                        </td>
                                                        <td class="column_Left" colspan="2">
                                                            <asp:TextBox ID="txtCO_Specs" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                        <td class="column_Left" style="width: 35%">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="center" style="vertical-align: middle; width: 30%; text-align: center">
                                                <asp:Image ID="Image5" runat="server" CssClass="textimage2" Height="180px" ImageAlign="Middle"
                                                    ImageUrl="~/images/blankImage.jpg" Width="250px" /></td>
                                        </tr>
                                    </table>
                                </asp:View>

                                <%-- 1-07-06-010  Motor Vehicles --%>
                                <asp:View ID="vwMotors" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center" style="vertical-align: top; width: 70%; text-align: center">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td colspan="4" style="font-weight: bold; font-size: 9pt; font-family: Arial; background-color: lightgrey; text-align: center">ITEM INFORMATION</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Item Desc. :
                                                        </td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_MName" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                                        <td class="column_RightBold" style="width: 15%">Wheel Capacity :
                                                        </td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_MCapacity" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Model / Year :
                                                        </td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_MModel" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                                        <td class="column_RightBold" style="width: 15%">Gross Weight :
                                                        </td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_MWeight" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Declared Name :</td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtDeclaredName" runat="server" CssClass="txtbox_Var" Width="98%"></asp:TextBox>

                                                        </td>

                                                        <td class="column_RightBold" style="width: 15%">No. of Seats :
                                                        </td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_MSeats" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">&nbsp;Displacement :</td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtDisplacement" runat="server" CssClass="txtbox_Var" Width="98%"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold" style="width: 15%">Beneficial User :
                                                        </td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtBeneficialUser" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">&nbsp;</td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_MChasisNo" runat="server" CssClass="txtbox_Var" Width="98%" Visible="false"></asp:TextBox>

                                                        </td>
                                                        <td class="column_RightBold" style="width: 15%">Warranty :
                                                        </td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_MWarranty" runat="server" Width="98%" CssClass="txtbox_Var"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">&nbsp;</td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCO_MColor" runat="server" CssClass="txtbox_Var" Width="98%" Visible="false"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold" style="width: 15%">Specification :</td>
                                                        <td class="column_Left" style="width: 35%; vertical-align: top" rowspan="3">
                                                            <asp:TextBox ID="txtCO_MSpecs" runat="server" Width="98%" CssClass="txtbox_Remarks" TextMode="MultiLine"></asp:TextBox>

                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">&nbsp;</td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtCSNumber" runat="server" CssClass="txtbox_Var" Width="98%" Visible="false"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold" style="width: 15%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">&nbsp;</td>
                                                        <td class="column_Left" style="width: 35%">
                                                            <asp:TextBox ID="txtEngineNo" runat="server" CssClass="txtbox_Var" Width="98%" Visible="false"></asp:TextBox>
                                                        </td>
                                                        <td class="column_RightBold" style="width: 15%"></td>
                                                    </tr>

                                                </table>
                                            </td>
                                            <td align="center" style="vertical-align: middle; width: 30%; text-align: center">
                                                <asp:Image ID="Image4" runat="server" CssClass="textimage2" Height="180px" ImageAlign="Middle"
                                                    ImageUrl="~/images/blankImage.jpg" Width="250px" /></td>
                                        </tr>
                                    </table>
                                </asp:View>

                                <asp:View ID="vwLand" runat="server">
                                    <table style="width: 1000px">
                                        <tbody>
                                            <tr>
                                                <td style="width: 800px" class="column_Left">
                                                    <fieldset style="width: 800px; height: 130px" class="PanelBorder">
                                                        <legend><strong>PROPERTY IDENTIFICATION</strong></legend>
                                                        <table width="800">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 85px" class="column_RightBold" align="right">LGU Code :</td>
                                                                    <td style="width: 100px" class="column_Left">
                                                                        <asp:TextBox ID="txtLandlgucode" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 100px" class="column_RightBold" align="right">District Code :</td>
                                                                    <td style="width: 90px" class="column_Left">
                                                                        <asp:TextBox ID="txtLanddistrictcode" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 150px" class="column_RightBold" align="right">City/Municipality Code :</td>
                                                                    <td style="width: 80px" class="column_Left">
                                                                        <asp:TextBox ID="txtLandcitymunicipality1" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 115px" class="column_RightBold" align="right">Barangay Code :</td>
                                                                    <td style="font-weight: bold; width: 80px; font-style: italic" class="column_Left" align="left">
                                                                        <asp:TextBox ID="txtLandbrgycode" runat="server" Width="75px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 85px" class="column_RightBold" align="right">Section No. :</td>
                                                                    <td style="width: 100px" class="column_Left">
                                                                        <asp:TextBox ID="txtLandSectionno" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 100px" class="column_RightBold" align="right">Parcel No. :</td>
                                                                    <td style="width: 90px" class="column_Left">
                                                                        <asp:TextBox ID="txtLandParcelno" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 150px" class="column_RightBold" align="right">Series No. :</td>
                                                                    <td style="width: 80px" class="column_Left">
                                                                        <asp:TextBox ID="txtLandSeriesno" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 115px" class="column_RightBold" align="right"></td>
                                                                    <td style="font-weight: bold; width: 80px; font-style: italic" class="column_Left" align="left"></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <table style="width: 800px">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 50px" class="column_RightBold">PIN :</td>
                                                                    <td style="width: 140px" class="column_Left">
                                                                        <asp:TextBox ID="txtLandPIN" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 60px" class="column_RightBold">ARP :</td>
                                                                    <td style="width: 120px" class="column_Left">
                                                                        <asp:TextBox ID="txtLandARP" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 150px" class="column_RightBold">Depreciation Rate :</td>
                                                                    <td style="width: 100px" class="column_Left">
                                                                        <asp:TextBox ID="txtLandDepriciationRate" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 80px" class="column_RightBold">Rev Year :</td>
                                                                    <td style="width: 100px" class="column_Left">
                                                                        <asp:TextBox ID="txtLandrevyear" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 50px" class="column_RightBold">TDN :</td>
                                                                    <td style="width: 140px" class="column_Left">
                                                                        <asp:TextBox ID="txtLandTdn" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 60px" class="column_RightBold">RPTIN :</td>
                                                                    <td style="width: 120px" class="column_Left">
                                                                        <asp:TextBox ID="txtLandRPTIN" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 150px" class="column_RightBold">Depreciation Value :</td>
                                                                    <td style="width: 100px" class="column_Left">
                                                                        <asp:TextBox ID="txtLandDepreciatedValue" runat="server" Width="120px" CssClass="txtboxinspection">0.00</asp:TextBox></td>
                                                                    <td style="width: 80px" class="column_RightBold"></td>
                                                                    <td style="width: 100px" class="column_Left"></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </fieldset>
                                                </td>
                                                <td style="width: 200px" rowspan="2">
                                                    <fieldset style="width: 191px; height: 245px" class="PanelBorder">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td style="vertical-align: middle; width: 191px; height: 141px; text-align: center" class="textimage" colspan="2">
                                                                        <asp:Image ID="ImageLand" runat="server" Width="151px" ImageUrl="~/images/LandDefaultimage.jpg" CssClass="textimage2" Height="124px" ImageAlign="Middle"></asp:Image></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 80px" class="textimage">Date Taken:</td>
                                                                    <td style="width: 110px" class="textimage2">
                                                                        <asp:TextBox ID="txtLanddatetaken" runat="server" Width="108px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 80px" class="textimage">Uploaded By:</td>
                                                                    <td style="width: 110px" class="textimage2">
                                                                        <asp:TextBox ID="txtLandUploadedby" runat="server" Width="108px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 80px" class="textimage">Position:</td>
                                                                    <td style="width: 110px" class="textimage2">
                                                                        <asp:TextBox ID="txtLandPosition" runat="server" Width="108px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 800px" class="column_Left">
                                                    <fieldset style="width: 800px; height: 115px" class="PanelBorder">
                                                        <legend><strong>LOCATION</strong></legend>
                                                        <table width="800">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 55px; height: 15px" class="column_LeftBold" align="left">Lot No. :</td>
                                                                    <td style="width: 64px; height: 15px" class="column_LeftBold" align="left">Blk No. :</td>
                                                                    <td style="width: 91px; height: 15px" class="column_LeftBold" align="left">Street Name :</td>
                                                                    <td style="width: 224px; height: 15px" class="column_LeftBold" align="left">Subdivision/Village/Compound :</td>
                                                                    <td style="width: 83px; height: 15px" class="column_LeftBold" align="left">Phase No. :</td>
                                                                    <td style="width: 145px; height: 15px" class="column_LeftBold" align="left">Purok :</td>
                                                                    <td style="height: 15px" class="column_LeftBold" align="left">Sitio :</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 55px" class="text4">
                                                                        <asp:TextBox ID="txtLandlocationLot" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 64px" class="text4">
                                                                        <asp:TextBox ID="txtLandlocationblkno" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 91px" class="text4">
                                                                        <asp:TextBox ID="txtLandlocationstreetname" runat="server" Width="85px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 224px" class="text4" align="left">
                                                                        <asp:TextBox ID="txtLandlocationsubdivisionvillage" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 83px" class="text4">
                                                                        <asp:TextBox ID="txtLandlocationphaseno" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 145px" class="text4" align="left">
                                                                        <asp:TextBox ID="txtLandlocationpurok" runat="server" Width="130px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td class="text4">
                                                                        <asp:TextBox ID="txtLandlocationsitio" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <table width="800">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 4px" class="column_LeftBold" align="left">Barangay :</td>
                                                                    <td style="width: 20px" class="column_LeftBold" align="left">District :</td>
                                                                    <td style="width: 194px" class="column_LeftBold" align="left">City/Municipality :</td>
                                                                    <td style="width: 85px" class="column_LeftBold" align="left">Region :</td>
                                                                    <td style="width: 117px" class="column_LeftBold" align="left">Province :</td>
                                                                    <td class="column_LeftBold" align="left">Zip Code :</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 4px" class="column_Left" align="left">
                                                                        <asp:TextBox ID="txtLandbarangay" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 20px" class="column_Left" align="left">
                                                                        <asp:TextBox ID="txtLandDistrict" runat="server" Width="134px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 194px" class="column_Left" align="left">
                                                                        <asp:TextBox ID="txtLandCitymunicipality" runat="server" Width="190px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 85px" class="column_Left" align="left">
                                                                        <asp:TextBox ID="txtLandRegion" runat="server" Width="94px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 117px" class="column_Left" align="left">
                                                                        <asp:TextBox ID="txtLandprovince" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td class="column_Left" align="left">
                                                                        <asp:TextBox ID="txtLandzipcode" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1000px" class="column_Left" colspan="2">
                                                    <fieldset style="width: 1000px" class="PanelBorder">
                                                        <legend><strong><em>CHARACTERISTICS</em></strong></legend>
                                                        <table style="width: 997px" id="tbcharacter">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 60px" class="column_RightBold">Classification :</td>
                                                                    <td style="width: 190px" class="column_Left" align="left">
                                                                        <asp:TextBox ID="txtLandClassification" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 80px" class="column_RightBold" align="right">Sub Class :</td>
                                                                    <td style="width: 150px" class="column_Left" align="left">
                                                                        <asp:TextBox ID="txtLandSubClass" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 80px" class="column_RightBold" align="right">Land Use :</td>
                                                                    <td style="width: 190px" class="column_Left" align="left">
                                                                        <asp:TextBox ID="txtLandUse" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 80px" class="column_RightBold" align="right">Status :</td>
                                                                    <td style="width: 160px" class="column_Left" align="left">
                                                                        <asp:TextBox ID="txtLandStatus1" runat="server" Width="142px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 60px; height: 9px" class="column_RightBold">Taxable :</td>
                                                                    <td style="width: 190px; height: 9px" class="column_Left" align="left">
                                                                        <asp:DropDownList ID="ddwnLandTaxable" runat="server" Width="80px">
                                                                            <asp:ListItem Selected="True">Yes</asp:ListItem>
                                                                            <asp:ListItem>No</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                    <td style="width: 80px; height: 9px" class="column_RightBold" align="right">Area :</td>
                                                                    <td style="width: 150px; height: 9px" class="column_Left" align="left">
                                                                        <asp:TextBox ID="txtLandArea" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 80px; height: 9px" class="column_RightBold"></td>
                                                                    <td style="width: 190px; height: 9px" class="column_Left"></td>
                                                                    <td style="width: 80px; height: 9px" class="column_RightBold" align="right">Status :</td>
                                                                    <td style="width: 160px; height: 9px" class="column_Left" align="left">
                                                                        <asp:TextBox ID="txtLandStatus2" runat="server" Width="142px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 1000px" class="column_Left" colspan="2">
                                                    <fieldset style="width: 1000px; height: 70px" id="fiedsetValue" class="PanelBorder">
                                                        <legend><strong><em>VALUE</em></strong></legend>
                                                        <table style="width: 997px; height: 50px" id="Table33">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 170px" class="column_RightBold" align="right">Assessed Value:</td>
                                                                    <td style="width: 90px" align="left">
                                                                        <asp:TextBox ID="txtLandAssessedValue" runat="server" Width="90px" CssClass="txtboxinspection">0.00</asp:TextBox></td>
                                                                    <td style="width: 30px" class="column_RightBold">Date:</td>
                                                                    <td style="width: 70px" align="left">
                                                                        <asp:TextBox ID="txtLandAssessedDate" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 190px" class="column_RightBold" align="right">Market Value:</td>
                                                                    <td style="width: 90px" align="left">
                                                                        <asp:TextBox ID="txtLandMarketValue" runat="server" Width="90px" CssClass="txtboxinspection">0.00</asp:TextBox></td>
                                                                    <td style="width: 30px" class="column_RightBold">Date:</td>
                                                                    <td style="width: 70px" align="left">
                                                                        <asp:TextBox ID="txtLandMarketDate" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 180px" class="column_RightBold" align="right">Unit Value:</td>
                                                                    <td style="width: 90px" align="left">
                                                                        <asp:TextBox ID="txtLandUnitValue" runat="server" Width="90px" CssClass="txtboxinspection">0.00</asp:TextBox></td>
                                                                    <td style="width: 30px" class="column_RightBold" align="left">Date:</td>
                                                                    <td style="width: 70px" align="left">
                                                                        <asp:TextBox ID="txtLandUnitDate" runat="server" Width="68px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 170px" class="column_RightBold" align="right">Amount in Words:</td>
                                                                    <td style="width: 200px" colspan="3">
                                                                        <asp:TextBox ID="txtLandAssessedAmount" runat="server" Width="210px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 190px" class="column_RightBold" align="right">Amount in Words:</td>
                                                                    <td style="width: 200px" align="left" colspan="3">
                                                                        <asp:TextBox ID="txtLandMarketAmount" runat="server" Width="210px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 180px" class="column_RightBold" align="right">Assessment Level :</td>
                                                                    <td style="width: 200px" align="left" colspan="3">
                                                                        <asp:DropDownList ID="dpLandAssessmentLvl" runat="server" Width="208px" CssClass="txtboxinspection"></asp:DropDownList></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txtLandAssessedDate"></cc1:CalendarExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtLandMarketDate"></cc1:CalendarExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txtLandUnitDate"></cc1:CalendarExtender>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:View>

                                <asp:View ID="vwBuilding" runat="server">
                                    <table style="width: 1000px">
                                        <tbody>
                                            <tr>
                                                <td style="width: 800px">
                                                    <fieldset style="width: 100%; height: 200px" class="PanelBorder">
                                                        <table id="Table35" width="800">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 120px; height: 18px" class="column_LeftBold" align="left"></td>
                                                                    <td style="width: 7px; height: 18px" class="column_RightBold"></td>
                                                                    <td style="width: 247px" class="text3" align="left"></td>
                                                                    <td style="width: 132px; height: 18px" class="column_LeftBold" align="left"></td>
                                                                    <td style="width: 2px; height: 18px" class="column_RightBold"></td>
                                                                    <td style="width: 180px" class="text3"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 120px; height: 18px" class="column_LeftBold" align="left">Building Control No.</td>
                                                                    <td style="width: 7px; height: 18px" class="column_RightBold">:</td>
                                                                    <td style="width: 247px" class="text3" align="left">
                                                                        <asp:TextBox ID="txtbuildingcontolno" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 132px; height: 18px" class="column_LeftBold" align="left">Building Use</td>
                                                                    <td style="width: 2px; height: 18px" class="column_RightBold">:</td>
                                                                    <td style="width: 180px" class="text3">
                                                                        <asp:TextBox ID="txtbuildinguse" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 120px" class="column_LeftBold" align="left">Building Code</td>
                                                                    <td style="width: 7px" class="column_RightBold">:</td>
                                                                    <td style="width: 247px" class="text3" align="left">
                                                                        <asp:TextBox ID="txtbuildingcode" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 132px" class="column_LeftBold" align="left">Building Occupancy</td>
                                                                    <td style="width: 2px" class="column_RightBold">:</td>
                                                                    <td style="width: 180px" class="text3">
                                                                        <asp:TextBox ID="txtbuildingoccupancy" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 120px" class="column_LeftBold" align="left">Building Name</td>
                                                                    <td style="width: 7px" class="column_RightBold">:</td>
                                                                    <td style="width: 247px" class="text3" align="left">
                                                                        <asp:TextBox ID="txtbuildingname" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 132px" class="column_LeftBold" align="left">Number of Floors</td>
                                                                    <td style="width: 2px" class="column_RightBold">:</td>
                                                                    <td style="width: 180px" class="text3">
                                                                        <asp:TextBox ID="txtbuildingnumberoffloors" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 120px; height: 24px" class="column_LeftBold" align="left">Address</td>
                                                                    <td style="width: 7px; height: 24px" class="column_RightBold">:</td>
                                                                    <td style="width: 247px; height: 24px" class="text3" align="left">
                                                                        <asp:TextBox ID="txtbuildingaddress" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 132px; height: 24px" class="column_LeftBold" align="left">Avg. Area Per Floor</td>
                                                                    <td style="width: 2px; height: 24px" class="column_RightBold">:</td>
                                                                    <td style="width: 180px; height: 24px" class="text3">
                                                                        <asp:TextBox ID="txtbuildingavgareaperfloor" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 120px" class="column_LeftBold" align="left">Postal Code</td>
                                                                    <td style="width: 7px" class="column_RightBold">:</td>
                                                                    <td style="width: 247px" class="text3" align="left">
                                                                        <asp:TextBox ID="txtbuildingpostalcode" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                    <td style="width: 132px" class="column_LeftBold" align="left">Cost per Area</td>
                                                                    <td style="width: 2px" class="column_RightBold">:</td>
                                                                    <td style="width: 180px" class="text3">
                                                                        <asp:TextBox ID="txtbuildingcostperarea" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 120px" class="column_LeftBold" align="left">Depreciation Rate</td>
                                                                    <td style="width: 7px" class="column_RightBold">:</td>
                                                                    <td style="width: 247px" class="text3" align="left">
                                                                        <asp:TextBox ID="txtbuildingdepreciationrate" runat="server" Width="200px" CssClass="txtboxinspection">0.00</asp:TextBox></td>
                                                                    <td style="width: 132px" class="column_LeftBold" align="left">Depreciated Value</td>
                                                                    <td style="width: 2px" class="column_RightBold">:</td>
                                                                    <td style="width: 180px" class="text3">
                                                                        <asp:TextBox ID="txtbuildingdepreciationvalue" runat="server" Width="200px" CssClass="txtboxinspection">0.00</asp:TextBox></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtbuildingdepreciationrate" ValidChars="0123456789.,%"></cc1:FilteredTextBoxExtender>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtbuildingdepreciationvalue" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                                    </fieldset>
                                                </td>
                                                <td style="width: 200px">
                                                    <fieldset style="width: 100%; height: 200px" class="PanelBorder">
                                                        <table class="textimage">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 191px; height: 141px" class="textimage2" colspan="2">
                                                                        <asp:Image ID="imgbuilding" runat="server" Width="151px" ImageUrl="~/images/BuildingDefaultImage.jpg" CssClass="textimage2" Height="124px" ImageAlign="Middle"></asp:Image></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 80px" class="textimage">Date Taken:</td>
                                                                    <td style="width: 100px" class="textimage1">
                                                                        <asp:TextBox ID="txtbuildingdatetaken" runat="server" Width="87px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 80px" class="textimage">Uploaded By:</td>
                                                                    <td style="width: 100px" class="textimage1">
                                                                        <asp:TextBox ID="txtbuildinguploadedby" runat="server" Width="87px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 80px" class="textimage">Position:</td>
                                                                    <td style="width: 100px" class="textimage1">
                                                                        <asp:TextBox ID="txtbuildingposition" runat="server" Width="87px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr>

                    <tr>
                        <td class="DivTitle" style="width: 98%; height: 26px;">
                            <strong>
                                <asp:Label ID="Label3" runat="server" Text="Acceptance"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <table>
                                <tr>
                                    <td class="column_RightBold">Date : </td>
                                    <td class="column">
                                        <asp:TextBox ID="txtAcceptDate" CssClass="txtbox_Var" runat="server"></asp:TextBox>

                                        &nbsp;<asp:ImageButton ID="ImageButton4" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_RightBold">Accepted By :</td>
                                    <td class="column_Left">
                                        <asp:DropDownList ID="ddAcceptedBy" runat="server" Width="98%" CssClass="drpdownCSS"></asp:DropDownList></td>

                                    <caption>
                                        &nbsp;</caption>
                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold">Delivery Status :</td>
                        <td class="column_Left">
                            <asp:RadioButtonList ID="rbStatus" runat="server" CssClass="rbCS_Horizontal" Width="180px" AutoPostBack="True" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="1">Partial</asp:ListItem>
                                <asp:ListItem Value="2">Complete</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>

                </table>
                </td>
                         </tr>
                         <tr align="center">
                             <td>
                                 <table>
                                     <tr>
                                         <td>
                                             <asp:Button ID="btnActSave" runat="server" CssClass="CSButton" Width="100px" Text="Save" Enabled="false" OnClick="btnSave_Click" />


                                         </td>
                                         <td>
                                             <asp:Button ID="btnActPreview" runat="server" Enabled="False" CssClass="CSButton" Width="100px" Text="Preview" OnClick="btnActPreview_Click" />
                                         </td>
                                     </tr>
                                 </table>
                             </td>
                         </tr>
                <tr style="height: 10px">
                    <td></td>
                </tr>



                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtAcceptDate" PopupButtonID="ImageButton4"></cc1:CalendarExtender>

                </table>
            </div>
            <asp:Panel ID="popup" runat="server" Width="850px" CssClass="Panel_Popup">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td style="width: 100%; height: 30px" class="DivTitle">Serial Number / Plate Number
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px" align="center"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Label ID="Label6" runat="server" Font-Italic="true" ForeColor="Red" Font-Size="10pt" Font-Names="Calibri" Text='Put "NA" if serial number and plate number is not applicable to the item.'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Panel ID="ZXC" runat="server" Width="98%" CssClass="PanelSize_Popup" ScrollBars="Vertical" BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" HorizontalAlign="Center" BackColor="White">
                                <asp:GridView ID="grdSerial" runat="server" Width="100%" SkinID="GridViewAA" EmptyDataText="No Data Found.">
                                    <Columns>
                                        <asp:BoundField DataField="ItemNo" HeaderText="Item No.">
                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Item_Desc" HeaderText="Description" HtmlEncode="false">
                                            <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Serial No. / Plate No.">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtSerialNo" runat="server" Width="90%" CssClass="txtbox_Date"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item_ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItem_ID" runat="server" Text='<%# Bind("Item_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px" align="center"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Button ID="btnSaveOS" OnClick="btnSaveOS_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="SAVE"></asp:Button>
                            &nbsp;<asp:Button runat="server" ID="btnCancelSerial" Width="150px" CssClass="CSButton" Text="CLOSE" />
                            &nbsp;<asp:Button runat="server" ID="btnNA" Width="150px" OnClick="btnNA_Click" CssClass="CSButton" Text="N/A All" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Label ID="Properties" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 20px" align="center"></td>
                    </tr>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Properties" PopupControlID="popup" BackgroundCssClass="modalBackground" BehaviorID="ctl02_ModalPopupExtender2" CancelControlID="ImageButton7"></cc1:ModalPopupExtender>


            <asp:Panel ID="popupVehicles" runat="server" Width="1000" CssClass="Panel_Popup">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td style="width: 100%; height: 30px" class="DivTitle">Serial Number / Plate Number
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px" align="center"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Label ID="Label5" runat="server" Font-Italic="true" ForeColor="Red" Font-Size="10pt" Font-Names="Calibri" Text='Put "NA" if serial number and plate number is not applicable to the item.'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Panel ID="Panel4" runat="server" Width="98%" CssClass="PanelSize_Popup" ScrollBars="Vertical" BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" HorizontalAlign="Center" BackColor="White">
                                <asp:GridView ID="grdSerialVehicles" runat="server" Width="100%" SkinID="GridViewAA" EmptyDataText="No Data Found.">
                                    <Columns>
                                        <asp:BoundField DataField="ItemNo" HeaderText="Item No.">
                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Item_Desc" HeaderText="Description" HtmlEncode="false">
                                            <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Serial No.">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtSerialNo" runat="server" Width="90%" CssClass="txtbox_Date"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Chasis No.">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtChasisNo" runat="server" Width="90%" CssClass="txtbox_Date"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="License Plate No.">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtLicensePlateNo" runat="server" Width="90%" CssClass="txtbox_Date"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="MV File No.">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMvfileno" runat="server" Width="90%" CssClass="txtbox_Date"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Con. Sticker">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtConsticker" runat="server" Width="90%" CssClass="txtbox_Date"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Chasis number">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtChasis_No" runat="server" Width="90%" CssClass="txtbox_Date"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Vehicle Color">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtVehicle_color" runat="server" Width="90%" CssClass="txtbox_Date"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="CS No.">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCS_no" runat="server" Width="90%" CssClass="txtbox_Date"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Engine No.">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtEngine_No" runat="server" Width="90%" CssClass="txtbox_Date"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Item_ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItem_ID1" runat="server" Text='<%# Bind("Item_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px" align="center"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Button ID="Button6" runat="server" Text="SAVE" CssClass="CSButton" Width="150px" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button runat="server" ID="Button4" Width="150px" CssClass="CSButton" Text="CLOSE" />
                            &nbsp;<asp:Button runat="server" ID="Button5" Width="150px" CssClass="CSButton" Text="N/A All" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Label ID="PropertyVehicles" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 20px" align="center"></td>
                    </tr>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="PropertyVehicles" PopupControlID="popupVehicles" BackgroundCssClass="modalBackground" BehaviorID="ctl02_ModalPopupExtender3" CancelControlID="ImageButton7"></cc1:ModalPopupExtender>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
