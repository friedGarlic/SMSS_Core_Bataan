<%@ Page 
    Title="Property Acknowledgement Receipt"
    Language="VB" 
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" 
    CodeFile="Property_Acknowledgement_Receipt_Report.aspx.vb" 
    Inherits="Inventory_Property_Acknowledgement_Receipt_Report" 
    StylesheetTheme="SkinFile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <contenttemplate>
               <TABLE style="WIDTH: 100%">
                   <TBODY>
                       <TR>
                           <TD style="WIDTH: 10px" align=center></TD>
                           <TD style="WIDTH: 1000px" class="PageTitle" align=center>PROPERTY ACKNOWLEDGEMENT RECEIPT </TD></TR><TR><TD style="WIDTH: 10px" align=center></TD>
                               <TD style="WIDTH: 1000px" align=center></TD></TR><TR><TD style="WIDTH: 10px" align=center></TD>
                               <TD style="WIDTH: 1000px" align=center><TABLE style="WIDTH: 100%">
                               <TBODY>
                                   <TR>
                                       <TD style="VERTICAL-ALIGN: middle; WIDTH: 10%" class="column_RightBold">Search By :</TD>
                                       <TD style="VERTICAL-ALIGN: top; WIDTH: 20%" class="text5"><asp:RadioButtonList id="RadioButtonList1" runat="server" Width="180px" AutoPostBack="True">
                                            <asp:ListItem Selected="True" Value="1">PAR Number</asp:ListItem>
                                            <asp:ListItem Value="2">Employee Name</asp:ListItem>
                                            <asp:ListItem Value="3">Date(Duration)</asp:ListItem>
                                            </asp:RadioButtonList></TD>
                                       <TD style="VERTICAL-ALIGN: top; WIDTH: 70%" class="text5"><asp:MultiView id="MultiView1" runat="server"><asp:View id="View1" runat="server">
                                           <TABLE style="WIDTH: 100%">
                                               <TBODY>
                                                   <TR>
                                                       <TD style="WIDTH: 20%" class="column_RightBold">PAR Number :</TD>
                                                       <TD style="WIDTH: 80%" class="text5"><asp:TextBox id="txtRefNumber" runat="server" Width="220px" MaxLength="20"></asp:TextBox><asp:Button id="btnSearchREF" runat="server" Width="120px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Browse"></asp:Button></TD></TR>
                                                   
                                                   <TR>
                                                       <TD style="WIDTH: 20%" class="column_RightBold"></TD><TD style="WIDTH: 80%" class="text5"></TD></TR></TBODY></TABLE></asp:View> <asp:View id="View3" runat="server">
                                                           <TABLE style="WIDTH: 100%">
                                                               <TBODY>
                                                                   <TR>
                                                                       <TD style="WIDTH: 20%" class="column_RightBold">Employee Name :</TD>
                                                                       <TD style="WIDTH: 80%" class="text5"><asp:DropDownList id="ddSupplier" runat="server" Width="420px" AutoPostBack="True">
                                                            </asp:DropDownList><asp:Button id="btnSearchSupp" runat="server" Width="120px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Browse"></asp:Button></TD></TR>
                                                                   <TR>
                                                                       <TD style="WIDTH: 20%" class="column_RightBold"></TD>
                                                                       <TD style="WIDTH: 80%" class="text5"></TD></TR></TBODY></TABLE></asp:View> <asp:View id="View4" runat="server">
                                                                           <TABLE style="WIDTH: 100%">
                                                                               <TBODY>
                                                                                   <TR>
                                                                                       <TD style="WIDTH: 20%" class="column_RightBold">Date From :</TD>
                                                                                       <TD style="WIDTH: 30%" class="text5"><asp:TextBox id="txtdatefrom" runat="server" Width="128px"></asp:TextBox><asp:ImageButton id="btncal1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true"></asp:ImageButton></TD>
                                                                                       <TD style="WIDTH: 50%" class="text5" rowSpan=2><asp:Button id="btnByDate" runat="server" Width="120px" OnClientClick="StartProgressBar();" CssClass="CSButton" Text="Browse"></asp:Button></TD></TR>
                                                                                   <TR>
                                                                                       <TD style="WIDTH: 20%" class="column_RightBold">Date To :</TD>
                                                                                       <TD style="WIDTH: 30%" class="text5"><asp:TextBox id="txtdateto" runat="server" Width="128px"></asp:TextBox><asp:ImageButton id="btncal2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true"></asp:ImageButton></TD></TR></TBODY></TABLE></asp:View> </asp:MultiView></TD></TR>
                                   <TR>
                                       <TD style="WIDTH: 10%" class="column_RightBold"></TD>
                                       <TD style="WIDTH: 20%" class="text5"></TD>
                                       <TD style="WIDTH: 70%" class="text5"></TD></TR>
                                   <TR>
                                       <TD class="DivTitle" colSpan=3>Property Acknowledgement Receipt</TD></TR>
                                   <TR>
                                       <TD class="text5" colSpan=3><asp:Panel id="Panel1" runat="server" Width="980px" CssClass="PanelSize" ScrollBars="Vertical">
                                            <asp:GridView ID="grdAcnkReceipt" runat="server" AutoGenerateColumns="False" DataKeyNames="MRENumber"
                                                EmptyDataText="NO DATA FOUND" SkinID="GridViewAA" Width="100%" Font-Size="9pt">
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Preview"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="MRE_Date_Recieve" DataFormatString="{0:d}" HeaderText="Date">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MRENumber" HeaderText="PAR No.">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RC_Name" HeaderText="Department">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Full_Name" HeaderText="Employee Name">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Full_Name" HeaderText="Employee Name">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MRto" HeaderText="MRto" Visible="false">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                      <asp:BoundField DataField="RC_ID" HeaderText="RC_ID" Visible="false">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MREHdr_ID" HeaderText="MREHdr_ID" Visible="false">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel> &nbsp; </TD></TR></TBODY></TABLE></TD></TR>
                       <TR>
                           <TD style="WIDTH: 10px" align=center></TD><TD style="WIDTH: 1000px" align=center><cc1:CalendarExtender id="CalendarExtender1" runat="server" PopupButtonID="btncal1" TargetControlID="txtdatefrom" __designer:wfdid="w107">
                                                            </cc1:CalendarExtender><cc1:CalendarExtender id="CalendarExtender2" runat="server" PopupButtonID="btncal2" TargetControlID="txtdateto" __designer:wfdid="w108">
                                                            </cc1:CalendarExtender></TD></TR></TBODY></TABLE>
           </contenttemplate>
       </asp:UpdatePanel>
</asp:Content>