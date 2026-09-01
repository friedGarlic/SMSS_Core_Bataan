<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" EnableEventValidation="false" 
CodeFile="rpt_purchase_request_gasoline.aspx.vb" Inherits="rpt_purchase_request_gasoline" title="Purchase Request Report"StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<table width="1015px" style="text-align:center">
<tr>
<td width="1015px" style="text-align:center">


    <table class="PageTitle">
        <tr>
            <td style="width: 1000px">
                &nbsp;PREVIEW PR GASOLINE</td>
        </tr>
    </table>
 </td>
</tr>
</table>   

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
<TABLE class="text" cellSpacing=0 cellPadding=0 width=1000 border=0><TBODY><TR><TD style="WIDTH: 800px; TEXT-ALIGN: left"><asp:LinkButton id="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton> <BR /></TD></TR><TR><TD style="WIDTH: 1000px" align=left><BR /><asp:Panel id="Panel1" runat="server" Width="98%" Font-Bold="True" CssClass="textgrid" GroupingText="Summary"><asp:GridView style="FONT-WEIGHT: normal" id="gvSummary" runat="server" Width="90%" DataKeyNames="isVarious,pr_period_key_id,rc_id,function_id,OBR_Hdr_ID" SkinID="GridViewGL" ShowFooter="True" AutoGenerateColumns="False" __designer:wfdid="w9"><Columns>
<asp:TemplateField HeaderText="OFFICE" ShowHeader="False"><ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                        Font-Underline="False" Text='<%# bind("rc_name") %>'></asp:LinkButton>
                                
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="total" DataFormatString="{0:N}" HeaderText="AMOUNT">
<FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView> </asp:Panel> </TD></TR></TBODY></TABLE>&nbsp; 
</contenttemplate>
</asp:UpdatePanel>
    <table style="width: 1000px">
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 900px" class="text5">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" CssClass="PanelBorder"
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="0">Purchase Request Report</asp:ListItem>
                    <asp:ListItem Value="1">Obligation Request Report</asp:ListItem>
                    <asp:ListItem Value="2">Summary Report</asp:ListItem>
                    <asp:ListItem Value="3">Detailed Report</asp:ListItem>
                </asp:RadioButtonList>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" 
                    EnableDrillDown="False" HasToggleGroupTreeButton="False" Style="background-color: white" ToolPanelView="None" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="rpt_purchase_request_gasoline.rpt">
                    </Report>
                </CR:CrystalReportSource>

                <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true"
                    BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" 
                    EnableDrillDown="False" HasToggleGroupTreeButton="False" Style="background-color: white" ToolPanelView="None" />
                 <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                    <Report FileName="OBRReport_gasoline.rpt">
                    </Report>
                </CR:CrystalReportSource>

                <CR:CrystalReportViewer ID="CrystalReportViewer3" runat="server" AutoDataBind="true"
                    BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" 
                    EnableDrillDown="False" HasToggleGroupTreeButton="False" Style="background-color: white" ToolPanelView="None" />
                      <CR:CrystalReportSource ID="CrystalReportSource3" runat="server">
                    <Report FileName="rpt_purchase_request_gasoline_summaryrpt.rpt">
                    </Report>
                </CR:CrystalReportSource>

                <CR:CrystalReportViewer ID="CrystalReportViewer4" runat="server" AutoDataBind="true"
                    BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                    EnableDrillDown="False" HasToggleGroupTreeButton="False" Style="background-color: white" ToolPanelView="None" />

                <CR:CrystalReportSource ID="CrystalReportSource4" runat="server">
                    <Report FileName="rpt_purchase_request_gasoline_detailed.rpt">
                    </Report>
                </CR:CrystalReportSource>
            </td>
        </tr>
    </table>
    &nbsp; &nbsp; &nbsp;



    
</asp:Content>

