<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Sitepage.aspx.vb" Inherits="Sitepage" title="SMSS_Cagayan_Site Maintenance" MaintainScrollPositionOnPostback="true" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

<asp:UpdatePanel id="UpdatePanel1" runat="server">   

            <Triggers>
            <asp:PostBackTrigger ControlID="button1" />
            <asp:PostBackTrigger ControlID="button2" />
        </Triggers>
<contenttemplate>
    <body>
    <table> 
    <tr>
    <td style="width: 1020px; height: 21px; text-align: center" colspan="3"> 
    <asp:GridView ID="grdLGU" runat="server" OnRowDataBound="OnRowDataBound" SkinID="GridViewAA" Width="100%"
                                EmptyDataText="No Data found." DataKeyNames="SiteID" AutoGenerateColumns="False">
                                <EmptyDataRowStyle Font-Bold="False"></EmptyDataRowStyle>
                                <Columns>
                                    <asp:CommandField SelectText="Select" ShowSelectButton="True">
                                        <ControlStyle Width="50px"></ControlStyle>
                                        <HeaderStyle Height="20px" Width="50px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                    </asp:CommandField>
                                    <asp:BoundField DataField="SiteName" HeaderText="SiteName" Visible="True">
                                    </asp:BoundField>
<%--                                    <asp:BoundField DataField="IsDefault" HeaderText="IsDefault" Visible="True">
                                    </asp:BoundField>--%>                                
                                    <asp:BoundField DataField="Description" HeaderText="Description Name">
             <%--                           <ControlStyle Width="200px"></ControlStyle>
                                        <HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>--%>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Province" HeaderText="Province Name">
                                    
                                     </asp:BoundField>
                                     <asp:BoundField DataField="City_Name" HeaderText="City Name">

                                    </asp:BoundField>
                                     <asp:BoundField DataField="Address" HeaderText="Address">
                  
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Image">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" Width="70px" height ="70px"/>
                <ControlStyle Width="50px"></ControlStyle>
                 <ItemStyle HorizontalAlign="Left" Width="50px" height ="50px"></ItemStyle>
            </ItemTemplate>
        </asp:TemplateField>
                                    <asp:BoundField DataField="logo" HeaderText="logo" Visible="False">
                                      <ControlStyle Width="200px"></ControlStyle>
                                        <HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
                                    </asp:BoundField >

 
<%--                                    <asp:TemplateField HeaderText="Image">
                                    <ItemTemplate>
 <asp:Image ID="image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID=" + Eval("imageid") %>' Height="150px" Width="150px"/>
</ItemTemplate>
                                    </asp:TemplateField>--%>
 
                                </Columns>
                            </asp:GridView>
                            </td>
                             </tr>
                                
                             
                                        <table  style="width: 97%; text-align: center">

                                        <tr>
                                        <td  style="width: 30%; text-align: center;" class="column_Left"> Attached Logo :
                                            <asp:FileUpload ID="FileUpload1" runat="server" ClientIDMode="Inherit" CssClass="CSButton" ViewStateMode="Inherit" cs Width="25%" />
                                            <asp:Button ID="UploadButton" runat="server" CssClass="CSButton" OnClick="UploadButton_Click" Text="UPLOAD FILE" Visible="False" Width="15%" />
                                            <input id="labelszx" type="text" runat="server" visible="false" />
                                        
                                        </td>
                                            <tr style="width: 97%; text-align: center">
                                                <td style="width: 30%">Site Name:
                                                    <asp:TextBox ID="TextBox3" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                                
                                            </tr>
                                            <tr style="width: 97%; text-align: center">
                                                <td style="width: 30%">LGU Name:
                                                    <asp:TextBox ID="TextBox1" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                              
                                            </tr>
                                            <tr style="width: 97%; text-align: center">
                                                <td style="width: 30%">Province:
                                                    <asp:TextBox ID="TextBox2" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>

                                                
                                            </tr>
                                            <tr>
                                                <td>
                                                    City Name :
                                                    <asp:TextBox ID="txtCityName" runat="server" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Address :
                                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <%--                               <tr style="width: 97%; text-align: center">
                                        <td  style="width: 30%"> is Default:
                                        <asp:CheckBox
                                            ID="CheckBox1" runat="server" />
                                        </td>
                                        </br>
                                        </tr>--%>
                                            <tr style="width: 97%; text-align: center">
                                                <td style="width: 30%">
                                                    <asp:Button ID="Button1" runat="server" CssClass="CSButton" Text="Update" width="7%" />
                                                    <asp:Button ID="Button2" runat="server" Text="Save" Visible="False" width="7%" />
                                                </td>
                                                
                                            </tr>
                                        </tr>
                                        </table>
                                        <br>
        <br></br>
        <br>
        <br></br>
        </br>
                                        </br>


                            </table>
                            </body>
    </contenttemplate>
</asp:UpdatePanel>


</asp:Content>

