<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="THome.aspx.cs" Inherits="PropertyRentalContarct.UHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin:15px; background-color:beige">         
        <div class="col-lg-1"></div>
        <div class="col-lg-5">           
           <h2>Personnel Details </h2><br />
            <table style="width:60%">
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Id :" Font-Bold="true" Font-Size="Large"></asp:Label></td>
                    <td><asp:Label ID="lbtid" runat="server" Text="Label"  Font-Size="Large"></asp:Label></td>                                                                         
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>                           
                </tr>
                <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="Name :" Font-Bold="true" Font-Size="Large"></asp:Label></td>
                    <td><asp:Label ID="lbtname" runat="server" Text="Label"  Font-Size="Large"></asp:Label></td>  
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>  
                </tr>
                <tr>
                    <td><asp:Label ID="Label4" runat="server" Text="Mobile No. :" Font-Bold="true" Font-Size="Large"></asp:Label></td>
                    <td><asp:Label ID="lbmobile" runat="server" Text="Label"  Font-Size="Large"></asp:Label></td>                                                                    
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>                                    
                </tr>
                <tr>
                    <td><asp:Label ID="Label6" runat="server" Text="Address :" Font-Bold="true" Font-Size="Large"></asp:Label></td>
                    <td><asp:Label ID="lbaddress" runat="server" Text="Label"  Font-Size="Large"></asp:Label></td>        
                </tr>
                <tr>
                     <td>&nbsp;</td>
                    <td>&nbsp;</td>   
                </tr>
                <tr>
                    <td><asp:Label ID="Label8" runat="server" Text="Email-Id :" Font-Bold="true" Font-Size="Large"></asp:Label></td>
                    <td><asp:Label ID="lbemail" runat="server" Text="Label"  Font-Size="Large"></asp:Label></td>                                                                          
                </tr>
                <tr>
                    <td>&nbsp;</td>                    
                    <td>&nbsp;</td>              
                </tr>
                <tr>
                    <td><asp:Label ID="Label10" runat="server" Text="Status :" Font-Bold="true" Font-Size="Large"></asp:Label></td>
                    <td><asp:Label ID="lbstatus" runat="server" Text="Label"  Font-Size="Large"></asp:Label></td>  
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>                                             
                </tr>                
            </table>         
        </div>
        <%--<div class="col-lg-1" style="width:90px"></div>--%>
        <div class="col-lg-6">
           <div id="walletDiv" runat="server" visible="false" style="margin:0% 2% 0% 2%;">
           <h2>Cirrus Wallet Details </h2><br />
           <table style="width:100%">
                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="Wallet Name :" Font-Bold="true" Font-Size="Large"></asp:Label></td>
                    <td><asp:Label ID="lbwnm" runat="server" Text="Label"  Font-Size="Large"></asp:Label></td>                                           
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>                                                                                        
                </tr>
                <tr>
                    <td><asp:Label ID="Label7" runat="server" Text="Wallet Account Name :" Font-Bold="true" Font-Size="Large"></asp:Label></td>
                    <td><asp:Label ID="lbwaccnm" runat="server" Text="Label"  Font-Size="Large"></asp:Label></td>   
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>                                                                                        
                </tr>
                <tr>
                     <td><asp:Label ID="Label13" runat="server" Text="Wallet Password :" Font-Bold="true" Font-Size="Large"></asp:Label></td>
                    <td><asp:Label ID="lbwpass" runat="server" Text="Label"  Font-Size="Large"></asp:Label></td>  
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>                                                                                        
                </tr>
                <tr>
                    <td><asp:Label ID="Label11" runat="server" Text="Wallete Address :" Font-Bold="true" Font-Size="Large"></asp:Label></td>
                    <td><asp:Label ID="lbwaddr" runat="server" Text="Label"  Font-Size="Large"></asp:Label></td>                      
                </tr>               
            </table>
            <br />
            <br />
            
            <asp:Button ID="btnChkBal" runat="server" Text="Check Balance" CssClass="btn btn-info" Visible="false" Font-Size="Medium" OnClick="btnChkBal_Click"/>           
            <br /><br />
            <asp:Label ID="lbamount" runat="server" Text="Label" Font-Size="Large" Visible="false" Font-Bold="true"></asp:Label>
            <br /><br />
        </div>
        </div>       
    </div>
</asp:Content>
