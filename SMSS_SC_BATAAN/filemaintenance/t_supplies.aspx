<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="t_supplies.aspx.vb"
    Inherits="t_supplies"
    Title="FM Supplies"
    EnableEventValidation="false"
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

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnsave" />
        </Triggers>
        <ContentTemplate>

            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 100%" class="PageTitle">Maintenance and Other Operating Expenses
                        </td>
                        <%--<td style="width: 1%"></td>--%>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 100%" align="center">
                            <table style="border: 1px solid #5c85d6; width: 54%;" cellpadding="0px" cellspacing="0px">
                                <tr>
                                    <td colspan="2" style="width: 100%" class="DivTitle">Note : 
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 5%"></td>
                                    <td style="width: 95%; color: #ff0000" class="column_Left">Use the unit that will be used in Issuance of Supplies.
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 5%"></td>
                                    <td style="width: 95%; color: #ff0000" class="column_Left">Example 1.) Box, The unit that will be used for Issuance is by Box.
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 5%"></td>
                                    <td style="width: 95%; color: #ff0000" class="column_Left">Example 2.) Box(12)Piece, The unit that will be used for Issuance is by Piece.</td>
                                </tr>
                                <tr>
                                    <td style="width: 5%"></td>
                                    <td style="width: 95%; color: #ff0000" class="column_Left">In Issuance, if you want to issue one(1) box then issue 12 pieces.</td>
                                </tr>
                                <tr>
                                    <td style="width: 5%"></td>
                                    <td style="width: 95%; height: 10px"></td>
                                </tr>

                            </table>
                        </td>
                        <%--<td style="width: 1%"></td>--%>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 101%; height: 10px"></td>
                        <%--<td style="width: 1%"></td>--%>
                    </tr>




                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 101%" align="center">
                            <table width="100%">
                                <tr>
                                    <td align="center" style="width: 80%; height: 19px;" class="ColumnHeader_C">ITEMS DETAILS:</td>
                                    <td align="center" style="width: 20%; height: 19px;" class="ColumnHeader_C">ITEM IMAGE</td>
                                </tr>

                                <tr>
                                    <td align="center" style="vertical-align: top; width: 80%; height: 180px" class="panel_border">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Calendar Year :</td>
                                                <td style="width: 101%;" align="left">
                                                    <asp:DropDownList ID="ddyear" runat="server" Width="70px" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="16px">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
                                                    <asp:HiddenField ID="HiddenField2" runat="server"></asp:HiddenField>
                                                    <asp:HiddenField ID="HiddenField3" runat="server"></asp:HiddenField>
                                                </td>


                                            </tr>
                                            <tr>
                                                <td style="width: 20%" class="column_RightBold">Classifications: 
                                                    <td style="width: 101%;" align="left">

                                                        <asp:HiddenField ID="hdnItemSubClass" runat="server" />
                                                        <asp:HiddenField ID="hdnGAId" runat="server" />

                                                        <asp:DropDownList ID="DrpClass" CssClass="drpdownCSS" runat="server" Width="190px" AutoPostBack="True" Endabled="False" OnSelectedIndexChanged="DrpClass_SelectedIndexChanged"></asp:DropDownList>
                                                        <asp:LinkButton Style="font-family: 'Arial'" Font-Size="9pt" ID="LinkButton4" runat="server" Width="150px" Visible="false" Text="New Classification" OnClick="LinkButton4_Click"></asp:LinkButton>
                                                    </td>
                                            </tr>


                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Sub-Classifications:</td>
                                                <td style="width: 101%;" align="left">

                                                    <asp:DropDownList ID="DrpSubClass" CssClass="drpdownCSS" runat="server" Width="190px" AutoPostBack="True" Endabled="False" OnSelectedIndexChanged="DrpClasssub_SelectedIndexChanged" Style="margin-left: 0px">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:LinkButton Style="font-family: 'Arial'" Font-Size="9pt" ID="LinkButton6" runat="server" Width="150px" Text="New Sub Classification" OnClick="LinkButton6_Click"></asp:LinkButton>

                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <%--<td style="width: 0%">
                            <asp:DropDownList ID="ddAccountCode" runat="server" Width="0px" AutoPostBack="True" Visible="False"></asp:DropDownList></td>--%>
                                                    <%-- <td style="width: 0%" align="center">
                            <%--<span class="column_RightBold">Search Description :</span>--%>
                                                    <caption>
                                                        &nbsp;<asp:TextBox ID="txtSearchAccnt" runat="server" CssClass="txtbox_Var" Enabled="False" Visible="false" Width="0px"></asp:TextBox>
                                                        &nbsp;<asp:Button ID="btnSearchAccnt" runat="server" CssClass="CSButton" Enabled="False" OnClick="btnSearchAccnt_Click" Text="SEARCH" Visible="false" Width="0px" />


                                                    </caption>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">General Account:</td>


                                                <td style="width: 85%;" align="left">


                                                    <asp:DropDownList ID="GenAccnt" runat="server" Width="468px" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="GenAccnt_SelectedIndexChanged" Style="margin-left: 0px" Height="17px">
                                                    </asp:DropDownList>
                                                </td>

                                                <td style="width: 1%"></td>
                                            </tr>

                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Category :
                                                    <spam style="color: red">*</spam>
                                                </td>
                                                <td style="width: 85%" class="column_Left">
                                                    <asp:DropDownList ID="ddParticular" runat="server" CssClass="drpdownCSS" Width="60%" AutoPostBack="True" OnSelectedIndexChanged="ddParticular_SelectedIndexChanged"></asp:DropDownList>
                                                    &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" Width="150px" Text="New Category" OnClick="LinkButton3_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Sub Category :
                                                </td>
                                                <td style="width: 85%" class="column_Left">
                                                    <asp:DropDownList ID="ddSubCategory" runat="server" CssClass="drpdownCSS" Width="60%" AutoPostBack="True" OnSelectedIndexChanged="ddSubCategory_SelectedIndexChanged"></asp:DropDownList>
                                                    &nbsp;<asp:LinkButton ID="Button3" OnClick="Button3_Click" runat="server" Width="150px" Text="New Sub Category"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr id="GenName" runat="server">
                                                <td style="width: 15%" class="column_RightBold">Generic Name :
                                                </td>
                                                <td style="width: 85%" class="column_Left">
                                                    <asp:TextBox ID="TextBoxGen" runat="server" Width="150px" AutoPostBack="True" Enabled="false" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none">
                                                <td style="width: 15%" class="column_RightBold">Brand :
                                                </td>
                                                <td style="width: 85%" class="column_Left">
                                                    <asp:TextBox ID="TextBoxBrand" runat="server" Width="150px" AutoPostBack="True" Enabled="true" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none">
                                                <td style="width: 15%" class="column_RightBold">Color :
                                                </td>
                                                <td style="width: 85%" class="column_Left">
                                                    <asp:TextBox ID="TextBoxColor" runat="server" Width="150px" AutoPostBack="True" Enabled="true" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none">
                                                <td style="width: 15%" class="column_RightBold">Size :
                                                </td>
                                                <td style="width: 85%" class="column_Left">
                                                    <asp:TextBox ID="TextBoxSize" runat="server" Width="150px" AutoPostBack="True" Enabled="true" CssClass="txtbox_Var"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Item Description :</td>
                                                <td style="width: 85%" class="column_Left">
                                                    <asp:TextBox ID="txtItemDesc" runat="server" Width="60%" AutoPostBack="True" CssClass="txtbox_Var" OnTextChanged="txtItemDesc_TextChanged"></asp:TextBox>
                                                    &nbsp;<asp:Label ID="lblmsg" runat="server" Font-Bold="False" ForeColor="Red" Font-Size="8pt" Font-Names="Tahoma" Visible="False" Text="* Item description already exist." Font-Italic="True"></asp:Label>
                                                    <asp:Image ID="imgCheck" runat="server" ImageUrl="~/images/check.jpg" Visible="False" Height="15px"></asp:Image>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="saveS" ErrorMessage="*" ControlToValidate="txtItemDesc"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Unit :
                                                </td>
                                                <td style="width: 85%" class="column_Left">
                                                    <asp:DropDownList ID="ddUnit" runat="server" CssClass="drpdownCSS" Width="25%" AppendDataBoundItems="True">
                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                    </asp:DropDownList>
                                                    &nbsp;<asp:CheckBox ID="chkInactive" runat="server" Visible="False" Text="In active"></asp:CheckBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="saveS" ErrorMessage="*" ControlToValidate="ddUnit" InitialValue="0"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Price :
                                                </td>
                                                <td style="width: 85%" class="column_Left">
                                                    <asp:TextBox ID="txtprice" runat="server" CssClass="txtbox_Amt" Width="150px" AutoPostBack="True" Text="0.00" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); "></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" ValidChars="0123456789.," TargetControlID="txtprice">
                                                    </cc1:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="saveS" ErrorMessage="*" ControlToValidate="txtprice" InitialValue="0.00"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Item Code :
                                                </td>
                                                <td style="width: 85%" class="column_Left">
                                                    <asp:TextBox ID="txtItemCode" runat="server" Width="150px" AutoPostBack="True" Enabled="False" CssClass="txtbox_Var" OnTextChanged="txtItemCode_TextChanged" MaxLength="8"></asp:TextBox>
                                                    &nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="False" ForeColor="Red" Font-Size="8pt" Font-Names="Tahoma" Visible="False" Text="* Item code already exist." Font-Italic="True"></asp:Label>
                                                    &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/images/check.jpg" Visible="False" Height="15px"></asp:Image>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Reorder Point : </td>
                                                <td class="column_Left">
                                                    <asp:TextBox ID="txtReorderPoint" runat="server" Width="50" Enabled="false"></asp:TextBox>
                                                    <asp:Button ID="btnROP" runat="server" CssClass="CSButton" Text="R.O.P" Width="40" Enabled="false" />

                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 15%" class="column_LeftBold"></td>
                                                <td style="width: 85%" class="column_Left">
                                                    <asp:TextBox ID="txtRpt" runat="server" Width="125px" Visible="False" Enabled="False" CssClass="txtboxinspection"></asp:TextBox>
                                                    &nbsp;<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789" TargetControlID="txtRpt" FilterType="Numbers"></cc1:FilteredTextBoxExtender>

                                                </td>

                                            </tr>

                                        </table>
                                    </td>
                                    <td align="center" style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; vertical-align: top; border-left: royalblue 1px solid; width: 25%; border-bottom: royalblue 1px solid; height: 150PX">
                                        <table style="width: 100%">
                                            <tbody>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl="~/images/blankImage.jpg" Width="170px" />
                                                        <asp:Label ID="lblNoti" runat="server" Font-Names="Calibri" Font-Size="9pt" ForeColor="Red" Text="* No file to upload." Visible="False"></asp:Label>
                                                        <asp:FileUpload type="file" onchange="return ShowImagePreview(this)" ID="FileUpload1" Enabled="false" runat="server" Width="88px" />
                                                        <asp:TextBox ID="Attched" runat="server" Visible="false"></asp:TextBox>
                                                    </td>

                                                </tr>
                                            </tbody>
                                        </table>

                                    </td>

                                </tr>
                            </table>
                        </td>
                        <%--<td style="width: 1%"></td>--%>
                    </tr>




                    <tr>
                        <td style="width: 1%"></td>
                        <td align="right" style="width: 101%"></td>
                        <%--<td style="width: 1%"></td>--%>
                    </tr>
                    <tr>
                        <td style="width: 1%; height: 34px;"></td>
                        <td align="right" style="width: 101%; height: 34px;">
                            <asp:Button ID="btnadd" runat="server" Font-Bold="true" ForeColor="blue" OnClick="btnadd_Click" Text="New" Width="80px" />
                            &nbsp;<asp:Button ID="btnedit" runat="server" Font-Bold="true" ForeColor="blue" Text="Edit" Width="80px" />
                            &nbsp;<asp:Button ID="btnsave" runat="server" Font-Bold="true" ForeColor="blue" Height="26px" OnClick="btnsave_Click" OnClientClick="StartProgressBar();" Text="Save" Width="80px" />
                            &nbsp;<asp:Button ID="btnDelete" runat="server" CssClass="CSButton" Font-Bold="true" OnClick="btnDelete_Click" Text="DELETE" Visible="False" Width="80px" />
                            &nbsp;<asp:Button ID="btncopyall" runat="server" Enabled="False" Font-Bold="true" ForeColor="blue" OnClick="btncopyall_Click" OnClientClick="StartProgressBar();" Text="Copy All previous price under this Account" Width="300px" />
                        </td>
                        <%--<td style="width: 1%; height: 34px;"></td>--%>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td class="DivTitle" style="width: 101%">ITEM LIST </td>
                        <%--<td style="width: 1%"></td>--%>
                    </tr>
                    <tr>
                        <%-- List of Items Grid--%>
                        <td style="width: 1%"></td>
                        <td style="width: 101%">
                            <table style="display: none" width="100%">
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">Search : </td>
                                    <td class="column_Left" style="width: 20%">
                                        <asp:DropDownList ID="DropDownList2" runat="server" Width="95%">
                                            <asp:ListItem Selected="True" Value="1">Description</asp:ListItem>
                                            <asp:ListItem Value="2">Item Code</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="column_Left" style="width: 40%">
                                        <asp:TextBox ID="TextBox4" runat="server" CssClass="txtbox_Var" Width="95%"></asp:TextBox>
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Button ID="Button1" runat="server" CssClass="CSButton" OnClick="btnsearch_Click" OnClientClick="StartProgressBar();" Text="Search" Width="150px" />
                                        <asp:Button ID="Button4" runat="server" OnClick="bntcopyPerGrid_Click" Text="Copy Previous Value" Visible="False" Width="160px" />
                                    </td>
                                </tr>
                            </table>
                            <%--End of Table--%>
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="true" DataKeyNames="ItemDesc,Item_ID,Unit_ID,item_particular_id,Year_Current,Item_Code" EmptyDataText="No Data Found." OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="15" SkinID="GridViewAA" Visible="false" Width="98%">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" CssClass="LinkBtnSelect" OnClientClick="StartProgressBar();" Text="Select"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Hide" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbHide" runat="server" AutoPostBack="true" Checked='<%# Bind("isHide") %>' CssClass="rbCS_Horizontal" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Item_Code" HeaderText="Item Code" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                    <asp:BoundField DataField="ItemDesc" HeaderText="Item Description" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50%" />
                                    <asp:BoundField DataField="UnitDesc" HeaderText="Unit" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblHeader_Previous" runat="server" CssClass="column_Center"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblYear_Previous" runat="server" CssClass="column_Right" Text='<%# Bind("Year_Previous", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblHeader_Current" runat="server" CssClass="column_Center"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblYear_Current" runat="server" CssClass="column_Right" Text='<%# Bind("Year_Current", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td align="center" style="width: 101%">
                            <table width="100%">
                                <tr>
                                    <td class="column_RightBold" style="width: 10%">Search : </td>
                                    <td class="column_Left" style="width: 20%">
                                        <asp:DropDownList ID="ddSearch" runat="server" Width="95%">
                                            <asp:ListItem Selected="True" Value="1">Description</asp:ListItem>
                                            <asp:ListItem Value="2">Item Code</asp:ListItem>
                                            <asp:ListItem Value="3">Category</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="column_Left" style="width: 40%">
                                        <asp:TextBox ID="txtsearch2" runat="server" CssClass="txtbox_Var" Width="95%"></asp:TextBox>
                                    </td>
                                    <td class="column_Left" style="width: 30%">
                                        <asp:Button ID="btnsearch" runat="server" CssClass="CSButton" OnClick="btnsearch_Click" OnClientClick="StartProgressBar();" Text="Search" Width="150px" />
                                        <asp:Button ID="bntcopyPerGrid" runat="server" OnClick="bntcopyPerGrid_Click" Text="Copy Previous Value" Visible="False" Width="160px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 101%">
                            <asp:GridView ID="gvstock" runat="server" AllowPaging="True" DataKeyNames="particulardesc,detail,UnitDesc,price1,Item_ID,item_particular_id,Unit_ID,itemdesc,SubCategoryID,SubCat_desc,isused,price2,price,Item_Code,Brand,Color,Size,SubClassificationName,SubClassificationID,GenericName"
                                EmptyDataText="No Records Found" PageSize="20" SkinID="GridViewAA" Width="99%" OnPageIndexChanging="gvstock_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select Item" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Font-Underline="False" OnClick="LinkButton1_Click" Text="Select" Width="63px"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Center" Width="3%" />
                                    </asp:TemplateField>

                                    
                                    <asp:TemplateField HeaderText="Hide?" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Checked='<%# Bind("isUsed") %>' OnCheckedChanged="CheckBox1_CheckedChanged" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Center" Width="3%" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="AccntCode" HeaderText="Account Code">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Item_Code" HeaderText="Item Code">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="particulardesc" HeaderText="ITEM DESCRIPTION">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Brand" HeaderText="Brand" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Color" HeaderText="Color" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Size" HeaderText="Size" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SubCat_Desc" HeaderText="SubClassification" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="unitdesc" HeaderText="UNIT">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="price1" HeaderText="CY2022">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="price2" HeaderText="CY2023">
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
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
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
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DEL">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
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
                        <%--<td style="width: 1%"></td>--%>
                    </tr>
                </table>

            </div>

            <asp:Panel Style="display: none; text-align: center" ID="pnl_pr_pop_up" runat="server" Width="500px" CssClass="Panel_Popup" BorderWidth="2px" BorderStyle="Solid">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width: 490px">
                            <tbody>
                                <tr>
                                    <%--<td style="font-weight: bold; font-size: 10pt; width: 100%; color: white; font-family: Verdana; background-color: #00FFFF" align="center">INPUT REMARKS
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="ok" ErrorMessage="*" ControlToValidate="txtremarks"></asp:RequiredFieldValidator></td>--%>
                                    <td style="width: 100%" align="center" class="DivTitle">Input Remarks
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" align="center">
                                        <asp:TextBox Style="text-align: left" ID="txtremarks" runat="server" Width="100%" Height="115px" TextMode="MultiLine"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" align="center">
                                        <asp:Button ID="btnOK" runat="server" Width="100px" Text="OK" ValidationGroup="ok" OnClientClick="StartProgressBar(); "></asp:Button>&nbsp;<asp:Button ID="btnCancel" runat="server" Width="100px" Text="CANCEL"></asp:Button></td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Label ID="pr_pop_up" runat="server"></asp:Label>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="pr_pop_up" PopupControlID="pnl_pr_pop_up" CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Label3" PopupControlID="popupParticular" CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <cc1:ModalPopupExtender ID="ModalPopupExtender4" runat="server" TargetControlID="Label5" PopupControlID="NewSubCatModal" CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <cc1:ModalPopupExtender ID="ModalPopupExtender5" runat="server" TargetControlID="Label6" PopupControlID="PopupClass" CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <cc1:ModalPopupExtender ID="ModalPopupExtender6" runat="server" TargetControlID="Label7" PopupControlID="ModalSubClass" CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>


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
                                                <asp:TextBox ID="txtLife" runat="server" Width="54%" CssClass="txtbox_Amt" align="left" Text="0"></asp:TextBox>
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
                                <asp:Button ID="btnsaveparticular" OnClick="btnsaveparticular_Click" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" ValidationGroup="savenp" OnClientClick="StartProgressBar();"></asp:Button>
                                &nbsp;<asp:Button ID="Button2" OnClick="btnaddparticular_Click" runat="server" Width="120px" CssClass="CSButton" Text="CLEAR"></asp:Button>

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
                                &nbsp;<asp:Button ID="Button7" runat="server" Width="120px" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();" OnClick="SrchCat_Click"></asp:Button>
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
                            <td style="width: 100%" align="center">
                                <asp:GridView ID="gvparticular" runat="server" Width="98%" OnSelectedIndexChanged="gvparticular_SelectedIndexChanged"
                                    OnPageIndexChanging="gvparticular_PageIndexChanging" SkinID="GridViewAA" EmptyDataText="No Records Found"
                                    DataKeyNames="item_particular_id,description,useful_life" AllowPaging="True" PageSize="9">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="LinkBtnSelect" ForeColor="#2977dc"></ItemStyle>
                                        </asp:CommandField>
                                        <asp:BoundField DataField="description" HeaderText="Description">
                                            <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="useful_life" HeaderText="Useful Life">
                                            <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
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
                                <asp:Button runat="server" ID="btnCloseParticular" Width="120px" CssClass="CSButton" Text="Close" />
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
            <%-- New Category End--%>

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
                                <table width="90%" style="height: 78px">
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
                                            <asp:TextBox ID="TextBox6" runat="server" Width="10%" Text="0" CssClass="txtbox_Amt" align="center"></asp:TextBox>
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
                            <asp:Button ID="gvparticular1" OnClick="btnsaveSubCat_Click" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" ValidationGroup="savenp" OnClientClick="StartProgressBar();"></asp:Button>
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
                            &nbsp;<asp:Button ID="Button9" runat="server" Width="120px" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();" OnClick="Button9_Click"></asp:Button>
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
                                OnPageIndexChanging="Gridview2_PageIndexChanging" SkinID="GridViewAA" EmptyDataText="No Records Found"
                                DataKeyNames="item_particular_id,SubCategoryID,subcat_desc,Useful_life,description" AllowPaging="True" PageSize="9">
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
                                    <asp:BoundField DataField="Useful_life" HeaderText="Useful Life">
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
            <asp:Panel ID="PopupClass" runat="server" Width="700px" CssClass="Panel_Popup">
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
                                                    <asp:CheckBox ID="WithSubClass" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnCheckedChanged="WithSubClass_CheckedChanged" /><font style="font-family: 'Arial'" size="2"> with Sub Classification</font>
                                                </td>
                                            </td>
                                        </tr>
                                    </tr>

                                    <tr id="GA" align="center" runat="server">
                                        <td style="width: 31%; height: 21px;" class="column_RightBold" align="center">General Account :</td>
                                        <td style="width: 50%; height: 21px;" class="column_Left" align="center">
                                            <asp:DropDownList ID="DropGA" runat="server" CssClass="drpdownCSS" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="DropGA_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>

                                    </tr>

                                    <tr align="center">
                                        <%--<td style="width: 31%; height: 24px;" class="column_RightBold" align="right">Sub Classification :</td>--%>
                                        <td style="width: 10%; height: 24px;" class="column_Left">
                                            <asp:DropDownList ID="DdSubClassification" Enabled="false" runat="server" Width="54%" CssClass="txtbox_Var" align="center" Visible="false"></asp:DropDownList>
                                            <asp:LinkButton ID="LinkButton5" runat="server" Width="150px" Text="New Sub Classification" OnClick="LinkButton5_Click" Visible="false"></asp:LinkButton>
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
                                            <asp:DropDownList ID="ddClassNewSub" runat="server" Width="54%" CssClass="txtbox_Var" align="center" OnSelectedIndexChanged="ddClassNewSub_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr align="center">
                                        <td style="width: 22%; height: 24px;" class="column_RightBold" align="right">Sub Classification :</td>
                                        <td style="width: 10%; height: 24px;" class="column_Left">
                                            <asp:TextBox ID="NewSubClassificationTxt" Enabled="false" runat="server" Width="74%" CssClass="txtbox_Var" align="center"></asp:TextBox>

                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td style="width: 31%" class="column_RightBold" align="center">General Account :</td>
                                        <td style="width: 50%" class="column_Left" align="center">
                                            <asp:DropDownList ID="ddGASubClass" runat="server" CssClass="drpdownCSS" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="ddGASubClass_SelectedIndexChanged">
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
                            <asp:Button ID="BtnSave_SUBCLASS" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" ValidationGroup="savenp" OnClientClick="StartProgressBar();" OnClick="BtnSave_SUBCLASS_Click"></asp:Button>
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
                    <%--<tr>
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
                            <td style="background-image: url(../images/modalpopup_02.png); width: 772px; height: 39px"></td>
                            <td style="width: 46px; height: 39px">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/modalpopup_03.png"></asp:ImageButton></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_04.png); vertical-align: top; width: 772px" id="Td3">
                                <table style="width: 705px; height: 336px" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="vertical-align: top; width: 4%; height: 14px; text-align: center"></td>
                                            <td style="background-color: floralwhite; text-align: left">
                                                <asp:Label ID="Label1" runat="server" Width="92px" Font-Bold="True" Text="Delete By :"></asp:Label>
                                                <asp:DropDownList ID="DropDownList1" runat="server" Width="198px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1">
                                                    <asp:ListItem Value="1">Item Description</asp:ListItem>
                                                    <asp:ListItem Value="2">Particular</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; width: 4%; text-align: center"></td>
                                            <td style="vertical-align: top; width: 100%; text-align: center">
                                                <asp:GridView ID="grdITEMS" runat="server" Width="100%" OnSelectedIndexChanged="grdITEMS_SelectedIndexChanged" SkinID="GridViewAA" AllowPaging="True" BackColor="White">
                                                    <Columns>
                                                        <asp:CommandField ShowSelectButton="True">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        </asp:CommandField>
                                                        <asp:BoundField DataField="description" HeaderText="Particular">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" Width="60%" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 4%; text-align: center"></td>
                                            <td style="width: 100%; text-align: center">&nbsp;<asp:Button ID="btnDel" OnClick="btnDel_Click" runat="server" Width="150px" Text="DELETE"></asp:Button></td>
                                        </tr>
                                    </tbody>
                                </table>
                                <asp:Label ID="Label2" runat="server"></asp:Label>&nbsp;</td>
                            <td style="background-image: url(../images/modalpopup_05.png); width: 46px; height: 446px"></td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="Label2" PopupControlID="popup" CancelControlID="ImageButton1" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


            <asp:Panel ID="popupROP" runat="server" Width="350px" CssClass="Panel_Popup">
                <table width="100%">
                    <tr>
                        <td style="width: 100%; height: 30px; margin-left: 40px;" colspan="3" class="DivTitle">REORDER POINT COMPUTATION
                              <asp:ImageButton ID="BtnImageClose" ImageUrl="~/images/Edited Image/CloseButton.png" runat="server" border="10px" Height="13px" Width="16px" />
                    </tr>
                    <tr>
                        <td class="column_RightBold">Demand Per Day :
                        </td>
                        <td class="column_Left">
                            <asp:TextBox ID="DRP" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold">Lead Time for Delivery:
                        </td>
                        <td class="column_Left">
                            <asp:TextBox ID="LTD" runat="server" CssClass="txtbox_Var" Width="150px"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold"></td>
                        <td>

                            <asp:Button ID="BtnCompute" runat="server" Width="133px" CssClass="CSButton" Text="Compute"></asp:Button>

                        </td>

                    </tr>
                    <tr>
                        <td class="column_RightBold">Reorder Point :
                        </td>
                        <td class="column_Left">
                            <asp:TextBox ID="RP" runat="server" CssClass="txtbox_Var" Width="150px" ReadOnly="true"></asp:TextBox>

                        </td>

                    </tr>
                    <tr>

                        <td style="width: 50%; height: 10px">
                            <asp:Label runat="server" ID="lblpopupROP"></asp:Label>
                        </td>
                    </tr>
                </table>

            </asp:Panel>

            <cc1:ModalPopupExtender ID="ModalPopupExtender7" runat="server" TargetControlID="lblpopupROP" PopupControlID="popupROP" CancelControlID="BtnImageClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
