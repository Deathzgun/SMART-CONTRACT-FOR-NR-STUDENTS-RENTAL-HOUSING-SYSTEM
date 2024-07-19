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
    public partial class ContractDetails : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        string tid;
        string contrStat, twname, taccnm, twpass, twaddr, contractAddr, deposite;
        protected void Page_Load(object sender, EventArgs e)
        {
            tid = Session["Tid"].ToString();
            if (!IsPostBack)
            {
                GvBind();
            }
        }
        protected void GvBind()
        {                    
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "Select p.Pid,p.Lid,p.Lname,p.Deposite,p.ContractAddress as CntrAddr, w.WalletName as Lwname, w.WalletAddr as Lwaddr, p.ContractAddress as CntrAddr,p.ContractStat as CntrStat from PropertyDetails p, WalletDetails w where p.Tid='" + tid + "' and p.Interest = 'Selected' and p.Lid = w.LidTid";
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
                    GridView1.Visible = false;
                    lbnodata.Visible = true;
                }
            }
        }

        protected void lbtnConfirm_Command(object sender, CommandEventArgs e)
        {
            string date = DateTime.Now.ToString("dd MMMM yyyy");
            LinkButton lbtncnf = sender as LinkButton;
            GridViewRow row = lbtncnf.NamingContainer as GridViewRow;
            //string eId = row.Cells[3].Text;

            string argument = e.CommandArgument.ToString();
            if (argument.Equals("Confirm&Pay"))
            {              
                string pid = row.Cells[1].Text;
                lbllid.Text = row.Cells[2].Text;
                lbllwadd.Text = row.Cells[5].Text;
                deposite = row.Cells[6].Text;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string q = "Select * from WalletDetails where LidTid='" + tid + "'";
                    SqlDataAdapter da = new SqlDataAdapter(q, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        twname = ds.Tables[0].Rows[0][2].ToString();
                        twpass = ds.Tables[0].Rows[0][4].ToString();
                        taccnm = ds.Tables[0].Rows[0][3].ToString();
                        twaddr = ds.Tables[0].Rows[0][6].ToString();
                    }

                    q = "Select ContractAddress from PropertyDetails where Pid='" + pid + "'";
                    da = new SqlDataAdapter(q, con);
                    ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        contractAddr = ds.Tables[0].Rows[0][0].ToString();

                    }
                }
                var client = new RestClient("http://localhost:38223/api/SmartContracts/build-and-send-call");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");

                var body = @"{" + "\n" +
    @"  ""amount"":""" + deposite + "\"," + "\n" +
    @"  ""contractAddress"": """ + contractAddr + "\"," + "\n" +
    @"  ""methodName"": ""ContractConfirm""," + "\n" +
    @"  ""password"": """ + twpass + "\"," + "\n" +
    @"  ""sender"": """ + twaddr + "\"," + "\n" +
    @"  ""walletName"":""" + twname + "\"," + "\n" +
    @"  ""accountName"":""" + taccnm + "\"," + "\n" +
    @"  ""outpoints"": null," + "\n" +
    @"  ""feeAmount"": ""0.01""," + "\n" +
    @"  ""gasPrice"": 100," + "\n" +
    @"  ""gasLimit"": 250000," + "\n" +
   @"  ""recipients"":[" + "\n" +
