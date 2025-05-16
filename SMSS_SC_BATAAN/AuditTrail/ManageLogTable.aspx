<%@ Page Language="VB" MasterPageFile="~/MasterPage1.master" AutoEventWireup="false" CodeFile="ManageLogTable.aspx.vb" Inherits="logaudit_ManageLogTable" title="Manage Log Tables" StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
  <h2>
        Manage Log Tables</h2>
   <asp:GridView id="dgLogTables" runat="server" Font-Size="10pt" AutoGenerateColumns="False" SkinID="gvnew">
            <Columns>
                <asp:BoundField DataField="TableName" HeaderText="Table Name" />
                <asp:BoundField DataField="PrimaryField" HeaderText="Primary Field" />
                <asp:BoundField DataField="TableId" HeaderText="Table ID" />
                <asp:BoundField DataField="ApplicationName" HeaderText="Application Name" />
            </Columns>
        </asp:GridView>
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#CC0000" Visible="False">Audit Trail for Tables has not been set yet!!!!</asp:Label>
        <hr />
    <table style="width: 100%">
        <tr>
            <td style="font-size: 10pt; width: 20%; font-family: Verdana; text-align: left" class="text1Bold">
                System Database:</td>
            <td style="width: 80%" class="text2">
                <asp:DropDownList ID="ddlSystemDB" runat="server" Font-Names="Verdana"
                    Font-Size="10pt" Width="250px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="font-size: 10pt; width: 20%; font-family: Verdana; text-align: left" class="text1Bold">
                SysMngr Database:</td>
            <td style="width: 80%" class="text2">
                <asp:DropDownList ID="ddlSysMngrDB" runat="server" AutoPostBack="False" Font-Names="Verdana"
                    Font-Size="10pt" Width="250px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="font-size: 10pt; width: 20%; font-family: Verdana; text-align: left" class="text1Bold">
                Table Name:</td>
            <td style="width: 80%" class="text2">
                <asp:DropDownList ID="ddlTables" runat="server" AutoPostBack="True" Font-Names="Verdana"
                    Font-Size="10pt" Width="250px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="font-size: 10pt; width: 20%; font-family: Verdana; text-align: left" class="text1Bold">
                Primary Field Indicator:</td>
            <td style="width: 80%" class="text2">
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:DropDownList id="ddlFields" runat="server" Width="250px" Font-Size="10pt" Font-Names="Verdana" AutoPostBack="True"></asp:DropDownList> 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlTables" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="font-size: 10pt; width: 20%; font-family: Verdana; text-align: left" class="text1Bold">
                </td>
            <td style="width: 80%" class="text2" >
                <asp:CheckBox ID="cbEnable" runat="server" Font-Size="10pt" Text="Create Audit Tables and Views" /></td>
        </tr>
        <tr>
            <td style="font-size: 10pt; width: 20%; font-family: Verdana; text-align: left" class="text1Bold">
            </td>
            <td style="width: 80%" class="text2">
                <asp:Button ID="btnEnable" runat="server" CssClass="CSButton" Font-Names="Verdana" Font-Size="10pt" Text="Enable Audit"
                    Width="150px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="CreateStatus" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>
</asp:Content>

