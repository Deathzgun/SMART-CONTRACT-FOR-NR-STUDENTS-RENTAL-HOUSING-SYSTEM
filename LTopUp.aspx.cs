using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using RestSharp;
using Newtonsoft.Json;

namespace PropertyRentalContarct
{
    public partial class LTopUp : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        string lid;

        protected void Page_Load(object sender, EventArgs e)
        {
            lid = Session["Lid"].ToString();
            using(SqlConnection con = new SqlConnection(cs))
            {
                string qu = "Select status from Landlords where Id='" + lid + "'";
                SqlDataAdapter da = new SqlDataAdapter(qu, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblid.Text = lid;
                    if (ds.Tables[0].Rows[0][0].ToString() == "Approved")
                    {
                        string q = "Select WalletName, WalletAddr from WalletDetails where LidTid = '" + lid + "'";
                        da = new SqlDataAdapter(q, con);
                        ds = new DataSet();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {                           
                            txtwnm.Text = ds.Tables[0].Rows[0][0].ToString();
                            txtwaddr.Text = ds.Tables[0].Rows[0][1].ToString();
                        }
                    }
                    else
                    {
                        alerttDiv.Visible = true;
                        btnsend.Enabled = false;
                    }
                }               
            }            
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://localhost:38223/api/Wallet/build-transaction");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            var body = @"{" + "\n" +
            @"  ""password"": ""password""," + "\n" +
            @"  ""walletName"": ""cirrusdev""," + "\n" +
            @"  ""feeAmount"": ""0.01""," + "\n" +
            @"  ""segwitChangeAddress"": true," + "\n" +
            @"  ""accountName"": ""account 0""," + "\n" +
            @"  ""outpoints"":null," + "\n" +
            @"  ""recipients"": [" + "\n" +
            @"    {" + "\n" +
            @"      ""amount"": """ + txtamnt.Text + "\"," + "\n" +
            @"      ""destinationAddress"": """ + txtwaddr.Text + "\"," + "\n" +
            @"      ""destinationScript"": ""cupid""," + "\n" +
            @"      ""subtractFeeFromAmount"": true" + "\n" +
            @"    }" + "\n" +
            @"  ]," + "\n" +
            @"  ""shuffleOutputs"": false" + "\n" +
            @"}";

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            request.AddJsonBody(body);
            RestResponse response = client.Post(request);
            string res = response.StatusCode.ToString();
            if (res.Contains("OK"))
            {
                //Get Transaction-ID of Successful Transaction             
                dynamic array = JsonConvert.DeserializeObject(response.Content);

                string hexcode = array.hex;

                System.Threading.Thread.Sleep(5000);

                client = new RestClient("http://localhost:38223/api/Wallet/send-transaction");
                request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Content-Type", "application/json");
                body = @"{" + "\n" +
  @"  ""hex"": """ + hexcode + "\"" + "\n" +
  @"}";

                request.AddParameter("application/json", body, ParameterType.RequestBody);
                request.AddJsonBody(body);
                response = client.Post(request);
                res = response.StatusCode.ToString();
                if (res.Contains("OK"))
                {
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        con.Open();
                        string qu = "Insert into TopUpRequests values('" + lblid.Text + "','" + txtwnm.Text + "','" + txtwaddr.Text + "','" + txtamnt.Text + "','Landlord','Done','" + DateTime.Now + "')";
                        SqlCommand cmd = new SqlCommand(qu, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgtype", "alert('Wallet has been TopUp Successfully!!!')", true);
                }
            }
        }
    }
}