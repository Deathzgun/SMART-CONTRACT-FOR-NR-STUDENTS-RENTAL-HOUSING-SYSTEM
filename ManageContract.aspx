<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master"  AutoEventWireup="true" CodeBehind="ManageContract.aspx.cs" Inherits="PropertyRentalContarct.ManageContract" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Gridview th, .Gridview td{
            text-align:center;
            vertical-align:middle;
        }        
        .head{
            display:none
        }
        
    </style>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2><strong>Manage Property Contract</strong></h2><br />
    </div>
    <div align="center" style="background-color:beige; height:350px; overflow-y:scroll">
        <br />
        <asp:GridView ID="GridView1" CssClass="Gridview" runat="server" Width="95%" CellPadding="4" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False">           
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnPrpDet" runat="server" Text="Property Details" CssClass="btn btn-info" OnClick="btnPrpDet_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="PId" HeaderText="PId" />
                <asp:BoundField DataField="TId" HeaderText="TId" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Mobile No" HeaderText="Mobile No" />               
                <asp:BoundField DataField="Rent" HeaderText="Rent" />
                <asp:BoundField DataField="Location" HeaderText="Location" />
                <asp:BoundField DataField="Wallet" HeaderText="Tenant Wallet" />
                <asp:BoundField DataField="Wallet-Address" HeaderText="Tenant Wallet-Address" />
                <asp:BoundField DataField="ContractStatus" HeaderText="ContractStatus" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" />
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnCContract" runat="server" Text="Create Contract" Visible='<%# Eval("ContractStatus").ToString() == "NA" ? true : false %>'  CssClass="btn btn-success" OnClick="btnCContract_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnVContract" runat="server" Text="View Contract"  Visible='<%# Eval("ContractStatus").ToString() == "NA" ? false : true %>' CssClass="btn btn-primary" OnClick="btnVContract_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnTContract" runat="server" Text="Terminate Contract" Visible='<%# Eval("ContractStatus").ToString() == "Started" ? true : false %>' CssClass="btn btn-warning" OnClick="btnTContract_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Height="40px" Font-Size="Medium" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="White" Height="45px"/>
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:Label ID="lbnodata" runat="server" Text="No Data available" Font-Size="Large" Font-Bold="true" ForeColor="SlateGray"></asp:Label>
        <br />
        <br />
    </div>

    <div class="modal fade" id="modal" role="dialog">
    <div class="modal-dialog " >
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h3 class="modal-title">Property Details</h3>
        </div>
        <div class="modal-body">
            <table style="width:55%">
                <tr>
                    <td><asp:Label ID="Label4" runat="server" Text="PId :"></asp:Label> </td>
                    <td><asp:Label ID="lbpid" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label5" runat="server" Text="House Type :"></asp:Label></td>
                    <td><asp:Label ID="lbaprt" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Total Area :"></asp:Label></td>
                    <td><asp:Label ID="lbarea" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="Location :"></asp:Label></td>
                    <td><asp:Label ID="lbloc" runat="server" Text="Label"></asp:Label></td>
                </tr>
                 <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="Rent :"></asp:Label></td>
                    <td><asp:Label ID="lbrent" runat="server" Text="Label"></asp:Label></td>
                </tr>
            </table>                             
        </div>
        <div class="modal-footer text-center" >
        </div>
      </div>
      
    </div>
    </div>
    
    <!-- Modal to Create Contract with additional details-->

    <div class="modal fade" id="Createmodal" role="dialog">
    <div class="modal-dialog " >
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h3 class="modal-title">Create Contract</h3>
        </div>
        <div class="modal-body">
            <table style="width:85%">
                <tr>
                    <td><asp:Label ID="Label6" runat="server" Text="PId :"></asp:Label> </td>
                    <td><asp:Label ID="lbp" runat="server" Text="Label"></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label11" runat="server" Text="TId :"></asp:Label> </td>
                    <td><asp:Label ID="lbt" runat="server" Text="Label"></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label12" runat="server" Text="Location :"></asp:Label></td>
                    <td><asp:Label ID="lblocatn" runat="server" Text="Label"></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label14" runat="server" Text="Rent :"></asp:Label></td>
                    <td><asp:Label ID="lbrnt" runat="server" Text="Label"></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td><asp:Label ID="Label10" runat="server" Text="Tenant Wallet-Address :"></asp:Label></td>
                    <td><asp:Label ID="lbtwaddr" runat="server" Text="Label"></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr> 
                <tr>
                    <td><asp:Label ID="Label9" runat="server" Text="Contract Address :"></asp:Label></td>
                    <td><asp:Label ID="lbcontrAddr" runat="server" Text="Label"></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label8" runat="server" Text="Duration :"></asp:Label></td>
                    <td><asp:TextBox ID="txtdur" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>               
                <tr>
                    <td><asp:Label ID="Label7" runat="server" Text="Deposite :"></asp:Label></td>
                    <td><asp:TextBox ID="txtdpst" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>                             
        </div>
        <div class="modal-footer" style="text-align:center">
            <asp:Button ID="btnCreate" runat="server" Text="Create" CssClass="btn btn-success" OnClick="btnCreate_Click"/>
        </div>
      </div>
      
    </div>
  </div>
  
    <!-- View Contract Modal -->
    <div class="modal fade" id="Viewmodal" role="dialog">
    <div class="modal-dialog " >
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h3 class="modal-title">Create Contract</h3>
        </div>
        <div class="modal-body">
            <table style="width:96%">
                <tr>
                    <td><asp:Label ID="Label13" runat="server" Text="TId "></asp:Label> </td>
                    <td><asp:Label ID="lbltid" runat="server" Text="Label"></asp:Label></td>                 
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>                
                </tr>
                <tr>
                    <td><asp:Label ID="Label16" runat="server" Text="Tenant Wallet Address "></asp:Label> </td>
                    <td><asp:Label ID="lbltwadd" runat="server" Text="Label"></asp:Label></td>                    
                </tr>                
            </table> 
            <table style="width:110%"> 
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbldet1" runat="server" Text="Label"></asp:Label></td>                               
                    <td><asp:Label ID="lbldetail1" runat="server" Text="Label"></asp:Label></td>                               
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbldet2" runat="server" Text="Label"></asp:Label></td>                               
                    <td><asp:Label ID="lbldetail2" runat="server" Text="Label"></asp:Label></td>                               
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbldet3" runat="server" Text="Label"></asp:Label></td>                               
                    <td><asp:Label ID="lbldetail3" runat="server" Text="Label"></asp:Label></td>                               
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbldet5" runat="server" Text="Label"></asp:Label></td>                               
                    <td><asp:Label ID="lbldetail5" runat="server" Text="Label"></asp:Label></td>                               
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td><asp:Label ID="lbldet6" runat="server" Text="Label"></asp:Label></td>                               
                    <td><asp:Label ID="lbldetail6" runat="server" Text="Label"></asp:Label></td>                               
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbldet7" runat="server" Text="Label"></asp:Label></td>                               
                    <td><asp:Label ID="lbldetail7" runat="server" Text="Label"></asp:Label></td>                               
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>                
                 <tr>
                    <td><asp:Label ID="Label15" runat="server" Text="Contract Address"></asp:Label></td>                               
                    <td><asp:Label ID="lbcnaddress" runat="server" Text="Label"></asp:Label></td>                               
                </tr>  
                 <tr>
                    <td><asp:Label ID="lbl" runat="server" Text="Label" Visible="false"></asp:Label></td>                               
                    <td><asp:Label ID="lbl1" runat="server" Text="Label" Visible="false"></asp:Label></td>                               
                </tr>
                <tr>
                    <td><asp:Label ID="lbl4" runat="server" Text="Label" Visible="false"></asp:Label></td>                               
                    <td><asp:Label ID="lbln4" runat="server" Text="Label" Visible="false"></asp:Label></td>                               
                </tr>
            </table>
        </div>
        <div class="modal-footer" style="text-align:center">
       </div>
      </div>
      
    </div>
  </div>
  
</asp:Content>
