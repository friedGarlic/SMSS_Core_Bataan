<%@ Page 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    EnableEventValidation="false" 
    AutoEventWireup="false"
    CodeFile="PropertyCard.aspx.vb" 
    Inherits="Records_PropertyCard" 
    Title="Property Card" 
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <script language="javascript" type="text/javascript">
        function Table2_onclick() {
        }
        function fun1(e, button1) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(button1);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">PROPERTY CARD
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                     <tr>
                         <td style="width: 1%"></td>
                              <td colspan="7" class="column_RightBold" style="width: 98%; text-align:right;"><%--STOCK CARD--%>Date :
                                 <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox_Date" Width="100px"></asp:TextBox>
                              </td>
                          <td style="width: 1%"></td>
                           </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Classification :</span>
                            &nbsp;<asp:DropDownList ID="ddClass" runat="server" Width="175px" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                           
                            <span class="column_RightBold">General Account :</span>
                            &nbsp;<asp:DropDownList ID="ddGlAccount" runat="server" Width="600px" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList>
                              </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                          <span class="column_RightBold">Category :</span>
                            &nbsp;<asp:DropDownList ID="ddCategory" runat="server" Width="175px" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged" ></asp:DropDownList>
                            &nbsp; <span class="column_RightBold">Sub Category :</span>
                                 &nbsp;   <asp:DropDownList ID="ddSubCategory" runat="server" AutoPostBack="True"  Width="150px" CssClass="drpdownCSS" Enabled =" false" OnSelectedIndexChanged="ddSubCategory_SelectedIndexChanged" ></asp:DropDownList>
                                    
                           &nbsp;<span class="column_RightBold">Description :</span>
                            &nbsp;<asp:TextBox ID="txtAccountSearch" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="ItemSearch" OnClick="ItemSearch_Click" runat="server" Width="120px" CssClass="CSButton" Text="Search"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:MultiView ID="mwProperty" runat="server">
                                <asp:View ID="vwListEquipements" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            
                                            <td align="center" style="width: 100%">
                                                <asp:GridView ID="gvsearchproperty" runat="server" Width="98%" SkinID="GridViewAA" HorizontalAlign="Center"
                                                    DataKeyNames="item_particular_id,Item_ID" AllowPaging="True" OnPageIndexChanging="gvsearchproperty_PageIndexChanging"
                                                    OnSelectedIndexChanged="gvsearchproperty_SelectedIndexChanged" OnRowDataBound="gvsearchproperty_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField DataField="Property_code" HeaderText="CODE" Visible="False"></asp:BoundField>
                                                        <asp:BoundField DataField="Item_ID" HeaderText="ITEM NO.">
                                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="itemdescription" HeaderText="ITEM DESCRIPTION" HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Left" Width="50%" ></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="unit" DataFormatString="{0:N}" HeaderText="UNIT">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ItemCount" HeaderText="BAL AS OF TODAY">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="NO. OF ORDERS/YEAR">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="MIN QTY/ORDER">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="reorderPT" HeaderText="REORDER PT">
                                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwListLandBldg" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <asp:GridView ID="gvsearch" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="Received_ID,Received_Dtl_ID"
                                                    HorizontalAlign="Center" AllowPaging="True" OnPageIndexChanging="gvsearch_PageIndexChanging">
                                                    <Columns>
                                                        <asp:BoundField DataField="Item_Code" HeaderText="Item Code">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Balance" HeaderText="Quantity">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Property_Date" DataFormatString="{0:d}" HeaderText="Acquisition Date">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AcquisitionCost" DataFormatString="{0:N}" HeaderText="Acquisition Cost">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MarketValue" HeaderText="Market Value">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:MultiView ID="mvPropertyInformation" runat="server">
                                <asp:View ID="vwEquipment" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center" class="DivTitle" style="width: 100%">List Of Equipments</td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <span class="column_RightBold">Serial Number :</span>
                                                &nbsp;<asp:TextBox ID="txtSerialSearch" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                &nbsp;<asp:Button ID="btnEquipmentSerialSearch" OnClick="btnSerialSearch_Click" runat="server" Width="120px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <asp:GridView ID="grdlistofEuipment" runat="server" Width="98%" SkinID="GridViewAA" OnPageIndexChanging="grdlistofEuipment_PageIndexChanging"
                                                    AllowPaging="True" HorizontalAlign="Center" DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,useful_life,Received_Dtl_ID,barcode"
                                                    OnRowDataBound="grdlistofEuipment_RowDataBound" OnSelectedIndexChanged="grdlistofEuipment_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:BoundField DataField="Type" HeaderText="TYPE OF EQUIPMENT">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="barcode" HeaderText="SERIAL NO.">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DatePurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AcquisitionCost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MarketValue" HeaderText="MARKET VALUE">
                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Condition" HeaderText="CONDITION">
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Location" HeaderText="LOCATION">
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Status" HeaderText="STATUS">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="DivTitle" style="width: 100%">INVENTORY CARD</td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class="column_RightBold" >Name :
                                                        </td>
                                                        <td class="column_Left">
                                                            <asp:Label ID="lblequipmentname" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Unit :
                                                        </td>
                                                        <td class="column_Left" >
                                                            <asp:Label ID="lblunit" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                          <td align="center" rowspan="9" style="width: 20%">
                                                            <asp:Image ID="Image3" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle" ImageUrl="~/images/blankImage.jpg" Width="90%" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Description :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblequipmentdesciption" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                       
                                                        <td class="column_RightBold" style="width: 10%">Dimension :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblequipmentdimension" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        </tr>
                                                    <tr>
                                                        
                                                        <td class="column_RightBold" style="width: 10%">Power Input :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblequipmentpowerinput" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                
                                                        <td class="column_RightBold" style="width: 10%">Area Capacity :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblequipmentareacapacity" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                      </tr>
                                                    <tr>
                                                         <td class="column_RightBold" style="width: 10%">Model :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblequipmentmodel" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                 <td class="column_RightBold" style="width: 10%">Warranty :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblequipmentwaranty" runat="server" Width="290px" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                       </tr>
                                       
                                                   
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                                        <td class="column_Left" style="width: 30%"></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 30%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <fieldset>
                                                                  <legend class="column_LeftBold">Acquisition :</legend>
                                     
                                                                       <table>
                                                                <tr>
                                                                    <td  class="column_RightBold" style="width:130px;">Acquisition Date :
                                                                    </td>
                                                                    <td class="column_Left" >
                                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                        <asp:TextBox ID="txtEAcqDate" runat="server"  AutoPostBack="True" CssClass="txtbox_Var" OnTextChanged="txtEAcqDate_TextChanged"></asp:TextBox>
                                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEAcqDate" PopupButtonID="txtEAcqDate"></cc1:CalendarExtender>
                                                                        &nbsp;(MM/DD/YYYY)</td> 
                                                         <td class="column_RightBold" style="width:130px;">Market Value :
                                                            </td>
                                                            <td class="column_Left" >
                                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                                                <asp:TextBox ID="txtEMarketValue" runat="server"  AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                                </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" >Acquisition Cost :
                                                                    </td>
                                                                    <td class="column_Left" >
                                                                        <asp:Label ID="Label2" runat="server" ></asp:Label>
                                                                        <asp:TextBox ID="txtEAcqCost" runat="server" AutoPostBack="True" CssClass="txtbox_Var"></asp:TextBox>
                                                                    </td>
                                                                      <td class="column_RightBold" >Useful Life :
                                                        </td>
                                                        <td class="column_Left">
                                                            <asp:Label ID="lblUsefulLife" runat="server"></asp:Label>&nbsp;(Years)</td>
                                                      
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold">Dep. Rate :
                                                        </td>
                                                        <td class="column_Left" >
                                                            <asp:TextBox ID="lblequipmentdepreciatedRate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True" OnTextChanged="lblequipmentdepreciatedRate_TextChanged"></asp:TextBox>&nbsp;(%) Percent</td>
                                                      <td class="column_RightBold">No. of Years :
                                                        </td>
                                                        <td class="column_Left" >
                                                            <asp:Label ID="lblNoYears" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                 <td class="column_RightBold" >Dep. Value :
                                                        </td>
                                                        <td class="column_Left" >
                                                            <asp:Label ID="lblequipmentdepreciatedvalue" runat="server" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                     <td class="column_RightBold" >Salvage Value :
                                                        </td>
                                                        <td class="column_Left" >
                                                            <asp:TextBox ID="txtSalvageValue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" OnTextChanged="txtSalvageValue_TextChanged">0.00</asp:TextBox></td>
                                              
                                                                </tr>
                                                            </table>
                                                    
                                                            </fieldset>
                                                         </td>
                                                        </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Specifications :
                                                        </td>
                                                        <td class="column_Left" colspan="3">
                                                            <asp:Label ID="lblSpecification" runat="server" CssClass="text3"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                                        <td class="column_Left" colspan="3"></td>
                                                    </tr>
                                                </table>
                                                <asp:Label ID="lblEquipDateTaken" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label>
                                                <asp:Label ID="lblEquipUploadedBy" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label>
                                                <asp:Label ID="lblEquipPosition" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="column_Left" style="width: 100%">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="column_Left" style="width: 100%">
                                                <asp:Button ID="btnEquipmentLedger" runat="server" Width="180px" CssClass="Initial" Text="Ledger"></asp:Button>
                                                <asp:Button ID="btnequipmentrepairs" runat="server" Width="180px" CssClass="Initial" Text="Repairs and Maintenance"></asp:Button>
                                                <asp:Button ID="btnequipmentattachdoc" runat="server" Width="180px" CssClass="Initial" Text="Document Attached"></asp:Button></td>
                                        </tr>
                                    </table>
                                </asp:View>



                                <asp:View ID="vwfurnitureandfixtures" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center" class="DivTitle" style="width: 100%">List Of Furniture And Fixtures</td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <span class="column_RightBold">Serail Number :</span>
                                                &nbsp;<asp:TextBox ID="txtFurnitureSerialSearch" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                &nbsp;<asp:Button ID="Button3" OnClick="Button3_Click" runat="server" Width="120px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <asp:GridView ID="grdfurnitureandfixtures" runat="server" Width="98%" SkinID="GridViewAA" OnPageIndexChanging="grdfurnitureandfixtures_PageIndexChanging"
                                                    AllowPaging="True" HorizontalAlign="Center" DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,useful_life,Received_Dtl_ID"
                                                    OnRowDataBound="grdfurnitureandfixtures_RowDataBound1" OnSelectedIndexChanged="grdfurnitureandfixtures_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:BoundField DataField="Type" HeaderText="TYPE OF FURNITURE">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="barcode" HeaderText="SERIAL NO.">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="datepurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="acquisitioncost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="marketvalue" DataFormatString="{0:N}" HeaderText="MARKET VALUE">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="condition" HeaderText="CONDITION">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="location" HeaderText="LOCATION">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="status" HeaderText="STATUS">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="DivTitle" style="width: 100%">Details</td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Name :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblfurniturename" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Model :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblfurnituremodel" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td align="center" rowspan="9" style="width: 20%">
                                                            <asp:Image ID="Image7" runat="server" CssClass="textimage2" Height="160px" ImageAlign="Middle"
                                                                ImageUrl="~/images/blankImage.jpg" Width="90%" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Description :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblfurnituredescription" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Warranty :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblfurniturewaranty" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Dimension :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblfurnituredimension" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Area Capacity :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblfurnitureareacapacity" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Dep. Value :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblfurnituredepriatedvalue" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Useful Life :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblFULife" runat="server"></asp:Label>&nbsp;Years</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Dep. Rate :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:TextBox ID="lblfurnituredepreciatedrate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" ReadOnly="True" OnTextChanged="lblfurnituredepreciatedrate_TextChanged"></asp:TextBox>&nbsp;(%) Percent</td>
                                                        <td class="column_RightBold" style="width: 10%">No. of Years :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblFNoYears" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Salvage Value :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:TextBox ID="txtFSalValue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" OnTextChanged="txtFSalValue_TextChanged"></asp:TextBox></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 30%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                                        <td class="column_Left" style="width: 30%"></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 30%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Specifications :
                                                        </td>
                                                        <td class="column_Left" colspan="3">
                                                            <asp:Label ID="lblfurniturespecification" runat="server" Width="600px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" colspan="3">&nbsp;</td>
                                                    </tr>
                                                </table>
                                                <asp:Label ID="lblfurnitureDateTaken" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label><asp:Label ID="lblFurnitureUploadedBy" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label><asp:Label ID="lblFurniturePosition" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="column_Left" style="width: 100%">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="column_Left" style="width: 100%">
                                                <asp:Button ID="btnfurnitureledger" runat="server" Width="180px" CssClass="Initial" Text="Ledger"></asp:Button>
                                                <asp:Button ID="btnfurnitureRepairs" runat="server" Width="180px" CssClass="Initial" Text="Repairs and Maintenance"></asp:Button>
                                                <asp:Button ID="btnfurnitureAttachedDoc" runat="server" Width="180px" CssClass="Initial" Text="Document Attached"></asp:Button></td>
                                        </tr>
                                    </table>
                                </asp:View>



                                <asp:View ID="vwmachineries" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center" class="DivTitle" style="width: 100%">List Of Machineries</td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <span class="column_RightBold">Serial Number :</span>
                                                &nbsp;<asp:TextBox ID="txtMachinerySearch" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                &nbsp;<asp:Button ID="btnMachinerySerial" OnClick="btnMachinerySearch_Click" runat="server" Width="120px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <asp:GridView ID="grdpropertyListofmachinery" runat="server" Width="98%" SkinID="GridViewAA" OnPageIndexChanging="grdpropertyListofmachinery_PageIndexChanging"
                                                    AllowPaging="True" HorizontalAlign="Center" DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_ID,AcquisitionCost,Received_Date,Date_Accepted,useful_life,Received_Dtl_ID"
                                                    OnRowDataBound="grdpropertyListofmachinery_RowDataBound" OnSelectedIndexChanged="grdpropertyListofmachinery_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:BoundField DataField="Type" HeaderText="TYPE OF MACHINERY">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="barcode" HeaderText="SERIAL NO.">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="datepurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="acquisitioncost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MarketValue" HeaderText="MARKET VALUE">
                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Condition" HeaderText="CONDITION">
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Location" HeaderText="LOCATION">
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="status" HeaderText="STATUS">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="DivTitle" style="width: 100%">Details</td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Brand/Model :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblmachiniriesbrandmodel" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Unit No. :
                                                        </td>
                                                        <td class="column_Left" style="width: 25%">
                                                            <asp:Label ID="lblmachiniriesunitno" runat="server" Width="230px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td align="center" rowspan="10" style="width: 20%">
                                                            <asp:Image ID="Image8" runat="server" CssClass="textimage2" Height="180px" ImageAlign="Middle"
                                                                ImageUrl="~/images/blankImage.jpg" Width="90%" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Description :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblmachiniriesDesc" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Working Load :
                                                        </td>
                                                        <td class="column_Left" style="width: 25%">
                                                            <asp:Label ID="lblmachiniriesworkingload" runat="server" Width="230px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Location :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblmachinirieslocation" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Rated Speed :
                                                        </td>
                                                        <td class="column_Left" style="width: 25%">
                                                            <asp:Label ID="lblmachiniriesratedspeed" runat="server" Width="230px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">No. of Passengers :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblmachiniriesnoofpassenger" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Dimension :
                                                        </td>
                                                        <td class="column_Left" style="width: 25%">
                                                            <asp:Label ID="lblmachiniriescardimension" runat="server" Width="230px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Service Floors :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblmachiniriesservicefloor" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Useful Life :
                                                        </td>
                                                        <td class="column_Left" style="width: 25%">
                                                            <asp:Label ID="lblMULife" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Dep. Value :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%">
                                                            <asp:Label ID="lblmachiniriesdepriciatedvalue" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">No. of Years :
                                                        </td>
                                                        <td class="column_Left" style="width: 25%">
                                                            <asp:Label ID="lblMNoYears" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Dep. Rate :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%; height: 18px">
                                                            <asp:TextBox ID="lblmachiniriesdepreciatedrate" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" MaxLength="5" ReadOnly="True" OnTextChanged="lblmachiniriesdepreciatedrate_TextChanged"></asp:TextBox>&nbsp;(%) Percent</td>
                                                        <td class="column_RightBold" style="width: 10%; height: 18px"></td>
                                                        <td class="column_Left" style="width: 25%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Salvage Value :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%; height: 18px">
                                                            <asp:TextBox ID="txtMSalValue" runat="server" Width="100px" AutoPostBack="True" CssClass="txtboxAmount" OnTextChanged="txtMSalValue_TextChanged"></asp:TextBox></td>
                                                        <td class="column_RightBold" style="width: 10%; height: 18px"></td>
                                                        <td class="column_Left" style="width: 25%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">&nbsp;</td>
                                                        <td class="column_Left" style="width: 30%; height: 18px"></td>
                                                        <td class="column_RightBold" style="width: 10%; height: 18px">&nbsp;</td>
                                                        <td class="column_Left" style="width: 25%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Mech. Permit No. :</td>
                                                        <td class="column_Left" style="width: 30%; height: 18px">
                                                            <asp:Label ID="lblmachiniriesmechpermitno" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%; height: 18px">Date Inspected :
                                                        </td>
                                                        <td class="column_Left" style="width: 25%">
                                                            <asp:Label ID="lblmachiniriesdateinspected" runat="server" Width="240px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Date to Operate :&nbsp;</td>
                                                        <td class="column_Left" style="width: 30%; height: 18px">
                                                            <asp:Label ID="lblmachiniriesdatetooperate" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%; height: 18px">Inspected By :
                                                        </td>
                                                        <td class="column_Left" style="width: 25%">
                                                            <asp:Label ID="lblmachiniriesinspectedby" runat="server" Width="240px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td align="center" rowspan="1" style="width: 20%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%">Date Issued :
                                                        </td>
                                                        <td class="column_Left" style="width: 30%; height: 18px">
                                                            <asp:Label ID="lblmachiniriesdateissued" runat="server" Width="290px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%; height: 18px">Remarks :
                                                        </td>
                                                        <td class="column_Left" style="width: 25%">
                                                            <asp:Label ID="lblmachiniriesremarks" runat="server" Width="240px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td align="center" rowspan="1" style="width: 20%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 15%"></td>
                                                        <td class="column_Left" style="width: 30%; height: 18px"></td>
                                                        <td class="column_RightBold" style="width: 10%; height: 18px"></td>
                                                        <td class="column_Left" style="width: 25%"></td>
                                                        <td align="center" rowspan="1" style="width: 20%"></td>
                                                    </tr>
                                                </table>
                                                <asp:Label ID="lblMchneDateTaken" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label>
                                                <asp:Label ID="lblMchneUploadedBy" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label>
                                                <asp:Label ID="lblMchnePosition" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="column_Left" style="width: 100%">
                                                <asp:Button ID="btnmachineryLedger" runat="server" Width="180px" CssClass="Initial" Text="Ledger"></asp:Button>
                                                <asp:Button ID="btnmachineryRepairs" runat="server" Width="180px" CssClass="Initial" Text="Repairs and Maintenance"></asp:Button>
                                                <asp:Button ID="btnmachineryDocattach" runat="server" Width="180px" CssClass="Initial" Text="Document Attached"></asp:Button></td>
                                        </tr>
                                    </table>
                                </asp:View>




                                <asp:View ID="vwMotorVehicle" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center" class="DivTitle" style="width: 100%">List Of Vehicles</td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <span class="column_RightBold">Plate Number :</span>
                                                &nbsp;<asp:TextBox ID="txtMotorSerialSearch" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                &nbsp;<asp:Button ID="btnMotorSerialSearch" OnClick="btnMotorSerialSearch_Click" runat="server" Width="120px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <asp:GridView ID="grdlistofMotors" runat="server" Width="98%" SkinID="GridViewAA" OnPageIndexChanging="grdlistofMotors_PageIndexChanging" AllowPaging="True"
                                                    HorizontalAlign="Center" DataKeyNames="Property_ID,PropertyDetai_ID,Item_ID,PropertyNo,Received_Dtl_ID,Barcode"
                                                    OnRowDataBound="grdlistofMotors_RowDataBound" OnSelectedIndexChanged="grdlistofMotors_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:BoundField DataField="type" HeaderText="TYPE OF SERVICE">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Barcode" HeaderText="PLATE NO.">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DatePurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AcquisitionCost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MarketValue" DataFormatString="{0:N}" HeaderText="MARKET VALUE">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Condition" HeaderText="CONDITION">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Location" HeaderText="LOCATION">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Status" HeaderText="STATUS">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="DivTitle" style="width: 100%">Details</td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Name :
                                                        </td>
                                                        <td class="column_Left" style="width: 20%">
                                                            <asp:Label ID="lblvehiclename" runat="server" Width="190px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Model :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblvehiclemodel" runat="server" Width="140px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Wheel Capacity :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblvehiclewheelcapacity" runat="server" Width="140px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td align="center" rowspan="10" style="width: 20%">
                                                            <asp:Image ID="Image6" runat="server" CssClass="textimage2" Height="180px" ImageAlign="Middle"
                                                                ImageUrl="~/images/blankImage.jpg" Width="90%" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Plate No. :
                                                        </td>
                                                        <td class="column_Left" style="width: 20%">
                                                            <asp:Label ID="lblvehicleplate" runat="server" Width="190px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Chasis No. :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblvehiclechasisno" runat="server" Width="140px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Gross Weight :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblvehiclegrossweight" runat="server" Width="140px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Motor No. :
                                                        </td>
                                                        <td class="column_Left" style="width: 20%">
                                                            <asp:Label ID="lblvehiclemotorno" runat="server" Width="190px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Vehicle Color :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblvehiclecolor" runat="server" Width="140px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Seats :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblvehicleseat" runat="server" Width="140px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                                        <td class="column_Left" style="width: 20%"></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 15%"></td>
                                                        <td class="column_RightBold" style="width: 10%">Warranty :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblvehiclewarranty" runat="server" CssClass="column_Left" Width="140px"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Vehicle Owner :
                                                        </td>
                                                        <td class="column_Left" style="width: 20%">
                                                            <asp:Label ID="lblvehicleowner" runat="server" Width="190px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Benificial User :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblvehiclebeneficialuser" runat="server" Width="140px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 15%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Declared Name :
                                                        </td>
                                                        <td class="column_Left" style="width: 20%">
                                                            <asp:Label ID="lblvehicledeclaredname" runat="server" Width="190px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 15%"></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 15%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                                        <td class="column_Left" style="width: 20%"></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 15%"></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 15%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Specifications :
                                                        </td>
                                                        <td class="column_Left" colspan="5">
                                                            <asp:Label ID="lblvehiclespecification" runat="server" Width="600px" CssClass="text3"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">&nbsp;&nbsp;</td>
                                                        <td class="column_Left" colspan="5"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                                        <td class="column_Left" colspan="5"></td>
                                                    </tr>
                                                </table>
                                                <asp:Label ID="lblMotorDateTaken" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label>
                                                <asp:Label ID="lblMotorUploadedBy" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label>
                                                <asp:Label ID="lblMotorPosition" runat="server" Width="110px" CssClass="textimage2" Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="column_Left" style="width: 100%">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%" class="column_Left">
                                                <asp:Button ID="btnvehicleledger" runat="server" Width="180px" CssClass="Initial" Text="Ledger"></asp:Button>
                                                <asp:Button ID="btnvehiclerepairs" runat="server" Width="180px" CssClass="Initial" Text="Repairs and Maintenance"></asp:Button>
                                                <asp:Button ID="btnvehicledocattach" runat="server" Width="180px" CssClass="Initial" Text="Document Attached"></asp:Button></td>
                                        </tr>
                                    </table>
                                </asp:View>



                                <asp:View ID="vwLandDetails" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center" class="DivTitle" style="width: 100%">Land Information</td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td align="center" style="vertical-align: top; width: 75%; height: 100px; text-align: center"
                                                            class="panel_border">
                                                            <table style="width: 100%">
                                                                <tr>
                                                                    <td class="column_LeftBold" colspan="8" style="background-color: lightgrey">PROPERTY IDENTIFICATION 
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 15%">LGU Code : 
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblLguCode" runat="server" CssClass="column_Left" BorderStyle="None"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">District Code :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblDistrictCode" runat="server" CssClass="column_Left" BorderStyle="None"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">City Code :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblMunicipalCode" runat="server" CssClass="column_Left" BorderStyle="None"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">Brgy. Code :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblBrgyCode" runat="server" CssClass="column_Left" BorderStyle="None"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 15%">Section No. :</td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblSectionNo" runat="server" CssClass="column_Left" BorderStyle="None"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">Parcel No. :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblParcelNo" runat="server" CssClass="column_Left" BorderStyle="None"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">Series No. :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblSeriesNo" runat="server" CssClass="column_Left" BorderStyle="None"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">RPTIN :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblRptin" runat="server" CssClass="column_Left" BorderStyle="None"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 15%">PIN :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblPin" runat="server" CssClass="column_Left" BorderStyle="None"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">ARP :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblArp" runat="server" CssClass="column_Left" BorderStyle="None"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">Dep. Rate :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblDepRate" runat="server" CssClass="column_Left" BorderStyle="None"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%"></td>
                                                                    <td class="column_Left" style="width: 10%"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 15%">TDN :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblTdn" runat="server" CssClass="column_Left" BorderStyle="None"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">Rev Year :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblRevYear" runat="server" CssClass="column_Left" BorderStyle="None"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">Dep. Value :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblDepValue" runat="server" CssClass="column_Left" BorderStyle="None"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%"></td>
                                                                    <td class="column_Left" style="width: 10%"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td rowspan="2" style="width: 25%;" class="panel_border">
                                                            <asp:Image ID="LandImage" runat="server" Width="180px" ImageUrl="~/images/blankImage.jpg" Height="220px" ImageAlign="Middle"></asp:Image></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="vertical-align: top; width: 75%; height: 100px; text-align: center"
                                                            class="panel_border">
                                                            <table style="width: 100%">
                                                                <tr>
                                                                    <td class="column_LeftBold" colspan="8" style="background-color: lightgrey">LOCATION</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 15%">LOT No. :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblLotNo" runat="server" CssClass="column_Left" SkinID="LabelBorder"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">Street :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblStreetName" runat="server" CssClass="column_Left"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">Purok :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblPurok" runat="server" CssClass="column_Left"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">Phase No. :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblPhaseNo" runat="server" CssClass="column_Left"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 15%">Blk No. :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblBlkNo" runat="server" CssClass="text3" SkinID="LabelBorder"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">Subdivision :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblSubdivision" runat="server" CssClass="column_Left"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">Sitio :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblSitio" runat="server" CssClass="column_Left"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%"></td>
                                                                    <td class="column_Left" style="width: 10%"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 15%">Brgy. :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblBrgy" runat="server" CssClass="column_Left"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">City/Mun. :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblMunicipal" runat="server" CssClass="column_Left"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">Region :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblRegion" runat="server" CssClass="column_Left"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%"></td>
                                                                    <td class="column_Left" style="width: 10%"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="column_RightBold" style="width: 15%">District :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblDistrict" runat="server" CssClass="column_Left"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">Province :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblProvince" runat="server" CssClass="column_Left"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%">Zip Code :
                                                                    </td>
                                                                    <td class="column_Left" style="width: 10%">
                                                                        <asp:Label ID="lblZipCode" runat="server" CssClass="column_Left"></asp:Label></td>
                                                                    <td class="column_RightBold" style="width: 15%"></td>
                                                                    <td class="column_Left" style="width: 10%"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Label ID="lblLandDateTaken" runat="server" Visible="False"></asp:Label><asp:Label ID="lblLandUploadedBy" runat="server" Visible="False"></asp:Label><asp:Label ID="lblLandPosition" runat="server" Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%;" class="panel_border">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td class="column_LeftBold" colspan="8" style="background-color: lightgrey">CHARACTERISTICS 
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Classification :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblClassification" runat="server" CssClass="column_Left"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Sub Class :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblSubClass" runat="server" CssClass="column_Left"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Land Use :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblLandUse" runat="server" CssClass="column_Left"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Status :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblStatus1" runat="server" CssClass="column_Left"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Taxable :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblTaxable" runat="server" CssClass="column_Left"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Area :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblArea" runat="server" CssClass="column_Left"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 15%"></td>
                                                        <td class="column_RightBold" style="width: 10%">Status :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblStatus2" runat="server" CssClass="column_Left"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">&nbsp;</td>
                                                        <td class="column_Left" style="width: 15%"></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 15%"></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 15%"></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 15%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Assessed Value:</td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblAssessedValue" runat="server" CssClass="column_Left"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Market Value :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblMarketValue" runat="server" CssClass="column_Left"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Unit Value :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblUnitValue" runat="server" CssClass="column_Left"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 15%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Date :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblAVDate" runat="server" CssClass="column_Left"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Date :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblMVDate" runat="server" CssClass="column_Left"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Date :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblUVDate" runat="server" CssClass="column_Left"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 15%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="column_RightBold" style="width: 10%">Amount :</td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblAVAmount" runat="server" CssClass="column_Left"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Amount :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:Label ID="lblMVAmount" runat="server" CssClass="column_Left"></asp:Label></td>
                                                        <td class="column_RightBold" style="width: 10%">Assessment :
                                                        </td>
                                                        <td class="column_Left" style="width: 15%">
                                                            <asp:DropDownList ID="ddAssessmentLvl" runat="server" CssClass="column_Left" Width="100px"></asp:DropDownList></td>
                                                        <td class="column_RightBold" style="width: 10%"></td>
                                                        <td class="column_Left" style="width: 15%"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>


                                <asp:View ID="vwBldgDetails" runat="server">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 800px; height: 230px;">
                                                    <fieldset style="width: 780px; height: 214px" class="panel_border">
                                                        <br />
                                                        <table id="Table31" width="780">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 120px; height: 18px" class="column_LeftBold" align="left">Building Control No.</td>
                                                                    <td style="width: 7px; height: 18px">:</td>
                                                                    <td style="width: 247px" class="text3" align="left">
                                                                        <asp:Label ID="lblbuildingcontrolno" runat="server" Width="247px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                    <td style="width: 132px; height: 18px" class="column_LeftBold" align="left">Building Use</td>
                                                                    <td style="width: 2px; height: 18px">:</td>
                                                                    <td style="width: 180px" class="text3">
                                                                        <asp:Label ID="lblbuildinguse" runat="server" Width="180px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 120px" class="column_LeftBold" align="left">Building Code</td>
                                                                    <td style="width: 7px">:</td>
                                                                    <td style="width: 247px" class="text3" align="left">
                                                                        <asp:Label ID="lblbuildingCode" runat="server" Width="247px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                    <td style="width: 132px" class="column_LeftBold" align="left">Building Occupancy</td>
                                                                    <td style="width: 2px">:</td>
                                                                    <td style="width: 180px" class="text3">
                                                                        <asp:Label ID="lblbuildingoccupancy" runat="server" Width="180px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 120px" class="column_LeftBold" align="left">Building Name</td>
                                                                    <td style="width: 7px">:</td>
                                                                    <td style="width: 247px" class="text3" align="left">
                                                                        <asp:Label ID="lblbuildingname" runat="server" Width="247px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                    <td style="width: 132px" class="column_LeftBold" align="left">Number of Floors</td>
                                                                    <td style="width: 2px">:</td>
                                                                    <td style="width: 180px" class="text3">
                                                                        <asp:Label ID="lblbuildingnumberoffloors" runat="server" Width="180px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 120px" class="column_LeftBold" align="left">Address</td>
                                                                    <td style="width: 7px">:</td>
                                                                    <td style="width: 247px" class="text3" align="left">
                                                                        <asp:Label ID="lblbuildingaddress" runat="server" Width="247px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                    <td style="width: 132px" class="column_LeftBold" align="left">Avg. Area Per Floor</td>
                                                                    <td style="width: 2px">:</td>
                                                                    <td style="width: 180px" class="text3">
                                                                        <asp:Label ID="lblbuildingavgareaperfloor" runat="server" Width="180px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 120px" class="column_LeftBold" align="left">Postal Code</td>
                                                                    <td style="width: 7px">:</td>
                                                                    <td style="width: 247px" class="text3" align="left">
                                                                        <asp:Label ID="lblbuildingpostalcode" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                    <td style="width: 132px" class="column_LeftBold" align="left">Cost per Area</td>
                                                                    <td style="width: 2px">:</td>
                                                                    <td style="width: 180px" class="text3">
                                                                        <asp:Label ID="lblbuildingcostperarea" runat="server" Width="180px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 120px" class="column_LeftBold" align="left">Depreciation Rate</td>
                                                                    <td style="width: 7px">:</td>
                                                                    <td style="width: 247px" class="text3" align="left">
                                                                        <asp:Label ID="lblbuildingDepriciationrate" runat="server" Width="200px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                    <td style="width: 132px" class="column_LeftBold" align="left">Depreciated Value</td>
                                                                    <td style="width: 2px">:</td>
                                                                    <td style="width: 180px" class="text3">
                                                                        <asp:Label ID="lblbuildingdepreciatedvalue" runat="server" Width="180px" CssClass="text3" SkinID="Label" Font-Italic="False"></asp:Label></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </fieldset>
                                                </td>
                                                <td style="width: 200px; height: 230px;">
                                                    <fieldset style="width: 195px; height: 214px" class="panel_border">
                                                        <table style="width: 195px">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 191px; height: 141px" class="textimage2" colspan="2">
                                                                        <asp:Image ID="Image2" runat="server" Width="151px" ImageUrl="~/images/blankImage.jpg" CssClass="textimage2" Height="124px" ImageAlign="Middle"></asp:Image></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 80px" class="textimage2">Date Taken:</td>
                                                                    <td style="width: 111px" class="textimage2">
                                                                        <asp:Label ID="lblbuildingdatetaken" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 80px" class="textimage2">Uploaded By:</td>
                                                                    <td style="width: 111px" class="textimage2">
                                                                        <asp:Label ID="lblbuildinguploadedby" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 80px" class="textimage2">Position:</td>
                                                                    <td style="width: 111px" class="textimage2">
                                                                        <asp:Label ID="lblbuildingposition" runat="server" Width="110px" CssClass="textimage2" BorderStyle="Solid" BorderWidth="1px"></asp:Label></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </fieldset>
                                                </td>
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
                        <td style="width: 98%" align="center">
                            <asp:MultiView ID="mvledger" runat="server">
                                <asp:View ID="vwledger" runat="server">
                                    <table style="width: 100%">
                                        <tr style="display:none;">
                                            <td align="center" style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; font-weight: bold; font-size: 9pt; border-left: royalblue 1px solid; width: 67%; color: blue; border-bottom: royalblue 1px solid; font-family: Arial; height: 30px">
                                                <asp:Label ID="lblHistoryDetails" runat="server" Text="HISTORY DETAILS"></asp:Label></td>
                                            <td align="center" style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; font-weight: bold; font-size: 9pt; border-left: royalblue 1px solid; width: 11%; color: blue; border-bottom: royalblue 1px solid; font-family: Arial">DEBIT</td>
                                            <td align="center" style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; font-weight: bold; font-size: 9pt; border-left: royalblue 1px solid; width: 11%; color: blue; border-bottom: royalblue 1px solid; font-family: Arial">CREDIT</td>
                                            <td align="center" style="border-right: royalblue 1px solid; border-top: royalblue 1px solid; font-weight: bold; font-size: 9pt; border-left: royalblue 1px solid; width: 11%; color: blue; border-bottom: royalblue 1px solid; font-family: Arial">BALANCE</td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:HiddenField ID="hdnItemNo" runat="server" />
                                                <asp:Panel ID="Panel1" runat="server" CssClass="PanelSize" ScrollBars="Vertical"
                                                    Width="100%">
                                                    <asp:GridView ID="grdLedger1" runat="server" Width="100%" OnSelectedIndexChanged="grdrepairsandmaintenance_SelectedIndexChanged" SkinID="GridViewAA" HorizontalAlign="Center" Font-Size="8pt" OnDataBound = "OnDataBound">
                                                        <Columns>
                                                            <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Trans_Type" HeaderText="Particulars">
                                                                <ItemStyle HorizontalAlign="Left" Width="8%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ref" HeaderText="Ref No" Visible="false">
                                                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AccountablePerson" HeaderText="Accountable Person" Visible="false">
                                                                <ItemStyle HorizontalAlign="Left" Width="8%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Department" HeaderText="Office" Visible="false">
                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="acceptedby" HeaderText="Accepted By" Visible="false">
                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="inspectedby" HeaderText="Inspected By" Visible="false">
                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BalanceUnit" HeaderText="Unit" >
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                              <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText="Unit Price">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DebitQty" HeaderText="Debit Qty">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText="Debit Cost">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CreditQty" HeaderText="Credit Qty">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText="Credit Cost">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BalQty" HeaderText="Bal Qty">
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText="Bal Cost">
                                                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW"></asp:Button></td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwrepairsandmaintenance" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <asp:GridView ID="grdrepairsandmaintenance" runat="server" Width="100%" DataKeyNames="Property_Dtl_ID,RepairMaintenanceId" OnSelectedIndexChanged="grdrepairsandmaintenance_SelectedIndexChanged" SkinID="GridViewAA" HorizontalAlign="Center" Font-Size="9pt">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkPreview" runat="server" CausesValidation="False" Font-Size="10pt" Font-Names="Arial" Text="View Items" CommandName="Select" Font-Underline="False"></asp:LinkButton>
                                                            </ItemTemplate>

                                                            <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ServiceProvider" HeaderText="Service Provider">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NatureRepair" HeaderText="Nature of Repairs">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No.">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Total" DataFormatString="{0:N}" HeaderText="Amount">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    &nbsp;
                                </asp:View>
                                <asp:View ID="vwdocumentattachment" runat="server">
                                    <table style="height: 236px" width="1000">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; width: 800px; height: 236px" align="center">
                                                    <fieldset style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; width: 700px; padding-top: 5px; height: 223px" class="PanelBorder">
                                                        <legend><span style="font-size: 11pt; font-family: Calibri"><strong>DOCUMENT DETAILS</strong></span></legend>
                                                        <center>&nbsp;</center>
                                                        <center>
                                                            <asp:GridView ID="grdpropertydocdetails" runat="server" Width="650px" SkinID="gvnew" DataKeyNames="DocuId" OnRowDataBound="grdpropertydocdetails_RowDataBound" OnSelectedIndexChanged="grdpropertydocdetails_SelectedIndexChanged1" PageSize="5" Font-Size="9pt">
                                                                <Columns>
                                                                    <asp:BoundField DataField="DocumentName" HeaderText="Document Name"></asp:BoundField>
                                                                    <asp:BoundField DataField="DocumentNo" HeaderText="Document No."></asp:BoundField>
                                                                    <asp:BoundField DataField="ValidatedBy" HeaderText="Validated By"></asp:BoundField>
                                                                    <asp:BoundField DataField="DateValidated" DataFormatString="{0:d}" HeaderText="Date Validated"></asp:BoundField>
                                                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks"></asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </center>
                                                    </fieldset>
                                                </td>
                                                <td style="vertical-align: top; width: 200px; height: 236px" id="Td6" align="center">
                                                    <fieldset style="width: 255px; height: 232px" class="PanelBorder">
                                                        <legend><span style="font-size: 11pt; font-family: Calibri"><strong>ATTACHED DOCUMENTS</strong></span></legend>
                                                        <center>
                                                            <asp:Image ID="imgpropertydocs" runat="server" Width="204px" ImageUrl="~/images/DefaulScannedDocuments.jpg" Height="202px"></asp:Image></center>
                                                    </fieldset>
                                                </td>
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
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>



            <asp:Panel Style="display: none" ID="PanelRepair" runat="server" Width="900px">
                <table id="Table35" height="486" cellspacing="0" cellpadding="0" width="747" border="0">
                    <tbody>
                        <tr>
                            <td colspan="2">

                                <%-- <IMG height=1 alt="" src="../images/modalpopup_01.png" width=747 --%>/>
     
                            </td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_02.png); width: 772px; height: 39px"></td>
                            <td style="width: 34px; height: 39px">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/modalpopup_03.png"></asp:ImageButton></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_04.png); vertical-align: top; width: 772px" id="Td7"><span style="color: black">
                                <div style="text-align: center">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 5%" align="center"></td>
                                                <td style="width: 95%" align="center"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5%" align="center"></td>
                                                <td style="width: 95%" align="center">
                                                    <table style="width: 100%" id="Table10" class="strip">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 1000px; height: 5px; text-align: left"><strong>Repair and Maintenance Items :</strong></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5%" align="center"></td>
                                                <td style="width: 95%" align="center">
                                                    <table style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 23%" class="column_LeftBold">Property Description</td>
                                                                <td style="width: 2%" class="column_LeftBold">:</td>
                                                                <td style="width: 25%" class="text5">
                                                                    <asp:Label ID="lblPropertyDesc" runat="server" Width="100%"></asp:Label></td>
                                                                <td style="width: 23%" class="column_LeftBold">Property Number</td>
                                                                <td style="width: 2%" class="column_LeftBold">:</td>
                                                                <td style="width: 25%" class="text5">
                                                                    <asp:Label ID="lblPropertyNo" runat="server" Width="100%"></asp:Label></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5%" align="center"></td>
                                                <td style="width: 95%" align="center">
                                                    <asp:GridView ID="grdRepair" runat="server" Width="100%" PageSize="5" SkinID="gvnew" AllowPaging="True" OnPageIndexChanging="grdRepair_PageIndexChanging" Font-Size="9pt">
                                                        <Columns>
                                                            <asp:BoundField DataField="RepairItems" HeaderText="Item Description">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="price" HeaderText="Cost">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5%" align="center"></td>
                                                <td style="width: 95%" align="center">
                                                    <asp:Button ID="btnOK" OnClick="btnOK_Click" runat="server" Width="166px" Text="OK"></asp:Button>
                                                    <asp:Button ID="btnRPreview" runat="server" Width="166px" Text="Preview" Visible="False"></asp:Button></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </span>
                                <asp:Label ID="lblRepair" runat="server" Width="71px"></asp:Label></td>
                            <td style="background-image: url(../images/modalpopup_05.png); width: 34px; height: 446px"></td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblRepair" PopupControlID="PanelRepair"></cc1:ModalPopupExtender>
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

