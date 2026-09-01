<%@ Page Language="VB" AutoEventWireup="false" CodeFile="prerepair_inspection.aspx.vb" Inherits="Inventory_Disposal_prerepair_inspection" MasterPageFile="~/MasterPage.master"
    StylesheetTheme="SkinFile" Title="Pre-Repair Inspection" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>



    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">PRE-REPAIR INSPECTION
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
                                        <asp:DropDownList ID="drpDepartment" runat="server" Width="95%" CssClass="drpdownCSS" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Allotment :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="drpAllotment" runat="server" CssClass="drpdownCSS" Width="50%">
                                            <asp:ListItem Value="1" Text="Capital Outlay" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Function :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="drpFunction" runat="server" Width="95%" CssClass="drpdownCSS" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">General Account :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="drpGenAccount" runat="server" CssClass="drpdownCSS" Width="95%"></asp:DropDownList>
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
                            <asp:Button runat="server" ID="btnView" CssClass="CSButton" Text="View Items" Width="15%" OnClientClick="StartProgressBar();" />
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
                        <td style="width: 98%" class="DivTitle">List of Items</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdPropertyList" SkinID="GridViewAA" Width="98%" AllowPaging="true" PageSize="15" EmptyDataText="No Data Found."
                                DataKeyNames="PropertyDetai_ID,Item_ID,prerepair_date,nature_scope,ItemDesc,UnitDesc,PropertyNo,SerialNo">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%--<asp:CheckBox runat="server" ID="cb1" Visible='<%# Bind("isVisible") %>' />--%>
                                            <asp:LinkButton runat="server" ID="lnkSelect" CssClass="LinkBtnSelect" Text="Select" CommandName="Select" OnClientClick="StartProgressBar();" Visible='<%# Bind("isVisible") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="42%" DataField="ItemDesc" HeaderText="Description" />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%" DataField="UnitDesc" HeaderText="Unit" />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="PropertyNo" HeaderText="Property No." />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" DataField="SerialNo" HeaderText="Serial No. / Plate No." />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" DataField="Property_Date" DataFormatString="{0:d}" HeaderText="Acquisition Date" />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%" DataField="Cost" DataFormatString="{0:N}" HeaderText="Acquisition Cost" />

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
                        <td style="width: 98%" class="DivTitle">For Pre-repair and Inspection</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdPreRepair" SkinID="GridViewAA" Width="98%" AllowPaging="false" EmptyDataText="No Data Found."
                                DataKeyNames="PropertyDetai_ID,Item_ID,prerepair_date,nature_scope,ItemDesc,PropertyNo,SerialNo">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkRemove" CssClass="LinkBtnCancel" Text="Remove" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30%" DataField="ItemDesc" HeaderText="Description" />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="PropertyNo" HeaderText="Property No." />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" DataField="SerialNo" HeaderText="Serial No. / Plate No." />

                                    <asp:TemplateField ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" HeaderText="Last Requested ">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtPreviousScope" CssClass="txtbox_Remarks" Width="95%" Height="50px" Text='<%# Bind("nature_scope") %>' TextMode="MultiLine"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" HeaderText="Scope of Work to be Done">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtNatureScope" CssClass="txtbox_Remarks" Width="95%" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                        <td style="width: 98%" class="DivTitle">Details
                        </td>
                        <td style="width: 1%"></td>
                    </tr>                 
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">

                            <table width="90%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Date :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtDate" CssClass="txtbox_Date" MaxLength="10" Width="30%"></asp:TextBox>
                                        <span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDate" PopupButtonID="txtDate" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtDate" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">GSO Inspector :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtGSOInspector" CssClass="txtbox_Var" Width="94%"></asp:TextBox>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Requested By :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="drpRequestedby" runat="server" Width="95%" CssClass="drpdownCSS">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Inspected By :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="drpInspectedby" runat="server" Width="95%" CssClass="drpdownCSS">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Approved By :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="drpApprovedBy" runat="server" Width="95%" CssClass="drpdownCSS">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">GSO Approved By :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="drpApprovedBy_GSO" runat="server" Width="95%" CssClass="drpdownCSS">
                                        </asp:DropDownList>
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
                            <asp:Button runat="server" ID="btnSave" CssClass="CSButton" Width="12%" Text="SAVE" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button runat="server" ID="btnPreview" CssClass="CSButton" Width="12%" Text="PREVIEW" Enabled="false" OnClientClick="StartProgressBar();" />
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


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



