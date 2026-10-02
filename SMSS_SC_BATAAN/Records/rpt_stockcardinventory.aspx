<%@ Page Title="StockCardInventory" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="rpt_stockcardinventory.aspx.vb" Inherits="rpt_stockcardinventory" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<script runat="server">



</script>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript">
        function PrintReport() {
            var frame = document.getElementById("pdfPrintFrame");
            if (!frame) {
                alert("Print frame not found.");
                return;
            }

            // Reset any previous handler so we do not trigger print twice.
            frame.onload = null;

            frame.onload = function () {
                // Small delay so the PDF viewer finishes initializing
                // before we ask it to print.
                setTimeout(function () {
                    try {
                        frame.contentWindow.focus();
                        frame.contentWindow.print();
                    } catch (e) {
                        alert("Could not open the print dialog automatically. The report will be shown so you can print it manually.");
                        frame.style.display = "block";
                        frame.style.width = "100%";
                        frame.style.height = "900px";
                    }
                }, 800);
            };

            // Cache-buster so the browser always reloads the PDF fresh.
            frame.src = "rpt_stockcardinventory.aspx?print=1&t=" + new Date().getTime();
        }
    </script>

    <iframe id="pdfPrintFrame" style="display:none; width:0; height:0; border:0;"></iframe>


            <div>
                <table width="1020px" cellpadding="0" cellspacing="0">

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">Stock Card Report</td>
                        <td style="width: 1%"></td>
                    </tr>

                    <!-- ===== Block A: Back button ===== -->
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="left">
                            <table width="1000px" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left">
                                        <asp:LinkButton ID="LnkPrevious" runat="server" CssClass="LinkBtnSelect" Text="Back to Previous Page ..."></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>

                    <!-- ===== Block B: Filter controls ===== -->
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
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
                        <td style="width: 1%"></td>
                    </tr>

                    <!-- ===== Block C: Print button — ALWAYS directly above Block D ===== -->
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="left">
                            <table width="1000px" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right">
                                        <asp:LinkButton ID="btnPrintReport" runat="server" CssClass="LinkBtnSelect" OnClientClick="PrintReport(); return false;">Print Report</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>

                    <!-- ===== Block D: Report viewer container ===== -->
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <div style="width: 1000px; background-color: #808080; text-align: center; vertical-align: middle">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" align="center">
                                            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"
                                                AutoDataBind="true"
                                                HasToggleGroupTreeButton="False"
                                                HasCrystalLogo="False"
                                                HasSearchButton="False"
                                                HasDrilldownTabs="False"
                                                BestFitPage="False"
                                                BackColor="#ffffff"
                                                Height="930px"
                                                Width="980px"
                                                BorderStyle="Solid"
                                                BorderColor="#2977dc"
                                                BorderWidth="1px"
                                                ToolPanelView="None"
                                                HasGroupTree="False"
                                                HasPrintButton="False" />
                                            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                                <Report FileName="rpt_StockCardInventory.rpt">
                                                </Report>
                                            </CR:CrystalReportSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>


</asp:Content>