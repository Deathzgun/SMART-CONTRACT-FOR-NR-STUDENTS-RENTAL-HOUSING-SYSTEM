<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="ViewTenants.aspx.cs" Inherits="PropertyRentalContarct.ViewTenants" %>
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
        <h2><strong>Tenants Details</strong></h2><br />
    </div>
    <div align="center" style="background-color:beige; height:350px; overflow-y:scroll">
        <br />
        <asp:GridView ID="GridView1" CssClass="Gridview" runat="server" AutoGenerateColumns="False" Width="60%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="horizontal">           
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="TId" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />
                <asp:BoundField DataField="PId" HeaderText="PId" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />
                <asp:BoundField DataField="Interest" HeaderText="Interest" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />
                <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" />
                <asp:BoundField DataField="MobileNo" HeaderText="Mobile No." HeaderStyle-CssClass="head" ItemStyle-CssClass="head" />
                <asp:BoundField DataField="Address" HeaderText="Address" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" />
                <asp:BoundField DataField="EmailId" HeaderText="Email-ID" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnShortlist" runat="server" Text="Shortlist"  Visible='<%# Eval("Interest").ToString() == "Interested" ? true : false %>' CssClass="btn btn-info" OnClick="btnShortlist_Click"/>
                        <asp:Label ID="lbshlst" runat="server" Font-Size="Medium" Font-Bold="true" ForeColor="SlateGray" Visible='<%# Eval("Interest").ToString() == "Interested" ? false : true %>' Text="Shortlisted"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" height="40px" Font-Size="Medium"/>
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="White" height="45px"/>
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
