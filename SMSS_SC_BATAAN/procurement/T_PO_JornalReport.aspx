<%@ Page Title="Purchase Journal report" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="T_PO_JornalReport.aspx.vb" Inherits="T_PO_JornalReport" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<script runat="server">


</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

                   <table cellspacing="1" style="width: 1010px">

                <tr>
                    <td width="10px"></td>
                    <td class="PageTitle" width="1000px">Schedule of Purchase   </td>
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
                                                           
                                <td class="column_RightBold" width="20%" style="height: 25px">Month : </td>
                                <td class="text5" width="60%" style="height: 25px">
                                    <asp:DropDownList ID="drpMonth" runat="server" Width="150px">
                                        <asp:ListItem Value="0">ALL</asp:ListItem>
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
                           
                                <td class="column_CenterBold" style="width: 35%; height: 25px;">Fund Type : </td>
                                <td class="text5" width="50%" style="height: 25px">
                                    <asp:DropDownList ID="ddFund" runat="server" Width="200px" style="margin-bottom: 0px">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">General Fund</asp:ListItem>
                                        <asp:ListItem Value="2">Special Educational Fund</asp:ListItem>
                                        <asp:ListItem Value="2">Trust Fund</asp:ListItem>
                                        
                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td class="column_RightBold" width="20%">Year : </td>
                                <td class="text5" width="60%">
                                    <asp:DropDownList ID="drpYear" runat="server" Width="150px">
                                    </asp:DropDownList>
                                     </td>
                                      <td class="column_CenterBold" style="width: 35%">Allotment Type : </td>
                                <td class="text5" width="50%">
                                    <asp:DropDownList ID="DDallotment" runat="server" Width="200px" style="margin-bottom: 0px; margin-right: 0px;">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="2">MOOE</asp:ListItem>
                                        <asp:ListItem Value="3">Capital Outlay</asp:ListItem>
                                        
                                        
                                    </asp:DropDownList>
                                     <td width="10px"></td>
                                <td>
                               
                    
                                </td>


                               
                            </tr>

                            <tr>
                                <td class="column_RightBold" width="20%">Prepared By : </td>
                                <td class="text5" width="60%">
                                    <asp:DropDownList ID="ddPrepared" runat="server" Width="150px">
                                    </asp:DropDownList>
                                     </td>
                                      <td class="column_CenterBold" style="width: 35%"> Approved By : </td>
                                <td class="text5" width="50%">
                                    <asp:DropDownList ID="ddApproved" runat="server" Width="200px" style="margin-bottom: 0px; margin-right: 0px;">
                                       
                                       
                                    </asp:DropDownList>
                                     <td width="10px"></td>
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
                        <Report FileName="rpt_PO_JournalReport.rpt">
                        </Report>
                        </cr:crystalreportsource>
      

                    </td>
                </tr>
            
            </table>

    
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

