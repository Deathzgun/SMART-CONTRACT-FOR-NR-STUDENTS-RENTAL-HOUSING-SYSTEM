<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PayRent.aspx.cs" Inherits="PropertyRentalContarct.PayRent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2><strong>Pay Rent</strong></h2><br />
    </div>
    <div align="center" style="background-color:beige">
        <br />
        <table style="width:45%;margin-left:3%">
            <tr>
                <td align="right"><asp:Label ID="Label1" runat="server" Text="Tenant-Id :" Font-Bold="true" Font-Size="Large"></asp:Label></td>
                <td align="center"><asp:Label ID="lbtid" runat="server" Text="Label" Font-Size="Medium"></asp:Label></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="Label5" runat="server" Text="Tenant Wallet :"  Font-Bold="true" Font-Size="Large"></asp:Label></td>
                <td align="center"><asp:Label ID="lbtwnm" runat="server" Text="Label" Font-Size="Medium"></asp:Label></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="Label7" runat="server" Text="Tenant Wallet Address :"  Font-Bold="true" Font-Size="Large"></asp:Label></td>
                <td align="center"><asp:Label ID="lbtwaddr" runat="server" Text="Label" Font-Size="Medium"></asp:Label></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="Label9" runat="server" Text="Tenant Account Name :"  Font-Bold="true" Font-Size="Large"></asp:Label></td>
                <td align="center"><asp:Label ID="lbtaccname" runat="server" Text="Label" Font-Size="Medium"></asp:Label></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr id="passTr" runat="server" visible="false">
                <td align="right"><asp:Label ID="Label6" runat="server" Text="Tenant Wallet Password :"  Font-Bold="true" Font-Size="Large"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txttwpass" runat="server" Width="350px" ReadOnly="true" CssClass="form-control text-center"></asp:TextBox></td>
                <td>&nbsp;</td>
            </tr>                                
            <tr>
                <td align="right"><asp:Label ID="Label3" runat="server" Text="Landlord Wallet Address :"  Font-Bold="true" Font-Size="Large"></asp:Label></td>
                <td align="center">
                    <asp:Label ID="lblwaddr" runat="server" Text="Label" Font-Size="Medium"></asp:Label>
                    <%--<asp:TextBox ID="" runat="server" CssClass="form-control text-center" Width="350px"></asp:TextBox>--%>
                </td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="Label4" runat="server" Text="Contract Address :"  Font-Bold="true" Font-Size="Large"></asp:Label></td>
                <td align="center">
                    <asp:Label ID="lbcaddr" runat="server" Text="Label" Font-Size="Medium"></asp:Label>
                    <%--<asp:TextBox ID="txtcaddr" runat="server" CssClass="form-control text-center" Width="350px"></asp:TextBox>--%>
                </td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="Label2" runat="server" Text="Amount :"  Font-Bold="true" Font-Size="Large"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txtamnt" runat="server" CssClass="form-control text-center" Width="350px"></asp:TextBox></td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>           
        </table>
        <div align="center">
            <asp:Button ID="btnpay" runat="server" Text="Pay" CssClass="btn btn-success" Font-Size="Medium" ValidationGroup="check" OnClick="btnpay_Click"/>&nbsp;&nbsp;
            &nbsp;&nbsp;<asp:Button ID="btncancel" runat="server" Text="Cancel" Font-Size="Medium"  CssClass="btn btn-danger" OnClick="btncancel_Click"/>

        </div>
        <br />
        <br />

    </div>
</asp:Content>
