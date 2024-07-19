<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TopUpRequest.aspx.cs" Inherits="PropertyRentalContarct.TopUpRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .hiddencol
        {
            display:none;
        }
        .gridview th, gridview td{
            text-align:center;
            vertical-align:middle;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2>TopUp Requests</h2><br />
    </div>
    <div align="center" >
        <br /><br />
        <asp:GridView ID="GridView1" CssClass="gridview" runat="server" CellPadding="4" Width="75%" ForeColor="Black" AutoGenerateColumns="false" GridLines="Horizontal" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">          
            <Columns>
                <asp:BoundField DataField="TprId" HeaderText="TId" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"  />
                <asp:BoundField DataField="LTId" HeaderText="PId" />
                <asp:BoundField DataField="WalletName" HeaderText="Wallet Name" />
                <asp:BoundField DataField="WalletAddr" HeaderText="Wallet Address" />
                <asp:BoundField DataField="Amount" HeaderText="Amount"  />
                <asp:BoundField DataField="User" HeaderText="User"/>
                <asp:BoundField DataField="DateTime" HeaderText="DateTime"/>
                <asp:BoundField DataField="status" HeaderText="status"  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnTopUp" runat="server" Text="TopUp"  Visible='<%# Eval("status").ToString() == "Pending" ? true : false %>' CssClass="btn btn-primary" OnClick="btnTopUp_Click"/>
                        <asp:Label ID="lbshlst" runat="server" Font-Size="Medium" Font-Bold="true" ForeColor="SlateGray" Visible='<%# Eval("status").ToString() == "Pending" ? false : true %>' Text="TopUp wallet"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Height="40px" HorizontalAlign="Center" VerticalAlign="Middle" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="White" Height="45px" HorizontalAlign="Center"/>
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384"/>
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <br /><br />
        <asp:Label ID="lbnodata" runat="server" Text="No Data Found" Font-Size="Large" Font-Bold="true" ForeColor="SlateGray"></asp:Label>
    </div>
    <%--<div style="background-image:url(Images/divbackg.png); background-repeat:no-repeat">
        <img src="Images/divbackg.png" style=""/>
    </div>--%>
</asp:Content>
