<%@ Page Language="VB" EnableEventValidation="false" ValidateRequest="false" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="t_inspection_and_acceptance_v2.aspx.vb" Inherits="t_inspection_and_acceptance_v2" StylesheetTheme ="SkinFile" Title="Inspection And Acceptance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 
 
 
 
 <asp:Content ID="Contetnt1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table width="1015px" style="text-align:center">
<tr>
<td width="1015px" style="text-align:center">

 
  
<script language="javascript" type="text/javascript">

function Table2_onclick() {

}

function fun1(e, button1){
          var evt = e ? e : window.event;
          var bt = document.getElementById(button1);
          if (bt){
              if (evt.keyCode == 13){
                    bt.click();
                    return false;
              }
          }
    }

function Table6_onclick() {

}

function DIV1_onclick() {

}
</script> 


<script type="text/javascript">

 function HandleBrowseClick2()
{
    var fileinput2 = document.getElementById("flAttachDoc1");
    fileinput2.click();
}

function Handlechange2()
{
    var fileinput2 = document.getElementById("flAttachDoc1");
    var hiddenControl2 = '<%= hdfAttachDoc1.ClientID %>';
    document.getElementById(hiddenControl2).value= fileinput2.value ;
}
 
 
 function BrowseAttachdoc2()
{
    var fileAttachdocument = document.getElementById("flAttachDoc2");
    fileAttachdocument.click();
}
 
 function handlesAttachdoc2()
{    
    var fileAttachdocument = document.getElementById("flAttachDoc2");
    var hiddenControlattacchdoc2 = '<%= hdfAttachDoc2.ClientID %>';
    document.getElementById(hiddenControlattacchdoc2).value= fileAttachdocument.value ;
}

  
  
function HandleBrowseClick()
{
    var fileinput = document.getElementById("flbuilding");
    fileinput.click();
}

function Handlechange()
{
    var fileinput = document.getElementById("flbuilding");
    var hiddenControl = '<%= hdfbuilding.ClientID %>';
    document.getElementById(hiddenControl).value= fileinput.value ;
} 
 
 
</script>

    <table class="PageTitle">
        <tr>
            <td style="width: 1000px">
                &nbsp;INSPECTION AND ACCEPTANCE</td>
        </tr>
    </table>

 </td>
 </tr>
 </table>

<asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:UpdatePanel id="UpdatePanel1" runat="server">      
<contenttemplate>
<TABLE style="WIDTH: 1000px; TEXT-ALIGN: center"><TBODY><TR><TD align=center colSpan=5><TABLE><TBODY><TR><TD style="WIDTH: 100px" class="column_RightBold">Search By&nbsp;:</TD><TD style="WIDTH: 100px" class="text5"><asp:DropDownList id="Drpsearch" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="Drpsearch_SelectedIndexChanged"><asp:ListItem Value="1">Category</asp:ListItem>
<asp:ListItem Value="2">Purchase Order</asp:ListItem>
<asp:ListItem Value="3">Purchase Request</asp:ListItem>
<asp:ListItem Value="4">ALL</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px" class="column_RightBold"><asp:RadioButtonList id="RadioButtonList3" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged" __designer:wfdid="w1" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="3">CO</asp:ListItem>
<asp:ListItem Value="2">MOOE</asp:ListItem>
</asp:RadioButtonList></TD><TD style="WIDTH: 100px" class="text5"><asp:DropDownList id="ddCategories" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddCategories_SelectedIndexChanged"></asp:DropDownList></TD><TD style="WIDTH: 100px" class="column_RightBold"><asp:Label id="lblSearch" runat="server" Width="150px" Font-Size="10pt" Font-Names="Ararial"></asp:Label></TD><TD style="WIDTH: 100px" class="text5"><asp:TextBox id="txtPOsearch" runat="server" Width="150px" MaxLength="4"></asp:TextBox></TD><TD style="WIDTH: 100px" class="text5"><asp:Button id="btnSearchPO" onclick="btnSearchPO_Click" runat="server" Width="100px" Text="Search"></asp:Button></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="TEXT-ALIGN: center" class="text6" align=center colSpan=5><asp:GridView style="FONT-WEIGHT: normal; TEXT-ALIGN: justify" id="grdInspection" runat="server" Width="1000px" DataKeyNames="GA_ID,POHdr_ID,PO_Amount,SuppName,RC_ID,Function_ID" SkinID="GridViewGL" HorizontalAlign="Center" AllowPaging="True" PageSize="8" OnPageIndexChanging="grdInspection_PageIndexChanging">
<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

<RowStyle BorderColor="Black" BorderStyle="None"></RowStyle>

<EmptyDataRowStyle BorderColor="Gray" BorderStyle="Solid"></EmptyDataRowStyle>
<Columns>
<asp:BoundField DataField="pr_no" HeaderText="PR No.">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="80px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ReqDept" HeaderText="Requesting Dept">
<ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="OBR_No" HeaderText="OBR No.">
<ItemStyle Width="90px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SuppName" HeaderText="Supplier">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ProjectName" HeaderText="Project Name">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PO_No" HeaderText="PO No.">
<ItemStyle Width="80px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PO_Date" HeaderText="PO Date">
<ItemStyle Width="80px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PO_Amount" DataFormatString="{0:N}" HeaderText="PO Amount">
<ItemStyle HorizontalAlign="Right" Width="75px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="dvno" HeaderText="DV No.">
<ItemStyle Width="70px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="checkno" HeaderText="Check No.">
<ItemStyle Width="70px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="amountpaid" DataFormatString="{0:N}" HeaderText="Amount Paid">
<ItemStyle HorizontalAlign="Right" Width="75px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="jevno" HeaderText="JEV No.">
<ItemStyle Width="70px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RespCenter" HeaderText="RespCenter" Visible="False"></asp:BoundField>
</Columns>

<FooterStyle BackColor="#669933"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BorderColor="Gray" BorderStyle="None"></PagerStyle>

<SelectedRowStyle BorderColor="Transparent"></SelectedRowStyle>

<HeaderStyle BorderColor="Transparent" BorderStyle="Dotted"></HeaderStyle>

<EditRowStyle BorderColor="White"></EditRowStyle>
</asp:GridView></TD></TR><TR><TD class="text6" align=center colSpan=5><TABLE style="WIDTH: 1000px" id="Table4" class="strip"><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: left"><STRONG style="FONT-FAMILY: Arial"><SPAN style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; FONT-FAMILY: verdana; TEXT-ALIGN: left">Inspection and Acceptance Information</SPAN></STRONG></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="TEXT-ALIGN: center" class="text6" align=center colSpan=5><FIELDSET style="WIDTH: 490px; HEIGHT: 165px" class="PanelBorder"><LEGEND><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: Verdana"><STRONG>Inspection and Acceptance Details</STRONG></SPAN></LEGEND><TABLE style="HEIGHT: 80px" id="tbpurchaseorderdetails" width=490><TBODY><TR><TD style="WIDTH: 90px; HEIGHT: 16px" class="column_LeftBold" align=right></TD><TD style="WIDTH: 160px" class="text5" align=left></TD><TD style="WIDTH: 90px" class="column_LeftBold" align=right></TD><TD style="WIDTH: 160px" class="text5" align=left></TD></TR><TR><TD style="WIDTH: 90px; HEIGHT: 16px" class="column_LeftBold" align=right>Supplier :</TD><TD style="WIDTH: 160px" class="text5" align=left><asp:TextBox id="txtsupplier" runat="server" Width="170px" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 90px" class="column_LeftBold" align=right>Date :</TD><TD style="WIDTH: 160px" class="text5" align=left><asp:TextBox id="txtInvoiceDate" runat="server" Width="116px" __designer:wfdid="w2" CssClass="txtboxinspection"></asp:TextBox><asp:ImageButton id="imgbtnAirDate" runat="server" Width="20px" ImageUrl="~/images/CalendarImage.jpg" __designer:wfdid="w3" Enabled="False" Height="16px"></asp:ImageButton></TD></TR><TR><TD style="WIDTH: 90px; HEIGHT: 16px" class="column_LeftBold" align=right>PO Number :</TD><TD style="WIDTH: 160px" class="text5" align=left><asp:Label id="txtPOnum" runat="server" Width="170px" CssClass="txtboxinspection"></asp:Label></TD><TD style="WIDTH: 90px" class="column_LeftBold" align=right>Invoice No :</TD><TD style="WIDTH: 160px" class="text5" align=left><asp:TextBox id="txtinvoiceNo" runat="server" Width="145px" __designer:wfdid="w5" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 90px; HEIGHT: 16px" class="column_LeftBold" align=right>PO Date :</TD><TD style="WIDTH: 160px" class="text5" align=left><asp:TextBox id="txtpoDate" runat="server" Width="116px" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 90px" class="column_LeftBold" align=right>Remarks :</TD><TD style="WIDTH: 160px" class="text5" align=left><asp:TextBox id="txtremaks" runat="server" Width="145px" __designer:wfdid="w6" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 90px" class="column_LeftBold" align=right>Department :</TD><TD style="WIDTH: 90px" class="text5" align=left><asp:TextBox id="txtdepartment" runat="server" Width="170px" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 90px" class="column_LeftBold"></TD><TD style="WIDTH: 90px" class="text5" rowSpan=1><asp:Label id="lblairno" runat="server" Width="145px" __designer:wfdid="w1" CssClass="txtboxinspection" Visible="False"></asp:Label></TD></TR><TR><TD style="WIDTH: 90px; HEIGHT: 16px" class="column_LeftBold"></TD><TD style="TEXT-ALIGN: left" class="column_RightBold" align=left colSpan=3><asp:TextBox id="txtLocation" runat="server" Width="230px" CssClass="txtboxinspection" Visible="False"></asp:TextBox> <asp:Label id="lblLoc" runat="server" Width="84px" ForeColor="Red" Font-Size="Smaller" Text="* Required" Visible="False" Font-Italic="True"></asp:Label><BR /><asp:Label id="PropNo" runat="server" Width="145px" CssClass="txtboxinspection" Visible="False"></asp:Label> <cc1:CalendarExtender id="CalendarExtender2" runat="server" __designer:wfdid="w4" TargetControlID="txtInvoiceDate"></cc1:CalendarExtender></TD></TR></TBODY></TABLE></FIELDSET><FIELDSET style="WIDTH: 490px; HEIGHT: 165px" class="PanelBorder"><LEGEND><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: Verdana"><STRONG>EXPIRY DETAILS</STRONG></SPAN></LEGEND><TABLE id="tbepirydetails" width=490><TBODY><TR><TD style="WIDTH: 90px" class="column_RightBold" align=right>Name :</TD><TD style="WIDTH: 160px" class="text5"><asp:TextBox id="txtMedName" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 90px" class="column_RightBold" align=right>Mftg Date :</TD><TD style="WIDTH: 160px" class="text5" align=left><asp:TextBox id="txtMedMftgdate" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox> <asp:ImageButton id="imgbtnMFTGDate" runat="server" Width="20px" ImageUrl="~/images/CalendarImage.jpg" Enabled="False" Height="16px"></asp:ImageButton> <cc1:CalendarExtender id="CalendarExtender4" runat="server" TargetControlID="txtMedMftgdate"></cc1:CalendarExtender></TD></TR><TR><TD style="WIDTH: 90px" class="column_RightBold" align=right>Dose :</TD><TD style="WIDTH: 160px" class="text5"><asp:TextBox id="txtMedDose" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 90px" class="column_RightBold" align=right>Batch :</TD><TD style="WIDTH: 160px" class="text5" align=left><asp:TextBox id="txtMedBatch" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox> <asp:Label id="lblBatch" runat="server" Width="84px" ForeColor="Red" Font-Size="Smaller" Text="* Required" Visible="False" Font-Italic="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 90px" class="column_RightBold" align=right>Form :</TD><TD style="WIDTH: 160px" class="text5"><asp:TextBox id="txtMedForm" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 90px" class="column_RightBold" align=right>Lot :</TD><TD style="WIDTH: 160px" class="text5" align=left><asp:TextBox id="txtMedLot" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 90px" class="column_RightBold" align=right>OTC/RX :</TD><TD style="WIDTH: 160px" class="text5"><asp:TextBox id="txtMedOTCRX" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 90px" class="column_RightBold"></TD><TD style="WIDTH: 160px" class="text5" align=left></TD></TR><TR><TD style="WIDTH: 90px" class="column_RightBold" align=right><SPAN style="FONT-SIZE: 8pt">Expiry Date <SPAN style="FONT-SIZE: 9pt">:</SPAN></SPAN></TD><TD style="WIDTH: 160px" class="text5"><asp:TextBox id="txtMedExpiredDate" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox> <asp:ImageButton id="imgbtnExpDate" runat="server" Width="20px" ImageUrl="~/images/CalendarImage.jpg" Enabled="False" Height="16px"></asp:ImageButton> <asp:Label id="lblrequiredfield" runat="server" Width="84px" ForeColor="Red" Font-Size="Smaller" Text="* Required" Visible="False" Font-Italic="True"></asp:Label> <cc1:CalendarExtender id="CalendarExtender3" runat="server" TargetControlID="txtMedExpiredDate"></cc1:CalendarExtender></TD><TD style="WIDTH: 90px" class="column_RightBold">Alert :</TD><TD style="WIDTH: 160px" class="text5" align=left><asp:TextBox id="txtMedAlertDate" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox> <asp:ImageButton id="imgbtnAlert" runat="server" Width="20px" ImageUrl="~/images/CalendarImage.jpg" Height="16px"></asp:ImageButton> <cc1:CalendarExtender id="CalendarExtender5" runat="server" TargetControlID="txtMedAlertDate"></cc1:CalendarExtender></TD></TR></TBODY></TABLE></FIELDSET></TD></TR></TBODY></TABLE><TABLE class="text2" width=1000><TBODY><TR><TD><TABLE style="WIDTH: 1000px" class="text2"><TBODY><TR><TD style="HEIGHT: 383px" align=center><asp:MultiView id="mvPurchasedetailedInfo" runat="server"><asp:View id="vwland" runat="server"><TABLE style="WIDTH: 1000px; TEXT-ALIGN: center"><TBODY><TR><TD style="WIDTH: 1014px" align=center><TABLE style="WIDTH: 1000px" id="Table3" class="strip"><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: left" align=center><STRONG>Goods</STRONG></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 1014px" align=center><asp:GridView id="grdLandGoods" runat="server" Width="800px" OnSelectedIndexChanged="grdLandGoods_SelectedIndexChanged" DataKeyNames="POHdr_ID,PODtl_ID,Item_ID,PropertyDetai_ID,Program_id,Project_ID,Item_Desc,Function_ID,RC_ID,Qty,AcquisitionCost,type" SkinID="GridViewGL" AllowPaging="True" PageSize="4" OnRowDataBound="grdLandGoods_RowDataBound"><Columns>
<asp:BoundField DataField="type" HeaderText="Type of Land">
<ItemStyle HorizontalAlign="Left" Width="120px"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Serial No."></asp:BoundField>
<asp:BoundField DataField="DatePurchased" DataFormatString="{0:d}" HeaderText="Date Purchased">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="AcquisitionCost" DataFormatString="{0:N}" HeaderText="Acquisition Cost">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataFormatString="{0:N}" HeaderText="Market Value"></asp:BoundField>
<asp:BoundField DataField="Status_AIR" HeaderText="Status"></asp:BoundField>
</Columns>
</asp:GridView></TD></TR><TR><TD style="WIDTH: 1014px" align=center><TABLE style="WIDTH: 1000px" id="Table5" class="strip"><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: left"><STRONG style="TEXT-ALIGN: center">LAND INFORMATION</STRONG></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 1014px" align=center><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 800px" align=center><FIELDSET style="WIDTH: 800px; HEIGHT: 130px" class="PanelBorder"><LEGEND><STRONG><EM>PROPERTY IDENTIFICATION</EM></STRONG></LEGEND><TABLE width=800><TBODY><TR><TD style="WIDTH: 85px" class="column_RightBold" align=right>LGU Code :</TD><TD style="WIDTH: 100px" class="text5"><asp:TextBox id="txtLandlgucode" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px" class="column_RightBold" align=right>District Code :</TD><TD style="WIDTH: 90px" class="text5"><asp:TextBox id="txtLanddistrictcode" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox> </TD><TD style="WIDTH: 150px" class="column_RightBold" align=right>City/Municipality Code :</TD><TD style="WIDTH: 80px" class="text5"><asp:TextBox id="txtLandcitymunicipality1" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 115px" class="column_RightBold" align=right>Barangay Code :</TD><TD style="FONT-WEIGHT: bold; WIDTH: 80px; FONT-STYLE: italic" class="text5" align=left><asp:TextBox id="txtLandbrgycode" runat="server" Width="75px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 85px" class="column_RightBold" align=right>Section No. :</TD><TD style="WIDTH: 100px" class="text5"><asp:TextBox id="txtLandSectionno" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px" class="column_RightBold" align=right>Parcel No. :</TD><TD style="WIDTH: 90px" class="text5"><asp:TextBox id="txtLandParcelno" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 150px" class="column_RightBold" align=right>Series No. :</TD><TD style="WIDTH: 80px" class="text5"><asp:TextBox id="txtLandSeriesno" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 115px" class="column_RightBold" align=right></TD><TD style="FONT-WEIGHT: bold; WIDTH: 80px; FONT-STYLE: italic" class="text5" align=left></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 800px"><TBODY><TR><TD style="WIDTH: 50px" class="column_RightBold">PIN :</TD><TD style="WIDTH: 140px" class="text5"><asp:TextBox id="txtLandPIN" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 60px" class="column_RightBold">ARP :</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtLandARP" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 150px" class="column_RightBold">Depreciation Rate :</TD><TD style="WIDTH: 100px" class="text5"><asp:TextBox id="txtLandDepriciationRate" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 80px" class="column_RightBold">Rev Year :</TD><TD style="WIDTH: 100px" class="text5"><asp:TextBox id="txtLandrevyear" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 50px" class="column_RightBold">TDN :</TD><TD style="WIDTH: 140px" class="text5"><asp:TextBox id="txtLandTdn" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 60px" class="column_RightBold">RPTIN :</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtLandRPTIN" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 150px" class="column_RightBold">Depreciation Value :</TD><TD style="WIDTH: 100px" class="text5"><asp:TextBox id="txtLandDepreciatedValue" runat="server" Width="120px" CssClass="txtboxinspection">0.00</asp:TextBox></TD><TD style="WIDTH: 80px" class="column_RightBold"></TD><TD style="WIDTH: 100px" class="text5"></TD></TR></TBODY></TABLE></FIELDSET></TD><TD style="WIDTH: 200px" rowSpan=2><FIELDSET style="WIDTH: 191px; HEIGHT: 245px" class="PanelBorder"><TABLE><TBODY><TR><TD style="VERTICAL-ALIGN: middle; WIDTH: 191px; HEIGHT: 141px; TEXT-ALIGN: center" class="textimage" colSpan=2><asp:Image id="ImageLand" runat="server" Width="151px" ImageUrl="~/images/LandDefaultimage.jpg" CssClass="textimage2" Height="124px" ImageAlign="Middle"></asp:Image></TD></TR><TR><TD style="WIDTH: 80px" class="textimage">Date Taken:</TD><TD style="WIDTH: 110px" class="textimage2"><asp:TextBox id="txtLanddatetaken" runat="server" Width="108px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 80px" class="textimage">Uploaded By:</TD><TD style="WIDTH: 110px" class="textimage2"><asp:TextBox id="txtLandUploadedby" runat="server" Width="108px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 80px" class="textimage">Position:</TD><TD style="WIDTH: 110px" class="textimage2"><asp:TextBox id="txtLandPosition" runat="server" Width="108px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD></TR><TR><TD style="WIDTH: 800px; HEIGHT: 112px" align=center><FIELDSET style="WIDTH: 800px; HEIGHT: 115px" class="PanelBorder"><LEGEND><EM><STRONG>LOCATION</STRONG></EM></LEGEND><TABLE width=800><TBODY><TR><TD style="WIDTH: 55px; HEIGHT: 15px" class="column_LeftBold" align=left>Lot No. :</TD><TD style="WIDTH: 64px; HEIGHT: 15px" class="column_LeftBold" align=left>Blk No. :</TD><TD style="WIDTH: 91px; HEIGHT: 15px" class="column_LeftBold" align=left>Street Name :</TD><TD style="WIDTH: 224px; HEIGHT: 15px" class="column_LeftBold" align=left>Subdivision/Village/Compound :</TD><TD style="WIDTH: 83px; HEIGHT: 15px" class="column_LeftBold" align=left>Phase No. :</TD><TD style="WIDTH: 145px; HEIGHT: 15px" class="column_LeftBold" align=left>Purok :</TD><TD style="HEIGHT: 15px" class="column_LeftBold" align=left>Sitio :</TD></TR><TR><TD style="WIDTH: 55px" class="text5" align=left><asp:TextBox id="txtLandlocationLot" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 64px" class="text5" align=left><asp:TextBox id="txtLandlocationblkno" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 91px" class="text5" align=left><asp:TextBox id="txtLandlocationstreetname" runat="server" Width="85px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 224px" class="text5" align=left><asp:TextBox id="txtLandlocationsubdivisionvillage" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 83px" class="text5" align=left><asp:TextBox id="txtLandlocationphaseno" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 145px" class="text5" align=left><asp:TextBox id="txtLandlocationpurok" runat="server" Width="130px" CssClass="txtboxinspection"></asp:TextBox></TD><TD class="text5" align=left><asp:TextBox id="txtLandlocationsitio" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE><TABLE width=800><TBODY><TR><TD style="WIDTH: 4px" class="column_LeftBold" align=left>Barangay :</TD><TD style="WIDTH: 20px" class="column_LeftBold" align=left>District :</TD><TD style="WIDTH: 194px" class="column_LeftBold" align=left>City/Municipality :</TD><TD style="WIDTH: 85px" class="column_LeftBold" align=left>Region :</TD><TD style="WIDTH: 117px" class="column_LeftBold" align=left>Province :</TD><TD class="column_LeftBold" align=left>Zip Code :</TD></TR><TR><TD style="WIDTH: 4px" class="text5" align=left><asp:TextBox id="txtLandbarangay" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 20px" class="text5" align=left><asp:TextBox id="txtLandDistrict" runat="server" Width="134px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 194px" class="text5" align=left><asp:TextBox id="txtLandCitymunicipality" runat="server" Width="190px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 85px" class="text5" align=left><asp:TextBox id="txtLandRegion" runat="server" Width="94px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 117px" class="text5" align=left><asp:TextBox id="txtLandprovince" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD><TD class="text5" align=left><asp:TextBox id="txtLandzipcode" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 1014px" align=center><FIELDSET style="WIDTH: 1000px" class="PanelBorder"><LEGEND><STRONG><EM>CHARACTERISTICS</EM></STRONG></LEGEND><TABLE style="WIDTH: 997px" id="tbcharacter"><TBODY><TR><TD style="WIDTH: 60px" class="column_RightBold">Classification :</TD><TD style="WIDTH: 190px" class="text5" align=left><asp:TextBox id="txtLandClassification" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 80px" class="column_RightBold" align=right>Sub Class :</TD><TD style="WIDTH: 150px" class="text5" align=left><asp:TextBox id="txtLandSubClass" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 80px" class="column_RightBold" align=right>Land Use :</TD><TD style="WIDTH: 190px" class="text5" align=left><asp:TextBox id="txtLandUse" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 80px" class="column_RightBold" align=right>Status :</TD><TD style="WIDTH: 160px" class="text5" align=left><asp:TextBox id="txtLandStatus1" runat="server" Width="142px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 60px; HEIGHT: 9px" class="column_RightBold">Taxable :</TD><TD style="WIDTH: 190px; HEIGHT: 9px" class="text5" align=left><asp:DropDownList id="ddwnLandTaxable" runat="server" Width="80px"><asp:ListItem>Select</asp:ListItem>
<asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 80px; HEIGHT: 9px" class="column_RightBold" align=right>Area :</TD><TD style="WIDTH: 150px; HEIGHT: 9px" class="text5" align=left><asp:TextBox id="txtLandArea" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 80px; HEIGHT: 9px" class="column_RightBold"></TD><TD style="WIDTH: 190px; HEIGHT: 9px" class="text5"></TD><TD style="WIDTH: 80px; HEIGHT: 9px" class="column_RightBold" align=right>Status :</TD><TD style="WIDTH: 160px; HEIGHT: 9px" class="text5" align=left><asp:TextBox id="txtLandStatus2" runat="server" Width="142px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD></TR><TR><TD style="WIDTH: 1014px" align=center><FIELDSET style="WIDTH: 1000px; HEIGHT: 70px" id="fiedsetValue" class="PanelBorder"><LEGEND><STRONG><EM>VALUE</EM></STRONG></LEGEND><TABLE style="WIDTH: 997px; HEIGHT: 50px" id="Table33"><TBODY><TR><TD style="WIDTH: 170px" class="column_RightBold" align=right>Assessed Value:</TD><TD style="WIDTH: 90px" align=left><asp:TextBox id="txtLandAssessedValue" runat="server" Width="90px" CssClass="txtboxinspection">0.00</asp:TextBox></TD><TD style="WIDTH: 30px" class="column_RightBold">Date:</TD><TD style="WIDTH: 70px" align=left><asp:TextBox id="txtLandAssessedDate" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox> </TD><TD style="WIDTH: 190px" class="column_RightBold" align=right>Market Value:</TD><TD style="WIDTH: 90px" align=left><asp:TextBox id="txtLandMarketValue" runat="server" Width="90px" CssClass="txtboxinspection">0.00</asp:TextBox></TD><TD style="WIDTH: 30px" class="column_RightBold">Date:</TD><TD style="WIDTH: 70px" align=left><asp:TextBox id="txtLandMarketDate" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 180px" class="column_RightBold" align=right>Unit Value:</TD><TD style="WIDTH: 90px" align=left><asp:TextBox id="txtLandUnitValue" runat="server" Width="90px" CssClass="txtboxinspection">0.00</asp:TextBox></TD><TD style="WIDTH: 30px" class="column_RightBold" align=left>Date:</TD><TD style="WIDTH: 70px" align=left><asp:TextBox id="txtLandUnitDate" runat="server" Width="68px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 170px" class="column_RightBold" align=right>Amount in Words:</TD><TD style="WIDTH: 200px" colSpan=3><asp:TextBox id="txtLandAssessedAmount" runat="server" Width="210px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 190px" class="column_RightBold" align=right>Amount in Words:</TD><TD style="WIDTH: 200px" align=left colSpan=3><asp:TextBox id="txtLandMarketAmount" runat="server" Width="210px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 180px" class="column_RightBold" align=right>Assessment Level :</TD><TD style="WIDTH: 200px" align=left colSpan=3><asp:DropDownList id="dpLandAssessmentLvl" runat="server" Width="208px" CssClass="txtboxinspection"></asp:DropDownList></TD></TR></TBODY></TABLE><cc1:CalendarExtender id="CalendarExtender9" runat="server" TargetControlID="txtLandAssessedDate"></cc1:CalendarExtender> <cc1:CalendarExtender id="CalendarExtender10" runat="server" TargetControlID="txtLandMarketDate"></cc1:CalendarExtender> <cc1:CalendarExtender id="CalendarExtender11" runat="server" TargetControlID="txtLandUnitDate"></cc1:CalendarExtender></FIELDSET></TD></TR></TBODY></TABLE><BR /><BR /><TABLE style="WIDTH: 882px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><%--  style="width: 132px; height: 26px;"--%><TD><asp:Button id="btntechnicaldescription" onclick="btntechnicaldescription_Click" runat="server" Width="142px" Text="Technical Description" CssClass="Initial"></asp:Button></TD><%--  style="height: 26px;"--%><TD><asp:Button id="btnLandDocument" onclick="btnLandDocument_Click" runat="server" Width="105px" Text="Land Document" CssClass="Initial"></asp:Button></TD><%--style="height: 26px;"--%><TD style="WIDTH: 143px"><asp:Button id="btnHistory" onclick="btnHistory_Click" runat="server" Width="137px" Text="History Of Ownership" CssClass="Initial"></asp:Button></TD><%-- style="height: 26px;"--%><TD style="WIDTH: 126px"><asp:Button id="btnlandvalue" onclick="btnlandvalue_Click" runat="server" Width="101px" Text="Land Valuation" CssClass="Initial"></asp:Button></TD><%-- style="width: 5px; height: 26px;"--%><TD><asp:Button id="bntapproval" onclick="bntapproval_Click" runat="server" Width="131px" Text="Approval Information" CssClass="Initial"></asp:Button></TD><%--style="width: 45px; height: 26px;"--%><TD><asp:Button id="btnimprovements" onclick="btnimprovements_Click" runat="server" Width="105px" Text="Improvements" CssClass="Initial"></asp:Button></TD><%--      style="width: 54px; height: 26px;"--%><TD><asp:Button id="btnmemoranda" onclick="btnmemoranda_Click" runat="server" Width="84px" Text="Memoranda" CssClass="Initial"></asp:Button></TD><TD style="HEIGHT: 26px"><asp:Button id="bntDocumentAttach" onclick="bntDocumentAttach_Click" runat="server" Width="143px" Text="Document Attachment" CssClass="Initial"></asp:Button></TD></TR></TBODY></TABLE><FIELDSET style="WIDTH: 1000px" class="PanelBorder"><asp:MultiView id="MvLandInspectionAccptnce" runat="server"><asp:View id="vwTechnicalTechnicaldescription" runat="server"><TABLE style="WIDTH: 1000px; TEXT-ALIGN: center"><TBODY><TR><TD style="VERTICAL-ALIGN: middle; WIDTH: 370px; TEXT-ALIGN: center"><TABLE style="WIDTH: 370px"><TBODY><TR><TD style="WIDTH: 120px" class="column_LeftBold"></TD><TD style="WIDTH: 120px" class="column_LeftBold"></TD><TD class="column_LeftBold" colSpan=2><EM style="TEXT-ALIGN: center">Property Boundaries</EM></TD></TR><TR><TD style="WIDTH: 120px" class="column_RightBold">OCT No. :</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txttechnicaloctno" runat="server" Width="115px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 40px" class="column_RightBold">North :</TD><TD style="WIDTH: 90px" class="text5"><asp:TextBox id="txttechnicalNorth" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px" class="column_RightBold">TCT No.&nbsp;:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txttechnicaltctno" runat="server" Width="115px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 40px" class="column_RightBold">East :</TD><TD style="WIDTH: 90px" class="text5"><asp:TextBox id="txttechnicalEast" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px" class="column_RightBold">Date :</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txttechnicalDate" runat="server" Width="115px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 40px" class="column_RightBold">South :</TD><TD style="WIDTH: 90px" class="text5"><asp:TextBox id="txttechnicalSouth" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px" class="column_RightBold">Date Registered :</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txttechnicaldateregistered" runat="server" Width="115px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 40px" class="column_RightBold">West :</TD><TD style="WIDTH: 90px" class="text5"><asp:TextBox id="txttechnicalwest" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px" class="column_RightBold">Cadastral No. :</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txttechnicalcadastralno" runat="server" Width="115px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 40px" class="column_RightBold"></TD><TD style="WIDTH: 90px" class="text5"></TD></TR><TR><TD class="column_RightBold" colSpan=2>Brgy Boundary Monument&nbsp;(B.B.M) No.&nbsp;:</TD><TD class="text5" colSpan=2><asp:TextBox id="txtLandBBM" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 350px; TEXT-ALIGN: center"><TABLE style="WIDTH: 350px"><TBODY><TR><TD style="WIDTH: 112px" class="strip" align=center><STRONG style="WIDTH: 80px">Line</STRONG></TD><TD style="WIDTH: 140px" class="strip" align=center><STRONG style="WIDTH: 140px">Bearing</STRONG></TD><TD style="WIDTH: 100px" class="strip" align=center><STRONG style="WIDTH: 100px">Distance</STRONG></TD></TR></TBODY></TABLE><asp:GridView id="grdLandTechDesc" runat="server" Width="350px" OnSelectedIndexChanged="grdLandTechDesc_SelectedIndexChanged" SkinID="GridView" PageSize="3"><Columns>
<asp:TemplateField HeaderText="Starting PT"><ItemTemplate>
<asp:TextBox id="txtStartingPT" runat="server" Width="40px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<ItemStyle Width="65px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ending PT"><ItemTemplate>
<asp:TextBox id="txtEndingPT" runat="server" Width="40px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<ItemStyle Width="65px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="N/S"><ItemTemplate>
<asp:TextBox id="txtNS" runat="server" Width="30px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>

