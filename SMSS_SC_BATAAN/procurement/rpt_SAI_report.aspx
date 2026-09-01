<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"  EnableEventValidation="false"
CodeFile="rpt_SAI_report.aspx.vb" Inherits="procurement_rpt_SAI_report" 
title="SAI Report" StylesheetTheme="SkinFile"%>


<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
<TABLE style="TEXT-ALIGN: center" width=1015><TBODY><TR><TD style="TEXT-ALIGN: center" width=1015><TABLE class="PageTitle"><TBODY><TR><TD style="WIDTH: 1000px">SUPPLY AVAILABILITY INQUIRY REPORT</TD></TR></TBODY></TABLE><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 1000px" align=left><asp:LinkButton id="LinkButton1" runat="server" __designer:wfdid="w69" CssClass="text" OnClick="LinkButton1_Click">Back to previous page...</asp:LinkButton></TD></TR><TR><TD style="WIDTH: 1000px; TEXT-ALIGN: left"><CR:CrystalReportViewer style="BACKGROUND-COLOR: white" id="CrystalReportViewer1" runat="server" __designer:dtid="6473924464345094" __designer:wfdid="w70" HasToggleGroupTreeButton="False"  AutoDataBind="true"></CR:CrystalReportViewer><BR /><CR:CrystalReportSource id="CrystalReportSource1" runat="server" __designer:dtid="6473924464345098" __designer:wfdid="w72">
<Report FileName="rpt_SAI.rpt"></Report>
</CR:CrystalReportSource></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>

</asp:Content>

