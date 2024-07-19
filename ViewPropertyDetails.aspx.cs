using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace PropertyRentalContarct
{
    public partial class ViewPropertyDetails : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        string tid;
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
            using(SqlConnection con = new SqlConnection(cs))
            {
                string qu = "Select * from PropertyDetails where Interest = 'shortlisted' or Interest= 'Interested' or Interest= 'NA' order by Pid";
                SqlDataAdapter da = new SqlDataAdapter(qu, con);
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
       
        protected void lbtnShowInt_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            GridViewRow row = lbtn.NamingContainer as GridViewRow;
            string pid = row.Cells[0].Text;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "Update PropertyDetails set Interest='Interested', Tid='" + tid + "' where Pid='" + pid + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
               
                GvBind(); 
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string qu = "Select * from PropertyDetails where Location='"+ txtsearch.Text + "' ";
                SqlDataAdapter da = new SqlDataAdapter(qu, con);
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
                    qu = "Select * from PropertyDetails where  Rent < '" + txtsearch.Text + "' or Rent = '" + txtsearch.Text + "'";
                    da = new SqlDataAdapter(qu, con);
                    ds = new DataSet();
                    da.Fill(ds);
                    if(ds.Tables[0].Rows.Count > 0)
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
        }
    }
}