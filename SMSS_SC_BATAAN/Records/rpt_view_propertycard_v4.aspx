<%@ Page 
    Title="ViewPropertyCard" 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="rpt_view_propertycard_v4.aspx.vb" 
    Inherits="Inventory_rpt_view_propertycard_v4"
    StylesheetTheme="SkinFile" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:ScriptManager ID="tScriptManager1" runat="server">
</asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
                <table  style="width: 1010px">
                    <tr>
                        <td style="width: 98%" class="PageTitle">PROPERTY INVENTORY REPORT</td>
                      
                    </tr>
                    <tr>
                        <td width="1000px" style="text-align:left">
                            <asp:LinkButton ID="LnkPrevious" runat="server" CssClass="LinkBtnSelect" Text="Back to Previous Page ..."></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="1" cellspacing="1" style="width: 80%">
                                        <tr>
                                            <td class="column_RightBold" style="height: 24px" width="20%">Report Type : </td>
                                            <td class="text5" style="height: 24px" width="30%">
                                                <asp:DropDownList ID="ddReport" runat="server" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddReport_SelectedIndexChanged" style="margin-left: 0px" Width="150px">
                                                    <asp:ListItem Value="0">Continuous </asp:ListItem>
                                                    <asp:ListItem Value="1">Monthly </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="column_CenterBold" style="width: 20%; height: 24px;">Month : </td>
                                            <td class="text5" style="height: 24px" width="20%">
                                                <asp:DropDownList ID="ddMonth" runat="server" enabled="false" Width="150px">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="1">January</asp:ListItem>
                                                    <asp:ListItem Value="2">February</asp:ListItem>
                                                    <asp:ListItem Value="3">March</asp:ListItem>
                                                    <asp:ListItem Value="4">April</asp:ListItem>
                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                    <asp:ListItem Value="6">June</asp:ListItem>
                                                    <asp:ListItem Value="7">July</asp:ListItem>
                                                    <asp:ListItem Value="8">August</asp:ListItem>
                                                    <asp:ListItem Value="9">September</asp:ListItem>
                                                    <asp:ListItem Value="10">October</asp:ListItem>
                                                    <asp:ListItem Value="11">November</asp:ListItem>
                                                    <asp:ListItem Value="12">December</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="column_CenterBold" style="width: 15%; height: 24px;">Year : </td>
                                            <td class="drpdownCSS" style="height: 24px" width="50%">
                                                <asp:DropDownList ID="drpYear" runat="server" enabled="false" Width="150px">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="10px"></td>
                                            <td>
                                                <asp:Button ID="BtnPreview" runat="server" cssClass="CSButton" OnClick="BtnPreview_Click" Text="PREVIEW" Width="100" />
                                            </td>
                                        </tr>
                                    </table>

                        </td>
                    </tr>
                    
                    <tr>
                        <td  width="1000px">
                            <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="True"  hastogglegrouptreebutton="False" style="background-color: white; text-align: left;" height="800px" width="950px" bestfitpage="False" bordercolor="Silver" borderstyle="Solid" borderwidth="1px" ToolPanelView="None" PrintMode="ActiveX"></cr:crystalreportviewer>
                            <cr:crystalreportsource id="CrystalReportSource1" runat="server">
                            <Report FileName="rpt_view_property_card_report.rpt">
                            </Report>
                            </cr:crystalreportsource>
                        </td>
                    </tr>
                </table>
           </ContentTemplate>
      </asp:UpdatePanel>
</asp:Content>