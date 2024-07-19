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
    public partial class Register : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        int tid;
        string twaddr;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Login"] = "Default";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string qu = "Select Id from Tenants order by Id desc";
                SqlDataAdapter da = new SqlDataAdapter(qu, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int a = ds.Tables[0].Rows.Count;
                if (a > 0)
                {
                    string id = ds.Tables[0].Rows[0][0].ToString();
                    if (id == "")
                    {
                        tid = 101;
                        txtId.Text = "101";
                    }
                    else
                    {
                        tid = Convert.ToInt32(id);
                        tid++;
                        txtId.Text = tid.ToString();
                    }
                }
                else
                {
                    tid = 101;
                    txtId.Text = "101";
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
@"  ""name"": ""Tenant" + txtId.Text + "\"," + "\n" +
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
                    client = new RestClient("http://localhost:38223/api/Wallet/addresses?WalletName=Tenant" + txtId.Text + "&AccountName=account 0&Segwit=true");
                    request = new RestRequest("http://localhost:38223/api/Wallet/addresses?WalletName=Tenant" + txtId.Text + "&AccountName=account 0&Segwit=true", Method.Get);
                    response = client.Execute(request);
                    res = response.StatusCode.ToString();
                    if (res == "OK")
                    {
                        dynamic array = JsonConvert.DeserializeObject(response.Content);
                        dynamic arr = array.addresses;
                        foreach (var h in arr)
                        {
                            dynamic array2 = h;
                           
                            twaddr = array2.address;
                            break;
                        }

                        con.Open();
                        string qu = "Insert into Tenants values('" + txtId.Text + "','" + txtname.Text + "','" + txtmobno.Text + "','" + txtaddr.Text + "','" + txtemail.Text + "','" + txtpassword.Text + "','Disapproved')";
                        SqlCommand cmd = new SqlCommand(qu, con);
                        cmd.ExecuteNonQuery();


                        qu = "Insert into WalletDetails values('" + txtId.Text + "','Tenant" + txtId.Text + "','account 0','" + txtpassword.Text + "','Tenant','" + twaddr + "')";
                        cmd = new SqlCommand(qu, con);
                        cmd.ExecuteNonQuery();

                        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype", "alert('Tenant registered Successfully!!!')", true);
                        tid++;
                        txtId.Text = tid.ToString();
                        txtname.Text = "";
                        txtaddr.Text = "";
                        txtmobno.Text = "";
                        txtemail.Text = "";
                        txtpassword.Text = "";
                    }
                }
                //txtwnm.Text = "";
                //txtaccnm.Text = "";
                //txtwpass.Text = "";
                //wallteDiv.Visible = false;
            }
        }

        //protected void btnNext_Click(object sender, EventArgs e)
        //{
        //    wallteDiv.Visible = true;
        //}
    }
}
