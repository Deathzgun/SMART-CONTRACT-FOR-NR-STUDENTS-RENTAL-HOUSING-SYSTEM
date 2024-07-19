<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewPropertyDetails.aspx.cs" Inherits="PropertyRentalContarct.ViewPropertyDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .hiddencol
        {
            display:none;
        }
        .head{
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2><strong>Property Details</strong></h2>
    </div>
    <div style="background-color:beige">
        <br />
     <div align="right" class="row">      
        <div class="col-md-8"></div>         
        <div class="col-md-2">
            <asp:TextBox ID="txtsearch" runat="server"  placeholder="Search by Location / Rent" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnsearch_Click"/>
        </div>
    </div>
    <br />
    <div align="center" style="height:325px; overflow-y:scroll;background-color:beige">
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="90%" GridLines="Horizontal" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black">                       
            <Columns>
                <asp:BoundField DataField="Pid" HeaderText="Id"  HeaderStyle-CssClass="head" ItemStyle-CssClass="head">                
                </asp:BoundField>

                <asp:BoundField DataField="Lid" HeaderText="LId"  HeaderStyle-CssClass="head" ItemStyle-CssClass="head">                
                </asp:BoundField>

                <asp:BoundField DataField="Lname" HeaderText="Landlord Name" HeaderStyle-CssClass="head" ItemStyle-CssClass="head">                
                </asp:BoundField>

                <asp:BoundField DataField="ApartmentType" HeaderText="House Type" HeaderStyle-CssClass="head" ItemStyle-CssClass="head">               
                </asp:BoundField>

                <asp:BoundField DataField="TotalArea" HeaderText="Total Area(in Sqft.)" HeaderStyle-CssClass="head" ItemStyle-CssClass="head">                
                </asp:BoundField>

                <asp:BoundField DataField="Location" HeaderText="Location" HeaderStyle-CssClass="head" ItemStyle-CssClass="head">               
                </asp:BoundField>

                <asp:BoundField DataField="Rent" HeaderText="Rent(per Month)" HeaderStyle-CssClass="head" ItemStyle-CssClass="head">             
                </asp:BoundField>
              
                <asp:BoundField DataField="Interest" HeaderText="Interest" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" >               
                </asp:BoundField>
               
                <asp:TemplateField HeaderStyle-CssClass="head" ItemStyle-CssClass="head">
                    <ItemTemplate>              
                        <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text='<%#Eval("Interest").ToString() %>'  Visible='<%#Eval("Interest").ToString() == "NA"? false : true %>'></asp:Label>
                        <asp:LinkButton ID="lbtnShowInt" runat="server" Font-Size="Medium" CssClass="btn btn-info" Text="Show Interest" Visible='<%#Eval("Interest").ToString() == "NA"? true : false %>' OnClick="lbtnShowInt_Click"></asp:LinkButton>
                    </ItemTemplate>                                       
                    <HeaderStyle CssClass="head"></HeaderStyle>
                    <ItemStyle CssClass="head"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Height="40px" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="white" HorizontalAlign="Center" Height="45px"/>
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
