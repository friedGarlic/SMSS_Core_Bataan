<%@ Page Language="VB" MasterPageFile="~/MasterPage1.master" AutoEventWireup="false" CodeFile="AuditTrails.aspx.vb" Inherits="AuditTrail_AuditTrails" title="AUDIT TRAIL" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
  <h2>
        Audit Trail</h2>
    <p>
        &nbsp;<asp:Panel ID="Panel2" runat="server" GroupingText="Date Duration" Width="800px" CssClass="text" Font-Bold="True">
            <table style="font-weight: normal" width="100%">
                <tr>
                    <td>
                        &nbsp;from</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtDateFrom" runat="server"></asp:TextBox></td>
                    <td style="width: 2px">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" /></td>
                    <td>
                        &nbsp;To </td>
                    <td style="width: 158px">
                        <asp:TextBox ID="txtDateTo" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" /></td>
                    <td>
                        &nbsp;User<asp:DropDownList ID="drpUsers" runat="server" AppendDataBoundItems="True">
                            <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" CssClass="CSButton" Text="Search" Width="104px" /></td>
                    <td style="width: 100px">
                        &nbsp;<asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" Text="View All" /></td>
                </tr>
            </table>
            &nbsp;
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ImageButton1"
                TargetControlID="txtDateFrom">
            </cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="ImageButton2"
                TargetControlID="txtDateTo">
            </cc1:CalendarExtender>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" GroupingText="PREVIEW DETAILS" Width="800px" CssClass="text" Font-Bold="True">
            <table style="font-weight: normal">
                <tr>
                    <td style="width: 100px">
                        Fieldname</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtFieldName" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td>
                        Operation</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtOperation" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Table - Item_ID</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtTable" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 100px">
                        Date/Time</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtDateTime" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        Old Value</td>
                    <td colspan="3" style="height: 26px">
                        <asp:TextBox ID="txtOldValue" runat="server" TextMode="MultiLine" Width="400px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        New Value</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNewValue" runat="server" TextMode="MultiLine" Width="400px" ReadOnly="True"></asp:TextBox></td>
                </tr>
            </table>
            <br />
            &nbsp;</asp:Panel>
    </p>
            <asp:Panel ID="Panel3" runat="server" CssClass="text" Font-Bold="True" GroupingText="Details"
                Width="800px">
                &nbsp;
        
          <asp:GridView id="dgLogTables" runat="server" Width="100%" DataKeyNames="AuditId,TableName,RowId,Operation,OccurredAt,TimeCaptured,PerformedBy,FieldName,OldValue,NewValue" SkinID="gvnew" style="font-weight: normal" Font-Overline="False" Font-Bold="False" AllowPaging="True" PageSize="5">
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Preview" />
                <asp:BoundField DataField="TableName" HeaderText="Table Name" >
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="RowId" HeaderText="Item_Id" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Operation" HeaderText="Operation" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="OccurredAt" HeaderText="Date/Time" DataFormatString="{0:d}" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="FieldName" HeaderText="FieldName" >
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="OldValue" HeaderText="Old Value" >
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="NewValue" HeaderText="New Value" >
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
            </Columns>
              <FooterStyle CssClass="text" Font-Bold="True" />
        </asp:GridView>
    </asp:Panel>
    <br />
</asp:Content>

