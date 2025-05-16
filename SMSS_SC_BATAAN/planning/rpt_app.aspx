<%@ Page Language="VB" 
    MasterPageFile="~/MasterPage.master"  
    AutoEventWireup="false" 
    CodeFile="rpt_app.aspx.vb" 
    Inherits="rpt_app" 
    Title="Annual Procurement Plan Report"
    StylesheetTheme="SkinFile" 
%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

	<div>
		<table style="width: 1010px">
			<tr>
				<td style="width: 1000px">
					<table style="width: 1000px">
						<tr>
							<td class="text5" style="width: 1000px">
								<asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton>
							</td>
						</tr>
						<tr>
							<td class="text5" style="width: 1000px">
								<asp:Label runat="server">APP Format :</asp:Label>
								<asp:DropDownList ID="rbFormat" runat="server" CssClass="drpdownCSS" AutoPostBack="true" Width="350px">
                                    <asp:ListItem Selected="True" Value="0">--SELECT--</asp:ListItem>
									<asp:ListItem Value="1">APP Report Format(5) v1</asp:ListItem>
									<asp:ListItem Value="2">APP Report Format(7) v2</asp:ListItem>
									<asp:ListItem Value="3">APP Report Format(5) v3</asp:ListItem>
									<asp:ListItem Value="4">APP Report Format(7) v4</asp:ListItem>
								</asp:DropDownList>
							</td>
						</tr>
						<tr>
							<%--<td style="width: 1000px">
								<CR:CrystalReportViewer ID="CrystalReportViewer3" runat="server" AutoDataBind="true" BestFitPage="True" HasToggleGroupTreeButton="False" Height="750px" Style="background-color: white; text-align: left;" Width="1000px" BorderColor="Silver" BorderStyle="Solid" BoreWidth="1px" ToolPanelView="None" />
								<CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
									<Report FileName="rpt_app_GPPB_LGU.rpt"></Report>
								</CR:CrystalReportSource>
								<CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
									<Report FileName="rpt_app_GPPB_LGU_v4.rpt"></Report>
								</CR:CrystalReportSource>
								<CR:CrystalReportSource ID="CrystalReportSource3" runat="server">
									<Report FileName="app_cagayan_nonCSE_Updated.rpt"></Report>
								</CR:CrystalReportSource>
								<CR:CrystalReportSource ID="CrystalReportSource4" runat="server">
									<Report FileName="app_cagayan_nonCSE_Updated_v2.rpt"></Report>
								</CR:CrystalReportSource>
							</td>--%>
                            <td style="width: 1000px">
                                <CR:CrystalReportViewer ID="CrystalReportViewer3" runat="server" AutoDataBind="true" BestFitPage="True" HasToggleGroupTreeButton="False" Height="750px" Style="background-color: white; text-align: left;" Width="1000px" BorderColor="Silver" BorderStyle="Solid" BoreWidth="1px" ToolPanelView="None" />

                                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server"></CR:CrystalReportSource>
                                <CR:CrystalReportSource ID="CrystalReportSource2" runat="server"></CR:CrystalReportSource>

                            </td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</div>
</asp:Content>

