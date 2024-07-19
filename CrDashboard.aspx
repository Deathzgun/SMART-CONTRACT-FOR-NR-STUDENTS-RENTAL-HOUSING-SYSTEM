<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CrDashboard.aspx.cs" Inherits="PropertyRentalContarct.CrDashboard" %>

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
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.12.1/css/all.css" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <link href="http://netdna.bootstrapcdn.com/bootstrap/3.1.0/css/bootstrap.min.css" rel="stylesheet" />

      
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
         <h2><strong>Cirrus Dashboard</strong></h2><br /> 
    </div>
<div align="center" style="background-color:beige">    
    <div style="margin-top:-10px"> 
        <br />
        <table>
            <tr>
                <td><h4>The Cirrus Core Wallet allows you to send, receive and interact with Smart Contracts. </h4> </td>
                <td>&nbsp;<asp:LinkButton ID="lbtndownload" runat="server" CssClass="btn btn-primary" OnClick="lbtndownload_Click">Download Cirrus Core  <i class="fa fa-solid fa-download"></i></asp:LinkButton></td>
            </tr>
        </table>                              
        <br />                  
    </div>
    <div style="margin-top:-10px">
        <button id="btndetails" type="button" class="btn btn-info" data-toggle="collapse" data-target="#demo" style="width:185px">Wallet Details</button>    
        <div id="demo" class="collapse" style="overflow-y:scroll; height:250px"> 
            <br />
            <asp:GridView ID="GridView1" runat="server"  Width="90%" AutoGenerateColumns="false" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="horizontal">           
                <Columns>
                    <asp:BoundField DataField="LidTid" HeaderText="Landlord/Tenant ID" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" />
                    <asp:BoundField DataField="WalletName" HeaderText="Wallet Name" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" />               
                    <asp:BoundField DataField="WalletAddr" HeaderText="Wallet Address" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" />               
                    <asp:BoundField DataField="AccName" HeaderText="Account Name" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" />               
                    <asp:BoundField DataField="Type" HeaderText="User" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" />               
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
            <br /><br />                  
        </div>
        <br /><br />   
    </div>
    </div>
     
</asp:Content>
