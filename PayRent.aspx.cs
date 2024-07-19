using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace PropertyRentalContarct
{
    public partial class PayRent : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        string tid;

        protected void Page_Load(object sender, EventArgs e)
        {
            tid = Session["Tid"].ToString();
            if (!IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string q = "Select WalletPass, WalletAddr, WalletName, AccName from WalletDetails where LidTid = '" + tid + "'";
                    SqlDataAdapter da = new SqlDataAdapter(q, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if(ds.Tables[0].Rows.Count > 0)
                    {
                        lbtid.Text = tid;
                        txttwpass.Text = ds.Tables[0].Rows[0][0].ToString();
                        txttwpass.Attributes["type"] = "password";
                        lbtwaddr.Text = ds.Tables[0].Rows[0][1].ToString();
                        lbtwnm.Text = ds.Tables[0].Rows[0][2].ToString();
                        lbtaccname.Text = ds.Tables[0].Rows[0][3].ToString();
                    }

                    q = "Select Lid,ContractAddress,Rent from PropertyDetails where Interest='Selected' and Tid = '" + tid + "'";
                    da = new SqlDataAdapter(q, con);
                    ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string lid = ds.Tables[0].Rows[0][0].ToString();
                        lbcaddr.Text = ds.Tables[0].Rows[0][1].ToString();
                        txtamnt.Text = ds.Tables[0].Rows[0][2].ToString();
                       
                        string qu = "Select  WalletAddr from WalletDetails where LidTid = '" + lid + "'";
                        SqlDataAdapter sda = new SqlDataAdapter(qu, con);
                        DataSet dss = new DataSet();
                        sda.Fill(dss);
                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            lblwaddr.Text = dss.Tables[0].Rows[0][0].ToString();
                        }
                    }
                    else
                    {
                        lbcaddr.Text = "NA";
                        lblwaddr.Text = "NA";
                        btnpay.Enabled = false;
                    }
                }
            }
        }

        protected void btnpay_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://localhost:38223/api/SmartContracts/build-and-send-call");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");

            var body = @"{" + "\n" +
@"  ""amount"":""" + txtamnt.Text + "\"," + "\n" +
@"  ""contractAddress"": """ + lbcaddr.Text + "\"," + "\n" +
@"  ""methodName"": ""Pay""," + "\n" +
@"  ""password"": """ + txttwpass.Text + "\"," + "\n" +
@"  ""sender"": """ + lbtwaddr.Text + "\"," + "\n" +
@"  ""walletName"":""" + lbtwnm.Text + "\"," + "\n" +
@"  ""accountName"":""" + lbtaccname.Text + "\"," + "\n" +
@"  ""outpoints"": null," + "\n" +
@"  ""feeAmount"": ""0.01""," + "\n" +
@"  ""gasPrice"": 100," + "\n" +
@"  ""gasLimit"": 250000," + "\n" +
@"  ""recipients"":[" + "\n" +
@"    {" + "\n" +
@"      ""amount"": """ + txtamnt.Text + "\"," + "\n" +
@"      ""destinationAddress"": """ + lblwaddr.Text + "\"," + "\n" +
@"      ""destinationScript"": ""Rent Payment""," + "\n" +
@"      ""subtractFeeFromAmount"": false" + "\n" +
@"    }" + "\n" +
@"  ]," + "\n" +
@"  ""parameters"": null," + "\n" +
@"  ""isInteropFeeForMultisig"": false" + "\n" +
@"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            //request.AddParameter("application/octet-stream", file, ParameterType.RequestBody);
            request.AddJsonBody(body);
            RestResponse response = client.Post(request);
            string res = response.StatusCode.ToString();
            // Lbstatus.Text = res;
            if (res.Contains("OK"))
            {
                //Get Transaction-ID of Successful Transaction             
                dynamic array = JsonConvert.DeserializeObject(response.Content);

                string transId = array.transactionId;

            again:
                System.Threading.Thread.Sleep(5000);

                //Pass Transaction-ID to next API              
                client = new RestClient("http://localhost:38223/api/SmartContracts/receipt?txHash=" + transId + "");
                request = new RestRequest("http://localhost:38223/api/SmartContracts/receipt?txHash=" + transId + "", Method.Get);
                //request.AddParameter("application/octet-stream", file, ParameterType.RequestBody);
                response = client.Execute(request);
                res = response.StatusCode.ToString();
                // Lbstatus.Text = res;
                if (res.Contains("BadRequest"))
                {
                    goto again;
                }
                else if (res.Contains("OK"))
                {                   
                    array = JsonConvert.DeserializeObject(response.Content);

                    string returnval = array.returnValue;
                    // Page.ClientScript.RegisterStartupScript(GetType(), "msgtype", "alert('Rent Paid Successfully!!!')", true);

                    if (returnval == "True")
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype", "alert('Rent Paid Successfully!!!')", true);
                        txtamnt.Text = "";
                    }
                }
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            txtamnt.Text = "";            
        }
    }
}