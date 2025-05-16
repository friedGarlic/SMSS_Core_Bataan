<%@ Page Title="Waste Materials" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="WasteMaterials_Reports.aspx.vb" Inherits="Reports_and_Query_WasteMaterials_Reports"
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript"> 
        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) {
                return false;
            }
        }
        document.onkeypress = stopRKey;

        function toPeso(objctrl) {
            //Get the Entered Value
            var number = objctrl.value.toString(),
                //Split the number between WholeNumber and Decimals
                php = number.split('.')[0], cents = (number.split('.')[1] || '') + '00';
            php = php.split('').reverse().join('').replace(/(\d{3}(?!$))/g, '$1,').split('').reverse().join('');
            //Concatenate the number 
            objctrl.value = php + '.' + cents.slice(0, 2);
        }

    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">WASTE MATERIALS REPORTS
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                     <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%;height:10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search By : </span>
                            &nbsp;<asp:DropDownList runat="server" ID="drpSearch" CssClass="drpdownCSS" Width="12%" AutoPostBack="true">
                                <asp:ListItem Value="1" Text="WMR No." Selected="True"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Department"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<span class="column_RightBold"> : </span>
                            &nbsp;<asp:TextBox runat="server" ID="txtSearch" CssClass="txtbox_Var" Width="25%" Text=""></asp:TextBox>
                            &nbsp;<asp:Button runat="server" ID="btnSearch" CssClass="CSButton" Width="12%" Text="Search" OnClientClick="StartProgressBar();"/>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%;height:5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdWMR" SkinID="GridViewAA" Width="80%" AllowPaging="true" PageSize="15" EmptyDataText="No Data Found"
                                DataKeyNames="WMHdr_ID">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkPreview" CssClass="LinkBtnSelect" Text="Preview" CommandName="Select" OnClientClick="StartProgressbar();"  Visible='<%# Bind("isVisible") %>'></asp:LinkButton>
                                        </ItemTemplate>                                        
                                    </asp:TemplateField>

                                    <asp:BoundField HeaderText="WMR Date" DataField="WM_Date" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:d}"/>
                                    <asp:BoundField HeaderText="WMR Number" DataField="ctrl_no" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField HeaderText="Department" DataField="RC_Name" ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Left"/>

                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                      <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%;height:20px"></td>
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



            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

