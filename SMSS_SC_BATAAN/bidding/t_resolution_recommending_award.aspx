<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_resolution_recommending_award.aspx.vb" Inherits="t_resolution_recommending_award" title="Resolution Recommending the Award" StylesheetTheme="SkinFile" MaintainScrollPositionOnPostback ="true" %>

<%@ Register Assembly="ZNet.Controls" Namespace="ZNet.Controls" TagPrefix="ZNet" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<table width="1015px" style="text-align:center">
<tr>
<td width="1015px" style="text-align:center">


    <table class="PageTitle">
        <tr>
            <td style="width: 1000px">
                &nbsp;RESOLUTION RECOMMENDING OF AWARD</td>
        </tr>
    </table>



    <table border="0" cellpadding="0" cellspacing="0" style="width: 1000px">
        <tr>
            <td colspan="8" style="text-align: left">
<%--                <asp:Label ID="Label3" runat="server" SkinID="pageheader" Style="font-weight: bold; font-size: 14pt" ForeColor="DimGray">Resolution Recommending the Award</asp:Label>--%>
                <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <ZNet:ZNetGridView ID="ZNetGridView1" runat="server">
            </ZNet:ZNetGridView>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:UpdatePanel id="upEmployeeDetail" runat="server">
                    <contenttemplate>
<cc1:CollapsiblePanelExtender id="cpeEmployeeList" runat="server" TargetControlID="panelContentEmployeeList" SuppressPostBack="true" ExpandedText="Collapse" CollapsedText="Expand" ImageControlID="imgBackgroundEmployeeList" CollapsedImage="../images/BackGroundResolution.png" Collapsed="false" ExpandedImage="../images/HighLightResolution.png" ExpandControlID="panelTitleEmployeeList" CollapseControlID="panelTitleEmployeeList" __designer:wfdid="w14"></cc1:CollapsiblePanelExtender> <cc1:CollapsiblePanelExtender id="cpeEmployeeDetail" runat="server" TargetControlID="panelContentEmployeeDetail" SuppressPostBack="True" ExpandedText="Collapse" CollapsedText="Expand" ImageControlID="imgBackgroundEmployeeDetail" CollapsedImage="../images/BackGroundProject.png" Collapsed="true" ExpandedImage="../images/HighLightProject.png" ExpandControlID="panelTitleEmployeeDetail" CollapseControlID="panelTitleEmployeeDetail" __designer:wfdid="w15"></cc1:CollapsiblePanelExtender><asp:Panel id="panelTitleEmployeeList" runat="server" Width="1000px" Height="25px" __designer:wfdid="w16"><IMG id="imgBackgroundEmployeeList" height=28 src="../images/BackGroundResolution.png" width=1000 /></asp:Panel> <asp:Panel id="panelContentEmployeeList" runat="server" Width="98%" __designer:wfdid="w17"><DIV style="BORDER-RIGHT: #cccccc 2px solid; PADDING-RIGHT: 0px; BORDER-TOP: #cccccc 0px solid; PADDING-LEFT: 0px; FONT-WEIGHT: normal; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: #cccccc 2px solid; WIDTH: 98%; PADDING-TOP: 0px; BORDER-BOTTOM: #cccccc 2px solid"><asp:GridView style="FONT-WEIGHT: normal; TEXT-ALIGN: justify" id="gvIncomingPR" runat="server" Width="100%" __designer:wfdid="w18" OnSelectedIndexChanged="gvIncomingPR_SelectedIndexChanged1" AutoGenerateColumns="False" DataKeyNames="mode_of_procurement_id,obr_evaluation_hdr_id,mode_description,transaction_date,resolution_mode_of_procurement,F_ID" PageSize="8" SkinID="gvnew"><Columns>
<asp:TemplateField HeaderText="Resolution Number" ShowHeader="False"><ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" CausesValidation="False" Text='<%# bind("resolution_mode_of_procurement") %>' Font-Underline="False" CommandName="Select" Visible='<%# bind("isVisible") %>'></asp:LinkButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="mode_description" HeaderText="Mode of Procurement"></asp:BoundField>
<asp:TemplateField HeaderText="Date of Evaluation"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("transaction_date") %>' id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("transaction_date", "{0:MM/dd/yyyy}") %>' Visible='<%# bind("isVisible") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
</Columns>
    <HeaderStyle BackColor="#2977DC" ForeColor="White" />
                        <FooterStyle BackColor="#2977DC" />
