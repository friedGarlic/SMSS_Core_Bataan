<%@ Page Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="rpt_Property_Acknowledgement_Receipt_Report.aspx.vb" 
    Inherits="Reports_and_Query_rpt_Property_Acknowledgement_Receipt_Report" 
    Title ="Property Acknowledgement Receipt" 
    StylesheetTheme="SkinFile"%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width: 1015px">
        <tr>
            <td>
                  <table style="width: 1000px">
                      <tr>
                          <td align="left">
                              <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text5">Back to previous page...</asp:LinkButton>
                          </td>
                      </tr>
                      <tr>
                          <td align="left">
                              <asp:RadioButtonList id="RadioButtonList1" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                                  <asp:ListItem Selected="True" Value="1">Report Format 1</asp:ListItem>
                                  <asp:ListItem Value="2">Report Format 2</asp:ListItem>
                              </asp:RadioButtonList>
                          </td>
                      </tr>
                      <tr>
                          <td align="left" style="width: 1000px">
                              <asp:MultiView ID="MultiView1" runat="server">
                                  <asp:View ID="View1" runat="server">
                                      <table width="100%">
                                          <tr>
                                              <td>
                                                  <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" BestFitPage="False" Height="800px" Width="980px" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                  <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                                      <Report FileName="rpt_Property_Acknowledgement_Receipt.rpt">
                                                      </Report>
                                                  </CR:CrystalReportSource>
                                              </td>
                                          </tr>
                                      </table>
                                  </asp:View>
                                  <asp:View ID="View2" runat="server">
                                      <table width="100%">
                                          <tr>
                                              <td class="column_LeftBold">
                                                  Noted By : <asp:DropDownList ID="drpNotedBy" runat="server" CssClass="drpdownCSS" Width="200" AutoPostBack="true"></asp:DropDownList> Position : <asp:Label ID="lblPosition" runat="server" Text=""></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true" BestFitPage="False" Height="800px" Width="980px" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                  <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                                                      <Report FileName="rpt_Property_Acknowledgement_Receipt_v2.rpt">
                                                      </Report>
                                                  </CR:CrystalReportSource>
                                              </td>
                                          </tr>
                                      </table>
                                  </asp:View>
                              </asp:MultiView>
                          </td>
                      </tr>
                  </table>
            </td>
        </tr>
    </table>
</asp:Content>