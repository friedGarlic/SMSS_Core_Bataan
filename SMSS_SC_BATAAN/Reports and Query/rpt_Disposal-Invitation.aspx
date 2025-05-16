<%@ Page 
    Language="VB" 
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" 
    CodeFile="rpt_Disposal-Invitation.aspx.vb" 
    Inherits="Reports_and_Query_rpt_Disposal_Invitation"
    Title="Disposal-Invitation to Submit Sealed Proposal"
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
               <div>
                   <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">Disposal-Invitation to Submit Sealed Proposal Report
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List of Invitation to Submit Sealed Proposal
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                      
                           <tr>
                               <td style="width: 1%"></td>
                               <td style="width: 98%">
                                   <asp:GridView ID="grdISSP" runat="server" AllowPaging="false" DataKeyNames="IIRUPHdr_ID,isWMR,IsspHdr_ID" EmptyDataText="No Data Found." SkinID="GridViewAA" Width="100%">
                                       <Columns>
                                           <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" Text="Preview ISSP" CssClass="LinkBtnPreview" CommandArgument='<%# Eval("IsspHdr_ID") %>' CommandName="Select" Font-Underline="False" OnClick="LinkButton1_Click"  OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:TemplateField>

                                           <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" Text="Preview BF" CssClass="LinkBtnPreview" CommandArgument='<%# Eval("IIRUPHdr_ID") %>' CommandName="Select" Font-Underline="False" OnClick="LinkButton2_Click"  OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:TemplateField>

                                           <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" Text="Preview NPB" CssClass="LinkBtnPreview" CommandArgument='<%# Eval("IIRUPHdr_ID") %>' CommandName="Select" Font-Underline="False" OnClick="LinkButton3_Click"  OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:TemplateField>

                                           <asp:BoundField DataField="IIRUP_Date" DataFormatString="{0:d}" HeaderText="IIRUP Date / WMR Date" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%" />
                                           <asp:BoundField DataField="IIRUP_No" HeaderText="IIRUP Number / WMR No." ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" />
                                           <asp:BoundField DataField="particulars" HeaderText="Particular" ItemStyle-HorizontalAlign="left" ItemStyle-Width="30%" />
                                           <asp:BoundField DataField="HRUnserviceable" HeaderText="How Rendered Unserviceable" ItemStyle-HorizontalAlign="left" ItemStyle-Width="30%" />
                                           <asp:BoundField DataField="PropCnt" HeaderText="No. of Properties" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" />
                                           <asp:BoundField DataField="TotalAppraisedValue" DataFormatString="{0:N}" HeaderText="Total Appraised Value" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%" />
                                           <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                       </Columns>
                                   </asp:GridView>
                               </td>
                               <td style="width: 1%"></td>
                           </tr>
                       

                   </table>
               </div>
           </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>

