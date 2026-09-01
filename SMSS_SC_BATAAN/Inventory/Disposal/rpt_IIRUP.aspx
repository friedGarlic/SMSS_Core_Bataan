<%@ Page Title="IIRUP" 
    Language="VB" 
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" 
    CodeFile="rpt_IIRUP.aspx.vb" 
    Inherits="Inventory_Disposal_rpt_IIRUP" 
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
  

        <div style="width: 1000px; background-color: #808080; text-align: center; vertical-align: middle">
            <table width="100%">
                <tr>
                    <td style="width: 100%; height: 10px"></td>
                </tr>
               
                <tr>
                    <td style="width: 100%" align="left">
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton>
                        
                        <CR:CrystalReportViewer ID="Disposal_Reports" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                            HasSearchButton="False" HasDrilldownTabs="False"  BestFitPage="False" BackColor="#ffffff" Height="930px" Width="980px"
                            BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" ToolPanelView="None" />

                        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                            <Report FileName="IIRUP.rpt">
                            </Report>
                        </CR:CrystalReportSource>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 10px"></td>
                </tr>
            </table>
        </div>



    </div>
</asp:Content>