<ItemStyle Width="40px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="ns1"><ItemTemplate>
<asp:TextBox id="txtns1" runat="server" Width="30px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="ns2"><ItemTemplate>
<asp:TextBox id="txtns2" runat="server" Width="30px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="W/E"><ItemTemplate>
<asp:TextBox id="txtWE" runat="server" Width="30px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>

<ItemStyle Width="40px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="m"><ItemTemplate>
<asp:TextBox id="txtm" runat="server" Width="40px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<ItemStyle Width="80px"></ItemStyle>
</asp:TemplateField>
</Columns>
</asp:GridView></TD><TD style="WIDTH: 280px"><IMG style="WIDTH: 250px; TEXT-ALIGN: center" src="../images/TechDesciption.jpg" width="0" /></TD></TR></TBODY></TABLE><BR /></asp:View> <asp:View id="vwLandDocument" runat="server"><TABLE style="HEIGHT: 236px" width=1000><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 704px; HEIGHT: 161px" align=right><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 700px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 163px"><LEGEND><SPAN style="FONT-SIZE: 10pt"><STRONG><EM>DOCUMENTS DETAILS</EM></STRONG></SPAN></LEGEND><TABLE class="text" width=700><TBODY><TR><TD style="WIDTH: 105px"></TD><TD style="WIDTH: 105px"><asp:HiddenField id="hdfAttachDoc1" runat="server" OnValueChanged="hdfAttachDoc1_ValueChanged"></asp:HiddenField><INPUT style="DISPLAY: none" id="flAttachDoc1" type=file onchange="Handlechange2();" name="fileupload" /><INPUT style="WIDTH: 147px; HEIGHT: 30px" id="btnBrowseAttachDoc1" onclick="HandleBrowseClick2();" type=submit value="Browse" runat="server" OnServerClick="btnBuildingBrowse_ServerClick" /></TD><TD style="WIDTH: 105px" align=right>Validated By:</TD><TD style="WIDTH: 105px"><asp:TextBox id="txtvalidatedby" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 105px" align=right>Agency :</TD><TD style="WIDTH: 105px"><asp:TextBox id="txtLandAgency" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 105px" align=right>Date Validated:</TD><TD style="WIDTH: 105px"><asp:TextBox id="txtdatevalidated" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox> <cc1:CalendarExtender id="CalendarExtender12" runat="server" TargetControlID="txtdatevalidated"></cc1:CalendarExtender></TD></TR><TR><TD style="WIDTH: 117px" align=right>Document Name:</TD><TD style="WIDTH: 117px"><asp:TextBox id="txtDocumentname" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 117px" align=right>Remarks:</TD><TD style="WIDTH: 117px" rowSpan=2><asp:TextBox id="txtdocremarks" runat="server" Width="200px" CssClass="txtboxinspection" Height="37px" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 117px; HEIGHT: 18px" class="text4">Document No.:</TD><TD style="WIDTH: 230px"><asp:TextBox id="txtdocumentno" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 105px; HEIGHT: 18px"></TD></TR><TR><TD align=center colSpan=4><asp:Button id="btnAddlist" onclick="btnAddlist_Click1" runat="server" Width="122px" Text="Add To List"></asp:Button> <asp:Button id="btnCancel" runat="server" Width="122px" Text="Cancel"></asp:Button></TD></TR></TBODY></TABLE></FIELDSET> </TD><TD style="VERTICAL-ALIGN: top; WIDTH: 250px" align=center rowSpan=2><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 252px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 340px"><LEGEND>ATTACHED DOCUMENTS</LEGEND><asp:Image id="imgLandDoc" runat="server" Width="228px" ImageUrl="~/images/DefaulScannedDocuments.jpg" Height="291px"></asp:Image><BR /></FIELDSET> </TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 704px; HEIGHT: 154px" align=right><asp:GridView id="grdLandDocu" runat="server" Width="700px" OnSelectedIndexChanged="grdLandDocu_SelectedIndexChanged" DataKeyNames="IdentityNo,LandDocuId" SkinID="GridView" PageSize="5" Height="170px" BorderStyle="Solid" BorderWidth="1px" OnRowDataBound="grdLandDocu_RowDataBound" BorderColor="Silver"><Columns>
<asp:BoundField DataField="Agency" HeaderText="Agency">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DocumentName" HeaderText="Document Name">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DocumentNo" HeaderText="Document No.">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ValidatedBy" HeaderText="Validated By">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DateValidated" DataFormatString="{0:d}" HeaderText="Date Validated">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Remarks" HeaderText="Remarks">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView></TD></TR></TBODY></TABLE></asp:View> <asp:View id="vwHistoryofOwnership" runat="server"><BR /><TABLE style="WIDTH: 1000px"><TBODY><TR><TD align=center colSpan=2><asp:GridView id="grdOwnership" runat="server" Width="900px" OnSelectedIndexChanged="grdOwnership_SelectedIndexChanged1" SkinID="GridViewGL" PageSize="4" OnRowDataBound="grdOwnership_RowDataBound1"><Columns>
<asp:BoundField DataField="year" HeaderText="Year"></asp:BoundField>
<asp:BoundField DataField="ownername" HeaderText="Owner's Name"></asp:BoundField>
<asp:BoundField DataField="ownershiptype" HeaderText="Ownership Type"></asp:BoundField>
<asp:BoundField DataField="address" HeaderText="Address"></asp:BoundField>
<asp:BoundField DataField="typeofacquisition" HeaderText="Type of Acquisition"></asp:BoundField>
</Columns>
</asp:GridView><asp:GridView id="grdAddOwnership" runat="server" Width="900px" SkinID="GridViewGL" PageSize="4"><Columns>
<asp:TemplateField HeaderText="Year"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("year") %>' id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtLandOwnerYear" runat="server" Width="80px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Owner's Name"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("ownername") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtLandOwnerName" runat="server" Width="170px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>

<ItemStyle Width="200px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ownership Type"><EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("ownershiptype") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
&nbsp;<asp:TextBox id="txtLandOwnerType" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address"><EditItemTemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("address") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtLandOwnerAddress" runat="server" Width="250px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>

