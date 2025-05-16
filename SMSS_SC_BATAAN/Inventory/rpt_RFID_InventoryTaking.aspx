<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_RFID_InventoryTaking.aspx.vb" 
Inherits="Inventory_rpt_RFID_InventoryTaking" title="INVENTORY TAKING REPORT" EnableEventValidation="false" StylesheetTheme="SkinFile"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:ScriptManager id="ScriptManager1" runat="server">
</asp:ScriptManager>

<script language="javascript" type="text/javascript">
function Table2_onclick() {
}
function fun1(e, button1){
          var evt = e ? e : window.event;
          var bt = document.getElementById(button1);
          if (bt){
              if (evt.keyCode == 13){
                    bt.click();
                    return false;
              }
          }
    }
 </script>

    <table style="width: 1000px">
        <tr>
            <td align="center" class="PageTitle" style="width: 1000px">
                &nbsp;RFID INVENTORY TAKING REPORT</td>
        </tr>
        <tr>
            <td align="center" style="width: 1000px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" style="width: 1000px">
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 1000px">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    BestFitPage="False" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                     HasToggleGroupTreeButton="False" Style="background-color: white"
                    Width="950px" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="rpt_RFID_Inventory.rpt">
                    </Report>
                </CR:CrystalReportSource>
            </td>
        </tr>
    </table>
 
 
 
 
 
 
</asp:Content>

