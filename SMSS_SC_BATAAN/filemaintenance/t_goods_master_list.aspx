<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_goods_master_list.aspx.vb" 
Inherits="filemaintenance_t_goods_master_list" title="FM MASTER LIST OF GOODS" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

    <script type="text/javascript">

    function StartProgressBar() {
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
    prm.add_endRequest(EndRequestHandler);

</script>


<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
    <table style="width: 1010px">
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" style="width: 1000px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" class="PageTitle" style="width: 1000px">
                MASTER LIST</td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" style="width: 1000px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" style="width: 1000px">
                <table style="width: 90%">
                    <tr>
                        <td class="column_RightBold" style="width: 20%">
                            Allotment Type :
                        </td>
                        <td class="text5" style="width: 80%">
                            <asp:RadioButtonList id="RadioButtonList1" runat="server" Width="200px" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Value="2">MOOE</asp:ListItem>
<asp:ListItem Value="3">Capital Outlay</asp:ListItem>
</asp:RadioButtonList></td>
                    </tr>

                     <tr>
                        <td class="column_RightBold" style="width: 20%">
                            Year :
                        </td>
                        <td class="text5" style="width: 80%">
                            <asp:DropDownList id="ddYear" runat="server" Width="400px" OnSelectedIndexChanged="ddYear_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                    </tr>

                    <tr>
                        <td class="column_RightBold" style="width: 20%">
                            Categories :
                        </td>
                        <td class="text5" style="width: 80%">
                            <asp:DropDownList ID="ddCategories"
    runat="server"
    Width="400px"
    OnSelectedIndexChanged="ddCategories_SelectedIndexChanged"
    AutoPostBack="True"
    onchange="StartProgressBar();">
</asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="column_RightBold" style="width: 20%">
                            <asp:DropDownList id="ddSearch" runat="server" Width="120px"><asp:ListItem Selected="True" Value="1">Description</asp:ListItem>
<asp:ListItem Value="2">Item Code</asp:ListItem>
</asp:DropDownList>: 
                        </td>
                        <td class="text5" style="width: 80%">
                            <asp:TextBox id="txtSearch" runat="server" Width="350px" CssClass="txtboxinspection"></asp:TextBox><asp:Button ID="btnsearch"
    runat="server"
    Width="150px"
    Text="SEARCH"
    CssClass="CSButton"
    OnClientClick="StartProgressBar();" /></td>
                    </tr>
                    <tr>
                        <td class="column_RightBold" style="width: 20%">
                        </td>
                        <td class="text5" style="width: 80%">
                        </td>
                    </tr>
                    <tr>
                        <td class="column_RightBold" style="width: 20%">
                        </td>
                        <td class="text5" style="width: 80%">
                            <asp:Button id="btnPreview" onclick="btnPreview_Click" runat="server" Width="200px" Text="Generate Report" CssClass="CSButton"></asp:Button></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" class="DivTitle" style="width: 1000px">
                &nbsp;<asp:Label id="lblAccntCode" runat="server" Font-Bold="True" Font-Size="11pt" Font-Names="Arial"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" style="width: 1000px">


<asp:GridView id="gvstock" runat="server" Width="95%" PageSize="30" SkinID="GridViewAA" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Data Found." Font-Size="9pt"><Columns>
<asp:BoundField DataField="No" HeaderText="No.">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ItemCode" HeaderText="Item Code">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Item_Desc" HeaderText="DESCRIPTION">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="65%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="unit_desc" HeaderText="UNIT">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="price" DataFormatString="{0:N}" HeaderText="PRICE" HtmlEncode="False">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" style="width: 1000px">
                <asp:Panel id="Panel1" runat="server" Width="98%" GroupingText="SEARCH CRITERIA" CssClass="text" Visible="False"><asp:RadioButtonList id="rb" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="0">Like</asp:ListItem>
            <asp:ListItem Value="1">Contains</asp:ListItem>
        </asp:RadioButtonList></asp:Panel> <asp:Panel style="TEXT-ALIGN: left" id="Panel222" runat="server" Width="98%" GroupingText="SEARCH" CssClass="text" Visible="False"><asp:Button id="Button1" runat="server" Width="100px" Text="REFRESH" Visible="False"></asp:Button></asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td align="center" style="width: 1000px">
            </td>
        </tr>
    </table>


    <asp:Panel
        ID="PanelProgress"
        runat="server"
        Width="109px"
        Style="border-top-width: 1px;
               border-left-width: 1px;
               border-left-color: #0033cc;
               border-bottom-width: 1px;
               border-bottom-color: #0033cc;
               border-top-color: #0033cc;
               position: relative;
               background-color: transparent;
               text-align: center;
               border-right-width: 1px;
               border-right-color: #0033cc;">

        <img alt="Loading..." src="../images/ajax-loader.gif" />

    </asp:Panel>


    <cc1:ModalPopupExtender
        ID="ProgressBarModalPopupExtender"
        runat="server"
        BackgroundCssClass="modalBackground"
        BehaviorID="ProgressBarModalPopupExtender"
        PopupControlID="PanelProgress"
        TargetControlID="ButtonProgress">
    </cc1:ModalPopupExtender>


    <asp:Button
        ID="ButtonProgress"
        runat="server"
        Width="16px"
        Enabled="False"
        Style="display: none;
               border-top-style: none;
               border-right-style: none;
               border-left-style: none;
               position: relative;
               background-color: transparent;
               border-bottom-style: none">
    </asp:Button>


</contenttemplate>
</asp:UpdatePanel>
</asp:Content>

