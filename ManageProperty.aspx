<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageProperty.aspx.cs" Inherits="PropertyRentalContarct.ManageProperty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.12.1/css/all.css" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    
     <style>
        .navA1
        {
            border-radius:25px;
        }   
        .hiddencol{
            display:none;
        }
        .modal-dialog
        {
            margin-top:100px;
        }        
        h1{
            text-align:center;
        }
        .head{
            text-align:center;
            vertical-align:middle;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2><strong>Manage Property Details</strong></h2>
    </div>
    <div align="center" style="background-color:beige">
        <div>
        <br />
        <asp:LinkButton ID="lbtnadd" runat="server" class="btn btn-primary" CausesValidation="false" Font-Size="Large" OnClick="lbtnadd_Click"><i class="fa fa-solid fa-plus" style="color:white; font-size:medium; font-weight:bold"></i>  Add Property Details</asp:LinkButton>
        <asp:Panel ID="PNewpr" runat="server" Visible="false">
        <br />
        <br />
        <table width="30%">
            <tr>
                <td align="right"><asp:Label ID="lbpid" runat="server" Text="Id : " Font-Size="Medium"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txtpid" runat="server" ReadOnly="true" Width="200px" CssClass="form-control"></asp:TextBox></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="lbloc" runat="server" Text="Location : " Font-Size="Medium"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txtloc" runat="server"  Width="200px" CssClass="form-control"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtloc" ForeColor="Red">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="lbaprtp" runat="server" Text="House Type : " Font-Size="Medium"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txtaprtp" runat="server"  Width="200px" CssClass="form-control"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtaprtp" ForeColor="Red">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="auto-style1"><asp:Label ID="lbtotar" runat="server" Text="Total Area(in Sqft.) : " Font-Size="Medium"></asp:Label></td>
                <td align="center" class="auto-style1"><asp:TextBox ID="txttotar" runat="server" Width="200px" CssClass="form-control"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txttotar" ForeColor="Red">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="right"><asp:Label ID="lbrent" runat="server" Text="Rent : " Font-Size="Medium"></asp:Label></td>
                <td align="center"><asp:TextBox ID="txtrent" runat="server" Width="200px" CssClass="form-control"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtrent" ForeColor="Red">*</asp:RequiredFieldValidator></td>
            </tr>   
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
           
            <tr>
                <td align="right">
                      </td>
                <td align="left" style="margin-left:2px">
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
            <div id="btnsDiv" runat="server" visible="false">
                <asp:Button ID="btnadd" runat="server" Text="Add" Font-Size="Medium" Height="40px" Width="93px" OnClick="btnadd_Click" CssClass="btn btn-success"/>
                <asp:Button ID="btnupdate" runat="server" Text="Update" Font-Size="Medium" Height="40px" Width="93px" visible="false" CssClass="btn btn-primary" OnClick="btnupdate_Click" />&nbsp;
                <asp:Button ID="btncancel" runat="server" Text="Cancel" Font-Size="Medium" Height="40px" CausesValidation="false" Width="93px" CssClass="btn btn-danger" OnClick="btncancel_Click"  />&nbsp;
            </div>
        </asp:Panel>
        <br />
        <br />                
    </div>
    <div id="gridDiv" runat="server" align="center" style="overflow-y:scroll; height:325px">
        <br />
        <asp:GridView ID="GridView1" runat="server" Width="80%" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
            <Columns>
                <asp:BoundField DataField="Pid" HeaderText="Id" HeaderStyle-CssClass="head" ItemStyle-CssClass="head"></asp:BoundField>
                <asp:BoundField DataField="Lname" HeaderText="Landlord Name" HeaderStyle-CssClass="head" ItemStyle-CssClass="head"></asp:BoundField>
                <asp:BoundField DataField="ApartmentType" HeaderText="House Type" HeaderStyle-CssClass="head" ItemStyle-CssClass="head"></asp:BoundField>
                <asp:BoundField DataField="TotalArea" HeaderText="Total Area(in Sqft.)" HeaderStyle-CssClass="head" ItemStyle-CssClass="head"></asp:BoundField>
                <asp:BoundField DataField="Location" HeaderText="Location" HeaderStyle-CssClass="head" ItemStyle-CssClass="head"></asp:BoundField>

                <asp:BoundField DataField="Rent" HeaderText="Rent(per Month)" HeaderStyle-CssClass="head" ItemStyle-CssClass="head"></asp:BoundField>
              
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnview" runat="server" Font-Size="Medium" OnClientClick="return SelectedRow2(this)"  data-toggle="modal"><i class="fa fa-solid fa-eye" style="font-size:large"></i></asp:LinkButton>
                    </ItemTemplate>                    
                    <ItemStyle Width="50px" CssClass="head"/>
                </asp:TemplateField>
                
                <asp:TemplateField>                    
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnedit" runat="server" Font-Size="Medium" OnClick="lbtnedit_Click"><i class="fa fa-solid fa-pencil" style="font-size:large"></i></asp:LinkButton>
                    </ItemTemplate>                    
                    <ItemStyle Width="50px" CssClass="head"/>
                </asp:TemplateField>
                
                <asp:TemplateField>                    
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtndelete" runat="server" Font-Size="Medium" OnClick="lbtndelete_Click"><i class="fa fa-solid fa-trash" style="color:#507CD1; font-size:large"></i></asp:LinkButton>&nbsp;&nbsp;
                    </ItemTemplate>
                    <ItemStyle Width="50px" CssClass="head" />
                </asp:TemplateField>               
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Height="40px"/>
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="White" Height="45px"/>
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
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" style="color:red" data-dismiss="modal">&times;</button>
                <h3 class="modal-title">Property Details</h3>
            </div>
            <div class="modal-body">
              <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label12" runat="server" Text="Id : "></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lbid" runat="server" Text="Label"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label15" runat="server" Text="Landlord Name : "></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lblname" runat="server" Text="Label"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label14" runat="server" Text="Apertment Type : "></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lbaprtt" runat="server" Text="Label"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label13" runat="server" Text="Total Sq.ft : "></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lbarea" runat="server" Text="Label"></asp:Label></asp:TableCell>
                </asp:TableRow>                
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label16" runat="server" Text="Location : "></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lblcn" runat="server" Text="Label"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label17" runat="server" Text="Rent : "></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lbrnt" runat="server" Text="Label"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label18" runat="server" Text="Duration : "></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lbdurr" runat="server" Text="Label"></asp:Label></asp:TableCell>
                </asp:TableRow>                
            </asp:Table>
           
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-success waves-effect m-r-20 " 
              Width="60px" Height="32px" Text ="OK" Font-Size="medium" Font-Bold="true" data-dismiss="modal">Ok</button>
            </div>
          </div>
        </div>
    </div>
   

     <script>
        function SelectedRow2(lnk)
        {
            var row = lnk.parentNode.parentNode;
             
            var Pid = row.cells[0].innerText;
            var Lndname = row.cells[1].innerText;
            var aprtype = row.cells[2].innerText;
            var area = row.cells[3].innerText;
            var location = row.cells[4].innerText;
            var rent = row.cells[5].innerText;
            var duration = row.cells[6].innerText;
            
            document.getElementById("<%=lbid.ClientID%>").innerText = Pid;
            document.getElementById("<%=lblname.ClientID%>").innerText = Lndname;
            document.getElementById("<%=lbaprtt.ClientID%>").innerText = aprtype;
            document.getElementById("<%=lbarea.ClientID%>").innerText = area;
            document.getElementById("<%=lblcn.ClientID%>").innerText = location;
            document.getElementById("<%=lbrnt.ClientID%>").innerText = rent;
            document.getElementById("<%=lbdurr.ClientID%>").innerText = duration;
            
            $("#myModal").modal('show');

            return false;           
        }

     </script>
</asp:Content>
