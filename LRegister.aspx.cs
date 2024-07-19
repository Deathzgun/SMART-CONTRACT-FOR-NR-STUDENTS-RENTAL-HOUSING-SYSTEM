using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using RestSharp;
using Newtonsoft.Json;

namespace PropertyRentalContarct
{
    public partial class LRegister : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        int lid;
        string lwaddr, amnt;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Login"] = "Default";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string qu = "Select Id from Landlords order by Id Desc";
                SqlDataAdapter da = new SqlDataAdapter(qu, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int a = ds.Tables[0].Rows.Count;
                if(a>0)
                {
                    string id = ds.Tables[0].Rows[0][0].ToString();
                    if (id == "")
                    {
                        lid = 1001;
                        txtId.Text = "1001";
                    }
                    else
                    {
                        lid = Convert.ToInt32(id);
                        lid++;
                        txtId.Text = lid.ToString();
                    }
                }
                else
                {
                    lid = 1001;
                    txtId.Text = "1001";
                }
                con.Close();
            }
        }

        protected void btnreg_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {               
                var client = new RestClient("http://localhost:38223/api/Wallet/create");
                RestRequest request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                var body = @"{" + "\n" +
@"  ""name"": ""Landlord" + txtId.Text + "\"," + "\n" +
@"  ""passphrase"": """ + txtname.Text + "\"," + "\n" +
@"  ""password"": """ + txtpassword.Text + "\"," + "\n" +
@"  ""mnemonic"": null" + "\n" +
@"}";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                request.AddJsonBody(body);
                RestResponse response = client.Post(request);
                string res = response.StatusCode.ToString();
                if (res == "OK")
                {
                    client = new RestClient("http://localhost:38223/api/Wallet/addresses?WalletName=Landlord" + txtId.Text + "&AccountName=account 0&Segwit=true");
                    request = new RestRequest("http://localhost:38223/api/Wallet/addresses?WalletName=Landlord" + txtId.Text + "&AccountName=account 0&Segwit=true", Method.Get);
                    response = client.Execute(request);
                    res = response.StatusCode.ToString();
                    if (res == "OK")
                    {
                        dynamic array = JsonConvert.DeserializeObject(response.Content);
                        dynamic arr = array.addresses;
                        foreach (var h in arr)
                        { 
                            dynamic array2 = h;
                            amnt = array2.amountConfirmed;                           
                            lwaddr = array2.address;
                            break;
                        }

                        con.Open();
                        string qu = "Insert into Landlords(Id, Name, MobileNo, Address,  EmailId, Password, Status) values('" + txtId.Text + "','" + txtname.Text + "','" + txtmobno.Text + "','" + txtaddr.Text + "','" + txtemail.Text + "','" + txtpassword.Text + "','Disapproved')";
                        SqlCommand cmd = new SqlCommand(qu, con);
                        cmd.ExecuteNonQuery();

                        qu = "Insert into WalletDetails values('" + txtId.Text + "','Landlord" + txtId.Text + "','account 0','" + txtpassword.Text + "','Landlord','" + lwaddr + "')";
                        cmd = new SqlCommand(qu, con);
                        cmd.ExecuteNonQuery();
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype", "alert('Landlord registered Successfully!!!')", true);
                        con.Close();
                        lid++;
                        txtId.Text = lid.ToString();
                        txtname.Text = "";
                        txtaddr.Text = "";
                        txtmobno.Text = "";
                        txtemail.Text = "";
                        txtpassword.Text = "";
                    }
                }               
            }
        }
    }
}