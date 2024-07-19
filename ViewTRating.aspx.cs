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
    public partial class ViewTRating : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            GvBind();
            
        }

        protected void GvBind()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "Select * from TntFeedBack";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
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
                    GridView1.Visible = false;
                    lbnodata.Visible = true;
                }
            }
        }
    }
}