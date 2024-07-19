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
    public partial class TopUpRequest : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GvBind();
            }
        }

        protected void GvBind()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "Select * from TopUpRequests";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                    lbnodata.Visible = false;
                }
                else
                {
                    lbnodata.Visible = true;
                    GridView1.Visible = false;
                }
            }
        }

        protected void btnTopUp_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string trpId = row.Cells[0].Text;
            string destWallet = row.Cells[3].Text;
            string amnt = row.Cells[4].Text;
            

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
            @"      ""amount"": """ + amnt + "\"," + "\n" +
            @"      ""destinationAddress"": """ + destWallet + "\"," + "\n" +
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
                        string q = "Update TopUpRequests set Status = 'Done' and DateTime='" + DateTime.Now + "' where TprId='" + trpId + "'";
                        SqlCommand cmd = new SqlCommand(q, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgtype", "alert('Wallet has been TopUp Successfully!!!')", true);
                    GvBind();
                }
            }
        }
    }
}