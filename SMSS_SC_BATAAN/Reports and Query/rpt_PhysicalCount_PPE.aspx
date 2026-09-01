<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
    CodeFile="rpt_PhysicalCount_PPE.aspx.vb" Inherits="Reports_and_Query_rpt_PhysicalCount_PPE"
    Title="Physical Count of PPE" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">PHYSICAL COUNT OF PPE REPORT
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LinkBtnSelect" Text="Back to Previous Page ..."></asp:LinkButton>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <div style="width: 1000px; background-color: #808080; text-align: center; vertical-align: middle">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%; height: 5px"></td>
                            </tr>
                            <tr>
                               <td style="width: 100%" align="center">
                                    <%--<CR:CrystalReportViewer 
                                        ID="rpt_PhysicalCount_PPE" 
                                        runat="server" 
                                        AutoDataBind="true"  
                                        HasToggleGroupTreeButton="False"
                                        HasCrystalLogo="False"
                                        BestFitPage="False" Width="980px"
                                        Height="820px" BackColor="#ffffff">

                                    </CR:CrystalReportViewer>--%>

                                   <CR:CrystalReportViewer 
                                    ID="rpt_PhysicalCount_PPE" 
                                    runat="server"
                                    HasToggleGroupTreeButton="False"
                                    HasCrystalLogo="False"
                                    BestFitPage="False"
                                    Width="980px"
                                    Height="820px"
                                    BackColor="#ffffff"
                                    ToolPanelView="None"
                                    EnableDatabaseLogonPrompt="False"
                                    EnableParameterPrompt="False"
                                    ReuseParameterValuesOnRefresh="True">

                                </CR:CrystalReportViewer>


                                    

                                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                        <Report FileName="rpt_PhysicalCount_PPE.rpt">
                                        </Report>
                                    </CR:CrystalReportSource>
                                </td>

                               
                            </tr>
                            <tr>
                                <td style="width: 100%; height: 5px"></td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%"></td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%"></td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%"></td>
                <td style="width: 1%"></td>
            </tr>
        </table>
    </div>




</asp:Content>

