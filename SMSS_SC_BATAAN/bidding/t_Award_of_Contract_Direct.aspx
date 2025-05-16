<%@ Page 
    Language="VB" 
    Title="Award of Canvass"
    AutoEventWireup="false" 
    MasterPageFile="~/MasterPage.master"
    CodeFile="t_Award_of_Contract_Direct.aspx.vb" 
    Inherits="t_Award_of_Contract_Direct"
    EnableEventValidation="false"
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
                <div>
                    <table width="100%">
                        <tr align="center">
                            <td>
                                <table>
                                    <tr>
                                      
                                        <td style="width: 20%" align="left">
                                            <asp:Button runat="server" ID="btnTab1_ROA" Width="100%" Text="Resolution of Award" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                        </td>
                                        <td style="width: 20%" align="left">
                                            <asp:Button runat="server" ID="btnTab2_NOA" Width="100%" Text="Notice of Award" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                        </td>
                                       
                                        <td style="width: 20%" align="left">
                                            <asp:Button runat="server" ID="btnTab4_NTP" Width="100%" Text="Notice to Proceed" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                        </td>
                                       
                                    </tr>
                                </table>
                            </td>
                        </tr>

                         <td  align="left">
                                            <asp:Button runat="server" ID="btnTab3_Contract" Text="Contract" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" Visible="false"/>
                                        </td>


                        <tr>
                            <td>
                                <asp:MultiView runat="server" ID="mvTabs">

                                   <asp:View runat="server" ID="vwROA">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Search By :</span>
                                                            &nbsp;<asp:DropDownList ID="drpSearch_ROA" runat="server" Width="12%" CssClass="drpdownCSS">
                                                                <asp:ListItem Value="1" Text="PR Number" Selected="True"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox ID="txtSearch_Resolution" runat="server" Width="20%" CssClass="txtbox_Var"></asp:TextBox>
                                                            &nbsp;<asp:Button ID="btnSearch_Resolution" runat="server" Width="15%" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();"></asp:Button>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView ID="grdResolution" runat="server" Width="98%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="10" SkinID="GridViewAA"
                                                                DataKeyNames="Hdr_ID,prhdr_id">
                                                                <Columns>
                                                                    <asp:BoundField DataField="MOP" HeaderText="Mode of Procurement">
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="Approved Budget (ABC)">
                                                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:TemplateField HeaderText="Resolution No">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtResoNo" runat="server" Width="95%" CssClass="txtbox_Date" Visible='<%# Bind("isVisible") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Resolution Date">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtResolutionDate" runat="server" Width="95%" CssClass="txtbox_Date" Visible='<%# Bind("isVisible") %>' Text='<%# Bind("Canvass_Date", "{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Resolve Date">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtResolveDate" runat="server" Width="95%" CssClass="txtbox_Date" Visible='<%#Bind("isVisible") %>' Text='<%# bind ("Canvass_Date", "{0:d}") %>'></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtResolveDate" Enabled="True" PopupButtonID="txtResolveDate"></cc1:CalendarExtender>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Quotation Date">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtQuotationDate" runat="server" CssClass="txtbox_Date" Visible='<%#Bind("isVisible") %>' Width="95%" Text='<%# bind ("Canvass_Date", "{0:d}") %>'></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtenderQD" runat="server" TargetControlID="txtQuotationDate" Enabled="True" PopupButtonID="txtQuotationDate"></cc1:CalendarExtender>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                    </asp:TemplateField>

                                                                   <asp:TemplateField>
                                                                         <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkViewReso" 
                                                                                runat="server" 
                                                                                Text="View" 
                                                                                CssClass="LinkBtnSelect" 
                                                                                Visible='<%# Bind("isVisible") %>' 
                                                                                CommandName="Select">
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 20px"></td>
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
                                                      
                                                        <asp:ListItem Value="1" Text="PR Number" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Supplier Name"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    &nbsp;<asp:TextBox runat="server" ID="txtNOA_Search" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                    &nbsp;<asp:Button runat="server" ID="btnNOA_Search" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView runat="server" ID="grdNOA" SkinID="GridViewAA" Width="90%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                         DataKeyNames="Infra_BidPrep_ID, prhdr_id, pr_no, Total_Amt, Hdr_ID, Supplier_ID,mode_of_procurement_id">
                                                        <Columns>
                                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="MOP" HeaderText="Mode of Procurement" />
                                                            <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="40%" DataField="SuppName" HeaderText="Supplier Name" />
                                                            <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="14%" DataField="Total_Amt" HeaderText="Supplier ABC" />
                                                            <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="14%" DataField="pr_no" HeaderText="PR Number" />
                                                            
                                                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="14%" HeaderText="NOA Date">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtNOADate" runat="server" 
                                                                            CssClass="txtbox_Date" 
                                                                            Width="80%" 
                                                                            Text='<%# If(Eval("NOA_Date") Is DBNull.Value, DateTime.Today.ToString("MM/dd/yyyy"), Eval("NOA_Date", "{0:MM/dd/yyyy}")) %>'
                                                                            Visible='<%# Not String.IsNullOrEmpty(Eval("pr_no").ToString()) %>'>
                                                                </asp:TextBox>
                                                                <cc1:CalendarExtender ID="ceNOADate" runat="server" 
                                                                                    TargetControlID="txtNOADate" 
                                                                                    PopupButtonID="txtNOADate" 
                                                                                    Format="MM/dd/yyyy">
                                                                </cc1:CalendarExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                             <asp:TemplateField>
                                                                 <ItemTemplate>
                                                                    <asp:LinkButton ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50%" ID="lnkView" runat="server" CommandName="Select"  CssClass="LinkBtnPreview" Font-Underline="False"  OnClientClick="StartProgressBar();" Visible='<%#Bind("isVisible") %>'>View</asp:LinkButton>
                                                                 </ItemTemplate>
                                                                 <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                             </asp:TemplateField>


                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 10px"></td>
                                            </tr>
                              
                                            <tr>
                                                <td style="width: 100%; height: 30px"></td>
                                            </tr>
                                        </table>
                                    </asp:View>

                                    <asp:View runat="server" ID="vwTab3_Contract" >
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
                                                        <asp:ListItem Value="1" Text="PO Number" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Supplier"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    &nbsp;<asp:TextBox runat="server" ID="txtNTP_Search" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                    &nbsp;<asp:Button runat="server" ID="btnNTP_Search" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />

                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView runat="server" ID="grdNTP" SkinID="GridViewAA" Width="90%" AllowPaging="true" PageSize="12" EmptyDataText="No Data Found."
                                                        DataKeyNames="Infra_BidPrep_ID,CanvassAward_ID,Supplier_ID,POHdr_ID, PO_No,SuppName,Hdr_ID,PR_Hdr_ID,Supp_ABC,rfq_no">
                                                        <Columns>

                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lnkReso_Select" Text="Select" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" DataField="rfq_no" HeaderText="Ref. Number" />
                                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" DataField="PO_No" HeaderText="PO Number" />
                                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40%" DataField="SuppName" HeaderText="Supplier" />
                                                             <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" DataField="Supp_ABC" HeaderText="Amount" />

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
                                                                        <asp:TextBox runat="server" ID="txtNTP_Date" CssClass="txtbox_Date" Width="30%" MaxLength="10"></asp:TextBox>
                                                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtNTP_Date" PopupButtonID="txtNTP_Date" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtNTP_Date" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                                                   </td>
                                                                    <td style="width: 15%" class="column_RightBold">Approved By :</td>
                                                                    <td style="width: 35%" class="column_Left">
                                                                        <asp:DropDownList runat="server" ID="drpNTP_Approvedby" CssClass="drpdownCSS" Width="90%"></asp:DropDownList>
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
                                                            <div class="ReportBorderCSS" style="width: 90%">
                                                                <table width="90%">
                                                                    <tr>
                                                                        <td style="width: 100%; height: 10px"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <span class="ReportEncoding_Title">NOTICE TO PROCEED</span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%; height: 20px"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" class="column_Center">
                                                                            <asp:TextBox runat="server" ID="txtNTP_Content" Text="" CssClass="txtbox_ReportEncoding" Width="95%" Height="150px" TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%; height: 20px"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" class="column_Center">
                                                                            <asp:Button runat="server" ID="btnNTP_Save" CssClass="CSButton" Width="15%" Text="Save & Preview" Enabled="false" OnClientClick="StartProgressBar();"/>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%; height: 20px"></td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 20px"></td>
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
                </div>
          </ContentTemplate>
     </asp:UpdatePanel>

</asp:Content>


