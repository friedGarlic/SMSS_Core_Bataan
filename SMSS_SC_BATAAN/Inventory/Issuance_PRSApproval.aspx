<%@ Page Title="" 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="Issuance_PRSApproval.aspx.vb" 
    Inherits="Inventory_Issuance_PRSApproval" 
    StylesheetTheme="SkinFile"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">

</script>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
              <div>
                <table width="100%" style="padding-bottom:5%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">PROPERTY RETURN SLIP APPROVAL
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                     <tr>
                      <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <table width="95%">
                                <tr>
                                    <td class="column_RightBold" style="width:10%">
                                        Search by :
                                    </td>
                                   <td class="column_LeftBold" style="width:15%">
                                           <asp:DropDownList ID="drpSearch" runat="server" Width="95%" AutoPostBack="true" OnSelectedIndexChanged="drpSearch_SelectedIndexChanged">
                                               <asp:ListItem Value="0">Department</asp:ListItem>
                                               <asp:ListItem Value="1">Date</asp:ListItem>
                                           </asp:DropDownList>
                                    </td>
                                    <td style="width:65%">
                                        <asp:MultiView ID="mvSearch" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="vwDepartment" runat="server" >
                                                <table style="width:100%;">
                                            <tr>
                                                <td class="column_RightBold" style="width:20%">
                                                   Department :
                                                </td>
                                                <td class="column_LeftBold" style="width:80%">
                                                    <asp:DropDownList ID="drpDepartment" runat="server" Width="95%" AutoPostBack ="true"  OnSelectedIndexChanged="drpDepartment_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                            </asp:View>
                                            <asp:View ID="vwDate" runat="server">
                                                    <table style="width:100%;">
                                            <tr>
                                                <td class="column_LeftBold" style="width:100%">
                                                   Date From : &nbsp; 
                                                      <asp:TextBox ID="txtDateFrom" runat="server" Width="150px" ></asp:TextBox>
                                                      <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDateFrom" Enabled="True" PopupButtonID="txtDateFrom"></cc1:CalendarExtender>
                                       &nbsp;  Date to : &nbsp; 
                                                      <asp:TextBox ID="txtDateto" runat="server" Width="150px" ></asp:TextBox>
                                                      <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateto" Enabled="True" PopupButtonID="txtDateto"></cc1:CalendarExtender>
                                    
                                                                      
                                                </td>
                                                
                                            </tr>
                                        </table>
                                            </asp:View>
                                        </asp:MultiView>
                                        
                                    </td>
                                      <td class="column_LeftBold" style="width:10%">
                                           <asp:Button ID="btnSearch" runat="server" Width="150px" CssClass="CSButton" Text="SEARCH"  OnClientClick="StartProgressBar();" OnClick="btnSearch_Click"></asp:Button>
                          
                                      </td>
                                   
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                         </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Property Return Slip List	
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                                <asp:GridView ID="grdPendingPRS" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="prs_hdr_id,Returned_ID,Purpose" AutoGenerateSelectButton="true"
                                          EmptyDataText="No Data Found." HorizontalAlign="Center"  OnSelectedIndexChanged="grdPendingPRS_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:BoundField DataField="Department" HeaderText="Department" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PRSDate" HeaderText="PRS Date" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ReturnedBy" HeaderText="Returned By" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Purpose" HeaderText="Purpose" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Right" Width="30%"></ItemStyle>
                                                       </asp:BoundField>
                                                       <asp:BoundField DataField="Remarks" HeaderText="Remarks" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Right" Width="30%"></ItemStyle>
                                                       </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                       <tr>
                           <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">LIST OF PROPERTIES TO RETURN
                        </td>
                        <td style="width: 1%"> </td>
                    </tr>
                    
                    <tr>
                         <td style="width: 1%"></td>
                        <td style="width: 98%" >
                               <asp:GridView ID="grListOfProperty" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="status,PropertyNo,Rc_name,rc_id,function_id,MREHdr_ID,Property_ID,PropertyDetai_ID,Item_Desc,Item_ID,MREDtl_ID,Cost,SerialNo,Returned_ID"
                                                    AllowPaging="True" HorizontalAlign="Center" OnSelectedIndexChanged="grListOfProperty_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="false" CssClass="LinkBtnSelect" CommandName="Select" Text="Select"></asp:LinkButton>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="Item_Desc" HeaderText="Item Description" HtmlEncode="false">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PropertyNo" HeaderText="Property Number">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AcquiredDate" HeaderText="Acq Date">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Amount">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="rc_name" HeaderText="Department">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="fullname" HeaderText=" Issued To">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DateIssued" DataFormatString="{0:d}" HeaderText="Date Issued">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MRE_Date" DataFormatString="{0:d}" HeaderText="Date Returned / Disposed">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Status" HeaderText="Status">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MREHdr_ID" HeaderText="MREHdr_ID" Visible="false">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                   
                    <tr>
                           <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <table width="100%">
                                <tr>
                                      <td class="column_RightBold" style="width:30%">
                                          Approved / Disapproved By :
                                      </td>
                                     <td class="column_LeftBold" style="width:25%">
                                           <asp:DropDownList ID="drpApprovedBy" runat="server" Width="95%">
                                             
                                           </asp:DropDownList>
                                    </td>
                                    <td class="column_RightBold" style="width:5%"> Date :
                                       </td>
                                    <td class="column_LeftBold" style="width:35%">
                                           <asp:TextBox ID="txtDate" runat="server" Width="25%"></asp:TextBox>
                                        (mm/dd/yyyy)
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"> </td>
                    </tr>
                      <tr>
                         <td style="width: 1%"></td>
                        <td style="width: 98%" >
                                <asp:Button ID="btnApprove" runat="server" Width="150px" CssClass="CSButton" Enabled="false" Text="APPROVE"  OnClientClick="StartProgressBar();"></asp:Button>
                     &nbsp;
                                     <asp:Button ID="btnDisApprove" runat="server" Width="150px" CssClass="CSButton" Text="DISAPPROVE"  OnClientClick="StartProgressBar();"></asp:Button>
                       &nbsp;
                                           <asp:Button ID="btnPreview" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW"  OnClientClick="StartProgressBar();"></asp:Button>
                     
                             </td>
                        <td style="width: 1%"> </td>
                    </tr>
                </table>
          </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>

