<%@ Page Title="Scheduling of Inventory" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="schedulinginventorysupplies.aspx.vb"
    Inherits="Reports_and_Query_AdditionalReports_schedulinginventorysupplies" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


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
                        <td style="width: 98%" class="PageTitle">SCHEDULING OF INVENTORY
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px">

                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Department :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpDepartment" CssClass="drpdownCSS" Width="95%" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Date :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtDate" CssClass="txtbox_Date" Width="30%" MaxLength="10"></asp:TextBox>
                                        <span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtDate" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDate" PopupButtonID="txtDate" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Function :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpFunction" CssClass="drpdownCSS" Width="95%"></asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Inventory :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpInventory" CssClass="drpdownCSS" Width="32%">
                                            <asp:ListItem Value="2" Text="Supplies" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="PPE"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                    <td style="width: 15%" class="column_RightBold">Outside Office :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:CheckBox runat="server" ID="cbOutside" CssClass="rbCS_Horizontal" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 15px" colspan="4" align="center"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="4" align="center">
                                        <asp:Button runat="server" ID="btnAdd_Dept" CssClass="CSButton" Width="12%" Text="Add" OnClientClick="StartProgressBar();" />
                                        &nbsp;<asp:Button runat="server" ID="btnPreview" CssClass="CSButton" Width="12%" Text="Preview" OnClientClick="StartProgressBar();" />
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
                            <table width="95%">
                                <tr>
                                    <td style="width: 50%" align="center"></td>
                                    <td style="width: 50%" align="center"></td>
                                </tr>
                                <tr>
                                    <td style="width: 50%" align="center">
                                        <asp:GridView runat="server" ID="grdDepartments" Width="80%" SkinID="GridViewAA" EmptyDataText="No Data Found." AllowPaging="false">
                                            <Columns>
                                                <asp:BoundField DataField="Department" HeaderText="Department" ItemStyle-Width="70%" ItemStyle-HorizontalAlign="Left"/>
                                                <asp:BoundField DataField="SchedDate" HeaderText="Date" DataFormatString="{0:d}" ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Center"/>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                    <td style="width: 50%" align="center">
                                        <asp:GridView runat="server" ID="grdOutside" Width="80%" SkinID="GridViewAA" EmptyDataText="No Data Found." AllowPaging="false">
                                            <Columns>
                                                <asp:BoundField DataField="Department" HeaderText="Department" ItemStyle-Width="70%" ItemStyle-HorizontalAlign="Left"/>
                                                <asp:BoundField DataField="SchedDate" HeaderText="Date" DataFormatString="{0:d}" ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Center" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>

                            </table>


                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 30px"></td>
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp; 
       

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

