<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="boss_function.aspx.vb"
    Inherits="filemaintenance_boss_function" Title="FM - Function" StylesheetTheme="SkinFile" EnableEventValidation="false" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">




</script>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[

       

// ]]>
    </script>


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">FM - FUNCTION PER OFFICE
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 80%">

                                <tr>
                                    <td class="text4Bold" style="width: 20%">Department :</td>
                                    <td class="text5" style="width: 80%">
                                        <asp:DropDownList ID="ddDepartment" runat="server" Width="80%" OnSelectedIndexChanged="ddDepartment_SelectedIndexChanged" CssClass="drpdownCSS" AutoPostBack="True"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td class="text4Bold" style="width: 20%">Function Name :
                                    </td>
                                    <td class="text5" style="width: 80%">
                                        <asp:TextBox ID="txtFunction" runat="server" Width="50%" CssClass="txtbox_Var"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="text4Bold" style="width: 20%">Function Abbreviation :
                                    </td>
                                    <td class="text5" style="width: 80%">
                                        <asp:TextBox ID="txtAbbr" runat="server" Width="20%" CssClass="txtbox_Var"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="text4Bold" style="width: 20%">Function Code :
                                    </td>
                                    <td class="text5" style="width: 80%">
                                        <asp:TextBox ID="txtCode" runat="server" Width="20%" CssClass="txtbox_Var"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnSave" runat="server" Width="150px" CssClass="CSButton" AutoPostBack="true" Text="SAVE FUNCTION" OnClick="btnSave_Click" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnCancel" runat="server" Width="150px" CssClass="CSButton" Text="CANCEL" OnClick="btnCancel_Click"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">LIST OF FUNCTIONS
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdFunctions" runat="server" Width="98%" DataKeyNames="Function_Desc,Function_Abb,Office_Code,RC_ID,Function_ID,Func_per_Office_ID" PageSize="15" 
                                AutoGenerateColumns="False"  SkinID="GridViewAA" EmptyDataText="No Data Found.">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" CssClass="LinkBtnSelect"  Text="Update"></asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Function_Desc" HeaderText="Function Name">
                                        <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Function_Abb" HeaderText="Function Abbrevation">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Office_Code" HeaderText="Function Code">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
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
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;
        
        
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

