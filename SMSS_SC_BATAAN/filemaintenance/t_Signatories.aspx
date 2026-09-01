<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
CodeFile="t_Signatories.aspx.vb" Inherits="filemaintenance_t_Signatories" 
title="FM Signatories" StylesheetTheme="SkinFile" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
 </script>






<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 
<asp:UpdatePanel id="UpdatePanel1" runat="server">
<contenttemplate>
<TABLE style="WIDTH: 1010px"><TBODY><TR><TD style="WIDTH: 1010px"><TABLE style="WIDTH: 1000px"><TBODY><TR><TD style="WIDTH: 1000px"><TABLE class="PageTitle" __designer:dtid="562949953421317"><TBODY><TR __designer:dtid="562949953421318"><TD style="WIDTH: 1000px" __designer:dtid="562949953421319">SIGNATORIES</TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 1000px" class="text4"><asp:Button id="btnList" onclick="btnList_Click" runat="server" Width="200px" __designer:wfdid="w179" Text="List of Signatories" Height="30px"></asp:Button><asp:Button id="btnAdd" runat="server" Width="200px" __designer:wfdid="w180" Text="Add Signatory" Height="30px" SkinID="button"></asp:Button></TD></TR><TR><TD style="WIDTH: 1000px"><asp:MultiView id="MultiView1" runat="server" __designer:wfdid="w4"><asp:View id="View1" runat="server" __designer:wfdid="w5"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 100%"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 30%" class="column_RightBold">Search Name : </TD><TD style="WIDTH: 30%" class="text5"><asp:TextBox id="txtname" runat="server" Width="300px" __designer:wfdid="w176" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 10%" class="text5"><asp:Button id="btnSearchEmp" runat="server" Width="150px" __designer:wfdid="w177" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></TD><TD class="text5"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </STRONG><asp:DropDownList id="ddSort" runat="server" Width="120px" __designer:wfdid="w178" AutoPostBack="True" OnSelectedIndexChanged="ddSort_SelectedIndexChanged" Visible="False"><asp:ListItem Selected="True" Value="1">Name</asp:ListItem>
<asp:ListItem Value="2">Position</asp:ListItem>
</asp:DropDownList></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 100%"><asp:GridView id="grdAddSignatory" runat="server" Width="90%" __designer:wfdid="w174" SkinID="GridViewAA" DataKeyNames="full_name,positiondesc" EmptyDataText="No Data Found." AllowPaging="True" AutoGenerateColumns="False"><Columns>
<asp:CommandField ShowSelectButton="True">
<ControlStyle Font-Underline="True" Width="50px"></ControlStyle>

<HeaderStyle Width="50px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:CommandField>
<asp:BoundField DataField="full_name" HeaderText="Employee Name">
<ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="positiondesc" HeaderText="Position">
<ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
</asp:BoundField>
</Columns>

