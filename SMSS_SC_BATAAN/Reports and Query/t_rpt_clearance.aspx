<%@ Page Language="VB" AutoEventWireup="false" CodeFile="t_rpt_clearance.aspx.vb" StylesheetTheme="SkinFile" MasterPageFile="~/MasterPage.master" Inherits="t_rpt_clearance" Title="Clearance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<table width="1015px" style="text-align:center">
<tr>
<td width="1015px" style="text-align:center">

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
<TABLE style="WIDTH: 1015px"><TBODY><TR><TD style="WIDTH: 1015px"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 1000px"><TABLE class="PageTitle" __designer:dtid="562949953421316"><TBODY><TR __designer:dtid="562949953421317"><TD style="WIDTH: 1000px" __designer:dtid="562949953421318">CLEARANCE</TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 1000px"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 20%" class="column_RightBold">Department :</TD><TD style="WIDTH: 80%" class="text5"><asp:DropDownList id="ddDepartment" runat="server" Width="400px" CssClass="txtboxinspection" AutoPostBack="True" OnSelectedIndexChanged="ddDepartment_SelectedIndexChanged" __designer:wfdid="w5"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 20%" class="column_RightBold">Function :</TD><TD style="WIDTH: 80%" class="text5"><asp:DropDownList id="ddFunction" runat="server" Width="400px" CssClass="txtboxinspection" AutoPostBack="True" OnSelectedIndexChanged="ddFunction_SelectedIndexChanged" __designer:wfdid="w6"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 20%" class="column_RightBold">Employee :</TD><TD style="WIDTH: 80%" class="text5"><asp:DropDownList id="ddEmployee" runat="server" Width="400px" CssClass="txtboxinspection" AutoPostBack="True" OnSelectedIndexChanged="ddEmployee_SelectedIndexChanged" __designer:wfdid="w7"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 20%" class="column_RightBold"></TD><TD style="WIDTH: 80%" class="text5"></TD></TR><TR><TD style="WIDTH: 20%" class="column_RightBold"></TD><TD style="WIDTH: 80%" class="text5"><asp:Button id="btnPreview" runat="server" Width="200px" Text="PREVIEW" CssClass="CSButton" Height="30px" __designer:wfdid="w8" OnClick="btnPreview_Click"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel><br />
    <br />
    <br />
    <br />
    
</td>
</tr>
</table>    
</asp:Content>