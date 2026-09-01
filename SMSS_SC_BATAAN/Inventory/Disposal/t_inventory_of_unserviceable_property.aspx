<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="t_inventory_of_unserviceable_property.aspx.vb" Inherits="t_inventory_of_unserviceable_property"
    Title="Inventory Of Unserviceable Property" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">INVENTORY OF UNSERVICEABLE PROPERTY
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="100%">
                                <tr>
                                    <td style="width: 10%" class="column_RightBold">Goods :</td>
                                    <td style="width: 20%" align="left">
                                        <asp:RadioButtonList ID="rbChoice" runat="server" Width="220px" CssClass="rbCS_Horizontal" OnSelectedIndexChanged="rbChoice_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Properties</asp:ListItem>
                                            <asp:ListItem Value="2">Supplies</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 70%" align="right">
                                        <span class="column_RightBold">Date :</span>
                                        &nbsp;<asp:TextBox ID="txtdate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>

                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr style="display:none;">
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List of Goods
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                              <asp:MultiView ID="mvUncerviceable" runat="server">
                                <asp:View ID="vwProperty" runat="server">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle" align="center">PROPERTIES</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                      <table width="100%">
                                                            <tr>
                                                                <td style="width: 1%"></td>
                                                                <td style="width: 98%" align="center">
                                <span class="column_RightBold">Description :</span>
                                &nbsp;<asp:TextBox runat="server" ID="txtSearchDesc" Width="250px" CssClass="txtbox_Var"></asp:TextBox>
                                &nbsp;<asp:Button runat="server" ID="btnSearchDesc" Width="150px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"/>
                            </td>
                                                                <td style="width: 1%"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 1%"></td>
                                                                <td style="width: 98%" align="center">
                                                                    <asp:GridView ID="gvitems" runat="server" Width="98%" SkinID="GridViewAA" CssClass="text" DataKeyNames="PropertyNo"
                                                                        AutoGenerateColumns="False" BackColor="White" PageSize="5" AllowPaging="True" OnPageIndexChanging="gvitems_PageIndexChanging1">
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="CheckBox2" runat="server" Width="50px" Font-Bold="True" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" Text="All" AutoPostBack="True" Visible="False" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="CheckBox1" runat="server" Width="50px" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                            </asp:TemplateField>

                                                                            <asp:BoundField DataField="item_desc" HeaderText="Description">
                                                                                <ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="PropertyNo" HeaderText="Property Number">
                                                                                <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Property_ID">
                                                                                <ItemStyle></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="cost" HeaderText="Cost"></asp:BoundField>
                                                                            <asp:BoundField DataField="Property_Date" HeaderText="Property_Date"></asp:BoundField>
                                                                            <asp:BoundField DataField="id" HeaderText="id"></asp:BoundField>
                                                                            <asp:BoundField DataField="RC_ID" HeaderText="RC_ID"></asp:BoundField>
                                                                            <asp:BoundField DataField="FUNCTION_ID" HeaderText="FUNCTION_ID"></asp:BoundField>
                                                                        </Columns>
                                                                    </asp:GridView>

                                                                </td>
                                                                <td style="width: 1%"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 1%"></td>
                                                                <td style="width: 98%" align="center">
                                                                    <asp:Button ID="btnload" runat="server" Width="150px" CssClass="CSButton" Text="ADD ITEM"></asp:Button>
                                                                </td>
                                                                <td style="width: 1%"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 1%"></td>
                                                                <td style="width: 98%" class="DivTitle">Goods For Disposal
                                                                </td>
                                                                <td style="width: 1%"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 1%"></td>
                                                                <td style="width: 98%" align="center">
                                                                    <asp:GridView  ID="gvbody" runat="server" Width="98%" SkinID="GridViewAA" EmptyDataText="No Data Found." AutoGenerateColumns="False" 
                                                                        DataKeyNames="Property_ID,item_desc,propertyno">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="Item_desc" HeaderText="Description">
                                                                                <ItemStyle HorizontalAlign="Left" Width="55%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="propertyNo" HeaderText="Property Number">
                                                                                <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Unit Cost" HtmlEncode="False">
                                                                                <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Adep" DataFormatString="{0:N}" HeaderText="Accumulated  Depreciation" HtmlEncode="False">
                                                                                <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="netval" DataFormatString="{0:N}" HeaderText="Net Book Value" HtmlEncode="False">
                                                                                <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                                <td style="width: 1%"></td>
                                                            </tr>
                                                       </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwSupply" runat="server">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle" align="center">SUPPLIES</td>
                                            </tr>
                                             <tr>
                                                <td style="width: 100%" align="center"> <asp:Button ID="btnadd" OnClick="btnadd_Click" runat="server" CssClass="CSButton"   Width="200px" Text="ADD ITEM" SkinID="ButtonImage"></asp:Button>
                                                 </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView Style="font-weight: normal" ID="grdSupply" runat="server" Width="95%" SkinID="GridViewAA" EmptyDataText="No Data Found." AutoGenerateColumns="False" DataKeyNames="Item_ID,balance,StockID,StockDate,cost" Font-Size="9pt">
                                                        <Columns>
                                                            <asp:BoundField DataField="Item_desc" HeaderText="Item Description">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Left" Width="65%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Quantity">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox runat="server" Text='<%# Bind("propertyNo") %>' ID="TextBox1"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtqty" runat="server" Width="95%" Text='<%# Bind("balance") %>' CssClass="txtboxAmount" AutoPostBack="True" OnTextChanged="txtqty_TextChanged"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtqty" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                                                </ItemTemplate>

                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Unit Cost" HtmlEncode="False">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox runat="server" Text='<%# Bind("Balance") %>' ID="TextBox2"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBalance" runat="server" Text='<%# Bind("Balance", "{0:N}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                           
                                        </tbody>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
                           
                          

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
                            <asp:Button ID="btnsave" runat="server" Width="150px" CssClass="CSButton" Enabled="False" OnClientClick="StartProgressBar();" ValidationGroup="save" SkinID="ButtonImage" Text="SAVE"></asp:Button>
                            &nbsp;<asp:Button ID="btnpreview" runat="server" Width="150px" CssClass="CSButton" Enabled="False" SkinID="ButtonImage" Text="PREVIEW ITB" Visible ="false"></asp:Button>
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
                        <td style="width: 98%">

                            <asp:Button ID="btnnew" runat="server" Text="NEW" SkinID="ButtonImage" Visible="False"></asp:Button>
                            <asp:Button ID="btnopen" runat="server" Text="OPEN" SkinID="ButtonImage" Visible="False"></asp:Button>

                           <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnsave" ConfirmText="Are you sure you want to save this transaction?">
                            </cc1:ConfirmButtonExtender>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>





            <asp:Panel Style="display: none" ID="popup" runat="server" Width="900px">
                <table id="TablepopUP"  cellspacing="0" cellpadding="0" width="747" border="0">
                    <tbody>
                        <tr>
                            <td colspan="2">
                              <%--  <img height="1" alt="" src="../images/modalpopup_01.png" width="747" />--%>

                            </td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../../images/modalpopup_02.png); width: 772px; height: 39px"></td>
                            <td style="width: 46px; height: 39px">
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/modalpopup_03.png"></asp:ImageButton></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../../images/modalpopup_04.png); vertical-align: top; width: 772px; height: 451px" id="Td3">
                                <table style="width: 705px; height: 336px" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="vertical-align: top; width: 4%; height: 398px; text-align: center"></td>
                                            <td style="vertical-align: top; width: 100%; height: 398px; text-align: center">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <table style="width: 100%" class="text" cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100%" colspan="3">
                                                                        <table style="width: 100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 20%" class="column_RightBold">Search : </td>
                                                                                    <td style="width: 80%" class="text5">
                                                                                        <asp:TextBox ID="txtSearch" runat="server" Width="70%" CssClass="text"></asp:TextBox><asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Width="100px" OnClientClick="StartProgressBar();" Text="SEARCH"></asp:Button></td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <asp:DropDownList ID="ddopen" runat="server" Width="146px" CssClass="text" Visible="False">
                                                                            <asp:ListItem Value="PropertyNo">Property Number</asp:ListItem>
                                                                            <asp:ListItem Value="Item_Desc">Article</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:Label ID="lblProperty" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 4%; text-align: center"></td>
                                            <td style="width: 100%; text-align: center"></td>
                                        </tr>
                                    </tbody>
                                </table></td>
                            <td style="background-image: url(../../images/modalpopup_05.png); width: 46px; height: 451px"></td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>






            <asp:Panel Style="display: none" ID="Panel4" runat="server" Width="730px" CssClass="Panel_Popup">
                <table id="Table1" height="200" cellspacing="0" cellpadding="0" width="747" border="0">
                    <tbody>
                        <tr>
                            <%--<td colspan="2">
                                <img height="1" alt="" src="../images/modalpopup_01.png" width="747" />

                            </td>--%>
                        </tr>
                        <tr>
                            <td style="width: 772px; "></td>
                            <td style="width: 46px; ">
                                <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/modalpopup_03.png"></asp:ImageButton></td>--%>
                        </tr>
                        <tr>
                            <td style=" vertical-align: top; width: 772px; " id="Td1">
                                <table style="width: 705px; height: 336px" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="vertical-align: top; width: 4%;  text-align: center"></td>
                                            <td style="vertical-align: top; width: 100%;  text-align: center">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <table style="width: 100%" class="text" cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100%" colspan="3">
                                                                        <table style="width: 100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 20%" class="column_RightBold">Search : </td>
                                                                                    <td style="width: 80%" class="text5">
                                                                                        <asp:TextBox ID="txtSupSearch" runat="server" Width="70%" CssClass="text"></asp:TextBox><asp:Button ID="btnSupSearch" CssClass="CSButton" OnClick="btnSupSearch_Click" runat="server" Width="100px" OnClientClick="StartProgressBar();" Text="SEARCH"></asp:Button></td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <asp:GridView Style="text-align: left" ID="gvSupItems" runat="server" Width="100%" SkinID="GridViewAA" CssClass="text" AutoGenerateColumns="False" EmptyDataText="No Data Found." BackColor="White" PageSize="8" AllowPaging="True" OnPageIndexChanging="gvSupItems_PageIndexChanging" Font-Size="9pt">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                                                                    </EditItemTemplate>
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="cbAllSupp" runat="server" Width="50px" Font-Bold="True" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" AutoPostBack="True" Text="All" Visible="False" OnCheckedChanged="cbAllSupp_CheckedChanged"></asp:CheckBox>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbSupp" runat="server" Width="50px" AutoPostBack="True" OnCheckedChanged="cbSupp_CheckedChanged"></asp:CheckBox>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="item_desc" HeaderText="Article">
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                    <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="balance" HeaderText="Quantity">
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                    <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="cost" HeaderText="Cost">
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                    <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Item_ID" HeaderText="Item_ID"></asp:BoundField>
                                                                <asp:BoundField DataField="StockID" HeaderText="StockID"></asp:BoundField>
                                                                <asp:BoundField DataField="StockDate" HeaderText="StockDate"></asp:BoundField>
                                                                <asp:BoundField DataField="ID" HeaderText="ID"></asp:BoundField>
                                                                <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                                    <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                </asp:BoundField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:Label ID="lblSupply" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 4%; text-align: center"></td>
                                            <td style="width: 100%; text-align: center">
                                                <asp:Button ID="btnLoadSupp" OnClick="btnLoadSupp_Click" runat="server" Width="150px" Text="LOAD" CssClass="CSButton"></asp:Button></td>
                                        </tr>
                                    </tbody>
                                </table>
                                &nbsp;</td>
                            <td style=" width: 46px; "></td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground" CancelControlID="ImageButton2" PopupControlID="popup" TargetControlID="lblProperty"></cc1:ModalPopupExtender>
            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" BackgroundCssClass="modalBackground" CancelControlID="ImageButton3" PopupControlID="Panel4" TargetControlID="lblSupply"></cc1:ModalPopupExtender>
           



            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