<ItemStyle Width="300px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Type Of Acquisition"><EditItemTemplate>
<asp:TextBox id="TextBox5" runat="server" Text='<%# Bind("typeofacquisition") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtLandOwnerAcquisition" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
</asp:TemplateField>
</Columns>
</asp:GridView> <TABLE style="LEFT: 0px; WIDTH: 900px; TOP: 0px"><TBODY><TR><TD style="WIDTH: 150px"></TD><TD style="WIDTH: 100px"></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 400px; TEXT-ALIGN: center"><asp:Button id="btnAddOwner" onclick="btnAddOwner_Click" runat="server" Width="164px" Text="Add Owner" Height="30px" Visible="False"></asp:Button><asp:Button style="LEFT: 0px; TOP: -1px" id="btnSaveOwner" onclick="btnSaveOwner_Click" runat="server" Width="164px" Text="Save" Height="30px" Visible="False"></asp:Button> <asp:Button id="btnCancelOwner" onclick="btnCancelOwner_Click" runat="server" Width="164px" Text="Cancel" Height="30px" Visible="False"></asp:Button></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 150px"></TD></TR></TBODY></TABLE><DIV style="TEXT-ALIGN: center"></DIV></TD></TR><TR><TD align=center colSpan=2><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; VERTICAL-ALIGN: middle; BORDER-LEFT: #669933 1px solid; WIDTH: 450px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 160px; TEXT-ALIGN: center"><TABLE style="WIDTH: 411px" id="tbownership1"><TBODY><TR><TD style="WIDTH: 145px" class="column_LeftBold" align=left></TD><TD style="WIDTH: 5px" class="column_LeftBold"></TD><TD style="WIDTH: 250px" class="text5"></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold" align=left>Corporation Name</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txthistoryownershipcorporationname" runat="server" Width="245px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold" align=left>Address</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txthistoryownershipAddress" runat="server" Width="245px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold" align=left>Telephone No.</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txthistoryownershiptelephoneno" runat="server" Width="245px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold" align=left>Cellphone No.</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txthistoryownershipcellphone" runat="server" Width="245px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold" align=left>Email Address</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txthistoryownershipemailaddress" runat="server" Width="245px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET> <FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; VERTICAL-ALIGN: middle; BORDER-LEFT: #669933 1px solid; WIDTH: 450px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 160px; TEXT-ALIGN: center"><TABLE style="WIDTH: 445px" id="tbownership2"><TBODY><TR><TD style="WIDTH: 165px" class="column_LeftBold" align=left>Chairman</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 230px" class="text5"><asp:TextBox id="txthistoryownershipchairman" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 165px" class="column_LeftBold" align=left>Vice Chairman</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 230px" class="text5"><asp:TextBox id="txthistoryownershipvicechairman" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 165px" class="column_LeftBold" align=left>President</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 230px" class="text5"><asp:TextBox id="txthistoryownershippresident" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 165px" class="column_LeftBold" align=left>Senior Vice President</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 230px" class="text5"><asp:TextBox id="txthistoryownershipseniorvicepresident" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 165px" class="column_LeftBold" align=left>Administrative VP</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 230px" class="text5"><asp:TextBox id="txthistoryownershipadminvicepresident" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 165px" class="column_LeftBold" align=left>Corporate Secretary</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 230px" class="text5"><asp:TextBox id="txthistoryownershipcorporatesecretary" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD></TR></TBODY></TABLE></asp:View> <asp:View id="vwLandValutaion" runat="server"><BR /><TABLE style="WIDTH: 900px"><TBODY><TR><TD style="WIDTH: 145px" class="column_LeftBold">Classification</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtLandValClass" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px" class="text5"></TD><TD style="WIDTH: 145px" class="column_LeftBold">Base Market Value</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtLandValBMV" runat="server" Width="240px" CssClass="txtboxinspection">0.00</asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold">Sub-Classification</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtLandValSubClass" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px" class="text5"></TD><TD style="WIDTH: 145px" class="column_LeftBold">Taxable</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtLandValTaxable" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold">Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtLandValArea" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px" class="text5"></TD><TD style="WIDTH: 145px" class="column_LeftBold">Adjustments</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtLandValAdjustment" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold">Unit</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtLandValUnit" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px" class="text5"></TD><TD style="WIDTH: 145px" class="column_LeftBold">Adjusted Market Value</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtLandValAMV" runat="server" Width="240px" CssClass="txtboxinspection">0.00</asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold">Unit Value</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtLandValUnitValue" runat="server" Width="240px" CssClass="txtboxinspection">0.00</asp:TextBox></TD><TD style="WIDTH: 100px" class="text5"></TD><TD style="WIDTH: 145px" class="column_LeftBold">Strip</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtLandValStrip" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold">Adjusted Unit Value</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtLandValAUV" runat="server" Width="240px" CssClass="txtboxinspection">0.00</asp:TextBox></TD><TD style="WIDTH: 100px" class="text5"></TD><TD style="WIDTH: 145px" class="column_LeftBold"></TD><TD style="WIDTH: 5px" class="column_LeftBold"></TD><TD style="WIDTH: 250px" class="text5"></TD></TR></TBODY></TABLE><BR /><TABLE style="WIDTH: 900px"><TBODY><TR><TD style="WIDTH: 100px" class="text4"><asp:CheckBox id="chkMultiple" runat="server"></asp:CheckBox></TD><TD style="WIDTH: 200px" class="column_LeftBold">Multiple Classification</TD><TD style="WIDTH: 150px" class="column_RightBold">Total Land Areas :</TD><TD style="WIDTH: 150px" class="text5"><asp:TextBox id="txtLandevaluationtotallandareas" runat="server" Width="102px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 200px" class="column_RightBold">Total Base Market Value :</TD><TD style="WIDTH: 100px" class="text5"><asp:TextBox id="txthistoryownershiptotalbasemarketvalue" runat="server" Width="100px" CssClass="txtboxinspection">0.00</asp:TextBox></TD></TR></TBODY></TABLE></asp:View> <asp:View id="vwApprovalInformation" runat="server"><TABLE style="HEIGHT: 171px" width=1000><TBODY><TR><TD style="WIDTH: 340px; HEIGHT: 205px" align=center><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 340px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 171px"><LEGEND>-</LEGEND><TABLE style="WIDTH: 330px; HEIGHT: 150px" id="tbEffectiveasset"><TBODY><TR><TD style="WIDTH: 188px; HEIGHT: 22px"><asp:CheckBox id="chkdateregistred" runat="server" Width="144px" Text="Date Registration"></asp:CheckBox></TD><TD style="WIDTH: 5px; HEIGHT: 22px"><asp:TextBox id="txtapprovalinformation" runat="server" Width="81px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD colSpan=2><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 300px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 70px"><LEGEND><STRONG><EM>Effectively of Assessment</EM></STRONG></LEGEND><TABLE style="WIDTH: 279px" id="tbeffectiveness"><TBODY><TR><TD style="WIDTH: 136px; HEIGHT: 24px"><asp:DropDownList id="ddQuarterbuilding" runat="server" Width="104px">
                                                                                          </asp:DropDownList></TD><TD style="HEIGHT: 24px"><asp:DropDownList id="ddyearbuilding" runat="server" Width="104px"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 136px; HEIGHT: 16px" class="text6Bold">Quarter</TD><TD style="HEIGHT: 16px" class="text6Bold">Year</TD></TR></TBODY></TABLE></FIELDSET> </TD></TR><TR><TD style="HEIGHT: 16px" colSpan=2><asp:RadioButtonList id="rdbBuilding" runat="server" Width="191px" RepeatDirection="Horizontal">
                                                                              <asp:ListItem>Taxable</asp:ListItem>
                                                                              <asp:ListItem>Exemption</asp:ListItem>
                                                                          </asp:RadioButtonList></TD></TR></TBODY></TABLE></FIELDSET> </TD><TD style="WIDTH: 650px; HEIGHT: 205px" align=center><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 640px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 171px"><LEGEND><STRONG><EM>Signatories</EM></STRONG></LEGEND><TABLE id="tbsignatoris" width=640><TBODY><TR><TD style="WIDTH: 14px; HEIGHT: 16px; TEXT-ALIGN: left" class="column_LeftBold"></TD><TD style="WIDTH: 487px; HEIGHT: 16px; TEXT-ALIGN: left" class="column_LeftBold">Appraised And Assessment By</TD><TD style="WIDTH: 12px; HEIGHT: 16px" class="column_LeftBold"></TD><TD style="HEIGHT: 16px" class="column_LeftBold" align=left>Date</TD></TR><TR><TD style="WIDTH: 14px; HEIGHT: 16px" align=left></TD><TD style="WIDTH: 487px; HEIGHT: 16px" align=left><asp:DropDownList id="ddappraisedLand" runat="server" Width="463px">
                                                                          </asp:DropDownList></TD><TD style="WIDTH: 12px; HEIGHT: 16px"><asp:CheckBox id="chk1" runat="server"></asp:CheckBox></TD><TD style="HEIGHT: 16px" align=left><asp:Label id="lblappraiseddate" runat="server" Width="81px" SkinID="LabelBorder" BorderStyle="Solid" BorderWidth="1px">mm/dd/yyyy</asp:Label></TD></TR><TR><TD style="WIDTH: 14px; HEIGHT: 16px" class="column_LeftBold" align=left></TD><TD style="WIDTH: 487px; HEIGHT: 16px" class="column_LeftBold" align=left>Recommending Approval</TD><TD style="WIDTH: 12px; HEIGHT: 16px" class="column_LeftBold"></TD><TD style="HEIGHT: 16px" class="column_LeftBold" align=left></TD></TR><TR><TD style="WIDTH: 14px; HEIGHT: 16px" align=left></TD><TD style="WIDTH: 487px; HEIGHT: 16px" align=left><asp:DropDownList id="ddrecommendingApprovalLand" runat="server" Width="463px">
                                                                          </asp:DropDownList></TD><TD style="WIDTH: 12px; HEIGHT: 16px"><asp:CheckBox id="chk2" runat="server"></asp:CheckBox></TD><TD style="HEIGHT: 16px" align=left><asp:Label id="lblrecommendingdate" runat="server" Width="81px" SkinID="LabelBorder" BorderStyle="Solid" BorderWidth="1px">mm/dd/yyyy</asp:Label></TD></TR><TR><TD style="WIDTH: 14px" class="column_LeftBold" align=left></TD><TD style="WIDTH: 487px" class="column_LeftBold" align=left>Approved By</TD><TD style="WIDTH: 12px" class="column_LeftBold"></TD><TD class="column_LeftBold" align=left></TD></TR><TR><TD style="WIDTH: 14px"></TD><TD style="WIDTH: 487px" align=left><asp:DropDownList id="ddapprovedLand" runat="server" Width="463px">
                                                                          </asp:DropDownList></TD><TD style="WIDTH: 12px"><asp:CheckBox id="chk3" runat="server"></asp:CheckBox></TD><TD align=left><asp:Label id="lblapproveddate" runat="server" Width="81px" SkinID="LabelBorder" BorderStyle="Solid" BorderWidth="1px">mm/dd/yyyy</asp:Label></TD></TR></TBODY></TABLE></FIELDSET> </TD></TR></TBODY></TABLE></asp:View> <asp:View id="vwImprovements" runat="server"><TABLE style="WIDTH: 900px"><TBODY><TR><TD style="WIDTH: 145px" class="column_LeftBold"></TD><TD style="WIDTH: 5px" class="column_LeftBold"></TD><TD style="WIDTH: 250px" class="text5"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 145px" class="column_LeftBold"></TD><TD style="WIDTH: 5px" class="column_LeftBold"></TD><TD style="WIDTH: 250px" class="text5"></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold">Kind</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtImprovementKind" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 145px" class="column_LeftBold">Sub - Class</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtImprovementSubclass" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold">Quality</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtImprovementQuality" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 145px" class="column_LeftBold">Type</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtImprovementType" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold">Unit Value</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtImprovementUnitValue" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 145px" class="column_LeftBold">Assessment Level</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtImprovementAssessLvl" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold">Base Market Value</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtImprovementBMV" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 145px" class="column_LeftBold">Actual Use</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtImprovementActualUse" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold">Taxable</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtImprovementTaxable" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 145px" class="column_LeftBold">Land Improvements</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="txtLandImprovement" runat="server" Width="240px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE><BR /><TABLE style="WIDTH: 900px"><TBODY><TR><TD style="WIDTH: 450px"></TD><TD style="WIDTH: 250px" class="column_RightBold">Total Improvement Base Market Value :</TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtImprovementBaseMV" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></asp:View> <asp:View id="vwmemoranda" runat="server"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="HEIGHT: 56px" id="Td1" align=center><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 876px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 70px"><LEGEND><STRONG>Memoranda</STRONG></LEGEND><asp:TextBox id="txtMemoranda1" runat="server" Width="841" CssClass="txtboxinspection" Height="43px" TextMode="MultiLine"></asp:TextBox> </FIELDSET> </TD></TR><TR><TD style="HEIGHT: 55px" id="Td2" align=center><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 878px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 70px"><LEGEND><STRONG>Remarks</STRONG></LEGEND><asp:TextBox id="txtremarks" runat="server" Width="844px" CssClass="txtboxinspection" Height="42px" TextMode="MultiLine"></asp:TextBox> </FIELDSET> </TD></TR><TR><TD style="HEIGHT: 84px" id="Td3" align=center><TABLE width=921><TBODY><TR><TD style="WIDTH: 302px" class="column_LeftBold">Date of Entry in the Records of Assesment By :</TD><TD style="WIDTH: 72px"><asp:CheckBox id="CheckBox1" runat="server" Text="Date"></asp:CheckBox></TD><TD style="WIDTH: 2295px" class="column_RightBold">Date Encoded:</TD><TD style="WIDTH: 46px"><asp:TextBox id="txtmemorandaDateencoded" runat="server" Width="81px" CssClass="txtboxinspection"></asp:TextBox> </TD><TD class="column_RightBold" align=right>By:</TD><TD style="WIDTH: 677px" align=left><asp:TextBox id="txtmemorandaEncodedBy" runat="server" Width="294px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 3px"></TD></TR><TR><TD style="WIDTH: 302px; HEIGHT: 18px"><asp:TextBox id="txtmemorandaAssessmentBy" runat="server" Width="294px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 72px; HEIGHT: 18px"><asp:Label id="Label60" runat="server" Width="76px" SkinID="LabelBorder" Font-Italic="True">mm/dd/yy</asp:Label></TD><TD style="WIDTH: 2295px; HEIGHT: 18px" class="column_RightBold">Date Uploaded:</TD><TD style="WIDTH: 46px; HEIGHT: 18px"><asp:TextBox id="txtMemorandaDateUploaded" runat="server" Width="81px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="HEIGHT: 18px" class="column_RightBold">By:</TD><TD style="WIDTH: 677px; HEIGHT: 18px" align=left><asp:TextBox id="txtMemorandaUploadedBy" runat="server" Width="294px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 3px; HEIGHT: 18px"></TD></TR><%--  <tr>
                                                 <td style="width: 302px; height: 16px;">
                                                 </td>
                                                 <td style="height: 16px; width: 72px;">
                                                 </td>
                                                 <td style="width: 2295px; height: 16px">
                                                 </td>
                                                 <td style="width: 46px; height: 16px">
                                                 </td>
                                                 <td style="height: 16px">
                                                 </td>
                                                 <td style="width: 677px; height: 16px">
                                                 </td>
                                                 <td style="width: 3px; height: 16px">
                                                 </td>
                                             </tr>--%></TBODY></TABLE></TD></TR></TBODY></TABLE></asp:View> <asp:View id="vwAttachedDocument" runat="server"><TABLE style="HEIGHT: 236px" width=1000><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 704px; HEIGHT: 161px" align=right><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 700px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 163px"><LEGEND><SPAN style="FONT-SIZE: 10pt"><STRONG><EM>DOCUMENTS DETAILS</EM></STRONG></SPAN></LEGEND><TABLE class="text" width=700><TBODY><TR><TD style="WIDTH: 212px"></TD><TD style="WIDTH: 212px"><asp:HiddenField id="hdfAttachDoc2" runat="server"></asp:HiddenField> <INPUT style="DISPLAY: none" id="flAttachDoc2" type=file onchange="handlesAttachdoc2();" name="fileupload" /><INPUT style="WIDTH: 147px; HEIGHT: 30px" id="btnBrowseAttachDoc2" onclick="BrowseAttachdoc2();" type=submit value="Browse" runat="server" OnServerClick="btnBrowseAttachDoc2_ServerClick" /></TD><TD style="WIDTH: 212px" align=right>Validated By:</TD><TD style="WIDTH: 212px"><asp:TextBox id="txtattachvalidatedby" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 117px" align=right>Document Name:</TD><TD style="WIDTH: 212px"><asp:TextBox id="txtattachdocumentname" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD><TD align=right>Date Validated:</TD><TD style="WIDTH: 217px"><asp:TextBox id="txtattachdatevaidated" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 117px; HEIGHT: 18px" align=right>Document No.:</TD><TD style="WIDTH: 212px; HEIGHT: 18px"><asp:TextBox id="txtattachDocumentNo" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="HEIGHT: 18px" align=right>Remarks:</TD><TD style="WIDTH: 217px" rowSpan=2><asp:TextBox id="txtattachremarks" runat="server" Width="200px" CssClass="txtboxinspection" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 117px; HEIGHT: 18px"></TD><TD style="WIDTH: 212px; HEIGHT: 18px"></TD><TD style="HEIGHT: 18px"></TD></TR><TR><TD style="HEIGHT: 26px" align=center colSpan=4><asp:Button id="btnAttachdoc2" onclick="btnAttachdoc2_Click" runat="server" Width="122px" Text="Add To List"></asp:Button> <asp:Button id="Button7" runat="server" Width="122px" Text="Cancel"></asp:Button></TD></TR></TBODY></TABLE></FIELDSET> </TD><TD style="VERTICAL-ALIGN: top; WIDTH: 260px" align=center rowSpan=2><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 252px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 340px" id="fieldsetimage2"><LEGEND>ATTACHED DOCUMENTS</LEGEND><asp:Image id="imgattach" runat="server" Width="219px" ImageUrl="~/images/DefaulScannedDocuments.jpg" Height="291px"></asp:Image></FIELDSET> &nbsp;</TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 704px; HEIGHT: 154px" align=right><asp:GridView id="grdLandAttachdoc" runat="server" Width="700px" OnSelectedIndexChanged="grdLandAttachdoc_SelectedIndexChanged" DataKeyNames="IdentityNo,DocuId" SkinID="GridView" PageSize="5" Height="170px" BorderStyle="Solid" BorderWidth="1px" OnRowDataBound="grdLandAttachdoc_RowDataBound" BorderColor="Silver"><Columns>
