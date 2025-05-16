<%@ Page Title="Inspection and Appraisal" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Disposal_InspectionAppraisal.aspx.vb"
    Inherits="Inventory_Disposal_Disposal_InspectionAppraisal" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript"> 
        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) {
                return false;
            }
        }
        document.onkeypress = stopRKey;
    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">INSPECTION AND APPRAISAL (INVENTORY AND INSPECTION REPORT OF UNSERVICEABLE PROPERTIES)
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
                        <td style="width: 98%" align="center">
                            <table cellpadding="0px" cellspacing="0px" width="100%">
                                <tr>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab1_Inspection" Width="100%" Text="Inspection" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab2_Appraisal" Width="100%" Text="Appraisal" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 60%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="3" class="PanelTabs">
                                        <asp:MultiView runat="server" ID="mvTabs">

                                            <asp:View runat="server" ID="vwTab1_Inspection">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:RadioButtonList ID="rbChoice" runat="server" Width="30%" CssClass="rbCS_Horizontal" AutoPostBack="True" RepeatDirection="Horizontal" Enabled="false">
                                                                <asp:ListItem Selected="True" Value="1">Properties</asp:ListItem>
                                                                <asp:ListItem Value="2">Supplies</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:MultiView ID="mvCategory" runat="server">
                                                                <asp:View ID="vwProperty" runat="server">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td style="width: 100%" class="DivTitle">List Of Transactions
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100%" align="center">
                                                                                <asp:GridView ID="grdInspection" runat="server" Width="80%" SkinID="GridViewAA" PageSize="5" AllowPaging="True" EmptyDataText="No Data Found."
                                                                                    DataKeyNames="IIRUPHdr_ID,IIRUP_Date">
                                                                                    <Columns>
                                                                                        <asp:TemplateField ShowHeader="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CssClass="LinkBtnSelect" Text="Select" Visible='<%# Bind("isVisible") %>' CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" Font-Underline="False" ForeColor="Blue" Width="10%"></ItemStyle>
                                                                                        </asp:TemplateField>

                                                                                        <asp:BoundField DataField="IIRUPHdr_ID" HeaderText="Transaction No.">
                                                                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                                        </asp:BoundField>

                                                                                        <asp:BoundField DataField="IIRUP_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date" HtmlEncode="False">
                                                                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                                        </asp:BoundField>

                                                                                        <asp:BoundField DataField="RC_Name" HeaderText="Department" HtmlEncode="False">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                                                                        </asp:BoundField>
                                                                                    </Columns>

                                                                                    <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100%" class="DivTitle">List Of Properties
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100%" align="center">
                                                                                <asp:GridView ID="grdInspection_Items" runat="server" Width="98%" SkinID="GridViewAA" EmptyDataText="No Data Found." AllowPaging="false"
                                                                                    DataKeyNames="Property_ID,Item_Desc,propertyNo">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="Item_Desc" HeaderText="Description" HtmlEncode="false">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                                                                        </asp:BoundField>

                                                                                        <asp:BoundField DataField="propertyNo" HeaderText="Property Number">
                                                                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                                        </asp:BoundField>

                                                                                        <asp:TemplateField HeaderText="Mode of Disposal">
                                                                                            <ItemTemplate>
                                                                                                <asp:DropDownList ID="ddMD" runat="server" Width="99%" CssClass="drpdownCSS" Visible='<%# Bind("isVisible") %>' AutoPostBack="True" OnSelectedIndexChanged="ddMD_SelectedIndexChanged">
                                                                                                    <asp:ListItem Selected="True" Value="0">--SELECT--</asp:ListItem>
                                                                                                    <asp:ListItem Value="1">Public Auction</asp:ListItem>
                                                                                                    <asp:ListItem Value="2">Private Sale</asp:ListItem>
                                                                                                    <asp:ListItem Value="3">Destroy</asp:ListItem>
                                                                                                    <asp:ListItem Value="4">Donation</asp:ListItem>
                                                                                                    <asp:ListItem Value="5">Cancel</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" Width="13%"></ItemStyle>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Appraised Value">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox DataFormatString="{0:N}" ID="txtappraisedval" Enabled="false" Visible='<%# Bind("isVisible") %>' Text="0.00" runat="server" Width="95%" CssClass="txtbox_Amt" AutoPostBack="True" OnTextChanged="txtappraisedval_TextChanged"></asp:TextBox>
                                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtappraisedval" ValidChars="0123456789.,">
                                                                                                </cc1:FilteredTextBoxExtender>
                                                                                            </ItemTemplate>

                                                                                            <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                                                        </asp:TemplateField>


                                                                                        <asp:BoundField DataFormatString="{0:N}" DataField="Cost" HeaderText="Acquired Cost">

                                                                                            <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                                                                        </asp:BoundField>

                                                                                        <asp:TemplateField HeaderText="Weight">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtWeight" runat="server" Text="0" Width="85%" CssClass="txtbox_Amt" Visible='<%# Bind("isVisible") %>' OnTextChanged="txtWeight_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtWeight" ValidChars="0123456789,.">
                                                                                                </cc1:FilteredTextBoxExtender>
                                                                                            </ItemTemplate>

                                                                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Current Amount">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtCurAmnt" DataFormatString="{0:N}" Text="0.00" runat="server" Width="95%" Visible='<%# Bind("isVisible") %>' CssClass="txtbox_Amt" AutoPostBack="True" OnTextChanged="txtCurAmnt_TextChanged"></asp:TextBox>
                                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtCurAmnt" ValidChars="0123456789.,">
                                                                                                </cc1:FilteredTextBoxExtender>
                                                                                            </ItemTemplate>

                                                                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100%">
                                                                                <asp:TextBox ID="txtdate" runat="server" Width="100px" Visible="False" SkinID="text" ReadOnly="True"></asp:TextBox>
                                                                                <asp:DropDownList ID="ddInspector" runat="server" Width="285px" Visible="False">
                                                                                </asp:DropDownList>
                                                                                <asp:DropDownList ID="ddappraiser" runat="server" Width="285px" Visible="False">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:View>





                                                                <asp:View ID="vwSupply" runat="server">
                                                                    <%-- <table style="width: 100%">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td style="width: 100%" class="TitleBar">SUPPLIES</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%" align="center">
                                                                                    <asp:GridView ID="grdSupply" runat="server" Width="70%" SkinID="GridViewAA" PageSize="5" AllowPaging="True" EmptyDataText="No Data Found."
                                                                                        DataKeyNames="IIRUS_ID,IIRUS_Date" >
                                                                                        <Columns>
                                                                                            <asp:TemplateField ShowHeader="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                                                        Font-Underline="True" CssClass="LinkBtnSelect" Text="Select"></asp:LinkButton>

                                                                                                </ItemTemplate>

                                                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="IIRUS_ID" HeaderText="TransactionID">
                                                                                                <ItemStyle HorizontalAlign="Center" Width="40%"></ItemStyle>
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="IIRUS_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date" HtmlEncode="False">
                                                                                                <ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
                                                                                            </asp:BoundField>
                                                                                        </Columns>

                                                                                        <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%" align="center">
                                                                                    <asp:GridView Style="font-weight: normal" ID="grdSupplyInfo" runat="server" Width="98%" Font-Size="9pt" SkinID="GridViewAA" DataKeyNames="StockID" AutoGenerateColumns="False" EmptyDataText="No Data Found." __designer:wfdid="w11">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                                                                <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                            </asp:BoundField>
                                                                                            <asp:TemplateField HeaderText="Mode of Disposal">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                                                                                                </EditItemTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:DropDownList ID="ddDispose" runat="server" Width="99%" AutoPostBack="True" OnSelectedIndexChanged="ddDispose_SelectedIndexChanged">
                                                                                                        <asp:ListItem Selected="True" Value="0">--SELECT--</asp:ListItem>
                                                                                                        <asp:ListItem Value="1">Public Auction</asp:ListItem>
                                                                                                        <asp:ListItem Value="2">Private Sale</asp:ListItem>
                                                                                                        <asp:ListItem Value="3">Destroy</asp:ListItem>
                                                                                                        <asp:ListItem Value="4">Donation</asp:ListItem>
                                                                                                        <asp:ListItem Value="5">Cancel</asp:ListItem>
                                                                                                    </asp:DropDownList>
                                                                                                </ItemTemplate>

                                                                                                <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Appraised Value">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AppraisedVal") %>'></asp:TextBox>

                                                                                                </EditItemTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox Style="text-align: right" ID="txtappraisedval" runat="server" Width="95%" AutoPostBack="True" OnTextChanged="txtappraisedval_TextChanged1">0.00</asp:TextBox>
                                                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtappraisedval" ValidChars="0123456789.,">
                                                                                                    </cc1:FilteredTextBoxExtender>
                                                                                                </ItemTemplate>

                                                                                                <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="StockID">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:TextBox runat="server" Text='<%# Bind("StockID") %>' ID="TextBox3"></asp:TextBox>
                                                                                                </EditItemTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblStockID" runat="server" Text='<%# Bind("StockID") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>--%>
                                                                </asp:View>

                                                            </asp:MultiView>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">Signatories / Details
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="90%">
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Date :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox ID="txtOpenDate" runat="server" Width="120px" CssClass="txtbox_Date" AutoPostBack="true"></asp:TextBox>
                                                                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtOpenDate" PopupButtonID="txtOpenDate" Enabled="True"></cc1:CalendarExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">IIRUP Number :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox ID="txtIIRUP_No" runat="server" Width="20%" CssClass="txtbox_Var"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trWrhseLoc" runat="server">
                                                                    <td style="width: 30%" class="column_RightBold">Warehouse Location :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox ID="txtWrhseLocation" runat="server" Width="50%" CssClass="txtbox_Var"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trParticulars" runat="server">
                                                                    <td style="width: 30%" class="column_RightBold">Particulars :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox ID="txtParticulars" runat="server" Height="50px" Width="50%" TextMode="MultiLine" CssClass="txtbox_Remarks"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trHRUnserviceable" runat="server">
                                                                    <td style="width: 30%" class="column_RightBold">How Rendered Unserviceable :</td>
                                                                    <td style="width: 70%;" class="column_Left">
                                                                        <asp:TextBox ID="txtHRUnserviceable" runat="server" Width="50%" CssClass="txtbox_Var"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Requested By :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:DropDownList ID="ddRequestedBy" runat="server" Width="50%" CssClass="drpdownCSS">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Inspected By :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:DropDownList ID="ddInspectedby" runat="server" Width="50%" CssClass="drpdownCSS"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Witness By :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:DropDownList ID="ddWitnessBy" runat="server" Width="50%" CssClass="drpdownCSS">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Approved By :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:DropDownList ID="ddApprovedBy" runat="server" Width="50%" CssClass="drpdownCSS">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>

                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button ID="btnSave_Inspection" runat="server" Width="12%" CssClass="CSButton" Text="SAVE" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                                                            &nbsp;<asp:Button ID="btnPreview_IIRUP" runat="server" Width="12%" CssClass="CSButton" Text="IIRUP" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 20px" align="center"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>


                                            <asp:View runat="server" ID="vwTab2_Appraisal">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdDisposalAppraisal" Width="85%" SkinID="GridViewAA" AllowPaging="true" PageSize="10" EmptyDataText="No Data Found."
                                                                DataKeyNames="IIRUPHdr_ID,WMHdr_ID">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkSelect_Appraisal" CssClass="LinkBtnSelect" Text="Select" Visible='<%# Bind("isVisible") %>' CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField DataField="IIRUP_Date" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" HeaderText="IIRUP Date / WMR Date" />
                                                                    <asp:BoundField DataField="IIRUP_No" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" HeaderText="IIRUP No. / WMR No." />
                                                                    <asp:BoundField DataField="particulars" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50%" HeaderText="Particulars" />
                                                                    <asp:BoundField DataField="AppraisedVal" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%" HeaderText="Appraised Value" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">Report Details
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <div class="borderCSS" style="align-content: center; width: 90%">
                                                                <table width="98%">
                                                                    <tr>
                                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" align="left">
                                                                            <span class="CalendarFormat">ANNEX E
                                                                               <br>
                                                                                APPRAISAL OF GOVERNMENT
                                                                               <br>
                                                                                PROPERTIES EXCEPT REAL ESTATE,
                                                                               <br>
                                                                                ANTIQUE PROPERTY AND WORKS OF ART
                                                                            </span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" class="column_CenterBold">Republic of the Philippines
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" class="column_Center">Provincial Government of Cagayan
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" class="column_CenterBold">
                                                                            APPRAISAL REPORT
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <span class="column_RightBold">Date :</span>
                                                                            &nbsp;<asp:TextBox runat="server" ID="txtAppraisalDate" CssClass="txtbox_Date" Width="15%" MaxLength="10"></asp:TextBox>
                                                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender_Appraised" TargetControlID="txtAppraisalDate" PopupButtonID="txtAppraisalDate" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender_Appraised" TargetControlID="txtAppraisalDate" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%; height: 20px" align="center"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" class="column_LeftBold">Subject :
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox runat="server" ID="txtSubject" CssClass="txtbox_Remarks" Width="90%" Height="50px" TextMode="MultiLine">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" class="column_LeftBold">Findings / Observations :</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox runat="server" ID="txtFindings" CssClass="txtbox_Remarks" Width="90%" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" class="column_CenterBold">Note : With individual Checklist and pictures hereto attached.</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" class="column_LeftBold">Valuation Procedures / Consideration :</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox runat="server" ID="txtValuation" CssClass="txtbox_Remarks" Width="90%" Height="80px" TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:GridView runat="server" ID="grdAppraisal_Items" Width="80%" SkinID="GridViewAA" EmptyDataText="No Data Found." AllowPaging="false"
                                                                                DataKeyNames="IIRUPDtl_ID" Visible="false">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="ID" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" HeaderText="No." />
                                                                                    <asp:BoundField DataField="Item_Desc" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80%" HeaderText="Description" />
                                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" HeaderText="Appraised Value">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox runat="server" ID="txtAppraisedValue" CssClass="txtbox_Amt" Width="80%" Text="0.00" AutoPostBack="true" OnTextChanged="txtAppraisedValue_TextChanged"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label runat="server" ID="lblTotalAppraisedValue"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" align="left">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td style="width: 100%" class="column_LeftBold">Prepared By :
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 100%; height: 10px"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 100%" class="column_Left">
                                                                                        <span class="column_RightBold">Name : </span>
                                                                                        &nbsp;<asp:TextBox runat="server" ID="txtAppraise_PreparedBy" Width="25%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                        &nbsp;&nbsp;<span class="column_RightBold">Designation : </span>
                                                                                        &nbsp;<asp:TextBox runat="server" ID="txtAppraise_PreparedByPos" Width="25%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 100%" class="column_Left">
                                                                                        <span class="column_RightBold">Name : </span>
                                                                                        &nbsp;<asp:TextBox runat="server" ID="txtAppraise_PreparedBy2" Width="25%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                        &nbsp;&nbsp;<span class="column_RightBold">Designation : </span>
                                                                                        &nbsp;<asp:TextBox runat="server" ID="txtAppraise_PreparedByPos2" Width="25%" CssClass="txtbox_Var"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 100%" class="column_Left">
                                                                                        <span class="column_RightBold">Name : </span>
                                                                                        &nbsp;<asp:TextBox runat="server" ID="txtAppraise_PreparedBy3" Width="25%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                        &nbsp;&nbsp;<span class="column_RightBold">Designation : </span>
                                                                                        &nbsp;<asp:TextBox runat="server" ID="txtAppraise_PreparedByPos3" Width="25%" CssClass="txtbox_Var"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%; height: 30px" align="center"></td>
                                                                    </tr>
                                                                </table>
                                                            </div>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 20px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnSave_Appraisal" Enabled="false" CssClass="CSButton" Width="15%" Text="Save and Preview" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 20px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>


                                        </asp:MultiView>
                                    </td>
                                </tr>
                            </table>

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
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>

            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

