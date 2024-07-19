<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ContractDetails.aspx.cs" Inherits="PropertyRentalContarct.ContractDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Gridview th, .Gridview td{
            text-align:center;
            vertical-align:middle;
        }   
        .head{
             text-align:center;
            vertical-align:middle;
        }
        
        .hiddencol
        {
            display:none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2><strong>Contract Details</strong></h2>
    </div>
    <div align="center" style="height:500px; overflow-y:scroll;background-color:beige">
        <br />
        <br />
        <asp:GridView ID="GridView1" CssClass=".Gridview" runat="server" CellPadding="4" Width="96%" AutoGenerateColumns="False" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">          
            <Columns>                
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnVContract" runat="server" Text="Contract Details"  Visible='<%# Eval("CntrStat").ToString() == "Terminated" ? false : true %>' CssClass="btn btn-primary" OnClick="btnVContract_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Pid" HeaderText="PId" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" >
                    <HeaderStyle CssClass="head" Width="50px"></HeaderStyle>
                    <ItemStyle CssClass="head"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Lid" HeaderText="LId" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" >               
                    <HeaderStyle CssClass="head" Width="50px"></HeaderStyle>
                    <ItemStyle CssClass="head"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Lname" HeaderText="Landlord Name" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" >               
                    <HeaderStyle CssClass="head"></HeaderStyle>    
                    <ItemStyle CssClass="head"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Lwname" HeaderText="Landlord Wallet" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" >               
                    <HeaderStyle CssClass="head"></HeaderStyle>
                    <ItemStyle CssClass="head"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Lwaddr" HeaderText="Landlord Wallet Address" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" >               
                    <HeaderStyle CssClass="head"></HeaderStyle>
                    <ItemStyle CssClass="head"></ItemStyle> 
                </asp:BoundField>  
                <asp:BoundField DataField="Deposite" HeaderText="Deposite" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" >               
                    <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                    <ItemStyle CssClass="hiddencol"></ItemStyle> 
                </asp:BoundField>  
                <asp:BoundField DataField="CntrAddr" HeaderText="Contract Address" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" >                               
                    <HeaderStyle CssClass="head"></HeaderStyle>
                    <ItemStyle CssClass="head"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="CntrStat" HeaderText="Contract Status" HeaderStyle-CssClass="head" ItemStyle-CssClass="head" >                               
                    <HeaderStyle CssClass="head"></HeaderStyle>
                    <ItemStyle CssClass="head"></ItemStyle>
                </asp:BoundField>
                
                <asp:TemplateField>
                    <ItemTemplate>                                                                         
                        <asp:LinkButton ID="lbtnConfirm" class="btn btn-success" Visible='<%# Eval("CntrStat").ToString() == "Created" ? true : false %>'  OnCommand="lbtnConfirm_Command"  OnClientClick="return confirm('Are you sure to want to Confirm and Pay deposite amount for Contract');" CommandArgument="Confirm&Pay" runat="server">Confirm And Pay Deposite</asp:LinkButton>
                        <asp:Label ID="lbcntstat" runat="server" Visible='<%# Eval("CntrStat").ToString() == "Terminated" ? true : false %>' Text="Terminated" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Height="40px" VerticalAlign="Middle" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="White" height="55px"/>
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384"/>
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="lbnodata" runat="server" Text="No Data Found" Font-Size="Large" Font-Bold="true" ForeColor="SlateGray"></asp:Label>
        <br />
        <br />
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
            <table style="width:92%">
                <tr>
                    <td><asp:Label ID="Label13" runat="server" Text="LId "></asp:Label> </td>
                    <td><asp:Label ID="lbllid" runat="server" Text="Label"></asp:Label></td>                 
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>                
                </tr>
                <tr>
                    <td><asp:Label ID="Label16" runat="server" Text="Landlord Wallet Address "></asp:Label> </td>
                    <td><asp:Label ID="lbllwadd" runat="server" Text="Label"></asp:Label></td>                    
                </tr>                
            </table> 
            <table style="width:117%"> 
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
                <tr id="cdt" runat="server" visible="false"> 
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
