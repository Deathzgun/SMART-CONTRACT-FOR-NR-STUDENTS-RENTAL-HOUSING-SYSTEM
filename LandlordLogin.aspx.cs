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
    public partial class LandlordLogin : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string qu = "Select Id, Password, Name from Landlords where Id = '" + txtId.Text + "' and Password = '" + txtpassword.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(qu, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int c = ds.Tables[0].Rows.Count;
                if (c > 0)
                {
                    string name = ds.Tables[0].Rows[0][2].ToString();
                    Session["Login"] = "Landlord";
                    Session["Lid"] = txtId.Text;
                    Session["Name"] = name;
                    Response.Redirect("LHome.aspx");
                }
            }
        }
    }
}