<%@ Page 
    Language="VB" 
    AutoEventWireup="false" 
    MasterPageFile="~/MasterPage.master"
    CodeFile="t_Capital_outlay.aspx.vb" 
    Inherits="t_Capital_outlay"
    Title="FM CAPITAL OUTLAY" 
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">


</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">




          function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                        .width(240)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }

</script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <Triggers>
        <asp:PostBackTrigger ControlID="btnsave" />
        </Triggers>
        <ContentTemplate>


            <div>
                <table width="100%">
                    <tr>
                        
                        <td style="width: 105%; height: 26px;" class="PageTitle" colspan="2">FM - CAPITAL OUTLAY</td>
                        <%--<td style="width: 1%; height: 26px;"></td>--%>
                    </tr>
                    <tr>
                        <td style="width: 105%"></td>
                        <td style="width: 98%" align="center">
                             <tr>
                                    <td align="center" style="width: 105%; height: 19px;" class="ColumnHeader_C">ITEMS DETAILS:</td>
                                    <td align="center" style="width: 20%; height: 19px;" class="ColumnHeader_C">ITEM IMAGE</td>
                                </tr>
                            <tr>
                                 <td align="center" style="vertical-align: top; width: 105%; height: 180px" class="panel_border">
                            <table width="95%">
                             
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Calendar Year :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddyear" runat="server" Width="100px" CssClass="drpdownCSS" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                        </asp:DropDownList>


                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Classification :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="drpclass" runat="server" Width="200px" CssClass="drpdownCSS" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="drpclass_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:LinkButton Style="font-family: 'Arial'" Font-Size="9pt" ID="LinkButton4" runat="server" Visible="false" Width="150px" Text="New Classification" OnClick="LinkButton4_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                                <asp:HiddenField ID="hdnItemSubClass" runat="server" />
                                <asp:HiddenField ID="hdnGAId" runat="server" />
                                <asp:HiddenField ID="hdnItemID" runat="server" />

                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Sub Classification :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="DrpSubClass" runat="server" Width="200px" CssClass="drpdownCSS" AppendDataBoundItems="True" AutoPostBack="True"  OnSelectedIndexChanged="DrpClassSub_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:LinkButton Style="font-family: 'Arial'" Font-Size="9pt" ID="LinkButton6" runat="server" Width="150px" Text="New Sub Classification" OnClick="LinkButton6_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">General Account :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="GenAccnt" runat="server" Width="374px" CssClass="drpdownCSS" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="GenAccnt_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>


                                    <asp:TextBox ID="txtcode" runat="server" Width="100%" CssClass="txtbox_Var" ReadOnly="True" Visible="false"></asp:TextBox>
                                    <caption>
                                        &nbsp;<asp:Button ID="Button1" runat="server" CssClass="CSButton" Text="SELECT" Visible="false" Width="0px" />
                                    </caption>

                                </tr>
                                <tr>

                                    <asp:TextBox ID="txttitle" runat="server" Width="70%" CssClass="txtbox_Var" ReadOnly="True" Visible="false"></asp:TextBox>

                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Category : <spam style="color:red">*</spam></td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddParticular" runat="server" Width="50%" CssClass="drpdownCSS" AutoPostBack="True">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<asp:LinkButton ID="btnaddP" runat="server" Width="150px" CssClass="CSButton" Text="New Category" Enabled="False" OnClick="btnaddP_Click"></asp:LinkButton>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddParticular" ErrorMessage="*" ValidationGroup="saveS" InitialValue="0">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Sub Category :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddSubCategory" runat="server" Width="50%" CssClass="drpdownCSS" AutoPostBack="True">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<asp:LinkButton ID="Button2" runat="server" Width="150px" CssClass="CSButton" Text="New Sub Category" Enabled="False" OnClick="Button2_Click"></asp:LinkButton>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddParticular" ErrorMessage="*" ValidationGroup="saveS" InitialValue="0">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr id="GenName" runat="server">
                                    <td style="width: 15%" class="column_RightBold">Generic Name:</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="TextBoxGen" runat="server" Width="150px" AutoPostBack="True" Enabled="false" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="display:none">

                                    <td style="width: 20%" class="column_RightBold">Brand :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="TextBoxBrand" runat="server" Width="150px" AutoPostBack="True" Enabled="true" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="display:none">
                                    <td style="width: 20%" class="column_RightBold">Color :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="TextBoxColor" runat="server" Width="150px" AutoPostBack="True" Enabled="true" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="display:none">
                                    <td style="width: 20%" class="column_RightBold">Size :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="TextBoxSize" runat="server" Width="150px" AutoPostBack="True" Enabled="true" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="display:none">
                                    <td style="width: 20%" class="column_RightBold">Dep. Rate :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="TextBoxDeptRate" runat="server" Width="150px" AutoPostBack="True" Enabled="true" CssClass="txtbox_Var"></asp:TextBox>%
                                    </td>
                                </tr>
                                <tr style="display:none">
                                    <td style="width: 20%" class="column_RightBold">Dep. Year :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="TextBoxDeptYear" runat="server" Width="150px" AutoPostBack="True" Enabled="true" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Item Description :</td>
                                    <td style="width: 80%" class="column_Left">

                                        <asp:TextBox ID="txtdescription" runat="server" Width="50%" CssClass="txtbox_Remarks" TextMode="MultiLine" AutoPostBack="True" OnTextChanged="txtdescription_TextChanged"></asp:TextBox>
                                        <asp:Label ID="lblmsg" runat="server" Font-Bold="False" ForeColor="Red" Font-Size="8pt" Font-Names="Tahoma" Text="* Item description already exist." Visible="False" Font-Italic="True"></asp:Label>
                                        <asp:Image ID="imgCheck" runat="server" ImageUrl="~/images/check.jpg" Visible="False" Height="15px"></asp:Image>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdescription" ErrorMessage="*" ValidationGroup="saveS"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Unit :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddUnit" runat="server" Width="20%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddUnit_SelectedIndexChanged">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddUnit" ErrorMessage="*" ValidationGroup="saveS" InitialValue="0">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Item Code :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="txtItemCode" runat="server" Width="20%" CssClass="txtbox_Var" OnTextChanged="txtItemCode_TextChanged"></asp:TextBox>
                                        <asp:Label ID="Label4" runat="server" Font-Bold="False" ForeColor="Red" Font-Size="8pt" Font-Names="Tahoma" Text="* Item code already exist." Visible="False" Font-Italic="True"></asp:Label>
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/check.jpg" Visible="False" Height="15px"></asp:Image>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Unit Price :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox Style="text-align: right" ID="txtprice" runat="server" Width="20%" CssClass="txtbox_Amt" AutoPostBack="True" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);" >
                                            <asp:ListItem>0.00</asp:ListItem>
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtprice" ErrorMessage="*" ValidationGroup="saveS" InitialValue="0.00"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtRpt" runat="server" Width="200px" Enabled="False" Visible="False" CssClass="txtboxinspection"></asp:TextBox>
                                    </td>
                                </tr>

                                
                            </table>


                                       <td align="center" style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; vertical-align: top; border-left: royalblue 1px solid; width: 25%; border-bottom: royalblue 1px solid; height: 150PX">
                                        <table style="width: 100%">
                                            <tbody>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Image ID="Image1"  runat="server" Height="150px" ImageUrl="~/images/blankImage.jpg" Width="170px" />
                                                        <asp:Label ID="lblNoti" runat="server" Font-Names="Calibri" Font-Size="9pt" ForeColor="Red" Text="* No file to upload." Visible="False"></asp:Label>
                                                        <asp:FileUpload type="file"  onchange="return ShowImagePreview(this)" ID="FileUpload1" Enabled="false" runat="server" Width="88px" />
                                                        <asp:TextBox ID="Attched" runat="server" Visible="false" Height="24px"></asp:TextBox>
                                                        <asp:TextBox ID="AttachedF" runat="server" Visible="false"></asp:TextBox>
                                                    </td>
                                                    
                                                </tr>
                                            </tbody>
                                        </table>

                                    </td>
                                    </td>
                                </tr>
                        
                         
                            
                            <tr>
                                <td style="width: 105%"></td>
                                <table width="100%">
                                <tr>
                                <td align="center" style="width: 98%">
                                    <asp:Button ID="btnadd" runat="server" CausesValidation="False" CssClass="CSButton" Text="ADD" Width="150px" />
                                    &nbsp;<asp:Button ID="btnedit" runat="server" CssClass="CSButton" Text="EDIT" Width="150px" />
                                    &nbsp;<asp:Button ID="btnsave" runat="server"  CssClass="CSButton" OnClientClick="StartProgressBar();"   Text ="SAVE"  Width="150px" />
                                    &nbsp;<asp:Button ID="btncopyall" runat="server" CssClass="CSButton" Enabled="False" Font-Overline="False" OnClick="btncopyall_Click" OnClientClick="StartProgressBar();" Text="Copy All previous price under this Account" Width="300px" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to save this transaction?" Enabled="True" TargetControlID="btnsave">
                                    </cc1:ConfirmButtonExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers" TargetControlID="txtRpt" ValidChars="0123456789">
                                    </cc1:FilteredTextBoxExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtprice" ValidChars="0123456789.,">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:HiddenField ID="HiddenField2" runat="server" />
                                    <asp:HiddenField ID="HiddenField3" runat="server" />
                                </td>
                                <td style="width: 1%"></td>
                                    </td>
                        </tr>
                            </tr>
                            <tr>
                                <td style="width: 1%"></td>
                                <td style="width: 98%; height: 10px"></td>
                                <td style="width: 1%"></td>
                            </tr>
                    <tr>
                        <td align="center" style="width: 101%">
                              <table width="100%">
                                  
                            <tr>
                                <td style="width: 1%"></td>
                                <td class="DivTitle" style="width: 98%">Item List</td>
                                <td style="width: 1%"></td>
                            </tr>
                            <tr>
                                <td style="width: 1%"></td>
                                <td align="center" style="width: 98%">
                                    <asp:DropDownList ID="ddSearch" runat="server" CssClass="drpdownCSS" Width="100px">
                                        <asp:ListItem Selected="True" Value="1">Description</asp:ListItem>
                                        <asp:ListItem Value="2">Item Code</asp:ListItem>
                                        <asp:ListItem Value="3">Category</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;<asp:TextBox ID="txtsearch2" runat="server" CssClass="txtbox_Var" Width="30%"></asp:TextBox>
                                    &nbsp;<asp:Button ID="btnsearch" runat="server" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="SEARCH" Width="150px" />
                                    <asp:Button ID="bntcopyPerGrid" runat="server" Height="25px" OnClick="bntcopyPerGrid_Click" Text="Copy Previous Value" Visible="False" Width="100px" />
                                </td>
                                <td style="width: 1%"></td>
                            </tr>
                            <tr>
                                <td style="width: 1%"></td>
                                <td align="center" style="width: 98%">
                                    <asp:GridView ID="gvstock" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="particulardesc,
                                        detail,
                                        UnitDesc,
                                        price1,
                                        Item_ID,
                                        item_particular_id,
                                        Unit_ID,
                                        itemdesc,
                                        SubCategoryID,
                                        SubCat_desc,isused,price2,price,Item_Code,Brand,Color,Size,SubClassificationName,SubClassificationID,GenericName" EmptyDataText="No Data Found." OnPageIndexChanging="gvstock_PageIndexChanging" OnSelectedIndexChanged="gvstock_SelectedIndexChanged" PageSize="15" SkinID="GridViewAA" Width="98%">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True">
                                            <ItemStyle CssClass="LinkBtnSelect" Font-Underline="false" ForeColor="Blue" HorizontalAlign="Center" Width="5%" />
                                            </asp:CommandField>
                                            <asp:TemplateField HeaderText="Hide?">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Checked='<%#Bind("Isused") %>' OnCheckedChanged="CheckBox1_CheckedChanged" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="AccntCode" HeaderText="Account Code">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Item_Code" HeaderText="Item Code">
                                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Particulardesc" HeaderText="DESCRIPTION">
                                            <ItemStyle HorizontalAlign="Left" Width="40%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="detail" HeaderText="DESCRIPTION" Visible="False" />
                                            <asp:BoundField DataField="unitdesc" HeaderText="UNIT">
                                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="price1" HeaderText="CY2021">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="price2" HeaderText="CY2021">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="PRICE 1" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("price1") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblPrevious" runat="server" Font-Bold="True"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("price1", "{0:N}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PRICE 2" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("price2") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblCurrent" runat="server" Font-Bold="True"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("price2", "{0:N}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:BoundField DataField="price1" DataFormatString="{0:N}" HeaderText="PRICE1" HtmlEncode="False">
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                     
                                    <asp:BoundField DataField="price2" DataFormatString="{0:N}" HeaderText="PRICE2">
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>--%>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/delete.png" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton4" runat="server" CommandName="Select" Height="15px" ImageUrl="~/images/delete.png" OnClick="ImageButton4_Click" OnClientClick="StartProgressBar();" />
                                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to delete this item?" TargetControlID="ImageButton4">
                                                    </cc1:ConfirmButtonExtender>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="4%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td style="width: 1%"></td>
                            </tr>
                                  </table>
                                  </td>
                                  </tr>
                            <tr>
                                <td style="width: 1%"></td>
                                <td style="width: 98%"></td>
                                <td style="width: 1%"></td>
                            </tr>
                    </tr>
                </table>
            </div>

            <%--New Sub Category Start--%>
            <asp:Panel ID="NewSubCatModal" runat="server" Width="700px" CssClass="Panel_Popup">
                <div>
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">New Sub Category
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 90%" align="center">
                                <table width="90%">
                                    <tr align="center">
                                        <td style="width: 50%; height: 24px;" class="column_RightBold" align="right">Category Name :</td>
                                        <td style="width: 27%; height: 24px;" class="column_Left">
                                            <asp:TextBox ID="TxtSubCat" runat="server" Width="54%" CssClass="txtbox_Var" align="center"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td style="width: 50%; height: 24px;" class="column_RightBold" align="right">Sub Category Name :</td>
                                        <td style="width: 27%; height: 24px;" class="column_Left">
                                            <asp:TextBox ID="SubCattxt" runat="server" Width="54%" CssClass="txtbox_Var" align="center"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td style="width: 20%" class="column_RightBold" align="center">Useful Life :</td>
                                        <td style="width: 50%" class="column_Left" align="center">
                                            <asp:TextBox ID="TextBoxLife" runat="server" Width="10%" Text="0" CssClass="txtbox_Amt" align="center"></asp:TextBox>
                                            &nbsp;<span class="column_RightBold">No. of Year/s</span>
                                        </td>
                            </td>
                        </tr>

                    </table>
                    </td>
                            <td style="width: 1%"></td>
                    </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <asp:Button ID="gvparticular1" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" ValidationGroup="savenp" OnClientClick="StartProgressBar();" OnClick="btnsaveSubCat_Click"></asp:Button>
                            &nbsp;<asp:Button ID="Button6" OnClick="btnaddparticular_Click" runat="server" Width="120px" CssClass="CSButton" Text="CLEAR"></asp:Button>

                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" Enabled="True" TargetControlID="gvparticular1" ConfirmText="Are you sure you want to save this transaction?">
                            </cc1:ConfirmButtonExtender>

                            <asp:TextBox ID="TextBox7" runat="server" Width="0px" Visible="False"></asp:TextBox>
                            <asp:Button ID="Button8" OnClick="btnaddparticular_Click" runat="server" Width="0px" Visible="False" Text="ADD"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List Of Categories & Sub Categories
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Description :</span>
                            &nbsp;<asp:TextBox ID="TextBox8" runat="server" Width="250px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="Button9" OnClick="Button9_Click" runat="server" Width="120px" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="Gridview2" runat="server" Width="98%" OnSelectedIndexChanged="Gridview2_SelectedIndexChanged"
                                SkinID="GridViewAA" EmptyDataText="No Records Found"
                                DataKeyNames="SubCategoryID,subcat_desc,useful_life" AllowPaging="True" PageSize="9">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="LinkBtnSelect" ForeColor="#2977dc"></ItemStyle>
                                    </asp:CommandField>
                                    <asp:BoundField DataField="description" HeaderText="Category">
                                        <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SubCat_Desc" HeaderText="Sub Category">
                                        <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="useful_life" HeaderText="Useful Life">
                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
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
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <asp:Button runat="server" ID="Button10" Width="120px" CssClass="CSButton" Text="Close" />
                            <asp:Label ID="Label5" runat="server"></asp:Label>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    </table>
                </div>
            </asp:Panel>
            <%--New Sub Category End--%>


            <%--New Classification START--%>
            <asp:Panel ID="PopupClassification" runat="server" Width="700px" CssClass="Panel_Popup">
                <div>
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">New Classification
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 90%" align="center">
                                <table width="90%">
                                    <tr align="center">
                                        <td style="width: 31%; height: 24px;" class="column_RightBold" align="right">Classification :</td>
                                        <td style="width: 27%; height: 24px;" class="column_Left">
                                            <asp:TextBox ID="TxtClassification" runat="server" Width="54%" CssClass="txtbox_Var" align="center"></asp:TextBox>
                                        </td>
                                        <tr id="WSUB" align="center" runat="server">

                                            <td style="width: 31%">

                                                <td style="width: 27%; height: 24px;" class="column_Left">
                                                    <asp:CheckBox ID="WithSubClass" runat="server" AppendDataBoundItems="true" AutoPostBack="true" /><font style="font-family: 'Arial'" size="2"> with Sub Classification</font>
                                                </td>
                                            </td>
                                        </tr>
                                    </tr>
                                    <tr id="GA" align="center" runat="server">
                                        <td style="width: 31%" class="column_RightBold" align="center">General Account :</td>
                                        <td style="width: 50%" class="column_Left" align="center">
                                            <asp:DropDownList ID="DropGA" runat="server" CssClass="drpdownCSS" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="DropGA_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <%--<td style="width: 31%; height: 24px;" class="column_RightBold" align="right">Sub Classification :</td>--%>
                                        <td style="width: 10%; height: 24px;" class="column_Left">
                                            <asp:DropDownList ID="DdSubClassification" Enabled="false" runat="server" Width="54%" CssClass="txtbox_Var" align="center" Visible="false"></asp:DropDownList>
                                            <asp:LinkButton ID="LinkButton5" runat="server" Width="150px" Text="New Sub Classification" OnClick="LinkButton5_Click" Visible="false"> ></asp:LinkButton>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="right">
                                <asp:Button ID="btnSaveClass" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" ValidationGroup="savenp" OnClientClick="StartProgressBar();" OnClick="btnSaveClass_Click"></asp:Button>
                                &nbsp;<asp:Button ID="BtnClearClass" runat="server" Width="120px" CssClass="CSButton" Text="CLEAR" OnClick="BtnClearClass_Click"></asp:Button>

                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" Enabled="True" TargetControlID="btnSaveClass" ConfirmText="Are you sure you want to save this transaction?">
                                </cc1:ConfirmButtonExtender>

                                <asp:TextBox ID="TextBox11" runat="server" Width="0px" Visible="False"></asp:TextBox>
                                <asp:Button ID="Button12" OnClick="btnaddparticular_Click" runat="server" Width="0px" Visible="False" Text="ADD"></asp:Button>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" class="DivTitle">List Of Classifications
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <span class="column_RightBold">Description :</span>
                                &nbsp;<asp:TextBox ID="TextBox12" runat="server" Width="250px" CssClass="txtbox_Var"></asp:TextBox>
                                &nbsp;<asp:Button ID="SrchClassification" OnClick="Button7_Click" runat="server" Width="120px" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();"></asp:Button>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <asp:GridView ID="GvClass" runat="server" Width="98%"
                                    OnPageIndexChanging="GvClass_PageIndexChanging" SkinID="GridViewAA" EmptyDataText="No Records Available"
                                    DataKeyNames="ClassificationID,ClassificationName" AllowPaging="True" PageSize="9" OnSelectedIndexChanged="GvClass_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="LinkBtnSelect" ForeColor="#2977dc"></ItemStyle>
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ClassificationName" HeaderText="Classification Name">
                                            <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ClassificationName" HeaderText="SubClassification Name" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ClassificationName" HeaderText="General Account" Visible="false">
                                            <ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
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
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%">
                                <asp:Button runat="server" ID="Button14" Width="120px" CssClass="CSButton" Text="Close" />
                                <asp:Label ID="Label6" runat="server"></asp:Label>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <%--New Classification END--%>


            <%--New Sub Classification START--%>
            <asp:Panel ID="ModalSubClass" runat="server" Width="700px" CssClass="Panel_Popup">
                <div>
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">New Sub Classification
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 90%" align="center">
                                <table width="90%">
                                    <tr align="center">
                                        <td style="width: 22%; height: 24px;" class="column_RightBold" align="right">Classification :</td>
                                        <td style="width: 27%; height: 24px;" class="column_Left">
                                            <asp:DropDownList ID="ddClassNewSub" runat="server" AutoPostBack="true" Width="54%" CssClass="txtbox_Var" align="center" OnSelectedIndexChanged="ddClassNewSub_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr align="center">
                                        <td style="width: 22%; height: 24px;" class="column_RightBold" align="right">Sub Classification :</td>
                                        <td style="width: 10%; height: 24px;" class="column_Left">
                                            <asp:TextBox ID="NewSubClassificationTxt" Enabled="false" runat="server" Width="54%" CssClass="txtbox_Var" align="center"></asp:TextBox>

                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td style="width: 31%" class="column_RightBold" align="center">General Account :</td>
                                        <td style="width: 50%" class="column_Left" align="center">
                                            <asp:DropDownList ID="ddGASubClass" runat="server" CssClass="drpdownCSS" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="DropGA_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </td>
                            </td>
                        </tr>

                    </table>
                    </td>
                            <td style="width: 1%"></td>
                    </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <asp:Button ID="BtnSave_SUBCLASS" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" ValidationGroup="savenp" OnClick="BtnSave_SUBCLASS_Click" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="Button11" runat="server" Width="120px" CssClass="CSButton" Text="CLEAR" OnClick="BtnClearSubClass_Click"></asp:Button>

                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server" Enabled="True" TargetControlID="BtnSave_SUBCLASS" ConfirmText="Are you sure you want to save this transaction?">
                            </cc1:ConfirmButtonExtender>

                            <asp:TextBox ID="TextBox13" runat="server" Width="0px" Visible="False"></asp:TextBox>
                            <asp:Button ID="Button15" OnClick="btnaddparticular_Click" runat="server" Width="0px" Visible="False" Text="ADD"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List Of Classification and Sub Classifications
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <%-- <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <span class="column_RightBold">Description :</span>
                                &nbsp;<asp:TextBox ID="TextBox14" runat="server" Width="250px" CssClass="txtbox_Var"></asp:TextBox>
                                &nbsp;<asp:Button ID="SrchSubClass"  runat="server" Width="120px" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();" OnClick="SrchSubClass_Click"></asp:Button>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>--%>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="GvSubClass" runat="server" Width="98%"
                                OnPageIndexChanging="GvSubClass_PageIndexChanging" SkinID="GridViewAA" EmptyDataText="No Records Available"
                                DataKeyNames="SubClassificationID,SubClassificationName,ClassificationName,GA_Title2,GA_ID,ClassificationID" AllowPaging="True" PageSize="9" OnSelectedIndexChanged="GvSubClass_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="LinkBtnSelect" ForeColor="#2977dc"></ItemStyle>
                                    </asp:CommandField>
                                    <asp:BoundField DataField="ClassificationName" HeaderText="Classification Name">
                                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SubClassificationName" HeaderText="Sub Classification Name">
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GA_Title2" HeaderText="General Account">
                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
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
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <asp:Button runat="server" ID="Button17" Width="120px" CssClass="CSButton" Text="Close" />
                            <asp:Label ID="Label7" runat="server"></asp:Label>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    </table>
                </div>
            </asp:Panel>

            <%--New SUb Classification END--%>



            <asp:Panel Style="display: none" ID="popup" runat="server" Width="900px">
                <table id="TablepopUP2" height="486" cellspacing="0" cellpadding="0" width="747" border="0">
                    <tbody>
                        <tr>
                            <td colspan="2">
                                <img height="1" alt="" src="../images/modalpopup_02.png" width="747" /></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_02.png); width: 772px; height: 39px"></td>
                            <td style="width: 46px; height: 39px">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/modalpopup_03.png"></asp:ImageButton></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_04.png); vertical-align: top; width: 772px" id="Td3">
                                <table style="width: 705px; height: 336px" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="vertical-align: top; width: 4%; text-align: center"></td>
                                            <td style="vertical-align: top; width: 100%; text-align: center">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Account Title : </td>
                                                            <td style="width: 80%" class="text5">
                                                                <asp:TextBox ID="txtAccnTitle" runat="server" Width="60%" __designer:wfdid="w164"></asp:TextBox><asp:Button ID="btnSearchAccnt" OnClick="btnSearchAccnt_Click" runat="server" Width="120px" __designer:wfdid="w165" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; width: 4%; text-align: center"></td>
                                            <td style="vertical-align: top; width: 100%; text-align: center">
                                                <asp:GridView ID="gvcode" runat="server" Width="100%" SkinID="GridViewAA" EmptyDataText="No Data Found." AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="GA_CODE,GA_Title,GA_ID,GA_Code2,BGA_ID" BackColor="White">
                                                    <Columns>
                                                        <asp:CommandField ShowSelectButton="True">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:CommandField>
                                                        <asp:BoundField DataField="GA_CODE2" HeaderText="ACCOUNT CODE">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="GA_Title" HeaderText="ACCOUNT TITLE">
                                                            <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 4%; text-align: center"></td>
                                            <td style="width: 100%; text-align: center">
                                                <asp:Button ID="Button5" runat="server" Width="150px" Text="LOAD"></asp:Button></td>
                                        </tr>
                                    </tbody>
                                </table>
                                <asp:Label ID="Label2" runat="server"></asp:Label></td>
                            <td style="background-image: url(../images/modalpopup_05.png); width: 46px; height: 446px"></td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label2" CancelControlID="ImageButton1" PopupControlID="popup" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <cc1:ModalPopupExtender ID="ModalPopupExtender5" runat="server" TargetControlID="Label3" PopupControlID="popupParticular" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <cc1:ModalPopupExtender ID="ModalPopupExtender6" runat="server" TargetControlID="Label5" PopupControlID="NewSubCatModal" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <cc1:ModalPopupExtender ID="ModalPopupExtender8" runat="server" TargetControlID="Label6" PopupControlID="PopupClassification" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <cc1:ModalPopupExtender ID="ModalPopupExtender7" runat="server" TargetControlID="Label7" PopupControlID="ModalSubClass" CancelControlID="ImageButton2" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>


            <%--  NEW PARTICULAR POP UP --%>
            <asp:Panel ID="popupParticular" runat="server" Width="700px" CssClass="Panel_Popup">
                <div>
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">New Category
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 90%" align="left">
                                <table width="90%">
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Category Name :</td>
                                        <td style="width: 27%" class="column_Left">
                                            <asp:TextBox ID="txtparticular" runat="server" Width="128%" CssClass="txtbox_Var"></asp:TextBox>
                                            <td style="width: 20%" class="column_RightBold" align="left">Useful Life :</td>
                                            <td style="width: 80%" class="column_Left">
                                                <asp:TextBox ID="txtLife" runat="server" Width="54%" CssClass="txtbox_Amt" align="left"></asp:TextBox>
                                                &nbsp;<span class="column_RightBold">No. of Year/s</span>

                                            </td>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="right">
                                <asp:Button ID="btnsaveparticular" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" ValidationGroup="savenp" OnClientClick="StartProgressBar();" OnClick="btnsaveparticular_Click1"></asp:Button>
                                &nbsp;<asp:Button ID="Button3" OnClick="Clear_Click" runat="server" Width="120px" CssClass="CSButton" Text="CLEAR"></asp:Button>

                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender20" runat="server" Enabled="True" TargetControlID="btnsaveparticular" ConfirmText="Are you sure you want to save this transaction?">
                                </cc1:ConfirmButtonExtender>

                                <asp:TextBox ID="txtParticularCode" runat="server" Width="0px" Visible="False"></asp:TextBox>
                                <asp:Button ID="btnaddparticular" OnClick="btnaddparticular_Click" runat="server" Width="0px" Visible="False" Text="ADD"></asp:Button>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" class="DivTitle">List Of Categories
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <span class="column_RightBold">Description :</span>
                                &nbsp;<asp:TextBox ID="txtparticular2" runat="server" Width="250px" CssClass="txtbox_Var"></asp:TextBox>
                                &nbsp;<asp:Button ID="Button7" OnClick="SrchCat_Click" runat="server" Width="120px" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();"></asp:Button>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <asp:GridView ID="gvparticular" runat="server" Width="98%" OnSelectedIndexChanged="gvparticular_SelectedIndexChanged"
                                    OnPageIndexChanging="gvparticular_PageIndexChanging" SkinID="GridViewAA" EmptyDataText="No Records Found"
                                    DataKeyNames="item_particular_id,description,useful_life" AllowPaging="True" PageSize="9">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="LinkBtnSelect" ForeColor="#2977dc"></ItemStyle>
                                        </asp:CommandField>
                                        <asp:BoundField DataField="description" HeaderText="Description">
                                            <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="useful_life" HeaderText="Useful Life">
                                            <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="ForDBM" HeaderText="For DBM">
                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        </asp:BoundField>--%>
                                    </Columns>
                                </asp:GridView>


                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 5px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%">
                                <asp:Button runat="server" ID="btnCloseParticular" Width="120px" CssClass="CSButton" Text="Close" OnClick="btnCloseParticular_Click" />
                                <asp:Label ID="Label3" runat="server"></asp:Label>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 10px"></td>
                            <td style="width: 1%"></td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>

            <%-- <asp:Panel ID="popupParticular" runat="server" Width="700px" CssClass="Panel_Popup">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td style="width: 100%; height: 30px" class="DivTitle">New Particular
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 5px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <table width="100%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Description :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="txtparticular" runat="server" Width="80%" CssClass="txtbox_Var" Enabled="False" OnTextChanged="txtparticular_TextChanged"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Useful Life :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox ID="txtLife" runat="server" Width="20%" CssClass="txtbox_Amt" Enabled="False" Text="0"></asp:TextBox>
                                        &nbsp;<span class="column_RightBold"> No. of Year/s</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 100%; height: 5px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:TextBox ID="txtParticularCode" runat="server" Width="150px" Enabled="False" OnTextChanged="txtparticular_TextChanged" Visible="False"></asp:TextBox>
                            <asp:Button ID="btnaddparticular" OnClick="btnaddparticular_Click" runat="server" Width="150px" CssClass="CSButton" Text="NEW"></asp:Button>
                            &nbsp;<asp:Button ID="btnsaveparticular" OnClick="btnsaveparticular_Click1" runat="server" Width="150px" CssClass="CSButton" Text="SAVE" ValidationGroup="savenp" OnClientClick="StartProgressBar();"></asp:Button>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender20" runat="server" Enabled="True" ConfirmText="Are you sure you want to save this transaction?" TargetControlID="btnsaveparticular"></cc1:ConfirmButtonExtender>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 100%; height: 5px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" class="DivTitle">Particular List
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 5px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <span class="column_RightBold">Description :</span>
                            &nbsp;<asp:TextBox ID="txtparticular2" runat="server" Width="50%" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="Button7" OnClick="Button7_Click" runat="server" Width="120px" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 100%; height: 5px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:GridView ID="gvparticular" runat="server" Width="98%" OnSelectedIndexChanged="gvparticular_SelectedIndexChanged" SkinID="GridViewAA" EmptyDataText="No Data Found." PageSize="5" AllowPaging="True" DataKeyNames="item_particular_id,description,useful_life,ParticularCode" BackColor="White">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <ItemStyle HorizontalAlign="Center" CssClass="LinkBtnSelect" Width="10%"></ItemStyle>
                                    </asp:CommandField>
                                    <asp:BoundField DataField="ParticularCode" HeaderText="Code" Visible="False">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="description" HeaderText="Description">
                                        <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="useful_life" HeaderText="Useful Life">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 100%; height: 5px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Button ID="btn_OK" OnClick="btn_OK_Click" runat="server" Width="150px" CssClass="CSButton" Text="OK"></asp:Button>
                            <asp:Button runat="server" ID="btnClose" Width="150px" Text="Close" CssClass="CSButton"/>
                            <asp:Label ID="Label3" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 100%; height: 10px"></td>
                    </tr>
                </table>--%>
            <%--END OF PARTICULAR POP UP--%>

            <%--                <table style="width: 747px" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <td style="background-position: center center; background-image: url(../images/POPUP/modalpopup_02.png); width: 705px; height: 39px"></td>
                            <td style="background-position: center center; background-image: url(../images/POPUP/modalpopup_03.png); width: 42px; height: 39px">
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../images/modalpopup_03.png" __designer:wfdid="w49"></asp:ImageButton></td>
                        </tr>
                        <tr>
                            <td style="background-position: center center; background-image: url(../images/POPUP/modalpopup_04.png); vertical-align: top; width: 705px; height: 446px; text-align: center">
                                <table style="width: 690px">
                                    <tbody>
                                        <tr>
                                            <td style="width: 690px">
                                                <asp:Panel ID="Panel2" runat="server" Width="98%" __designer:wfdid="w36" CssClass="text" GroupingText="NEW PARTICULAR">
                                                    <table style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold">Description : </td>
                                                                <td style="width: 80%" class="text5"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold">Useful Life : </td>
                                                                <td style="width: 80%" class="text5">No. of Years</td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold"></td>
                                                                <td style="width: 80%" class="text5"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold"></td>
                                                                <td style="width: 80%" class="text5"></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>

                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 690px">
                                                <asp:Panel ID="Panel1" runat="server" Width="98%" __designer:wfdid="w43" CssClass="text" GroupingText="SEARCH">
                                                    <table style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold">Description : </td>
                                                                <td style="width: 80%"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2"></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td style="background-position: center center; background-image: url(../images/POPUP/modalpopup_05.png); width: 42px; height: 446px"></td>
                        </tr>
                    </tbody>
                </table>--%>

            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label3" CancelControlID="ImageButton2" PopupControlID="popupParticular" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>




            <%-- UPDATE REMARKS --%>
            <asp:Panel ID="pnl_pr_pop_up" runat="server" Width="500px" CssClass="Panel_Popup">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td style="width: 100%" class="DivTitle">Input Remarks
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:TextBox ID="txtremarks" runat="server" Width="95%" CssClass="txtbox_Remarks" Height="100px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Button ID="btnOK" runat="server" Width="100px" Text="OK" ValidationGroup="ok" OnClientClick="StartProgressBar(); " CssClass="CSButton"></asp:Button>
                            &nbsp;<asp:Button ID="btnCancel" runat="server" Width="100px" CssClass="CSButton" Text="CANCEL"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px"></td>
                    </tr>
                </table>
                <asp:Label ID="pr_pop_up" runat="server"></asp:Label>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="pr_pop_up" CancelControlID="btnCancel" PopupControlID="pnl_pr_pop_up" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
