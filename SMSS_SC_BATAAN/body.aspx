<%@ Page Language="VB" AutoEventWireup="false" CodeFile="body.aspx.vb" Inherits="body" 
MasterPageFile="~/MasterPage.master" StylesheetTheme="SkinFile" Title="SMSS: Supply Management Support System" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager id="ScriptManager1" runat="server">
</asp:ScriptManager>
                
<asp:UpdatePanel id="UpdatePanel2" runat="server">
<contenttemplate>

          
                
                
    <table style="width: 1010px">
        <tr>
            <td style="background-image: url(images/LOGINPAGE_SMSS_try.jpg); vertical-align: top; width: 1010px;
                height: 790px; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td class="text1Home" style="width: 10%">
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </td>
                        <td class="text2Home" style="width: 20%">
                        </td>
                        <td style="width: 70%; text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td class="text1Home" style="width: 10%">
                            Username :
                        </td>
                        <td class="text2Home" style="width: 20%">
                                        <asp:Label ID="lblUser" runat="server" Style="position: relative" Width="98%"></asp:Label></td>
                        <td rowspan="5" style="width: 70%; text-align: left">
                            <img height="100" src="images/noPicture.JPG" width="95" /></td>
                    </tr>
                    <tr>
                        <td class="text1Home" style="width: 10%">
                                        Full Name :
                        </td>
                        <td class="text2Home" style="width: 20%">
                                        <asp:Label ID="lblName" runat="server" Style="position: relative" Width="98%"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="text1Home" style="width: 10%">
                                        Position :</td>
                        <td class="text2Home" style="width: 20%">
                                        <asp:Label ID="lblPosition" runat="server" Style="position: relative" Width="98%"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="text1Home" style="width: 10%">
                                        Time :
                        </td>
                        <td class="text2Home" style="width: 20%">
                                        <asp:Label ID="lblTime" runat="server" Style="position: relative" Width="98%"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="text1Home" style="width: 10%">
                                        Today is :
                        </td>
                        <td class="text2Home" style="width: 20%">
                                        <asp:Label ID="lblDate" runat="server" Style="position: relative" Width="98%"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Panel ID="PanelProgress" runat="server" Style="border-top-width: 1px; border-left-width: 1px;
        border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc;
        border-top-color: #0033cc; background-color: transparent; text-align: center;
        border-right-width: 1px; border-right-color: #0033cc" Width="109px">
        <img src="images/ajax-loader.gif" /></asp:Panel>
    <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress">
    </cc1:ModalPopupExtender>
    <asp:Button ID="ButtonProgress" runat="server" Enabled="False" Style="border-top-style: none;
        border-right-style: none; border-left-style: none; background-color: transparent;
        border-bottom-style: none" Width="16px" />
    &nbsp; &nbsp; &nbsp;
    
    </contenttemplate>
</asp:UpdatePanel>  
</asp:Content>
