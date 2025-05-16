<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="fm_warehouse.aspx.vb" Inherits="filemaintenance_fm_warehouse" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">WAREHOUSE</td>
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
                            <td style="width: 30%" class="column_RightBold">Warehouse Name:</td>
                                    <td style="width: 80%" class="column_Left">
                                     <asp:TextBox stye="width:100px" ID="TxtWareHouse" runat="server" Width="351px"  Enabled="True"></asp:TextBox>
                                    </td>
                        </tr>
                        <tr>
                            <td style="width: 30%" class="column_RightBold">Code:</td>
                                    <td style="width: 80%" class="column_Left">
                                     <asp:TextBox stye="width:100px" ID="TxtCode" runat="server" Width="144px"  Enabled="True"></asp:TextBox>
                                    </td>
                        </tr>
                      <tr>
                            <td style="width: 30%" class="column_RightBold">Address:</td>
                                    <td style="width: 80%" class="column_Left">
                                     <asp:TextBox stye="width:100px" ID="TxtAddress" runat="server" Width="351px"  Enabled="True"></asp:TextBox>
                                    </td>
                        </tr>

                         <tr>
                             <td style="width:1%"></td>
                            <td style="width: 90%"  class="column_RightBold">
                                
                                 <asp:Button ID="btnadd" runat="server" Width="78px"  CssClass="CSButton" CausesValidation="False" Text="SAVE" OnClick="btnadd_Click"></asp:Button>

                                 <asp:Button ID="btncancel" runat="server" Width="78px"  CssClass="CSButton" CausesValidation="False" Text="CANCEL" OnClick="btncancel_Click"></asp:Button>
                            </td>
                              <td style="width: 50%"  class="column_RightBold">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;</td>
                        </tr>

                        </table>
        <table width="1020px">
                        <tr>
                        <td style="width: 1%" ></td>
                        <td style="width: 98%" class="DivTitle">LIST OF WAREHOUSE</td>
                        <td style="width: 1%"></td>
                       </tr>
                

              <tr>
                      
                       <td style="width: 1%" class="column_RightBold"></td>
                       <td style="width: 98%" align="center" >Search:
                            <asp:DropDownList ID="ddSearch" runat="server" Width="100px" Visible="false" CssClass="drpdownCSS">
                                <asp:ListItem Selected="True" Value="1">Warehouse Name</asp:ListItem>
                                <asp:ListItem Value="2">Code</asp:ListItem>
                                <asp:ListItem Value="3">Address</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="txtsearchWarehouse" runat="server" Width="30%" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnsearch" runat="server" Width="150px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();" OnClick="btnsearch_Click"></asp:Button>
                            <asp:Button ID="bntcopyPerGrid" runat="server" Width="100px" Text="Copy Previous Value" Visible="False" Height="25px"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                           
                    </tr>

            <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <asp:GridView ID="GvWarehouse" runat="server" Width="98%" 
                                     SkinID="GridViewAA" EmptyDataText="No Records Found"
                                    DataKeyNames="Warehouse_ID,wCode,wName,wAddress" AllowPaging="True" PageSize="9" OnSelectedIndexChanged="GvWarehouse_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Hide?" ShowHeader="False">                                                    <ItemTemplate >                                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" Checked='<%# Bind("isUsed") %>' ></asp:CheckBox>                                                    </ItemTemplate>                                                    <ItemStyle HorizontalAlign="Center" Width="10px"></ItemStyle>                                                </asp:TemplateField>

                                        <asp:CommandField ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="LinkBtnSelect" ForeColor="#2977dc"></ItemStyle>
                                        </asp:CommandField>    
                                        <asp:BoundField DataField="Warehouse_ID" Visible="false" HeaderText="WarehouseID">
                                            <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                        </asp:BoundField>
                                         <asp:BoundField DataField="wCode" HeaderText="Code">
                                            <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="wName" HeaderText="Warehouse Name">
                                            <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                             </asp:BoundField>
                                       
                                        <asp:BoundField DataField="wAddress" HeaderText="Address">
                                            <ItemStyle HorizontalAlign="Center" Width="65%"></ItemStyle>
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