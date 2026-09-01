<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_RFID.aspx.vb" Inherits="Reports_and_Query_t_RFID" 
title="RFID INVENTORY" EnableEventValidation="false" StylesheetTheme="SkinFile"%>


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
 
 
<asp:UpdatePanel id="UpdatePanel1" runat="server">
<contenttemplate>
    <table style="width: 1000px">
        <tr>
            <td align="center" class="PageTitle" style="width: 1000px">
                &nbsp;RFID INVENTORY</td>
        </tr>
        <tr>
            <td align="center" style="width: 1000px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" style="width: 1000px">
                <table style="width: 700px">
                    <tr>
                        <td class="column_RightBold" style="width: 100px">
                            NOTE:
                        </td>
                        <td class="text5" style="width: 600px">
                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold" style="width: 100px">
                        </td>
                        <td class="text5" style="width: 600px">
                            <em><span style="color: red"><strong>
                            1. Save RFID scanned files at "E:\Alvin Files\FILES\RFID\SCANNED"</strong></span></em></td>
                    </tr>
                    <tr>
                        <td class="column_RightBold" style="width: 100px">
                        </td>
                        <td class="text5" style="width: 600px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="column_RightBold" style="width: 100px">
                            Year :
                        </td>
                        <td class="text5" style="width: 600px">
                            <asp:DropDownList ID="ddYear" runat="server" Width="150px">
                            </asp:DropDownList></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 1000px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" style="width: 1000px">
                <asp:Button ID="btnConvert" runat="server" OnClick="btnConvert_Click" Text="CONVERT" Width="200px" OnClientClick="StartProgressBar();" />
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="SAVE" Width="200px" OnClientClick="StartProgressBar();" /></td>
        </tr>
        <tr>
            <td align="center" style="width: 1000px">
                &nbsp;</td>
        </tr>
    </table>
    <asp:Panel ID="PanelProgress" runat="server" Style="border-top-width: 1px; border-left-width: 1px;
        border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc;
        border-top-color: #0033cc; background-color: transparent; text-align: center;
        border-right-width: 1px; border-right-color: #0033cc" Width="109px">
        <img src="../images/ajax-loader.gif" /></asp:Panel>
    <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BehaviorID="ProgressBarModalPopupExtender"
        PopupControlID="PanelProgress" TargetControlID="ButtonProgress">
    </cc1:ModalPopupExtender>
    <asp:Button ID="ButtonProgress" runat="server" Enabled="False" Style="border-top-style: none;
        border-right-style: none; border-left-style: none; background-color: transparent;
        border-bottom-style: none" Width="16px" />


</contenttemplate>
</asp:UpdatePanel>
    <table style="width: 1000px">
        <tr>
            <td style="width: 1000px" align="center">
            </td>
        </tr>
        <tr>
            <td style="width: 1000px" align="center">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    BestFitPage="False" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                     HasToggleGroupTreeButton="False" Height="800px" Style="background-color: white;
                    text-align: left" Width="900px" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="rpt_ReturnedSummary.rpt">
                    </Report>
                </CR:CrystalReportSource>
            </td>
        </tr>
        <tr>
            <td style="width: 1000px" align="center">
            </td>
        </tr>
    </table>



</asp:Content>

