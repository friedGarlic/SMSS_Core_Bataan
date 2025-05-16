<%@ Page Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="t_Purchase_Order.aspx.vb"
    Inherits="procurement_t_Purchase_Order" 
    Title="CREATE PURCHASE ORDER" 
    EnableEventValidation="false" 
    StylesheetTheme="SkinFile" %>

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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">CREATE PURCHASE ORDER
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search By : </span>
                            <asp:DropDownList ID="ddSearchOption" runat="server" CssClass="drpdownCSS" Width="200px" OnSelectedIndexChanged="ddSearchOption_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="1">ALL</asp:ListItem>
                                <asp:ListItem Value="2">PR Number</asp:ListItem>
                                <asp:ListItem Value="3">Project Reference No.</asp:ListItem>
                            </asp:DropDownList>
                            <span class="column_RightBold"> <asp:Label ID="lblSearch" runat="server" Font-Bold="True" Font-Size="11pt" Font-Names="Calibri" Text="ALL"></asp:Label> </span>                                                     
                            <asp:TextBox ID="txtSearch" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox>
                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server"  CssClass="CSButton" Width="150px" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="gvPurchase_Order" runat="server" Width="98%" Font-Bold="False" OnSelectedIndexChanged="gvPurchase_Order_SelectedIndexChanged" AllowPaging="True" OnRowDataBound="gvPurchase_Order_RowDataBound" SkinID="GridViewAA" 
                                AutoGenerateColumns="False" DataKeyNames="prhdr_id,isGasoline,SuppName,Address1,ContractPrice,Supplier_ID,pr_no,RC_ID,Function_ID,CanvassID,mode_of_procurement_id,isCanvass,ID,isBidding,pre_procurement_hdr_id,isConsolidated,GA_ID,ProjectName,Consolidated_PRNumber,F_ID,Func_per_Office_ID " 
                                OnPageIndexChanging="gvPurchase_Order_PageIndexChanging" EmptyDataText="No Data Found.">
                                <Columns>
                                    <asp:BoundField DataField="pr_no" HeaderText="PR / Reference Number">
                                        <FooterStyle HorizontalAlign="Left"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OBR_No" HeaderText="OBR No." HtmlEncode="False">
                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RC_Name" HeaderText="Requesting Dept.">
                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                    </asp:BoundField>                                    
                                    <asp:BoundField DataField="SuppName" HeaderText="Supplier">
                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProjectName" HeaderText="Project Name">
                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                       <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%;height:10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">
                            Details
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 98%">
                                <tbody>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Supplier Name :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtSupplier" runat="server" Width="95%" CssClass="txtbox_Var" SkinID="text" ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 15%" class="column_RightBold">Contract Price :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox Style="text-align: right" ID="txtAmount" runat="server" Width="150px" CssClass="txtbox_Amt" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Address :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtaddress" runat="server" Width="95%" CssClass="txtbox_Var" SkinID="text" ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 15%" class="column_RightBold">PO Number :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtPOnum" runat="server" Width="150px" CssClass="txtbox_Var" SkinID="text" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Place of Delivery :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtDPlace" runat="server" Width="95%" CssClass="txtbox_Var" SkinID="text"></asp:TextBox></td>
                                        <td style="width: 15%" class="column_RightBold">PO Date :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtPOdate" runat="server" Width="120px" CssClass="txtbox_Date" SkinID="text"></asp:TextBox>
                                            &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Width="20px" ImageUrl="~/images/calendar1.jpg" Height="15px"></asp:ImageButton>
                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Delivery Date :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtDeliveryDate" runat="server" Width="120px" CssClass="txtbox_Date" ></asp:TextBox>
                                            &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" Width="20px" ImageUrl="~/images/calendar1.jpg" Height="15px"></asp:ImageButton>
                                            <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Text="Label" CssClass="textimage1" Visible="False"></asp:Label>
                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span></td>
                                        <td style="width: 15%" class="column_RightBold">Delivery Term :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtDeliveryTerm" runat="server" CssClass="txtbox_Var" SkinID="text" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">OBR NO. :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtOBR_NO" runat="server" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                        </td>
                                        <td style="width: 15%" class="column_RightBold">Payment Term :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddPterm" runat="server" Width="200px" CssClass="drpdownCSS" Enabled="False">
                                               <%-- <asp:ListItem Value="  ">   </asp:ListItem>--%>
                                                <asp:ListItem>Cheque</asp:ListItem>
                                                <asp:ListItem>Cash on delivery</asp:ListItem>
                                                <asp:ListItem>Cash before shipment</asp:ListItem>
                                                <asp:ListItem>Payment in advance</asp:ListItem>
                                                <asp:ListItem>End of month</asp:ListItem>
                                                <asp:ListItem>Net 7</asp:ListItem>
                                                <asp:ListItem>Net 30</asp:ListItem>
                                                <asp:ListItem>Net 60</asp:ListItem>
                                                <asp:ListItem>Net 90</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                </tbody>
                            </table>
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" TargetControlID="txtDeliveryDate" PopupButtonID="ImageButton3"></cc1:CalendarExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtPOdate" PopupButtonID="ImageButton1"></cc1:CalendarExtender>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">
                           List of Goods
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:MultiView ID="mvGoods" runat="server">
                                <asp:View ID="vwGoods" runat="server">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:Panel ID="Panel2" runat="server" Width="99%" CssClass="PanelSize" ScrollBars="Vertical">
                                                <asp:GridView ID="gvGoods" runat="server" Width="100%" SkinID="GridViewAA" AutoGenerateColumns="False" EmptyDataText="No Data Found." PageSize="20" HorizontalAlign="Center" ShowFooter="True">
                                                    <Columns>
                                                       <%-- <asp:BoundField HeaderText="Remarks" Visible="False" DataField="Item_Desc" HtmlEncode="false">                                                            
                                                            <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                        </asp:BoundField>--%>

                                                        <asp:BoundField HeaderText="Description" DataField="Item_Desc" HtmlEncode="false" >
                                                            <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                        </asp:BoundField>



