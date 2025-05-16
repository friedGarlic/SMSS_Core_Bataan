<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_Department.aspx.vb"
    Inherits="filemaintenance_t_Department" Title="FM - Department" StylesheetTheme="SkinFile" EnableEventValidation="false" %>


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
                        <td style="width: 98%" class="PageTitle">DEPARTMENTS / OFFICES
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tbody>
                                    <tr>
                                        <td class="column_RightBold" style="width: 15%">Department Name : 
                                        </td>
                                        <td class="column_Left" colspan="3">
                                            <asp:TextBox ID="txtDeparment" runat="server" Width="500px" Height="30px" CssClass="txtbox_Var"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Dept. Abbreviation : </td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtAbbr" runat="server" Width="50%" CssClass="txtbox_Var"></asp:TextBox></td>
                                        <td style="width: 15%" class="column_RightBold">Sector :
                                        </td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddSector" runat="server" Width="60%" OnSelectedIndexChanged="ddSector_SelectedIndexChanged" CssClass="drpdownCSS" AutoPostBack="True"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Department Code : </td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:TextBox ID="txtCode" runat="server" Width="50%" CssClass="txtbox_Var"></asp:TextBox></td>
                                        <td style="width: 15%" class="column_RightBold">Sub - Sector : </td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddSubSector" runat="server" Width="60%" OnSelectedIndexChanged="ddSubSector_SelectedIndexChanged" CssClass="drpdownCSS"></asp:DropDownList></td>
                                    </tr>
                                </tbody>
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
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="CSButton" Width="150px" OnClientClick="StartProgressBar();" Text="SAVE OFFICE"></asp:Button>
                            &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="CSButton" Width="150px" Text="CANCEL" OnClick="btnCancel_Click"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List Of Departments
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdDepartments" runat="server" Width="95%" DataKeyNames="RC_ID,RC_Name,Office_Ab,Sector_ID,Sector_Name,Office_Code,Func_per_Office_ID"
                                PageSize="20" AutoGenerateColumns="False" OnSelectedIndexChanged="grdDepartments_SelectedIndexChanged" EmptyDataText="No Data Found." SkinID="GridViewAA"
                                AllowPaging="True" Font-Size="8pt" OnPageIndexChanging="grdDepartments_PageIndexChanging">
                                <PagerSettings NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" CssClass="LinkBtnSelect" Font-Underline="false" OnClick="LinkButton1_Click" Text="Update"></asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="RC_Name" HeaderText="Deapartment Name">
                                        <ItemStyle HorizontalAlign="Left" Width="45%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Office_Ab" HeaderText="Dept. Abbrevation">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Office_Code" HeaderText="Dept. Code">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sector_Name" HeaderText="Sector">
                                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>

                                <PagerStyle Font-Bold="True"></PagerStyle>
                            </asp:GridView>
                        </td>
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
                <img src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp; 
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