<asp:BoundField DataField="DocumentName" HeaderText="Document Name">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DocumentNo" HeaderText="Document No.">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ValidatedBy" HeaderText="Validated By">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DateValidated" DataFormatString="{0:d}" HeaderText="Date Validated">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Remarks" HeaderText="Remarks">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView> </TD></TR></TBODY></TABLE></asp:View></asp:MultiView></FIELDSET><BR /></asp:View> <asp:View id="vwBuilding" runat="server"><TABLE style="WIDTH: 1000px; TEXT-ALIGN: center"><TBODY><TR><TD colSpan=2><TABLE style="WIDTH: 1000px" id="Table38" class="strip"><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: left" align=center><STRONG>Goods</STRONG></TD></TR></TBODY></TABLE></TD></TR><TR><TD colSpan=2><asp:GridView id="grdBuildingGoods" runat="server" Width="800px" OnSelectedIndexChanged="grdBuildingGoods_SelectedIndexChanged" DataKeyNames="POHdr_ID,PODtl_ID,Item_ID,PropertyDetai_ID,Program_id,Project_ID,Item_Desc,Function_ID,RC_ID,Qty,AcquisitionCost,type" SkinID="GridViewGL" AllowPaging="True" PageSize="4" OnRowDataBound="grdBuildingGoods_RowDataBound"><Columns>
<asp:BoundField DataField="type" HeaderText="Type of Building">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Serial No."></asp:BoundField>
<asp:BoundField DataField="DatePurchased" DataFormatString="{0:d}" HeaderText="Date Purchased">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="AcquisitionCost" DataFormatString="{0:N}" HeaderText="Acquisition Cost">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Market Value"></asp:BoundField>
<asp:BoundField DataField="Status_AIR" HeaderText="Status"></asp:BoundField>
</Columns>
</asp:GridView></TD></TR><TR><TD colSpan=2><TABLE id="Table14" class="strip" width=1000><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: left"><STRONG>BUILDING INFORMATION</STRONG></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 800px"><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 800px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 225px"><BR /><TABLE id="Table35" width=800><TBODY><TR><TD style="WIDTH: 20px" class="text5" align=left></TD><TD style="WIDTH: 120px; HEIGHT: 18px" class="column_LeftBold" align=left>Building Control No.</TD><TD style="WIDTH: 7px; HEIGHT: 18px">:</TD><TD style="WIDTH: 247px" class="text3" align=left><asp:TextBox id="txtbuildingcontolno" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 132px; HEIGHT: 18px" class="column_LeftBold" align=left>Building Use</TD><TD style="WIDTH: 2px; HEIGHT: 18px">:</TD><TD style="WIDTH: 180px" class="text3"><asp:TextBox id="txtbuildinguse" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 20px" class="text5" align=left></TD><TD style="WIDTH: 120px" class="column_LeftBold" align=left>Building Code</TD><TD style="WIDTH: 7px">:</TD><TD style="WIDTH: 247px" class="text3" align=left><asp:TextBox id="txtbuildingcode" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 132px" class="column_LeftBold" align=left>Building Occupancy</TD><TD style="WIDTH: 2px">:</TD><TD style="WIDTH: 180px" class="text3"><asp:TextBox id="txtbuildingoccupancy" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 20px" class="text5" align=left></TD><TD style="WIDTH: 120px" class="column_LeftBold" align=left>Building Name</TD><TD style="WIDTH: 7px">:</TD><TD style="WIDTH: 247px" class="text3" align=left><asp:TextBox id="txtbuildingname" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 132px" class="column_LeftBold" align=left>Number of Floors</TD><TD style="WIDTH: 2px">:</TD><TD style="WIDTH: 180px" class="text3"><asp:TextBox id="txtbuildingnumberoffloors" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 20px" class="text5" align=left></TD><TD style="WIDTH: 120px" class="column_LeftBold" align=left>Address</TD><TD style="WIDTH: 7px">:</TD><TD style="WIDTH: 247px" class="text3" align=left><asp:TextBox id="txtbuildingaddress" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 132px" class="column_LeftBold" align=left>Avg. Area Per Floor</TD><TD style="WIDTH: 2px">:</TD><TD style="WIDTH: 180px" class="text3"><asp:TextBox id="txtbuildingavgareaperfloor" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 20px" class="text5" align=left></TD><TD style="WIDTH: 120px" class="column_LeftBold" align=left>Postal Code</TD><TD style="WIDTH: 7px">:</TD><TD style="WIDTH: 247px" class="text3" align=left><asp:TextBox id="txtbuildingpostalcode" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 132px" class="column_LeftBold" align=left>Cost per Area</TD><TD style="WIDTH: 2px">:</TD><TD style="WIDTH: 180px" class="text3"><asp:TextBox id="txtbuildingcostperarea" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 20px" class="text5" align=left></TD><TD style="WIDTH: 120px" class="column_LeftBold" align=left>Depreciation Rate</TD><TD style="WIDTH: 7px">:</TD><TD style="WIDTH: 247px" class="text3" align=left><asp:TextBox id="txtbuildingdepreciationrate" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 132px" class="column_LeftBold" align=left>Depreciated Value</TD><TD style="WIDTH: 2px">:</TD><TD style="WIDTH: 180px" class="text3"><asp:TextBox id="txtbuildingdepreciationvalue" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE><BR /><BR /></FIELDSET></TD><TD style="WIDTH: 200px"><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 191px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 225px"><TABLE class="textimage"><TBODY><TR><TD style="WIDTH: 191px; HEIGHT: 141px" class="textimage2" colSpan=2><asp:Image id="imgbuilding" runat="server" Width="151px" ImageUrl="~/images/BuildingDefaultImage.jpg" CssClass="textimage2" Height="124px" ImageAlign="Middle"></asp:Image></TD></TR><TR><TD style="WIDTH: 80px" class="textimage">Date Taken:</TD><TD style="WIDTH: 100px" class="textimage1"><asp:TextBox id="txtbuildingdatetaken" runat="server" Width="87px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 80px" class="textimage">Uploaded By:</TD><TD style="WIDTH: 100px" class="textimage1"><asp:TextBox id="txtbuildinguploadedby" runat="server" Width="87px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 80px" class="textimage">Position:</TD><TD style="WIDTH: 100px" class="textimage1"><asp:TextBox id="txtbuildingposition" runat="server" Width="87px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD></TR></TBODY></TABLE><BR /><TABLE style="WIDTH: 882px" id="tbbuildingButton" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 132px; HEIGHT: 26px"><asp:Button id="btnConstructionDetails" onclick="btnConstructionDetails_Click" runat="server" Width="129px" Text="Construction Details" CssClass="Initial"></asp:Button></TD><TD style="HEIGHT: 26px"><asp:Button id="btnBuildingInformation" onclick="btnBuildingInformation_Click" runat="server" Width="128px" Text="Building Information" CssClass="Initial"></asp:Button></TD><TD style="HEIGHT: 26px"><asp:Button id="btnOwnersInformation" onclick="btnOwnersInformation_Click" runat="server" Width="126px" Text="Owner's Information" CssClass="Initial"></asp:Button></TD><TD style="HEIGHT: 26px"><asp:Button id="btnOccupants" onclick="btnOccupants_Click" runat="server" Width="73px" Text="Occupants" CssClass="Initial"></asp:Button></TD><TD style="WIDTH: 5px; HEIGHT: 26px"><asp:Button id="btnPermitApplicationHistory" onclick="btnPermitApplicationHistory_Click" runat="server" Width="162px" Text="Permit Application History" CssClass="Initial"></asp:Button></TD><TD style="WIDTH: 48px; HEIGHT: 26px"><asp:Button id="btnInspectionHistory" onclick="btnInspectionHistory_Click" runat="server" Width="117px" Text="Inspection History" CssClass="Initial"></asp:Button></TD><TD style="WIDTH: 54px; HEIGHT: 26px"><asp:Button id="btnPaymentHistory" onclick="btnPaymentHistory_Click" runat="server" Width="107px" Text="Payment History" CssClass="Initial"></asp:Button></TD><TD style="WIDTH: 145px; HEIGHT: 26px"><asp:Button id="btnbuildingDocumentAttach" onclick="btnbuildingDocumentAttach_Click" runat="server" Width="143px" Text="Document Attachment" CssClass="Initial"></asp:Button></TD></TR></TBODY></TABLE><DIV style="BORDER-RIGHT: #669933 thin solid; BORDER-TOP: #669933 thin solid; BORDER-LEFT: #669933 thin solid; WIDTH: 1000px; BORDER-BOTTOM: #669933 thin solid; TEXT-ALIGN: center"><asp:MultiView id="mvBuilding" runat="server"><asp:View id="vwConstructionDetails" runat="server"><BR /><TABLE style="WIDTH: 950px; HEIGHT: 110px" id="Table6" onclick="return Table6_onclick()"><TBODY><TR><TD style="WIDTH: 80px" align=left></TD><TD style="WIDTH: 135px" class="column_LeftBold" align=left>Construction Type</TD><TD style="WIDTH: 13px" class="column_LeftBold">:</TD><TD style="WIDTH: 150px" class="text5"><asp:TextBox id="txtbuildingconstructiontype" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 160px" class="column_LeftBold" align=left>Project Cost</TD><TD style="WIDTH: 10px" class="column_LeftBold">:</TD><TD style="WIDTH: 150px" class="text5"><asp:TextBox id="txtbuildingprojectcost" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 81px" class="column_LeftBold" align=left>Date Issued</TD><TD style="WIDTH: 9px" class="column_LeftBold">:</TD><TD style="WIDTH: 150px" class="text5"><asp:TextBox id="txtbuildingdateissued" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 80px" align=left></TD><TD style="WIDTH: 135px" class="column_LeftBold" align=left>Date Started</TD><TD style="WIDTH: 13px" class="column_LeftBold">:</TD><TD style="WIDTH: 150px" class="text5"><asp:TextBox id="txtbuildingdatestarted" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 160px" class="column_LeftBold" align=left>Building Permit No.</TD><TD style="WIDTH: 10px" class="column_LeftBold">:</TD><TD style="WIDTH: 150px" class="text5"><asp:TextBox id="txtbuildingpermitno" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 81px" class="column_LeftBold" align=left>Remarks</TD><TD style="WIDTH: 9px" class="column_LeftBold">:</TD><TD style="WIDTH: 150px" class="text5"><asp:TextBox id="txtbuildingremarks" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD align=left></TD><TD class="column_LeftBold" align=left>Date Of Completion</TD><TD class="column_LeftBold">:</TD><TD class="text5"><asp:TextBox id="txtbuildingdatecompleted" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD class="column_LeftBold" align=left>Date Of Application</TD><TD class="column_LeftBold">:</TD><TD class="text5"><asp:TextBox id="txtbuildingdateofapplication" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD class="column_LeftBold" align=left></TD><TD class="column_LeftBold"></TD><TD class="text5"></TD></TR><TR><TD align=left colSpan=10> 
<HR style="WIDTH: 990px; HEIGHT: 1px" />
</TD></TR><TR><TD align=left colSpan=10><EM><STRONG>List Of Professionals</STRONG></EM></TD></TR><TR><TD align=center colSpan=10><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 150px" class="column_RightBold">Professional/Contractor :</TD><TD style="WIDTH: 250px" class="text5"><asp:DropDownList id="DropDownList1" runat="server" Width="230px" CssClass="txtboxinspection"></asp:DropDownList></TD><TD style="WIDTH: 100px" class="column_RightBold"></TD><TD style="WIDTH: 125px" class="text5"></TD><TD style="WIDTH: 100px" class="column_RightBold"></TD><TD style="WIDTH: 180px" class="text5"></TD></TR><TR><TD style="WIDTH: 150px" class="column_RightBold">Name :</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="TextBox1" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px" class="column_RightBold">Cellphone No. :</TD><TD style="WIDTH: 125px" class="text5"><asp:TextBox id="TextBox4" runat="server" Width="125px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px" class="column_RightBold">PTR No. :</TD><TD style="WIDTH: 180px" class="text5"><asp:TextBox id="TextBox7" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 150px" class="column_RightBold">Address :</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="TextBox2" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px" class="column_RightBold">Email Address :</TD><TD style="WIDTH: 125px" class="text5"><asp:TextBox id="TextBox5" runat="server" Width="125px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px" class="column_RightBold">Validity :</TD><TD style="WIDTH: 180px" class="text5"><asp:TextBox id="TextBox17" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 150px" class="column_RightBold">Telephone No. :</TD><TD style="WIDTH: 250px" class="text5"><asp:TextBox id="TextBox3" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px" class="column_RightBold">PRC No. :</TD><TD style="WIDTH: 125px" class="text5"><asp:TextBox id="TextBox6" runat="server" Width="125px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 100px" class="column_RightBold">Date Issued :</TD><TD style="WIDTH: 180px" class="text5"><asp:TextBox id="TextBox18" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE><asp:GridView id="grdlistofProfessional" runat="server" Width="950px" SkinID="GridView" PageSize="5"><Columns>
<asp:BoundField DataField="profeesionalcontractor" HeaderText="Profeesional Contractor"></asp:BoundField>
<asp:BoundField DataField="name" HeaderText="Name"></asp:BoundField>
<asp:BoundField DataField="address" HeaderText="Address"></asp:BoundField>
<asp:BoundField DataField="telephoneno" HeaderText="Telephone No."></asp:BoundField>
<asp:BoundField DataField="cellphoneno" HeaderText="Cellphone No."></asp:BoundField>
<asp:BoundField DataField="emailaddress" HeaderText="Email Address"></asp:BoundField>
<asp:BoundField DataField="prcno" HeaderText="PRC No."></asp:BoundField>
<asp:BoundField DataField="pirno" HeaderText="PIR No."></asp:BoundField>
<asp:BoundField DataField="validity" HeaderText="Validity"></asp:BoundField>
<asp:BoundField DataField="dateissued" HeaderText="Date Issued"></asp:BoundField>
</Columns>
</asp:GridView></TD></TR></TBODY></TABLE></asp:View> <asp:View id="vwbuildinginformation" runat="server"><TABLE width=1000><TBODY><TR><TD align=center><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 955px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 100px"><LEGEND><EM><STRONG><SPAN style="FONT-SIZE: 10pt">Basic Information</SPAN></STRONG></EM></LEGEND><TABLE id="Table36" width=950><TBODY><TR><TD style="WIDTH: 120px" class="column_LeftBold" align=left>Real Property PIN</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 180px" align=left><asp:TextBox id="txtbuildinginformationrealpropertyPIN" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 150px" class="column_LeftBold" align=left>Occupancy Count</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 180px"><asp:TextBox id="txtbuildinginformationoccupantcount" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 120px" class="column_LeftBold" align=left>Efficiency Rate(U/R)</TD><TD style="WIDTH: 5px" class="column_LeftBold" align=left>:</TD><TD style="WIDTH: 180px"><asp:TextBox id="txtbuildinginformationefficiencyrate" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 125px" class="column_LeftBold" align=left>Property Code</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 180px" align=left><asp:TextBox id="txtbuildinginformationpropertycode" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 150px" class="column_LeftBold">Max Building Occupancy</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 180px"><asp:TextBox id="txtbuildinginformationmaxbuilding" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 125px" class="column_LeftBold" align=left>RU Ratio (R/U)</TD><TD style="WIDTH: 5px" class="column_LeftBold" align=left>:</TD><TD style="WIDTH: 180px"><asp:TextBox id="txtbuildinginformationRURatio" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px" class="column_LeftBold" align=left>Account Code</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 180px" align=left><asp:TextBox id="txtbuildinginformationaccountcode" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 150px" class="column_LeftBold">Entity Handle/Unique ID</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 180px"><asp:TextBox id="txtbuildinginformationentityhandle" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 120px" class="column_LeftBold" align=left>Comments</TD><TD style="WIDTH: 5px" class="column_LeftBold" align=left>:</TD><TD style="WIDTH: 180px"><asp:TextBox id="txtbuildinginformationComment" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD></TR><TR><TD align=center><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 955px; BORDER-BOTTOM: #669933 1px solid"><LEGEND><STRONG><EM><SPAN style="FONT-SIZE: 10pt">Area</SPAN></EM></STRONG></LEGEND><TABLE id="tbArea" cellSpacing=0 cellPadding=0 width=950 border=0><TBODY><TR><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Ext Gross Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5" align=left><asp:TextBox id="txtbuildinginformationextgrossarea" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 180px" class="column_LeftBold" align=left>Room Bldg. Common Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationroombldgcommonarea" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Total Non-Occup. Common Area</TD><TD style="WIDTH: 5px" class="column_LeftBold" align=left>: </TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationtotalnonoccup" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Int Gross Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5" align=left><asp:TextBox id="txtbuildinginformationintgrossarea" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 180px" class="column_LeftBold" align=left>Service Bldg. Common Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationservicebuildingcommonarea" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Total Non-Occup. Dept Area</TD><TD style="WIDTH: 5px" class="column_LeftBold" align=left>:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationtotalnonoccup2" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Ext Wall Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5" align=left><asp:TextBox id="txtbuildinginformationexitwallarea" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 180px" class="column_LeftBold" align=left>Service Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationServicearea" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Total Occup Area</TD><TD style="WIDTH: 5px" class="column_LeftBold" align=left>:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationtotaloccuparea2" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Avg. Area Per Emp</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5" align=left><asp:TextBox id="txtbuildinginformationavgareaperemp" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 180px" class="column_LeftBold" align=left>Suite Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationsuitearea" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Total Occup Common Area</TD><TD style="WIDTH: 5px" class="column_LeftBold" align=left>:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationtotaloccupcommonarea3" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Usable Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5" align=left><asp:TextBox id="txtbuildinginformationusablearea" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 180px" class="column_LeftBold" align=left>Total Emp. Dept Area(fld not used)</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationtotalemp" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Total Occup Dept Area</TD><TD style="WIDTH: 5px" class="column_LeftBold" align=left>:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationtotaloccupdeptarea" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Reamaining Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5" align=left><asp:TextBox id="txtbuildinginformationremainingarea" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 180px" class="column_LeftBold" align=left>Total Group Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationtotalgrouparea" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Total Room Area</TD><TD style="WIDTH: 5px" class="column_LeftBold" align=left>:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationtotalroomarea2" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Rentable Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5" align=left><asp:TextBox id="txtbuildinginformationrentablearea" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 180px" class="column_LeftBold" align=left>Total Group Common Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationcommongrouparea" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Total Room Common Area</TD><TD style="WIDTH: 5px" class="column_LeftBold" align=left>:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationtotalroomarea3" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Group Building Common Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5" align=left><asp:TextBox id="txtbuildinginformationgroupbuildingcommonarea" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 180px" class="column_LeftBold" align=left>Total Group Dept. Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationtotalgrouparea3" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Total Room Dept Area</TD><TD style="WIDTH: 5px" class="column_LeftBold" align=left>:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationtotalroomdeptarea2" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Non- Occu Bldg. Common Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5" align=left><asp:TextBox id="txtbuildinginformationnonoccubldg" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 180px" class="column_LeftBold" align=left>Total Lease Negotiated Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationtotallease" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Vert Pen Area</TD><TD style="WIDTH: 5px" class="column_LeftBold" align=left>:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationvertpinarea" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 175px" class="column_LeftBold" align=left>Occupable Bldg. Common Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5" align=left><asp:TextBox id="txtbuildinginformationocuupablebldg" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 180px" class="column_LeftBold" align=left>Total Non Occup. Area</TD><TD style="WIDTH: 5px" class="column_LeftBold">:</TD><TD style="WIDTH: 120px" class="text5"><asp:TextBox id="txtbuildinginformationtotalnonoccu" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 175px" class="column_LeftBold" align=left></TD><TD style="WIDTH: 5px" class="column_LeftBold" align=left></TD><TD style="WIDTH: 120px" class="text5"></TD></TR></TBODY></TABLE></FIELDSET> </TD></TR><TR><TD align=center><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 955px; BORDER-BOTTOM: #669933 1px solid"><LEGEND><SPAN style="FONT-SIZE: 10pt"><STRONG><EM>Values</EM></STRONG></SPAN></LEGEND><TABLE id="Table37" width=950><TBODY><TR><TD style="WIDTH: 200px; HEIGHT: 18px" class="column_LeftBold" align=left>Value Market</TD><TD style="WIDTH: 8px; HEIGHT: 18px" class="column_LeftBold">:</TD><TD style="WIDTH: 56px; HEIGHT: 18px" align=left><asp:TextBox id="txtbuildinginformationvaluemarket" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 341px; HEIGHT: 18px" class="column_LeftBold" align=left>Expense - Other Total</TD><TD style="WIDTH: 12px; HEIGHT: 18px" class="column_LeftBold">:</TD><TD style="WIDTH: 123px; HEIGHT: 18px"><asp:TextBox id="txtbuildinginformationExpenseother" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 407px; HEIGHT: 18px" class="column_RightBold" align=left>Expense Utility Total</TD><TD style="HEIGHT: 18px" class="column_LeftBold" align=left>:</TD><TD style="WIDTH: 3px; HEIGHT: 18px"><asp:TextBox id="txtbuildinginformationExpenseUtility" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 200px" class="column_LeftBold" align=left>Value Book</TD><TD style="WIDTH: 8px" class="column_LeftBold">:</TD><TD style="WIDTH: 56px" align=left><asp:TextBox id="txtbuildinginformationbookvalue" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 341px" class="column_LeftBold" align=left>Expense Opper Total</TD><TD style="WIDTH: 12px" class="column_LeftBold">:</TD><TD style="WIDTH: 123px"><asp:TextBox id="txtbuildinginformationExpenseoppertotal" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 407px" class="column_RightBold" align=left></TD><TD class="column_LeftBold" align=left></TD><TD style="WIDTH: 3px"></TD></TR><TR><TD style="WIDTH: 200px; HEIGHT: 16px" class="column_LeftBold" align=left>Income Total</TD><TD style="WIDTH: 8px; HEIGHT: 16px" class="column_LeftBold">:</TD><TD style="WIDTH: 56px; HEIGHT: 16px" align=left><asp:TextBox id="txtbuildinginformationIncometotal" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 341px; HEIGHT: 16px" class="column_LeftBold" align=left>Expense Tax Total</TD><TD style="WIDTH: 12px; HEIGHT: 16px" class="column_LeftBold">:</TD><TD style="WIDTH: 123px; HEIGHT: 16px"><asp:TextBox id="txtbuildinginformationExpensetaxtotal" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 407px; HEIGHT: 16px" class="column_RightBold" align=left></TD><TD style="HEIGHT: 16px" class="column_LeftBold" align=left></TD><TD style="WIDTH: 3px; HEIGHT: 16px"></TD></TR></TBODY></TABLE></FIELDSET></TD></TR></TBODY></TABLE></asp:View> <asp:View id="vwOwnersInformation" runat="server"><TABLE style="WIDTH: 950px; TEXT-ALIGN: center"><TBODY><TR><TD style="WIDTH: 100px"><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 473px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 200px"><LEGEND><STRONG><EM>Corporate</EM></STRONG></LEGEND><TABLE id="Table13" width=470><TBODY><TR><TD style="WIDTH: 30px; HEIGHT: 15px" class="text5" align=left></TD><TD style="WIDTH: 118px; HEIGHT: 15px" class="column_LeftBold" align=left></TD><TD style="WIDTH: 3px; HEIGHT: 15px" class="column_LeftBold"></TD><TD style="WIDTH: 288px; HEIGHT: 16px" class="text3" align=left></TD></TR><TR><TD style="WIDTH: 30px; HEIGHT: 15px" class="text5" align=left></TD><TD style="WIDTH: 118px; HEIGHT: 15px" class="column_LeftBold" align=left>Corporation Name</TD><TD style="WIDTH: 3px; HEIGHT: 15px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 16px" class="text3" align=left><asp:TextBox id="txtOwnersInformationcorporatename" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 30px; HEIGHT: 15px" class="text5" align=left></TD><TD style="WIDTH: 118px; HEIGHT: 16px" class="column_LeftBold" align=left>Address</TD><TD style="WIDTH: 3px; HEIGHT: 16px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 16px" class="text3" align=left><asp:TextBox id="txtOwnersInformationAddress" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 30px; HEIGHT: 15px" class="text5" align=left></TD><TD style="WIDTH: 118px; HEIGHT: 16px" class="column_LeftBold" align=left>Telephone No.</TD><TD style="WIDTH: 3px; HEIGHT: 16px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 16px" class="text3" align=left><asp:TextBox id="txtOwnersInformationTelephone" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 30px; HEIGHT: 15px" class="text5" align=left></TD><TD style="WIDTH: 118px" class="column_LeftBold" align=left>Cellphone No.</TD><TD style="WIDTH: 3px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 16px" class="text3" align=left><asp:TextBox id="txtOwnersInformationCellphone" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 30px; HEIGHT: 15px" class="text5" align=left></TD><TD style="WIDTH: 118px" class="column_LeftBold" align=left>Email Address</TD><TD style="WIDTH: 3px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 16px" class="text3" align=left><asp:TextBox id="txtOwnersInformationEmailaddress" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD><TD style="WIDTH: 100px" align=center><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 473px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 200px"><LEGEND><STRONG><EM>Officer</EM></STRONG></LEGEND><TABLE id="Table34" width=470><TBODY><TR><TD style="WIDTH: 20px; HEIGHT: 16px" class="text5" align=left></TD><TD style="WIDTH: 148px; HEIGHT: 16px" class="column_LeftBold" align=left>Chairman</TD><TD style="WIDTH: 3px; HEIGHT: 23px" class="column_LeftBold">:</TD><TD style="WIDTH: 3px; HEIGHT: 23px" class="text3" align=left><asp:TextBox id="txtOwnersInformationchairman" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 20px; HEIGHT: 16px" class="text5" align=left></TD><TD style="WIDTH: 148px; HEIGHT: 16px" class="column_LeftBold" align=left>Vice Chairman</TD><TD style="WIDTH: 3px; HEIGHT: 16px" class="column_LeftBold">:</TD><TD style="WIDTH: 3px; HEIGHT: 16px" class="text3" align=left><asp:TextBox id="txtOwnersInformationVicechairman" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 20px; HEIGHT: 16px" class="text5" align=left></TD><TD style="WIDTH: 148px; HEIGHT: 16px" class="column_LeftBold" align=left>President</TD><TD style="WIDTH: 3px; HEIGHT: 16px" class="column_LeftBold">:</TD><TD style="WIDTH: 3px; HEIGHT: 16px" class="text3" align=left><asp:TextBox id="txtOwnersInformationPresident" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 20px; HEIGHT: 16px" class="text5" align=left></TD><TD style="WIDTH: 148px; HEIGHT: 16px" class="column_LeftBold" align=left>Senior Vice President</TD><TD style="WIDTH: 3px" class="column_LeftBold">:</TD><TD style="WIDTH: 3px" class="text3" align=left><asp:TextBox id="txtOwnersInformationSeniorVicepresident" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 20px; HEIGHT: 16px" class="text5" align=left></TD><TD style="WIDTH: 148px; HEIGHT: 16px" class="column_LeftBold" align=left>Vice President</TD><TD style="WIDTH: 3px" class="column_LeftBold">:</TD><TD style="WIDTH: 3px" class="text3" align=left><asp:TextBox id="txtOwnersInformationvicepresident" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 20px; HEIGHT: 16px" class="text5" align=left></TD><TD style="WIDTH: 148px; HEIGHT: 16px" class="column_LeftBold" align=left>Assistant Vice President</TD><TD style="WIDTH: 3px" class="column_LeftBold">:</TD><TD style="WIDTH: 3px" class="text3" align=left><asp:TextBox id="txtOwnersInformationAssistantVP" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 20px; HEIGHT: 16px" class="text5" align=left></TD><TD style="WIDTH: 148px; HEIGHT: 16px" class="column_LeftBold" align=left>Corporate Secretary</TD><TD style="WIDTH: 3px" class="column_LeftBold">:</TD><TD style="WIDTH: 3px" class="text3" align=left><asp:TextBox id="txtOwnersInformationCorporateSecretary" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD></TR><TR><TD style="WIDTH: 100px"><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 470px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 350px"><LEGEND><STRONG><EM>Representative</EM></STRONG></LEGEND><TABLE id="Table39" width=470><TBODY><TR><TD style="WIDTH: 30px" class="text5" align=left></TD><TD style="WIDTH: 118px; HEIGHT: 15px" class="column_LeftBold" align=left>Representative 1</TD><TD style="WIDTH: 3px; HEIGHT: 15px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 15px" class="text3" align=left><asp:TextBox id="txtOwnersInformationRepresentative1" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 30px" class="text5" align=left></TD><TD style="WIDTH: 118px; HEIGHT: 16px" class="column_LeftBold" align=left>Position </TD><TD style="WIDTH: 3px; HEIGHT: 16px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 15px" class="text3" align=left><asp:TextBox id="txtOwnersInformationPosition1" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 30px" class="text5" align=left></TD><TD style="WIDTH: 118px; HEIGHT: 16px" class="column_LeftBold" align=left>Address</TD><TD style="WIDTH: 3px; HEIGHT: 16px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 15px" class="text3" align=left><asp:TextBox id="txtOwnersInformationaddress1" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 30px" class="text5" align=left></TD><TD style="WIDTH: 118px" class="column_LeftBold" align=left>Telephone No.</TD><TD style="WIDTH: 3px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 15px" class="text3" align=left><asp:TextBox id="txtOwnersInformationTelephone1" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 30px" class="text5" align=left></TD><TD style="WIDTH: 118px" class="column_LeftBold" align=left>Cellphone No.</TD><TD style="WIDTH: 3px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 15px" class="text3" align=left><asp:TextBox id="txtOwnersInformationCellphone1" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 30px" class="text5" align=left></TD><TD style="WIDTH: 118px" class="column_LeftBold" align=left>Email Address</TD><TD style="WIDTH: 3px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 15px" class="text3" align=left><asp:TextBox id="txtOwnersInformationEmailaddress1" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 30px" class="text5" align=left></TD><TD style="WIDTH: 118px; HEIGHT: 16px" class="column_LeftBold" align=left></TD><TD style="WIDTH: 3px; HEIGHT: 16px" class="column_LeftBold"></TD><TD style="WIDTH: 288px; HEIGHT: 15px" class="text3" align=left></TD></TR><TR><TD style="WIDTH: 30px" class="text5" align=left></TD><TD style="WIDTH: 118px" class="column_LeftBold" align=left>Representative 2</TD><TD style="WIDTH: 3px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 15px" class="text3" align=left><asp:TextBox id="txtOwnersInformationRepresentative2" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 30px" class="text5" align=left></TD><TD style="WIDTH: 118px; HEIGHT: 16px" class="column_LeftBold" align=left>Position</TD><TD style="WIDTH: 3px; HEIGHT: 16px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 15px" class="text3" align=left><asp:TextBox id="txtOwnersInformationPosition2" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 30px" class="text5" align=left></TD><TD style="WIDTH: 118px" class="column_LeftBold" align=left>Address</TD><TD style="WIDTH: 3px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 15px" class="text3" align=left><asp:TextBox id="txtOwnersInformationAddress2" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 30px" class="text5" align=left></TD><TD style="WIDTH: 118px" class="column_LeftBold" align=left>Telephone No</TD><TD style="WIDTH: 3px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 15px" class="text3" align=left><asp:TextBox id="txtOwnersInformationTelephone2" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 30px" class="text5" align=left></TD><TD style="WIDTH: 118px" class="column_LeftBold" align=left>Cellphone No.</TD><TD style="WIDTH: 3px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 15px" class="text3" align=left><asp:TextBox id="txtOwnersInformationCellphone2" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 30px" class="text5" align=left></TD><TD style="WIDTH: 118px" class="column_LeftBold" align=left>Email Address</TD><TD style="WIDTH: 3px" class="column_LeftBold">:</TD><TD style="WIDTH: 288px; HEIGHT: 15px" class="text3" align=left><asp:TextBox id="txtOwnersInformationEmailaddress2" runat="server" Width="280px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD><TD style="WIDTH: 100px; HEIGHT: 350px" align=center><TABLE style="HEIGHT: 270px" width=470><TBODY><TR><TD style="WIDTH: 242px; HEIGHT: 124px" align=center><TABLE style="HEIGHT: 108px" id="Table40" width=230><TBODY><TR><TD style="WIDTH: 230px; HEIGHT: 66px" id="Td7" align=center><asp:Image id="Image2" runat="server" Width="104px" ImageUrl="~/images/noPicture.JPG" Height="96px"></asp:Image></TD></TR><TR><TD style="WIDTH: 71px; HEIGHT: 16px" align=center><asp:TextBox id="txtOwnersInformationPerson1" runat="server" Width="210px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></TD><TD style="HEIGHT: 124px"><TABLE style="HEIGHT: 108px" id="Table41" width=230><TBODY><TR><TD style="WIDTH: 230px; HEIGHT: 66px" id="Td8" align=center><asp:Image id="Image3" runat="server" Width="104px" ImageUrl="~/images/noPicture.JPG" Height="96px"></asp:Image></TD></TR><TR><TD style="WIDTH: 71px; HEIGHT: 16px" align=center><asp:TextBox id="txtOwnersInformationPerson2" runat="server" Width="210px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 242px; HEIGHT: 152px"><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 235px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 180px"><LEGEND><STRONG><EM>Personal Information</EM></STRONG></LEGEND><TABLE id="Table42" width=230><TBODY><TR><TD style="WIDTH: 71px" class="textimage" align=left>Birth Date</TD><TD style="WIDTH: 5px" class="text5">:</TD><TD style="TEXT-ALIGN: left" class="textimage1" align=left><asp:TextBox id="txtOwnersInformationbirthdate1" runat="server" Width="130px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 71px" class="textimage" align=left>Age</TD><TD style="WIDTH: 5px" class="text5">:</TD><TD style="TEXT-ALIGN: left" class="textimage1" align=left><asp:TextBox id="txtOwnersInformationAge2" runat="server" Width="130px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 71px" class="textimage" align=left>Address</TD><TD style="WIDTH: 5px" class="text5">:</TD><TD style="TEXT-ALIGN: left" class="textimage1" align=left><asp:TextBox id="txtOwnersInformationAddress3" runat="server" Width="130px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 71px" class="textimage" align=left>Tel No.</TD><TD style="WIDTH: 5px" class="text5">:</TD><TD style="TEXT-ALIGN: left" class="textimage1" align=left><asp:TextBox id="txtOwnersInformationTelephoneno2" runat="server" Width="130px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 71px" class="textimage" align=left>Cell No.</TD><TD style="WIDTH: 5px" class="text5">:</TD><TD style="TEXT-ALIGN: left" class="textimage1" align=left><asp:TextBox id="txtOwnersInformationCellphoneno2" runat="server" Width="130px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 71px" class="textimage" align=left>E. Address</TD><TD style="WIDTH: 5px" class="text5">:</TD><TD style="TEXT-ALIGN: left" class="textimage1" align=left><asp:TextBox id="txtOwnersInformationEmailaddress3" runat="server" Width="130px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET> </TD><TD style="WIDTH: 235px; HEIGHT: 152px"><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 235px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 180px"><LEGEND><STRONG><EM>Personal Information</EM></STRONG></LEGEND><TABLE id="Table43" width=230><TBODY><TR><TD style="WIDTH: 70px" class="textimage" align=left>Birth Date</TD><TD style="WIDTH: 5px" class="text5">:</TD><TD style="HEIGHT: 16px" class="textimage1" align=left><asp:TextBox id="txtOwnersInformationBirthdate3" runat="server" Width="130px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 70px" class="textimage" align=left>Age</TD><TD style="WIDTH: 5px" class="text5">:</TD><TD class="textimage1" align=left><asp:TextBox id="txtOwnersInformationAge4" runat="server" Width="130px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 70px" class="textimage" align=left>Address</TD><TD style="WIDTH: 5px" class="text5">:</TD><TD class="textimage1" align=left><asp:TextBox id="txtOwnersInformationaddress4" runat="server" Width="130px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 70px" class="textimage" align=left>Tel No.</TD><TD style="WIDTH: 5px" class="text5">:</TD><TD class="textimage1" align=left><asp:TextBox id="txtOwnersInformationTelephoneno3" runat="server" Width="130px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 70px" class="textimage" align=left>Cell No.</TD><TD style="WIDTH: 5px" class="text5">:</TD><TD class="textimage1" align=left><asp:TextBox id="txtOwnersInformationCellphoneNo4" runat="server" Width="130px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 70px" class="textimage" align=left>E. Address</TD><TD style="WIDTH: 5px" class="text5">:</TD><TD class="textimage1" align=left><asp:TextBox id="txtOwnersInformationEmailaddress4" runat="server" Width="130px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></asp:View> <asp:View id="vwOccupants" runat="server"><TABLE style="HEIGHT: 368px" width=900><TBODY><TR><TD style="WIDTH: 450px; HEIGHT: 245px"><TABLE style="HEIGHT: 364px; BACKGROUND-COLOR: #c0c0c0" width=400><TBODY><TR><TD style="WIDTH: 216px; HEIGHT: 24px; TEXT-ALIGN: right">Building Storey No.:</TD><TD style="HEIGHT: 24px" align=left><asp:DropDownList id="ddBuildingStorey" runat="server" Width="174px">
                                                                        </asp:DropDownList></TD></TR><TR><TD align=center colSpan=2><asp:Image id="imgbuildingsketch" runat="server" Width="368px" ImageUrl="~/images/DefaultBuildingSkecth.jpg" Height="310px" BorderStyle="Solid" BorderWidth="15px" BorderColor="#c0c0c0"></asp:Image></TD></TR></TBODY></TABLE></TD><TD style="WIDTH: 450px; HEIGHT: 245px"><TABLE style="HEIGHT: 364px" width=450><TBODY><TR><TD align=center colSpan=2><asp:Image id="imgbuildingfloorplan" runat="server" Width="418px" ImageUrl="~/images/DefaultBuildingfloorplan.jpg" Height="344px" BorderStyle="Solid" BorderWidth="15px" BorderColor="#c0c0c0"></asp:Image></TD></TR></TBODY></TABLE></TD></TR><TR><TD colSpan=2><asp:GridView id="grdlistofOccupants" runat="server" Width="900px" SkinID="GridView" PageSize="5"><Columns>
