<%@ Page Title="Infra - Bid Preparation" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Infra_PreProcurement.aspx.vb" Inherits="bidding_Bidding_Infra_Infra_PreProcurement"
    StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">INFRA - BID PREPARATION
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
                        <td style="width: 98%" align="center">

                            <table cellpadding="0px" cellspacing="0px" width="100%">
                                <tr>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab1_PreProcurement" Width="100%" Text="Pre Procurement" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab2_ITB" Width="100%" Text="Invitation To Bid" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab3_PBD" Width="100%" Text="Pre Bid Opening" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab4_Opening" Width="100%" Text="Interested Bidders" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="5" class="PanelTabs">
                                        <asp:MultiView runat="server" ID="mvTabs">

                                            <asp:View runat="server" ID="vwTab1_PreProc">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search by :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpSearch_PreProc" CssClass="drpdownCSS" Width="12%">
                                                                <asp:ListItem Value="1" Text="OBR Number" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Project Name"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtSearch_PreProc" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnSearch_PreProc" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdPreProc" SkinID="GridViewAA" Width="98%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="OBR_Hdr_ID,Program_ID,Project_ID,Amount,PPA,RC_ID,Function_ID">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkSelect" Text="Select" CssClass="LinkBtnSelect" Visible='<%#Bind("isVisible") %>' CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%" DataField="OBR_Date" HeaderText="OBR Date" DataFormatString="{0:d}" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" DataField="OBR_No" HeaderText="OBR Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="63%" DataField="PPA" HeaderText="Project Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="12%" DataField="Amount" HeaderText="Amount" DataFormatString="{0:N}" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="90%">
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Date :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtDate_PreProc" CssClass="txtbox_Date" Width="30%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDate_PreProc" PopupButtonID="txtDate_PreProc" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtDate_PreProc" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>

                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Mode of Procurement :
                                                                    </td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList ID="drpMOP" runat="server" Width="60%" CssClass="drpdownCSS" Enabled="False"></asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Remarks :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtRemarks_PreProc" CssClass="txtbox_Var" Width="95%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%; height: 10px" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">BAC Member : </td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList ID="drpBAC1" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">BAC Vice Chairman : </td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList ID="drpBACVC" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">BAC Member : </td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList ID="drpBAC2" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">BAC Chairman : </td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList ID="drpBACC" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">BAC Member : </td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList ID="drpBAC3" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Approved By : </td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList ID="drpApprovedBy" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList>
                                                                    </td>
                                                                </tr>

                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnSave_PreProc" CssClass="CSButton" Width="15%" Text="Save" Enabled="false" OnClientClick="StartProgressBar();" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>



                                            <asp:View runat="server" ID="vwTab2_ITB">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search by :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpSearch_ITB" CssClass="drpdownCSS" Width="12%">
                                                                <asp:ListItem Value="1" Text="OBR Number" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Project Name"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtSearch_ITB" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnSearch_ITB" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdITB" SkinID="GridViewAA" Width="98%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="Bid_ID,OBR_No,PPA,Amount">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkSelect" Text="Select" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%" DataField="OBR_Date" HeaderText="OBR Date" DataFormatString="{0:d}" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" DataField="OBR_No" HeaderText="OBR Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="63%" DataField="PPA" HeaderText="Project Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="12%" DataField="Amount" HeaderText="Amount" DataFormatString="{0:N}" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="left">
                                                            <table width="90%">
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">ITB Date :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtITB_Date" Width="20%" CssClass="txtbox_Date" Text="" AutoPostBack="true"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="filter1" ValidChars="01234567890/" TargetControlID="txtITB_Date"></cc1:FilteredTextBoxExtender>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtenderitb" TargetControlID="txtITB_Date" PopupButtonID="txtITB_Date" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Ref. Number (ITB No.) :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtITB_No" Width="20%" CssClass="txtbox_Var" Text="" ReadOnly="true"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">PhilGeps Posting Date :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtPhilGeps_DateFrom" Width="20%" CssClass="txtbox_Date" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        &nbsp;<span class="column_CenterBold"> - </span>
                                                                        &nbsp;<asp:TextBox runat="server" ID="txtPhilGeps_DateTo" Width="20%" CssClass="txtbox_Date" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>

                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender2" ValidChars="01234567890/" TargetControlID="txtPhilGeps_DateFrom"></cc1:FilteredTextBoxExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender3" ValidChars="01234567890/" TargetControlID="txtPhilGeps_DateTo"></cc1:FilteredTextBoxExtender>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtPhilGeps_DateFrom" PopupButtonID="txtPhilGeps_DateFrom" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender3" TargetControlID="txtPhilGeps_DateTo" PopupButtonID="txtPhilGeps_DateTo" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Date of Availability of Bid Form :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtBidForm_AvailDate" Width="20%" CssClass="txtbox_Date" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>

                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender4" ValidChars="01234567890/" TargetControlID="txtBidForm_AvailDate"></cc1:FilteredTextBoxExtender>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender4" TargetControlID="txtBidForm_AvailDate" PopupButtonID="txtBidForm_AvailDate" PopupPosition="TopLeft"></cc1:CalendarExtender>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%; height: 10px" class="column_RightBold"></td>
                                                                    <td style="width: 70%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold"></td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:CheckBox runat="server" ID="cbPreBidConference" Text="Without Pre-Bid Conference" CssClass="rbCS_Horizontal" AutoPostBack="true" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Date of Pre-Bid Conference :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtPreBid_ConferenceDate" Width="20%" CssClass="txtbox_Date" Text="" Enabled="true" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        &nbsp;&nbsp;&nbsp;<span class="column_RightBold">Time of Pre-Bid Conference :</span>
                                                                        &nbsp;<asp:TextBox runat="server" ID="txtPreBid_ConferenceTime" Width="10%" CssClass="txtbox_Date" Text="" Enabled="true"></asp:TextBox>
                                                                        &nbsp;<asp:DropDownList runat="server" ID="drpPreBid_ConferenceTime" CssClass="drpdownCSS" Width="7%" Enabled="true">
                                                                            <asp:ListItem Value="1" Text="PM" Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="AM"></asp:ListItem>
                                                                        </asp:DropDownList>

                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender5" ValidChars="01234567890/" TargetControlID="txtPreBid_ConferenceDate"></cc1:FilteredTextBoxExtender>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender5" TargetControlID="txtPreBid_ConferenceDate" PopupButtonID="txtPreBid_ConferenceDate" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Place of Pre-Bid Conference :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtPreBid_ConferencePlace" Width="90%" CssClass="txtbox_Var" Text="" Enabled="true"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%; height: 10px" class="column_RightBold"></td>
                                                                    <td style="width: 70%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Date of Bid Opening :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtBidOpening_Date" Width="20%" CssClass="txtbox_Date" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        &nbsp;&nbsp;&nbsp;<span class="column_RightBold">Time of Bid Opening :</span>
                                                                        &nbsp;<asp:TextBox runat="server" ID="txtBidOpening_Time" Width="10%" CssClass="txtbox_Date" Text=""></asp:TextBox>
                                                                        &nbsp;<asp:DropDownList runat="server" ID="drpBidOpening_Time" CssClass="drpdownCSS" Width="7%">
                                                                            <asp:ListItem Value="1" Text="PM" Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="AM"></asp:ListItem>
                                                                        </asp:DropDownList>

                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender6" ValidChars="01234567890/" TargetControlID="txtBidOpening_Date"></cc1:FilteredTextBoxExtender>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender6" TargetControlID="txtBidOpening_Date" PopupButtonID="txtBidOpening_Date" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Place of Bid Opening :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtBidOpening_Place" Width="90%" CssClass="txtbox_Var" Text=""></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnSave_ITB" CssClass="CSButton" Width="12%" Text="Save" Enabled="false" OnClientClick="StartProgressBar();" />
                                                            &nbsp;<asp:Button runat="server" ID="btnPreview_ITB" CssClass="CSButton" Width="12%" Text="Preview ITB" Enabled="false" OnClientClick="StartProgressBar();" />
                                                            &nbsp;<asp:Button runat="server" ID="btnPreview_Cert" CssClass="CSButton" Width="15%" Text="BAC Certification" Enabled="false" OnClientClick="StartProgressBar();" />
                                                            <%--&nbsp;<asp:Button runat="server" ID="btnPreview_FA" CssClass="CSButton" Width="12%" Text="Preview FA" Enabled="false" OnClientClick="StartProgressBar();" />--%>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>



                                            <asp:View runat="server" ID="vwTab3_PBD">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search by :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpSearch_PBD" CssClass="drpdownCSS" Width="12%">
                                                                <asp:ListItem Value="1" Text="ITB Number" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Project Name"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="OBR Number"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtSearch_PBD" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnSearch_PBD" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdPBD" SkinID="GridViewAA" Width="98%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="Bid_ID,PPA">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkSelect" Text="Select" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" DataField="ITB_No" HeaderText="ITB Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" DataField="OBR_No" HeaderText="OBR Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="59%" DataField="PPA" HeaderText="Project Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="12%" DataField="Amount" HeaderText="Amount" DataFormatString="{0:N}" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="90%">
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Bid Document :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtBidDoc_Amt" Width="15%" CssClass="txtbox_Amt" Text="0.00" onblur="toPeso(this)"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Project Location :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtProjectLocation" Width="70%" CssClass="txtbox_Var" Text=""></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold"></td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:CheckBox runat="server" ID="cbwithAddendum" Text="with Addendum" Visible="false" CssClass="rbCS_Horizontal" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnSave_PBD" Text="Save" CssClass="CSButton" Width="12%" Enabled="false" OnClientClick="StartProgressBar();" />
                                                            &nbsp;<asp:Button runat="server" ID="btnPreview_OP" Text="Order of Payment" CssClass="CSButton" Enabled="false" Width="15%" OnClientClick="StartProgressBar();" />
                                                            &nbsp;<asp:Button runat="server" ID="btnPreview_BidForm" Text="Bid Form" CssClass="CSButton" Enabled="false" Width="12%" OnClientClick="StartProgressBar();" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>



                                            <asp:View runat="server" ID="vwTab4_Opening">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search by :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpSearch_Opening" CssClass="drpdownCSS" Width="12%">
                                                                <asp:ListItem Value="1" Text="ITB Number" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Project Name"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="OBR Number"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtSearch_Opening" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnSearch_Opening" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdOpening" SkinID="GridViewAA" Width="98%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="Bid_ID,PPA">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkSelect" Text="Select" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" DataField="ITB_No" HeaderText="ITB Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" DataField="OBR_No" HeaderText="OBR Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="59%" DataField="PPA" HeaderText="Project Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="12%" DataField="Amount" HeaderText="Amount" DataFormatString="{0:N}" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">Add Bidders
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Select Bidder :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpAddBidder" CssClass="drpdownCSS" Width="35%"></asp:DropDownList>
                                                            &nbsp;<asp:Button runat="server" ID="btnAddBidder" CssClass="CSButton" Width="12%" Enabled="false" Text="Add Bidder" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdBidders" SkinID="GridViewAA" Width="70%" AllowPaging="false" EmptyDataText="No Data Found."
                                                                DataKeyNames="Infra_Bidders_ID,Supplier_Id,SuppName">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkSelect_Bidder" Text="Order of Payment" CssClass="LinkBtnSelect" OnClick="lnkSelect_Bidder_Click" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70%" DataField="SuppName" HeaderText="Bidder's Name" />

                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkRemove_Bidder" Text="Remove" CssClass="LinkBtnCancel" OnClick="lnkRemove_Bidder_Click" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                   <%-- <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">Eligibility Documents
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdEqligibility" SkinID="GridViewAA" Width="98%" EmptyDataText="No Data Found." AllowPaging="false"
                                                                DataKeyNames="Supplier_ID">
                                                                <Columns>
                                                                    <asp:BoundField DataField="SuppName" HeaderText="Bidders">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:TemplateField HeaderText="PHILGEPS Certificate - Plantinum Membership">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbPhilgeps" Checked='<%#Bind("Philgeps")%>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Statement of all Ongoing Government and Private Contracts">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbOngoing" Checked='<%#Bind("isOngoing")%>' />
                                                                            <br />
                                                                            <asp:TextBox runat="server" ID="txtOngoing" CssClass="txtbox_Var" Width="95%" Text='<%#Bind("OngoingContracts")%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Statement of Single Largest Completed Contract (SLCC)">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbSLCC" Checked='<%#Bind("isSLCC")%>' />
                                                                            <br />
                                                                            <asp:TextBox runat="server" ID="txtSLCC" CssClass="txtbox_Var" Width="95%" Text='<%#Bind("SLCC")%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="NFCC Computation or Committed Line of Credit">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbNFCC" Checked='<%#Bind("isNFCC")%>' />
                                                                            <br />
                                                                            <asp:TextBox runat="server" ID="txtNFCC" CssClass="txtbox_Var" Width="95%" Text='<%#Bind("NFCC")%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Joint Venture Agreement (JVA)">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbJVA" Checked='<%#Bind("isJVA")%>' />
                                                                            <br />
                                                                            <asp:TextBox runat="server" ID="txtJVA" CssClass="txtbox_Var" Width="95%" Text='<%#Bind("JVA")%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Supplier_ID" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="lblSupplier_ID" Text='<%#Bind("Supplier_ID")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">Project Requirement
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdProjectRequirements" SkinID="GridViewAA" Width="98%" EmptyDataText="No Data Found." AllowPaging="false"
                                                                DataKeyNames="reqID" AutoGenerateColumns="false">
                                                                <Columns>

                                                                    <asp:TemplateField HeaderText="Criteria">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox runat="server" ID="txtCriteria" CssClass="txtbox_Var" Width="95%" Text='<%#Bind("Criteria") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="40%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="BidderA" Text="BidderA"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbA" Checked='<%#Bind("Supp1_isPass") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="BidderB" Text="BidderB"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbB" Checked='<%#Bind("Supp2_isPass") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="BidderC" Text="BidderC"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbC" Checked='<%#Bind("Supp3_isPass") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="BidderD" Text="BidderD"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbD" Checked='<%#Bind("Supp4_isPass") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="BidderE" Text="BidderE"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbE" Checked='<%#Bind("Supp5_isPass") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">Other Criteria
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdOtherCriteria" SkinID="GridViewAA" Width="98%" EmptyDataText="No Data Found." AllowPaging="false"
                                                                DataKeyNames="" AutoGenerateColumns="false">
                                                                <Columns>
                                                                    <asp:BoundField DataField="SuppName" ItemStyle-Width="60%" ItemStyle-HorizontalAlign="Left" HeaderText="Bidder's Name" />

                                                                    <asp:TemplateField HeaderText="Omnibus Sworn Statement">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbOmnibus" Checked='<%#Bind("omnibus") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="The Signatory is the duly authorized representative of the prospective bidder">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="cbauthorized" Checked='<%#Bind("authorized_rep") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnSave_Opening" Text="Save and Proceed" CssClass="CSButton" Width="15%" Enabled="false" OnClientClick="StartProgressBar();" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                        </asp:MultiView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 30px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>


            <asp:Panel runat="server" ID="pnlITB_No" CssClass="Panel_Popup" Width="200px">
                <div>
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">ITB Number
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <asp:TextBox runat="server" ID="txtDisplay_ITBNo" CssClass="txtbox_CenterBold" Width="80%"></asp:TextBox>
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
                            <td style="width: 98%" align="center">
                                <asp:Button runat="server" ID="btnOK" CssClass="CSButton" Text="OK" Width="25%" />
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px">
                                <asp:Label runat="server" ID="lblITB"></asp:Label>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <cc1:ModalPopupExtender runat="server" ID="ModalPopupExtender1" TargetControlID="lblITB" PopupControlID="pnlITB_No" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>



            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