</asp:GridView></DIV></asp:Panel> <asp:Panel id="panelTitleEmployeeDetail" runat="server" Width="1000px" Height="25px" __designer:wfdid="w19"><IMG id="imgBackgroundEmployeeDetail" height=28 src="../images/BackGroundproject.png" width=1000 /></asp:Panel> <asp:Panel style="TEXT-ALIGN: center" id="panelContentEmployeeDetail" runat="server" Width="98%" CssClass="text" __designer:wfdid="w20"><DIV style="BORDER-RIGHT: #cccccc 2px solid; PADDING-RIGHT: 0px; BORDER-TOP: #cccccc 0px solid; PADDING-LEFT: 0px; FONT-WEIGHT: normal; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: #cccccc 2px solid; WIDTH: 98%; PADDING-TOP: 0px; BORDER-BOTTOM: #cccccc 2px solid" id="DIV1" onclick="return DIV1_onclick()"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" colSpan=2><asp:GridView id="gvProject" runat="server" Width="100%" __designer:wfdid="w21" AutoGenerateColumns="False" SkinID="gvnew" UseAccessibleHeader="False"><Columns>
<asp:TemplateField HeaderText="Project"><ItemTemplate>
<asp:Label id="lblTitle" runat="server" Text='<%#CheckIfTitleExists(Eval("title").ToString())%>'></asp:Label><asp:DropDownList
    ID="ddSupplier" runat="server">
</asp:DropDownList>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lblTitle2" runat="server" Text='<%# CheckIfTitleExists2(Eval("title").ToString()) %>'></asp:Label><asp:Label id="Label4" runat="server" Text='<%# Eval("amount", "{0:N}") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
</Columns>
    <HeaderStyle BackColor="#2977DC" ForeColor="White" />
                        <FooterStyle BackColor="#2977DC" />
