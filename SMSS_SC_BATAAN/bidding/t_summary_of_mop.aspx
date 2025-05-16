<%@ Page 
    Title="Summary of Mode of Procurement"
    Language="VB" 
    AutoEventWireup="false" 
    MasterPageFile="~/MasterPage.master"
    CodeFile="t_summary_of_mop.aspx.vb" 
    Inherits="bidding_t_summary_of_mop"
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">


</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
                   <div>
                       <table width="100%">
                              <tr>
                                    <td style="width: 98%" class="PageTitle">Monitoring</td>
                              </tr>
                              <tr>
                                  <td>
                                      
                                      <table>
                                          <tr>
                                             
                                              <td class="column_RightBold">Mode of Procurement : </td>
                                              <td class="column_Left">
                                                   <asp:DropDownList ID="dd_mode_of_procurement" runat="server" Width="150px" CssClass="drpdownCSS"  AutoPostBack="True" OnSelectedIndexChanged="dd_mode_of_procurement_SelectedIndexChanged" >
                                                        <asp:ListItem Text="Select"></asp:ListItem>
                                                   </asp:DropDownList>
                                              </td>
                                              <td class="column_RightBold" style="width:50px">From :</td>
                                              <td><asp:TextBox ID="txtFrom" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                              <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtFrom" PopupButtonID="txtFrom"></cc1:CalendarExtender>
                                              <td class="column_RightBold" >To :</td>
                                              <td><asp:TextBox ID="txtTo" runat="server" CssClass="txtbox_Var" Width="100px"></asp:TextBox></td>
                                              <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo" PopupButtonID="txtTo"></cc1:CalendarExtender>
                                              <td>
                                                  <asp:Button ID="btnSearch" CssClass="CSButton" Text="Search" runat="server" OnClick="btnSearch_Click" />
                                              </td>
                                           </tr>
                                         
                                      </table>
                                  </td>
                              </tr>
                               <tr align="center">
                                              <td>
                                                  <asp:Panel ID="Panel2" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical" BorderColor="DodgerBlue" BorderStyle="Solid" BorderWidth="1px">
                                                       <asp:GridView ID="gvMonitoring" runat="server" Width="100%" EmptyDataText="No Data Found." Font-Size="8pt" CssClass="text"  DataKeyNames="" AutoGenerateColumns="False" SkinID="GridViewAA" ShowFooter="True"
                                                        OnRowDataBound="gvMonitoring_RowDataBound">
                                                            <Columns>

                                                                <asp:BoundField  HeaderText="No.">
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                 </asp:BoundField>
                                          
                                                                 <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                 </asp:BoundField>


                                                                  <asp:BoundField DataField="RC_Name" HeaderText="Department">
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                 </asp:BoundField>
                                                                 <asp:BoundField DataField="remarks" HeaderText="PPA Description">
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                 </asp:BoundField>

                                                                <asp:BoundField DataField="GA_Code" HeaderText="Account Code">
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:BoundField>


                                                                <asp:BoundField DataField="ABC" HeaderText="Amount"  DataFormatString="{0:n2}">
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:BoundField>
                                                            </Columns>
                                                       </asp:GridView>
                                                  </asp:Panel>
                                              </td>
                                          </tr>

                       </table>
                   </div>
               </ContentTemplate>
       </asp:UpdatePanel>
</asp:Content>