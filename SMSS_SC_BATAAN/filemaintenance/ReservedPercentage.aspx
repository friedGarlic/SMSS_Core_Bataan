<%@ Page Title="FM - Reserved Percentage" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ReservedPercentage.aspx.vb"
    Inherits="filemaintenance_ReservedPercentage" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">FM - RESERVED PERCENTAGE</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="80%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold"></td>
                                    <td style="width: 80%; height: 5px" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Calendar Year :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpYear" Width="25%" CssClass="drpdownCSS" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Allotment Class :</td>
                                    <td>
                                        <asp:DropDownList ID="drpAllotment" runat="server" Width="25%" CssClass="drpdownCSS" AutoPostBack="true"></asp:DropDownList> </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Reserved Percentage :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtReservedPercentage" Width="20%" CssClass="txtbox_Amt" Text="0.00"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold"></td>
                                    <td style="width: 80%; height: 5px" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold"></td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:Button runat="server" ID="btnSave" Width="150px" CssClass="CSButton" Text="Save" OnClientClick="StartProgressBar();" />
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
                        <td style="width: 98%" class="DivTitle">Accounts with Reserved Percentage
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">

                            <table cellpadding="0px" cellspacing="0px" width="95%">
                                <tr>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab1" Width="100%" Text="MOOE" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab2" Width="100%" Text="Capital Outlay" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 60%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="3" class="Panel_Popup" align="center">
                                        <table width="90%">
                                            <tr>
                                                <td style="width: 100%; height: 10px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <span class="column_RightBold">Search :</span>
                                                    &nbsp;<asp:TextBox runat="server" ID="txtSearch" Width="40%" CssClass="txtbox_Var"></asp:TextBox>
                                                    &nbsp;<asp:Button runat="server" ID="btnSearch" Width="15%" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView runat="server" ID="grdReserved" Width="100%" SkinID="GridViewAA" EmptyDataText="No Data Found." DataKeyNames="GA_ID,BGA_ID,ReservedPercentage,GA_Title"
                                                        AllowPaging="true" PageSize="10">
                                                        <Columns>
                                                            <asp:BoundField DataField="GA_Code2" HeaderText="ACCOUNT CODE" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" />
                                                            <asp:BoundField DataField="GA_Title" HeaderText="ACCOUNT DESCRIPTION" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="65%" />
                                                            <asp:BoundField DataField="ReservedPercentage" HeaderText="RESERVED PERCENTAGE" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="lnkEdit" ImageUrl="~/images/Edited Image/Active_Pencil.jpg" CommandName="Select" OnClick="lnkEdit_Click" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="lnkExempt" ImageUrl="~/images/Edited Image/X_Icon.png" CommandName="Select" OnClick="lnkExempt_Click" />
                                                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are You Sure You Want to Exempt this Account?" TargetControlID="lnkExempt">
                                                                    </cc1:ConfirmButtonExtender>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />

                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 10px"></td>
                                            </tr>
                                        </table>
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
                        <td style="width: 98%" class="DivTitle">Accounts Exempted for Reserved Percentage
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table cellpadding="0px" cellspacing="0px" width="95%">
                                <tr>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTabEx1" Width="100%" Text="MOOE" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTabEx2" Width="100%" Text="Capital Outlay" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 60%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="3" class="Panel_Popup" align="center">
                                        <table width="90%">
                                            <tr>
                                                <td style="width: 100%; height: 10px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <span class="column_RightBold">Search :</span>
                                                    &nbsp;<asp:TextBox runat="server" ID="txtSearchExempt" Width="40%" CssClass="txtbox_Var"></asp:TextBox>
                                                    &nbsp;<asp:Button runat="server" ID="btnSearchExempt" Width="15%" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView runat="server" ID="grdExcemptedAccounts" Width="100%" SkinID="GridViewAA" EmptyDataText="No Data Found." DataKeyNames="GA_ID,BGA_ID,GA_Title"
                                                        AllowPaging="true" PageSize="10">
                                                        <Columns>
                                                            <asp:BoundField DataField="GA_Code2" HeaderText="ACCOUNT CODE" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" />
                                                            <asp:BoundField DataField="GA_Title" HeaderText="ACCOUNT DESCRIPTION" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="65%" />
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="lnkAddReserved" ImageUrl="~/images/Edited Image/Checked_Icon.png" CommandName="Select" OnClick="lnkAddReserved_Click" />
                                                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are You Sure You Want to Add Reserved Percentage to this Account?" TargetControlID="lnkAddReserved">
                                                                    </cc1:ConfirmButtonExtender>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />

                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 10px"></td>
                                            </tr>
                                        </table>


                                    </td>
                                </tr>
                            </table>

                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>



            <%-- POPUP PANEL FOR EDIT RESERVED PERCENTAGE --%>
            <div>
                <asp:Panel runat="server" ID="pnlEdit" CssClass="Panel_Popup" Width="250px" DefaultButton="btnUpdate_Reserved">
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" class="DivTitle">Edit Reserved Percentage
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 10px"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 5px"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%" align="center">
                                <span class="column_RightBold">Reserved Percentage :</span>
                                <br />
                                <asp:TextBox runat="server" ID="txtEditReserved" Width="40%" CssClass="txtbox_Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 10px"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%" align="center">
                                <asp:Button runat="server" ID="btnUpdate_Reserved" Width="100px" CssClass="CSButton" Text="Update" OnClientClick="StartProgressBar();" />
                                &nbsp;<asp:Button runat="server" ID="btnCancel" Width="100px" CssClass="CSButton" Text="Cancel" OnClientClick="StartProgressBar();" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 10px">
                                <asp:Label runat="server" ID="lblEdit"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <cc1:ModalPopupExtender ID="ModalPopupExtender_PnleDIT" runat="server" PopupControlID="pnlEdit" BackgroundCssClass="modalBackground" TargetControlID="lblEdit"></cc1:ModalPopupExtender>

            </div>


            <%-- POPUP PANEL FOR MESSAGE --%>
            <div>
                <asp:Panel runat="server" ID="pnlMessage" CssClass="PanelMessage" DefaultButton="btnMsgOK">
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" class="DivTitle">Alert!
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 15px"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%" align="center">
                                <asp:Label runat="server" ID="lblMessagePopup" Text="" CssClass="AlertMsg"></asp:Label>
                                <asp:TextBox runat="server" ID="txtHide" Width="0%" Height="0%" BorderStyle="None" BorderColor="Transparent" BackColor="Transparent"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 25px"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%" align="center">
                                <asp:Button runat="server" ID="btnMsgOK" Width="100px" CssClass="CSButton" Text="OK" OnClientClick="StartProgressBar();"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 10px">
                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <cc1:ModalPopupExtender ID="ModalPopupExtender_PnlMessage" runat="server" PopupControlID="pnlMessage" BackgroundCssClass="modalBackground" TargetControlID="lblMessage"></cc1:ModalPopupExtender>

            </div>



            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp; 
       
            


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

