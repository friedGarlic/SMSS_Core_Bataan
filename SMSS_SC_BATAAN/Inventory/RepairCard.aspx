<%@ Page Title="Repair Card" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RepairCard.aspx.vb" Inherits="Inventory_RepairCard"
    StylesheetTheme="SkinFile" %>


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
                        <td style="width: 98%" class="PageTitle">Property Repair Card
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
                            <span class="column_RightBold">Search :</span>
                            &nbsp;<asp:DropDownList runat="server" ID="drpSearchBy" CssClass="drpdownCSS" Width="10%" AutoPostBack="true">
                                <asp:ListItem Value="1" Text="Department" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Gen. Account"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:DropDownList runat="server" ID="drpSearch" CssClass="drpdownCSS" Width="35%" AutoPostBack="true">
                            </asp:DropDownList>
                            &nbsp;<asp:Button runat="server" ID="btnSearch" Width="12%" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdApprovedRepair" SkinID="GridViewAA" Width="80%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="15"
                                DataKeyNames="repair_hdr_id">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" CommandName="Select" Text="Select" CssClass="LinkBtnSelect" Visible='<%# Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="repair_date" DataFormatString="{0:d}" HeaderText="Date" />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="55%" DataField="RC_Name" HeaderText="Department" />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" DataField="GA_Code2" HeaderText="Account Code" />

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
                        <td style="width: 98%" class="DivTitle">List of Properties
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">

                            <asp:GridView runat="server" ID="grdPropertyList" SkinID="GridViewAA" Width="98%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="15"
                                DataKeyNames="PropertyDetai_ID,repair_hdr_id">
                            
                                <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%">
                                        <ItemTemplate>
                                             <asp:LinkButton runat="server" ID="lnkSelect" CommandName="Select" Text="Select" CssClass="LinkBtnSelect" OnClick="btnSelect_Click" Visible='<%# Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkPreview" CommandName="Select" Text="Preview" CssClass="LinkBtnSelect"  OnClick="btnPreview2_Click" Visible='<%# Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="25%" DataField="Item_Desc" HeaderText="Description" />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="PropertyNo" HeaderText="Property Number" />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" DataField="SerialNo" HeaderText="Serial / Plate Number" />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" DataField="previous_scope" HeaderText="Nature & Date Last Rendered" />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" DataField="nature_scope" HeaderText="Nature & Scope of Work to be Done" />
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
                        <td style="width: 98%" align="center">
                            <table width="80%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Date :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtDate" CssClass="txtbox_Date" Width="15%" MaxLength="10"></asp:TextBox>
                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender" TargetControlID="txtDate" PopupButtonID="txtDate" PopupPosition="BottomLeft"></cc1:CalendarExtender>
                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender" TargetControlID="txtDate" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td style="width: 20%" class="column_RightBold">Number :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtNumber" CssClass="txtbox_Var" Width="20%" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Cost of Repair :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtRepairCost" CssClass="txtbox_Amt" Width="20%" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold"></td>
                                    <td style="width: 80%" class="column_Left"></td>
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
                            <asp:Button runat="server" ID="btnSave" Text="Save" Enabled="false" CssClass="CSButton" Width="12%" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button runat="server" ID="btnPreview" Text="Preview" Enabled="false" Visible="false"  CssClass="CSButton" Width="12%" OnClientClick="StartProgressBar();" />
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
                        <td style="width: 98%; height: 30px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>


            


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

