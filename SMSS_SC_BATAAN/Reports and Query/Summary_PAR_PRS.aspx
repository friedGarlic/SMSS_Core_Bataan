<%@ Page Title="Summary of PAR and PRS" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Summary_PAR_PRS.aspx.vb" Inherits="Reports_and_Query_Summary_PAR_PRS" StylesheetTheme="SkinFile" %>


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
                        <td style="width: 98%" class="PageTitle">SUMMARY OF PAR, PRS AND RPRI
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table cellpadding="0px" cellspacing="0px" width="100%">
                                <tr>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab1_PAR" Width="100%" Text="Summary of PAR" CssClass="TabButton_Active" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button runat="server" ID="btnTab2_PRS" Width="100%" Text="Summary of PRS" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:Button ID="btnTab3_PRI" runat="server" CssClass="TabButton_InActive" OnClientClick="StartProgressBar();" Text="Summary of RPRI" Width="100%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="3" class="PanelTabs">
                                        <asp:MultiView runat="server" ID="mvTabs">


                                            <asp:View runat="server" ID="vwTab1_PAR">
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <td align="center" style="width: 100%">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <td align="center" style="width: 100%">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 100%">
                                                            <table width="80%">
                                                                
                                                                    <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Department :</td>
                                                                    <td style="width: 80%" class="column_Left">

                                                                       <asp:DropDownList ID="DrpRC_PAR" runat="server" CssClass="drpdownCSS" Height="22px" Width="34%">
                                                                        </asp:DropDownList>
                                                                        <asp:CheckBox ID="SelectAll" runat="server" CssClass="rbCS_Horizontal" AutoPostBack="True"  Text="ALL" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Month :</td>
                                                                    <td style="width: 80%" class="column_Left">

                                                                       <asp:DropDownList ID="DrpMonth_PAR" runat="server" CssClass="drpdownCSS" Height="16px" Width="10%" Visible="true">
                                                                           <asp:ListItem Selected="True" Value="0">ALL</asp:ListItem>
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
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Year :</td>
                                                                    <td style="width: 80%" class="column_Left">

                                                                       <asp:DropDownList ID="drpYear_PAR" runat="server" CssClass="drpdownCSS" Height="16px" Width="10%">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <tr>
                                                                <td style="width: 100%; height: 10px"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="width: 100%">
                                                                    <asp:Button ID="btnPreview_PAR" runat="server" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Preview" Width="12%" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%; height: 20px"></td>
                                                            </tr>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>



                                            <asp:View runat="server" ID="vwTab2_PRS">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="80%">
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Department :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:DropDownList ID="ddDepartment" runat="server" Width="60%" CssClass="drpdownCSS">
                                                                        </asp:DropDownList>
                                                                        &nbsp;<asp:CheckBox ID="cbAll" runat="server" CssClass="rbCS_Horizontal" AutoPostBack="True"  Text="ALL" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Report Option :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:DropDownList ID="ddOption" runat="server" Width="20%" CssClass="drpdownCSS">
                                                                            <asp:ListItem Value="All">ALL</asp:ListItem>
                                                                            <asp:ListItem Value="Stock">Returned to Stock</asp:ListItem>
                                                                            <asp:ListItem Value="Repair">For Repair</asp:ListItem>
                                                                            <asp:ListItem Value="Dispose">Disposal</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Year :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:DropDownList ID="ddYear" runat="server" Width="20%" CssClass="drpdownCSS">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Month :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:DropDownList ID="ddMonth" runat="server" Width="20%" CssClass="drpdownCSS">
                                                                            <asp:ListItem Selected="True" Value="0">ALL</asp:ListItem>
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
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Prepared By :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:DropDownList ID="ddPreparedBy" runat="server" Width="60%" CssClass="drpdownCSS">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td style="width: 100%;height:10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                                <asp:Button ID="btnPreview_PRS" runat="server" Text="Preview" Width="12%" CssClass="CSButton" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%;height:20px"></td>
                                                    </tr>
                                                </table>

                                            </asp:View>
                                                                                        <asp:View runat="server" ID="vwTab3_RPI">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100%; height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                            <table width="80%">
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Department :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:DropDownList ID="DDdept" runat="server" Width="60%" CssClass="drpdownCSS">
                                                                        </asp:DropDownList>
                                                                        &nbsp;<asp:CheckBox ID="CBALL1" runat="server" CssClass="rbCS_Horizontal" AutoPostBack="True"  Text="ALL" />
                                                                    </td>
                                                                </tr>
                                                              
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Year :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:DropDownList ID="DDyear1" runat="server" Width="20%" CssClass="drpdownCSS">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Month :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:DropDownList ID="DDmonth1" runat="server" Width="20%" CssClass="drpdownCSS">
                                                                            <asp:ListItem Selected="True" Value="0">ALL</asp:ListItem>
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
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                             
                                                            </table>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td style="width: 100%;height:10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" align="center">
                                                                <asp:Button ID="BtnPreview3" runat="server" Text="Preview" Width="12%" CssClass="CSButton" OnClientClick="StartProgressBar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%;height:20px"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                        </asp:MultiView>
                                    </td>
                                </tr>
                            </table>
                        </td>
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
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 20px"></td>
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

