<%@ Page Title="Import New Items" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="upload_newitems.aspx.vb"
    Inherits="filemaintenance_upload_newitems" EnableEventValidation="false" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">






</script>



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



    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">UPLOAD NEW ITEMS
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <table width="90%">
                        <tr>
                            <td style="width: 20%" class="column_RightBold">Calendar Year :</td>
                            <td style="width: 80%" class="column_Left">
                                <asp:DropDownList runat="server" ID="drpYear" Width="30%"  CssClass="drpdownCSS">
                                    <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" class="column_RightBold">Allotment Type :
                            </td>
                            <td style="width: 80%" class="column_Left">
                                <asp:DropDownList runat="server" ID="drpAllotment" Width="30%"  CssClass="drpdownCSS" AutoPostBack="true" >
                                       <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="MOOE" ></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Capital Outlay"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                            <td style="width: 20%" class="column_RightBold">Classification :
                            </td>
                            <td style="width: 80%" class="column_Left">
                                <asp:DropDownList runat="server" ID="DdClassF" Width="30%" CssClass="drpdownCSS" AutoPostBack="true" OnSelectedIndexChanged="DdClassF_SelectedIndexChanged">
                                     <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                            <td style="width: 20%" class="column_RightBold">Sub Classification :
                            </td>
                            <td style="width: 80%" class="column_Left">
                                <asp:DropDownList runat="server" ID="DdSubClassF" Width="30%" CssClass="drpdownCSS" AutoPostBack="true">
                                     <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" class="column_RightBold">General Account :</td>
                            <td style="width: 80%" class="column_Left">
                                <asp:DropDownList runat="server" ID="drpGenAccount" Width="60%" CssClass="drpdownCSS">
                                    <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="CSButton" Text="Create Template" />
                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
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
                <td style="width: 98%" align="center">
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="txtbox_Var" Height="21px" Width="40%" />
                    &nbsp;<asp:Button ID="btnUpload" runat="server" Text="Upload" Width="12%" CssClass="CSButton" />
                </td>
                <td style="width: 1%"></td>
            </tr>
            <%-- <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <asp:Label ID="Label1" runat="server" Text="Has Header ?" CssClass="rbCS_Horizontal" Visible="false"></asp:Label><br />
                    <asp:RadioButtonList ID="rbHDR" runat="server" RepeatLayout="Flow" CssClass="rbCS_Vertical" Visible="false">
                        <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:GridView ID="grdItems" SkinID="GridViewAA" runat="server" Width="95%" PageSize="10" AllowPaging="true">
                        <Columns>
                            <asp:BoundField HeaderText="Particular" DataField="Particular" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="Item Description" DataField="Item_Desc" ItemStyle-Width="55%" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="Unit" DataField="UnitDesc" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="Unit Price" DataField="Cost" DataFormatString="{0:N}" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Right" />

                        </Columns>
                    </asp:GridView>
                </td>
                <td style="width: 1%"></td>
            </tr>--%>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    &nbsp;</td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%"></td>
                <td style="width: 1%"></td>
            </tr>
        </table>
    </div>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Label ID="Label1" runat="server" Text="Has Header ?" CssClass="rbCS_Horizontal" Visible="false"></asp:Label><br />
                            <asp:RadioButtonList ID="rbHDR" runat="server" RepeatLayout="Flow" CssClass="rbCS_Vertical" Visible="false">
                                <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:GridView ID="grdItems" SkinID="GridViewAA" runat="server" Width="95%" PageSize="20" AllowPaging="true" EmptyDataText="No Data Found.">
                                <Columns>
                                    <asp:BoundField HeaderText="Particular" DataField="Particular" ItemStyle-Width="13%" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField HeaderText="Sub Category" DataField="SubCat_Desc" ItemStyle-Width="13%" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField HeaderText="Item Code" DataField="Item_Code" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField HeaderText="Item Description" DataField="Item_Desc" ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField HeaderText="Unit" DataField="UnitDesc" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField HeaderText="Unit Price" DataField="Cost" DataFormatString="{0:N}" ItemStyle-Width="12%" ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Useful Life" DataField="Useful_Life" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button runat="server" ID="btnSave" CssClass="CSButton" Width="12%" Text="Save" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button runat="server" ID="btnCancel" CssClass="CSButton" Width="12%" Text="Cancel" OnClientClick="StartProgressBar();" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 20px"></td>
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

