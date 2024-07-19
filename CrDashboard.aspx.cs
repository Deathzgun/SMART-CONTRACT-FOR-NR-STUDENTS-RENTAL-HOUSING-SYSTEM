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
    public partial class CrDashboard : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            walletDetails();
            
        }

        protected void walletDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("LidTid");
            dt.Columns.Add("WalletName");
            dt.Columns.Add("WalletAddr");
            dt.Columns.Add("AccName");
            dt.Columns.Add("Type");
            using(SqlConnection con = new SqlConnection(cs))
            {
                string qu = "Select LidTid, WalletName, WalletAddr, AccName, Type from WalletDetails";
                SqlDataAdapter da = new SqlDataAdapter(qu, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int c = ds.Tables[0].Rows.Count;
                if (c > 0)
                {
                    for(int i = 0; i < c; i++)
                    {
                        string id = ds.Tables[0].Rows[i][0].ToString();
                        string q = "Select status from Landlords where Id='" + id + "'";
                        SqlDataAdapter sda = new SqlDataAdapter(q, con);
                        DataSet dss = new DataSet();
                        sda.Fill(dss);
                        if(dss.Tables[0].Rows.Count > 0)
                        {
                            if (dss.Tables[0].Rows[0][0].ToString() == "Approved")
                            {
                                var dr = dt.NewRow();
                                dr["LidTid"] = ds.Tables[0].Rows[i][0];
                                dr["WalletName"] = ds.Tables[0].Rows[i][1];
                                dr["WalletAddr"] = ds.Tables[0].Rows[i][2];
                                dr["AccName"] = ds.Tables[0].Rows[i][3];
                                dr["Type"] = ds.Tables[0].Rows[i][4];

                                dt.Rows.Add(dr);
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {                            
                            q = "Select status from Tenants where Id='" + id + "'";
                            sda = new SqlDataAdapter(q, con);
                            dss = new DataSet();
                            sda.Fill(dss);
                            if (dss.Tables[0].Rows.Count > 0)
                            {
                                if (dss.Tables[0].Rows[0][0].ToString() == "Approved")
                                {
                                    var dr = dt.NewRow();
                                    dr["LidTid"] = ds.Tables[0].Rows[i][0];
                                    dr["WalletName"] = ds.Tables[0].Rows[i][1];
                                    dr["WalletAddr"] = ds.Tables[0].Rows[i][2];
                                    dr["AccName"] = ds.Tables[0].Rows[i][3];
                                    dr["Type"] = ds.Tables[0].Rows[i][4];

                                    dt.Rows.Add(dr);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }

                    }
                    

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        //protected void btncirrus_Click(object sender, EventArgs e)
        //{           
        //    Pwallet.Visible = false;
        //}

        protected void lbtndownload_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process1 = new System.Diagnostics.Process();

            process1.StartInfo.WorkingDirectory = Request.MapPath("~/");
            //exe File Name. 
            process1.StartInfo.FileName = Request.MapPath("Cirrus.Core.Private.Net-v1.9.1-setup-win-x64.exe");
            //Argement Which you have tp pass. 
            process1.StartInfo.Arguments = " ";
            process1.StartInfo.LoadUserProfile = true;
            //Process Start on exe.
            process1.Start();
            process1.WaitForExit();
            process1.Close();
            
        }

        //protected void getaddress_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var client = new RestClient("http://localhost:38223/api/Wallet/load");
        //        RestRequest request = new RestRequest();
        //        request.AddHeader("Content-Type", "application/json");
        //        var body = @"{" + "\n" +
        //        @"  ""name"": ""cirrusdev""," + "\n" +
        //        @"  ""password"": ""password""" + "\n" +
        //        @"}" + "\n" +
        //        @"";
        //        request.AddParameter("application/json", body, ParameterType.RequestBody);
        //        request.AddJsonBody(body);
        //        RestResponse response = client.Post(request);
        //        string res = response.StatusCode.ToString();
        //        if (res == "OK")
        //        {
        //            client = new RestClient("http://localhost:38223/api/Wallet/addresses?WalletName=cirrusdev&AccountName=account 0&Segwit=true");
        //            request = new RestRequest("http://localhost:38223/api/Wallet/addresses?WalletName=cirrusdev&AccountName=account 0&Segwit=true", Method.Get);
        //            response = client.Execute(request);
        //            res = response.StatusCode.ToString();
        //            if (res == "OK")
        //            {
        //                dynamic array = JsonConvert.DeserializeObject(response.Content);
        //                dynamic arr = array.addresses;
        //                foreach (var h in arr)
        //                {
        //                    dynamic array2 = h;
        //                    string amnt = array2.amountConfirmed;
        //                    if (amnt == "0")
        //                    {
        //                        continue;
        //                    }
        //                    else
        //                    {
        //                        lbwaddr.Text = array2.address;
        //                        lbwname.Text = "cirrusdev";
        //                        lbwacc.Text = "account 0";
        //                        lbwpass.Text = "password";
        //                        tblwdetails.Visible = true;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(GetType(), "msgtype", "alert('Downlload the Cirrus Core Application first')", true);
        //    }
        //}
    }
}