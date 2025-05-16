<%@ Page Title="APPROVAL OFFICERS" StylesheetTheme="SkinFile" Language="VB" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeFile="t_Approval.aspx.vb" Inherits="filemaintenance_t_Approval"   EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">


</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManagerStock" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">  
          <ContentTemplate>
                <div>
     <table width="1020px">
                      <tr >
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle"><strong>APPROVAL OFFICERS</strong> 
                        </td>
                        <td style="width: 1%"></td>
                      </tr>
         <tr>

              <td style="width: 1%"></td>
              <td style="width: 98%" >
                  <table>
                      <tr>
                        <td class="column_RightBold">
                            Full Name:
                         </td>
                         <td class="column_left">
                             <asp:TextBox ID="txtApproveName" runat="server"></asp:TextBox>
                         </td>
                          <td class="column_RightBold">
                            Position:
                         </td>
                         <td class="column_left">
                            <asp:TextBox ID="txtApprovePosition" runat="server"></asp:TextBox>
                          </td>
                         
                      </tr>
                       
                       <tr>
                        <td class="column_RightBold">
                            Password:
                         </td>
                         <td class="column_left">
                               <asp:TextBox ID="txtApprovePwd" runat="server" TextMode="Password"></asp:TextBox>
                         </td>
                            <td class="column_RightBold">
                            Confirm Password:
                         </td>
                         <td class="column_left">
                               <asp:TextBox ID="txtApproveConfirmPwd" runat="server" TextMode="Password"></asp:TextBox>
                         </td>
                           <td>
                               <asp:Button id="btnSave" runat="server"  CssClass="CSButton" Width="120px" Text="Save" OnClick="btnSave_Click"/>
                           </td>
                      </tr>
                      <tr>
                          <td colspan="4" style="height: 23px">
                                   <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtApprovePwd" ControlToValidate="txtApproveConfirmPwd" ErrorMessage="Passwords Do Not Match" ValidationGroup="insertofficer"></asp:CompareValidator>
                          
                          </td>
                      </tr>
                  </table>
              </td>
              <td style="width: 1%"></td>
            
             
         </tr>
                        <tr >
                        <td style="width: 1%"></td>
                        <td style="width: 98%" >
                            <asp:GridView ID="GridView1" runat="server" SkinID="GridViewAA">
                                <Columns>
                                    <asp:BoundField Datafield="Full_name"  HeaderText="Full Name" >
                                    <HeaderStyle HorizontalAlign="Center" Height="30px" Width="75%"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField Datafield="nposition"  HeaderText="Position" ControlStyle-Width ="25%"/>
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

