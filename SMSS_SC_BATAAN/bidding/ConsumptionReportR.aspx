<%@ Page Title="CONSUMPTION REPORT" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="ConsumptionReportR.aspx.vb" Inherits="Bidding_ConsumptionReport" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

                   <table cellspacing="1" style="width:100%">

                <tr>
                    <td width="10px"></td>
                    <td class="PageTitle" width="1000px">REPORT OF CONSUMPTION</td>
                </tr>
                <tr>
                    <td width="10px"></td>
                    <td width="1000px"></td>
                </tr>
                <tr>
                    <td width="10px"></td>
                    <td width="1000px">
                       
                        <table cellpadding="1" cellspacing="1" style="width: 80%">
                            <tr>
                                <td class="column_RightBold" width="20%">Account : </td>
                                <td class="text5" width="80%">
                                    <asp:DropDownList ID="drpAccount" runat="server" Width="300px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="column_RightBold" width="20%">Month : </td>
                                <td class="text5" width="80%">
                                    <asp:DropDownList ID="drpMonth" runat="server" Width="150px">
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
                            </tr>
                            <tr>
                                <td class="column_RightBold" width="20%">Year : </td>
                                <td class="text5" width="80%">
                                    <asp:DropDownList ID="drpYear" runat="server" Width="150px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                          
                        </table>

                    </td>
                </tr>
               <tr>
                    <td width="10px"></td>
                    <td width="1000px" style="align-content:center">
                               <asp:Button ID="BtnPreview" runat="server" Text="PREVIEW" Width="200px" CssClass="CSButton" />
                    </td>
                </tr>
                <tr>
                    <td width="10px"></td>
                    <td width="1000px">
                     <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                                        BackColor="#ffffff" BestFitPage="True" ToolPanelView="None" ToolPanelWidth="0px" />
                        <cr:crystalreportsource id="CrystalReportSource1" runat="server">
                        <Report FileName="rpt_Consumption.rpt">
                        </Report>
                        </cr:crystalreportsource>
      

                    </td>
                </tr>
            
            </table>

    

</asp:Content>

