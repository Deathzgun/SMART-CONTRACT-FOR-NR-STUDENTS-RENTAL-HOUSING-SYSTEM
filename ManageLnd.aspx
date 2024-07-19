<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="ManageLnd.aspx.cs" Inherits="PropertyRentalContarct.ManageLnd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .hiddencol
        {
            display:none;
        }
        .gridview th, gridview td{
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
       <h2><strong>Manage Landlords</strong></h2><br />
    </div>
    <div style="background-color:beige">
        <br />
    <div align="right" class="row">      
        <div class="col-md-7"></div>         
        <div class="col-md-2">
            <asp:TextBox ID="txtsearch" runat="server"  placeholder="Search by Id / Name" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-1" align="left">
            <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnsearch_Click"/>
        </div>
    </div>    
    <div align="center" style="overflow-y:scroll;height:325px">
        <br />
        <asp:GridView ID="GridView1" CssClass="gridview" runat="server" CellPadding="4" Width="64%" AutoGenerateColumns="False" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">          
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Landlord-Id" HeaderStyle-Height="35px" ItemStyle-Height="35px">                                       
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />                   
                </asp:BoundField>

                <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-Height="35px" ItemStyle-Height="35px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>

                <asp:BoundField DataField="MobileNo" HeaderText="Mobile No." HeaderStyle-Height="35px" ItemStyle-Height="35px">                    
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />                    
                </asp:BoundField>

                <asp:BoundField DataField="Address" HeaderText="Address" HeaderStyle-Height="35px" ItemStyle-Height="35px">                    
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />                    
                </asp:BoundField>

                <asp:BoundField DataField="EmailId" HeaderText="Email-Id" HeaderStyle-Height="35px" ItemStyle-Height="35px">                   
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />                   
                </asp:BoundField>

                <asp:BoundField DataField="Status" HeaderText="Status"  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol">                    
                    <HeaderStyle  HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                    <ItemStyle  HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>                    
                </asp:BoundField>
               
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnapprv" runat="server" Width="90px" Height="30px" CssClass="btn btn-warning" Text='<%#Eval("Status").ToString() == "Disapproved"? "Approve" : "Disapprove" %>' OnClick="btnaprrv_Click" />&nbsp;&nbsp;
                    </ItemTemplate>                   
                    <ItemStyle HorizontalAlign="Center" />                   
                </asp:TemplateField>
            </Columns>

            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Height="40px" HorizontalAlign="Center" VerticalAlign="Middle" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="White" Height="45px"/>
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384"/>
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>       
        <asp:Label ID="lbnodata" runat="server" Text="No Data Found" Font-Size="Large" Font-Bold="true" ForeColor="SlateGray"></asp:Label>        
    </div>
        <br />
        <br />
    </div>
</asp:Content>