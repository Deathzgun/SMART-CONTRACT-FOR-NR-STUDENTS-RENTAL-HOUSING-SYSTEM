<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TRating.aspx.cs" Inherits="PropertyRentalContarct.TRating" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2><strong>Feedback about Landlord</strong></h2><br />
    </div>
    <div align="center" style="background-color:beige">
        <br />
        <table style="width:25%">
            <tr>
                <td align="left"><asp:Label ID="Label1" runat="server" Text="TId :" Font-Size="Medium" Font-Bold="true"></asp:Label></td>
                <td><asp:Label ID="lbtid" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="left">&nbsp;<asp:Label ID="Label3" runat="server" Text="LId :"  Font-Size="Medium" Font-Bold="true"></asp:Label></td>
                <td><asp:DropDownList ID="ddllid" runat="server" CssClass="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="left"><asp:Label ID="Label2" runat="server" Text="Feedback :"  Font-Size="Medium" Font-Bold="true"></asp:Label></td>
                <td><asp:TextBox ID="txtfdbck" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div align="center">
            <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnsubmit_Click"/>
        </div>
    
    <br />
    <br />
        </div>
</asp:Content>
