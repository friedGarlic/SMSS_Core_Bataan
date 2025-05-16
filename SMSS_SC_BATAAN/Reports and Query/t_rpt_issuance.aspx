<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
CodeFile="t_rpt_issuance.aspx.vb" Inherits="t_rpt_issuance" 
title="Issuance Report" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <table width="100%" style="text-align: center">
        <tr>
            <td width="100%" style="text-align: center">

                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 100%">


                                        <table width="100%" class="PageTitle">
                                            <tr>
                                                <td style="width: 100%">&nbsp;ISSUANCE REPORT</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%">
                                        <table style="width: 100%">
                                            <tr>
                                                <td class="column_RightBold" style="width: 25%">Month :</td>
                                                <td class="text5" style="width: 75%">
                                                    <asp:DropDownList ID="ddMonth" runat="server" AutoPostBack="True" CssClass="txtboxinspection"
                                                        Width="200px">
                                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">January</asp:ListItem>
                                                        <asp:ListItem Value="2">February</asp:ListItem>
                                                        <asp:ListItem Value="3">March</asp:ListItem>
                                                        <asp:ListItem Value="4">April</asp:ListItem>
                                                        <asp:ListItem Value="5">May</asp:ListItem>
                                                        <asp:ListItem Value="6">June</asp:ListItem>
                                                        <asp:ListItem Value="7">July</asp:ListItem>
                                                        <asp:ListItem Value="8">August</asp:ListItem>
                                                        <asp:ListItem Value="9">September</asp:ListItem>
                                                        <asp:ListItem Value="10">October</asp:ListItem>
                                                        <asp:ListItem Value="11">November</asp:ListItem>
                                                        <asp:ListItem Value="12">December</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td class="column_RightBold" style="width: 25%">Year :</td>
                                                <td class="text5" style="width: 75%">
                                                    <asp:DropDownList ID="ddYear" runat="server" AutoPostBack="True" CssClass="txtboxinspection"
                                                        Width="200px">
                                                    </asp:DropDownList>
                                                    <asp:Button ID="btnPreview" runat="server" Text="PREVIEW" ValidationGroup="save" CssClass="CSButton" Width="150px" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />


            </td>
        </tr>
    </table>
   
    
</asp:Content>

