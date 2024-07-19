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
    public partial class UHome : System.Web.UI.Page
    {

        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        string tid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tid = Session["Tid"].ToString();
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string qu = "Select * from Tenants where Id='" + tid + "'";
                    SqlDataAdapter da = new SqlDataAdapter(qu, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if(ds.Tables[0].Rows.Count > 0)
                    {
                        lbtid.Text = ds.Tables[0].Rows[0][0].ToString();
                        lbtname.Text = ds.Tables[0].Rows[0][1].ToString();
                        lbmobile.Text = ds.Tables[0].Rows[0][2].ToString();
                        lbaddress.Text = ds.Tables[0].Rows[0][3].ToString();
                        lbemail.Text = ds.Tables[0].Rows[0][4].ToString();
                        lbstatus.Text = ds.Tables[0].Rows[0][6].ToString();
                    }

                    qu = "Select * from WalletDetails where LidTid='" + tid + "'";
                    da = new SqlDataAdapter(qu, con);
                    ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lbwnm.Text = ds.Tables[0].Rows[0][2].ToString();
                        lbwaccnm.Text = ds.Tables[0].Rows[0][3].ToString();
                        lbwaddr.Text = ds.Tables[0].Rows[0][6].ToString();
                        lbwpass.Text = ds.Tables[0].Rows[0][4].ToString();
                        walletDiv.Visible = true;
                        btnChkBal.Visible = true;
                    }
                    else
                    {
                        walletDiv.Visible = false;

                    }
                }
            }
        }

        protected void btnChkBal_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:38223/api/Dashboard/Stats";
            //string url = "http://localhost:38223/api/Wallet/balance?WalletName="+lbwnm.Text+"&AccountName="+lbwaccnm.Text+"&IncludeBalanceByAddress=true";         
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(url, Method.Get);
            RestResponse response = client.Execute(request);
            string res = response.StatusCode.ToString();

            if (res.Contains("OK"))
            {
                string array = response.Content;

                int stindex = array.IndexOf("Wallets");
                int lindex = array.Length;
                array = array.Substring(stindex);
                string[] wallets = array.Split('\n');
                for(int i = 0; i < wallets.Length; i++)
                {
                    string winfo = wallets[i];
                    if (winfo.Contains(lbwnm.Text))
                    {
                        int startindex = winfo.IndexOf("Confirmed balance");
                        winfo = winfo.Substring(startindex);
                        string[] info = winfo.Split(' ');
                        lbamount.Text = info[2] + " RM";
                        lbamount.Visible = true;
                    }
                    else
                    {

                    }
                }

            }
            else
            {
                lbamount.Text = "0 RM";
                lbamount.Visible = true;
            }
        }
    }
}