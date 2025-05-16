<%@ Page Title="Pre Repair Inspection" Language="VB"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_Pre_Repair_Inspection_RepQuery.aspx.vb" Inherits="Reports_and_Query_t_Pre_Repair_Inspection"   StylesheetTheme="SkinFile" %>

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


            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                <ContentTemplate>


                    <div>
                        <table width="1020px">
                            <tr>
                                <td style="width: 1%"></td>
                                <td style="width: 98%" class="PageTitle">PRE-REPAIR INSPECTION REPORTS
                                </td>
                                <td style="width: 1%"></td>
                            </tr>
                            <tr>
                                <td style="width: 1%"></td>
                                <td style="width: 98%" align="center">
                                    <table width="90%">
                                        <tr>
                                            <td style="width: 10%" class="column_RightBold">Search By :</td>
                                            <td style="width: 20%" class="column_Left">
                                                <asp:RadioButtonList ID="rbSearch" runat="server" Width="98%" CssClass="rbCS_Vertical" AutoPostBack="True">
                                                    <asp:ListItem Value="1">Account</asp:ListItem>
                                                    <asp:ListItem Value="2">Department</asp:ListItem>
                                                  
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="width: 70%" class="column_Left">
                                                <asp:MultiView ID="mvSearch" runat="server">

                                                    <asp:View ID="vwAccount" runat="server">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold">Account :</td>
                                                                <td style="width: 80%" class="column_Left">
                                                                    &nbsp;<asp:DropDownList ID="drpAccount" runat="server" CssClass="drpdownCSS" Width="60%">
                                                                    </asp:DropDownList>
                                                                    <asp:Button ID="btnSearch_GA" runat="server" Width="20%" Text="Search" OnClientClick="StartProgressBar();" CssClass="CSButton"></asp:Button></td>
                                                            </tr>
                                                        </table>
                                                    </asp:View>


                                                    <asp:View ID="vwDepartment" runat="server">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold">Department :</td>
                                                                <td style="width: 80%" class="column_Left">
                                                                    <asp:DropDownList ID="drpDepartment" runat="server" Width="60%" CssClass="drpdownCSS">
                                                                    </asp:DropDownList>
                                                                    <asp:Button ID="btnSearch_RC" runat="server" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Search" Width="20%" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold"></td>
                                                                <td style="width: 80%" class="column_Left">
                                                                    &nbsp;</td>
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
                                <td style="width: 98%" class="DivTitle">Pre-Repair Inspection
                                </td>
                                <td style="width: 1%"></td>
                            </tr>
                            <tr>
                                <td style="width: 1%"></td>
                                <td style="width: 98%" align="center">
                                    <asp:GridView ID="grdRepair" runat="server" AllowPaging="True" PageSize="20" SkinID="GridViewAA" Width="98%"
                                        DataKeyNames="repair_hdr_id" EmptyDataText="No Data Found.">
                                        <Columns>
                                            <asp:TemplateField>
                                               <ItemTemplate>
                                            <asp:LinkButton ID="lnkSelect" CssClass="LinkBtnSelect" runat="server" CausesValidation="False" Text="Select" Font-Underline="False" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="repair_date" DataFormatString="{0:d}" HeaderText="Date" />
                                            <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="55%" DataField="RC_Name" HeaderText="Department" />
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" DataField="GA_Code2" HeaderText="Account Code" />
                                        
                                        </Columns>
                                    </asp:GridView>
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
                                <td style="width: 98%" class="DivTitle">List Of Property
                                </td>
                                <td style="width: 1%"></td>
                            </tr>
                               <tr>
                                <td style="width: 1%"></td>
                                <td style="width: 98%" align="center">
                                    <asp:GridView runat="server" ID="grdProperty" SkinID="GridViewAA" Width="98%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="15"
                                                                DataKeyNames="PropertyDetai_ID">
                                        <Columns>
                                         
                                              <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="35%" DataField="Item_Desc" HeaderText="Description" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="PropertyNo" HeaderText="Property Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" DataField="SerialNo" HeaderText="Serial / Plate Number" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" DataField="previous_scope" HeaderText="Nature & Date Last Repaired" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" DataField="nature_scope" HeaderText="Nature & Scope of Work to be Done" />
                                        
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td style="width: 1%"></td>
                            </tr>

                            <tr>
                                <td style="width: 1%"></td>
                                <td style="width: 98%"></td>
                                <td style="width: 1%"></td>
                            </tr>
                             <tr>
                                <td style="width: 1%; "></td>
                                <td style="width: 98%; "></td>
                                <td style="width: 1%; "></td>
                            </tr>
                             <tr>
                                <td style="width: 1%; height: 36px;"></td>
                                <td style="width: 98%; height: 36px;">
                                    <asp:Button ID="BtnPreview" runat="server" Text="PREVIEW" CssClass="CSButton"  />
                                 </td>
                                <td style="width: 1%; height: 36px;"></td>
                            </tr>
                            <tr>
                                <td style="width" 1%></td>
                                <td style="width"98%></td>
                                <td style="width"1%></td>
                            </tr>


                            
                         </table>    
                    </div>





                    <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                        <img alt="" src="../images/ajax-loader.gif" />
                    </asp:Panel>
                    <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender">
                    </cc1:ModalPopupExtender>
                    <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>



                </ContentTemplate>
            </asp:UpdatePanel>



        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

