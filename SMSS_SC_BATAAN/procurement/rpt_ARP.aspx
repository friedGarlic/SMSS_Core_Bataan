<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
CodeFile="rpt_ARP.aspx.vb" Inherits="procurement_rpt_ARP" title="Agency Procurement Request" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   


    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 800px; text-align: left">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton>
                &nbsp; &nbsp;&nbsp;
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    BestFitPage="False"  HasToggleGroupTreeButton="False"
                     Height="900px" Style="background-color: white; text-align: left"
                    Width="850px" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
            </td>
        </tr>
      
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 800px">
        <tr>
            <td style="width: 800px">
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="rpt_APR.rpt">
        </Report>
    </CR:CrystalReportSource>
                &nbsp; &nbsp;

                </td>
        </tr>
    </table>
</asp:Content>

