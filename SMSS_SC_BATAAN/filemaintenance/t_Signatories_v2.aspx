<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_Signatories_v2.aspx.vb"
    Inherits="filemaintenance_t_Signatories_v2" Title="FM SIGNATORIES" EnableEventValidation="false" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">SIGNATORIES</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="95%">
                                <tr>
                                    <td style="width: 10%" class="column_RightBold">Department :</td>
                                    <td style="width: 50%" class="column_Left">
                                        <asp:DropDownList ID="ddDepartment" runat="server" Width="95%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddDepartment_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                                    <td style="width: 15%" class="column_RightBold">Department Head :</td>
                                    <td style="width: 25%" class="column_Left">
                                        <asp:DropDownList ID="ddDeptHead" runat="server" Width="50%" CssClass="drpdownCSS">
                                            <asp:ListItem Selected="True" Value="1">Select</asp:ListItem>
                                            <asp:ListItem Value="2">Yes</asp:ListItem>
                                            <asp:ListItem Value="3">No</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 10%" class="column_RightBold">Function :</td>
                                    <td style="width: 50%" class="column_Left">
                                        <asp:DropDownList ID="ddFunction" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList></td>
                                    <td style="width: 15%" class="column_RightBold">is Active :</td>
                                    <td style="width: 25%" class="column_Left">
                                        <asp:DropDownList ID="ddIsActive" runat="server" Width="50%" CssClass="drpdownCSS">
                                            <asp:ListItem Selected="True" Value="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 10%" class="column_RightBold">Name :</td>
                                    <td style="width: 50%" class="column_Left">
                                        <asp:TextBox ID="txtName" runat="server" Width="80%" CssClass="txtbox_Var"></asp:TextBox></td>
                                    <td style="width: 15%" class="column_RightBold">is Inspector :
                                    </td>
                                    <td style="width: 25%" class="column_Left">
                                        <asp:DropDownList ID="ddisInspector" runat="server" Width="50%" CssClass="drpdownCSS">
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="False">No</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 10%" class="column_RightBold">Position :</td>
                                    <td class="column_Left" colspan="3">
                                        <asp:DropDownList ID="ddPosition" runat="server" Width="44%" CssClass="drpdownCSS"></asp:DropDownList>
                                        <asp:TextBox ID="txtPositionDesc" runat="server" Width="44%" CssClass="txtbox_Var" Visible="False"></asp:TextBox>
                                        &nbsp;<asp:Button ID="btnNewPosition" OnClick="btnNewPosition_Click" runat="server" Width="100px" CssClass="CSButton" Text="New" OnClientClick="StartProgressBar();"></asp:Button>
                                        &nbsp;<asp:Label ID="lblNoti" runat="server" ForeColor="Red" Font-Size="10pt" Font-Names="Calibri" Visible="False" Text="Position already exist" Font-Italic="True" Font-Strikeout="False"></asp:Label></td>
                                </tr>

                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%;height:5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="150px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" Width="150px" CssClass="CSButton" Text="CLEAR" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%;height:5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List of Signatories
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Department :</span>
                            &nbsp;<asp:DropDownList ID="ddDepartment_Search" runat="server" Width="40%" CssClass="drpdownCSS"></asp:DropDownList>
                            &nbsp;<asp:Button ID="btnSearchSignatories" OnClick="btnSearchSignatories_Click" runat="server" Width="150px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdSignatories" runat="server" Width="98%" OnSelectedIndexChanged="grdSignatories_SelectedIndexChanged" 
                                OnPageIndexChanging="grdSignatories_PageIndexChanging" DataKeyNames="RC_ID,Function_ID,FullName,Position_Desc,isDeptHead,isActive,EmpID,isInspector" 
                                PageSize="15" AutoGenerateColumns="False" SkinID="GridViewAA" EmptyDataText="No DataFound." AllowPaging="True">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" Font-Underline="False" CssClass="LinkBtnSelect">Select</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FullName" HeaderText="Full Name">
                                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Position_Desc" HeaderText="Position">
                                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RC_Name" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="isDeptHead" HeaderText="Head">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                     <asp:BoundField DataField="isActive" HeaderText="Status">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
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
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
       
            
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

