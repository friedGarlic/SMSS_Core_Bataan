<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="NoAIRReports.aspx.vb"
    Inherits="Procurement_NoAIR" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <table cellspacing="1" style="width: 1010px">
                <tr>
                    <td width="10px"></td>
                    <td class="PageTitle" width="1000px">TRANSACTIONS WITHOUT A.I.R.</td>
                </tr>
                <tr>
                    <td width="10px"></td>
                    <td align="center" width="1000px"><font style="font-family: Arial; font-size: 10pt; font-weight: bold">SEARCH : </font>
                        <asp:DropDownList ID="ddSearchOption" runat="server" Style="width: 150px" CssClass="txtboxinspection">
                            <asp:ListItem Selected="True">Purchase Order No.</asp:ListItem>
                            <asp:ListItem>Purchase Request No.</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;
                <asp:TextBox runat="server" ID="txtSearch" Width="150px" CssClass="txtboxinspection"></asp:TextBox>
                        &nbsp;<asp:Button ID="btnSearch" runat="server" Text="SEARCH" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();"/>
                    </td>
                </tr>
                <tr>
                    <td width="10px"></td>
                    <td align="center" width="1000px">
                        <asp:GridView ID="grdNoAIR" runat="server" Width="90%" SkinID="GridViewAA" EmptyDataText="No Data Found." PageSize="20" AllowPaging="True">

                            <Columns>
                              
                               <asp:BoundField HeaderText="PO Number" DataField="PO_No" >
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:BoundField>
                                
                               <asp:BoundField HeaderText="OBR Number" DataField="OBR_No" >
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                </asp:BoundField>

                                 <asp:BoundField HeaderText="PR Number" DataField="pr_no" >
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                </asp:BoundField>

                                 <asp:BoundField HeaderText="PR Purpose" DataField="remarks" >
                                <ItemStyle HorizontalAlign="left" Width="55%" />
                                </asp:BoundField>

                            </Columns>

                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td width="10px"></td>
                    <td align="center" width="1000px"></td>
                </tr>
                <tr>
                    <td width="10px"></td>
                    <td align="center" width="1000px"></td>
                </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

