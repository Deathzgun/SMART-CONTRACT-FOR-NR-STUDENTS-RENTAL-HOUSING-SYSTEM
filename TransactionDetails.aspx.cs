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
    public partial class TransactionDetails : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        string tid, twaddr, twnm, taccname;

      
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
            DataTable dt = new DataTable();
            dt.Columns.Add("Type");
            dt.Columns.Add("Address");
            dt.Columns.Add("Transaction-Id");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Time");

            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "Select  WalletAddr, WalletName, AccName from WalletDetails where LidTid = '" + tid + "'";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {                   
                    twaddr = ds.Tables[0].Rows[0][0].ToString();
                    twnm = ds.Tables[0].Rows[0][1].ToString();
                    taccname = ds.Tables[0].Rows[0][2].ToString();
                }
            }

            var client = new RestClient("http://localhost:38223/api/Wallet/history?WalletName=" + twnm + "&AccountName=" + taccname + "&Address=" + twaddr + "");

            var request = new RestRequest();
            RestResponse response = client.Execute(request);
            string res = response.Content;
            dynamic array = JsonConvert.DeserializeObject(res);
            dynamic arr = array.history;
            foreach (var h in arr)
            {
                dynamic th = h.transactionsHistory;
                foreach (var tr in th)
                {
                    var dr = dt.NewRow();
                    string tp = tr.type;
                    dr["Address"] = tr.toAddress;
                    string fee = tr.fee;                      
                    string amnt = tr.amount;
                    if (amnt.Contains("26000000"))
                    {
                        if (amnt == "26000000")
                        {
                            amnt = "0.0";
                        }
                        else
                        {
                            amnt = amnt.Replace("26000000", ".0");
                            dr["Type"] = tp;

                            dr["Transaction-Id"] = tr.id;
                            dr["Amount"] = amnt;
                            double tm = tr.timestamp;
                            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                            dtDateTime = dtDateTime.AddSeconds(tm).ToLocalTime();
                            dr["Time"] = dtDateTime;
                            dt.Rows.Add(dr);
                        }
                    }
                    else
                    {
                        amnt = amnt.Remove(5);
                        dr["Type"] = tp;

                        dr["Transaction-Id"] = tr.id;
                        dr["Amount"] = amnt;
                        double tm = tr.timestamp;
                        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        dtDateTime = dtDateTime.AddSeconds(tm).ToLocalTime();
                        dr["Time"] = dtDateTime;
                        dt.Rows.Add(dr);
                    }
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Visible = true;
            lbnodata.Visible = false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == "createOrCall")
                {
                    string transId = e.Row.Cells[2].Text;
                    RestClient client = new RestClient("http://localhost:38223/api/SmartContracts/receipt?txHash=" + transId + "");
                    RestRequest request = new RestRequest("http://localhost:38223/api/SmartContracts/receipt?txHash=" + transId + "", Method.Get);
                    //request.AddParameter("application/octet-stream", file, ParameterType.RequestBody);
                    RestResponse response = client.Execute(request);
                    string res = response.StatusCode.ToString();
                    // Lbstatus.Text = res;
                   
                    if (res.Contains("OK"))
                    {
                        dynamic array = JsonConvert.DeserializeObject(response.Content);

                        string address = array.to;
                        
                        e.Row.Cells[1].Text = address;
                       
                    }
                }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                DateTime sdt = Convert.ToDateTime(txtdate.Text);
                string sedt = sdt.ToString("dd-MM-yyyy");

                DateTime dt = Convert.ToDateTime(row.Cells[4].Text);
                string ddt = dt.ToString("dd-MM-yyyy");
                if (ddt == sedt)
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

    }
}