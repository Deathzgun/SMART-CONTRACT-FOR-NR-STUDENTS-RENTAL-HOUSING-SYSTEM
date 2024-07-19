<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewLRating.aspx.cs" Inherits="PropertyRentalContarct.ViewLRating" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .Gridview th, .Gridview td
        {
            text-align:center;
            vertical-align:middle;
        } 
        .hiddencol
        {
            display:none;
        }
        .head
        {
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2><strong>Feedback about Landlord</strong></h2><br />
    </div>
    <div align="center" style="background-color:beige;height:350px;overflow-y:scroll">
        <br />
        <asp:GridView ID="GridView1" CssClass="Gridview" runat="server"  Width="50%" BackColor="White" AutoGenerateColumns="false" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="horizontal">           
            <Columns>
                <asp:BoundField DataField="Fdid" HeaderText="fDId" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />
                <asp:BoundField DataField="Lid" HeaderText="Landlord-Id" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" />               
                <asp:BoundField DataField="Tid" HeaderText="Tenant-Id" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" />               
                <asp:BoundField DataField="FeedBack" HeaderText="Feedback" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" />               
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" height="35px" Font-Size="Medium"/>
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="White" height="35px"/>
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
</asp:Content>
