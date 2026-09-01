<%@ Page Title="Encoding of Intangible Asset" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Encoding_IntangibleAsset.aspx.vb" Inherits="Inventory_Encoding_IntangibleAsset" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
        <script type="text/javascript">
        window.onbeforeunload = function (e) {
            var e = e || window.event;

            // For IE and FireFox
            var value = "There is some data to be saved!"

            if (e) {
                e.returnValue = value;
            }

            // For Safari
            return value;
        }

    </script>
    <script type="text/javascript">

        function NoOfYears(dateString) {
            var today = new Date();
            var birthDate = new Date(dateString);
            var age = today.getFullYear() - birthDate.getFullYear();
            var m = today.getMonth() - birthDate.getMonth();
            if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
                age--;
            }

            if (age < 0) {
                alert("Invalid of year")

            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_txtNoofYears").value = age;
            }

        }


        //Optimize this code
        function getDepValRate() {
            const year = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtNoofYears').value);
            const UL = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtUsefullife').value);

            const depval = Math.min(100, (year / UL) * 100);

            document.getElementById('ctl00_ContentPlaceHolder1_txtDepreciatedRate').value = depval.toFixed(2);

            const AcquisationCostVal = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtAcquisitionCost').value.replace(/\,/g, ''));
            const Salvagevalue = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtSalvageValue').value.replace(/\,/g, ''));

            let Depreciation = 0.00;
            if (AcquisationCostVal > 0 && Salvagevalue > 0 && UL > 0) {
                Depreciation = (AcquisationCostVal - Salvagevalue) / UL;
            }

            document.getElementById('ctl00_ContentPlaceHolder1_txtDepreciationValue').value = Depreciation.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

            const DepreciatedtVal = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_txtDepreciationValue').value.replace(/\,/g, ''));
            const DepreciatedValue = DepreciatedtVal > 0 ? AcquisationCostVal - DepreciatedtVal * year : 0;

            document.getElementById('ctl00_ContentPlaceHolder1_txtDepreciatedValue').value = DepreciatedValue.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        }


        function getSalVal(Double) {
            var AcquisationCostVal = document.getElementById("ctl00_ContentPlaceHolder1_txtAcquisitionCost").value;
            AcquisationCostVal = AcquisationCostVal.replace(/\,/g, '');
            AcquisationCostVal = parseInt(AcquisationCostVal, 10);
            var SalvageVal = AcquisationCostVal * 0.05

            document.getElementById("ctl00_ContentPlaceHolder1_txtSalvageValue").value = (SalvageVal).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        }


    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <style type="text/css">
        .required-label {
            position: relative;
            display: inline-block;
        }

        .required-label::before {
            content: "*";
            position: absolute;
            left: -9px;
            top: 0;
            color: Red;
            font-weight: bold;
        }
    </style>

    <script type="text/javascript">
        function StartProgressBar() {
            var progressPopup = $find('ProgressBarModalPopupExtender');

            if (progressPopup != null) {
                progressPopup.show();
            }
        }

        function BeginRequestHandler(sender, args) {
            var progressPopup = $find('ProgressBarModalPopupExtender');

            if (progressPopup != null) {
                progressPopup.show();
            }
        }

        function EndRequestHandler(sender, args) {
            var progressPopup = $find('ProgressBarModalPopupExtender');

            if (progressPopup != null) {
                progressPopup.hide();
            }
        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);

    </script>

    <script type="text/javascript">
        function preventPropertyInfoEnter(evt) {
            evt = evt || window.event;

            var keyCode = evt.keyCode || evt.which;

            if (keyCode == 13) {
                if (evt.preventDefault) {
                    evt.preventDefault();
                }

                evt.returnValue = false;
                return false;
            }

            return true;
        }
    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="100%">
                    <tr>
                        <td class="PageTitle" style="width: 98%">
                            <strong>
                                <asp:Label ID="lblClass" runat="server" Text="Encoding of Intangible Asset"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <table>
                            <table>
                                <!-- Hide Classification row -->
                                <tr style="display:none;">
                                    <td class="column_RightBold">Classification : </td>
                                    <td>
                                        <asp:DropDownList ID="ddClass" runat="server" CssClass="drpdownCSS" Width="200px"></asp:DropDownList>
                                    </td>
                                </tr>

                               <!-- General Account & Sub Classification on the same row -->
                                <tr>
                                    <td class="column_RightBold">&nbsp; &nbsp;
                                        <span class="required-label">General Account :</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddGA"
                                            runat="server"
                                            CssClass="drpdownCSS"
                                            Width="200px"
                                            AutoPostBack="True" >
                                        </asp:DropDownList>
                                    </td>

                                    <td style="width:20px;"></td>

                                    <td class="column_RightBold">
                                        <span>Sub Classification :</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpSubClassification"
                                            runat="server"
                                            CssClass="drpdownCSS"
                                            Width="200px"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>


                        </td>

                    </tr>

                    <tr>
                        <td align="center" style="width: 100%">
                            <asp:HiddenField ID="hdnItemNo" runat="server" />
                            <asp:HiddenField ID="hdnGAId" runat="server" />
                            <asp:HiddenField ID="hf_PropertyDetai_ID" runat="server" />
                            <asp:HiddenField ID="hf_Property_ID" runat="server" />
                            <asp:HiddenField ID="hf_Ledger_ID" runat="server" />
                        </td>


                    </tr>

                    <tr>
                        <td align="center" class="DivTitle" style="width: 100%">INTANGIBLE ASSET INFORMATION 
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="">

                                <tr>
                                    <td style="width: 145px" class="column_RightBold">&nbsp;</td>
                                    <td style="width: 145px" class="column_Left"></td>
                                    <td style="width: 145px"></td>
                                    <td style="width: 145px"></td>
                                    <td style="width: 145px"></td>
                                    <td style="width: 145px"></td>
                                    <td style="width: 145px"></td>
                                </tr>
                                <tr>
                                       <td style="width: 145px" class="column_RightBold"><span class="required-label">Name :</span></td>
                                        <td style="width: 145px">
                                        <asp:DropDownList ID="ddName" runat="server" Width="100%" CssClass="drpdownCSS"
                                            AutoPostBack="true"
                                            OnSelectedIndexChanged="ddName_SelectedIndexChanged"  >
                                        </asp:DropDownList>
                                        </td>
                                    
                                      <td style="width: 145px" class="column_RightBold"> <span class="required-label">No. of Disc :</span> </td>
                                    <td style="width: 145px">
                                        <asp:TextBox ID="txtNoOfDisc"  AutoPostBack="True" CssClass="txtbox_Var" runat="server"></asp:TextBox></td>

                                    <td style="width: 145px"></td>
                                    <td style="width: 145px"></td>
                                    <td style="width: 145px"></td>
                                </tr>
                                 <tr>
                                     <td style="width: 145px" class="column_RightBold">Title :</td>
                                    <td style="width: 145px" class="column_Left">
                                        <asp:TextBox ID="txtTitle" AutoPostBack="True"  runat="server" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>


                                    <td style="width: 145px" class="column_RightBold">Unit : </td>
                                    <td style="width: 145px">
                                        <asp:DropDownList ID="txtUnit"  AutoPostBack="True"  runat="server" Width="100%" Enabled="false" CssClass="drpdownCSS" ></asp:DropDownList>
                                    <td style="width: 145px"></td>
                                    <td style="width: 145px"></td>
                                    <td style="width: 145px"></td>
                                </tr>

                                <tr>
                                      <td style="width: 145px" class="column_RightBold">Description :</td>
                                    <td style="width: 145px" class="column_Left">
                                        <asp:TextBox ID="txtDescription"  AutoPostBack="True" runat="server" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>

                                  

                                    <td style="width: 145px; height: 23px;" class="column_RightBold">Model :</td>
                                    <td style="width: 145px; height: 23px;">
                                        <asp:TextBox ID="txtModel" AutoPostBack="True"  CssClass="txtbox_Var" runat="server"></asp:TextBox></td>

                                    <td style="width: 145px"></td>
                                    <td style="width: 145px"></td>
                                    <td style="width: 145px"></td>
                                </tr>


                                <tr>
                                    <td style="width: 145px; height: 23px;" class="column_RightBold">Brand :</td>
                                    <td style="width: 145px; height: 23px;" class="column_Left">
                                        <asp:TextBox ID="txtBrand"  AutoPostBack="True" runat="server" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>


                             
                                    <td style="width: 145px" class="column_RightBold">Remarks. :</td>
                                    <td style="width: 145px">
                                      <asp:TextBox ID="txtRemarks"  AutoPostBack="True" runat="server" Width="95%" CssClass="txtbox_Var"
                                            TextMode="MultiLine" Rows="3"></asp:TextBox>


                                    <td style="width: 145px; height: 23px;"></td>
                                    <td style="width: 145px; height: 23px;" colspan="2" rowspan="4">
                                        <asp:Image ID="imgpropertydocs" runat="server" Height="202px" ImageUrl="~/images/blankImage.jpg" Width="204px" />
                                        <asp:Button ID="btnUpload" runat="server" OnClientClick="StartProgressBar();" CssClass="CSButton" Text="UPLOAD" Enabled="false" Width="120px" />
                                    </td>

                                </tr>
                                <tr>
                                    <td style="width: 145px" class="column_RightBold">License Duration :</td>
                                    <td style="width: 145px" class="column_Left">
                                        <asp:TextBox ID="txtLicenceDuration" AutoPostBack="True"  CssClass="txtbox_Var" runat="server"></asp:TextBox>
                                
                                    </td>
                                    <td style="width: 145px" class="column_RightBold"></td>
                                   <td style="width: 145px"> 
                                        <asp:LinkButton ID="lnkAddPropertyNumber"
                                            runat="server"
                                            Text="Add Property Number"
                                           
                                             CssClass="CSLink required-label"
                                            CausesValidation="false"
                                            OnClick="lnkAddPropertyNumber_Click" />

                                    </td>

                                    <td style="width: 145px"></td>
                                </tr>

                              
    <td colspan="5">
        <table width="100%" style="margin-top: 10px; table-layout: fixed;">
            <tr>
                <td class="column_RightBold"
                    style="width: 115px; vertical-align: top;">
                    Specifications :
                </td>

                <td class="column_Left">
                    <asp:TextBox ID="txtSpecification"
                        AutoPostBack="True"
                        runat="server"
                        Width="95%"
                        Height="25px"
                        TextMode="MultiLine"
                        CssClass="txtbox_Var"
                        Rows="3">
                    </asp:TextBox>
                </td>
            </tr>
        </table>
    </td>

    <td></td>
    <td></td>
