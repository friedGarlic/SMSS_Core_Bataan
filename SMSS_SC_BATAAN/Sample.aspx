<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Sample.aspx.vb" Inherits="Sample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  

      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  
</asp:UpdatePanel>



<%--    
<h2>align-items: flex-start</h2>

<div id="main">
 
 
</div>
--%>
    <div>
    <table >
        <tr>
            <td colspan="4">
                  <div id="lazada">
     <asp:ListView ID="ListView1" runat="server" GroupItemCount="4" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1">
                    <EmptyDataTemplate>
                       
                    </EmptyDataTemplate>
                    <LayoutTemplate>
                       
                            <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                       
                    </LayoutTemplate>
                    <GroupTemplate>
                     
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                     
                    </GroupTemplate>
                    <ItemTemplate>
                            <div class="card">
                                <div >
                                  <table width="100%" style="border:1px solid #6F8FAF" >
                                        <tr>
                                            <td class="DivTitle">
                                                 <asp:Label ID="Label2" runat="server" Text='<%#Eval("ProductName")%>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                   <asp:Image ID="Image1" style=" height: 75px;width: 50px;border: 1px solid #ddd;  border-radius: 4px;  padding: 5px; " runat="server" ImageUrl='<%#Eval("image") %>' AlternateText='<%# Eval("image") %>' ToolTip='<%# Eval("image")  %>' />
                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                     <asp:Label ID="Label1" runat="server" Text='<%#Eval("Price")%>' CssClass="txtboxAmount"></asp:Label>
                               
                                            </td>
                                        </tr>
                                    </table>
                                   </div>
                            </div>
                  
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                          <div class="card">
                              <table width="100%">
                                        <tr>
                                            <td>
                                                 <asp:Label ID="Label2" runat="server" Text='<%#Eval("ProductName")%>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                             <asp:Image ID="Image1" style=" height: 150px;width: 100px;border: 1px solid #ddd;  border-radius: 4px;  padding: 5px;  width: 150px;" runat="server" ImageUrl='<%#Eval("image") %>' AlternateText='<%# Eval("image") %>' ToolTip='<%# Eval("image")  %>' />
                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                     <asp:Label ID="Label1" runat="server" Text='<%#Eval("Price")%>'></asp:Label>
                               
                                            </td>
                                        </tr>
                                    </table>                
                            </div>
                    </AlternatingItemTemplate>
                </asp:ListView>
        </div>
            </td>
        </tr>
    </table>
     </div>
    <asp:GridView ID="grdPropertyInfo" runat="server" SkinID="gvnew" AutoGenerateColumns="false"
                            EmptyDataText="No records has been added."  Width="300px" OnRowDataBound="grdPropertyInfo_RowDataBound"><%----%>
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width ="50px">
                                        <ItemTemplate>
                                            
                                            <asp:CheckBox id="cbPI" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Property Number" >
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtPropertyNo" runat ="server" Width ="200px"  onchange="return calculateCurrent(this);"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width ="19%" HeaderText="Department" Visible="false" >
                                        <ItemTemplate>
                                            
                                       <asp:DropDownList ID="drpDepartment" runat="server" Width ="300px" ></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width ="19%" HeaderText="Accountable Person" >
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtAccountablePerson" runat ="server"  Width ="200px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width ="19%" HeaderText="Floor Location"   >
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtPIFloorLocation" runat ="server"  Width ="100px" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width ="50%" HeaderText="Room"   Visible="false">
                                        <ItemTemplate>
                                            
                                         <asp:TextBox ID="txtPIRoom" runat ="server"  Width ="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  </Columns>
                            </asp:GridView>

<%--    <ul class="thumbnail-list">
  <li><img src="http://placekitten.com/200/200" alt=""></li>
  <li><img src="http://placekitten.com/200/200" alt=""></li>
  <li><img src="http://placekitten.com/200/200" alt=""></li>
  <li><img src="http://placekitten.com/200/200" alt=""></li>
  <li><img src="http://placekitten.com/200/200" alt=""></li>
  <li><img src="http://placekitten.com/200/200" alt=""></li>
  <li><img src="http://placekitten.com/200/200" alt=""></li>
  <li><img src="http://placekitten.com/200/200" alt=""></li>
</ul>--%>
     <script type="text/javascript">
         function calculateCurrent(current) {
         //var val = $("[id$='" + rel.id + "']").val();
             let text = current.id
             const myArray = text.split("_", 5);
             let word = myArray[0] + "_" + myArray[1] + "_" + myArray[2] + "_" + myArray[3];
             var x = parseInt(document.getElementById(word + "_txtAccountablePerson").value);
            var y =   parseInt(document.getElementById(current.id).value);
             var sum = x * y;
             document.getElementById(word + "_txtPIFloorLocation").value = sum
             alert(sum);
         }
          
        

</script>
</asp:Content>

