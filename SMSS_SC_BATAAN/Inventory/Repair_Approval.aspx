<%@ Page Title="Repair Approval" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Repair_Approval.aspx.vb" Inherits="Inventory_Repair_Approval"
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
                        <td style="width: 98%" class="PageTitle">Repair Approval</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="left">

                            <table cellpadding="0px" cellspacing="0px" width="100%">
                                <tr>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab1_PreRepair" Width="100%" Text="Pre-repair Inspection" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab2_RepairCard" Width="100%" Text="Property Repair Card" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 60%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="3" class="PanelTabs">
                                        <asp:MultiView runat="server" ID="mvTabs">


                                            <asp:View runat="server" ID="vwTab1_PreRepair">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="column_RightBold">Department :</span>
                                                            &nbsp;<asp:TextBox runat="server" ID="txtPreRepair_Search" CssClass="txtbox_Var" Width="30%" Text=""></asp:TextBox>
                                                            &nbsp;<asp:Button runat="server" ID="btnPreRepair_Search" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">


                                                            <asp:GridView runat="server" ID="grdPreRepairList" SkinID="GridViewAA" Width="80%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="15"
                                                                DataKeyNames="repair_hdr_id,repair_date">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkSelect" CommandName="Select" Text="Select" CssClass="LinkBtnSelect" Visible='<%# Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" DataField="repair_date" DataFormatString="{0:d}" HeaderText="Date" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="55%" DataField="RC_Name" HeaderText="Department" />
                                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" DataField="GA_Code2" HeaderText="Account Code" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" class="DivTitle">List of Properties
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:GridView runat="server" ID="grdPropertyList" SkinID="GridViewAA" Width="98%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="15"
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
                                                    </tr>



                                                    <tr>
                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 10px" align="center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <asp:Button runat="server" ID="btnPreview1" CssClass="CSButton" Width="12%" Text="Preview" Enabled="false" OnClientClick="StartProgressBar();" />
                                                            <asp:Button runat="server" ID="btnApproved_Prerepair" CssClass="CSButton" Width="12%" Text="Approve" Enabled="false" OnClientClick="StartProgressBar();" />
                                                            &nbsp;<asp:Button runat="server" ID="btnCancel_Prerepair" CssClass="CSButton" Width="12%" Text="Cancel" Enabled="false" OnClientClick="StartProgressBar();" />

                                                            <cc1:ConfirmButtonExtender runat="server" ID="ConfirmButtonExtender_Prerepair_Approved" TargetControlID="btnApproved_Prerepair" ConfirmText="Are you sure to APPROVE this pre-repair inspection?"></cc1:ConfirmButtonExtender>
                                                            <cc1:ConfirmButtonExtender runat="server" ID="ConfirmButtonExtender_Prerepair_Cancel" TargetControlID="btnCancel_Prerepair" ConfirmText="Are you sure to CANCEL this pre-repair inspection?"></cc1:ConfirmButtonExtender>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 30px" align="center"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>



                                            <asp:View runat="server" ID="vwTab2_RepairCard">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 50px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <span class="AlertMsg">This page is under development.</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; height: 50px"></td>
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
                        <td style="width: 98%; height: 30px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>

            <asp:Panel runat="server" ID="pnlRepairNo" Width="300px" CssClass="Panel_Popup">
                <div>
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">Property Repair Number
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
                                <asp:TextBox runat="server" ID="txtRepairNo" CssClass="txtbox_CenterBold" ReadOnly="true" Width="60%"></asp:TextBox>
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
                                <asp:Button runat="server" ID="btnOK" CssClass="CSButton" Text="OK" Width="30%" />
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 15px">
                                <asp:Label runat="server" ID="lblPopup"></asp:Label>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <cc1:ModalPopupExtender runat="server" ID="ModalPopupExtender1" TargetControlID="lblPopup" PopupControlID="pnlRepairNo" BackgroundCssClass="modalBackground" CancelControlID="btnOK"></cc1:ModalPopupExtender>


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

