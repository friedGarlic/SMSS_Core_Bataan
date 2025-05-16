<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_PPE_Encoding.aspx.vb"
    Inherits="Inventory_t_PPE_Encoding" Title="Encoding of PPE" StylesheetTheme="SkinFile" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">MANUAL ENCODING OF PPE
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">General Account :</span>
                            &nbsp;<asp:DropDownList ID="ddAllotment" runat="server" Width="300px" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddAllotment_SelectedIndexChanged"></asp:DropDownList>
                            &nbsp;<asp:DropDownList ID="ddSearch" runat="server" Width="100px" CssClass="drpdownCSS">
                                <asp:ListItem Value="1">Description</asp:ListItem>
                                <asp:ListItem Value="2">Item Code</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="txtSearch" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearchItem" OnClick="btnSearchItem_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="SEARCH"></asp:Button>

                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdItemList" runat="server" Width="95%" OnSelectedIndexChanged="grdItemList_SelectedIndexChanged" SkinID="GridViewAA"
                                AllowPaging="True" BackColor="White" DataKeyNames="GA_Code,Item_ID,Item_Desc" EmptyDataText="No Data Found."
                                OnRowDataBound="grdItemList_RowDataBound" OnPageIndexChanging="grdItemList_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="Item_Code" HeaderText="Item Code">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                        <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprice" runat="server" Text='<%# Bind("price", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%;height:5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Item Details
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:MultiView ID="mvPPE" runat="server">
                                <asp:View ID="vwEquipments" runat="server">
                                    <table width="98%">
                                        <tr>
                                            <td style="width: 10%" class="column_RightBold">Department :</td>
                                            <td style="width: 35%">
                                                <asp:DropDownList ID="ddEquipDepartment" runat="server" Width="98%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddEquipDepartment_SelectedIndexChanged"></asp:DropDownList>
                                            </td>
                                            <td style="width: 15%" class="column_RightBold">Additional Specs :</td>
                                            <td style="width: 40%" rowspan="2">
                                                <asp:TextBox ID="txtESpecs" runat="server" Width="98%" CssClass="txtbox_Remarks" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 10%" class="column_RightBold">Function :</td>
                                            <td style="width: 35%">
                                                <asp:DropDownList ID="ddEquipFunction" runat="server" Width="98%" CssClass="drpdownCSS" AutoPostBack="True"></asp:DropDownList>
                                            </td>
                                            <td style="width: 15%" class="column_RightBold"></td>

                                        </tr>
                                        <tr>
                                            <td style="width: 10%" class="column_RightBold">Acquired Date :</td>
                                            <td style="width: 35%">
                                                <asp:TextBox ID="txtEAcqDate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                                &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                                                &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                            </td>
                                            <td style="width: 15%" class="column_RightBold">Quantity :</td>
                                            <td style="width: 40%">
                                                <asp:TextBox ID="txtEQty" runat="server" Width="150px" CssClass="txtbox_Amt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 10%" class="column_RightBold">Acquired Cost :</td>
                                            <td style="width: 35%">
                                                <asp:TextBox ID="txtEAcqCost" runat="server" Width="150px" AutoPostBack="True" CssClass="txtbox_Amt" OnTextChanged="txtEAcqCost_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="width: 15%" class="column_RightBold">JEV Number :</td>
                                            <td style="width: 40%">
                                                <asp:TextBox ID="txtJEVNumb" runat="server" Width="150px" CssClass="txtbox_Var"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 10%" class="column_RightBold">Market Value :</td>
                                            <td style="width: 35%">
                                                <asp:TextBox ID="txtEMarketValue" runat="server" Width="150px" AutoPostBack="True" CssClass="txtbox_Amt" OnTextChanged="txtEMarketValue_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="width: 15%" class="column_RightBold"></td>
                                            <td style="width: 40%"></td>
                                        </tr>

                                        <tr>
                                            <td style="width: 100%" align="center" colspan="4">
                                                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="SUBMIT" Enabled="False"></asp:Button>
                                                &nbsp;<asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="CANCEL"></asp:Button>

                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEAcqDate" PopupButtonID="ImageButton1"></cc1:CalendarExtender>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtEAcqCost" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtEMarketValue" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>

                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwLand" runat="server">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Department : </td>
                                                <td style="width: 35%" class="text5">
                                                    <asp:DropDownList ID="ddLandDepartment" runat="server" Width="98%" AutoPostBack="True" OnSelectedIndexChanged="ddLandDepartment_SelectedIndexChanged"></asp:DropDownList></td>
                                                <td style="width: 15%" class="column_RightBold">Function : </td>
                                                <td style="width: 35%" class="text5">
                                                    <asp:DropDownList ID="ddLandFunction" runat="server" Width="98%"></asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 15%" class="column_RightBold"><span style="font-family: Calibri"><span style="font-family: Arial">Location / Brgy.&nbsp;:</span> </span></td>
                                                <td style="width: 35%; font-family: Calibri" class="text5">
                                                    <asp:TextBox ID="txtLocation" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                <td style="width: 15%; font-family: Calibri" class="column_RightBold"><span style="font-family: Arial">Acquisition Date :</span> </td>
                                                <td style="width: 35%; font-family: Arial" class="text5">
                                                    <asp:TextBox ID="txtAcqDate" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox><asp:ImageButton ID="ImageButton8" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton><span style="font-size: 8pt; font-family: Calibri"><strong>(MM/DD/YYYY)</strong></span></td>
                                            </tr>
                                            <tr style="font-family: Arial">
                                                <td style="width: 15%" class="column_RightBold">Area : </td>
                                                <td style="width: 35%" class="text5">
                                                    <asp:TextBox ID="txtArea" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                <td style="width: 15%" class="column_RightBold">Acquisition Cost : </td>
                                                <td style="width: 35%" class="text5">
                                                    <asp:TextBox ID="txtAcqCost" runat="server" Width="200px" AutoPostBack="True" CssClass="txtboxinspection" OnTextChanged="txtAcqCost_TextChanged">0.00</asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Tax Dec. No. : </td>
                                                <td style="width: 35%" class="text5">
                                                    <asp:TextBox ID="txtTaxDec" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                <td style="width: 15%" class="column_RightBold">Acquisition Mode : </td>
                                                <td style="width: 35%" class="text5">
                                                    <asp:TextBox ID="txtAcqMode" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Previous Owner : </td>
                                                <td style="width: 35%" class="text5">
                                                    <asp:TextBox ID="txtPreviousOwner" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                <td style="width: 15%" class="column_RightBold">Market Value : </td>
                                                <td style="width: 35%" class="text5">
                                                    <asp:TextBox ID="txtMarketValue" runat="server" Width="200px" AutoPostBack="True" CssClass="txtboxinspection" OnTextChanged="txtMarketValue_TextChanged">0.00</asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">Brgy. Code : </td>
                                                <td style="width: 35%" class="text5">
                                                    <asp:TextBox ID="txtBrgyCode" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                <td style="width: 15%" class="column_RightBold"></td>
                                                <td style="width: 35%" class="text5"></td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4">
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtAcqCost" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtMarketValue" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4">
                                                    <asp:Button ID="btnLandSave" OnClick="btnLandSave_Click" runat="server" Width="200px" OnClientClick="StartProgressBar();" Text="SAVE" Height="30px"></asp:Button><asp:Button ID="btnClear" OnClick="btnClear_Click" runat="server" Width="200px" OnClientClick="StartProgressBar();" Text="CLEAR" Height="30px"></asp:Button></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List Of Properties - Manually Encoded
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Property Year :</span>
                            &nbsp;<asp:TextBox ID="txtSearchYear" runat="server" CssClass="txtbox_Var" Width="200px"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearchYear" runat="server" OnClick="btnSearchYear_Click" OnClientClick="StartProgressBar();" Text="SEARCH" Width="150px" CssClass="CSButton" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdProperties" runat="server" Width="98%" OnSelectedIndexChanged="grdProperties_SelectedIndexChanged" SkinID="GridViewAA"
                                AllowPaging="True" DataKeyNames="RC_Name,Amount,Item_ID,Property_ID,RC_ID,Function_ID,Property_Date" EmptyDataText="No Data Found."
                                OnRowDataBound="grdProperties_RowDataBound" OnPageIndexChanging="grdProperties_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="RC_Name" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Left" Width="30%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                        <ItemStyle HorizontalAlign="Left" Width="39%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Amount" DataFormatString="{0:N}" HeaderText="Amount">
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Property_Date" DataFormatString="{0:d}" HeaderText="Date ">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:BoundField>
                                </Columns>
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
                        <td style="width: 98%" align="center">
                            <table width="80%" cellpadding="0px" cellspacing="0px" class="borderCSS">
                                <tr>
                                    <td style="width: 100%" colspan="4" class="DivTitle">Update Item Details
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 10px" colspan="4"></td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Department : &nbsp;</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="ddDepartment" runat="server" CssClass="drpdownCSS" OnSelectedIndexChanged="ddDepartment_SelectedIndexChanged" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Amount : &nbsp;</td>
                                    <td style="width: 30%" align="left">
                                        <asp:TextBox ID="txtAmount" runat="server" AutoPostBack="True" CssClass="txtbox_Amt" OnTextChanged="txtAmount_TextChanged" Width="120px" Text="0.00"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 5px" colspan="4"></td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Function : &nbsp;</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="ddFunction" runat="server" Width="300px" CssClass="drpdownCSS">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 30%" align="left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 10px" colspan="4"></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnSaveProp" runat="server" OnClick="btnSaveProp_Click" Text="SAVE" Width="150px" CssClass="CSButton" Enabled="False" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button ID="btnDelete" runat="server" Text="DELETE" Width="150px" CssClass="CSButton" Enabled="False" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button ID="btnCancelProp" runat="server" Enabled="False" OnClick="btnCancelProp_Click" OnClientClick="StartProgressBar();" Text="CANCEL" Width="150px" CssClass="CSButton" />

                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers" TargetControlID="txtSearchYear" ValidChars="0123456789">
                            </cc1:FilteredTextBoxExtender>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtAmount" ValidChars="0123456789.,">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>


            
            
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
            
            
            <asp:Panel Style="display: none" ID="Panel1" runat="server" Width="900px">
                <table id="Table2" height="486" cellspacing="0" cellpadding="0" width="747" border="0">
                    <tbody>
                        <tr>
                            <td colspan="2">
                                <%--<img height="1" alt="" src="../images/modalpopup_01.png" width="747" />--%>

                            </td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_02.png); width: 772px; height: 39px"></td>
                            <td style="width: 46px; height: 39px">
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../images/modalpopup_03.png"></asp:ImageButton></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_04.png); vertical-align: top; width: 772px" id="Td1">
                                <table style="width: 705px; height: 336px" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="vertical-align: top; width: 4%; text-align: center"></td>
                                            <td style="vertical-align: top; width: 100%; text-align: center">
                                                <asp:Panel ID="Panel2" runat="server" Width="100%" Height="380px" ScrollBars="Vertical" BorderColor="Transparent">
                                                    <asp:GridView ID="grdSerial" runat="server" Width="100%" BackColor="White" SkinID="GridViewAA" CssClass="text" Font-Size="9pt">
                                                        <Columns>
                                                            <asp:BoundField DataField="no" HeaderText="#">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Serial Number / Plate Number">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtSerial" runat="server" Width="90%" Text='<%#Bind("barcode") %>' CssClass="txtbosinspection"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <HeaderStyle CssClass="text"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Property Number">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPropNo" runat="server" CssClass="txtbosinspection" Text='<%# bind("PropertyNo") %>'
                                                                        Width="90%"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="45%" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <br />
                                                </asp:Panel>
                                                &nbsp;<asp:Label ID="lblSerial" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 4%; height: 19px; text-align: center"></td>
                                            <td style="width: 100%; height: 19px; text-align: center">
                                                <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Smaller" Font-Names="Calibri" Text="* Optional : Property Number is for old inventory with existing property number."></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 4%; height: 19px; text-align: center"></td>
                                            <td style="width: 100%; height: 19px; text-align: center">
                                                <asp:Button ID="btnSavePPE" OnClick="btnSavePPE_Click" runat="server" Width="150px" Font-Bold="False" OnClientClick="StartProgressBar();" Text="SAVE" SkinID="Button"></asp:Button></td>
                                        </tr>
                                    </tbody>
                                </table>
                                &nbsp;</td>
                            <td style="background-image: url(../images/modalpopup_05.png); width: 46px; height: 446px"></td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1" TargetControlID="lblSerial" CancelControlID="ImageButton3" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

