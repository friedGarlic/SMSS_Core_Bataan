<%@ Page 
    Title="PropertyCardInventory" 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false"
    CodeFile="rpt_PropertyCardInventory.aspx.vb" 
    Inherits="rpt_PropertyCardInventory" 
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<script runat="server">



</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    
<script type="text/javascript">
document.getScroll = function() {
    if (window.pageYOffset != undefined) {
        return [pageXOffset, pageYOffset];
    } else {
        var sx, sy, d = document,
            r = d.documentElement,
            b = d.body;
        sx = r.scrollLeft || b.scrollLeft || 0;
        sy = r.scrollTop || b.scrollTop || 0;
        return [sx, sy];
    }
}
</script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

                   <table cellspacing="1" style="width: 1010px">

                <tr>
                    <td width="10px"></td>
                    <td class="PageTitle" width="1000px">Property Card Report</td>
                </tr>
                <tr>
                    <td width="10px"></td>
                    <td width="1000px"></td>
                </tr>
                <tr>
                    <td width="10px"></td>
                    <td width="1000px">
                       
                        <table cellpadding="1" cellspacing="1" style="width: 80%">
                           
                          <tr>
                                                           
                                <td class="column_RightBold" width="22%" style="height: 24px">Report Type : </td>
                                <td class="text5" width="30%" style="height: 24px">
                                    <asp:DropDownList ID="ddReport" runat="server" Width="150px" AutoPostBack="True" CssClass="drpdownCSS"  style="margin-left: 0px; margin-top: 0px;" OnSelectedIndexChanged="ddReport_SelectedIndexChanged"  >
                                        <asp:ListItem Value="0">Continuous </asp:ListItem>
                                        <asp:ListItem Value="1">Monthly </asp:ListItem>
                                      
                                    </asp:DropDownList>
                                </td>
                           
                                  <td class="column_RightBold" style="width: 15%; height: 24px;">Year : </td>
                                <td  class="column_LeftBold" width="15%" style="height: 24px">
                                     <asp:DropDownList ID="drpYear"   runat="server" Width="150px">
                                    </asp:DropDownList>
                                </td>

                                <td class="column_RightBold" style="width: 20%; height: 24px;">Month : </td>
                                <td class="column_LeftBold" width="20%" style="height: 24px">
                                    <asp:DropDownList ID="ddMonth"   enabled="false" runat="server" Width="150px">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
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
                                
                                   
                                <td>
                               <asp:Button ID="BtnPreview" cssClass="CSButton" runat="server" Text="PREVIEW" Width="100" OnClick="BtnPreview_Click" />
                    
                                </td>
                            </tr>
                        </table>
                         
                    </td>
                </tr>
          
                <tr>
                    <td width="10px"></td>
                    <td width="1000px">
                    <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"  hastogglegrouptreebutton="False" style="background-color: white; text-align: left;" height="800px" width="950px" bestfitpage="False" bordercolor="Silver" borderstyle="Solid" borderwidth="1px"></cr:crystalreportviewer>
                    <cr:crystalreportsource id="CrystalReportSource1" runat="server">
                    <Report FileName="PropertyCardInventory.rpt">
                    </Report>
                    </cr:crystalreportsource>
      

                    </td>
                </tr>
            
            </table>

    
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

