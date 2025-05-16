<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SupplierCard.aspx.vb" Inherits="Records_SupplierCard" Title="Supplier Card" StylesheetTheme="skinFile" %>

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
                        <td style="width: 98%" class="PageTitle">SUPPLIER CARD
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Supplier :</span>
                            &nbsp;<asp:TextBox ID="txtSuppname" runat="server" Width="300px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearch" TabIndex="1" runat="server" Width="120px" CssClass="CSButton" Text="Search" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdcompany" runat="server" Width="98%" SkinID="GridViewAA" AllowPaging="True" DataKeyNames="Supplier_Id">
                                <Columns>
                                    <asp:BoundField DataField="SuppName" HeaderText="Company Name">
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProductService" HeaderText="Product And Services">
                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Address1" HeaderText="Address">
                                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Officeno" HeaderText="Telephone No.">
                                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContactP" HeaderText="Manager's Name">
                                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Details
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 100%">
                                <tr>
                                    <td align="center" style="width: 80%; height: 19px;" class="ColumnHeader_C">COMPANY PROFILE</td>
                                    <td align="center" style="width: 20%; height: 19px;" class="ColumnHeader_C">COMPANY IMAGE</td>
                                   
                                    
                                </tr>
                                <tr>
                                    <td align="center" style="vertical-align: top; width: 80%; height: 180px" class="panel_border">
                                        <table style="width: 100%">
                                            <tbody>
                                                <tr>
                                                    <td style="vertical-align: top; width: 30%" class="column_RightBold">Company Name :</td>
                                                    <td style="vertical-align: top; width: 70%" class="column_Left" rowspan="2">
                                                        <asp:Label ID="lblcompanyname" runat="server"></asp:Label></td>
                                                   
                                                </tr>
                                                <tr style="font-size: 8pt">
                                                    <td style="vertical-align: top; width: 20%; height: 17px;" class="column_RightBold"></td>
                                                   </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 20%" class="column_RightBold">Product/ Services &nbsp;:</td>
                                                    <td style="vertical-align: top; width: 30%" class="column_Left" rowspan="2">
                                                        <asp:Label ID="lblProduct" runat="server"></asp:Label></td>
                                                   </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 20%" class="column_RightBold"><span style="font-size: 8pt"><span style="font-size: 9pt"></span></span></td>
                                                   
                                                </tr>
                                                <tr style="font-size: 10pt">
                                                    <td style="vertical-align: top; width: 20%" class="column_RightBold">Address :</td>
                                                    <td style="vertical-align: top; width: 30%" class="column_Left" rowspan="3">
                                                        <asp:Label ID="lblSuppAddress" runat="server"></asp:Label></td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 20%" class="column_RightBold"></td>
                                                   
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 20%" class="column_RightBold"></td>
                                                 
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 20%" class="column_RightBold">Email Address :</td>
                                                    <td style="vertical-align: top; width: 30%" class="column_Left">
                                                        <asp:Label ID="lblEmailaddress" runat="server"></asp:Label></td>
                                                   
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                    <td align="center" style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; vertical-align: top; border-left: royalblue 1px solid; width: 25%; border-bottom: royalblue 1px solid; height: 150PX">
                                        <table style="width: 100%">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl="~/images/noPicture.jpg" Width="150px" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                  
                                    
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 100%">
                                <tr>
                                    <td align="center" style="width: 80%" class="ColumnHeader_C">Contact Person</td>
                                     <td align="center" style="width: 20%" class="ColumnHeader_C">CONTACT IMAGE</td>
                                   
                                    
                                </tr>
                                <tr>
                                    <td align="center" class="panel_border" style="vertical-align: top; width: 25%; height: 50px">
                                        <table style="width: 100%">
                                            <tbody>
                                                <tr>

                                                    <td class="column_RightBold" style="vertical-align: top; width: 20%"> </td>
                                                    <td class="column_Left" style="vertical-align: top; width: 30%">
                                                       
                                                    </td>
                                                    <td class="column_LeftBold" style="vertical-align: top; width: 20%"> </td>
                                                    <td class="column_Left" style="vertical-align: top; width: 30%">
                                                        
                                                    </td>
                                                </tr>
                                                <tr><td class="column_RightBold" style="vertical-align: top; width: 20%"> </td>
                                                    <td class="column_Left" style="vertical-align: top; width: 30%"></td>
                                                    <td class="column_LeftBold" style="vertical-align: top; width: 20%"> </td>
                                                    <td class="column_Left" style="vertical-align: top; width: 30%"> </td>
                                                </tr>
                                               
                                               
                                                <tr>

                                                    <td class="column_RightBold" style="vertical-align: top; width: 20%">Full Name : </td>
                                                    <td class="column_Left" style="vertical-align: top; width: 30%">
                                                        <asp:Label ID="lblname" runat="server" CssClass="column_Left"></asp:Label>
                                                    </td>
                                                    <td class="column_LeftBold" style="vertical-align: top; width: 20%">Birth Date : </td>
                                                    <td class="column_Left" style="vertical-align: top; width: 30%">
                                                        <asp:Label ID="lblBday" runat="server" CssClass="column_Left"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="vertical-align: top; width: 20%">Position : </td>
                                                    <td class="column_Left" style="vertical-align: top; width: 30%">
                                                        <asp:Label ID="lblPosition" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="column_LeftBold" style="vertical-align: top; width: 20%">Age : </td>
                                                    <td class="column_Left" style="vertical-align: top; width: 30%">
                                                        <asp:Label ID="lblage" runat="server" CssClass="column_Left"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="vertical-align: top; width: 20%">Address :</td>
                                                    <td class="column_Left" style="vertical-align: top; width: 30%">
                                                        <asp:Label ID="lbladdress" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="column_LeftBold" style="vertical-align: top; width: 20%">Gender : </td>
                                                    <td class="column_Left" style="vertical-align: top; width: 30%">
                                                        <asp:Label ID="lblgender" runat="server" CssClass="column_Left"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="vertical-align: top; width: 20%">Contact No.</td>
                                                    <td class="column_Left" style="vertical-align: top; width: 30%">
                                                        <asp:Label ID="lblContact" runat="server" ></asp:Label>
                                                    </td>
                                                    <td class="column_LeftBold" style="vertical-align: top; width: 20%">Nationality : </td>
                                                    <td class="column_Left" style="vertical-align: top; width: 30%">
                                                        <asp:Label ID="lblnationality" runat="server" CssClass="column_Left"></asp:Label>
                                                    </td>


                                          


                                                </tr>
                                                 <tr>
                                                    <td class="column_RightBold" style="vertical-align: top; width: 20%">Email: </td>
                                                    <td class="column_Left" style="vertical-align: top; width: 30%">
                                                        <asp:Label ID="lblemail" runat="server" ></asp:Label>
                                                    </td>
                                                    <td class="column_LeftBold" style="vertical-align: top; width: 20%"> </td>
                                                    <td class="column_Left" style="vertical-align: top; width: 30%">
                                                       
                                                    </td>

                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                                                         <td align="center" style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; vertical-align: top; border-left: royalblue 1px solid; width: 25%; border-bottom: royalblue 1px solid; height: 150PX">
                                        <table style="width: 100%">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:Image ID="Image2" runat="server" Height="150PX" ImageUrl="~/images/noPicture.jpg" Width="150PX" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                    
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                  

                            <tr>
                                <td style="width: 1%"></td>
                                <td class="DivTitle" style="width: 98%">INFORMATION </td>
                                <td style="width: 1%"></td>
                            </tr>
                            <tr>
                                <td style="width: 1%"></td>
                                <td align="left" style="width: 98%">
                                    <asp:Button ID="btnTab1_Ledger" runat="server" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" Text="Ledger" Width="10%" />
                                    &nbsp;<asp:Button ID="btnTab2_Product" runat="server" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" Text="Product Lines" Width="12%" />
                                    &nbsp;<asp:Button ID="btnTab3_Documents" runat="server" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" Text="Business Documents" Width="20%" />
                                </td>
                                <td style="width: 1%"></td>
                            </tr>
                            <tr>
                                <td class="PanelTabs" colspan="3" style="width: 100%">
                                    <asp:MultiView ID="mvTabs" runat="server">
                                        <asp:View ID="vwTab1_Ledger" runat="server">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 1%"></td>
                                                    <td class="DivTitle" style="width: 98%">List of Purchase Order </td>
                                                    <td style="width: 1%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 1%"></td>
                                                    <td align="center" style="width: 98%">
                                                        <asp:GridView ID="grpoorder" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="POHdr_ID" EmptyDataText="No Data Found." HorizontalAlign="Center" OnRowDataBound="grpoorder_RowDataBound" PageSize="5" SkinID="GridViewAA" Width="98%">
                                                            <Columns>
                                                                <asp:BoundField DataField="PO_No" HeaderText="PO No.">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="PO_Date" DataFormatString="{0:d}" HeaderText="PO Date">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ContractPrice" DataFormatString="{0:N}" HeaderText="PO Amount">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="OBR_No" HeaderText="OBR No.">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ProjectName" HeaderText="Project Name">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="RC_Name" HeaderText="Requesting Dept">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SuppName" HeaderText="Supplier" Visible="False">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="dv_no" HeaderText="DV No." Visible="False">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="check_no" HeaderText="Check No." Visible="False">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="amountpaid" HeaderText="Amount Paid" Visible="False">
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="jev_no" HeaderText="JEV No." Visible="False">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                    <td style="width: 1%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 1%"></td>
                                                    <td class="DivTitle" style="width: 98%">Supplier Ledger </td>
                                                    <td style="width: 1%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 1%"></td>
                                                    <td align="center" style="width: 98%">
                                                        <asp:GridView ID="grdlistofgoods" runat="server" AllowPaging="True" EmptyDataText="No Data Found." HorizontalAlign="Center" PageSize="5" SkinID="GridViewAA" Width="98%">
                                                            <Columns>
                                                                <asp:BoundField DataField="PO_Date" DataFormatString="{0:d}" HeaderText="Date">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="PO_No" HeaderText="PO NO.">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Particular" HeaderText="Particulars">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="REF_No" HeaderText="Ref No.">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Debit" DataFormatString="{0:N}" HeaderText=" Debit ">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Credit" DataFormatString="{0:N}" HeaderText=" Credit ">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Bal" DataFormatString="{0:N}" HeaderText=" BALANCE ">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                    <td style="width: 1%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 1%; height: 28px;"></td>
                                                    <td class="center" style="width: 98%; height: 28px;">
                                                        <asp:Button ID="preview" runat="server" CssClass="CSButton" OnClick="preview_Click" Text="PREVIEW" />
                                                    </td>
                                                    <td style="width: 1%; height: 28px;"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 1%"></td>
                                                    <td style="width: 98%"></td>
                                                    <td style="width: 1%"></td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vwTab2_Documents" runat="server">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 1%"></td>
                                                    <td class="DivTitle" style="width: 98%">Business Documents </td>
                                                    <td style="width: 1%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 1%"></td>
                                                    <td align="center" class="panel_border" style="vertical-align: top; width: 25%; height: 50px">
                                                        <table style="width: 100%">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 5%"></td>
                                                                    <td class="column_LeftBold" style="vertical-align: top; width: 50%">
                                                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" CssClass="rbCS_Horizontal" Text=" " />
                                                                        &nbsp;<asp:Button ID="Button1" runat="server" CssClass="TabButton_InActive" Text="Upload" Width="15%" />
                                                                        &nbsp;<asp:Button ID="btnDTI" runat="server" CssClass="TabButton_InActive" OnClick="btnDTI_Click" Text="View" Width="10%" />
                                                                        <asp:Label ID="Label13" runat="server" CssClass="column_Left" Text="DTI Registration" Width="180px"></asp:Label>
                                                                    </td>
                                                                    <td class="column_LeftBold" style="vertical-align: top; width: 50%">
                                                                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" CssClass="rbCS_Horizontal" Text=" " />
                                                                        &nbsp;<asp:Button ID="Button2" runat="server" CssClass="TabButton_InActive" Text="Upload" Width="15%" />
                                                                        &nbsp;<asp:Button ID="btnPermit" runat="server" CssClass="TabButton_InActive" Text="View" Width="10%" />
                                                                        <asp:Label ID="Label12" runat="server" CssClass="column_Left" Text="Business Permit" Width="180px"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 5%"></td>
                                                                    <td class="column_LeftBold" style="vertical-align: top; width: 50%">
                                                                        <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" CssClass="rbCS_Horizontal" Text=" " />
                                                                        &nbsp;<asp:Button ID="Button5" runat="server" CssClass="TabButton_InActive" Text="Upload" Width="15%" />
                                                                        &nbsp;<asp:Button ID="BtnTax" runat="server" CssClass="TabButton_InActive" OnClick="BtnTax_Click" Text="View" Width="10%" />
                                                                        <asp:Label ID="Label7" runat="server" CssClass="column_Left" Text="Tax Clearance Cert" Width="180px"></asp:Label>
                                                                    </td>
                                                                    <td class="column_LeftBold" style="vertical-align: top; width: 50%">
                                                                        <asp:CheckBox ID="CheckBox4" runat="server" AutoPostBack="True" CssClass="rbCS_Horizontal" Text=" " />
                                                                        &nbsp;<asp:Button ID="Button7" runat="server" CssClass="TabButton_InActive" Text="Upload" Width="15%" />
                                                                        &nbsp;<asp:Button ID="btnPCAB" runat="server" CssClass="TabButton_InActive" Text="View" Width="10%" />
                                                                        <asp:Label ID="Label10" runat="server" CssClass="column_Left" Text="PCAB License" Width="180px"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 5%"></td>
                                                                    <td class="column_LeftBold" style="vertical-align: top; width: 50%">
                                                                        <asp:CheckBox ID="CheckBox5" runat="server" AutoPostBack="True" CssClass="rbCS_Horizontal" Text=" " />
                                                                        &nbsp;<asp:Button ID="Button9" runat="server" CssClass="TabButton_InActive" Text="Upload" Width="15%" />
                                                                        &nbsp;<asp:Button ID="BtnSEC" runat="server" CssClass="TabButton_InActive" OnClick="BtnSEC_Click" Text="View" Width="10%" />
                                                                        <asp:Label ID="Label8" runat="server" CssClass="column_Left" Text="SEC Registration" Width="180px"></asp:Label>
                                                                    </td>
                                                                    <td class="column_LeftBold" style="vertical-align: top; width: 50%">
                                                                        <asp:CheckBox ID="CheckBox6" runat="server" AutoPostBack="True" CssClass="rbCS_Horizontal" Text=" " />
                                                                        &nbsp;<asp:Button ID="Button11" runat="server" CssClass="TabButton_InActive" Text="Upload" Width="15%" />
                                                                        &nbsp;<asp:Button ID="btnFDA" runat="server" CssClass="TabButton_InActive" Text="View" Width="10%" />
                                                                        <asp:Label ID="Label11" runat="server" CssClass="column_Left" Text="FDA Registration" Width="180px"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 5%"></td>
                                                                    <td class="column_LeftBold" style="vertical-align: top; width: 50%">
                                                                        <asp:CheckBox ID="CheckBox7" runat="server" AutoPostBack="True" CssClass="rbCS_Horizontal" Text=" " />
                                                                        &nbsp;<asp:Button ID="Button13" runat="server" CssClass="TabButton_InActive" Text="Upload" Width="15%" />
                                                                        &nbsp;<asp:Button ID="Button14" runat="server" CssClass="TabButton_InActive" Text="View" Width="10%" />
                                                                        <asp:Label ID="Label9" runat="server" CssClass="column_Left" Text="PhilGEPS " Width="180px"></asp:Label>
                                                                        <td class="column_LeftBold" style="vertical-align: top; width: 50%"></td>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <td style="width: 1%"></td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                       
                                        <asp:View ID="SupplierItems" runat="server">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 1%"></td>
                                                    <td class="DivTitle" style="width: 98%">Product Lines </td>
                                                    <td style="width: 1%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 1%"></td>
                                                    <td align="center" class="panel_border" style="vertical-align: top; width: 25%; height: 50px">
                                                        <table style="width: 100%">
                                                             <tr>
                                                                 <td class="column_Left" width="10%">Classification   </td>
                                                                <td >
                                                                <asp:DropDownList ID="ddClassification" runat="server" width="150px" AutoPostBack="True" CssClass="drpdownCSS" ></asp:DropDownList>
                                                                </td>
                                                                 <td class="column_RightBold" width="10%" >Sub Classification
                                                                
                                                                </td>
                                                                <td >
                                                                <asp:DropDownList ID="DropDownList1" runat="server" width="150px" AutoPostBack="True" CssClass="drpdownCSS" ></asp:DropDownList>
                                                                </td>
                                                                 <td class="column_RightBold" width="10%" >General Account
                                                                
                                                                </td>
                                                                <td >
                                                                <asp:DropDownList ID="DropDownList2" runat="server" width="150px" AutoPostBack="True" CssClass="drpdownCSS" ></asp:DropDownList>
                                                                </td>
                                                             </tr>
                                                            <tr>
                                                                 <td class="column_Left" width="10%%">Category:   </td>
                                                                <td >
                                                                <asp:DropDownList ID="DropDownList3" runat="server" width="150px" AutoPostBack="True" CssClass="drpdownCSS" ></asp:DropDownList>
                                                                </td>
                                                                 <td class="column_RightBold" width="10%" >Sub Category:
                                                                
                                                                </td>
                                                                <td >
                                                                <asp:DropDownList ID="DropDownList4" runat="server" width="150px" AutoPostBack="True" CssClass="drpdownCSS" ></asp:DropDownList>
                                                                </td>
                                                                 <td class="column_RightBold" width="10%" >Description
                                                                
                                                                </td>
                                                                 <td>
                                        <asp:TextBox ID="txtSearchStock" runat="server" Width="90%"  CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearchStock" Width="100px" runat="server" CssClass="CSButton" Text="Search"></asp:Button>

                        
                                    </td>
                                                             </tr>
                                                  </table>

     <div id="lazada" >
                    <asp:ListView ID="ListView1" runat="server" GroupItemCount="4" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1">
                    <EmptyDataTemplate>
                        <table runat="server" style="">
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <LayoutTemplate>
                        
                            <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                        
                    </LayoutTemplate>
                    <GroupTemplate>
                     
                        
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                       
                    </GroupTemplate>
                    <ItemTemplate>
                            <div class="card">
                                  <table width="100%" cellpadding="2%" cellspacing="2%" >
                                        <tr>
                                            <td>
                                                 <asp:Label ID="Label2" runat="server" Text='<%#Eval("ProductName")%>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                   <asp:Image ID="Image1" style=" height: 150px;width: 160px; border: 1px solid #ddd;  border-radius: 4px;  padding: 5px; " runat="server" ImageUrl='<%#Eval("image") %>' AlternateText='<%# Eval("image") %>' ToolTip='<%# Eval("image")  %>' />
                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                     <asp:Label ID="Label1" runat="server" Text='<%#Eval("Price")%>'></asp:Label>
                               
                                            </td>
                                        </tr>
                                    </table>
                                   
                            </div>
                  
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                          <div class="card">
                              <table width="100%" cellpadding="2%" cellspacing="2%">
                                        <tr>
                                            <td>
                                                 <asp:Label ID="Label2" runat="server" Text='<%#Eval("ProductName")%>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                             <asp:Image ID="Image1" style=" height: 150px;width: 160px;border: 1px solid #ddd;  border-radius: 4px;  padding: 5px;  " runat="server" ImageUrl='<%#Eval("image") %>' AlternateText='<%# Eval("image") %>' ToolTip='<%# Eval("image")  %>' />
                                
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
                                                      
                                                       
                                        </asp:View>
                                    </asp:MultiView>
                                </td>
                            </tr>
                        </tr>
                                        </table>
              
            </div>
             

         
                    

                        <asp:Panel ID="popupView" runat="server" CssClass="Panel_Popup" Width="600px">
                            <table cellpadding="2px" cellspacing="2px" width="100%">
                                <tr>
                                    <td class="DivTitle" colspan="2">DETAILS </td>
                                </tr>
             
                <tr>
                    <td>
                        <asp:Label ID="lblIssued" runat="server" CssClass="column_Right" Text="Issued At:" Width="130px"></asp:Label>&nbsp;
                        <asp:TextBox ID="TxtIssued" runat="server" ReadOnly="true" Width="130px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblDocument" runat="server" CssClass="column_Right" Text="DTI Registration No.:" Width="130px"></asp:Label>&nbsp;
                        <asp:TextBox ID="TxtDocument" runat="server" ReadOnly="true" Width="130px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" CssClass="column_Right" Text="Date Issued:" Width="130px"></asp:Label>&nbsp;
                        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" Width="130px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" CssClass="column_Right" Text="Validity:" Width="130px"></asp:Label>&nbsp;
                        <asp:TextBox ID="TextBox2" runat="server" ReadOnly="true" Width="130px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                   
                    <td class="column_Right">
                        <asp:Button ID="BtnOK" runat="server" CssClass="CSButton"  Text="CLOSE" Width="100px" />
                    </td>
                       
                </tr>
                <tr>
                    <td style="width: 50%; height: 10px">
                        <asp:Label ID="lblview" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
                </asp:Panel>
             
                           <cc1:ModalPopupExtender ID="ModalPopupExtender5" runat="server" CancelControlID="BtnOK" PopupControlID="popupView" TargetControlID="lblview"></cc1:ModalPopupExtender>

            
                       
                           
              
             
                          
                       
              

                     
            <%--<asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender">
            </cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>--%>
        

                            
              
                
   
        
             




        </ContentTemplate>
    </asp:UpdatePanel>  
</asp:Content>

