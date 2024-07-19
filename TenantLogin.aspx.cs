using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace PropertyRentalContarct
{
    public partial class TenantLogin : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtpassword.Text != "")
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    string qu = "Select Id, Password from Tenants where Id='" + txtId.Text + "' and Password='" + txtpassword.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(qu, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int c = ds.Tables[0].Rows.Count;
                    if (c > 0)
                    {
                        Session["Login"] = "Tenant";
                        Session["Tid"] = txtId.Text;
                        Response.Redirect("THome.aspx");
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msg", "alert('Please enter the Login Credentials')", true);
            }
        }
    }
}