@"    {" + "\n" +
@"      ""amount"": """ + deposite + "\"," + "\n" +
@"      ""destinationAddress"": """ + lbllwadd.Text + "\"," + "\n" +
@"      ""destinationScript"": ""Deposite Payment""," + "\n" +
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
                    dynamic array = JsonConvert.DeserializeObject(response.Content);

                    string transId = array.transactionId;

                again:
                    System.Threading.Thread.Sleep(5000);

                    //Get Contract Details
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
                        //Get New Contract Address in response....
                        array = JsonConvert.DeserializeObject(response.Content);

                        string returnval = array.returnValue;
                        if (returnval == "True")
                        {
                            using (SqlConnection con = new SqlConnection(cs))
                            {
                                con.Open();
                                string qu = "update PropertyDetails set  ContractStat='Started' where Pid='" + pid + "' and Tid='" + tid + "'";
                                SqlCommand cmd = new SqlCommand(qu, con);
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            Page.ClientScript.RegisterStartupScript(GetType(), "msgtype", "alert('Contract Confirmed and Deposite Paid Successfully!!!')", true);
                            GvBind(); 
                        }

                        //lbcnaddress.Text = contractAddr;

                        //string[] cntrDet = contractDetail.Split(',');
                        //Label[] lb = { lbl, lbldet1, lbldet2, lbldet3, lbl4, lbldet5, lbldet6, lbldet7, lbldet8, lbl1, lbldetail1, lbldetail2, lbldetail3, lbln4, lbldetail5, lbldetail6, lbldetail7, lbldetail8 };
                        //for (int i = 1; i < cntrDet.Length; i++)
                        //{
                        //    string detail = cntrDet[i];
                        //    if (detail == "" || i == 4)
                        //    {
                        //        continue;
                        //    }
                        //    else
                        //    {
                        //        string[] dt = detail.Split(':');
                        //        lb[i].Text = dt[0];
                        //        lb[i + 9].Text = dt[1];

                        //    }
                        //}
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "$('#Viewmodal').modal({backdrop: 'static', keyboard: false},'show')", true);

                    }
                }
            }
        }
      
        protected void btnVContract_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string pid = row.Cells[1].Text;
            lbllid.Text = row.Cells[2].Text;
            lbllwadd.Text = row.Cells[5].Text;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "Select * from WalletDetails where LidTid='" + tid + "'";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    twname = ds.Tables[0].Rows[0][2].ToString();
                    twpass = ds.Tables[0].Rows[0][4].ToString();
                    taccnm = ds.Tables[0].Rows[0][3].ToString();
                    twaddr = ds.Tables[0].Rows[0][6].ToString();
                }

                q = "Select ContractAddress from PropertyDetails where Pid='" + pid + "'";
                da = new SqlDataAdapter(q, con);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    contractAddr = ds.Tables[0].Rows[0][0].ToString();

                }
            }
            var client = new RestClient("http://localhost:38223/api/SmartContracts/build-and-send-call");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");

            var body = @"{" + "\n" +
@"  ""amount"": ""0""," + "\n" +
@"  ""contractAddress"": """ + contractAddr + "\"," + "\n" +
@"  ""methodName"": ""ContractDetails""," + "\n" +
@"  ""password"": """ + twpass + "\"," + "\n" +
@"  ""sender"": """ + twaddr + "\"," + "\n" +
@"  ""walletName"":""" + twname + "\"," + "\n" +
@"  ""accountName"":""" + taccnm + "\"," + "\n" +
@"  ""outpoints"": null," + "\n" +
@"  ""feeAmount"": ""0.01""," + "\n" +
@"  ""gasPrice"": 100," + "\n" +
@"  ""gasLimit"": 250000," + "\n" +
@"  ""recipients"":null," + "\n" +
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
                dynamic array = JsonConvert.DeserializeObject(response.Content);

                string transId = array.transactionId;

            again:
                System.Threading.Thread.Sleep(5000);

                //Get Contract Details
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
                    //Get New Contract Address in response....
                    array = JsonConvert.DeserializeObject(response.Content);

                    string contractDetail = array.returnValue;
                    lbcnaddress.Text = contractAddr;

                    string[] cntrDet = contractDetail.Split(',');
                    Label[] lb = { lbl, lbldet1, lbldet2, lbldet3, lbl4, lbldet5, lbldet6, lbldet7, lbl1, lbldetail1, lbldetail2, lbldetail3, lbln4, lbldetail5, lbldetail6, lbldetail7 };
                    for (int i = 1; i < cntrDet.Length; i++)
                    {
                        string detail = cntrDet[i];
                        if (detail == "" || i == 4)
                        {
                            continue;
                        }
                        else
                        {
                            string[] dt = detail.Split(':');
                            lb[i].Text = dt[0];
                            lb[i + 8].Text = dt[1];

                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "$('#Viewmodal').modal({backdrop: 'static', keyboard: false},'show')", true);

                }
            }
        }
    }
}