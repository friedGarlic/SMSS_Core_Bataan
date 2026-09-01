<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="t_BAC.aspx.vb" Inherits="filemaintenance_t_BAC" Title="FM BAC MEMBERS"
    StylesheetTheme="SkinFile" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">BAC SIGNATORIES
                        </td>
                        <td style="width: 1%"></td>
                    </tr>

                <tr>
                    <td style="width: 1%"></td>
                    <td style="width: 98%">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 50%; vertical-align: middle;">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server"
                                        Font-Size="12pt" Font-Names="Calibri"
                                        RepeatDirection="Horizontal" AutoPostBack="True"
                                        OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                        Visible="true">
                                        <asp:ListItem>Goods</asp:ListItem>
                                        <asp:ListItem>Infrastructure</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style="width: 50%; text-align: right; vertical-align: middle;">
                                    <div style="display: inline-block; margin-right: 20px;">
                                       <asp:CheckBox ID="chkViewHidden" runat="server" AutoPostBack="True" OnCheckedChanged="chkViewHidden_CheckedChanged" />
                <asp:Label ID="lblViewHidden" runat="server" AssociatedControlID="chkViewHidden"
                    Text="View Hidden Signatories" Font-Names="Calibri" Font-Size="11pt" />

                                    </div>
                                    <asp:Button ID="btnADD" OnClick="btnADD_Click" runat="server"
                                        Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();"
                                        Text="ADD MEMBER" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 1%"></td>
                </tr>

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdBAC" runat="server" Width="90%" OnSelectedIndexChanged="grdBAC_SelectedIndexChanged" OnPageIndexChanging="grdBAC_PageIndexChanging"
                                AllowPaging="True" DataKeyNames="position_desc,BAC_PostionID,id,empsig_id,Name,isActive,isDefault,isPublicInfra" AutoGenerateColumns="False"
                                SkinID="GridViewAA" EmptyDataText="No Data Found">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <ItemStyle HorizontalAlign="Center" Font-Underline="False" ForeColor="Blue" CssClass="LinkBtnSelect" Width="5%"></ItemStyle>
                                    </asp:CommandField>
                                    <asp:BoundField DataField="name" HeaderText="Name">
                                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="position_desc" HeaderText="BAC Position">
                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="position" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="isPublicInfra" HeaderText="Services">
                                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="isActive" HeaderText="Is Active">
                                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="isDefault" HeaderText="Is Default">
                                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" runat="server" visible="false" class="DivTitle">Default BAC Signatories
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center" runat="server" visible="false">
                            <asp:GridView ID="grdDefault" runat="server"  Width="70%" SkinID="GridViewAA" EmptyDataText="No Data Found.">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                        <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BAC_Pos" HeaderText="BAC Position">
                                        <ItemStyle HorizontalAlign="Center" Width="40%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">
                            <asp:Label ID="lblBAC" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:MultiView ID="MultiView1"  runat="server">
                                <asp:View ID="View1" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <table style="width: 50%">
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">Name : </td>
                                                        <td style="width: 75%" class="column_Left">
                                                            <asp:Label ID="lblName" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">Service : </td>
                                                        <td style="width: 75%" class="column_Left">
                                                            <asp:DropDownList ID="DDIsPubInfra" runat="server" Width="70%" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="DDIsPubInfra_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Infrastructure</asp:ListItem>
                                                                <asp:ListItem Value="2">Goods</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">Update Position : </td>
                                                        <td style="width: 75%" class="column_Left">
                                                            <asp:DropDownList ID="ddBACpos" runat="server" Width="70%" AutoPostBack="True" OnSelectedIndexChanged="ddBACpos_SelectedIndexChanged" CssClass="drpdownCSS">
                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">Is Active? :</td>
                                                        <td style="width: 75%" class="column_Left">
                                                            <asp:DropDownList ID="ddisActive" runat="server" Width="100px" CssClass="drpdownCSS">
                                                                <asp:ListItem Selected="True" Value="3">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                <asp:ListItem Value="0">No</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">Is Default : </td>
                                                        <td style="width: 75%" class="column_Left">
                                                            <asp:DropDownList ID="ddDefault" runat="server" Width="100px" CssClass="drpdownCSS">
                                                                <asp:ListItem Selected="True" Value="3">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                <asp:ListItem Value="0">No</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:Button ID="btnsave" OnClick="btnsave_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Save"></asp:Button>
                                                &nbsp;<asp:Button ID="btncancel" OnClick="btncancel_Click" runat="server" Width="150px" CssClass="CSButton" Text="Cancel"></asp:Button></td>
                                        </tr>
                                    </table>
                                </asp:View>


                                <asp:View ID="View2" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <table style="width: 50%">
                                                    <tr>
                                                        <td style="width: 25%; height: 21px;" class="column_RightBold">Position : </td>
                                                        <td style="width: 75%; height: 21px;" class="column_Left">
                                                            <asp:DropDownList ID="ddBACpos2" runat="server" Width="70%" AutoPostBack="True" CssClass="drpdownCSS">
                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="txtNewPosition" CssClass="txtbox_Var" runat="server" Width="65%" Visible="false"></asp:TextBox>
                                                            <asp:Button ID="btnNewPosition" runat="server" CssClass="CSButton" Width="100px" Text="New" OnClick="btnNewPosition_Click" />
                                                            <asp:HiddenField ID="hndDepID" runat="server" />
                                                        </td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">Name : </td>
                                                        <td style="width: 75%" class="column_Left">
                                                            <asp:DropDownList ID="ddNewBAC" runat="server" Width="70%"  CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddNewBAC_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">Select</asp:ListItem>

                                                            </asp:DropDownList></td>
                                                    </tr>
                                                     <tr>
                                                        <td style="width: 25%" class="column_RightBold">Service : </td>
                                                        <td style="width: 75%" class="column_Left">
                                                            <asp:DropDownList ID="DdServ" runat="server" Width="70%"  CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="DdServ_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                 <asp:ListItem Value="1">Infrastructure</asp:ListItem>
                                                                <asp:ListItem Value="2">Goods</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">Department : </td>
                                                        <td style="width: 75%" class="column_Left">
                                                            <asp:TextBox ID="txtNewDep" runat="server" Width="70%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox></td>
                                                    </tr>
                                                     <tr>
                                                        <td style="width: 25%" class="column_RightBold">Is Active? :</td>
                                                        <td style="width: 75%" class="column_Left">
                                                            <asp:DropDownList ID="DDIsAct" runat="server" Width="100px" CssClass="drpdownCSS">
                                                                <asp:ListItem Selected="True" Value="3">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                <asp:ListItem Value="0">No</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">Is Default : </td>
                                                        <td style="width: 75%" class="column_Left">
                                                            <asp:DropDownList ID="DDiSDef" runat="server" Width="100px" CssClass="drpdownCSS">
                                                                <asp:ListItem Selected="True" Value="3">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                <asp:ListItem Value="0">No</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:Button ID="btnSaveNew" OnClick="btnSaveNew_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Save" Enabled="False"></asp:Button>
                                                &nbsp;<asp:Button ID="btnCancelNew" OnClick="btnCancelNew_Click" runat="server" Width="150px" CssClass="CSButton" Text="Cancel" Enabled="False"></asp:Button></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center"></td>
                                        </tr>
                                    </table>
                                </asp:View>

                            </asp:MultiView>

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

            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>