<asp:TemplateField HeaderText="Unit No."><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("unitno") %>' id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
&nbsp;
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Occupant Name"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("occupantname") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
&nbsp;
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Business Name"><EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("businessname") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
&nbsp;
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Floor Area"><EditItemTemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("floorarea") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
&nbsp;
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ownership"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("ownership") %>' id="TextBox5"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("ownership") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Category"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("category") %>' id="TextBox6"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label runat="server" Text='<%# Bind("category") %>' id="Label5"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Permit Type"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("permittype") %>' id="TextBox7"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label runat="server" Text='<%# Bind("permittype") %>' id="Label6"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Permit No."><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("permitno") %>' id="TextBox8"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label runat="server" Text='<%# Bind("permitno") %>' id="Label7"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Date of Application"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("dateofapplication") %>' id="TextBox9"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label runat="server" Text='<%# Bind("dateofapplication") %>' id="Label8"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Date of Permit Issuance"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("dateofpermitissuance") %>' id="TextBox10"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label runat="server" Text='<%# Bind("dateofpermitissuance") %>' id="Label9"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("remarks") %>' id="TextBox11"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label runat="server" Text='<%# Bind("remarks") %>' id="Label10"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView> </TD></TR></TBODY></TABLE></asp:View> <asp:View id="vwpermitapplicationhistory" runat="server"><asp:GridView id="grdpermitapplicationhistory" runat="server" Width="700px" SkinID="GridView" PageSize="5"><Columns>
<asp:BoundField DataField="permittype" HeaderText="Permit Type"></asp:BoundField>
<asp:BoundField DataField="dateofapplication" HeaderText="Date of Application"></asp:BoundField>
<asp:BoundField DataField="permitno" HeaderText="Permit No."></asp:BoundField>
<asp:BoundField DataField="dateofpermitissuance" HeaderText="Date of Permit Issuance"></asp:BoundField>
<asp:BoundField DataField="remarks" HeaderText="Remarks"></asp:BoundField>
</Columns>
</asp:GridView> </asp:View> <asp:View id="vwInspectionHistory" runat="server"><asp:GridView id="grdInspectionHistory" runat="server" Width="700px" PageSize="5" SkinID="GridView"><Columns>
<asp:TemplateField HeaderText="Date Inspection"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("dateinspection") %>' id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtBldgDateInspection" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Inspection Type"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("inspectiontype") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtBldgInspectionType" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Mission Order No."><EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("missionorderno") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtBldgMissionOrder" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Inspector"><EditItemTemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("inspector") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtBldgInspector" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Violation"><EditItemTemplate>
<asp:TextBox id="TextBox5" runat="server" Text='<%# Bind("violation") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtBldgViolation" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><EditItemTemplate>
<asp:TextBox id="TextBox6" runat="server" Text='<%# Bind("remarks") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtBldgRemarks" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView> </asp:View> <asp:View id="vwPaymentHistory" runat="server"><asp:GridView id="grdPaymentHistory" runat="server" Width="700px" SkinID="GridView" PageSize="5"><Columns>
<asp:TemplateField HeaderText="Permit Type"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("permittype") %>' id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtBldgPermitType" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Permit No."><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("permitno") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtBldgPermitNo" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="O.R No."><EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("orno") %>'></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtBldgORno" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><EditItemTemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("amount") %>'></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
&nbsp;<asp:TextBox id="txtBldgAmount" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Payment Date"><EditItemTemplate>
<asp:TextBox id="TextBox5" runat="server" Text='<%# Bind("paymentdate") %>'></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
&nbsp;<asp:TextBox id="txtBldgPaymentDate" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView> </asp:View> <asp:View id="vwbuildingdocumentdetails" runat="server"><TABLE style="HEIGHT: 236px" width=1000><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 704px; HEIGHT: 161px" align=right><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 700px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 163px"><LEGEND><SPAN style="FONT-SIZE: 10pt"><STRONG><EM>DOCUMENTS DETAILS</EM></STRONG></SPAN></LEGEND><TABLE class="text" width=700><TBODY><TR><TD style="WIDTH: 105px"></TD><TD style="WIDTH: 105px"><asp:HiddenField id="HiddenField1" runat="server" OnValueChanged="hdfAttachDoc1_ValueChanged"></asp:HiddenField><INPUT style="DISPLAY: none" id="File1" type=file onchange="Handlechange2();" name="fileupload" /><INPUT style="WIDTH: 147px; HEIGHT: 30px" id="Submit1" onclick="HandleBrowseClick2();" type=submit value="Browse" runat="server" OnServerClick="btnBuildingBrowse_ServerClick" /></TD><TD style="WIDTH: 105px" align=right>Validated By:</TD><TD style="WIDTH: 105px"><asp:TextBox id="TextBox14" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 105px" align=right>Agency :</TD><TD style="WIDTH: 105px"><asp:TextBox id="TextBox15" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 105px" align=right>Date Validated:</TD><TD style="WIDTH: 105px"><asp:TextBox id="TextBox16" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox> <cc1:CalendarExtender id="CalendarExtender18" runat="server" TargetControlID="txtdatevalidated"></cc1:CalendarExtender></TD></TR><TR><TD style="WIDTH: 117px" align=right>Document Name:</TD><TD style="WIDTH: 117px"><asp:TextBox id="TextBox19" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 117px" align=right>Remarks:</TD><TD style="WIDTH: 117px" rowSpan=2><asp:TextBox id="TextBox20" runat="server" Width="200px" CssClass="txtboxinspection" Height="37px" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 117px; HEIGHT: 18px" class="text4">Document No.:</TD><TD style="WIDTH: 230px"><asp:TextBox id="TextBox21" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 105px; HEIGHT: 18px"></TD></TR><TR><TD align=center colSpan=4><asp:Button id="Button1" runat="server" Width="122px" Text="Add To List"></asp:Button> <asp:Button id="Button3" runat="server" Width="122px" Text="Cancel"></asp:Button></TD></TR></TBODY></TABLE></FIELDSET> </TD><TD style="VERTICAL-ALIGN: top; WIDTH: 250px" align=center rowSpan=2><FIELDSET style="BORDER-RIGHT: #669933 1px solid; BORDER-TOP: #669933 1px solid; BORDER-LEFT: #669933 1px solid; WIDTH: 252px; BORDER-BOTTOM: #669933 1px solid; HEIGHT: 340px"><LEGEND>ATTACHED DOCUMENTS</LEGEND><asp:Image id="Image6" runat="server" Width="228px" ImageUrl="~/images/DefaulScannedDocuments.jpg" Height="291px"></asp:Image><BR /></FIELDSET> </TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 704px; HEIGHT: 154px" align=right><asp:GridView id="grdocumentdetails" runat="server" Width="700px" SkinID="GridView" PageSize="5" Height="170px" BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver"><Columns>
<asp:BoundField DataField="DocumentName" HeaderText="Document Name">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DocumentNo" HeaderText="Document No.">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ValidatedBy" HeaderText="Validated By"></asp:BoundField>
<asp:BoundField DataField="DateValidated" DataFormatString="{0:d}" HeaderText="Date Validated">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Remarks" HeaderText="Remarks">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView></TD></TR></TBODY></TABLE><%--<table style="height: 236px" width="1000px">
                                                    <tr>
                                                        <td align="center" style="width: 800px; height: 236px ; vertical-aligN:top" >
                                                            <fieldset  style="width: 700px;height:223px; border-right: #669933 1px solid; border-top: #669933 1px solid; border-left: #669933 1px solid; border-bottom: #669933 1px solid;">
                                                                <legend><span style="font-size: 10pt"><strong><em>DOCUMENTS DETAILS</em></strong></span></legend>
                                                                <asp:GridView ID="grdocumentdetails" runat="server" PageSize="5" SkinID="GridView" Width="650px">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="documentname" HeaderText="Document Name" />
                                                                        <asp:BoundField DataField="documentno" HeaderText="Document No." />
                                                                        <asp:BoundField DataField="validatedby" HeaderText="Validated By" />
                                                                        <asp:BoundField DataField="datevalidated" HeaderText="Date Validated" />
                                                                        <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </fieldset>
                                                        </td>
                                                        <td id="Td4" style="width: 200px; height: 236px ; vertical-align:top" align="center" >
                                                            <fieldset style="width:200px; height:194px; border-bottom: #669933 1px solid; border-left: #669933 1px solid; border-top: #669933 1px solid; border-right: #669933 1px solid; " >
                                                                <asp:Image ID="ImgBuildingsacnnedDoc" runat="server" Height="222px" Width="255px" ImageUrl="~/images/DefaulScannedDocuments.jpg" /></fieldset>
                                                        </td>
                                                    </tr>
                                                </table>--%></asp:View> </asp:MultiView></DIV></asp:View> <asp:View id="vwMotorVehicle" runat="server"><DIV style="TEXT-ALIGN: center"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="HEIGHT: 38px" colSpan=2><TABLE style="WIDTH: 1000px" id="Table18" class="strip"><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: left"><STRONG>TRANSPORTATION INFORMATION</STRONG></TD></TR></TBODY></TABLE></TD></TR><TR><TD colSpan=2><asp:Panel id="Panel4" runat="server" Width="1000px" CssClass="InspectionAccptPANEL" ScrollBars="Vertical"><asp:GridView id="grdMotor" runat="server" Width="980px" DataKeyNames="Item_ID,Qty,Cost,PODtl_ID,type,RC_ID,Function_ID,Project_ID,Program_id" SkinID="GridViewGL" HorizontalAlign="Center"><Columns>