<PagerStyle Font-Bold="True"></PagerStyle>
</asp:GridView><BR /></TD></TR><TR><TD style="WIDTH: 100%"><asp:Panel id="Panel1" runat="server" Width="99%" Font-Bold="True" __designer:wfdid="w15" CssClass="text" GroupingText="INFORMATION"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 15%" class="column_RightBold">Department : </TD><TD style="WIDTH: 35%" class="text5"><asp:DropDownList id="drpDepartment" runat="server" Width="98%" __designer:wfdid="w67" CssClass="txtboxinspection" OnSelectedIndexChanged="drpDepartment_SelectedIndexChanged" AutoPostBack="True" DataTextField="Office_Ab" DataValueField="Office_ID"><asp:ListItem Value="1">Select</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 10%" class="column_RightBold">Position : </TD><TD style="WIDTH: 40%" class="text5"><asp:DropDownList id="drpAddSigPosition" runat="server" Width="74%" __designer:wfdid="w68" Visible="False" CssClass="txtboxinspection"><asp:ListItem Value="False">No</asp:ListItem>
<asp:ListItem Value="True">Yes</asp:ListItem>
</asp:DropDownList><asp:TextBox id="txtAddPosition" runat="server" Width="74%" __designer:wfdid="w69" CssClass="txtboxinspection"></asp:TextBox><asp:Label style="POSITION: relative" id="lblrequired" runat="server" ForeColor="Red" Font-Size="Smaller" Text="*required" __designer:wfdid="w70" Visible="False"></asp:Label><asp:Button id="btnAddPosition" onclick="btnAddPosition_Click" runat="server" Width="25%" Font-Size="Smaller" Text="Add Position" __designer:wfdid="w71" SkinID="button"></asp:Button><asp:Button id="btnSearchPos" onclick="btnSearchPos_Click" runat="server" Width="25%" Font-Size="Smaller" Text="Search Position" __designer:wfdid="w72" SkinID="button" Visible="False"></asp:Button></TD></TR><TR><TD style="WIDTH: 15%" class="column_RightBold">Function : </TD><TD style="WIDTH: 35%" class="text5"><asp:DropDownList id="drpFunction" runat="server" Width="98%" __designer:wfdid="w73" CssClass="txtboxinspection" OnSelectedIndexChanged="drpFunction_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 10%" class="column_RightBold">Department Head : </TD><TD style="WIDTH: 40%" class="text5"><TABLE style="WIDTH: 100%" id=""><TBODY><TR><TD style="WIDTH: 78px; HEIGHT: 12px"><asp:DropDownList id="drpDeptHead" runat="server" Width="120px" __designer:wfdid="w74" CssClass="txtboxinspection"><asp:ListItem Value="False">No</asp:ListItem>
<asp:ListItem Value="True">Yes</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 60%; HEIGHT: 12px" align=right><asp:Button id="btnsavepos" onclick="btnsavepos_Click" runat="server" Width="83px" Font-Size="Smaller" Text="SAVE" __designer:wfdid="w75" SkinID="button" Visible="False"></asp:Button> <asp:Button id="btncancelpos" onclick="btncancelpos_Click" runat="server" Width="83px" Font-Size="Smaller" Text="CANCEL" __designer:wfdid="w76" SkinID="button" Visible="False"></asp:Button></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 15%" class="column_RightBold">Employee : </TD><TD style="WIDTH: 35%" class="text5"><asp:TextBox id="txtEmployee" runat="server" Width="80%" __designer:wfdid="w77" CssClass="txtboxinspection"></asp:TextBox></TD><TD style="WIDTH: 10%" class="column_RightBold"></TD><TD style="WIDTH: 40%" class="text5"><asp:TextBox style="LEFT: 0px" id="txtEffectiveDate" runat="server" Width="120px" __designer:wfdid="w78" Visible="False" CssClass="txtboxinspection"></asp:TextBox></TD></TR></TBODY></TABLE></asp:Panel> <cc1:CalendarExtender id="CalendarExtender1" runat="server" __designer:wfdid="w54" TargetControlID="txtEffectiveDate" PopupButtonID="txtEffectiveDate"></cc1:CalendarExtender></TD></TR><TR><TD style="WIDTH: 100%"><asp:Button id="btnOk" runat="server" Width="200px" __designer:wfdid="w26" Text="ADD" Height="30px" SkinID="button" OnClientClick="StartProgressBar();"></asp:Button><asp:Button id="btnCancel" runat="server" Width="200px" __designer:wfdid="w27" Text="CANCEL" Height="30px" SkinID="button"></asp:Button><BR /></TD></TR><TR><TD style="WIDTH: 100%" class="DivTitle">SIGNATORIES</TD></TR><TR><TD style="WIDTH: 100%"><asp:GridView id="grdEmployee" runat="server" Width="100%" __designer:wfdid="w24" SkinID="GridViewAA" EmptyDataText="No Data Found." AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="grdEmployee_PageIndexChanging"><Columns>
<asp:BoundField DataField="full_name" HeaderText="Full Name">
<ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="position_desc" HeaderText="Position">
<ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Office_Name" HeaderText="Department">
<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Function_desc" HeaderText="Function">
<ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="isDeptHead" HeaderText="Department Head">
<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView></TD></TR></TBODY></TABLE></asp:View> <asp:View id="View2" runat="server" __designer:wfdid="w6"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 100%"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 10%" class="column_RightBold">Department : </TD><TD style="WIDTH: 60%" class="text5"><asp:DropDownList id="drpOffice" runat="server" Width="98%" __designer:wfdid="w2" OnSelectedIndexChanged="drpOffice_SelectedIndexChanged" AutoPostBack="True" DataTextField="RespCenter" DataValueField="Func_per_Office_ID"></asp:DropDownList></TD><TD style="WIDTH: 30%" class="text5"><asp:CheckBox id="cbShowAll" runat="server" Text="All Departments" __designer:wfdid="w3" AutoPostBack="True" OnCheckedChanged="cbShowAll_CheckedChanged"></asp:CheckBox></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 100%" class="DivTitle">SIGNATORIES</TD></TR><TR><TD style="WIDTH: 100%"><asp:GridView id="grdSignatory" runat="server" Width="100%" __designer:wfdid="w31" SkinID="GridViewAA" AutoGenerateColumns="False" PageSize="15" AllowPaging="True" EmptyDataText="No Data Found." DataKeyNames="Signatory_Id,position_id,empid,full_name,deptID,division_key,empsig_ID">
<EmptyDataRowStyle BorderColor="RoyalBlue" BorderWidth="1px" BorderStyle="Solid" Font-Bold="False"></EmptyDataRowStyle>
<Columns>
<asp:CommandField SelectText="Update" ShowSelectButton="True">
<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:CommandField>
<asp:BoundField DataField="Signatory_ID" HeaderText="SignatoryID" Visible="False"></asp:BoundField>
<asp:BoundField DataField="position_key" HeaderText="PositionID" Visible="False"></asp:BoundField>
<asp:BoundField DataField="empid" HeaderText="empID" Visible="False"></asp:BoundField>
<asp:BoundField DataField="full_name" HeaderText="Full Name">
<ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="position_desc" HeaderText="Position">
<ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="effectivity_date" HeaderText="Effectivity Date" Visible="False">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Office_Name" HeaderText="Department">
<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="deptid" HeaderText="deptid" Visible="False"></asp:BoundField>
<asp:BoundField DataField="division_key" HeaderText="Function_ID" Visible="False"></asp:BoundField>
<asp:BoundField DataField="Function_desc" HeaderText="Function">
<ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="isDeptHead" HeaderText="Department Head">
<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="empsig_ID" HeaderText="empsig_ID" Visible="False"></asp:BoundField>
</Columns>
</asp:GridView></TD></TR></TBODY></TABLE><asp:HiddenField id="DeptID" runat="server" __designer:wfdid="w185"></asp:HiddenField><asp:HiddenField id="FuncID" runat="server" __designer:wfdid="w186"></asp:HiddenField><asp:HiddenField id="showAllDept" runat="server" __designer:wfdid="w187"></asp:HiddenField></asp:View></asp:MultiView></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><%--<cc1:ModalPopupExtender id="ModalPopupExtender1" runat="server" PopupControlID="pnlSignatory" TargetControlID="Label1">
    </cc1:ModalPopupExtender>--%><asp:Panel style="DISPLAY: none" id="pUpdate" runat="server" Width="552px" __designer:wfdid="w32" SkinID="popUpMsgs"><BR /><TABLE style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; WIDTH: 95%; BORDER-BOTTOM: gray 1px solid; HEIGHT: 32px" cellSpacing=0 cellPadding=0><TBODY><TR><TD style="WIDTH: 44px; TEXT-ALIGN: right"><asp:Image id="Image2" runat="server" ImageUrl="~/images/info_image_20px.png" __designer:wfdid="w33"></asp:Image></TD><TD style="WIDTH: 8px; TEXT-ALIGN: left"></TD><TD style="TEXT-ALIGN: left"><asp:Label style="BACKGROUND-IMAGE: url(images/info_image.jpg)" id="Label3" runat="server" Font-Bold="True" __designer:wfdid="w34" Text="Update Signatory Information" SkinID="BoldBigger"></asp:Label></TD></TR></TBODY></TABLE><BR /><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0><TBODY><TR><TD colSpan=2><TABLE style="WIDTH: 100%" cellSpacing=1 cellPadding=1><TBODY><TR><TD style="WIDTH: 26px"></TD><TD style="WIDTH: 132px; TEXT-ALIGN: left"><STRONG>Employee Name:</STRONG></TD><TD style="WIDTH: 334px; TEXT-ALIGN: left"><asp:TextBox id="txtUpdateEmpName" runat="server" Width="353px" __designer:wfdid="w35" Enabled="False" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 26px"></TD><TD style="WIDTH: 132px; TEXT-ALIGN: left"><STRONG style="VERTICAL-ALIGN: top">Position:</STRONG></TD><TD style="WIDTH: 334px; TEXT-ALIGN: left"><asp:DropDownList id="drpPosition" runat="server" Width="360px" __designer:wfdid="w36"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 26px"></TD><TD style="WIDTH: 132px; TEXT-ALIGN: left"><STRONG>Department:</STRONG></TD><TD style="TEXT-ALIGN: left"><asp:DropDownList id="drpUpdateDepartment" runat="server" Width="360px" __designer:wfdid="w37" AutoPostBack="True" OnSelectedIndexChanged="drpUpdateDepartment_SelectedIndexChanged" DataValueField="Office_ID" DataTextField="Office_Ab"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 26px"></TD><TD style="WIDTH: 132px; TEXT-ALIGN: left"><STRONG>Function:</STRONG></TD><TD style="TEXT-ALIGN: left"><asp:DropDownList id="drpUpdateFunction" runat="server" Width="360px" __designer:wfdid="w38" OnSelectedIndexChanged="drpUpdateFunction_SelectedIndexChanged" DataValueField="Function_ID" DataTextField="Function_Desc"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 26px"></TD><TD style="WIDTH: 132px; TEXT-ALIGN: left"><STRONG>Department Head:</STRONG></TD><TD style="WIDTH: 334px; TEXT-ALIGN: left"><asp:DropDownList id="drpUpdateDeptHead" runat="server" Width="80px" __designer:wfdid="w39"><asp:ListItem Value="False">No</asp:ListItem>
