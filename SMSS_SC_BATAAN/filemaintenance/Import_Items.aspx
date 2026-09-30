<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Import_Items.aspx.vb" Inherits="filemaintenance_Import_Items"
    Title="Import Items" MaintainScrollPositionOnPostback="true" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUploadFile" />
            <asp:PostBackTrigger ControlID="btnDownloadTemplate" />
        </Triggers>
        <ContentTemplate>

            <div style="text-align: center;">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%; height: 26px;" class="PageTitle" colspan="4">Import Items</td>
                    </tr>
                    <tr style="height: 10px">
                        <td colspan="4"></td>
                    </tr>

                    <%-- Calendar Year --%>
                    <tr>
                        <td style="width: 25%"></td>
                        <td style="width: 15%" class="column_RightBold">Calendar Year :</td>
                        <td style="width: 35%" class="column_Left">
                            <asp:DropDownList ID="ddyear" runat="server" Width="80%" CssClass="drpdownCSS"
                                AutoPostBack="True" OnSelectedIndexChanged="ddyear_SelectedIndexChanged">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 25%"></td>
                    </tr>

                    <%-- Allotment Type --%>
                    <tr>
                        <td style="width: 25%"></td>
                        <td style="width: 15%" class="column_RightBold">Allotment Type :</td>
                        <td style="width: 35%" class="column_Left">
                            <asp:DropDownList ID="ddAllotmentType" runat="server" Width="80%" CssClass="drpdownCSS"
                                AutoPostBack="True" OnSelectedIndexChanged="ddAllotmentType_SelectedIndexChanged">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 25%"></td>
                    </tr>

                    <%-- General Account --%>
                    <tr>
                        <td style="width: 25%"></td>
                        <td style="width: 15%" class="column_RightBold">General Account :</td>
                        <td style="width: 35%" class="column_Left">
                            <asp:DropDownList ID="GenAccnt" runat="server" Width="80%" CssClass="drpdownCSS"
                                AutoPostBack="True" OnSelectedIndexChanged="GenAccnt_SelectedIndexChanged">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 25%"></td>
                    </tr>

                    <%-- Classification --%>
                    <tr>
                        <td style="width: 25%"></td>
                        <td style="width: 15%" class="column_RightBold">Classification :</td>
                        <td style="width: 35%" class="column_Left">
                            <asp:DropDownList ID="drpclass" runat="server" Width="80%" CssClass="drpdownCSS"
                                AutoPostBack="True" OnSelectedIndexChanged="drpclass_SelectedIndexChanged">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 25%"></td>
                    </tr>

                    <%-- Sub Classification --%>
                    <tr>
                        <td style="width: 25%"></td>
                        <td style="width: 15%" class="column_RightBold">Sub Classification :</td>
                        <td style="width: 35%" class="column_Left">
                            <asp:DropDownList ID="DrpSubClass" runat="server" Width="80%" CssClass="drpdownCSS"
                                AutoPostBack="True" OnSelectedIndexChanged="DrpSubClass_SelectedIndexChanged">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 25%"></td>
                    </tr>

                    <%-- Spacing --%>
                    <tr style="height: 15px">
                        <td colspan="4"></td>
                    </tr>

                    <%-- Buttons Row: New Subclass / Download Template --%>
                    <tr>
                        <td colspan="4" style="text-align: center;">
                            <asp:Button ID="btnNewSubClass" runat="server" CssClass="CSButton"
                                Text="Manage Subclass" Width="20%"  />
                            &nbsp;
                            <asp:Button ID="btnDownloadTemplate" runat="server" CssClass="CSButton"
                                Text="Download Template" Width="20%" />
                        </td>
                    </tr>

                    <%-- Spacing --%>
                    <tr style="height: 15px">
                        <td colspan="4"></td>
                    </tr>

                    <%-- File Upload --%>
                    <tr>
                        <td style="width: 25%"></td>
                        <td style="width: 15%" class="column_RightBold">Choose File :</td>
                        <td style="width: 35%" class="column_Left">
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="CSButton" Width="80%" />
                        </td>
                        <td style="width: 25%"></td>
                    </tr>

                    <%-- Spacing --%>
                    <tr style="height: 15px">
                        <td colspan="4"></td>
                    </tr>

                    <%-- Upload File Button --%>
                    <tr>
                        <td colspan="4" style="text-align: center;">
                            <asp:Button ID="btnUploadFile" runat="server" CssClass="CSButton"
                                Text="Upload File" Width="20%"  />
                        </td>
                    </tr>

                    <%-- Spacing --%>
                    <tr style="height: 15px">
                        <td colspan="4"></td>
                    </tr>

                </table>

                <%-- Section header --%>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List of Items to be Imported</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr style="height: 1px">
                        <td colspan="3"></td>
                    </tr>
                </table>


                <%-- GridView of Uploaded Items (scrollable) --%>
                <div style="width: 99%; max-height: 300px; overflow-y: auto; margin: 0 auto; border: 1px solid #ccc;">
                    <asp:GridView ID="grdUploadedItems" runat="server" SkinID="GridViewAA"
                        EmptyDataText="No Data found." AutoGenerateColumns="False"
                        HorizontalAlign="Center" Width="100%">
                        <EmptyDataRowStyle Font-Bold="False"></EmptyDataRowStyle>
                        <HeaderStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="Item_Code" HeaderText="Item Code">
                                <ItemStyle Width="12%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CategoryName" HeaderText="Category Name">
                                <ItemStyle Width="18%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Item_Desc" HeaderText="Item Description">
                                <ItemStyle Width="25%" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="price" HeaderText="Price">
                                <ItemStyle Width="10%" HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UnitDescription" HeaderText="Unit">
                                <ItemStyle Width="12%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="reorderPT" HeaderText="Reorder PT">
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UsefulLife" HeaderText="Useful Life">
                                <ItemStyle Width="13%" HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>

                <%-- Spacing --%>
                <br />
                <%-- Save / Cancel Buttons Row --%>
                <table style="width: 100%">
                    <tr>
                        <td colspan="4" style="text-align: center;">
                            <asp:Button ID="btnSave" runat="server" CssClass="CSButton"
                                Text="Import Items" Width="20%"  />
                            &nbsp;
                            <asp:Button ID="btnCancel" runat="server" CssClass="CSButton"
                                Text="Cancel" Width="20%"  />
                        </td>
                    </tr>
                </table>

                <br /><br />

            </div>


            <%--Add/Update Sub Classification START--%>
            <asp:Panel ID="ModalSubClass" runat="server" Width="700px" CssClass="Panel_Popup">
                <div>
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">Add/Update Sub Classification
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 90%" align="center">
                                <table width="90%">

                                    <tr align="center">
                                        <td style="width: 31%" class="column_RightBold" align="center">General Account :</td>
                                        <td style="width: 50%" class="column_Left" align="center">
                                            <asp:Label ID="lblNewSubClass_GA" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr align="center">
                                        <td style="width: 22%; height: 24px;" class="column_RightBold" align="right">Classification :</td>
                                        <td style="width: 27%; height: 24px;" class="column_Left">
                                            <asp:Label ID="lblNewSubClass_Class" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr align="center">
                                        <td style="width: 22%; height: 24px;" class="column_RightBold" align="right">Sub Classification :</td>
                                        <td style="width: 10%; height: 24px;" class="column_Left">
                                            <asp:TextBox ID="NewSubClassificationTxt" Enabled="true" runat="server" Width="54%" CssClass="txtbox_Var" align="center"></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                </table>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="right">
                                <asp:Button ID="BtnSave_SUBCLASS" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" ValidationGroup="savenp" OnClientClick="StartProgressBar();"></asp:Button>
                                &nbsp;<asp:Button ID="BtnClearSubClass" runat="server" Width="120px" CssClass="CSButton" Text="CLEAR"></asp:Button>

                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server" Enabled="True" TargetControlID="BtnSave_SUBCLASS" ConfirmText="Are you sure you want to save this transaction?">
                                </cc1:ConfirmButtonExtender>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" class="DivTitle">List Of Classification and Sub Classifications
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <asp:GridView ID="GvSubClass" runat="server" Width="98%"
                                    SkinID="GridViewAA" EmptyDataText="No Records Available"
                                    DataKeyNames="SubClassificationID,SubClassificationName,ClassificationName,GA_Title2,GA_ID,ClassificationID"
                                    AllowPaging="True" PageSize="9">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="LinkBtnSelect" ForeColor="#21007dc"></ItemStyle>
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ClassificationName" HeaderText="Classification Name">
                                            <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SubClassificationName" HeaderText="Sub Classification Name">
                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GA_Title2" HeaderText="General Account">
                                            <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%">
                                <asp:Button runat="server" ID="btnCloseSubClass" Width="120px" CssClass="CSButton" Text="Close" />
                                <asp:Label ID="lblSubClassMessage" runat="server"></asp:Label>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender7" runat="server" TargetControlID="lblSubClassMessage" PopupControlID="ModalSubClass" CancelControlID="btnCloseSubClass" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <%--New Sub Classification END--%>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>