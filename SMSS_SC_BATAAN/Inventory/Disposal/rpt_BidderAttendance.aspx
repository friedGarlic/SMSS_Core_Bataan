<%@ Page Title="List of Interested Bidders" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_BidderAttendance.aspx.vb"
    Inherits="Inventory_Disposal_rpt_BidderAttendance" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript"> 
        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) {
                return false;
            }
        }
        document.onkeypress = stopRKey;

        function toPeso(objctrl) {
            //Get the Entered Value
            var number = objctrl.value.toString(),
                //Split the number between dollars and cents
                php = number.split('.')[0], cents = (number.split('.')[1] || '') + '00';
            php = php.split('').reverse().join('').replace(/(\d{3}(?!$))/g, '$1,').split('').reverse().join('');
            //Concatenate the number with currecny symbol
            objctrl.value = php + '.' + cents.slice(0, 2);
        }

    </script>

    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">LIST OF INTERESTED BIDDERS
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LinkBtnSelect">Back to Previous Page ...</asp:LinkButton>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <table width="60%">
                        <tr>
                            <td style="width: 20%" class="column_RightBold">Number of Copies :
                            </td>
                            <td style="width: 80%" class="column_Left">
                                <asp:TextBox runat="server" ID="txtCopies" CssClass="txtbox_Amt" Width="20%" Text="0"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" class="column_RightBold">Price :</td>
                            <td style="width: 80%" class="column_Left">
                                <asp:TextBox runat="server" ID="txtPrice" CssClass="txtbox_Amt" Width="20%" Text="0.00" onblur="toPeso(this)"></asp:TextBox>
                                &nbsp;<asp:Button runat="server" ID="btnPreview" CssClass="CSButton" Text="Preview" Width="20%" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" class="column_RightBold"></td>
                            <td style="width: 80%" class="column_Left"></td>
                        </tr>
                    </table>

                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <div style="width: 880px; text-align: center; vertical-align: middle">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%; height: 10px"></td>
                            </tr>
                            <tr>
                                <td style="width: 100%" align="center">

                                    <CR:CrystalReportViewer ID="BidderReport" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" HasSearchButton="False" HasDrilldownTabs="False"
                                        BestFitPage="true" BackColor="#ffffff" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />

                                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                        <Report FileName="rpt_BiddersAttendance.rpt">
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