<%--                                                        <asp:TemplateField HeaderText="Description" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldesc" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="50%" ></ItemStyle>
                                                        </asp:TemplateField>--%>

                                                        
                                                        <asp:TemplateField HeaderText="Unit">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblunit" runat="server" Text='<%#Bind("Unit") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Quantity">
                                                            <ItemTemplate>
                                                                <asp:Label Style="text-align: center" ID="lblqty" runat="server" Text='<%#Bind("Quantity") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Price">
                                                            <FooterTemplate>
                                                                <strong>TOTAL :</strong>
                                                            </FooterTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox Style="text-align: right" ID="txtcost" runat="server" Width="120px" Text='<%#Bind("UnitPrice", "{0:N}") %>' ReadOnly="True" OnTextChanged="txtcost_TextChanged"></asp:TextBox>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right"></FooterStyle>

                                                            <HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Amount">
                                                            <FooterTemplate>
                                                                <asp:Label Style="text-align: right" ID="lbltotal" runat="server" Width="100px" CssClass="text" Text='<%# Bind("total", "{0:N}") %>'></asp:Label>
                                                            </FooterTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label Style="text-align: right" ID="lbltotal" runat="server" Text='<%# Bind("Total", "{0:N}") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right" Wrap="True" Font-Bold="False"></FooterStyle>

                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Remarks" Visible="False" >
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Wrap="True"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnDetail" runat="server" Text="+" EnableTheming="True"></asp:Button>
                                                                
                                                                <asp:Panel ID="pnlDetail" runat="server" Width="400px" BackColor="White" BorderStyle="Solid" BorderColor="#5c85d6" BorderWidth="2px">
                                                                    <table style="width: 100%; text-align: center">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td style="width: 100%">
                                                                                    <asp:TextBox ID="txtremarks" runat="server" Width="98%" Text='<%#Bind("remarks") %>' CssClass="txtbox_Remarks" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%">
                                                                                    <asp:Button ID="Button6" runat="server" CssClass="CSButton" Width="100px" Text="OK"></asp:Button></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </asp:Panel>

                                                                <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnDetail" PopupControlID="pnlDetail" CancelControlID="Button6" DynamicServicePath="" BackgroundCssClass="modalBackground">
                                                                </cc1:ModalPopupExtender>
                                                            </ItemTemplate>

                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>

                                                    <FooterStyle BackColor="#2977DC"></FooterStyle>

                                                    <HeaderStyle BackColor="#2977DC" Font-Names="Arial" Font-Size="8pt" ForeColor="White"></HeaderStyle>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:View>
                                <asp:View ID="vwGasoline" runat="server">
                                    <asp:GridView ID="gvProject" runat="server" Width="99%" SkinID="GridViewAA" AutoGenerateColumns="False" ShowFooter="True" UseAccessibleHeader="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTitle" runat="server" Text='<%# CheckIfTitleExists(Eval("rc_name").ToString()) %>'></asp:Label>
                                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Item_Desc") %>'></asp:Label>
                                                            
                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                                <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Description" HeaderText="Unit">
                                                <FooterStyle HorizontalAlign="Right"></FooterStyle>

                                                <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTitle2" runat="server" Text='<%# CheckIfTitleExists2(Eval("rc_name").ToString()) %>'></asp:Label><asp:Label
                                                        ID="Label4" runat="server" Text='<%# Eval("total", "{0:N}") %>'></asp:Label>

                                                </ItemTemplate>

                                                <FooterStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False"></FooterStyle>

                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>

                                        <FooterStyle BackColor="#2977DC"></FooterStyle>

                                        <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                                    </asp:GridView>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Approved By :</span>
                            <asp:DropDownList ID="ddApprovedBy" runat="server" Width="300px" OnSelectedIndexChanged="ddApprovedBy_SelectedIndexChanged" CssClass="drpdownCSS"></asp:DropDownList>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                     <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:HiddenField ID="hfPOHdr_ID" runat="server" />

                            <asp:Button ID="btnsave" OnClick="btnsave_Click" runat="server" CssClass="CSButton" Width="150px" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnReturn" OnClick="btnReturn_Click" runat="server" Visible="false" CssClass="CSButton" Width="150px" Text="RETURN" OnClientClick="StartProgressBar();" Enabled="False"></asp:Button>
                            &nbsp;<asp:Button ID="btnpreview" OnClick="btnpreview_Click" runat="server" CssClass="CSButton" Width="150px" Text="PREVIEW CONTRACT"></asp:Button>
                            &nbsp;<asp:Button ID="btnpreviewPO" OnClick="btnpreviewPO_Click" runat="server" CssClass="CSButton" Width="150px" Text="PREVIEW PO"></asp:Button>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" TargetControlID="btnReturn" ConfirmText="Are you sure you want to return this transaction in abstract approval?"></cc1:ConfirmButtonExtender>
                            
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
                </table>
            </div>

            
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
        
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

