<%@ Page Title="Inventory Custodian Slip" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ICS.aspx.vb" Inherits="Inventory_ICS"
    EnableEventValidation="false" StylesheetTheme="SkinFile" %>

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

                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">INVENTORY CUSTODIAN SLIP
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Panel runat="server" ID="pnlSearch" DefaultButton="btnSearch">
                                <table width="100%">
                                    <tr>
                                        <td class="column_RightBold" style="width: 30%">RIS Number : </td>
                                        <td class="column_Left" style="width: 30%">
                                            <asp:TextBox ID="txtSearch" runat="server" CssClass="txtbox_Var" Width="95%"></asp:TextBox>
                                        </td>
                                        <td class="column_Left" style="width: 20%">
                                            <asp:Button ID="btnSearch" runat="server" CssClass="CSButton" Width="150px" OnClientClick="StartProgressBar();" Text="SEARCH" />
                                        </td>
                                        <td class="column_Right" style="width: 20%">Date :
                                            <asp:TextBox runat="server" ID="txtDate" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDate" PopupButtonID="txtDate" PopupPosition="BottomRight"></cc1:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Requisition Issuance Slip List
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdRIS" runat="server" Width="90%" CssClass="text" SkinID="GridViewAA" DataKeyNames="RISHdr_ID,RIS_No,RC_ID,Func_ID"
                                AllowPaging="True" EmptyDataText="No Data Found.">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" CommandName="Select" CssClass="LinkBtnSelect" Font-Underline="false" Text="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="RIS_No" HeaderText="RIS NUMBER">
                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RISDate" HeaderText="RIS DATE" DataFormatString="{0:d}">
                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RC_Name" HeaderText="DEPARTMENT">
                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List Of Goods
                        </td>
                        <td style="width: 1%"></td>
                    </tr>

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">

                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Width="98%" CssClass="PanelSize" HorizontalAlign="Center" ScrollBars="Vertical">
                                        <asp:GridView ID="grdItems" runat="server" Width="100%" SkinID="GridViewAA"
                                            AutoGenerateColumns="False" EmptyDataText="No Data Found.">
                                            <Columns>
                                                <asp:BoundField DataField="Item_Desc" HeaderText="DESCRIPTION" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Width="48%"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Unit" HeaderText="UNIT">
                                                    <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="COST">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblCost" Text='<%#Bind("Cost") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="13%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="AVAILABLE QTY">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblQty" Text='<%#Bind("Available_Qty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="QUANTITY">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtQuantity" runat="server" Width="90%" OnTextChanged="txtQuantity_TextChanged" Text='<%# Bind("Available_Qty") %>' AutoPostBack="True" CssClass="txtbox_Amt" Visible='<%# bind("isVisible") %>'></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtQuantity" ValidChars="0123456789." Enabled="True"></cc1:FilteredTextBoxExtender>

                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tr>
                                    <td style="width: 13%" class="column_RightBold">Received From :
                                    </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtIssuedBy" CssClass="txtbox_Var" Width="90%"></asp:TextBox>
                                    </td>
                                    <td style="width: 10%" class="column_RightBold">Received By :
                                    </td>
                                    <td style="width: 42%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtIssuedTo" CssClass="txtbox_Var" Width="80%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 13%" class="column_RightBold">Position :
                                    </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtIssuedBy_Pos" CssClass="txtbox_Var" Width="90%"></asp:TextBox>
                                    </td>
                                    <td style="width: 10%" class="column_RightBold">Position :
                                    </td>
                                    <td style="width: 42%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtIssuedTo_Pos" CssClass="txtbox_Var" Width="80%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 13%" class="column_RightBold"></td>
                                    <td style="width: 35%; height: 10px" class="column_Left"></td>
                                    <td style="width: 10%" class="column_RightBold"></td>
                                    <td style="width: 42%" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 13%" class="column_RightBold">Issued To :
                                    </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtAccountablePerson" CssClass="txtbox_Var" Width="90%"></asp:TextBox>
                                    </td>
                                    <td style="width: 10%" class="column_RightBold"></td>
                                    <td style="width: 42%" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 13%" class="column_RightBold">Position :
                                    </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtAccountablePerson_Pos" CssClass="txtbox_Var" Width="90%"></asp:TextBox>
                                    </td>
                                    <td style="width: 10%" class="column_RightBold"></td>
                                    <td style="width: 42%" class="column_Left"></td>
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
                            <asp:Button runat="server" ID="btnSaveICS" Text="SAVE" CssClass="CSButton" Width="150px" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button runat="server" ID="btnPreviewICS" Text="PREVIEW" CssClass="CSButton" Enabled="false" Width="150px" OnClientClick="StartProgressBar();" />

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


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

