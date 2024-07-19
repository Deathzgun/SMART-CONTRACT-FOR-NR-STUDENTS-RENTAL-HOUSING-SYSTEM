using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PropertyRentalContarct
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Login"] = "Login";
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Equals("admin") && txtId.Text.Equals("admin"))
            {
                Session["Login"] = "Admin";
                Response.Redirect("CrDashboard.aspx");
            }
        }
    }
}