<%@ Page Title="Waste Marials Report" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Disposal_WasteMaterials.aspx.vb"
    Inherits="Inventory_Disposal_Disposal_WasteMaterials" StylesheetTheme="SkinFile" %>

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


        function toPeso(objctrl) {
            //Get the Entered Value
            var number = objctrl.value.toString(),
                //Split the number between WholeNumber and Decimals
                php = number.split('.')[0], cents = (number.split('.')[1] || '') + '00';
            php = php.split('').reverse().join('').replace(/(\d{3}(?!$))/g, '$1,').split('').reverse().join('');
            //Concatenate the number 
            objctrl.value = php + '.' + cents.slice(0, 2);
        }

        function HighlightAll(txtObj) {
            txtObj.select();
        }

    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">WASTE MATERIALS</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">

                            <table width="90%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Department :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpDepartment" CssClass="drpdownCSS" Width="95%" AutoPostBack="true">
                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Gen. Account :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpGenAccount" CssClass="drpdownCSS" Width="95%">
                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Function :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpFunction" CssClass="drpdownCSS" Width="95%">
                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:Button runat="server" ID="btnView" CssClass="CSButton" Width="35%" Text="View" OnClientClick="StartProgressBar();" />
                                    </td>
                                </tr>
                            </table>
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
                        <td style="width: 98%" class="DivTitle">List of Properties
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search By</span>
                            &nbsp;<asp:DropDownList runat="server" ID="drpSearchBy" CssClass="drpdownCSS" Width="12%">
                                <asp:ListItem Value="1" Text="Description" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="2" Text="PO Number"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<span class="column_RightBold">:</span>
                            &nbsp;<asp:TextBox runat="server" ID="txtSearch" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                            &nbsp;<asp:Button runat="server" ID="btnSearch" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdPropertyList" Width="98%" SkinID="GridViewAA" AllowPaging="true" PageSize="10" EmptyDataText="No Data Found."
                                DataKeyNames="PropertyDetai_ID,RC_ID,Function_ID,PO_No,POHdr_ID">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" CssClass="LinkBtnSelect" Text="Select" CommandName="Select" Visible='<%# Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="PO_No" HeaderText="PO Number" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="ItemDesc" HeaderText="Description" ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Left" HtmlEncode="false" />
                                    <asp:BoundField DataField="UnitDesc" HeaderText="Unit" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N}" />
                                    <asp:BoundField DataField="PropertyNo" HeaderText="Property Number" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" />

                                </Columns>
                            </asp:GridView>
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
                        <td style="width: 98%" class="DivTitle">List of Materials / Parts
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdParts" Width="80%" SkinID="GridViewAA" AllowPaging="true" PageSize="15" EmptyDataText="No Data Found."
                                DataKeyNames="parts_id,description,qty,unit,cost">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" CssClass="LinkBtnSelect" Text="Select" CommandName="Select" Visible='<%# Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-Width="52%" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="qty" DataFormatString="{0:#,##0.##}" HeaderText="Quantity" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" HeaderText="Qty for Waste">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtWasteQty" Width="90%" CssClass="txtbox_Qty" Text='<%# Bind("qty", "{0:#,##0.##}") %>' Visible='<%# Bind("isVisible") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="unit" HeaderText="Unit" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="Unit Cost" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Right" />

                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="80%">
                                <tr>
                                    <td style="width: 100%" colspan="4" class="DivTitle">Additional Parts / Materials
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Description :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtDesc" CssClass="txtbox_Var" Width="90%" Text=""></asp:TextBox>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Quantity :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtQty" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Unit :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtUnit" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Appraised Value :</td>
                                    <td style="width: 35%" class="column_Left">
                                         <asp:TextBox runat="server" ID="txtAppraisedValue" CssClass="txtbox_Amt" Width="35%" Text="0.00" onblur="toPeso(this)"></asp:TextBox>
                                        <asp:TextBox runat="server" ID="txtCost" CssClass="txtbox_Amt" Visible="false" Width="35%" Text="0.00" onblur="toPeso(this)"></asp:TextBox>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td style="width: 100%; height: 10px" colspan="4"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="4" align="center">
                                        <asp:Button runat="server" ID="btnAddParts" CssClass="CSButton" Width="15%" Text="Add Parts" Enabled="false" OnClientClick="StartProgressBar();" />
                                    </td>
                                </tr>
                            </table>
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
                        <td style="width: 98%" class="DivTitle">List of Parts for Waste
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdForWaste" Width="70%" SkinID="GridViewAA" AllowPaging="false" EmptyDataText="No Data Found."
                                DataKeyNames="">
                                <Columns>

                                    <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-Width="35%" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="qty" HeaderText="Quantity" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="unit" HeaderText="Unit" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" HeaderText="OR No.">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtOR" Width="90%" CssClass="txtbox_Var" Text='<%# Bind("OR") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtCost" Width="90%" CssClass="txtbox_Amt" Text='<%# Bind("cost", "{0:N}") %>' Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" HeaderText="Appraised Value">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtAppValue" Width="90%" CssClass="txtbox_Amt" Text='<%# Bind("AppValue", "{0:N}") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 20px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Date :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtDate" CssClass="txtbox_Date" Width="30%" MaxLength="10"></asp:TextBox>
                                        <span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender" TargetControlID="txtDate" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDate" PopupButtonID="txtDate" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Ctrl No. :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtCtrlNo" CssClass="txtbox_Var" Width="50%" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Place of Storage :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtStorage" CssClass="txtbox_Var" Width="95%"></asp:TextBox>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Dispose As :</td>
                                    <td style="width: 85%" colspan="3" class="column_Left">
                                        <asp:RadioButtonList runat="server" ID="rbDispose" CssClass="rbCS_Horizontal" Width="80%" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Text="Destroyed" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Sold at private sale"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Sold at public auction"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Transferred without cost to"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtTransfer" CssClass="txtbox_Var" Width="90%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%; height: 10px" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Certified By :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpCertifiedby" CssClass="drpdownCSS" Width="95%"></asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Approved By :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpApprovedby" CssClass="drpdownCSS" Width="95%"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Property Inspector :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpInspector" CssClass="drpdownCSS" Width="95%"></asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Witness :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtWitness" CssClass="txtbox_Var" Width="94%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                </tr>
                            </table>
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
                            <asp:Button runat="server" ID="btnSaveWaste" CssClass="CSButton" Width="12%" Text="Save" Enabled="false" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button runat="server" ID="btnPreview" CssClass="CSButton" Width="12%" Text="Preview" Enabled="false" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button runat="server" ID="btnPreview_Summary" CssClass="CSButton" Width="15%" Text="Preview Summary" Enabled="true" OnClientClick="StartProgressBar();" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 30px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>



            <asp:Panel runat="server" ID="pnlPreparedBy" Width="400px" CssClass="Panel_Popup">
                <div>
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">Prepared By
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <table width="90%">
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Name :</td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:DropDownList runat="server" ID="drpPreparedBy1" CssClass="drpdownCSS" Width="90%"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Name :</td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:DropDownList runat="server" ID="drpPreparedBy2" CssClass="drpdownCSS" Width="90%"></asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
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
                                <asp:Button runat="server" ID="btnPreview_SummaryWMR" CssClass="CSButton" Text="Preview Summary" Width="40%" OnClientClick="StartProgressBar();"/>
                                 &nbsp;<asp:Button runat="server" ID="btnCancel" CssClass="CSButton" Text="Cancel" Width="40%" OnClientClick="StartProgressBar();"/>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px">
                                <asp:Label runat="server" ID="lblpreparedby"></asp:Label>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                    </table>
                </div>

            </asp:Panel>
            <cc1:ModalPopupExtender runat="server" ID="ModalPopupExtender1" TargetControlID="lblpreparedby" PopupControlID="pnlPreparedBy" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">

                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