</asp:GridView><BR /><BR /></TD></TR><TR><TD style="VERTICAL-ALIGN: top; HEIGHT: 16px; TEXT-ALIGN: center" colSpan=2></TD></TR><TR><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: center" colSpan=2></TD></TR></TBODY></TABLE></DIV></asp:Panel>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button id="btnsave" onclick="btnsave_Click" runat="server" Width="200px" OnClientClick="StartProgressBar();" ValidationGroup="save" Text="CREATE RESOLUTION" __designer:wfdid="w22"></asp:Button> <asp:Button id="btnPreview" onclick="btnPreview_Click" runat="server" Width="200px" Text="PREVIEW" __designer:wfdid="w23"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<BR /><BR /><BR /><BR /><cc1:ModalPopupExtender id="ModalPopupExtender1" runat="server" __designer:dtid="2814749767106621" CancelControlID="btnCancel" PopupControlID="pnl_pr_pop_up" BackgroundCssClass="modalBackground" TargetControlID="pr_pop_up" __designer:wfdid="w24"></cc1:ModalPopupExtender> <BR /><asp:Panel style="DISPLAY: none; TEXT-ALIGN: center" id="pnl_pr_pop_up" runat="server" Width="217px" __designer:dtid="2814749767106594" BorderWidth="2px" BorderStyle="Solid" BorderColor="#FFA016" BackColor="White" __designer:wfdid="w25"><TABLE style="WIDTH: 217px; TEXT-ALIGN: left" cellSpacing=0 cellPadding=0 border=0 __designer:dtid="2814749767106595"><TBODY><TR __designer:dtid="2814749767106596"><TD style="FONT-WEIGHT: bold; COLOR: white; HEIGHT: 21px; BACKGROUND-COLOR: #ffa016; TEXT-ALIGN: center" colSpan=3 __designer:dtid="2814749767106597">Resolution Number </TD></TR><TR __designer:dtid="2814749767106598"><TD style="FONT-WEIGHT: bold; COLOR: white; HEIGHT: 21px; BACKGROUND-COLOR: #ffa016; TEXT-ALIGN: center" colSpan=3 __designer:dtid="2814749767106599">Recommending of </TD></TR><TR __designer:dtid="2814749767106600"><TD style="FONT-WEIGHT: bold; COLOR: white; HEIGHT: 21px; BACKGROUND-COLOR: #ffa016; TEXT-ALIGN: center" colSpan=3 __designer:dtid="2814749767106601">Award</TD></TR><TR __designer:dtid="2814749767106602"><TD colSpan=3 __designer:dtid="2814749767106603"><TABLE style="WIDTH: 213px" cellSpacing=0 cellPadding=0 border=0 __designer:dtid="2814749767106604"><TBODY><TR __designer:dtid="2814749767106605"><TD style="HEIGHT: 21px" colSpan=4 __designer:dtid="2814749767106606"> </TD></TR><TR __designer:dtid="2814749767106607"><TD style="TEXT-ALIGN: center" colSpan=4 __designer:dtid="2814749767106608"><asp:UpdatePanel id="UpdatePanel1" runat="server" __designer:dtid="2814749767106609" __designer:wfdid="w26"><ContentTemplate __designer:dtid="2814749767106610">
<asp:TextBox style="TEXT-ALIGN: left" id="txtResolutionNumber" runat="server" Width="90%" __designer:wfdid="w27" OnTextChanged="txtResolutionNumber_TextChanged"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="ok" __designer:wfdid="w28" ErrorMessage="*" ControlToValidate="txtResolutionNumber"></asp:RequiredFieldValidator> 
</ContentTemplate>
</asp:UpdatePanel></TD></TR><TR __designer:dtid="2814749767106611"><TD style="WIDTH: 33px; HEIGHT: 18px" __designer:dtid="2814749767106612"></TD><TD style="WIDTH: 24px; HEIGHT: 18px" __designer:dtid="2814749767106613"></TD><TD style="WIDTH: 152px; HEIGHT: 18px" __designer:dtid="2814749767106614"></TD><TD style="WIDTH: 31px" __designer:dtid="2814749767106615"></TD></TR><TR __designer:dtid="2814749767106616"><TD style="HEIGHT: 24px; TEXT-ALIGN: center" colSpan=4 __designer:dtid="2814749767106617"><asp:Button id="btnOK" runat="server" Width="80px" __designer:dtid="2814749767106618" OnClientClick="StartProgressBar();" Text="OK" __designer:wfdid="w29"></asp:Button><asp:Button id="btnCancel" runat="server" Width="80px" __designer:dtid="2814749767106619" Text="CANCEL" __designer:wfdid="w30"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><asp:Label id="pr_pop_up" runat="server" __designer:dtid="2814749767106620" __designer:wfdid="w31"></asp:Label></asp:Panel><BR /><asp:Panel style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #0033cc; BORDER-BOTTOM-WIDTH: 1px; BORDER-BOTTOM-COLOR: #0033cc; BORDER-TOP-COLOR: #0033cc; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #0033cc" id="PanelProgress" runat="server" Width="109px" __designer:wfdid="w32">
                <img src="../images/ajax-loader.gif" /></asp:Panel> <cc1:ModalPopupExtender id="ProgressBarModalPopupExtender" runat="server" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" __designer:wfdid="w33" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender> <asp:Button style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none" id="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w34" Enabled="False"></asp:Button> <BR /><BR />
</contenttemplate>
                </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    &nbsp;
</td>
</tr>
</table>

</asp:Content>

