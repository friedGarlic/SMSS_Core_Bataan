<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_DocumentAttachment.aspx.vb"
    Inherits="bidding_t_DocumentAttachment" Title="DOCUMENT ATTACHMENT" EnableEventValidation="false" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <div>
        <table width="100%">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">Document Attachment - Public Bidding
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <asp:DropDownList ID="ddSearch" runat="server" Width="120px" CssClass="drpdownCSS">
                        <asp:ListItem Selected="True" Value="1">PR Number</asp:ListItem>
                        <asp:ListItem Value="2">PPA Description</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;<span class="column_RightBold">:</span>
                    &nbsp;<asp:TextBox ID="txtSearch" runat="server" CssClass="txtbox_Var" Width="300px"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnSearch" runat="server" Text="SEARCH" Width="150px" CssClass="CSButton" />
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <asp:GridView ID="grdPurchaseRequest" runat="server" AllowPaging="True" DataKeyNames="prhdr_id,pre_procurement_hdr_id"
                        EmptyDataText="No Data Found." OnRowDataBound="grdPurchaseRequest_RowDataBound"
                        OnSelectedIndexChanged="grdPurchaseRequest_SelectedIndexChanged" SkinID="GridViewAA"
                        Width="98%">
                        <Columns>
                            <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="project_name" HeaderText="Program / Project / Activities">
                                <ItemStyle HorizontalAlign="Left" Width="50%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="opening_venue" HeaderText="Bid Location">
                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="opening_date" DataFormatString="{0:d}" HeaderText="Bid Date">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#2977DC" />
                        <HeaderStyle BackColor="#2977DC" ForeColor="White" />
                    </asp:GridView>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="DivTitle">Attachment
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <table style="width: 100%">
                        <tr>
                            <td class="column_RightBold" style="width: 20%">Date :
                            </td>
                            <td class="text5" style="width: 80%">
                                <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox_Date" ReadOnly="True" Width="120px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="column_RightBold" style="width: 20%">Attach File :</td>
                            <td class="text5" style="width: 80%">
                                <asp:FileUpload ID="FileUpload1" runat="server" Width="400px" ClientIDMode="Inherit" ViewStateMode="Inherit" CssClass="txtbox_Var" Enabled="False"></asp:FileUpload></td>
                        </tr>
                        <tr>
                            <td style="width: 20%"></td>
                            <td style="width: 80%; height: 10px"></td>
                        </tr>
                        <tr>
                            <td class="column_RightBold" style="width: 20%"></td>
                            <td class="column_Left" style="width: 80%">
                                <span style="color: red; font-family: Calibri">Note:
                                    <br />
                                    Accepted file types:  *.doc, *.rar, *.zip, *.xls, and *.xlsx
                                </span></td>
                        </tr>
                        <tr>
                            <td style="width: 20%"></td>
                            <td style="width: 80%; height: 10px"></td>
                        </tr>
                        <tr>
                            <td class="column_RightBold" style="width: 20%"></td>
                            <td class="column_Left" style="width: 80%">

                                <asp:Button ID="UploadButton" Text="UPLOAD FILE" OnClick="UploadButton_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();"></asp:Button>
                                <asp:Label ID="lblNoti" runat="server" Font-Names="Calibri" Font-Size="9pt" ForeColor="Red" Text="* No file to upload." Visible="False"></asp:Label></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <asp:GridView ID="grdDocuments" runat="server" AllowPaging="True" DataKeyNames="Document_ID,AttachedFilename,Location"
                        EmptyDataText="No Data Found." SkinID="GridViewAA" Width="80%" PageSize="5" OnSelectedIndexChanged="grdDocuments_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="Document Name">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDocu" runat="server" CommandName="Select" Text='<%# Bind("AttachedFilename") %>' Font-Underline="False"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="70%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="DateUploaded" DataFormatString="{0:d}" HeaderText="Date Uploaded">
                                <ItemStyle HorizontalAlign="Center" Width="30%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Location" HeaderText="From" Visible="False">
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#2977DC" />
                        <HeaderStyle BackColor="#2977DC" ForeColor="White" />
                    </asp:GridView>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%"></td>
                <td style="width: 1%"></td>
            </tr>
        </table>
    </div>


      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="PanelProgress" runat="server" Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" Width="109px">
                    <img alt="" src="../images/ajax-loader.gif" />
                </asp:Panel>
                <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress">
                </cc1:ModalPopupExtender>
                <asp:Button ID="ButtonProgress" runat="server" Enabled="False" Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" Width="16px" />

            </ContentTemplate>
        </asp:UpdatePanel>


    

</asp:Content>

