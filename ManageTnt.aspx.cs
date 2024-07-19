using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PropertyRentalContarct
{
    public partial class ManageTnt : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            gvBind();
        }
        protected void gvBind()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "Select Id, Name, MobileNo, Address, EmailId, Status from Tenants";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
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

        protected void btnaprrvt_Click(object sender, EventArgs e)
        {
            Button Button1 = sender as Button;

            //Reference the GridView Row.
            GridViewRow row = Button1.NamingContainer as GridViewRow;
            string Lid = row.Cells[0].Text;

            using (SqlConnection con = new SqlConnection(cs))
            {
                if (Button1.Text == "Disapprove")
                {
                    con.Open();
                    string q = "Update Tenants set Status='Disapprove' where Id='" + Lid + "' ";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();

                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Tenant is Disapproved');", true);
                    gvBind();
                }
                else
                {
                    con.Open();
                    string q = "Update Tenants set Status='Approved' where Id='" + Lid + "' ";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();

                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Tenant is Approved');", true);
                    gvBind();
                }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "Select Id, Name, MobileNo, Address, EmailId, Status from Tenants where Name like '%" + txtsearch.Text + "%' or Id like '%" + txtsearch.Text + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
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
    }
}