</tr>

                                <tr>
                                    <td colspan="5">
                                        <fieldset>
                                            <legend class="column_LeftBold">Acquisition :</legend>
                                            <table>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 115px"><span class="required-label">Acquisition Date :</span></td>
                                                    <td class="column_Left" style="width: 250px">
                                                        <asp:TextBox ID="txtAcquisitionDate" runat="server" CssClass="txtbox_Var" onchange="return NoOfYears(this.value);"  ></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtAcquisitionDate" PopupButtonID="txtAcquisitionDate"></cc1:CalendarExtender>
                                                        &nbsp;MM/DD/YYYY</td>
                                                    <td class="column_RightBold" style="width: 150px">Market Value :</td>
                                                    <td class="column_Left" style="width: 100px">
                                                        <asp:TextBox ID="txtMarketValue" AutoPostBack="True"  runat="server" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 115px"><span class="required-label">Acquisition Cost :</span></td>
                                                    <td class="column_Left" style="width: 250px">
                                                        <asp:TextBox ID="txtAcquisitionCost"  AutoPostBack="True" runat="server" CssClass="txtbox_Var" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value); return getSalVal(this),getDepValRate(this);"  ></asp:TextBox></td>
                                                    <td class="column_RightBold" style="width: 150px">No. of Years :</td>
                                                    <td class="column_Left" style="width: 100px">
                                                        <asp:TextBox ID="txtNoofYears" AutoPostBack="True"  runat="server" CssClass="txtbox_Var" Width="75px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 115px">Depreciated Rate :</td>
                                                    <td class="column_Left" style="width: 250px">
                                                        <asp:TextBox ID="txtDepreciatedRate" AutoPostBack="True"  runat="server" CssClass="txtbox_Var" Width="75"></asp:TextBox>
                                                        &nbsp;(%)Percent</td>
                                                    <td class="column_RightBold" style="width: 150px">Useful Life :</td>
                                                    <td class="column_Left" style="width: 100px">
                                                        <asp:TextBox ID="txtUsefullife" AutoPostBack="True" Enabled="false" runat="server" CssClass="txtbox_Var" Width="75px" onchange="return getDepValRate(this);"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 115px">Depreciated Value :</td>
                                                    <td class="column_Left" style="width: 250px">
                                                        <asp:TextBox ID="txtDepreciatedValue" AutoPostBack="True"  runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                                    <td class="column_RightBold" style="width: 150px">Salvage Value :</td>
                                                    <td class="column_Left" style="width: 100px">
                                                        <asp:TextBox ID="txtSalvageValue"  AutoPostBack="True" runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                                </tr>

                                                <tr>
                                                    <td class="column_RightBold" style="width: 115px">Depreciation Value :</td>
                                                    <td class="column_Left" style="width: 250px">
                                                        <asp:TextBox ID="txtDepreciationValue" AutoPostBack="True"  runat="server" CssClass="txtbox_Var"></asp:TextBox></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>

                                            </table>
                                        </fieldset>


                                    </td>
                                    <%-- <td colspan="2">
                                 
                                                 
                                      
                                  </td>--%>
                                </tr>
                                <%-- <tr>
                                  <td colspan="5"></td>
                                  <td>&nbsp;</td>
                                  <td>&nbsp;</td>
                              </tr>--%>
                                <tr>
                                    <td colspan="5">
                                        <fieldset>
                                            <legend class="column_LeftBold">Warehouse :</legend>
                                            <table>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 75px">Warehouse :</td>
                                                    <td class="column_Left">
                                                        <asp:DropDownList ID="drpWarehouse" runat="server" Width="150px"></asp:DropDownList></td>
                                                    <td class="column_RightBold" style="width: 75px">Bay :</td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtBay" AutoPostBack="True"  runat="server" CssClass="txtbox_Var" Width="85px"></asp:TextBox></td>
                                                    <td class="column_RightBold" style="width: 75px">Column :</td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtColumn" AutoPostBack="True"  runat="server" CssClass="txtbox_Var" Width="85px"></asp:TextBox></td>
                                                    <td class="column_RightBold" style="width: 75px">Floor :</td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtFloor"  AutoPostBack="True" runat="server" CssClass="txtbox_Var" Width="85px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="column_RightBold" style="width: 75px">Room :</td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtRoom"  AutoPostBack="True" runat="server" CssClass="txtbox_Var" Width="85px"></asp:TextBox></td>
                                                    <td class="column_RightBold" style="width: 75px">Shelves :</td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtShelves" AutoPostBack="True"  runat="server" CssClass="txtbox_Var" Width="85px"></asp:TextBox></td>
                                                    <td class="column_RightBold" style="width: 75px">Rack :</td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtRack"  AutoPostBack="True" runat="server" CssClass="txtbox_Var" Width="85px"></asp:TextBox></td>
                                                    <td class="column_RightBold" style="width: 75px">Bin :</td>
                                                    <td class="column_Left">
                                                        <asp:TextBox ID="txtBin"  AutoPostBack="True" runat="server" CssClass="txtbox_Var" Width="85px"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </fieldset>

                                      

                                    </td>
                                    <td style="vertical-align: text-top">
                                        <asp:Button ID="btnSave" runat="server"  CssClass="CSButton" Text="SAVE" Width="95%" />
                                    </td>
                                    <td style="vertical-align: text-top">
                                        <asp:Button ID="btnCancel0" runat="server" OnClientClick="StartProgressBar();" CssClass="CSButton" Text="CANCEL" Width="95%" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <asp:GridView ID="grdLedger1" runat="server" Width="100%" AllowPaging="True" SkinID="GridViewAA" HorizontalAlign="Center" OnPageIndexChanging="grdLedger1_PageIndexChanging" Font-Size="8pt" OnDataBound="OnDataBound"
    DataKeyNames="Item_ID,Property_ID,Ledger_ID">
                                <%--OnSelectedIndexChanged="grdrepairsandmaintenance_SelectedIndexChanged" OnRowDataBound="grdLedger1_RowDataBound"--%>
                                <Columns>

                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                          
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbInspection" runat="server" AutoPostBack="True" OnCheckedChanged="cbInspection_CheckedChanged"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="Date">
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Trans_Type" HeaderText="Particulars">
                                        <ItemStyle HorizontalAlign="Left" Width="46%" />
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
                                    <asp:BoundField DataField="BalanceUnit" HeaderText="Ref No.">
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UnitPrice" DataFormatString="{0:N}" HeaderText="Unit Price" Visible="false">
                                        <ItemStyle HorizontalAlign="Right" Width="7%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DebitQty" HeaderText="Debit Qty" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DebitCost" DataFormatString="{0:N}" HeaderText="DebitCost">
                                        <ItemStyle HorizontalAlign="Right" Width="7%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CreditQty" HeaderText="Credit Qty" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CreditCost" DataFormatString="{0:N}" HeaderText="CreditCost">
                                        <ItemStyle HorizontalAlign="Right" Width="7%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BalQty" HeaderText="Bal Qty" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BalCost" DataFormatString="{0:N}" HeaderText="BalCost">
                                        <ItemStyle HorizontalAlign="Right" Width="7%" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>

                        </td>
                    </tr>

                </table>
            </div>
            <!-- ===== Progress (hidden) ===== -->

            <asp:Panel ID="PanelProgress" runat="server"
                Style="border:1px solid #0033cc; position:relative; background-color:transparent; text-align:center;"
                Width="109px">
                <img alt="Loading..." src="../images/ajax-loader.gif" />
            </asp:Panel>

            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender"
                runat="server"
                BehaviorID="ProgressBarModalPopupExtender"
                BackgroundCssClass="modalBackground"
                PopupControlID="PanelProgress"
                TargetControlID="ButtonProgress" />

            <asp:Button ID="ButtonProgress" runat="server"
                Style="display: none; border:none; position:relative; background-color:transparent;"
                Width="16px" Enabled="false" />

            <!-- ===== Property Information Modal (hidden) ===== -->
            <!-- Hidden trigger (call ModalPopup_PropertyInfo.Show() in code-behind later if needed) -->
            <asp:LinkButton ID="btnShowPropertyInfo" runat="server" Style="display:none;"></asp:LinkButton>

            <cc1:ModalPopupExtender ID="ModalPopup_PropertyInfo" runat="server"
                TargetControlID="btnShowPropertyInfo"
                PopupControlID="pnlPropertyInfo"
                CancelControlID="btnClosePropertyInfo"
                BackgroundCssClass="modalBackground" />

            <asp:Panel ID="pnlPropertyInfo" runat="server" CssClass="Panel_Popup">
                <table style="width:100%;">
                    <tr>
                        <td class="DivTitle" style="height:30px;">PROPERTY INFORMATION</td>
                    </tr>

                    <tr>
                        <td>
                            <asp:GridView ID="grdPropertyInfo" runat="server"
                                SkinID="gvnew"
                                AutoGenerateColumns="false"
                                Width="680px"
                                ShowHeader="true"
                                ShowHeaderWhenEmpty="true"
                                DataKeyNames="PropertyDetai_ID"
                                OnRowDataBound="grdPropertyInfo_RowDataBound"
                                 onkeydown="return preventPropertyInfoEnter(event);">

                                <Columns>
                                    <asp:TemplateField HeaderText="Property No.">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPropertyNo" runat="server" Width="150px"
                                                Text='<%# Bind("PropertyNo") %>'
                                                AutoPostBack="true"
                                                OnTextChanged="txtPropertyNo_TextChanged"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Serial No.">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSerialNoIntangAsset" runat="server" AutoPostBack="true" OnTextChanged="txtSerialNoIntangAsset_TextChanged" Width="150px"
                                                Text='<%# Bind("SerialNo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Installed At" ItemStyle-Width="19%">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="drpInstalledIntangAsset" 
                                                runat="server" 
                                                Width="150px"
                                                AutoPostBack="true" 
                                                OnSelectedIndexChanged="drpInstalledIntangAsset_SelectedIndexChanged" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Location" ItemStyle-Width="19%">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPIFloorLocation" runat="server" Width="250px"
                                                Text='<%# Bind("FloorLocation") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>


                        </td>
                    </tr>

                    <tr>
                        <td style="padding-top:8px;">
                            <asp:Button ID="btnProceedEdit" runat="server" Width="150px" CssClass="CSButton" Text="PROCEED" />
                            <asp:Button ID="btnClosePropertyInfo" runat="server" Width="150px" CssClass="CSButton" Text="CLOSE" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>






            <!-- ===== APPROVAL MODAL ===== -->
