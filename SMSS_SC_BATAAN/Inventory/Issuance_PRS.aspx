<%@ Page 
    Title="" 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="Issuance_PRS.aspx.vb" 
    Inherits="Inventory_Issuance_PRS" 
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
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">PROPERTY RETURN SLIP
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                      <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <table width="95%">
                                <tr>
                                      <td class="column_RightBold" style="width:15%"> Department :
                                       </td>
                                    <td class="column_LeftBold" style="width:35%">
                                           <asp:DropDownList ID="drpDepartment" runat="server" Width="95%"></asp:DropDownList>
                                    </td>
                                   <td class="column_RightBold" style="width:15%">  Gen. Account :
                                       
                                   </td>
                                    <td class="column_LeftBold" style="width:35%">
                                          <asp:DropDownList ID="drpGenAccnt" runat="server" Width="95%"  OnSelectedIndexChanged="drpGenAccnt_SelectedIndexChanged"></asp:DropDownList>                                              
                                    </td>
                                </tr>
                                 <tr>
                                      <td class="column_RightBold" style="width:15%"> Function :
                                       </td>
                                    <td class="column_LeftBold" style="width:35%">
                                           <asp:DropDownList ID="drpFunction" runat="server" Width="95%"></asp:DropDownList>
                                    </td>
                                   <td class="column_RightBold" style="width:15%">  Fund Source :
                                       
                                   </td>
                                    <td class="column_LeftBold" style="width:35%">
                                          <asp:DropDownList ID="drpFund" runat="server" Width="45%"></asp:DropDownList>                                              
                                    </td>
                                </tr>
                                
                            </table>
                        </td>
                        <td  style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" >
                              <asp:Button ID="btnViewProp" runat="server" Width="150px" CssClass="CSButton" Text="VIEW"  OnClientClick="StartProgressBar();" OnClick="btnViewProp_Click" ></asp:Button>
                           
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">LIST OF PROPERTIES
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                                                <asp:GridView ID="gvsearchProperty" runat="server" Width="95%" SkinID="GridViewAA" DataKeyNames="Item_id,Item_Desc,GA_ID,ItemParticular,isDonated"
                                                    AllowPaging="True" HorizontalAlign="Center" AutoGenerateSelectButton="True">
                                                    <Columns>
                                                        <asp:BoundField DataField="Item_Desc" HeaderText="Item Description" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Description" HeaderText="Unit">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                         <td style="width: 1%"></td>
                        <td style="width: 98%" >
                               <asp:GridView ID="grListOfProperty" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="status,PropertyNo,Rc_name,rc_id,function_id,MREHdr_ID,Property_ID,PropertyDetai_ID,Item_Desc,Item_ID,MREDtl_ID,Cost,SerialNo"
                                                    AllowPaging="True" HorizontalAlign="Center">
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
                                                        <asp:BoundField DataField="MREHdr_ID" HeaderText="MREHdr_ID" Visible ="false">
                                                            <HeaderStyle Font-Size="Smaller"></HeaderStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                         <td style="width: 1%"></td>
                        <td style="width: 98%" >
                         <asp:Button ID="btnADD_Item" OnClick="btnADD_Item_Click" runat="server" CssClass="CSButton" Width="150px" Text="ADD"></asp:Button>
                                          
                        </td>
                        <td style="width: 1%"> </td>
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
                                 <asp:GridView ID="grdIssueItems" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="Item_Desc,PropertyNo,rc_id,function_id,Property_ID,PropertyDetai_ID,Item_ID,Cost,isDonated"
                                                    EmptyDataText="No Data Found." HorizontalAlign="Center">
                                                    <Columns>
                                                        <asp:BoundField DataField="Item_Desc" HeaderText="Item Description" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PropertyNo" HeaderText="Property Number">
                                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Amount">
                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="RC_Name" HeaderText="Department">
                                                            <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                          
                        </td>
                        <td style="width: 1%"> </td>
                    </tr>
                     <tr>
                           <td style="width: 1%"></td>
                        <td style="width: 98%" >
                            <table width="100%">
                                <tr>
                                     <td class="column_RightBold" style="width:15%"> Date :
                                       </td>
                                    <td class="column_LeftBold" style="width:35%">
                                           <asp:TextBox ID="txtDate" runat="server" Width="25%"></asp:TextBox>
                                         <cc1:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="txtDate" PopupButtonID="txtDate"></cc1:CalendarExtender>
                                        &nbsp;(MM/DD/YYYY)
                                    </td>
                                </tr>
                                 <tr>
                                     <td class="column_RightBold" style="width:15%"> Purpose :
                                       </td>
                                    <td class="column_LeftBold" style="width:35%">
                                           <asp:DropDownList ID="drpPurpose" runat="server" Width="95%">
                                               <asp:ListItem Value="0">Select</asp:ListItem>
                                               <asp:ListItem Value="1">Return to Stock</asp:ListItem>
                                               <asp:ListItem Value="2">Dispose</asp:ListItem>
                                               <asp:ListItem Value="3">Repair</asp:ListItem>
                                           </asp:DropDownList>
                                    </td>
                                  
                                </tr>
                            <tr>
                                     <td class="column_RightBold" style="width:15%"> Returned by :
                                       </td>
                                    <td class="column_LeftBold" style="width:35%">
                                           <asp:DropDownList ID="drpReturnedby" runat="server" Width="95%"></asp:DropDownList>
                                    </td>
                                   <td class="column_RightBold" style="width:15%">  Returned to :
                                       
                                   </td>
                                    <td class="column_LeftBold" style="width:35%">
                                          <asp:DropDownList ID="drpReturnedto" runat="server" Width="95%" OnSelectedIndexChanged="drpGenAccnt_SelectedIndexChanged"></asp:DropDownList>                                              
                                    </td>
                                </tr>
                            <tr>
                                     <td class="column_RightBold" style="width:15%"> Designation :
                                       </td>
                                    <td class="column_LeftBold" style="width:35%">
                                           <asp:DropDownList ID="drpDesignationby" runat="server" Width="95%"></asp:DropDownList>
                                    </td>
                                   <td class="column_RightBold" style="width:15%">  Designation :
                                       
                                   </td>
                                    <td class="column_LeftBold" style="width:35%">
                                          <asp:DropDownList ID="drpDesignationto" runat="server" Width="95%" OnSelectedIndexChanged="drpGenAccnt_SelectedIndexChanged"></asp:DropDownList>                                              
                                    </td>
                                </tr>
                            <tr>
                                     <td class="column_RightBold" style="width:15%"> Remarks :
                                       </td>
                                    <td class="column_LeftBold" style="width:35%">
                                              <asp:TextBox ID="txtRemarks" runat="server" Width="90%" TextMode="MultiLine" Rows ="2"></asp:TextBox>
                                  </td>
                                   
                                </tr>
                           
                            </table>
                        </td>
                        <td style="width: 1%"> </td>
                    </tr>
                    <tr>
                         <td style="width: 1%"></td>
                        <td style="width: 98%" >
                                <asp:Button ID="btnSave" runat="server" Width="150px" CssClass="CSButton" Text="SAVE"  OnClientClick="StartProgressBar();" OnClick="btnSave_Click"></asp:Button>
                     &nbsp;
                                     <asp:Button ID="btnPreview" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW"  OnClientClick="StartProgressBar();"></asp:Button>
                     
                             </td>
                        <td style="width: 1%"> </td>
                    </tr>
                     <tr>
                           <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">LIST OF PROPERTY RETURN SLIP
                        </td>
                        <td style="width: 1%"> </td>
                    </tr>
                      <tr>
                           <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <asp:Button ID="btnViewPending" runat="server" Width="180px" CssClass="Initial" Text="PENDING"  Visible="true" OnClick="btnViewPending_Click" ></asp:Button>
                            <asp:Button ID="btnViewApproved" runat="server" Width="180px" CssClass="Initial" Text="APPROVED" OnClick="btnViewApproved_Click" ></asp:Button>
                            <asp:Button ID="btnViewDisApproved" runat="server" Width="180px" CssClass="Initial" Text="DISAPPROVED" OnClick="btnViewDisApproved_Click" ></asp:Button>
                       
                        </td>
                        <td style="width: 1%"> </td>
                    </tr>
                      <tr>
                           <td style="width: 1%"></td>
                        <td style="width: 98%" >
                            <asp:MultiView ID="mvPropertyReturnSlips" runat="server">
                                <asp:View ID="vwPending" runat="server">
                                      <asp:GridView ID="grdPendingPRS" runat="server" Width="98%" SkinID="GridViewAA" 
                                          EmptyDataText="No Data Found." HorizontalAlign="Center">
                                                    <Columns>
                                                        <asp:BoundField DataField="PRSDate" HeaderText="PRS Date" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ReturnedBy" HeaderText="Returned By" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                       <asp:BoundField DataField="Returnedto" HeaderText="Returned To" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Right" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                        
                                </asp:View>
                                 <asp:View ID="vwApproved" runat="server">
                                            <asp:GridView ID="grdApprovedPRS" runat="server" Width="98%" SkinID="GridViewAA" 
                                          EmptyDataText="No Data Found." HorizontalAlign="Center">
                                                    <Columns>
                                                        <asp:BoundField DataField="PRSDate" HeaderText="PRS Date" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ReturnedBy" HeaderText="Returned By" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                       <asp:BoundField DataField="Returnedto" HeaderText="Returned To" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Right" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                      
                                </asp:View>
                                 <asp:View ID="vwDisapproved" runat="server">
                                               <asp:GridView ID="grdDisApprovedPRS" runat="server" Width="98%" SkinID="GridViewAA" 
                                          EmptyDataText="No Data Found." HorizontalAlign="Center">
                                                    <Columns>
                                                        <asp:BoundField DataField="PRSDate" HeaderText="PRS Date" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ReturnedBy" HeaderText="Returned By" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                       <asp:BoundField DataField="Returnedto" HeaderText="Returned To" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Right" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                       
                                
                                </asp:View>

                            </asp:MultiView>
                        </td>
                        <td style="width: 1%"> </td>
                    </tr>
                    </tr>

                    </table>

              </div>
             </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

