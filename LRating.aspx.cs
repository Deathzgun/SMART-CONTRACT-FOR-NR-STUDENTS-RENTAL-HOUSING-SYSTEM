using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PropertyRentalContarct
{
    public partial class LRating : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        string lid;
        protected void Page_Load(object sender, EventArgs e)
        {
            lid = Session["Lid"].ToString();
            lblid.Text = lid;
            if (!IsPostBack)
            {                
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string q = "Select Tid from PropertyDetails where Lid = '" + lid + "' and Interest = 'Selected'";
                    SqlDataAdapter da = new SqlDataAdapter(q, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int c = ds.Tables[0].Rows.Count;
                    if (c > 0)
                    {
                        for (int i = 0; i < c; i++)
                        {
                            string tid = ds.Tables[0].Rows[i][0].ToString();
                            ddltid.Items.Add(tid);
                        }
                    }
                }               
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (txtfdbck.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgtype", "alert('Feedback field cannot be empty!!!')", true);
            }
            else
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    string qu = "Insert into LdFeedBack values('" + ddltid.SelectedValue + "','" + lblid.Text + "','" + txtfdbck.Text + "')";
                    SqlCommand cmd = new SqlCommand(qu, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Page.ClientScript.RegisterStartupScript(GetType(), "msgtype", "alert('Feedback sent Successfully!!!')", true);
                    txtfdbck.Text = "";
                    ddltid.ClearSelection();
                }
            }
        }
    }
}