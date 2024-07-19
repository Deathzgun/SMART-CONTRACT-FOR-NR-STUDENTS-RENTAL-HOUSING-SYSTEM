<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LTopUp.aspx.cs" Inherits="PropertyRentalContarct.LTopUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div align="center">
        <h2><strong>Top Up Wallet Account</strong></h2><br />
    </div>  
    <div Id="alerttDiv" runat="server" visible="false" class="alert alert-warning" align="center">        
      <br /><h2><strong>Warning!</strong> Approval from Admin is Pending.</h2><br />      
    </div>     
    <div align="center" style="background-color:beige">
        <br />
        <table style="width:35%; margin-left:6%">
            <tr>
                <td align="right"><asp:Label ID="Label1" runat="server" Text="Landlord-Id :" Font-Size="Large" Font-Bold="true"></asp:Label></td>
                <td align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblid" runat="server" Text="Label"  Font-Size="Medium"></asp:Label></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="Label2" runat="server" Text="Wallet Name :" Font-Size="Large" Font-Bold="true"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txtwnm" runat="server" ReadOnly="true" CssClass="form-control" Width="300px" ></asp:TextBox></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="Label3" runat="server" Text="Wallet Address :" Font-Size="Large" Font-Bold="true"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txtwaddr" runat="server" ReadOnly="true" CssClass="form-control" Width="300px"></asp:TextBox></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="Label4" runat="server" Text="Amount :" Font-Size="Large" Font-Bold="true"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txtamnt" runat="server" CssClass="form-control" MaxLength="5" Width="300px"></asp:TextBox></td>
                <td>&nbsp;</td>
            </tr>             
            <tr>
                <td>&nbsp;</td>
                <td align="left"></td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <div align="center">
            <asp:Button ID="btnsend" runat="server" CssClass="btn btn-primary" Text="TopUp Wallet" onclick="btnsend_Click"/>
        </div>
        <br /><br />
    </div>
</asp:Content>
