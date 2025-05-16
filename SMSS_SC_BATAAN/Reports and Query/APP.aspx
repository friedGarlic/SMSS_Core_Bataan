<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
CodeFile="APP.aspx.vb" Inherits="Reports_and_Query_APP" title="Annual Procurement Plan Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">

    Protected Sub ddDepartment_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
<TABLE style="WIDTH: 1010px"><TBODY><TR><TD style="WIDTH: 10px"></TD><TD style="WIDTH: 1000px" align=center></TD></TR><TR><TD style="WIDTH: 10px"></TD><TD style="WIDTH: 1000px" class="PageTitle" align=center>ANNUAL PROCUREMENT PLAN</TD></TR><TR><TD style="WIDTH: 10px"></TD><TD style="WIDTH: 1000px" align=center></TD></TR><TR><TD style="WIDTH: 10px"></TD><TD style="WIDTH: 1000px" class="text5" align=center><asp:RadioButtonList id="rbChoice" runat="server" Width="300px" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbChoice_SelectedIndexChanged" CssClass="text5" AutoPostBack="True">
                    <asp:ListItem Value="1">LGU - Consolidated</asp:ListItem>
                    <asp:ListItem Value="2" Selected="True">Per Department</asp:ListItem>
                </asp:RadioButtonList></TD></TR><TR><TD style="WIDTH: 10px"></TD><TD style="WIDTH: 1000px" align=center><asp:MultiView id="mvAPP" runat="server"><asp:View id="vwLGU" runat="server"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 20%" class="column_RightBold">Report Format :</TD><TD style="WIDTH: 80%" class="text5"><asp:RadioButtonList id="rbLGU" runat="server" Width="200px" RepeatDirection="Horizontal" CssClass="text5" AutoPostBack="True">
                                        <asp:ListItem Value="1">GPPB </asp:ListItem>
                                        <asp:ListItem Value="2">DILG</asp:ListItem>
                                    </asp:RadioButtonList></TD></TR><TR><TD style="WIDTH: 20%" class="column_RightBold">APP Year :</TD><TD style="WIDTH: 80%" class="text5"><asp:DropDownList id="ddYear" runat="server" Width="150px" CssClass="txtboxinspection" AutoPostBack="True" Enabled="False">
                                    </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 20%" class="column_RightBold"></TD><TD style="WIDTH: 80%" class="text5"></TD></TR><TR><TD style="WIDTH: 20%" class="column_RightBold"></TD><TD style="WIDTH: 80%" class="text5"><asp:Button id="btnPreview" runat="server" Width="200px" Enabled="False" Text="PREVIEW" CssClass="CSButton"></asp:Button> <asp:Label id="lblNotification2" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="11pt" Font-Names="Calibri" Text="**NOTE:  Complete Signatories." Visible="False" Font-Italic="True"></asp:Label></TD></TR></TBODY></TABLE></asp:View> <asp:View id="vwDepartment" runat="server"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 20%" class="column_RightBold">Report Format :</TD><TD style="WIDTH: 80%" class="text5">
<asp:RadioButtonList id="rbPerDept" runat="server" Width="200px" RepeatDirection="Horizontal" CssClass="text5" AutoPostBack="True">
                                        <asp:ListItem Value="1">GPPB </asp:ListItem>
                                        <asp:ListItem Value="2">DILG</asp:ListItem>
                                    </asp:RadioButtonList></TD></TR><TR><TD style="WIDTH: 20%" class="column_RightBold">Year :</TD><TD style="WIDTH: 80%" class="text5"><asp:DropDownList id="ddDeptYear" runat="server" Width="150px" CssClass="txtboxinspection" AutoPostBack="True" Enabled="False">
                                    </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 20%" class="column_RightBold">Department :</TD><TD style="WIDTH: 80%" class="text5"><asp:DropDownList id="ddDepartment" runat="server" Width="500px" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddDepartment_SelectedIndexChanged">
                                    </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 20%" class="column_RightBold">Function :</TD><TD style="WIDTH: 80%" class="text5"><asp:DropDownList id="ddFunction" runat="server" Width="500px" AutoPostBack="True" Enabled="False">
                                    </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 20%" class="column_RightBold"></TD><TD style="WIDTH: 80%" class="text5"><asp:CheckBox id="cbSupplemental" runat="server" Font-Bold="True" Font-Names="Arial" Text="Supplemental"></asp:CheckBox></TD></TR><TR><TD style="WIDTH: 20%" class="column_RightBold"></TD><TD style="WIDTH: 80%" class="text5"><asp:Button id="btnAPPDept" runat="server" Width="200px" Enabled="False" Text="PREVIEW" CssClass="CSButton"></asp:Button> <asp:Button id="btnConti" runat="server" Width="200px" Font-Size="9pt" Enabled="False" Text="PREVIEW APP CONTINGENCY" Visible="False"></asp:Button> 
