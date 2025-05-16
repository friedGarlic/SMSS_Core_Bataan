<%@ Page Title="Disposal Reports" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Disposal_ReportEncoding.aspx.vb" Inherits="Inventory_Disposal_Disposal_ReportEncoding" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



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
                //Split the number between WholeNumber and Decimals
                php = number.split('.')[0], cents = (number.split('.')[1] || '') + '00';
            php = php.split('').reverse().join('').replace(/(\d{3}(?!$))/g, '$1,').split('').reverse().join('');
            //Concatenate the number 
            objctrl.value = php + '.' + cents.slice(0, 2);
        }

    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">DISPOSAL REPORTS
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                         <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="left">
                            <asp:LinkButton runat="server" ID="lnkBack" Text="Back to previous ..."  Visible="false" CssClass="LinkBtnSelect" OnClientClick="StartProgressBar();" ></asp:LinkButton>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <div runat="server" id="divDisposal" class="ReportBorderCSS" style="width: 80%; height: 800px">
                                <asp:MultiView runat="server" ID="mvDisposal">


                                    <asp:View runat="server" ID="vwNTP">
                                        <table width="90%">
                                            <tr>
                                                <td style="width: 100%; height: 30px" align="center"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_CenterBold">NOTICE TO PROCEED
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Center">
                                                    <asp:Label runat="server" ID="lblNTP_ISSPNo" Text="ISSP No."></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 20px" align="center"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Left">
                                                    <asp:Label runat="server" ID="lblNTP_Date" Text="January 01, 2000"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 15px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_LeftBold">
                                                    <asp:Label runat="server" ID="lblNTP_Rep" Text="Mr. John Doe"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_LeftBold">
                                                    <asp:Label runat="server" ID="lblNTP_SuppName" Text="GeoData Solutions Inc."></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Left">
                                                    <asp:Label runat="server" ID="lblNTP_Address" Text="Pasig City, Manila, Philippines"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 20px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Left">
                                                    <span class="column_Left">Dear </span>
                                                    &nbsp;<asp:Label runat="server" ID="lblNTP_Rep2" Text="Mr. John Doe"></asp:Label>
                                                    <span class="column_LeftBold">;</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 10px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_LeftBold">
                                                    <asp:TextBox runat="server" ID="txtNTP_Content" CssClass="txtbox_ReportEncoding" Width="98%" Height="250px" Text="" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 50px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Left">
                                                    <asp:Label runat="server" ID="Label1" Text="Very truly yours,"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 30px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_LeftBold">
                                                    <asp:Label runat="server" ID="lblNTP_ApprovedBy" Text="Mr. GSO Head"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Left">
                                                    <asp:Label runat="server" ID="lblNTP_ApprovedByPosition" Text="GSO Department Head"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 25px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Left">
                                                    <asp:Label runat="server" ID="Label2" Text="I acknowledge receipt of this Notice on"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Left">
                                                    <asp:Label runat="server" ID="Label3" Text="Name of the Representative of the bidder"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Left">
                                                    <asp:Label runat="server" ID="Label4" Text="Authorized Signature:"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 40px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:Button runat="server" ID="btnNTP_Preview" Text="Save / Preview" Width="18%" CssClass="CSButton" OnClientClick="StartProgressBar();" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 20px"></td>
                                            </tr>
                                        </table>
                                    </asp:View>




                                    <asp:View runat="server" ID="vwAccntng">
                                        <table width="90%">
                                            <tr>
                                                <td style="width: 100%; height: 30px" align="center"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Right">
                                                    <asp:Label runat="server" ID="lblAccntng_Date" Text="January 01, 2000"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 15px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_LeftBold">
                                                    <asp:Label runat="server" ID="lblAccntng_CAO" Text="Mr. John Doe"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_LeftBold">
                                                    <asp:Label runat="server" ID="lblAccntng_COA_Pos" Text="City Accountant"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Left">
                                                    <asp:Label runat="server" ID="lblAccntng_City" Text="This City"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 20px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Left">
                                                    <span class="column_Left">Dear </span>
                                                    &nbsp;<asp:Label runat="server" ID="lblAccntng_CAO2" Text="Mr. John Doe"></asp:Label>
                                                    <span class="column_LeftBold">;</span>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 10px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_LeftBold">
                                                    <asp:TextBox runat="server" ID="txtAccntng_Content" CssClass="txtbox_ReportEncoding" Width="98%" Height="350px" Text="" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 50px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Left">
                                                    <asp:Label runat="server" ID="Label11" Text="Very truly yours,"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 30px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_LeftBold">
                                                    <asp:Label runat="server" ID="lblAccntng_GSO" Text="Mr. GSO Head"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Left">
                                                    <asp:Label runat="server" ID="lblAccntng_GSO_Pos" Text="GSO Department Head"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 25px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Left">
                                                    <asp:Label runat="server" ID="lblAccntng_ISSPNo" Text="ISSP No. "></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 40px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:Button runat="server" ID="btnAccntng_Save" Text="Save / Preview" Width="18%" CssClass="CSButton" OnClientClick="StartProgressBar();" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 20px"></td>
                                            </tr>
                                        </table>
                                    </asp:View>


                                    <asp:View runat="server" ID="vwNoticeCOA">

                                        <table width="90%">
                                            <tr>
                                                <td style="width: 100%; height: 30px" align="center"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_CenterBold">Republika ng Pilipinas
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_CenterBold">Provincial Government of Cagayan
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="column_Center">Tanggapan ng Taga-Pangasiwa
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 30px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="left">
                                                    <asp:TextBox runat="server" ID="txtCOA_Date" CssClass="txtbox_Date" Width="20%" Text="" MaxLength="10"></asp:TextBox>
                                                    <cc1:CalendarExtender runat="server" ID="CalendarExtender_COADate" TargetControlID="txtCOA_Date" PopupButtonID="txtCOA_Date" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                    <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender_COA" TargetControlID="txtCOA_Date" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 30px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:TextBox runat="server" ID="txtCOA_Content" CssClass="txtbox_ReportEncoding" TextMode="MultiLine" Width="98%" Height="500px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 30px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:Button runat="server" ID="btnSave_NoticeCOA" CssClass="CSButton" Text="Save and Preview" Width="20%" OnClientClick="StartProgressBar();" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center"></td>
                                            </tr>
                                        </table>

                                    </asp:View>


                                </asp:MultiView>
                            </div>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
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


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
