<%@ Page Language="VB"
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false"
    CodeFile="Bac_CertificateReport.aspx.vb"
    Inherits="Reports_and_Query_Bac_CertificateReport"
    StylesheetTheme="SkinFile" %>


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
                            <td style="width: 98%" class="DivTitle">List Of Procurement
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" >
                                <asp:GridView ID="gvopen" runat="server" Width="98%" SkinID="GridViewAA" EmptyDataText="NO DATA FOUND"
                                DataKeyNames="obr_evaluation_hdr_id" AutoGenerateColumns="False" AllowPaging="true" PageSize="30">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CssClass="LinkBtnPreview" runat="server" CausesValidation="False" Text="Preview" Font-Underline="False" CommandName="Select" __designer:wfdid="w27"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="BACCert_Issued" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date Issued">
                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PR_Purpose" HeaderText="Purpose">
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                
                                    <asp:BoundField DataField="mode_description"  HeaderText="Mode of Procurement">
                                        <ItemStyle HorizontalAlign="center" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                        <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="Amount">
                                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                    </table>
                 </div>

            <cc1:ModalPopupExtender ID="ModalPopupExtendepopup" runat="server" TargetControlID="lblPopUp" BackgroundCssClass="modalBackground" PopupControlID="PopUP_Panel" CancelControlID="btnBACCancel"></cc1:ModalPopupExtender>

            <asp:Panel ID="PopUP_Panel" runat="server" Width="350px" CssClass="Panel_Popup">
                <table style="width: 100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td style="width: 100%" colspan="2" class="DivTitle">Bac Certification
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%; height: 5px" class="column_RightBold"></td>
                        <td style="width: 70%" align="left"></td>
                    </tr>
                    <tr>
                        <td style="width: 30%" class="column_RightBold">Date Duration :&nbsp;</td>
                        <td style="width: 70%" align="left">
                            <asp:TextBox ID="txtDateFrom" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                            &nbsp;<span class="column_RightBold">to</span>
                            &nbsp;<asp:TextBox ID="txtDateTo" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%; height: 5px" class="column_RightBold"></td>
                        <td style="width: 70%" align="left"></td>
                    </tr>
                    <tr>
                        <td style="width: 30%" class="column_RightBold">Date Issued :&nbsp;</td>
                        <td style="width: 70%" align="left">
                            <asp:TextBox ID="txtDateIssued" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 30%; height: 5px" class="column_RightBold"></td>
                        <td style="width: 70%" align="left"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" colspan="2" align="center">
                            <asp:Button ID="btnBACCertSave" OnClick="btnBACCertSave_Click" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnBACCancel" runat="server" Width="120px" CssClass="CSButton" Text="CANCEL"></asp:Button>

                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%; height: 10px" class="column_RightBold"></td>
                        <td style="width: 70%" align="left">
                             <asp:Label ID="lblPopUp" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
