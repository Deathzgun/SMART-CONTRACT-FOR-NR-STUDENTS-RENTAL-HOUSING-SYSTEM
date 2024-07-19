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
    public partial class ViewTenants : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        string lid;
        protected void Page_Load(object sender, EventArgs e)
        {
            lid = Session["Lid"].ToString();
            GvBind();
        }

        protected void GvBind()
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                string qu = "Select t.*, P.Pid, p.Interest from Tenants t, PropertyDetails p where Status='Approved' and t.Id=p.Tid and t.Id=(Select Tid from PropertyDetails where Interest='Interested' and Lid = '" + lid + "')";
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

        protected void btnShortlist_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string prid = row.Cells[1].Text;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string qu = "update PropertyDetails set Interest='Shortlisted' where Pid='" + prid + "'";
                SqlCommand cmd = new SqlCommand(qu, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            GvBind();
        }
    }
}