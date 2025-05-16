<%@ Page Title="AIR EDITING" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="IAR_Editing.aspx.vb"
    Inherits="procurement_IAR_Editing" EnableEventValidation="false" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 1010px">
                <tr>
                    <td style="width: 10px"></td>
                    <td style="width: 1000px" align="center" class="PageTitle">IAR EDITING</td>
                </tr>
                <tr>
                    <td style="width: 10px"></td>
                    <td style="width: 1000px; font-family:Arial; font-size:10pt" align="center" >
                       <strong> SEARCH INVOICE NUMBER :</strong>                          
                       <asp:TextBox runat="server" ID="txtSearch" Width="250px" CssClass="txtboxinspection"></asp:TextBox>
                        &nbsp;<asp:Button runat="server" ID="btnSearch" Width="150px" Text="SEARCH"/>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px"></td>
                    <td style="width: 1000px" align="center">
                        <asp:GridView ID="grdIAR" runat="server" Width="96%" Font-Bold="False" CssClass="text" AllowPaging="True"  SkinID="GridViewAA" AutoGenerateColumns="False" DataKeyNames="AIRHdr_ID"  EmptyDataText="No Data Found." Font-Size="8pt">
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSelect" runat="server" Font-Underline="false" CommandName="Select">Select</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Invoice_No" HeaderText="Invoice Number">
                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Invoice Date">                                    
                                        <ItemTemplate>                                        
                                            <asp:TextBox runat="server" ID="txtInvoiceDate" Width="95%" Text='<%# Bind("Invoice_date", "{0:d}") %>' Enabled ="false" CssClass="txtboxcenter"></asp:TextBox>
                                             <cc1:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="txtInvoiceDate" Enabled="True" PopupButtonID="txtInvoiceDate"></cc1:CalendarExtender>

                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="RC_Name" HeaderText="Requesting Dept.">
                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                    </asp:BoundField>                                    
                                    <asp:BoundField DataField="SuppName" HeaderText="Supplier">
                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>                                    
                                </Columns>

                                <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
                            </asp:GridView>
                    </td>
                </tr>
                 <tr>
                    <td style="width: 10px"></td>
                    <td style="width: 1000px" align="center" > &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 10px"></td>
                    <td style="width: 1000px" align="center" class="DivTitle">ITEM DETAILS</td>
                </tr>
                <tr>
                    <td style="width: 10px"></td>
                    <td style="width: 1000px" align="center">
                        <asp:Panel ID="Panel2" runat="server" Width="90%" CssClass="PanelSize" ScrollBars="Vertical">
                           
                         <asp:GridView ID="grdIAR_Items" runat="server" Width="100%" Font-Bold="False" CssClass="text"  SkinID="GridViewAA" AutoGenerateColumns="False" DataKeyNames="AIRHdr_ID,AIRDtl_ID"  EmptyDataText="No Data Found." Font-Size="8pt">
                                <Columns>                                   
                                    <asp:BoundField DataField="Item_Desc" HeaderText="Item Description">
                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="IAR Qty">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">                                       
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtQty" runat="server" Text='<%# Bind("Qty") %>' CssClass="text6" Width="90%"></asp:TextBox>
                                        </ItemTemplate>                                    
                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
                            </asp:GridView>
                             </asp:Panel>
                    </td>
                </tr>
                   <tr>
                    <td style="width: 10px"></td>
                    <td style="width: 1000px" align="center" > 
                        <asp:Button runat="server" ID="btnSave" Width="150px" Text="SAVE" OnClientClick="StartProgressBar();"/>
                        <asp:Button runat="server" ID="btnCancel" Width="150px" Text="CANCEL"/>
                    </td>
                </tr>
                     </tr>
                   <tr>
                    <td style="width: 10px"></td>
                    <td style="width: 1000px" align="center" > &nbsp;</td>
                </tr>
            </table>

            
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
           <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
            

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

