<%@ Page Title="Canvass Resolution Report" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CanvassResolution_ReportEdit.aspx.vb"
    Inherits="bidding_CanvassResolution_ReportEdit" StylesheetTheme="SkinFile" %>


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
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">CANVASS RESOLUTION AWARD
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
                            <span class="column_RightBold">Name of Project :</span>
                            &nbsp;<asp:Label runat="server" ID="lblProjectName" CssClass="lbltext"></asp:Label>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Resolution Number :</span>
                            &nbsp;<asp:Label runat="server" ID="lblResolutionNo" CssClass="lbltext"></asp:Label>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">BAC RESOLUTION RECOMMENDING THE AWARD OF CONTRACT THRU THE USE OF ALTERNATIVE MODE OF PROCUREMENT FOR THE</span>
                            &nbsp;<asp:Label runat="server" ID="lblProjectName2" CssClass="lbltext"></asp:Label>
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
                            <asp:TextBox runat="server" ID="txtPart1" CssClass="txtbox_Encoding" Width="80%" Height="250px" TextMode="MultiLine"></asp:TextBox>
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
                            <asp:MultiView runat="server" ID="mvMOP">
                                <asp:View runat="server" ID="vwCanvasss">
                                    <asp:GridView runat="server" ID="grdItems" SkinID="GridViewAA" Width="98%" AllowPaging="true" PageSize="15" EmptyDataText="No Data Found.">
                                        <Columns>
                                            <asp:BoundField HeaderText="Item No" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" DataField="ItemNo" DataFormatString="{0:0.##}" />
                                            <asp:BoundField HeaderText="Description" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="40%" DataField="Item_Desc" />
                                            <asp:BoundField HeaderText="Unit Cost" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%" DataField="UnitPrice" DataFormatString="{0:N}" />
                                            <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%" DataField="xSupp1" DataFormatString="{0:N}" />
                                            <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%" DataField="xSupp2" DataFormatString="{0:N}" />
                                            <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%" DataField="xSupp3" DataFormatString="{0:N}" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:View>


                                <asp:View runat="server" ID="vwAlternative">
                                      <asp:GridView runat="server" ID="grdAlternative" SkinID="GridViewAA" Width="90%" AllowPaging="true" PageSize="15" EmptyDataText="No Data Found.">
                                        <Columns>
                                            <asp:BoundField HeaderText="Item No" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" DataField="ItemNo" DataFormatString="{0:0.##}" />
                                            <asp:BoundField HeaderText="Description" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60%" DataField="Item_Desc" />
                                             <asp:BoundField HeaderText="Unit" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" DataField="Unit" />
                                            <asp:BoundField HeaderText="Unit Cost" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%" DataField="UnitPrice" DataFormatString="{0:N}" />
                                            <asp:BoundField ItemStyle-HorizontalAlign="Right" ItemStyle-Width="25%" DataField="UnitPrice" DataFormatString="{0:N}" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:View>
                            </asp:MultiView>

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
                            <asp:TextBox runat="server" ID="txtPart2" CssClass="txtbox_Encoding" Width="80%" Height="250px" TextMode="MultiLine"></asp:TextBox>
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
                            <asp:Button runat="server" ID="btnPreview" CssClass="CSButton" Width="15%" Text="Save / Preview" OnClientClick="StartProgressBar();" />
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
                </table>
            </div>



            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        



        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

