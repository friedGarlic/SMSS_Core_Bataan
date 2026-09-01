<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="fm_Brgy.aspx.vb" Inherits="filemaintenance_fm_Brgy" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">





</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>


         <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">BARANGAY</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                    <td style="width:1%"></td>
                     <td style="width: 98%" align="right">
                        <span  class="column_RightBold"> Date :
                        </span>
                         &nbsp;
                    <asp:TextBox ID="txtDate" runat="server" Width="89px" CssClass="txtbox_Date" Enabled="False"></asp:TextBox>
                         </td>
                    <td style="width:1%"></td>
                    </tr>
                    </table>

                    <table width="1020px">
                        <tr>
                          <td style="width: 30%" class="column_RightBold" >Municipal Name:</td>
                            <td style="width: 5%" align="left" class="column_leftBold">
                               
                            <asp:DropDownList ID="DDMunicipal"  runat="server" Width="150px" CssClass="drpdownCSS" Height="22px">
                              
                              
                            </asp:DropDownList>
                              </td>
                        </tr>
                        <tr >

                           
                            <td style="width: 30%" class="column_RightBold" >Barangay Name:</td>
                                    <td style="width: 10% "class="column_LeftBold" >
                                     <asp:TextBox stye="width:10px" ID="TxtBrgyName" runat="server" Width="351px"  Enabled="True"></asp:TextBox>
                                    </td>
                        </tr>
                      
                      
                      

                         <tr>
                             <td style="width:1%"></td>
                            <td style="width: 50%"  class="column_RightBold">
                                
                                 <asp:Button ID="btnadd" runat="server" Width="78px"  CssClass="CSButton" CausesValidation="False" Text="SAVE" OnClick="btnadd_Click"></asp:Button>

                                 <asp:Button ID="btncancel" runat="server" Width="78px"  CssClass="CSButton" CausesValidation="False" Text="CANCEL" OnClick="btncancel_Click"></asp:Button>
                            </td>
                              <td style="width: 50%"  class="column_RightBold">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;</td>
                        </tr>

                        </table>
        <table width="1020px">
                        <tr>
                        <td style="width: 1%" ></td>
                        <td style="width: 98%" class="DivTitle">LIST OF BARANGAY</td>
                        <td style="width: 1%"></td>
                       </tr>
                

              <tr>
                      
                       <td style="width: 1%" class="column_RightBold"></td>
                       <td style="width: 98%" align="center" >Search:
                            <asp:DropDownList ID="ddSearch" runat="server" Width="100px" CssClass="drpdownCSS">
                                <asp:ListItem Selected="True" Value="1">Brgy Name</asp:ListItem>
                              <asp:ListItem Selected="false" Value="2">Municipal Name</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="txtsearchBrgy" runat="server" Width="30%" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnsearch" runat="server" Width="150px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();" OnClick="btnsearch_Click"></asp:Button>
                            <asp:Button ID="bntcopyPerGrid" runat="server" Width="100px" Text="Copy Previous Value" Visible="False" Height="25px"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                           
                    </tr>

            <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <asp:GridView ID="GvBrgy" runat="server" Width="98%" 
                                     SkinID="GridViewAA" EmptyDataText="No Records Found"
                                    DataKeyNames="Brgy_ID,Brgy_Name,Municipal_ID,Municipal_Name" AllowPaging="True" PageSize="9" OnSelectedIndexChanged="GvBrgy_SelectedIndexChanged" OnPageIndexChanging="GvBrgy_PageIndexChanging">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" Width="40%" CssClass="LinkBtnSelect" ForeColor="#2977dc"></ItemStyle>
                                        </asp:CommandField>    
                                        <asp:BoundField DataField="Brgy_ID" Visible="false" HeaderText="Brgy_ID">
                                            <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                        
                                        <asp:BoundField DataField="Brgy_Name" HeaderText="Barangay Name">
                                            <ItemStyle HorizontalAlign="Left" Width="45%"></ItemStyle>
                                             </asp:BoundField>
                                       
                                        <asp:BoundField DataField="Municipal_Name" HeaderText="Municipal Name">
                                            <ItemStyle HorizontalAlign="Left" Width="45%"></ItemStyle>
                                             </asp:BoundField>
                                        
                                       <%--<asp:BoundField DataField="ForDBM" HeaderText="For DBM">
                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        </asp:BoundField>--%>
                                    </Columns>
                                </asp:GridView>
                             
                                
                                <div>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>










                    </table>

                    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>