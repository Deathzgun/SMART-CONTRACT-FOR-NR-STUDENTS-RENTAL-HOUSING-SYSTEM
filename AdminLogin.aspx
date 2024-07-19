<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="PropertyRentalContarct.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <div align="center" style="margin-top:-20px">
        <asp:Image ID="Bnkbanner" runat="server" ImageUrl="~/Images/cirrus-admin1.jpg" style="width:100%;height:350px" />
    </div>--%>

    <div align="center" style="margin:10% 5% 0% 0%;width:35%;height:350px; background-color:white">
        <br /><h2><strong>Admin Login </strong></h2>    
        <br /><br />
        <table style="width:60%; margin-left:11%">                  
            <tr>
                <td align="right"><asp:Label ID="Label1" Font-Size="Medium" runat="server" Text="Id :"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txtId" runat="server"  Width="200px"  CssClass="form-control"></asp:TextBox></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="Label2" Font-Size="Medium" runat="server" Text="Password :"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txtpassword" runat="server"  Width="200px" TextMode="Password" CssClass="form-control"></asp:TextBox></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td align="left"><asp:Button ID="btnlogin" runat="server" Font-Size="Medium" Text="Login" CssClass="btn btn-primary" OnClick="btnlogin_Click" /></td>                
            </tr>
        </table>
    </div>
   
</asp:Content>