<asp:BoundField DataField="type" HeaderText="TYPE OF SERVICE">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="PLATE NO."><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("plateno") %>'></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtMotorPlateNo" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
<asp:BoundField DataField="datepurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="MARKET VALUE"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
&nbsp;<asp:TextBox  id="txtMotorMV" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="CONDITION"><EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
&nbsp;<asp:TextBox id="txtMotorCondition" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="LOCATION"><EditItemTemplate>
<asp:TextBox id="TextBox4" runat="server"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
&nbsp;<asp:TextBox id="txtMotorLoc" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
<asp:BoundField DataField="status" HeaderText="STATUS">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Item_ID" Visible="False"><EditItemTemplate>
<asp:TextBox id="TextBox5" runat="server"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lblItemID" runat="server" Text='<%# Bind("Item_ID") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTrans" runat="server" ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
</Columns>
</asp:GridView> <asp:GridView id="grdMotor_Serial" runat="server" Width="980px" OnSelectedIndexChanged="grdMotor_Serial_SelectedIndexChanged" DataKeyNames="Item_ID,Qty,Cost,PODtl_ID,type,RC_ID,Function_ID,Project_ID,Program_id,SerialNo,Item_Serial_ID,Location,MarketValue,Condition,Item_Desc,Property_Dtl_ID" SkinID="GridViewGL" HorizontalAlign="Center" Visible="False" OnRowDataBound="grdMotor_Serial_RowDataBound"><Columns>
<asp:TemplateField><HeaderTemplate>
<asp:CheckBox id="chckbxTrans_ALL" runat="server" AutoPostBack="True" Text="ALL" OnCheckedChanged="chckbxTrans_ALL_CheckedChanged"></asp:CheckBox>
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="CheckBox1" runat="server" Width="50px"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="type" HeaderText="TYPE OF SERVICE">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SerialNo" HeaderText="PLATE NO."></asp:BoundField>
<asp:BoundField DataField="datepurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="MarketValue" DataFormatString="{0:N}" HeaderText="MARKET VALUE">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Condition" HeaderText="CONDITION">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Location" HeaderText="LOCATION">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Status" HeaderText="STATUS">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Property_Dtl_ID" HeaderText="Property_Dtl_ID"></asp:BoundField>
</Columns>
</asp:GridView> </asp:Panel> <TABLE style="LEFT: 0px; WIDTH: 1000px; TOP: 0px"><TBODY><TR><TD style="WIDTH: 200px"></TD><TD style="WIDTH: 100px"></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 400px; TEXT-ALIGN: center"><asp:Button id="btnSaveMotor" onclick="btnSaveMotor_Click" runat="server" Width="164px" Text="Save" Visible="False" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnUpdateMotor" onclick="btnUpdateMotor_Click" runat="server" Width="164px" Text="Update" Visible="False" OnClientClick="StartProgressBar();"></asp:Button> <asp:Button id="btnEditMotor" onclick="btnEditMotor_Click" runat="server" Width="164px" Text="Edit" Visible="False"></asp:Button><asp:Button id="btnCancelMotor" onclick="btnCancelMotor_Click" runat="server" Width="164px" Text="Cancel" Visible="False"></asp:Button></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 200px"></TD></TR></TBODY></TABLE></TD></TR><TR><TD colSpan=2><DIV style="TEXT-ALIGN: center"><TABLE style="WIDTH: 1000px" id="tbleTranspo" runat="server"><TBODY><TR><TD style="WIDTH: 100px"><FIELDSET style="WIDTH: 700px; HEIGHT: 245px" class="PanelBorder"><TABLE style="COLOR: white; BACKGROUND-COLOR: #c0c0c0; TEXT-ALIGN: center" id="Table15" width=700><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: center"><STRONG><SPAN style="COLOR: black">VEHICLE INFORMATION</SPAN></STRONG></TD></TR></TBODY></TABLE><TABLE id="Table16" width=700><TBODY><TR><TD style="WIDTH: 70px; HEIGHT: 18px" class="column_LeftBold" align=right>Name</TD><TD style="WIDTH: 5px; HEIGHT: 18px" class="text5">:</TD><TD style="WIDTH: 120px; HEIGHT: 18px" class="text3" align=left><asp:TextBox id="txtMotorVehicleName" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 80px" class="column_LeftBold" align=right>Model</TD><TD style="WIDTH: 5px" class="text5" align=left>:</TD><TD style="WIDTH: 120px" class="text3" align=left><asp:TextBox id="txtMotorVehicleModel" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 95px; HEIGHT: 18px" class="column_LeftBold" align=right>Wheel Capacity</TD><TD style="WIDTH: 5px; HEIGHT: 18px" class="text5">:</TD><TD style="WIDTH: 100px; HEIGHT: 18px" class="text3"><asp:TextBox id="txtMotorVehicleCapacity" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 70px; HEIGHT: 18px" class="column_LeftBold" align=right>Plate No.</TD><TD style="WIDTH: 5px; HEIGHT: 18px" class="text5">:</TD><TD style="WIDTH: 120px; HEIGHT: 18px" class="text3" align=left><asp:TextBox id="txtMotorVehiclePalte" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 80px" class="column_LeftBold" align=right>Chasis No.</TD><TD style="WIDTH: 5px" class="text5" align=left>:</TD><TD style="WIDTH: 120px" class="text3" align=left><asp:TextBox id="txtMotorVehicleChasisno" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 95px; HEIGHT: 18px" class="column_LeftBold" align=right>Gross Weigth</TD><TD style="WIDTH: 5px; HEIGHT: 18px" class="text5">:</TD><TD style="WIDTH: 100px; HEIGHT: 18px" class="text3"><asp:TextBox id="txtMotorVehicleGrossWeight" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 70px; HEIGHT: 18px" class="column_LeftBold" align=right>Motor No.</TD><TD style="WIDTH: 5px; HEIGHT: 18px" class="text5">:</TD><TD style="WIDTH: 120px; HEIGHT: 18px" class="text3" align=left><asp:TextBox id="txtMotorVehicleMotorNo" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 80px" class="column_LeftBold" align=right>Vehicle Color</TD><TD style="WIDTH: 5px" class="text5" align=left>:</TD><TD style="WIDTH: 120px" class="text3" align=left><asp:TextBox id="txtMotorVehicleColor" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 95px; HEIGHT: 18px" class="column_LeftBold" align=right>Seats</TD><TD style="WIDTH: 5px; HEIGHT: 18px" class="text5">:</TD><TD style="WIDTH: 100px; HEIGHT: 18px" class="text3"><asp:TextBox id="txtMotorVehicleSeat" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 700px"><TBODY><TR><TD style="WIDTH: 80px" class="text5" colSpan=4>
<HR style="WIDTH: 690px; HEIGHT: 2px" />
</TD></TR><TR><TD style="FONT-WEIGHT: bold; WIDTH: 600px; FONT-STYLE: italic" class="text5" colSpan=2>&nbsp; Vehicle Specification :</TD><TD style="FONT-WEIGHT: bold; WIDTH: 80px; FONT-STYLE: italic" class="text5">Warranty :</TD><TD style="WIDTH: 120px" class="text3"><asp:TextBox id="txtMotorVehicleWarranty" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 80px" class="text3"></TD><TD style="WIDTH: 350px" class="text3" rowSpan=2><asp:TextBox id="txtMotorVehicleSpecification" runat="server" Width="350px" CssClass="txtboxinspection" Height="28px" TextMode="MultiLine"></asp:TextBox></TD><TD style="FONT-WEIGHT: bold; WIDTH: 80px; FONT-STYLE: italic" class="text3"></TD><TD style="WIDTH: 120px" class="text3"></TD></TR><TR><TD style="WIDTH: 80px" class="text3"></TD><TD style="FONT-WEIGHT: bold; WIDTH: 80px; FONT-STYLE: italic" class="text3"></TD><TD style="WIDTH: 120px" class="text3"></TD></TR></TBODY></TABLE><TABLE id="Table17" width=700><TBODY><TR><TD style="WIDTH: 213px; HEIGHT: 14px" class="column_RightBold" align=right>Vehicle Owner</TD><TD style="WIDTH: 7px; HEIGHT: 14px" class="column_LeftBold">:</TD><TD style="WIDTH: 155px; HEIGHT: 14px" class="text3" align=left><asp:TextBox id="txtMotorVehicleOwner" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 150px" class="column_RightBold" align=right>Beneficial User</TD><TD style="WIDTH: 12px; HEIGHT: 14px" class="column_LeftBold" align=left>:</TD><TD style="WIDTH: 173px; HEIGHT: 14px" class="text3" align=left><asp:TextBox id="txtMotorVehicleBeneficialUser" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 213px; HEIGHT: 16px" class="column_RightBold" align=right>Declared Name</TD><TD style="WIDTH: 7px; HEIGHT: 16px" class="column_LeftBold">:</TD><TD style="WIDTH: 155px; HEIGHT: 16px" class="text3" align=left><asp:TextBox id="txtMotorVehicleDeclaredname" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 150px" class="column_RightBold" align=right></TD><TD style="WIDTH: 12px; HEIGHT: 16px" class="column_LeftBold" align=left></TD><TD style="WIDTH: 173px; HEIGHT: 16px" class="text3" align=left></TD></TR></TBODY></TABLE></FIELDSET></TD><TD style="WIDTH: 100px"><FIELDSET style="WIDTH: 290px; HEIGHT: 245px" class="PanelBorder"><DIV style="TEXT-ALIGN: center"><TABLE style="WIDTH: 290px; TEXT-ALIGN: center"><TBODY><TR><TD style="WIDTH: 290px; HEIGHT: 210px" align=center><asp:Image id="imgvehicle" runat="server" Width="270px" ImageUrl="~/images/blankImage.jpg" Height="190px"></asp:Image></TD></TR></TBODY></TABLE></DIV><TABLE style="WIDTH: 290px"><TBODY><TR><TD style="WIDTH: 80px" class="textimage2">Date :</TD><TD style="WIDTH: 80px" class="textimage2" align=left><asp:TextBox id="txtMotorVehicleDateTaken" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 80px" class="textimage2">By :</TD><TD style="WIDTH: 111px" class="textimage1" align=left><asp:TextBox id="txtMotorVehicleUploadedBy" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD></TR></TBODY></TABLE></DIV><DIV style="TEXT-ALIGN: center"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 100px"><TABLE style="WIDTH: 1000px" id="tblambulance" class="PanelBorder" runat="server"><TBODY><TR><TD style="WIDTH: 300px; BACKGROUND-COLOR: #c0c0c0"><STRONG>Vehicle Information</STRONG></TD><TD style="WIDTH: 300px; BACKGROUND-COLOR: #c0c0c0"><STRONG>Equipments</STRONG></TD><TD style="WIDTH: 400px" rowSpan=3><asp:Image id="Image7" runat="server" Width="350px" ImageUrl="~/images/Ambulance.jpg" CssClass="textimage2" Height="200px" ImageAlign="Middle"></asp:Image></TD></TR><TR><TD style="WIDTH: 300px; BORDER-BOTTOM: gray 2px solid"><SPAN style="COLOR: orangered"><STRONG>Ambulance Location<BR /><asp:TextBox id="txtAmbulanceLoc" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></STRONG></SPAN></TD><TD style="WIDTH: 300px" rowSpan=2><asp:TextBox id="txtAmbulanceEquip" runat="server" Width="250px" CssClass="txtboxinspection" Height="150px" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 300px"><TABLE style="WIDTH: 300px"><TBODY><TR><TD style="WIDTH: 75px" class="column_RightBold">Brand</TD><TD style="WIDTH: 5px" class="column_RightBold">:</TD><TD style="WIDTH: 220px" class="text5"><asp:TextBox id="txtAmbulanceBrand" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 75px" class="column_RightBold">Model</TD><TD style="WIDTH: 5px" class="column_RightBold">:</TD><TD style="WIDTH: 220px" class="text5"><asp:TextBox id="txtAmbulanceModel" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 75px" class="column_RightBold">Area</TD><TD style="WIDTH: 5px" class="column_RightBold">:</TD><TD style="WIDTH: 220px" class="text5"><asp:TextBox id="txtAmbulanceArea" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 75px" class="column_RightBold">Plate No.</TD><TD style="WIDTH: 5px" class="column_RightBold">:</TD><TD style="WIDTH: 220px" class="text5"><asp:TextBox id="txtAmbulancePlate" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 75px" class="column_RightBold">Seat </TD><TD style="WIDTH: 5px" class="column_RightBold">:</TD><TD style="WIDTH: 220px" class="text5"><asp:TextBox id="txtAmbulanceSeat" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 75px; HEIGHT: 18px" class="column_RightBold">Color</TD><TD style="WIDTH: 5px; HEIGHT: 18px" class="column_RightBold">:</TD><TD style="WIDTH: 220px; HEIGHT: 18px" class="text5"><asp:TextBox id="txtAmbulanceColor" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></DIV></TD></TR></TBODY></TABLE></DIV></asp:View> <asp:View id="vwEquipment" runat="server"><DIV style="TEXT-ALIGN: center"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD colSpan=2><TABLE id="Table20" class="strip" width=1000><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: left"><STRONG>Equipments</STRONG></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="HEIGHT: 167px; TEXT-ALIGN: center" colSpan=2><asp:Panel id="Panel1" runat="server" Width="1000px" CssClass="InspectionAccptPANEL" ScrollBars="Vertical"><asp:GridView id="grdEuipment" runat="server" Width="980px" DataKeyNames="Item_ID,Qty,Cost,PODtl_ID,type,RC_ID,Function_ID,Project_ID,Program_id,Item_Desc" SkinID="GridViewGL" HorizontalAlign="Center"><Columns>
<asp:BoundField DataField="type" HeaderText="TYPE OF EQUIPMENT">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="SERIAL NO."><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("SerialNo") %>'></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtEquipSerialNo" runat="server" Width="90px" AutoPostBack="True" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
<asp:BoundField DataField="datepurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle Width="100px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="MARKET VALUE"><EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtEquipMV" runat="server" Width="90px" AutoPostBack="True" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="CONDITION"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtEquipCondition" runat="server" Width="90px" AutoPostBack="True" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="LOCATION"><EditItemTemplate>
<asp:TextBox id="TextBox4" runat="server"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtEquipLoc" runat="server" Width="90px" AutoPostBack="True" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
<asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
<asp:TemplateField HeaderText="Item Code" Visible="False"><EditItemTemplate>
<asp:TextBox id="TextBox6" runat="server" Text='<%# Bind("Item_ID") %>'></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lblItemCode" runat="server" Text='<%# Bind("Item_ID") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
<asp:Label   id="lblEquip" runat="server"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView> <asp:GridView id="grdEuipment_Serial" runat="server" Width="980px" OnSelectedIndexChanged="grdEuipment_Serial_SelectedIndexChanged" DataKeyNames="Item_ID,Qty,Cost,PODtl_ID,type,RC_ID,Function_ID,Project_ID,Program_id,SerialNo,Item_Serial_ID,Location,MarketValue,Condition,Item_Desc,Property_Dtl_ID" SkinID="GridViewGL" HorizontalAlign="Center" PageSize="8" Visible="False" OnRowDataBound="grdEuipment_Serial_RowDataBound"><Columns>
<asp:TemplateField><HeaderTemplate>
<asp:CheckBox   id="CheckBox3" runat="server" AutoPostBack="True" Text="ALL" OnCheckedChanged="CheckBox3_CheckedChanged"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="CheckBox1" runat="server" Width="50px"></asp:CheckBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="10px"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="type" HeaderText="TYPE OF EQUIPMENT">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SerialNo" HeaderText="SERIAL NO."></asp:BoundField>
<asp:BoundField DataField="datepurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="MarketValue" DataFormatString="{0:N}" HeaderText="MARKET VALUE">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Condition" HeaderText="CONDITION">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Location" HeaderText="LOCATION">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Status" HeaderText="STATUS">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Property_Dtl_ID" HeaderText="Property_Dtl_ID"></asp:BoundField>
</Columns>
</asp:GridView></asp:Panel>&nbsp;<DIV style="TEXT-ALIGN: center"><TABLE style="LEFT: 0px; WIDTH: 1000px; TOP: 0px"><TBODY><TR><TD style="WIDTH: 200px"></TD><TD style="WIDTH: 100px"></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 400px; TEXT-ALIGN: center"><asp:Button id="btnSaveSerial" onclick="btnSaveSerial_Click" runat="server" Width="164px" Text="Save" Visible="False" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnUpdateEquip" onclick="btnUpdateEquip_Click" runat="server" Width="164px" Text="Update" Visible="False" OnClientClick="StartProgressBar();"></asp:Button> <asp:Button id="btnEditEquip" onclick="btnEditEquip_Click" runat="server" Width="164px" Text="Edit" Visible="False"></asp:Button> <asp:Button id="btnCancel2" onclick="btnCancel2_Click" runat="server" Width="164px" Text="Cancel" Visible="False"></asp:Button></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 200px"></TD></TR></TBODY></TABLE></DIV></TD></TR><TR><TD style="WIDTH: 600px"><FIELDSET style="WIDTH: 600px; HEIGHT: 230px" class="PanelBorder"><TABLE style="COLOR: white; BACKGROUND-COLOR: #c0c0c0; TEXT-ALIGN: center" id="Table1" width=600><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 15px; TEXT-ALIGN: center"><STRONG><SPAN style="COLOR: black">EQUIPMENT INFORMATION</SPAN></STRONG></TD></TR></TBODY></TABLE><TABLE id="Table2" width=600><TBODY><TR><TD style="WIDTH: 110px; HEIGHT: 18px" class="column_LeftBold" align=right>Name</TD><TD style="WIDTH: 5px; HEIGHT: 16px" class="text4">:</TD><TD style="WIDTH: 180px" class="text3" align=left><asp:TextBox id="txtEquipmentName" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 120px; HEIGHT: 18px" class="column_LeftBold" align=right>Dimension </TD><TD style="WIDTH: 5px; HEIGHT: 16px" class="text4" align=left>:</TD><TD style="WIDTH: 180px" class="text3" align=left><asp:TextBox id="txtEquipmentDimension" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 110px; HEIGHT: 18px" class="column_LeftBold" align=right>Description</TD><TD style="WIDTH: 5px; HEIGHT: 16px" class="text4">:</TD><TD style="WIDTH: 180px" class="text3" align=left rowSpan=2><asp:TextBox id="txtEquipmentDescription" runat="server" Width="180px" CssClass="txtboxinspection" Height="32px" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 120px; HEIGHT: 18px" class="column_LeftBold" align=right>Area Capacity</TD><TD style="WIDTH: 5px; HEIGHT: 16px" class="text4" align=left>:</TD><TD style="WIDTH: 180px" class="text3" align=left><asp:TextBox id="txtEquipmentAreaCapacity" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 110px; HEIGHT: 18px" class="column_LeftBold" align=right></TD><TD style="WIDTH: 5px; HEIGHT: 16px" class="text4"></TD><TD style="WIDTH: 120px; HEIGHT: 18px" class="column_LeftBold" align=right>Model </TD><TD style="WIDTH: 5px; HEIGHT: 16px" class="text4" align=left>:</TD><TD style="WIDTH: 180px" class="text3" align=left><asp:TextBox id="txtEquipmentModel" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 110px; HEIGHT: 18px" class="column_LeftBold" align=right>Power Input</TD><TD style="WIDTH: 5px; HEIGHT: 16px" class="text4">:</TD><TD style="WIDTH: 180px" class="text3" align=left><asp:TextBox id="txtEquipmentpowerinput" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 120px; HEIGHT: 18px" class="column_LeftBold" align=right>Warranty </TD><TD style="WIDTH: 5px; HEIGHT: 16px" class="text4" align=left>:</TD><TD style="WIDTH: 180px" class="text3" align=left><asp:TextBox id="txtEquipmentWarranty" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 110px; HEIGHT: 18px" class="column_LeftBold" align=right><SPAN style="FONT-SIZE: 8pt">Depreciated Rate</SPAN></TD><TD style="WIDTH: 5px; HEIGHT: 16px" class="text4">:</TD><TD style="WIDTH: 180px" class="text3" align=left><asp:TextBox id="txtEquipmentDepreciatedRate" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 120px; HEIGHT: 18px" class="column_LeftBold" align=right><SPAN style="FONT-SIZE: 8pt">Depreciated Value</SPAN></TD><TD style="WIDTH: 5px; HEIGHT: 16px" class="text4" align=left>:</TD><TD style="WIDTH: 180px" class="text3" align=left><asp:TextBox id="txtEquipmentDepreciatedValue" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE><TABLE id="Table44" width=600><TBODY><TR><TD style="FONT-WEIGHT: bold; FONT-STYLE: italic; HEIGHT: 15px" class="text5" align=right colSpan=2>
<HR style="WIDTH: 590px; HEIGHT: 1px" />
</TD></TR><TR><TD style="FONT-WEIGHT: bold; WIDTH: 200px; FONT-STYLE: italic; HEIGHT: 15px" class="text5" align=right>&nbsp; Equipment Specifications :</TD><TD style="WIDTH: 400px" class="text3" align=right rowSpan=2><asp:TextBox id="txtEquipmentSpecification" runat="server" Width="400px" CssClass="txtboxinspection" Height="40px" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="FONT-WEIGHT: bold; WIDTH: 200px; FONT-STYLE: italic; HEIGHT: 15px" class="text5" align=right></TD></TR></TBODY></TABLE></FIELDSET></TD><TD style="WIDTH: 400px; TEXT-ALIGN: center" align=center><FIELDSET style="WIDTH: 380px; HEIGHT: 230px" class="PanelBorder"><TABLE style="WIDTH: 380px; TEXT-ALIGN: center"><TBODY><TR><TD style="WIDTH: 380px; HEIGHT: 180px; TEXT-ALIGN: center" align=center><asp:Image id="Image5" runat="server" Width="299px" ImageUrl="~/images/blankImage.jpg" CssClass="textimage2" Height="182px" BorderWidth="1px" ImageAlign="Middle"></asp:Image></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 380px"><TBODY><TR><TD style="WIDTH: 40px" class="textimage2">Date :</TD><TD style="WIDTH: 130px" align=left><asp:TextBox id="txtEquipmentDateTaken" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 40px" class="textimage2">By :</TD><TD style="WIDTH: 170px" align=left><asp:TextBox id="txtEquipmentUploadedBy" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD></TR></TBODY></TABLE></DIV></asp:View> <asp:View id="vwmachiniries" runat="server"><DIV style="TEXT-ALIGN: center"><TABLE style="WIDTH: 1000px" id="tablemachine"><TBODY><TR><TD colSpan=2><TABLE id="Table25" class="strip" width=1000><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 5px; TEXT-ALIGN: left"><STRONG>MACHINERY INFORMATION</STRONG></TD></TR></TBODY></TABLE></TD></TR><TR><TD colSpan=2><asp:Panel id="Panel3" runat="server" Width="1000px" CssClass="InspectionAccptPANEL" ScrollBars="Vertical"><asp:GridView id="grdMachineries" runat="server" Width="980px" DataKeyNames="Item_ID,Qty,Cost,PODtl_ID,type,RC_ID,Function_ID,Project_ID,Program_id" SkinID="GridViewGL" HorizontalAlign="Center"><Columns>
<asp:BoundField DataField="type" HeaderText="TYPE OF MACHINE">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="SERIAL NO."><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("serialno") %>' id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtMachineSerial" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
<asp:BoundField DataField="datepurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="MARKET VALUE"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtMachineMV" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="CONDITION"><EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox  id="txtMachineCondition" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="LOCATION"><EditItemTemplate>
<asp:TextBox id="TextBox4" runat="server"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
&nbsp;<asp:TextBox id="txtMachineLoc" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
<asp:BoundField DataField="status" HeaderText="STATUS"></asp:BoundField>
<asp:TemplateField HeaderText="Item Code" Visible="False"><ItemTemplate>
<asp:Label id="lblMacItemID" runat="server" Text='<%# Bind("Item_ID") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
<asp:Label   id="lblMach" runat="server"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView> <asp:GridView id="grdMachineries_Serial" runat="server" Width="980px" OnSelectedIndexChanged="grdMachineries_Serial_SelectedIndexChanged" DataKeyNames="Item_ID,Qty,Cost,PODtl_ID,type,RC_ID,Function_ID,Project_ID,Program_id,SerialNo,Item_Serial_ID,Location,MarketValue,Condition,Item_Desc,Property_Dtl_ID" SkinID="GridViewGL" HorizontalAlign="Center" Visible="False" OnRowDataBound="grdMachineries_Serial_RowDataBound"><Columns>
<asp:TemplateField><HeaderTemplate>
<asp:CheckBox   id="chckbxmachine_ALL" runat="server" AutoPostBack="True" Text="ALL" OnCheckedChanged="chckbxmachine_ALL_CheckedChanged"></asp:CheckBox>
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="CheckBox1" runat="server" Width="50px"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="type" HeaderText="TYPE OF MACHINE">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SerialNo" HeaderText="SERIAL NO."></asp:BoundField>
<asp:BoundField DataField="datepurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="MarketValue" DataFormatString="{0:N}" HeaderText="MARKET VALUE">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Condition" HeaderText="CONDITION">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Location" HeaderText="LOCATION">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Status" HeaderText="STATUS">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Property_Dtl_ID" HeaderText="Property_Dtl_ID"></asp:BoundField>
</Columns>
</asp:GridView></asp:Panel> <TABLE style="LEFT: 0px; WIDTH: 1000px; TOP: 0px"><TBODY><TR><TD style="WIDTH: 200px"></TD><TD style="WIDTH: 100px"></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 400px; TEXT-ALIGN: center"><asp:Button id="btnSaveSerialMac" onclick="btnSaveSerialMac_Click" runat="server" Width="164px" Text="Save" Visible="False" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnUpdateMac" onclick="btnUpdateMac_Click" runat="server" Width="164px" Text="Update" Visible="False" OnClientClick="StartProgressBar();"></asp:Button> <asp:Button id="btnEditMachine" onclick="btnEditMachine_Click" runat="server" Width="164px" Text="Edit" Visible="False"></asp:Button><asp:Button id="btnCancelMac" onclick="btnCancelMac_Click" runat="server" Width="164px" Text="Cancel" Visible="False"></asp:Button></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 200px"></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 650px"><FIELDSET style="WIDTH: 650px; HEIGHT: 285px" class="PanelBorder"><TABLE style="COLOR: white; BACKGROUND-COLOR: #c0c0c0; TEXT-ALIGN: center" id="Table8" width=650><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: center"><STRONG><SPAN style="COLOR: black">MACHINERY INFORMATION</SPAN></STRONG></TD></TR></TBODY></TABLE><TABLE id="Table9" width=650><TBODY><TR><TD style="WIDTH: 145px" class="column_LeftBold" align=right>Brand/Model</TD><TD style="WIDTH: 5px" class="text4">:</TD><TD style="WIDTH: 175px" class="text3" align=left><asp:TextBox id="txtMachiniriesBrandmodel" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 145px; HEIGHT: 16px" class="column_LeftBold" align=right>Unit No.</TD><TD style="WIDTH: 5px" class="text4" align=left>:</TD><TD style="WIDTH: 175px" class="text3" align=left><asp:TextBox id="txtMachiniriesUnitNo" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold" align=right>Description&nbsp;</TD><TD style="WIDTH: 5px" class="text4">:</TD><TD style="WIDTH: 175px" class="text3" align=left><asp:TextBox id="txtMachiniriesDesc" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 145px; HEIGHT: 16px" class="column_LeftBold" align=right>Working Load</TD><TD style="WIDTH: 5px" class="text4" align=left>:</TD><TD style="WIDTH: 175px" class="text3" align=left><asp:TextBox id="txtMachiniriesWorkingLoad" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold" align=right>Location</TD><TD style="WIDTH: 5px" class="text4">:</TD><TD style="WIDTH: 175px" class="text3" align=left><asp:TextBox id="txtMachiniriesLocation" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 145px; HEIGHT: 16px" class="column_LeftBold" align=right>Rated Speed</TD><TD style="WIDTH: 5px" class="text4" align=left>:</TD><TD style="WIDTH: 175px" class="text3" align=left><asp:TextBox id="txtMachiniriesRatedSpeed" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold" align=right>No. of Passengers </TD><TD style="WIDTH: 5px" class="text4">:</TD><TD style="WIDTH: 175px" class="text3" align=left><asp:TextBox id="txtMachiniriesNoofPassengers" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 145px; HEIGHT: 16px" class="column_LeftBold" align=right>Car Dimension</TD><TD style="WIDTH: 5px" class="text4" align=left>:</TD><TD style="WIDTH: 175px" class="text3" align=left><asp:TextBox id="txtMachiniriescardimension" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold" align=right>Service Floors</TD><TD style="WIDTH: 5px" class="text4">:</TD><TD style="WIDTH: 175px" class="text3" align=left><asp:TextBox id="txtMachiniriesServiceFloor" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 145px; HEIGHT: 16px" class="column_LeftBold" align=right></TD><TD style="WIDTH: 5px" class="text4" align=left></TD><TD style="WIDTH: 175px" class="text3" align=left></TD></TR><TR><TD style="WIDTH: 145px" class="column_LeftBold" align=right>Depreciation Rate&nbsp;</TD><TD style="WIDTH: 5px" class="text4">:</TD><TD style="WIDTH: 175px" class="text3" align=left><asp:TextBox id="txtMachiniriesDeprecitedRate" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 145px; HEIGHT: 16px" class="column_LeftBold" align=right>Depreciated Value</TD><TD style="WIDTH: 5px" class="text4" align=left>:</TD><TD style="WIDTH: 175px" class="text3" align=left><asp:TextBox id="txtMachiniriesDepreciatedValue" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE>
<HR style="WIDTH: 640px; HEIGHT: 1px" />
<TABLE style="HEIGHT: 18px" id="Table10" width=650><TBODY><TR><TD style="WIDTH: 145px" class="column_RightBold" align=right>Mech Permit No.</TD><TD style="WIDTH: 5px" class="text4" align=left>:</TD><TD style="WIDTH: 175px" align=left><asp:TextBox id="txtMachiniriesMechpermitno" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 145px" class="column_RightBold" align=right>Date Inspected</TD><TD style="WIDTH: 5px" class="text4" align=left>:</TD><TD style="WIDTH: 175px" align=left><asp:TextBox id="txtMachiniriesDateInspected" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox> <cc1:CalendarExtender id="CalendarExtender17" runat="server" TargetControlID="txtMachiniriesDateInspected"></cc1:CalendarExtender></TD></TR><TR><TD style="WIDTH: 145px" class="column_RightBold" align=right>Date to Operate</TD><TD style="WIDTH: 5px" class="text4" align=left>:</TD><TD style="WIDTH: 175px" align=left><asp:TextBox id="txtMachiniriesDatetoOperate" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox> <cc1:CalendarExtender id="CalendarExtender15" runat="server" TargetControlID="txtMachiniriesDatetoOperate"></cc1:CalendarExtender></TD><TD style="WIDTH: 145px" class="column_RightBold" align=right>Inspected By</TD><TD style="WIDTH: 5px" class="text4" align=left>:</TD><TD style="WIDTH: 175px" align=left><asp:TextBox id="txtMachiniriesInspectedBy" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 145px" class="column_RightBold" align=right>Date Issued </TD><TD style="WIDTH: 5px" class="text4" align=left>:</TD><TD style="WIDTH: 175px" align=left><asp:TextBox id="txtMachiniriesDateissued" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox> <cc1:CalendarExtender id="CalendarExtender16" runat="server" TargetControlID="txtMachiniriesDateissued"></cc1:CalendarExtender></TD><TD style="WIDTH: 145px" class="column_RightBold" align=right>Remarks</TD><TD style="WIDTH: 5px" class="text4" align=left>:</TD><TD style="WIDTH: 175px" align=left><asp:TextBox id="txtMachiniriesRemarks" runat="server" Width="175px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD><TD style="WIDTH: 350px"><FIELDSET style="WIDTH: 340px; HEIGHT: 285px" class="PanelBorder"><TABLE style="WIDTH: 350px; TEXT-ALIGN: center"><TBODY><TR><TD style="WIDTH: 340px; HEIGHT: 250px; TEXT-ALIGN: center" align=center><asp:Image id="imgmachiniries" runat="server" Width="296px" ImageUrl="~/images/blankImage.jpg" Height="212px"></asp:Image></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 350px"><TBODY><TR><TD style="WIDTH: 40px; HEIGHT: 6px" class="textimage2">Date :</TD><TD style="WIDTH: 130px; HEIGHT: 6px" align=left><asp:TextBox id="txtMachiniriesDateTaken" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 40px; HEIGHT: 6px" class="textimage2">By :</TD><TD style="WIDTH: 170px; HEIGHT: 6px" align=left><asp:TextBox id="txtMachiniriesUploadedBy" runat="server" Width="120px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD></TR></TBODY></TABLE></DIV></asp:View> <BR /><asp:View id="vwfurnitureandfixtures" runat="server"><TABLE style="WIDTH: 1000px; TEXT-ALIGN: center"><TBODY><TR><TD colSpan=2><TABLE style="WIDTH: 1000px" id="Table26" class="strip"><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: left"><STRONG>FURNITURE AND FIXTURE INFORMATION</STRONG></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="HEIGHT: 122px" colSpan=2><asp:Panel id="Panel2" runat="server" Width="1000px" CssClass="InspectionAccptPANEL" ScrollBars="Vertical"><asp:GridView id="grdfurnitureandfixtures" runat="server" Width="980px" DataKeyNames="Item_ID,Qty,Cost,PODtl_ID,type,RC_ID,Function_ID,Project_ID,Program_id" SkinID="GridViewGL" HorizontalAlign="Center"><Columns>
<asp:BoundField DataField="type" HeaderText="TYPE OF FURNITURE">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="SERIAL NO."><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("SerialNo") %>' id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtFurnitureSerial" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
<asp:BoundField DataField="datepurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="MARKET VALUE"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox  id="txtFurnitureMV" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="CONDITION"><EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox  id="txtFurnitureCondition" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="LOCATION"><EditItemTemplate>
<asp:TextBox id="TextBox4" runat="server"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox  id="txtFurnitureLoc" runat="server" Width="90px" CssClass="txtboxinspection"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="status" HeaderText="STATUS">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Item_ID" Visible="False"><EditItemTemplate>
<asp:TextBox id="TextBox5" runat="server"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lblItemID" runat="server" Text='<%# Bind("Item_ID") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><EditItemTemplate>
<asp:TextBox runat="server" id="TextBox6"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lblPropertyDtl" runat="server"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView> <asp:GridView id="grdFurniture_Serial" runat="server" Width="980px" OnSelectedIndexChanged="grdFurniture_Serial_SelectedIndexChanged" DataKeyNames="Item_ID,Qty,Cost,PODtl_ID,type,RC_ID,Function_ID,Project_ID,Program_id,SerialNo,Item_Serial_ID,Location,MarketValue,Condition,Item_Desc,Property_Dtl_ID" SkinID="GridViewGL" HorizontalAlign="Center" PageSize="8" Visible="False" OnRowDataBound="grdFurniture_Serial_RowDataBound"><Columns>
<asp:TemplateField><HeaderTemplate>
<asp:CheckBox   id="chckbxFurn_ALL" runat="server" AutoPostBack="True" Text="ALL" OnCheckedChanged="chckbxFurn_ALL_CheckedChanged"></asp:CheckBox>
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="CheckBox1" runat="server" Width="50px"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="type" HeaderText="TYPE OF FURNITURE">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SerialNo" HeaderText="SERIAL NO."></asp:BoundField>
<asp:BoundField DataField="datepurchased" DataFormatString="{0:d}" HeaderText="DATE PURCHASED">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="ACQUISITION COST">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="MarketValue" DataFormatString="{0:N}" HeaderText="MARKET VALUE">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Condition" HeaderText="CONDITION">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Location" HeaderText="LOCATION">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Status" HeaderText="STATUS">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Property_Dtl_ID" HeaderText="PropertyDtl_ID"></asp:BoundField>
</Columns>
</asp:GridView> </asp:Panel> <TABLE style="LEFT: 0px; WIDTH: 1000px; TOP: 0px"><TBODY><TR><TD style="WIDTH: 200px"></TD><TD style="WIDTH: 100px"></TD><TD style="VERTICAL-ALIGN: middle; WIDTH: 400px; TEXT-ALIGN: center"><asp:Button id="btnSaveFurn" onclick="btnSaveFurn_Click" runat="server" Width="164px" Text="Save" Visible="False" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnUpdateFurn" onclick="btnUpdateFurn_Click" runat="server" Width="164px" Text="Update" Visible="False" OnClientClick="StartProgressBar();"></asp:Button> <asp:Button id="btnEditFur" onclick="btnEditFur_Click" runat="server" Width="164px" Text="Edit" Visible="False"></asp:Button><asp:Button id="btnCancelFur" onclick="btnCancelFur_Click" runat="server" Width="164px" Text="Cancel" Visible="False"></asp:Button></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 200px"></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 600px"><FIELDSET style="WIDTH: 600px; HEIGHT: 230px" class="PanelBorder"><TABLE style="COLOR: white; BACKGROUND-COLOR: #c0c0c0; TEXT-ALIGN: center" id="Table7" width=600><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: center"><STRONG><SPAN style="COLOR: black">FURNITURE AND FIXTURES INFORMATION</SPAN></STRONG></TD></TR></TBODY></TABLE><TABLE id="Table19" width=600><TBODY><TR><TD style="WIDTH: 115px" class="column_LeftBold" align=right>Name</TD><TD style="WIDTH: 5px" class="text4">:</TD><TD style="WIDTH: 180px" class="text3" align=left><asp:TextBox id="txtFurnitureName" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 115px" class="column_LeftBold" align=right>Model</TD><TD style="WIDTH: 4px; HEIGHT: 16px" class="text4" align=left>:</TD><TD style="WIDTH: 180px; HEIGHT: 16px" class="text3" align=left><asp:TextBox id="txtFurnitureModel" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 115px" class="column_LeftBold" align=right>Description</TD><TD style="WIDTH: 5px" class="text4">:</TD><TD style="WIDTH: 180px" class="text3" align=left><asp:TextBox id="txtFurnitureDescription" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 115px" class="column_LeftBold" align=right>Warranty</TD><TD style="WIDTH: 4px" class="text4" align=left>:</TD><TD style="WIDTH: 180px; HEIGHT: 16px" class="text3" align=left><asp:TextBox id="txtFurnitureWarranty" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 115px" class="column_LeftBold" align=right>Dimension</TD><TD style="WIDTH: 5px" class="text4">:</TD><TD style="WIDTH: 180px" class="text3" align=left><asp:TextBox id="txtFurnitureDimension" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 115px" class="column_LeftBold" align=right>Area Capacity</TD><TD style="WIDTH: 4px" class="text4" align=left>:</TD><TD style="WIDTH: 180px; HEIGHT: 16px" class="text3" align=left><asp:TextBox id="txtFurnitureAreaCapacity" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 115px" class="column_LeftBold" align=right><SPAN style="FONT-SIZE: 8pt">Depreciated Rate</SPAN></TD><TD style="WIDTH: 5px" class="text4">:</TD><TD style="WIDTH: 180px" class="text3" align=left><asp:TextBox id="txtFurnitureDepreciatedRate" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 115px" class="column_LeftBold" align=right><SPAN style="FONT-SIZE: 8pt">Depreciated Value</SPAN></TD><TD style="WIDTH: 4px; HEIGHT: 16px" class="text4" align=left>:</TD><TD style="WIDTH: 180px; HEIGHT: 16px" class="text3" align=left><asp:TextBox id="txtFurnitureDepreciatedValue" runat="server" Width="180px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE>
<HR style="WIDTH: 590px; HEIGHT: 1px" />
<TABLE id="Table21" width=600><TBODY><TR><TD style="WIDTH: 172px; HEIGHT: 14px" class="text5" align=right> <STRONG><EM>Furniture Specifications:</EM></STRONG></TD><TD class="text5" colSpan=5 rowSpan=3><BR /><asp:TextBox id="txtFurnitureSpecification" runat="server" Width="400px" CssClass="txtboxinspection" Height="47px" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 172px; HEIGHT: 16px" class="text5" align=right></TD></TR><TR><TD style="WIDTH: 172px" class="text5" align=right></TD></TR></TBODY></TABLE></FIELDSET></TD><TD style="WIDTH: 400px"><FIELDSET style="WIDTH: 390px; HEIGHT: 230px" class="PanelBorder"><TABLE style="WIDTH: 380px; TEXT-ALIGN: center"><TBODY><TR><TD style="WIDTH: 380px; HEIGHT: 180px; TEXT-ALIGN: center" align=center><asp:Image id="Image1" runat="server" Width="299px" ImageUrl="~/images/blankImage.jpg" CssClass="textimage2" Height="182px" BorderWidth="1px" ImageAlign="Middle"></asp:Image></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 380px"><TBODY><TR><TD style="WIDTH: 40px" class="textimage2">Date :</TD><TD style="WIDTH: 130px" align=left><asp:TextBox id="txtFurnitureDateTaken" runat="server" Width="110px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 40px" class="textimage2">By :</TD><TD style="WIDTH: 170px" align=left><asp:TextBox id="txtFurnitureUploadedBy" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET> </TD></TR></TBODY></TABLE></asp:View> <asp:View id="vwofficesupplies" runat="server"><%-- <table id="Table31" style="color: white; background-color: #669933" width="1000px">
                                          <tbody>
                                              <tr>
                                                  <td style="width: 1000px; height: 16px; text-align: left">
                                                      <strong>SUPPLIES INFORMATION</strong></td>
                                              </tr>
                                          </tbody>
                                      </table>
                                      <table width="1000px">
                                          <tbody>
                                              <tr>
                                                  <td align="center" style="width: 490px">
                                                      <fieldset id="fielsetsuppl1" style="border-right: #669933 1px solid; border-top: #669933 1px solid;
                                                          border-left: #669933 1px solid; width: 490px; border-bottom: #669933 1px solid;
                                                          height: 240px">
                                                          <legend>SUPPLY DETAILS</legend>
                                                          <table id="tableofficesupplies" style="width: 490px">
                                                              <tbody>
                                                                  <tr>
                                                                      <td align="right" style="width: 119px; height: 19px">
                                                                      </td>
                                                                      <td style="height: 19px">
                                                                      </td>
                                                                      <td style="width: 82px; height: 19px">
                                                                      </td>
                                                                      <td align="right" style="width: 132px; height: 19px">
                                                                      </td>
                                                                      <td style="width: 3px; height: 19px">
                                                                      </td>
                                                                      <td style="width: 3px; height: 19px">
                                                                      </td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td align="right" style="width: 119px; height: 19px">
                                                                          Item Description</td>
                                                                      <td style="height: 19px">
                                                                          :</td>
                                                                      <td style="width: 82px; height: 19px">
                                                                        <asp:TextBox ID="txtOfficeSuppliesItemDescription" runat="server" Width="80px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                      <td align="right" style="width: 132px; height: 19px">
                                                                          Category</td>
                                                                      <td style="width: 3px; height: 19px">
                                                                          :</td>
                                                                      <td style="width: 3px; height: 19px">
                                                                            <asp:TextBox ID="txtOfficeSuppliesCategory" runat="server" Width="80px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td align="right" style="width: 119px; height: 18px">
                                                                          Brand Name</td>
                                                                      <td style="height: 18px">
                                                                          :</td>
                                                                      <td style="width: 82px; height: 18px">
                                                                           <asp:TextBox ID="txtOfficeSuppliesBrandname" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                      <td align="right" style="width: 132px; height: 18px">
                                                                          Length</td>
                                                                      <td style="width: 3px; height: 18px">
                                                                          :</td>
                                                                      <td style="width: 3px; height: 18px">
                                                                            <asp:TextBox ID="txtOfficeSuppliesLength" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td align="right" style="width: 119px; height: 18px">
                                                                          Supplier</td>
                                                                      <td style="height: 18px">
                                                                          :</td>
                                                                      <td style="width: 82px; height: 18px">
                                                                          <asp:LinkButton ID="lnksupplieroffice" runat="server" Width="100px">Supplier</asp:LinkButton>
                                                                      </td>
                                                                      <td align="right" style="width: 132px; height: 18px">
                                                                          Width</td>
                                                                      <td style="width: 3px; height: 18px">
                                                                          <span style="font-size: 7pt">:</span></td>
                                                                      <td style="font-size: 7pt; width: 3px; height: 18px">
                                                                           <asp:TextBox ID="txtOfficeSuppliesWidth" runat="server" Width="80px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td align="right" style="width: 119px; height: 18px">
                                                                          Size</td>
                                                                      <td style="height: 18px">
                                                                          :</td>
                                                                      <td style="width: 82px; height: 18px">
                                                                            <asp:TextBox ID="txtOfficeSuppliesSize" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                      <td align="right" style="width: 132px; height: 18px">
                                                                          Height</td>
                                                                      <td style="width: 3px; height: 18px">
                                                                          :</td>
                                                                      <td style="width: 3px; height: 18px">
                                                                            <asp:TextBox ID="txtOfficeSuppliesHeight" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td align="right" style="width: 119px">
                                                                          Color</td>
                                                                      <td>
                                                                          :</td>
                                                                      <td style="width: 82px">
                                                                            <asp:TextBox ID="txtOfficeSuppliesColor" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                      <td align="right" style="width: 132px">
                                                                          Weight</td>
                                                                      <td style="width: 3px">
                                                                          :</td>
                                                                      <td style="width: 3px">
                                                                            <asp:TextBox ID="txtOfficeSuppliesWeight" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td align="right" style="width: 119px; height: 14px">
                                                                          Depreciation Rate</td>
                                                                      <td style="height: 14px">
                                                                          :</td>
                                                                      <td style="width: 82px; height: 14px">
                                                                            <asp:TextBox ID="txtOfficeSuppliesDepreciatedRate" runat="server" Width="80px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                      <td align="right" style="width: 132px; height: 14px">
                                                                          Depreciation Values</td>
                                                                      <td style="width: 3px; height: 14px">
                                                                          :</td>
                                                                      <td style="width: 3px; height: 14px">
                                                                            <asp:TextBox ID="txtOfficeSuppliesDepreciatedvalue" runat="server" Width="80px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                  </tr>
                                                              </tbody>
                                                          </table>
                                                      </fieldset>
                                                  </td>
                                                  <td style="width: 300px">
                                                      <fieldset id="fielsetsuppl2" style="border-right: #669933 1px solid; border-top: #669933 1px solid;
                                                          border-left: #669933 1px solid; width: 300px; border-bottom: #669933 1px solid;
                                                          height: 240px">
                                                          <legend style="font-size: 10pt">EXPIRY DETAILS</legend>
                                                          <table style="font-size: 10pt; height: 113px" width="300">
                                                              <tbody>
                                                                  <tr>
                                                                      <td align="right" style="width: 84px; height: 18px">
                                                                          Form:</td>
                                                                      <td style="width: 78px; height: 18px">
                                                                            <asp:TextBox ID="txtOfficeSuppliesForm" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td align="right" style="width: 84px">
                                                                          OTC/Rx:</td>
                                                                      <td style="width: 78px">
                                                                             <asp:TextBox ID="txtOfficeSuppliesOTCRx" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td align="right" style="width: 84px">
                                                                          Mftg. Date:</td>
                                                                      <td style="width: 78px">
                                                                             <asp:TextBox ID="txtOfficeSuppliesmftgDate" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td align="right" style="width: 84px">
                                                                          <span>Batch:</span></td>
                                                                      <td style="width: 78px">
                                                                             <asp:TextBox ID="txtOfficeSuppliesBatch" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td align="right" style="width: 84px">
                                                                          Dose:</td>
                                                                      <td style="width: 78px">
                                                                             <asp:TextBox ID="txtOfficeSuppliesDose" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td align="right" style="width: 84px">
                                                                          Lot:
                                                                      </td>
                                                                      <td style="width: 78px">
                                                                             <asp:TextBox ID="txtOfficeSuppliesLot" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td align="right" style="width: 84px">
                                                                          Expiry Date:</td>
                                                                      <td align="left" style="width: 78px">
                                                                             <asp:TextBox ID="txtOfficeSuppliesExpiryDate" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td align="right" style="width: 84px">
                                                                          Alert:</td>
                                                                      <td align="left" style="width: 78px">
                                                                             <asp:TextBox ID="txtOfficeSuppliesAlert" runat="server" Width="70px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td colspan="2">
                                                                          <span style="font-size: 7pt">(one Month Before the Expiry date)</span></td>
                                                                  </tr>
                                                              </tbody>
                                                          </table>
                                                      </fieldset>
                                                  </td>
                                                  <td style="width: 191px">
                                                      <fieldset id="tbSuppliesimage" style="border-right: #669933 1px solid; border-top: #669933 1px solid;
                                                          border-left: #669933 1px solid; width: 203px; border-bottom: #669933 1px solid;
                                                          height: 240px">
                                                          <legend></legend>
                                                          <table style="height: 211px" width="191">
                                                              <tbody>
                                                                  <tr>
                                                                      <td align="center" style="width: 194px; height: 137px">
                                                                          <asp:Image ID="imgofficesupplies" runat="server" Height="124px" ImageUrl="~/images/supplies_icon.jpg"
                                                                              Width="138px" /></td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td>
                                                                          <table style="height: 8px" width="100%">
                                                                              <tbody>
                                                                                  <tr>
                                                                                      <td align="right" style="width: 89px; height: 34px">
                                                                                          Date Taken:</td>
                                                                                      <td style="width: 5px; height: 34px">
                                                                                           <asp:TextBox ID="txtOfficeSuppliesdatetaken" runat="server" Width="60px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                                  </tr>
                                                                                  <tr>
                                                                                      <td align="right" style="width: 89px">
                                                                                          Uploaded By:</td>
                                                                                      <td style="width: 5px">
                                                                                            <asp:TextBox ID="txtOfficeSuppliesUploadedBy" runat="server" Width="60px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                                  </tr>
                                                                                  <tr>
                                                                                      <td align="right" style="width: 89px">
                                                                                          Position:</td>
                                                                                      <td style="width: 5px">
                                                                                             <asp:TextBox ID="txtOfficeSuppliesPosition" runat="server" Width="60px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                                  </tr>
                                                                              </tbody>
                                                                          </table>
                                                                      </td>
                                                                  </tr>
                                                              </tbody>
                                                          </table>
                                                      </fieldset>
                                                  </td>
                                              </tr>
                                          </tbody>
                                      </table>--%><DIV style="TEXT-ALIGN: center"><DIV style="TEXT-ALIGN: center"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 1000px" align=center><TABLE style="WIDTH: 1000px" id="Table31" class="strip"><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: left"><STRONG style="TEXT-ALIGN: left">Goods</STRONG></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 1000px" align=center><asp:GridView id="grdOfficeSupp" runat="server" Width="990px" OnSelectedIndexChanged="grdOfficeSupp_SelectedIndexChanged" DataKeyNames="Item_ID,PODtl_ID,qty,Item_Desc,SuppName,Supplier_Id,Cost,AcquisitionCost" SkinID="GridViewGL" HorizontalAlign="Center" AllowPaging="True" OnPageIndexChanging="grdOfficeSupp_PageIndexChanging" OnRowDataBound="grdOfficeSupp_RowDataBound"><Columns>
