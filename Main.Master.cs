using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PropertyRentalContarct
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["Login"] != null)
            {
                string login = Session["Login"].ToString();
                if (login == "Tenant")
                {
                    PAdmin.Visible = false;
                    PTenant.Visible = true;
                    PLandlord.Visible = false;
                    PDefault.Visible = false;
                }
                else if(login == "Landlord")
                {
                    PAdmin.Visible = false;
                    PTenant.Visible = false;
                    PLandlord.Visible = true;
                    PDefault.Visible = false;
                }
                else if(login == "Admin")
                {
                    PAdmin.Visible = true;
                    PTenant.Visible = false;
                    PLandlord.Visible = false;
                    PDefault.Visible = false;
                }
                else
                {
                    PAdmin.Visible = false;
                    PTenant.Visible = false;
                    PLandlord.Visible = false;
                    PDefault.Visible = true;
                }
            }

        }
    }
}