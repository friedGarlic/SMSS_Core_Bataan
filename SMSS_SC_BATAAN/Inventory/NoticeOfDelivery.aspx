<%@ Page Title="Notice of Delivery" Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="NoticeOfDelivery.aspx.vb"   EnableEventValidation="false" StylesheetTheme="SkinFile" Inherits="Inventory_NoticeOfDelivery" %>

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

        function confirmReturn() {
            return confirm("Are you sure you want to return this PO for re-approval?");
        }

        document.onkeypress = stopRKey;
    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">NOTICE OF DELIVERY
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search by :</span>
                            &nbsp;<asp:DropDownList runat="server" ID="drpSearch" CssClass="drpdownCSS" Width="12%">
                                <asp:ListItem Value="1" Text="PO Number" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Supplier"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<span class="column_RightBold">Search by :</span>
                            &nbsp;<asp:TextBox runat="server" ID="txtSearch" CssClass="txtbox_Var" Width="25%"></asp:TextBox>
                            &nbsp;<asp:Button runat="server" ID="btnSearch" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdNOD" OnSelectedIndexChanged="grdNOD_SelectedIndexChanged"
                                SkinID="GridViewAA" AllowPaging="True" DataKeyNames="POHdr_ID,PO_No,PO_Date,ContractPrice,SuppName,RC_ID,Function_ID,RC_Name,Function_Desc,GA_ID,Supplier_Id,pre_procurement_hdr_id"
                                OnRowDataBound="grdNOD_RowDataBound" OnPageIndexChanging="grdNOD_PageIndexChanging" Font-Size="8pt" EmptyDataText="No Data Found.">
                                   <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
                               
                                <Columns>
                                    <asp:BoundField DataField="PO_No" HeaderText="PO No.">
                                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PO_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="PO Date">
                                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContractPrice" DataFormatString="{0:N}" HeaderText="PO Amount" Visible ="false">
                                        <ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SuppName" HeaderText="Supplier">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="220px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RC_Name" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Left" Width="210px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProjectName" HeaderText="Project Name" Visible ="false">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OBR_No" HeaderText="OBR No." Visible ="false">
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
                                    <td style="width: 15%" class="column_RightBold">Delivery Receipt No.:</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtReceiptNo" CssClass="txtbox_Var" Width="60%" AutoPostBack="true" OnTextChanged="txtReceiptNo_TextChanged"  ></asp:TextBox>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Signatory :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpSignatory" CssClass="drpdownCSS" Width="95%"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Delivery Date :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtDeliveryDate" CssClass="txtbox_Var" Width="90%"></asp:TextBox>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">is Complete :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpCompelete" CssClass="drpdownCSS" Width="20%">
                                            <asp:ListItem Value="1" Text="Yes" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button runat="server" ID="btnSave" CssClass="CSButton" Enabled="false" Text="SAVE" Width="15%" OnClientClick="StartProgressBar();" />
                            <asp:Button runat="server" ID="btnReturn" CssClass="CSButton" Enabled="false" Text="RETURN" Width="15%" OnClientClick="return confirmReturn(); StartProgressBar();" OnClick="btnReturn_Click" />
                            <asp:Button ID="btnPreview" runat="server" Width="15%" CssClass="CSButton" Text="PREVIEW" Enabled="False" OnClick="btnPreview_Click" />
                        </td>
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