<asp:Label id="lblNotification" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="11pt" Font-Names="Calibri" Text="**NOTE:  Complete Signatories." Visible="False" Font-Italic="True"></asp:Label></TD></TR></TBODY></TABLE></asp:View> </asp:MultiView></TD></TR><TR><TD style="WIDTH: 10px"></TD><TD style="WIDTH: 1000px" class="DivTitle" align=center>SIGNATORIES</TD></TR><TR><TD style="WIDTH: 10px"></TD><TD style="WIDTH: 1000px" align=center><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 15%" class="column_RightBold">BAC Member 1 :</TD><TD style="WIDTH: 35%" class="text5"><asp:DropDownList id="ddBAC1" runat="server" Width="90%" CssClass="txtboxinspection" Enabled="False">
                            </asp:DropDownList></TD><TD style="WIDTH: 15%" class="column_RightBold">BAC Vice Chairman : </TD><TD style="WIDTH: 35%" class="text5"><asp:DropDownList id="ddBACVC" runat="server" Width="90%" CssClass="txtboxinspection" Enabled="False">
                            </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 15%" class="column_RightBold">BAC Member 2 :</TD><TD style="WIDTH: 35%" class="text5"><asp:DropDownList id="ddBAC2" runat="server" Width="90%" CssClass="txtboxinspection" Enabled="False">
                            </asp:DropDownList></TD><TD style="WIDTH: 15%" class="column_RightBold">BAC Chairman : </TD><TD style="WIDTH: 35%" class="text5"><asp:DropDownList id="ddBACC" runat="server" Width="90%" CssClass="txtboxinspection" Enabled="False">
                            </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 15%" class="column_RightBold">BAC Member 3 :</TD><TD style="WIDTH: 35%" class="text5"><asp:DropDownList id="ddBAC3" runat="server" Width="90%" CssClass="txtboxinspection" Enabled="False">
                            </asp:DropDownList></TD><TD style="WIDTH: 15%" class="column_RightBold"></TD><TD style="WIDTH: 35%" class="text5"></TD></TR><TR><TD style="WIDTH: 15%" class="column_RightBold"></TD><TD style="WIDTH: 35%" class="text5"></TD><TD style="WIDTH: 15%" class="column_RightBold"></TD><TD style="WIDTH: 35%" class="text5"></TD></TR><TR><TD style="WIDTH: 15%" class="column_RightBold">Prepared By :</TD><TD style="WIDTH: 35%" class="text5"><asp:DropDownList id="ddPreparedBy" runat="server" Width="90%" OnSelectedIndexChanged="ddPreparedBy_SelectedIndexChanged" CssClass="txtboxinspection" AutoPostBack="True" Enabled="False">
                            </asp:DropDownList></TD><TD style="WIDTH: 15%" class="column_RightBold">Approved By :</TD><TD style="WIDTH: 35%" class="text5"><asp:DropDownList id="ddApprovedBy" runat="server" Width="90%" CssClass="txtboxinspection" Enabled="False">
                            </asp:DropDownList></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 10px"></TD><TD style="WIDTH: 1000px" align=center></TD></TR><TR><TD style="WIDTH: 10px"></TD><TD style="WIDTH: 1000px" align=center></TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>
</asp:Content>