<asp:TemplateField><HeaderTemplate>
<asp:CheckBox   id="chckbxOffice" runat="server" AutoPostBack="True" Text="ALL" OnCheckedChanged="chckbxOffice_CheckedChanged"></asp:CheckBox>
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox   id="CheckBox1" runat="server"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="unit" HeaderText="Unit">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="qty" HeaderText="QTY">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="QtyPerBox" HeaderText="QTY/BOX">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Total No of PCS">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Item_Desc" HeaderText="Description">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Serial No.">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DatePurchased" DataFormatString="{0:d}" HeaderText="Date Purchased">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="AcquisitionCost" DataFormatString="{0:N}" HeaderText="Acquisition Cost">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Location" Visible="False">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="status" HeaderText="Status"></asp:BoundField>
<asp:BoundField DataField="Item_ID" HeaderText="Item_ID"></asp:BoundField>
<asp:BoundField DataField="cost" HeaderText="cost"></asp:BoundField>
<asp:BoundField DataField="Supplier_ID" HeaderText="Supplier_ID"></asp:BoundField>
</Columns>
</asp:GridView></TD></TR><TR><TD style="WIDTH: 1000px" align=center><TABLE style="WIDTH: 950px; TEXT-ALIGN: center"><TBODY><TR><TD style="WIDTH: 600px; TEXT-ALIGN: center" align=center><FIELDSET style="WIDTH: 600px; HEIGHT: 245px" class="PanelBorder"><DIV style="TEXT-ALIGN: center"><DIV style="TEXT-ALIGN: center"><TABLE style="COLOR: white; BACKGROUND-COLOR: #c0c0c0; TEXT-ALIGN: center" id="Table23" width=600><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 15px; TEXT-ALIGN: center"><STRONG><SPAN style="COLOR: black">SUPPLIES&nbsp;INFORMATION</SPAN></STRONG></TD></TR></TBODY></TABLE></DIV></DIV><TABLE style="FONT-SIZE: 9pt; WIDTH: 600px; FONT-FAMILY: Verdana" id="Table11"><TBODY><TR><TD style="WIDTH: 120px; HEIGHT: 18px" class="column_RightBold" align=right rowSpan=1></TD><TD style="VERTICAL-ALIGN: top; WIDTH: 170px; HEIGHT: 21px" class="text5" rowSpan=1></TD><TD style="WIDTH: 120px" class="column_RightBold" align=right></TD><TD style="WIDTH: 170px" class="text5"></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 18px" class="column_RightBold" align=right rowSpan=1>Item Description :</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 170px; HEIGHT: 21px" class="text5" rowSpan=1><asp:TextBox id="txtOfficeItemDesc" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 120px" class="column_RightBold" align=right>Category :</TD><TD style="WIDTH: 170px" class="text5"><asp:TextBox id="txtOfficeCategory" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 18px" class="column_RightBold" align=right>Brand Name :</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 170px; HEIGHT: 21px" class="text5"><asp:TextBox id="txtOfficeBrandName" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 120px" class="column_RightBold" align=right>Length :</TD><TD style="WIDTH: 170px" class="text5"><asp:TextBox id="txtOfficeLength" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 18px" class="column_RightBold" align=right>Supplier :</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 170px; HEIGHT: 21px" class="text5"><asp:TextBox id="txtOfficeSupplier" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 120px" class="column_RightBold" align=right>Width :</TD><TD style="WIDTH: 170px" class="text5"><asp:TextBox id="txtOfficeWidth" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 18px" class="column_RightBold" align=right>Size :</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 170px; HEIGHT: 21px" class="text5"><asp:TextBox id="txtOfficeSize" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 120px" class="column_RightBold" align=right>Height :</TD><TD style="WIDTH: 170px" class="text5"><asp:TextBox id="txtOfficeHeight" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 18px" class="column_RightBold" align=right>Color :</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 170px; HEIGHT: 21px" class="text5"><asp:TextBox id="txtOfficeColor" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 120px" class="column_RightBold" align=right>Weight :</TD><TD style="WIDTH: 170px" class="text5"><asp:TextBox id="txtOfficeWeight" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 18px" class="column_RightBold" align=right>Depreciation Rate :</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 170px; HEIGHT: 21px" class="text5"><asp:TextBox id="txtOfficeDepRate" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 120px" class="column_RightBold" align=right>Depreciation Value:</TD><TD style="WIDTH: 170px" class="text5"><asp:TextBox id="txtOfficeDepValue" runat="server" Width="140px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD><TD style="WIDTH: 350px; TEXT-ALIGN: center" align=center><FIELDSET style="WIDTH: 350px; HEIGHT: 245px" class="PanelBorder"><TABLE style="WIDTH: 350px; TEXT-ALIGN: center"><TBODY><TR><TD style="WIDTH: 350px; HEIGHT: 201px; TEXT-ALIGN: center" align=center><asp:Image id="imgOffice" runat="server" Width="299px" ImageUrl="~/images/blankImage.jpg" CssClass="textimage2" Height="182px" BorderWidth="1px" ImageAlign="Middle"></asp:Image></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 350px; TEXT-ALIGN: center"><TBODY><TR><TD style="WIDTH: 35px; HEIGHT: 16px; TEXT-ALIGN: right"><SPAN style="FONT-FAMILY: Arial"><STRONG>Date :</STRONG></SPAN></TD><TD style="WIDTH: 150px; HEIGHT: 16px; TEXT-ALIGN: left" class="textimage1"><asp:TextBox id="txtOfficeDatetaken" runat="server" Width="100px" CssClass="txtboxinUpload"></asp:TextBox></TD><TD style="WIDTH: 25px; HEIGHT: 16px; TEXT-ALIGN: right" class="column_RightBold">By :</TD><TD style="WIDTH: 250px; HEIGHT: 16px" class="textimage1"><asp:TextBox id="txtOfficeUploadedBy" runat="server" Width="150px" CssClass="txtboxinUpload"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 100px; TEXT-ALIGN: center">&nbsp;&nbsp;</TD></TR></TBODY></TABLE></DIV></DIV></asp:View> <asp:View id="vwMedicalSupplies" runat="server"><DIV style="TEXT-ALIGN: center"><TABLE style="WIDTH: 1000px; TEXT-ALIGN: center"><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 38px; TEXT-ALIGN: center" align=center><TABLE style="WIDTH: 1000px" id="Table32" class="strip"><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: left"><STRONG>Goods</STRONG></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 1000px; TEXT-ALIGN: center" align=center><asp:GridView id="grdmedicalsupplies" runat="server" Width="1000px" OnSelectedIndexChanged="grdmedicalsupplies_SelectedIndexChanged1" DataKeyNames="Item_ID,PODtl_ID,qty,Item_Desc,SuppName,Supplier_Id,Cost,price,AcquisitionCost" SkinID="GridViewGL" HorizontalAlign="Center" AllowPaging="True" OnPageIndexChanging="grdmedicalsupplies_PageIndexChanging1" OnRowDataBound="grdmedicalsupplies_RowDataBound1"><Columns>
<asp:TemplateField><HeaderTemplate>
<asp:CheckBox   id="chckbxMed_ALL" runat="server" AutoPostBack="True" Text="ALL" OnCheckedChanged="chckbxMed_ALL_CheckedChanged"></asp:CheckBox>
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox   id="CheckBox4" runat="server"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="unit" HeaderText="Unit">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="qty" HeaderText="QTY">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="QtyPerBox" HeaderText="QTY/BOX">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Total No of PCS">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Item_Desc" HeaderText="Description">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Serial No.">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DatePurchased" DataFormatString="{0:d}" HeaderText="Date Purchased">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="AcquisitionCost" DataFormatString="{0:N}" HeaderText="Acquisition Cost">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Location" Visible="False"></asp:BoundField>
<asp:BoundField DataField="status" HeaderText="Status"></asp:BoundField>
<asp:BoundField DataField="Item_ID" HeaderText="Item_ID"></asp:BoundField>
<asp:BoundField DataField="cost" HeaderText="Cost"></asp:BoundField>
<asp:BoundField DataField="Supplier_ID" HeaderText="Supplier_ID"></asp:BoundField>
</Columns>
</asp:GridView></TD></TR><TR><TD style="WIDTH: 1000px; TEXT-ALIGN: center" align=center><DIV style="TEXT-ALIGN: center"><TABLE style="WIDTH: 1000px; TEXT-ALIGN: center"><TBODY><TR><TD style="WIDTH: 640px"><FIELDSET style="WIDTH: 640px; HEIGHT: 245px" class="PanelBorder"><DIV style="TEXT-ALIGN: center"><TABLE style="COLOR: white; BACKGROUND-COLOR: #c0c0c0; TEXT-ALIGN: center" id="Table12" width=640><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 15px; TEXT-ALIGN: center"><STRONG><SPAN style="COLOR: black">MEDICINE&nbsp;INFORMATION</SPAN></STRONG></TD></TR></TBODY></TABLE></DIV><BR /><TABLE style="FONT-SIZE: 10pt; WIDTH: 600px" id="Table22"><TBODY><TR><TD style="WIDTH: 120px" class="column_RightBold" align=right>Item Description :</TD><TD style="WIDTH: 150px; HEIGHT: 18px" class="text5" align=left><asp:TextBox id="txtOfficeMedicalItemDescription" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 150px; HEIGHT: 18px" class="column_RightBold" align=left>Delivery Date :</TD><TD style="WIDTH: 180px; HEIGHT: 18px" class="text5" align=left><asp:TextBox id="txtMedDeliveryDate" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox> <cc1:CalendarExtender id="CalendarExtender14" runat="server" TargetControlID="txtMedDeliveryDate"></cc1:CalendarExtender></TD></TR><TR><TD style="WIDTH: 120px" class="column_RightBold" align=right>Drug Name :</TD><TD style="WIDTH: 150px; HEIGHT: 18px" class="text5" align=left><asp:TextBox id="txtOfficeMedicalDrugname" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 150px; HEIGHT: 18px" class="column_RightBold" align=left>Depreciation Rate :</TD><TD style="WIDTH: 180px; HEIGHT: 18px" class="text5" align=left><asp:TextBox id="txtOfficeMedicalDepreciatedRate" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px" class="column_RightBold" align=right>Brand Name :</TD><TD style="WIDTH: 150px; HEIGHT: 18px" class="text5" align=left><asp:TextBox id="txtMedicalBrandName" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 150px; HEIGHT: 18px" class="column_RightBold" align=left>Depreciation Value :</TD><TD style="WIDTH: 180px; HEIGHT: 18px" class="text5" align=left><asp:TextBox id="txtOfficeMedicalDepreciationValue" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 120px" class="column_RightBold" align=right>&nbsp;Manufacturer :</TD><TD style="WIDTH: 150px; HEIGHT: 18px" class="text5" align=left><asp:TextBox id="txtMedicalSupplier" runat="server" Width="150px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 150px; HEIGHT: 18px" class="column_RightBold" align=left></TD><TD style="WIDTH: 180px; HEIGHT: 18px" class="text5" align=left></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 600px"><TBODY><TR><TD style="WIDTH: 600px" class="column_LeftBold">Remarks :</TD></TR><TR><TD style="WIDTH: 600px"><asp:TextBox id="txtMedRemarks" runat="server" Width="500px" CssClass="txtboxinspection" Height="40px" TextMode="MultiLine"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD><TD style="WIDTH: 350px; TEXT-ALIGN: center" align=center><FIELDSET style="WIDTH: 350px; HEIGHT: 245px" class="PanelBorder"><TABLE style="WIDTH: 350px; TEXT-ALIGN: center"><TBODY><TR><TD style="WIDTH: 350px; HEIGHT: 201px; TEXT-ALIGN: center" align=center><asp:Image id="Image4" runat="server" Width="299px" ImageUrl="~/images/blankImage.jpg" CssClass="textimage2" Height="182px" BorderWidth="1px" ImageAlign="Middle"></asp:Image></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 350px; TEXT-ALIGN: center"><TBODY><TR><TD style="WIDTH: 35px; HEIGHT: 16px; TEXT-ALIGN: right"></TD><TD style="WIDTH: 35px; HEIGHT: 16px; TEXT-ALIGN: right"><SPAN style="FONT-FAMILY: Arial"><STRONG>Date :</STRONG></SPAN></TD><TD style="WIDTH: 150px; HEIGHT: 16px; TEXT-ALIGN: left" class="textimage1"><asp:TextBox id="TextBox12" runat="server" Width="100px" CssClass="txtboxinUpload"></asp:TextBox></TD><TD style="WIDTH: 25px; HEIGHT: 16px; TEXT-ALIGN: right" class="column_RightBold">By :</TD><TD style="WIDTH: 250px; HEIGHT: 16px" class="textimage1"><asp:TextBox id="TextBox13" runat="server" Width="150px" CssClass="txtboxinUpload"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET><BR /></TD></TR></TBODY></TABLE></DIV></TD></TR></TBODY></TABLE></DIV></asp:View> <asp:View id="vwSupply" runat="server"><DIV style="TEXT-ALIGN: center"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 100px"><TABLE style="WIDTH: 1000px; POSITION: relative" id="Table24" class="strip"><TBODY><TR><TD style="WIDTH: 1000px; HEIGHT: 16px; TEXT-ALIGN: left"><STRONG>Goods</STRONG></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 100px"><asp:GridView id="grdSupply" runat="server" Width="1000px" OnSelectedIndexChanged="grdSupply_SelectedIndexChanged" OnPageIndexChanging="grdSupply_PageIndexChanging" AllowPaging="True" HorizontalAlign="Center" SkinID="GridViewGL" DataKeyNames="Item_ID,PODtl_ID,qty,Item_Desc,SuppName,Supplier_Id,Cost,price,AcquisitionCost" OnRowDataBound="grdSupply_RowDataBound"><Columns>
<asp:TemplateField><HeaderTemplate>
<asp:CheckBox   id="CheckBox2" runat="server" AutoPostBack="True" Text="ALL" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox   id="CheckBox2" runat="server"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="unit" HeaderText="Unit">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="qty" HeaderText="QTY">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="QtyPerBox" HeaderText="QTY/BOX">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Total No of PCS">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Item_Desc" HeaderText="Description">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Serial No.">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DatePurchased" DataFormatString="{0:d}" HeaderText="Date Purchased">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="AcquisitionCost" DataFormatString="{0:N}" HeaderText="Acquisition Cost">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Location" Visible="False"></asp:BoundField>
<asp:BoundField DataField="status" HeaderText="Status"></asp:BoundField>
<asp:BoundField DataField="Item_ID" HeaderText="Item_ID"></asp:BoundField>
<asp:BoundField DataField="cost" HeaderText="cost"></asp:BoundField>
<asp:BoundField DataField="Supplier_ID" HeaderText="Supplier_ID"></asp:BoundField>
</Columns>
</asp:GridView></TD></TR><TR><TD style="WIDTH: 100px"><DIV style="TEXT-ALIGN: center"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 335px"><FIELDSET style="WIDTH: 335px; HEIGHT: 250px" class="PanelBorder"><LEGEND><STRONG><SPAN style="FONT-FAMILY: Arial"><EM>Expirey Details</EM></SPAN></STRONG></LEGEND><TABLE style="WIDTH: 335px"><TBODY><TR><TD style="WIDTH: 135px" class="column_RightBold">Item Description:</TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtSuppDesc" runat="server" Width="145px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 135px" class="column_RightBold"><asp:Label style="LEFT: -19px" id="lblName" runat="server" Width="100px"></asp:Label></TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtSuppB" runat="server" Width="145px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 135px" class="column_RightBold">Supplier:</TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtSuppSupplier" runat="server" Width="145px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 135px" class="column_RightBold">Storage:</TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtSuppStorage" runat="server" Width="145px" CssClass="txtboxinspection"></asp:TextBox> <asp:Label id="lblSuppStorage" runat="server" ForeColor="Red" Font-Size="Smaller" Text="**" Visible="False" Font-Italic="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 135px" class="column_RightBold">Depreciation Rate:</TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtSuppDepRate" runat="server" Width="145px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 135px" class="column_RightBold">Depreciation Value:</TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtSuppDepValue" runat="server" Width="145px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD><TD style="WIDTH: 335px"><FIELDSET style="WIDTH: 335px; HEIGHT: 250px" class="PanelBorder"><LEGEND><STRONG><SPAN style="FONT-FAMILY: Arial"><EM>Expirey Details</EM></SPAN></STRONG></LEGEND><TABLE style="WIDTH: 335px"><TBODY><TR><TD style="WIDTH: 135px" class="column_RightBold">Form:</TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtSuppForm" runat="server" Width="145px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 135px" class="column_RightBold">QTC/Rx:</TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtSuppQTC" runat="server" Width="145px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 135px" class="column_RightBold">Mftg. Date:</TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtSuppMftg" runat="server" Width="145px" CssClass="txtboxinspection"></asp:TextBox> <cc1:CalendarExtender id="CalendarExtender20" runat="server" TargetControlID="txtSuppMftg"></cc1:CalendarExtender></TD></TR><TR><TD style="WIDTH: 135px" class="column_RightBold">Batch:</TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtSuppBatch" runat="server" Width="145px" CssClass="txtboxinspection"></asp:TextBox> <asp:Label id="lblSuppBatch" runat="server" ForeColor="Red" Font-Size="Smaller" Text="**" Visible="False" Font-Italic="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 135px" class="column_RightBold">Lot:</TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtSuppLot" runat="server" Width="145px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 135px" class="column_RightBold">Expiry Date:</TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtSuppExpire" runat="server" Width="145px" CssClass="txtboxinspection"></asp:TextBox><asp:Label id="lblSuppExpire" runat="server" ForeColor="Red" Font-Size="Smaller" Text="**" Visible="False" Font-Italic="True"></asp:Label> <cc1:CalendarExtender id="CalendarExtender19" runat="server" TargetControlID="txtSuppExpire"></cc1:CalendarExtender></TD></TR><TR><TD style="WIDTH: 135px" class="column_RightBold">Alert:</TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtSuppAlert" runat="server" Width="145px" CssClass="txtboxinspection"></asp:TextBox> <cc1:CalendarExtender id="CalendarExtender21" runat="server" TargetControlID="txtSuppAlert"></cc1:CalendarExtender></TD></TR><TR><TD style="WIDTH: 135px" class="column_RightBold"></TD><TD style="WIDTH: 200px" class="text5"></TD></TR></TBODY></TABLE><DIV style="TEXT-ALIGN: center"><TABLE style="FONT-SIZE: 8pt; WIDTH: 100%; TEXT-ALIGN: center"><TBODY><TR><TD style="WIDTH: 100%">(One Month before Expiry Date)</TD></TR></TBODY></TABLE></DIV></FIELDSET></TD><TD style="WIDTH: 300px"><FIELDSET style="WIDTH: 300px; HEIGHT: 250px" class="PanelBorder"><TABLE style="WIDTH: 300px"><TBODY><TR><TD style="HEIGHT: 16px" colSpan=2><asp:Image id="ImgSupp" runat="server" Width="260px" ImageUrl="~/images/blankImage.jpg" CssClass="textimage2" Height="170px" BorderWidth="1px" ImageAlign="Middle"></asp:Image></TD></TR><TR><TD style="WIDTH: 125px" class="column_RightBold">Uploaded By:</TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtSuppUploadBy" runat="server" Width="145px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 125px" class="column_RightBold">Date Uploaded:</TD><TD style="WIDTH: 200px" class="text5"><asp:TextBox id="txtSuppDateUpload" runat="server" Width="145px" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></FIELDSET></TD></TR></TBODY></TABLE></DIV></TD></TR></TBODY></TABLE></DIV></asp:View></asp:MultiView> <asp:MultiView id="mvAttachments" runat="server"><asp:View id="vwAttchDoc" runat="server"><DIV style="TEXT-ALIGN: center"><TABLE style="HEIGHT: 236px" width=1000><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 704px; HEIGHT: 161px" align=right><FIELDSET style="WIDTH: 700px; HEIGHT: 163px" class="PanelBorder"><LEGEND><SPAN style="FONT-SIZE: 10pt"><STRONG><EM>DOCUMENTS DETAILS</EM></STRONG></SPAN></LEGEND><TABLE class="text" width=700><TBODY><TR><TD style="WIDTH: 212px"></TD><TD style="WIDTH: 212px"><asp:HiddenField id="hdfbuilding" runat="server"></asp:HiddenField><INPUT style="DISPLAY: none" id="flbuilding" type=file onchange="Handlechange();" name="fileupload" /><INPUT style="WIDTH: 147px; HEIGHT: 29px" id="btnBuildingBrowse" onclick="HandleBrowseClick();" type=submit value="Browse" runat="server" OnServerClick="btnBuildingBrowse_ServerClick" /></TD><TD style="WIDTH: 212px" align=right>Validated By:</TD><TD style="WIDTH: 212px"><asp:TextBox id="txtOfficeValidatedBy" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 117px" align=right>Document Name:</TD><TD style="WIDTH: 212px"><asp:TextBox id="txtOfficeDocName" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD><TD align=right>Date Validated:</TD><TD style="WIDTH: 217px"><asp:TextBox id="txtOfficeDateValidated" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox> <cc1:CalendarExtender id="CalendarExtender13" runat="server" TargetControlID="txtOfficeDateValidated"></cc1:CalendarExtender></TD></TR><TR><TD style="WIDTH: 117px; HEIGHT: 18px" align=right>Document No.:</TD><TD style="WIDTH: 212px; HEIGHT: 18px"><asp:TextBox id="txtOfficeDocNo" runat="server" Width="230px" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="HEIGHT: 18px" align=right>Remarks:</TD><TD style="WIDTH: 217px" rowSpan=2><asp:TextBox id="txtOfficeRemarks" runat="server" Width="200px" CssClass="txtboxinspection" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 117px; HEIGHT: 18px"></TD><TD style="WIDTH: 212px; HEIGHT: 18px"></TD><TD style="HEIGHT: 18px"></TD></TR><TR><TD style="HEIGHT: 26px" align=center colSpan=4><asp:Button id="btnOfficeAttchDoc" onclick="btnOfficeAttchDoc_Click" runat="server" Width="122px" Text="Add To List" OnClientClick="StartProgressBar();"></asp:Button> <asp:Button id="Button2" runat="server" Width="122px" Text="Cancel"></asp:Button></TD></TR></TBODY></TABLE></FIELDSET> </TD><TD style="VERTICAL-ALIGN: top; WIDTH: 260px" align=center rowSpan=2><FIELDSET style="WIDTH: 252px; HEIGHT: 340px" id="Fieldset1" class="PanelBorder"><LEGEND>ATTACHED DOCUMENTS</LEGEND><BR /><asp:Image id="imgOfficeSupp" runat="server" Width="219px" ImageUrl="~/images/DefaulScannedDocuments.jpg" Height="291px"></asp:Image></FIELDSET> &nbsp;</TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 704px; HEIGHT: 154px" align=right><asp:GridView id="grdSuppAttchDoc" runat="server" Width="700px" OnSelectedIndexChanged="grdSuppAttchDoc_SelectedIndexChanged" DataKeyNames="IdentityNo,DocuId" SkinID="GridView" PageSize="5" Height="170px" BorderStyle="Solid" BorderWidth="1px" OnRowDataBound="grdSuppAttchDoc_RowDataBound" BorderColor="Silver"><Columns>
<asp:BoundField DataField="DocumentName" HeaderText="Document Name">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DocumentNo" HeaderText="Document No.">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ValidatedBy" HeaderText="Validated By">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DateValidated" DataFormatString="{0:d}" HeaderText="Date Validated">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Remarks" HeaderText="Remarks">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView> </TD></TR></TBODY></TABLE></DIV></asp:View></asp:MultiView> <BR /><TABLE style="VERTICAL-ALIGN: middle; WIDTH: 990px; TEXT-ALIGN: center"><TBODY><TR><TD class="strip" align=left colSpan=3><STRONG>INSPECTION AND ACCEPTANCE</STRONG></TD></TR><TR><TD style="WIDTH: 300px; TEXT-ALIGN: center"><FIELDSET style="WIDTH: 300px; HEIGHT: 140px" class="PanelBorder"><LEGEND><STRONG>INSPECTION</STRONG></LEGEND><TABLE id="tdinspection" width=300><TBODY><TR><TD style="WIDTH: 109px" class="column_LeftBold">Date Inspected</TD><TD style="WIDTH: 6px" class="column_LeftBold">:</TD><TD class="text5"><asp:TextBox id="txtInspectedDate" runat="server" Width="100px" Font-Bold="False" CssClass="txtboxinspection"></asp:TextBox> <asp:ImageButton id="ImageButton1" runat="server" Width="20px" ImageUrl="~/images/CalendarImage.jpg" Enabled="False" Height="17px"></asp:ImageButton> <cc1:CalendarExtender id="CalendarExtender6" runat="server" TargetControlID="txtInspectedDate"></cc1:CalendarExtender></TD></TR><TR><TD style="WIDTH: 109px" class="column_LeftBold">Inspector Officer</TD><TD style="WIDTH: 6px" class="column_LeftBold">:</TD><TD class="text5"><asp:DropDownList id="ddinspector1" runat="server" Width="166px" AutoPostBack="True"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 109px; HEIGHT: 16px" class="column_LeftBold"></TD><TD style="WIDTH: 6px; HEIGHT: 16px" class="column_LeftBold"></TD><TD style="HEIGHT: 16px" class="text5"><asp:DropDownList id="ddinspector2" runat="server" Width="166px" AutoPostBack="True" Visible="False"><asp:ListItem>Select</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 109px; HEIGHT: 26px" class="column_LeftBold"></TD><TD style="WIDTH: 6px; HEIGHT: 26px" class="column_LeftBold"></TD><TD style="HEIGHT: 26px" class="text5" align=center><asp:Button id="btninspectedsave" onclick="btninspectedsave_Click" runat="server" Width="74px" Text="Save" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnInspectUpdate" onclick="btnInspectUpdate_Click" runat="server" Width="74px" Text="Save" Visible="False" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnInspectedPreview" onclick="btnInspectedPreview_Click" runat="server" Width="74px" Text="Preview" Enabled="False"></asp:Button></TD></TR></TBODY></TABLE></FIELDSET></TD><TD style="WIDTH: 300px; TEXT-ALIGN: center"><FIELDSET style="WIDTH: 300px; HEIGHT: 140px" class="PanelBorder"><LEGEND><STRONG>ACCEPTANCE</STRONG></LEGEND><TABLE id="tdacceptance" width="100%"><TBODY><TR><TD style="WIDTH: 30%" class="column_LeftBold">Date Received</TD><TD style="WIDTH: 5%" class="column_LeftBold">:</TD><TD style="WIDTH: 65%" class="text5"><asp:TextBox id="txtAcceptedDate" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox> <asp:ImageButton id="ImageButton2" runat="server" Width="20px" ImageUrl="~/images/CalendarImage.jpg" Enabled="False" Height="17px"></asp:ImageButton> <cc1:CalendarExtender id="CalendarExtender7" runat="server" TargetControlID="txtAcceptedDate"></cc1:CalendarExtender></TD></TR><TR><TD style="WIDTH: 30%" class="column_LeftBold"></TD><TD style="WIDTH: 5%" class="column_LeftBold"></TD><TD style="WIDTH: 65%" class="text5"><asp:RadioButtonList id="rbStatus" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Enabled="False"><asp:ListItem Value="1">Complete</asp:ListItem>
<asp:ListItem Selected="True" Value="0">Partial</asp:ListItem>
</asp:RadioButtonList></TD></TR><TR><TD style="WIDTH: 30%" class="column_LeftBold">Received By</TD><TD style="WIDTH: 5%" class="column_LeftBold">:</TD><TD style="WIDTH: 65%" class="text5"><asp:DropDownList id="ddacceptance" runat="server" Width="166px" AutoPostBack="True"><asp:ListItem Selected="True">- Select -</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 30%" class="column_LeftBold"></TD><TD style="WIDTH: 5%" class="column_LeftBold"></TD><TD style="WIDTH: 65%" class="text5" align=center><asp:Button id="btnacceptancesave" onclick="btnacceptancesave_Click" runat="server" Width="74px" Text="Save" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnAccptUpdate" onclick="btnAccptUpdate_Click" runat="server" Width="74px" Text="Save" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnacceptancepreview" onclick="btnacceptancepreview_Click" runat="server" Width="74px" Text="Preview" Enabled="False"></asp:Button></TD></TR></TBODY></TABLE></FIELDSET></TD><TD style="WIDTH: 390px"><FIELDSET style="WIDTH: 390px; HEIGHT: 140px" class="PanelBorder"><LEGEND><STRONG>ACKNOWLEDGEMENT RECEIPT</STRONG></LEGEND><TABLE style="WIDTH: 386px" id="tdacknowledgement"><TBODY><TR><TD style="WIDTH: 20px; HEIGHT: 31px" class="column_LeftBold">Date</TD><TD style="WIDTH: 1px; HEIGHT: 31px" class="column_LeftBold">:</TD><TD style="WIDTH: 340px; HEIGHT: 31px" class="text5"><asp:TextBox id="txtAcknowledgementDate" runat="server" Width="100px" CssClass="txtboxinspection" Enabled="False"></asp:TextBox> <asp:ImageButton id="ImageButton3" runat="server" Width="20px" ImageUrl="~/images/CalendarImage.jpg" Enabled="False" Height="17px"></asp:ImageButton> <cc1:CalendarExtender id="CalendarExtender8" runat="server" TargetControlID="txtAcknowledgementDate"></cc1:CalendarExtender></TD><TD style="WIDTH: 260px" class="text5">Items :<asp:DropDownList id="ddItems" runat="server" Width="141px" Enabled="False"><asp:ListItem>Select</asp:ListItem>
<asp:ListItem>Equipments</asp:ListItem>
<asp:ListItem>Machinery</asp:ListItem>
<asp:ListItem>Motors</asp:ListItem>
<asp:ListItem>Furniture &amp; Fixtures</asp:ListItem>
<asp:ListItem>Land</asp:ListItem>
<asp:ListItem>Building</asp:ListItem>
<asp:ListItem>Office Supply</asp:ListItem>
<asp:ListItem>Medicine</asp:ListItem>
</asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 20px" class="column_LeftBold">To</TD><TD style="WIDTH: 1px" class="column_LeftBold">:</TD><TD style="WIDTH: 340px" class="text5"><asp:DropDownList id="ddAcknowledgement" runat="server" Width="141px" Enabled="False"></asp:DropDownList></TD><TD style="WIDTH: 260px" class="text5"></TD></TR><TR><TD style="WIDTH: 20px; HEIGHT: 16px" class="column_LeftBold">Position</TD><TD style="WIDTH: 1px; HEIGHT: 16px" class="column_LeftBold">:</TD><TD style="WIDTH: 340px; HEIGHT: 16px" class="text5"><asp:TextBox id="txtAcknowledgementposition" runat="server" Width="137px" CssClass="txtboxinspection" Enabled="False"></asp:TextBox></TD><TD style="WIDTH: 260px" class="text5"></TD></TR><TR><TD style="WIDTH: 20px" class="column_LeftBold">Officer</TD><TD style="WIDTH: 1px" class="column_LeftBold">:</TD><TD style="WIDTH: 340px" class="text5"><asp:TextBox id="txtAcknowledgementOfficer" runat="server" Width="137px" CssClass="txtboxinspection" Enabled="False"></asp:TextBox></TD><TD style="WIDTH: 260px" class="text5" align=center><asp:Button id="btnacknowledgementpost" onclick="btnacknowledgementpost_Click" runat="server" Width="74px" Text="Post" Enabled="False"></asp:Button><asp:Button id="btnacknowledgementpreview" runat="server" Width="74px" Text="Preview" Enabled="False"></asp:Button></TD></TR></TBODY></TABLE></FIELDSET></TD></TR></TBODY></TABLE><BR /><BR /><BR /><asp:Panel style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #0033cc; BORDER-BOTTOM-WIDTH: 1px; BORDER-BOTTOM-COLOR: #0033cc; BORDER-TOP-COLOR: #0033cc; POSITION: relative; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #0033cc" id="PanelProgress" runat="server" Width="109px" __designer:wfdid="w66">
                <img src="../images/ajax-loader.gif" /></asp:Panel> <cc1:ModalPopupExtender id="ProgressBarModalPopupExtender" runat="server" __designer:wfdid="w67" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender> <asp:Button style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; POSITION: relative; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none" id="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w68" Enabled="False"></asp:Button><BR /><BR /><BR /><asp:Panel style="DISPLAY: none; COLOR: black" id="pConfOK" runat="server" Width="384px" SkinID="popUpMsgs" BorderStyle="Solid" BorderWidth="2px"><BR /><asp:Image id="imgBarcode" runat="server"></asp:Image><BR /><BR /><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="80px" Text="OK" SkinID="button"></asp:Button><BR /><BR /><asp:Label id="Label3" runat="server"></asp:Label> </asp:Panel> <cc1:ModalPopupExtender id="mpeBarcode" runat="server" TargetControlID="Label3" PopupControlID="pConfOK" BehaviorID="mpeBarcode">
    </cc1:ModalPopupExtender> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>

</asp:Content>
