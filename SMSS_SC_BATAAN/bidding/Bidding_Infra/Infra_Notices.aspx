<%@ Page 
    Title="Infra Notices" 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="Infra_Notices.aspx.vb" 
    Inherits="bidding_Bidding_Infra_Infra_Notices" 
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
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">INFRA NOTICES</td>
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
                                    <td style="width: 16%" align="left">
                                        <asp:Button runat="server" ID="btnTab_Declaration" Width="100%" Text="Declaration" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 16%" align="left">
                                        <asp:Button runat="server" ID="btnTab_PostQua" Width="100%" Text="Post Qualification" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 16%" align="left">
                                        <asp:Button runat="server" ID="btnTab1_Resolution" Width="100%" Text="BAC Resolution" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 16%" align="left">
                                        <asp:Button runat="server" ID="btnTab2_NOA" Width="100%" Text="Notice of Award" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 16%" align="left">
                                        <asp:Button runat="server" ID="btnTab3_Contract" Width="100%" Text="Contract" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 16%" align="left">
                                        <asp:Button runat="server" ID="btnTab4_NTP" Width="100%" Text="Notice to Proceed" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 4%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="7" class="PanelTabs">
                                        <asp:MultiView runat="server" ID="mvTabs">


                                            <asp:View runat="server" ID="vwTab_Declaration">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search by :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpDeclaration_Search" CssClass="drpdownCSS" Width="12%">
                                                                <asp:ListItem Value="1" Text="ITB Number" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Project Name"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtDeclaration_Search" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnDeclaration_Search" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdDeclaration" SkinID="GridViewAA" Width="90%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="Infra_BidPrep_ID,RC_ID,Function_ID">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkDeclaration_Select" Text="Select" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="ITB_No" HeaderText="ITB Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50%" DataField="PPA" HeaderText="Project Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="13%" DataField="Amount" HeaderText="ABC" DataFormatString="{0:N}" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="15%" DataField="FundDesc" HeaderText="Fund" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">List of Bidders
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdDeclaration_Bidders" SkinID="GridViewAA" Width="95%" AllowPaging="false" EmptyDataText="No Data Found."
                                                                DataKeyNames="Infra_Bidders_ID,Supplier_ID">
                                                                <Columns>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50%" DataField="SuppName" HeaderText="Bidder's Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="12%" DataField="BidAmount" HeaderText="Total Bid Amount" DataFormatString="{0:N}" />

                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="9%" HeaderText="Rate">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList runat="server" ID="drpDeclaration_Passed" CssClass="drpdownCSS" Width="95%" OnSelectedIndexChanged="drpDeclaration_Passed_Changed" Visible='<%#Bind("isVisible") %>' AutoPostBack="true">
                                                                                <asp:ListItem Value="1" Text="Passed" Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Value="2" Text="Failed"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" HeaderText="Remarks">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox runat="server" ID="txtDeclaration_Remarks" CssClass="txtbox_Var" Width="95%" Text=""></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>


                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="9%" HeaderText="Declare Winner">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList runat="server" ID="drpDeclaration_Winner" CssClass="drpdownCSS" Width="95%" OnSelectedIndexChanged="drpDeclaration_Winner_Changed" Visible='<%#Bind("isVisible") %>' AutoPostBack="true">
                                                                                <asp:ListItem Value="1" Text=" - " Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Value="2" Text="Winner"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">

                                                            <table width="60%">
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Date :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtDate_Declaration" CssClass="txtbox_Date" Width="20%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDate_Declaration" PopupButtonID="txtDate_Declaration" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtDate_Declaration" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Responsive Bid :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpDeclaration_ResponsiveBid" CssClass="drpdownCSS" Width="65%">
                                                                            <asp:ListItem Value="1" Text="Single Calculated and Responsive Bid" Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="Lowest Calculated and Responsive Bid"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>

                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="width: 100%; height: 20px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnDeclaration_Save" CssClass="CSButton" Width="12%" Text="Save" Enabled="false" OnClientClick="StartProgressBar();" />
                                                       
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>




                                            <asp:View runat="server" ID="vwTab_PostQua">
                                                <table width="98%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search by :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpPostQua_Search" CssClass="drpdownCSS" Width="12%">
                                                                <asp:ListItem Value="1" Text="ITB Number" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Project Name"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtPostQua_Search" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnPostQua_Search" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdPostQua" SkinID="GridViewAA" Width="95%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="Infra_BidPrep_ID,Infra_Bidders_ID,PPA,ITB_No,SuppName,BidAmount,Supplier_ID">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkPostQua_Select" Text="Select" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="ITB_No" HeaderText="ITB Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="35%" DataField="PPA" HeaderText="Project Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="35%" DataField="SuppName" HeaderText="Bidder's Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%" DataField="BidAmount" HeaderText="Bid Amount" DataFormatString="{0:N}" />


                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">Post Qualification Details
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="80%">
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Date :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtDate_PostQua" CssClass="txtbox_Date" Width="15%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender5" TargetControlID="txtDate_PostQua" PopupButtonID="txtDate_PostQua" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender5" TargetControlID="txtDate_PostQua" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Date Docs. required :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtDate_DocsReq" CssClass="txtbox_Date" Width="15%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender6" TargetControlID="txtDate_DocsReq" PopupButtonID="txtDate_DocsReq" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender6" TargetControlID="txtDate_DocsReq" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Period :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtDate_PeriodFrom" CssClass="txtbox_Date" Width="15%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender7" TargetControlID="txtDate_PeriodFrom" PopupButtonID="txtDate_PeriodFrom" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender7" TargetControlID="txtDate_PeriodFrom" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>

                                                                        &nbsp;<span class="column_CenterBold">To :</span>

                                                                        &nbsp;<asp:TextBox runat="server" ID="txtDate_PeriodTo" CssClass="txtbox_Date" Width="15%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender8" TargetControlID="txtDate_PeriodTo" PopupButtonID="txtDate_PeriodTo" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender8" TargetControlID="txtDate_PeriodTo" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Result :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtDate_Result" CssClass="txtbox_Date" Width="15%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender9" TargetControlID="txtDate_Result" PopupButtonID="txtDate_Result" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender9" TargetControlID="txtDate_Result" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>


                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold"></td>
                                                                    <td style="width: 80%" class="column_Left"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="95%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_CenterBold">REQUIREMENTS</td>
                                                                                <td style="width: 40%" class="column_CenterBold">REMARKS</td>
                                                                                <td style="width: 20%" class="column_CenterBold">FINDINGS</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <table width="98%">
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">I. TECHNICAL DOCUMENTS</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">Class "A" Documents</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">Legal Documents</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">a. Philgeps Certificate - Platinum Membership; OR as per circular 03-2016</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksA" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsA" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">b. Registration cetificate from SEC</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksB" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsB" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">c. Mayor's Permit in the principal place of business - Makati</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksC" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsC" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">d. Tax clearance</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksD" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsD" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 15px" colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">Technical Documents</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">f. Statement of all ongoing government and private contracts, including contracts awarded not yet started, if any</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksF" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsF" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">g. Statement of Single Largest Completed Contract which similar in nature</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksG" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsG" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">h. Bid Securing Declaration</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksH" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsH" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">i. Technical Specifications</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">1. Statement from the prospective bidder duly notarize that they will comply with the specification as provided for the procuring entity.</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksI1" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsI1" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">2. Sworn Statement from prospective bidder that they can deliver within 30 calendar days after the receipt of NTP</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksI2" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsI2" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">3. Sworn Statement from prospective bidder that they are authorized / exclusive dealer / reseller / distributor of branded products being offered.</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksI3" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsI3" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">4. Sworn Statement from prospective bidder that they all products being offer are all original / branded.</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksI4" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsI4" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">5. Manpower requirement or a list of personnel to be assigned for the contract to be bid.</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksI5" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsI5" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">6. Sworn Statement from prospective bidder duly notarized for the warranty and details of after sales service.</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksI6" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsI6" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">j. Omnibus Sworn Statement</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksJ1" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsJ1" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">Duly Authorized Representative / Signatory of the prospective bidder</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksJ2" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsJ2" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 15px" colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">Financial Documents</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">k. Audited Financial Statements stamped received by BIR or its duly accredited and authorized institutions for the preceding calendar year which should not be earlier that 2 years from the date of bid submission.</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksK" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsK" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">l. Net Financial Contracting Capacity</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_RemarksL" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_FindingsL" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 15px" colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">Class "B" Documents</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">Joint Venture Agreement</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <span class="column_Center">Not Applicable</span>
                                                                                </td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 15px" colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">II. FINANCIAL COMPONENTS</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">a. Bid Form</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Remarks2A" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Findings2A" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">b. Proposal Sheet</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Remarks2B" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Findings2B" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">c. Price Schedule</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Remarks2C" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Findings2C" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 15px" colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">III. POST QUALIFICATION DOCUMENTS</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">a. Latest income and business tax returns</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Remarks3A" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Findings3A" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">b. Other licenses and permits required Business Permit (Pasay City)</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Remarks3B" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Findings3B" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left">c. BIR Certificate of Registration</td>
                                                                                <td style="width: 40%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Remarks3C" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox></td>
                                                                                <td style="width: 20%" class="column_Center">
                                                                                    <asp:TextBox runat="server" ID="txt_Findings3C" CssClass="txtbox_Remarks" TextMode="MultiLine" Width="90%" Height="80px" Text=""></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 15px" colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">IV. BID PRICE / AMOUNT EVALUATION</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%" colspan="3" align="center">
                                                                                    <table width="80%" style="border: solid 1px; border-collapse: collapse">
                                                                                        <tr>
                                                                                            <td style="width: 35%; border: solid 1px; border-collapse: collapse" class="column_CenterBold">Amount of Bid as Read</td>
                                                                                            <td style="width: 35%; border: solid 1px; border-collapse: collapse" class="column_CenterBold">Amount of Bid as Calculated</td>
                                                                                            <td style="width: 30%; border: solid 1px; border-collapse: collapse" class="column_CenterBold">Findings</td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 35%; height: 50px; border: solid 1px; border-collapse: collapse" class="column_CenterBold">
                                                                                                <asp:Label runat="server" ID="lblPostQua_Read" Text="0.00"></asp:Label>
                                                                                            </td>
                                                                                            <td style="width: 35%; height: 50px; border: solid 1px; border-collapse: collapse" class="column_CenterBold">
                                                                                                <asp:Label runat="server" ID="lblPostQua_Calculated" Text="0.00"></asp:Label>
                                                                                            </td>
                                                                                            <td style="width: 30%; height: 50px; border: solid 1px; border-collapse: collapse" class="column_CenterBold">
                                                                                                <asp:TextBox runat="server" ID="txtPostQua_IV_Findings" CssClass="txtbox_Remarks" TextMode="MultiLine" Text="" Width="90%" Height="30px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 15px" colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_LeftBold">V. FINDINGS</td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%" colspan="3" align="center">
                                                                                    <table width="80%" style="border: solid 1px; border-collapse: collapse">
                                                                                        <tr>
                                                                                            <td style="width: 35%; border: solid 1px; border-collapse: collapse" class="column_CenterBold">Bidder's Name</td>
                                                                                            <td style="width: 35%; border: solid 1px; border-collapse: collapse" class="column_CenterBold">Findings</td>
                                                                                            <td style="width: 30%; border: solid 1px; border-collapse: collapse" class="column_CenterBold">Grounds</td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 35%; height: 50px; border: solid 1px; border-collapse: collapse" class="column_CenterBold">
                                                                                                <asp:Label runat="server" ID="lblPostQua_V_Bidder" Text="Bidder's Name"></asp:Label>
                                                                                            </td>
                                                                                            <td style="width: 35%; height: 50px; border: solid 1px; border-collapse: collapse" class="column_CenterBold">
                                                                                                <asp:TextBox runat="server" ID="txtPostQua_V_Findings" CssClass="txtbox_Remarks" TextMode="MultiLine" Text="" Width="90%" Height="30px"></asp:TextBox>

                                                                                            </td>
                                                                                            <td style="width: 30%; height: 50px; border: solid 1px; border-collapse: collapse" class="column_CenterBold">
                                                                                                <asp:TextBox runat="server" ID="txtPostQua_V_Grounds" CssClass="txtbox_Remarks" TextMode="MultiLine" Text="" Width="90%" Height="30px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%; height: 10px" colspan="3" align="center"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%" colspan="3" align="center">
                                                                                    <asp:TextBox runat="server" ID="txtPostQua_ThereFore" CssClass="txtbox_Remarks" TextMode="MultiLine" Text="" Width="80%" Height="100px"></asp:TextBox>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 40%" class="column_Left"></td>
                                                                                <td style="width: 20%" class="column_Left"></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 20px" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnSave_PostQua" CssClass="CSButton" Width="15%" Enabled="false" Text="Save" OnClientClick="StartProgressBar();" />
                                                            &nbsp;<asp:Button runat="server" ID="btnPreview_PostQua" CssClass="CSButton" Width="15%" Enabled="false" Text="Preview" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 20px" align="center"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>




                                            <asp:View runat="server" ID="vwTab1_Reso">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search by :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpReso_Search" CssClass="drpdownCSS" Width="12%">
                                                                <asp:ListItem Value="1" Text="ITB Number" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Project Name"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtReso_Search" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnReso_Search" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdResolution" SkinID="GridViewAA" Width="95%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="Infra_BidPrep_ID,ResponsiveBid,BidAmount,Supplier_ID,RC_ID,Function_ID">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkReso_Select" Text="Select" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="ITB_No" HeaderText="ITB Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="40%" DataField="PPA" HeaderText="Project Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30%" DataField="SuppName" HeaderText="Bidder's Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%" DataField="BidAmount" HeaderText="Bid Amount" DataFormatString="{0:N}" />
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
                                                                    <td style="width: 15%" class="column_RightBold">Resolution Date :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtReso_Date" CssClass="txtbox_Date" Width="30%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1a" TargetControlID="txtReso_Date" PopupButtonID="txtReso_Date" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1a" TargetControlID="txtReso_Date" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Resolution No. :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtReso_No" CssClass="txtbox_Var" Width="50%" Text=""></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Responsived Bid :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtReso_ResponsiveBid" CssClass="txtbox_Var" Width="95%" Text="" ReadOnly="true"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%; height: 15px" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 35%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Budget :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpReso_CBO" CssClass="drpdownCSS" Width="95%">
                                                                            <asp:ListItem Value="1" Text="Select" Selected="True"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Chairman :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpReso_BACC" CssClass="drpdownCSS" Width="95%">
                                                                            <asp:ListItem Value="1" Text="Select" Selected="True"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">GSO :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpReso_GSO" CssClass="drpdownCSS" Width="95%">
                                                                            <asp:ListItem Value="1" Text="Select" Selected="True"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Vice Chairman :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpReso_BACVC" CssClass="drpdownCSS" Width="95%">
                                                                            <asp:ListItem Value="1" Text="Select" Selected="True"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">City Engineering :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpReso_CEO" CssClass="drpdownCSS" Width="95%">
                                                                            <asp:ListItem Value="1" Text="Select" Selected="True"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">End User :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpReso_EndUser" CssClass="drpdownCSS" Width="95%">
                                                                            <asp:ListItem Value="1" Text="Select" Selected="True"></asp:ListItem>
                                                                        </asp:DropDownList>
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
                                                            <span class="column_RightBold">Approved by :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpReso_Approvedby" CssClass="drpdownCSS" Width="30%">
                                                                <asp:ListItem Value="1" Text="Select" Selected="True"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnReso_Save" CssClass="CSButton" Width="12%" Text="Save" OnClientClick="StartProgressBar();" />
                                                            &nbsp;<asp:Button runat="server" ID="btnReso_Preview" CssClass="CSButton" Width="12%" Text="Preview" OnClientClick="StartProgressBar();" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                </table>


                                            </asp:View>




                                            <asp:View runat="server" ID="vwTab2_NOA">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search by :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpNOA_Search" CssClass="drpdownCSS" Width="12%">
                                                                <asp:ListItem Value="1" Text="ITB Number" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Project Name"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtNOA_Search" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnNOA_Search" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdNOA" SkinID="GridViewAA" Width="90%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="Infra_BidPrep_ID">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkReso_Select" Text="Select" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="ITB_No" HeaderText="ITB Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50%" DataField="PPA" HeaderText="Project Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="28%" DataField="SuppName" HeaderText="Bidder's Name" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="80%">
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">NOA Date :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtNOA_Date" CssClass="txtbox_Date" Width="15%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtNOA_Date" PopupButtonID="txtNOA_Date" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender2" TargetControlID="txtNOA_Date" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Approved by :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpNOA_Approvedby" CssClass="drpdownCSS" Width="60%">
                                                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                                                        </asp:DropDownList>
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
                                                            <asp:Button runat="server" ID="btnNOA_Save" CssClass="CSButton" Width="12%" Text="Save" Enabled="false" OnClientClick="StartProgressBar();" />
                                                            &nbsp;<asp:Button runat="server" ID="btnNOA_Preview" CssClass="CSButton" Width="12%" Text="Preview" Enabled="false" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>



                                            <asp:View runat="server" ID="vwTab3_Contract">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search by :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpContract_Search" CssClass="drpdownCSS" Width="12%">
                                                                <asp:ListItem Value="1" Text="ITB Number" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Project Name"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtContract_Search" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnContract_Search" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdContract" SkinID="GridViewAA" Width="90%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="Infra_BidPrep_ID,Supplier_ID">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkReso_Select" Text="Select" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="ITB_No" HeaderText="ITB Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50%" DataField="PPA" HeaderText="Project Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="28%" DataField="SuppName" HeaderText="Bidder's Name" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="80%">
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Contract Date :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtContract_Date" CssClass="txtbox_Date" Width="20%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender3" TargetControlID="txtContract_Date" PopupButtonID="txtContract_Date" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender3" TargetControlID="txtContract_Date" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Contract No. :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtContractNo" CssClass="txtbox_Var" Width="20%" Text=""></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Completion Timeline :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtContract_Completion" CssClass="txtbox_Var" Width="60%" Text=""></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Contractor ID No. :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtContractorID_No" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Date of Validity :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtContractorID_Validity" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%; height: 10px" class="column_RightBold"></td>
                                                                    <td style="width: 70%" class="column_Left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Approved by :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpContract_Aprpovedby" CssClass="drpdownCSS" Width="60%">
                                                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                                                        </asp:DropDownList>
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
                                                            <asp:Button runat="server" ID="btnContract_Save" CssClass="CSButton" Width="12%" Text="Save" Enabled="false" OnClientClick="StartProgressBar();" />
                                                            &nbsp;<asp:Button runat="server" ID="btnContract_Preview" CssClass="CSButton" Width="12%" Text="Preview" Enabled="false" OnClientClick="StartProgressBar();" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>



                                            <asp:View runat="server" ID="vwTab4_NTP">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search by :</span>
                                                            &nbsp;<asp:DropDownList runat="server" ID="drpNTP_Search" CssClass="drpdownCSS" Width="12%">
                                                                <asp:ListItem Value="1" Text="ITB Number" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Project Name"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtNTP_Search" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnNTP_Search" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdNTP" SkinID="GridViewAA" Width="90%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                                DataKeyNames="Infra_BidPrep_ID,Supplier_ID">
                                                                <Columns>

                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkReso_Select" Text="Select" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="ITB_No" HeaderText="ITB Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50%" DataField="PPA" HeaderText="Project Name" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="28%" DataField="SuppName" HeaderText="Bidder's Name" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="80%">
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">NTP Date :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtNTP_Date" CssClass="txtbox_Date" Width="20%" Text="" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender4" TargetControlID="txtNTP_Date" PopupButtonID="txtNTP_Date" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender4" TargetControlID="txtNTP_Date" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">NTP Number :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:TextBox runat="server" ID="txtNTP_No" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%" class="column_RightBold">Approved by :</td>
                                                                    <td style="width: 70%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpNTP_Approvedby" CssClass="drpdownCSS" Width="60%">
                                                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                                                        </asp:DropDownList>
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
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnNTP_Save" CssClass="CSButton" Width="12%" Text="Save" Enabled="false" OnClientClick="StartProgressBar();" />
                                                            &nbsp;<asp:Button runat="server" ID="btnNTP_Preview" CssClass="CSButton" Width="12%" Text="Preview" Enabled="false" OnClientClick="StartProgressBar();" />

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

