<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="TransferApproval.aspx.vb" Inherits="Inventory_TransferApproval" StylesheetTheme="SkinFile" %>


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
                        <td style="width: 98%" class="PageTitle">TRANSFER APPROVAL
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
                        <td style="width: 98%" class="DivTitle">Transfer Approval List
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                         <asp:GridView ID="grdPendingPRS" runat="server" Width="98%" SkinID="GridViewAA" 
                              DataKeyNames="MRE_Transfer_ID,MREHdr_ID,Returned_ID,TransferTo,DepartmentFromID"
                              EmptyDataText="No Data Found." HorizontalAlign="Center" OnSelectedIndexChanged="grdPendingPRS_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="false" CssClass="LinkBtnSelect" CommandName="Select" Text="Select"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>

                                     <asp:BoundField DataField="DateTransfer" HeaderText="Date Transfer" HtmlEncode="false" DataFormatString="{0:MM/dd/yyyy}">
                                        <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                    </asp:BoundField>

                
                                    <asp:BoundField DataField="DepartmentFrom" HeaderText="Department From" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DepartmentTo" HeaderText="Department To" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                   
                                    <asp:BoundField DataField="ReturnedBy" HeaderText="Transferred To" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Purpose" HeaderText="Purpose" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Width="12%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                       <tr>
                           <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">LIST OF PROPERTIES TO TRANSFER
                        </td>
                        <td style="width: 1%"> </td>
                    </tr>
                    
                    <tr>
                         <td style="width: 1%"></td>
                        <td style="width: 98%" >
                            <asp:GridView ID="grListOfProperty" runat="server" Width="98%" SkinID="GridViewAA" 
                                AllowPaging="True" HorizontalAlign="Center" OnSelectedIndexChanged="grListOfProperty_SelectedIndexChanged">
                                <Columns>
      
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="false" CssClass="LinkBtnSelect" CommandName="Select" Text="Select"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>


                                    <asp:BoundField DataField="Item_Desc" HeaderText="Item Description" HtmlEncode="false">
                                        <HeaderStyle Font-Size="Smaller" HorizontalAlign="Center" Width="25%" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    </asp:BoundField>

      
                                    <asp:BoundField DataField="PropertyNo" HeaderText="Property Number">
                                        <HeaderStyle Font-Size="Smaller" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Item_ID" HeaderText="Item_ID" Visible="false">
</asp:BoundField>

      
                                    <asp:BoundField DataField="AcquiredDate" HeaderText="Acq Date" DataFormatString="{0:MM/dd/yyyy}">
                                        <HeaderStyle Font-Size="Smaller" HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:BoundField>

       
                                    <asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Amount">
                                        <HeaderStyle Font-Size="Smaller" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                    </asp:BoundField>

      
                                    <asp:BoundField DataField="fullname" HeaderText="Issued To">
                                        <HeaderStyle Font-Size="Smaller" HorizontalAlign="Center" Width="18%" />
                                        <ItemStyle HorizontalAlign="Left" Width="18%" />
                                    </asp:BoundField>

        
                                    <asp:BoundField DataField="DateIssued" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date Issued">
                                        <HeaderStyle Font-Size="Smaller" HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:BoundField>

    
                                    <asp:BoundField DataField="Status" HeaderText="Status">
                                        <HeaderStyle Font-Size="Smaller" HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="MREHdr_ID" HeaderText="MREHdr_ID" Visible="false">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="MRE_Transfer_ID" HeaderText="MRE_Transfer_ID" Visible="false">
                                        <HeaderStyle Font-Size="Smaller" />
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
                         <td style="width: 1%; height: 28px;"></td>
                        <td style="width: 98%; height: 28px;" >
                                <asp:Button ID="btnApprove" runat="server" Width="150px" CssClass="CSButton" Enabled="false" Text="APPROVE"  OnClientClick="StartProgressBar();"></asp:Button>
                     &nbsp;
                                     <asp:Button ID="btnDisApprove" runat="server"  enabled="false"  Width="150px" CssClass="CSButton" Text="DISAPPROVE"  OnClientClick="StartProgressBar();"></asp:Button>
                       &nbsp;
                                           <asp:Button ID="btnPreview" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW"  OnClientClick="StartProgressBar();"></asp:Button>
                     
                             </td>
                        <td style="width: 1%; height: 28px;"> </td>
                    </tr>
                </table>
          </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>