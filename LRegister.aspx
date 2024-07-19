<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LRegister.aspx.cs" Inherits="PropertyRentalContarct.LRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.12.1/css/all.css" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2><strong>Registration Page</strong></h2>
     </div>
     <div id="regDiv" runat="server" visible="true" align="center" style="margin-left:10%">
        <br />        
        <table width="40%">
            <tr>
                <td align="right"><asp:Label ID="Label1" Font-Size="Medium" runat="server" Text="Id :"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txtId" runat="server" ReadOnly="true" CssClass="form-control" Height="35px" Width="250px" ></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr> 
            <tr>
               <td align="right"><asp:Label ID="Label3" Font-Size="Medium" runat="server" Text="Name :"></asp:Label></td>
               <td align="center"><asp:TextBox ID="txtname" runat="server" Height="35px" Width="250px" CssClass="form-control"></asp:TextBox></td>
               <td align="left"><asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ValidationGroup="check1" runat="server" ErrorMessage="*" ControlToValidate="txtname" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
            </tr> 
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="Label4" Font-Size="Medium" runat="server" Text="Mobile No. :"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txtmobno" runat="server" Height="35px" Width="250px" CssClass="form-control"></asp:TextBox></td>
                <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ValidationGroup="check1" ControlToValidate="txtmobno" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="check1" ErrorMessage="Incorrect Mobile No." ValidationExpression="^0[0-9]{10}$" ControlToValidate="txtmobno" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>

              

                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="Label5" Font-Size="Medium" runat="server" Text="Address :"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txtaddr" runat="server" Height="35px" Width="250px" CssClass="form-control"></asp:TextBox></td>
                <td align="left"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="check1" ErrorMessage="*" ControlToValidate="txtaddr" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
            </tr> 
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="Label6" Font-Size="Medium" runat="server" Text="Email-Id :"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txtemail" runat="server" Height="35px" Width="250px" CssClass="form-control"></asp:TextBox></td>
                <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ValidationGroup="check1" ControlToValidate="txtemail" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="check1" ErrorMessage="Incorrect Email-Id." ControlToValidate="txtemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                </td>
            </tr> 
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="Label2" Font-Size="Medium" runat="server" Text="Password :"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txtpassword" runat="server" Height="35px" Width="250px" CssClass="form-control"></asp:TextBox></td>
                <td align="left"><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="check1" ErrorMessage="*" ControlToValidate="txtpassword" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>  
             <tr>
                <td>&nbsp;</td>
                <td align="center">
                    <asp:Button ID="btnreg" runat="server" Font-Size="Medium" Text="Register" ValidationGroup="check1" CssClass="btn btn-primary" OnClick="btnreg_Click"  />
                    <%--<asp:Button ID="btnNext" runat="server" CssClass="btn btn-primary" Font-Size="Medium" Text="Next" OnClick="btnNext_Click"  />--%>
                </td>
                <td>&nbsp;</td>
            </tr>             
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>  
            <tr>
                <td>&nbsp;</td>
                <td align="center"><asp:LinkButton ID="lbtnBack" runat="server" PostBackUrl="~/LandlordLogin.aspx"><i class="fa fa-sharp fa-solid fa-arrow-left"></i> Back</asp:LinkButton></td>
                <td>&nbsp;</td>
            </tr>  
        </table>       
        <br />
    </div>
   <%-- <div id="wallteDiv" runat="server" visible="false" align="center">
        <h3><strong>Add Wallet Details</strong></h3><br />
        <table width="28%" style="margin-left:-1%">
            <tr>
                <td><asp:Label ID="Label7" Font-Size="Medium" runat="server" Text="Wallet Name :"></asp:Label></td>
                <td><asp:TextBox ID="txtwnm" runat="server" Height="35px" Width="250px" CssClass="form-control"></asp:TextBox></td>
                <td align="left"><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtwnm" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><asp:Label ID="Label8" Font-Size="Medium" runat="server" Text="Account Name :"></asp:Label></td>
                <td><asp:TextBox ID="txtaccnm" runat="server" Height="35px" Width="250px" CssClass="form-control"></asp:TextBox></td>
                <td align="left"><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtaccnm" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><asp:Label ID="Label9" Font-Size="Medium" runat="server" Text="Wallet Address :"></asp:Label></td>
                <td><asp:TextBox ID="txtwaddr" runat="server" Height="35px"  Width="250px" CssClass="form-control"></asp:TextBox></td>
                <td align="left"><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="txtwaddr" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>     
            <tr>
                <td><asp:Label ID="Label10" Font-Size="Medium" runat="server" Text="Wallet Password :"></asp:Label></td>
                <td><asp:TextBox ID="txtwpass" runat="server" Height="35px" TextMode="Password" Width="250px" CssClass="form-control"></asp:TextBox></td>
                <td align="left"><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="txtwpass" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>     
        </table>
        <div style="margin-left:6%">
        </div>
        
        <br /><br />
    </div>--%>
</asp:Content>
