<%@ Page 
    Title="ITB - Pre Procurement" 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false"
    CodeFile="Pre_Procurement.aspx.vb" 
    Inherits="bidding_Pre_Procurement" 
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

    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">
                            <asp:Label runat="server" ID="lblPageTitle" Text="INVITATION TO BID"></asp:Label>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">

                            <table cellpadding="0px" cellspacing="0px" width="100%">
                                <tr>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab1" Width="100%" Text="INVITATION TO BID" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab2" Width="100%" Text="PRE BID OPENING" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 60%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="3" class="PanelTabs">
                                        <asp:MultiView runat="server" ID="mvTabs">
                                            <asp:View runat="server" ID="vwITB">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:GridView runat="server" ID="grdITB" SkinID="GridViewAA" Width="100%" EmptyDataText="No Data Found."
                                                                            DataKeyNames="obr_evaluation_hdr_id,prhdr_id,remarks,OBR_No,ABC">
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox runat="server" ID="cb1" Visible='<%# Bind("isVisible") %>' AutoPostBack="true" OnCheckedChanged="CheckITB" />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Width="3%" />
                                                                                </asp:TemplateField>

                                                                                <asp:BoundField ItemStyle-Width="8%" DataField="EvalDate" DataFormatString="{0:d}" HeaderText="Date Evaluated" ItemStyle-HorizontalAlign="Center" />
                                                                                <asp:BoundField ItemStyle-Width="10%" DataField="pr_no" HeaderText="PR Number" ItemStyle-HorizontalAlign="Center" />
                                                                                <asp:BoundField ItemStyle-Width="10%" DataField="OBR_No" HeaderText="CAA Number" ItemStyle-HorizontalAlign="Center" />
                                                                                <asp:BoundField ItemStyle-Width="16%" DataField="RC_Name" HeaderText="Department" ItemStyle-HorizontalAlign="Center" />
                                                                                <asp:BoundField ItemStyle-Width="8%" DataField="GA_Code" HeaderText="Account Code" ItemStyle-HorizontalAlign="Center" />
                                                                                <asp:BoundField ItemStyle-Width="10%" DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC" ItemStyle-HorizontalAlign="Right" />
                                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Purpose">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox runat="server" ID="txtProjectName" Text='<%# Bind("remarks") %>' Visible='<%# Bind("isVisible") %>' Width="98%" CssClass="txtbox_Var"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Width="30%" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Action">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton runat="server" ID="btnReturn" Text="Return" CssClass="LinkBtnCancel" CommandName="Select" Font-Underline="false" OnClientClick="StartProgressBar();" Visible='<%# Bind("isVisible") %>' />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Width="5%" />
                                                                                </asp:TemplateField>

                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%; height: 5px" align="center"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%" class="DivTitle">Details
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <table width="90%">
                                                                            <tr>
                                                                                <td style="width: 30%" class="column_RightBold">ITB Date :</td>
                                                                                <td style="width: 70%" class="column_Left">
                                                                                    <asp:TextBox runat="server" ID="txtITB_Date" Width="20%" CssClass="txtbox_Date" Text="" AutoPostBack="true"></asp:TextBox>
                                                                                    &nbsp;<asp:ImageButton runat="server" ID="imgCalendar" ImageUrl="~/images/calendar1.jpg" />
                                                                                    &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                                    <cc1:FilteredTextBoxExtender runat="server" ID="filter1" ValidChars="01234567890/" TargetControlID="txtITB_Date"></cc1:FilteredTextBoxExtender>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 30%" class="column_RightBold">Ref. Number (ITB No.) :</td>
                                                                                <td style="width: 70%" class="column_Left">
                                                                                    <asp:TextBox runat="server" ID="txtITB_No" Width="40%" CssClass="txtbox_Var" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 30%" class="column_RightBold">Project Name :</td>
                                                                                <td style="width: 70%" class="column_Left"><asp:TextBox ID="txtProjectName_new" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox></td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td style="width: 30%" class="column_RightBold">PhilGeps Posting Date :</td>
                                                                                <td style="width: 70%" class="column_Left">
                                                                                    <asp:TextBox runat="server" ID="txtPhilGeps_DateFrom" Width="20%" CssClass="txtbox_Date" Text=""></asp:TextBox>
                                                                                    &nbsp;<asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="~/images/calendar1.jpg" />
                                                                                    &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                                    &nbsp;<span class="column_CenterBold"> - </span>
                                                                                    &nbsp;<asp:TextBox runat="server" ID="txtPhilGeps_DateTo" Width="20%" CssClass="txtbox_Date" Text=""></asp:TextBox>
                                                                                    &nbsp;<asp:ImageButton runat="server" ID="ImageButton2" ImageUrl="~/images/calendar1.jpg" />
                                                                                    &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 30%" class="column_RightBold">Date of Availability of Bid Form :</td>
                                                                                <td style="width: 70%" class="column_Left">
                                                                                    <asp:TextBox runat="server" ID="txtBidForm_AvailDate" Width="20%" CssClass="txtbox_Date" Text=""></asp:TextBox>
                                                                                    &nbsp;<asp:ImageButton runat="server" ID="ImageButton3" ImageUrl="~/images/calendar1.jpg" />
                                                                                    &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                                </td>
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
                                                                                    <asp:TextBox runat="server" ID="txtPreBid_ConferenceDate" Width="20%" CssClass="txtbox_Date" Text="" Enabled="true"></asp:TextBox>
                                                                                    &nbsp;<asp:ImageButton runat="server" ID="ImageButton4" ImageUrl="~/images/calendar1.jpg" />
                                                                                    &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                                    &nbsp;&nbsp;&nbsp;<span class="column_RightBold">Time of Pre-Bid Conference :</span>
                                                                                    &nbsp;<asp:TextBox runat="server" ID="txtPreBid_ConferenceTime" Width="10%" CssClass="txtbox_Date" Text="2:00" Enabled="true"></asp:TextBox>
                                                                                    <%--&nbsp;<asp:DropDownList runat="server" ID="drpPreBid_ConferenceTime" CssClass="drpdownCSS" Width="7%" Enabled="true">
                                                                                        <asp:ListItem Value="1" Text="PM" Selected="True"></asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="AM"></asp:ListItem>
                                                                                    </asp:DropDownList>--%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 30%" class="column_RightBold">Place of Pre-Bid Conference :</td>
                                                                                <td style="width: 70%" class="column_Left">
                                                                                    <asp:TextBox runat="server" ID="txtPreBid_ConferencePlace" Width="90%" CssClass="txtbox_Var" Text="" Enabled="true"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 30%" class="column_RightBold">Date of Bid Opening :</td>
                                                                                <td style="width: 70%" class="column_Left">
                                                                                    <asp:TextBox runat="server" ID="txtBidOpening_Date" Width="20%" CssClass="txtbox_Date" Text=""></asp:TextBox>
                                                                                    &nbsp;<asp:ImageButton runat="server" ID="ImageButton6" ImageUrl="~/images/calendar1.jpg" />
                                                                                    &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                                    &nbsp;&nbsp;&nbsp;<span class="column_RightBold">Time of Bid Opening :</span>
                                                                                    &nbsp;<asp:TextBox runat="server" ID="txtBidOpening_Time" Width="10%" CssClass="txtbox_Date" Text="2:00"></asp:TextBox>
                                                                                    <%--&nbsp;<asp:DropDownList runat="server" ID="drpBidOpening_Time" CssClass="drpdownCSS" Width="7%">
                                                                                        <asp:ListItem Value="1" Text="PM" Selected="True"></asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="AM"></asp:ListItem>
                                                                                    </asp:DropDownList>--%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 30%" class="column_RightBold">Place of Bid Opening :</td>
                                                                                <td style="width: 70%" class="column_Left">
                                                                                    <asp:TextBox runat="server" ID="txtBidOpening_Place" Width="90%" CssClass="txtbox_Var" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 30%" class="column_RightBold"></td>
                                                                                <td style="width: 70%" class="column_Left"></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%; height: 10px" align="center"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:Button runat="server" ID="btnSaveITB" CssClass="CSButton" Width="12%" Text="Save" OnClientClick="StartProgressBar();" />
                                                                        &nbsp;<asp:Button runat="server" ID="btnPreviewITB" CssClass="CSButton" Width="12%" Text="Preview ITB" Enabled="false" OnClientClick="StartProgressBar();" />
                                                                        &nbsp;<asp:Button runat="server" ID="btnPreview_FA" CssClass="CSButton" Width="12%" Text="Preview FA" Enabled="false" OnClientClick="StartProgressBar();" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%; height: 10px" align="center">
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtITB_Date" PopupButtonID="txtITB_Date" PopupPosition="BottomRight"></cc1:CalendarExtender>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtPhilGeps_DateFrom" PopupButtonID="txtPhilGeps_DateFrom" PopupPosition="BottomRight"></cc1:CalendarExtender>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender3" TargetControlID="txtPhilGeps_DateTo" PopupButtonID="txtPhilGeps_DateTo" PopupPosition="BottomRight"></cc1:CalendarExtender>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender4" TargetControlID="txtBidForm_AvailDate" PopupButtonID="txtBidForm_AvailDate" PopupPosition="BottomRight"></cc1:CalendarExtender>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender5" TargetControlID="txtPreBid_ConferenceDate" PopupButtonID="txtPreBid_ConferenceDate" PopupPosition="BottomRight"></cc1:CalendarExtender>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender6" TargetControlID="txtBidOpening_Date" PopupButtonID="txtBidOpening_Date" PopupPosition="BottomRight"></cc1:CalendarExtender>

                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>


                                            <asp:View runat="server" ID="vwPRE">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdPreProcurement" SkinID="GridViewAA" Width="90%" EmptyDataText="No Data Found."
                                                                DataKeyNames="obr_evaluation_hdr_id,obr_evaluation_dtl_id,ProjectName,ABC,ITB_No,BidOpening_Date,BidOpening_Time,BidOpening_Place,Transaction_type,Project_name,ITB_Hdr_ID">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkSelect" CssClass="LinkBtnSelect" Font-Underline="false" Visible='<%# Bind("isVisible") %>' Text="Select" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="7%" />
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-Width="13%" DataField="ITB_No" HeaderText="ITB Number" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField ItemStyle-Width="65%" DataField="Project_name" HeaderText="Contract / Project Name" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField ItemStyle-Width="15%" DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC" ItemStyle-HorizontalAlign="Right" />

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
                                                                       <%-- <asp:DropDownList runat="server" ID="drpBidDoc" CssClass="drpdownCSS" Width="8%" Enabled="true" AutoPostBack="true">
                                                                            <asp:ListItem Value="0.01" Text="1%" Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Value="0.02" Text="2%"></asp:ListItem>
                                                                            <asp:ListItem Value="0.03" Text="3%"></asp:ListItem>
                                                                            <asp:ListItem Value="0.04" Text="4%"></asp:ListItem>
                                                                            <asp:ListItem Value="0.05" Text="5%"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        &nbsp;<span class="column_RisghtBold">of Total ABC :</span>--%>
                                                                        <asp:TextBox runat="server" ID="txtBidDoc_Amt" Width="15%" CssClass="txtbox_Amt" Text="0.00" ></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Project Location :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtProjectLocation" Width="80%" CssClass="txtbox_Var" Text=""></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Bidding Category :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:RadioButtonList runat="server" ID="rbBidCategory" CssClass="rbCS_Horizontal" Width="70%" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Value="1" Text="Goods/Services" Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="Civil Works"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="Consultancy" Enabled="false"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold"></td>
                                                                    <td style="width: 70%" class="column_Left"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <%-- ADD THIS CODE ITBUpdate --%>
 
                                                    <%-- END HERE --%>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnSavePreProc" Text="Save" CssClass="CSButton" Width="150px" OnClientClick="StartProgressBar();" />
                                                            &nbsp;<asp:Button runat="server" ID="btnPreviewOP" Text="Preview" CssClass="CSButton" Enabled="false"  Visible ="false"  Width="150px" OnClientClick="StartProgressBar();" />
                                                            &nbsp;<asp:Button runat="server" ID="btnPreviewBidForm" Text="Preview" CssClass="CSButton" Enabled="false" Width="150px" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <%-- ADD THIS CODE ITBUpdate --%>
                                                    <%-- END HERE --%>
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



            <div>
                <asp:Panel runat="server" ID="pnlUpdateProjName" Width="300px" CssClass="Panel_Popup">
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" class="DivTitle">Project Name
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 15px"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%" align="center">
                                <asp:TextBox runat="server" ID="txtProjectName" Width="90%" Height="100px" CssClass="txtbox_Remarks" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 25px"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%" align="center">
                                <asp:Button runat="server" ID="btnOk_ProjectName" Width="120px" CssClass="CSButton" Text="OK" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 10px">
                                <asp:Label runat="server" ID="lblUpdateProjName"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="ModalPopupExtender_UpdateProjName" runat="server" PopupControlID="pnlUpdateProjName" BackgroundCssClass="modalBackground" TargetControlID="lblUpdateProjName"></cc1:ModalPopupExtender>
            </div>



            <%-- POPUP PANEL FOR MESSAGE --%>
            <div>
                <asp:Panel runat="server" ID="pnlMessage" CssClass="PanelMessage" DefaultButton="btnMsgOK">
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" class="DivTitle">Alert!
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 15px"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%" align="center">
                                <asp:Label runat="server" ID="lblMessagePopup" Text="" CssClass="AlertMsg"></asp:Label>
                                <asp:TextBox runat="server" ID="txtHide" Width="0%" Height="0%" BorderStyle="None" BorderColor="Transparent" BackColor="Transparent"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 25px"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%" align="center">
                                <asp:Button runat="server" ID="btnMsgOK" Width="100px" CssClass="CSButton" Text="OK" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 10px">
                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="ModalPopupExtender_PnlMessage" runat="server" PopupControlID="pnlMessage" BackgroundCssClass="modalBackground" TargetControlID="lblMessage"></cc1:ModalPopupExtender>
            </div>







            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        


        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