<asp:ListItem Value="True">Yes</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 26px"></TD><TD style="WIDTH: 132px; TEXT-ALIGN: left"></TD><TD style="WIDTH: 334px; TEXT-ALIGN: left"></TD></TR><TR><TD style="HEIGHT: 15px" colSpan=3></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="HEIGHT: 8px; TEXT-ALIGN: center" colSpan=2><asp:Button id="btnUpdate" onclick="btnUpdate_Click" runat="server" __designer:wfdid="w40" Text="Update" SkinID="button"></asp:Button>&nbsp;<asp:Button id="btnuCancel" runat="server" __designer:wfdid="w41" Text="Cancel" SkinID="button"></asp:Button> </TD></TR><TR><TD style="HEIGHT: 15px" colSpan=2></TD></TR></TBODY></TABLE><asp:Label id="Label4" runat="server" __designer:wfdid="w42"></asp:Label></asp:Panel> <cc1:ModalPopupExtender id="ModalPopupExtender2" runat="server" __designer:wfdid="w43" BehaviorID="ModalPopupExtender2" PopupDragHandleControlID="pUpdate" PopupControlID="pUpdate" TargetControlID="Label4"></cc1:ModalPopupExtender> <asp:Panel style="DISPLAY: none" id="pnlSaved" runat="server" Width="384px" __designer:wfdid="w44" SkinID="popUpMsgs" BorderWidth="2px" BorderStyle="Solid"><BR /><asp:Label id="lblError" runat="server" Font-Bold="True" Font-Size="10pt" Font-Names="Tahoma" __designer:wfdid="w45">Signatory information was successfully saved!</asp:Label><BR /><BR /><asp:Button id="btnOKSave" runat="server" Width="80px" CausesValidation="False" Text="OK" SkinID="button" __designer:wfdid="w46"></asp:Button><BR /><BR /><asp:Label id="Label9" runat="server" __designer:wfdid="w47"></asp:Label></asp:Panel> <cc1:ModalPopupExtender id="mpeConfirm" runat="server" __designer:wfdid="w48" BehaviorID="mpeConfirm" PopupControlID="pnlSaved" TargetControlID="Label9"></cc1:ModalPopupExtender> <asp:Panel style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #0033cc; BORDER-BOTTOM-WIDTH: 1px; BORDER-BOTTOM-COLOR: #0033cc; BORDER-TOP-COLOR: #0033cc; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #0033cc" id="PanelProgress" runat="server" Width="109px" __designer:wfdid="w181">
                <img src="../images/ajax-loader.gif" /></asp:Panel> <cc1:ModalPopupExtender id="ProgressBarModalPopupExtender" runat="server" __designer:wfdid="w182" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender> <asp:Button style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-BOTTOM-STYLE: none" id="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w183" Enabled="False"></asp:Button> 
</contenttemplate>
    </asp:UpdatePanel>
    &nbsp;&nbsp;

</asp:Content>

