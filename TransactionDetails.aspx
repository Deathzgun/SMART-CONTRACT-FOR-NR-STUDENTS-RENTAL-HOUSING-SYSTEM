<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TransactionDetails.aspx.cs" Inherits="PropertyRentalContarct.TransactionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .head{
            text-align:center;
            vertical-align:middle;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2><strong>Transaction History</strong></h2>
    </div>
    <div style="background-color:beige">
        <br />
     <div align="right" class="row">      
        <div class="col-md-6"></div> 
        <div class="col-md-2" style="margin-top:4px">
            <asp:Label ID="Label1" runat="server" Text="Search by Date :" Font-Size="Medium"></asp:Label>
        </div> 
        <div class="col-md-2">
            <asp:TextBox ID="txtdate" runat="server" Width="250px" type="date" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnsearch_Click" />
        </div>
    </div>
    <br />
    <div align="center" style="height:325px; overflow-y:scroll">
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="92%" GridLines="Horizontal" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound"  BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black">                       
            <Columns>
                <asp:BoundField DataField="Type" HeaderText="Type" HeaderStyle-CssClass="head" ItemStyle-CssClass="head"/>
                <asp:BoundField DataField="Address" HeaderText="Address" HeaderStyle-CssClass="head" ItemStyle-CssClass="head"/>
                <asp:BoundField DataField="Transaction-Id" HeaderText="Transaction-Id" HeaderStyle-CssClass="head" ItemStyle-CssClass="head"/>
                <asp:BoundField DataField="Amount" HeaderText="Amount" HeaderStyle-CssClass="head" ItemStyle-CssClass="head"/>               
                <asp:BoundField DataField="Time" HeaderText="Time" HeaderStyle-CssClass="head" ItemStyle-CssClass="head"/>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Height="40px" Font-Size="Medium" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="White" Height="45px"/>
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="lbnodata" runat="server" Text="No Data Found" Font-Size="Large" Font-Bold="true" ForeColor="SlateGray"></asp:Label>
        <br />
        <br />
    </div>
        </div>
</asp:Content>
