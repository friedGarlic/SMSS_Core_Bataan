<%@ Page Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="t_ppmp_manage.aspx.vb"
    Inherits="planning_t_ppmp_manage" Title="MANAGE PPMP" StylesheetTheme="SkinFile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">



</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>




            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">MANAGE PPMP
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="70%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Calendar Year :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddYear" runat="server" Width="30%" CssClass="drpdownCSS" AutoPostBack="True"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Department :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddDepartments" runat="server" Width="70%" CssClass="drpdownCSS" AutoPostBack="True" Enabled="False"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">P / P / A :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddPPA" runat="server" Width="70%" CssClass="drpdownCSS" AutoPostBack="True" Enabled="False"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List Of General Accounts
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView  ID="gvAccount" runat="server" Width="98%" BorderStyle="Solid" DataKeyNames="Ga_title,Status,ga_id,bga_id,isforRevision,enable,rc_id,Function_id,Project_ID,Program_id,isRepair" 
                                AutoGenerateColumns="False" AllowPaging="True" SkinID="GridViewAA" OnPageIndexChanging="gvAccount_PageIndexChanging">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PageButtonCount="5" PreviousPageText="Previous"></PagerSettings>
                                <Columns>
                                    <asp:BoundField DataField="Ga_title" HeaderText="ACCOUNT TITLE">
                                        <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Status" HeaderText="STATUS">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="REVISE">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click1" runat="server" ImageUrl="~/images/Edited Image/Active_Pencil.jpg" Enabled='<%#Bind("enable") %>' CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" Visible='<%# bind("enable") %>'></asp:ImageButton><asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/Edited Image/Inactive_Pencil.jpg" Enabled='<%#Bind("isforRevision") %>' Visible='<%# bind("isforRevision") %>'></asp:ImageButton><asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/images/Edited Image/Inactive_Pencil.jpg" Visible='<%#Bind("isRepair") %>'></asp:ImageButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="LOCKED">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" OnClick="ImageButton2_Click" runat="server" ImageUrl="~/images/Edited Image/Active_Locked.jpg" Enabled='<%#Bind("isforRevision") %>' CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" Visible='<%# bind("isforRevision") %>'></asp:ImageButton><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/Edited Image/Inactive_Locked.jpg" Enabled='<%#Bind("enable") %>' Visible='<%# bind("enable") %>'></asp:ImageButton><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/Edited Image/Inactive_Locked.jpg" Enabled='<%#Bind("isRepair") %>' Visible='<%# bind("isRepair") %>'></asp:ImageButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle HorizontalAlign="Center" BackColor="#2977DC"></FooterStyle>

                                <PagerStyle HorizontalAlign="Center"></PagerStyle>

                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
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
                        <td style="width: 98%">
                            <asp:HiddenField ID="lblClass" runat="server" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>


            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblClass" PopupControlID="Panel2" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Panel ID="Panel2" runat="server" Width="350px" CssClass="Panel_Popup">
                  <table width="100%">
                      <tr>
                         <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">
                             APPROVAL
                          </td>
                      </tr>
                      <tr>      
                          <td class="column_RightBold">
                              Approving Officer :
                            </td>
                          <td class="column_Left">
                              <asp:DropDownList id="drpApprovedOfficer" runat="server" Width="150px" CssClass="ddropbox"></asp:DropDownList>
                          </td>
                      </tr>
                       <tr>      
                          <td class="column_RightBold">
                              Password :
                            </td>
                          <td class="column_Left">
                             <asp:TextBox ID="txtApprovedPass" runat ="server" CssClass="txtbox_Var" Width="150px" TextMode="Password"></asp:TextBox>

                          </td>
                      </tr>
                      <tr>
                          <td colspan="3">
                        <asp:Button ID="Button1" OnClick="Button1_Click"  runat="server" Width="150px" CssClass="CSButton" Text="PROCEED"></asp:Button>
                    
                        <asp:Button ID="Button2" OnClick="Button2_Click"  runat="server" Width="150px" CssClass="CSButton" Text="CANCEL"></asp:Button>
                    </td>
                      </tr>
                  </table>
                  
                  </asp:Panel>


        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
