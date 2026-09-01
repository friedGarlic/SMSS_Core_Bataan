<%@ Page 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="t_bid_form_report.aspx.vb" 
    Inherits="Reports_and_Query_t_bid_form_report" 
    StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
                  <div>
                        <table width="1020px">
                            <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" class="DivTitle">List Of Bid Form Report
                            </td>
                            <td style="width: 1%"></td>

                            <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" >
                               <asp:GridView ID="gvopen" runat="server" Width="98%" SkinID="GridViewAA" EmptyDataText="NO DATA FOUND"
                                DataKeyNames="pre_procurement_hdr_id" AutoGenerateColumns="False" AllowPaging="true" PageSize="30">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CssClass="LinkBtnPreview" runat="server" CausesValidation="False" Text="Preview" Font-Underline="False" CommandName="Select" __designer:wfdid="w27"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                     <asp:BoundField DataField="project_reference_no" HeaderText="Reference No.">
                                        <ItemStyle HorizontalAlign="center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="project_name" HeaderText="Project Name">
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="project_location" HeaderText="Location">
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="Amount">
                                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="opening_date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Opening Date">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                 
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