<asp:Label ID="lblApprovalTarget"
    runat="server"
    Style="display: none;">
</asp:Label>

<cc1:ModalPopupExtender ID="ModalPopupExtender_Approval"
    runat="server"
    TargetControlID="lblApprovalTarget"
    PopupControlID="pnlApproval"
    CancelControlID="btnCancelApproval"
    BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnlApproval" runat="server" Width="350px" CssClass="Panel_Popup"  DefaultButton="btnProceedApproval">
    <table width="100%">
        <tr>
            <td style="width: 100%; height: 30px" colspan="2" class="DivTitle">
                APPROVAL
            </td>
        </tr>
        <tr>      
            <td class="column_RightBold" style="width: 40%">Approving Officer :</td>
            <td class="column_Left">
                <asp:DropDownList ID="drpApprovedOfficer" runat="server" Width="180px" CssClass="drpdownCSS"></asp:DropDownList>
            </td>
        </tr>
        <tr>      
            <td class="column_RightBold">Password :</td>
            <td class="column_Left">
                <asp:TextBox ID="txtApprovedPass" runat="server" CssClass="txtbox_Var" Width="180px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center; padding-top: 10px;">
                <asp:Button ID="btnProceedApproval" runat="server" Width="120px" CssClass="CSButton" Text="PROCEED" ></asp:Button>
                <asp:Button ID="btnCancelApproval" runat="server" Width="120px" CssClass="CSButton"   CausesValidation="False" Text="CANCEL"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Panel>






        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
