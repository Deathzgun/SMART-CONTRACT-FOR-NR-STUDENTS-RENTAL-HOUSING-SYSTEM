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
    public partial class ManageProperty : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        int id;
        string lid, lname;
        string prid, lndname, aprtt, tarea, loctn, rnt, duratn;        

        protected void Page_Load(object sender, EventArgs e)
        {
            lid = Session["Lid"].ToString();
            lname = Session["Name"].ToString();
            if (!IsPostBack)
            {
                GvBind();
                setId();
            }
            
        }

        protected void setId()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string que = "Select Pid from PropertyDetails order by Pid desc";
                SqlDataAdapter da = new SqlDataAdapter(que, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int d = ds.Tables[0].Rows.Count;
                if (d > 0)
                {
                    string pid = ds.Tables[0].Rows[0][0].ToString();
                    id = Convert.ToInt32(pid);
                    id++;
                    txtpid.Text = id.ToString();
                }
                else
                {
                    txtpid.Text = "101";
                }
            }
        }

        protected void GvBind()
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string que = "Select Pid, ApartmentType, TotalArea, Location, Rent, Lname from PropertyDetails  where Lid='" + lid + "' order by Pid";
                SqlDataAdapter da = new SqlDataAdapter(que, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int d = ds.Tables[0].Rows.Count;
                if (d > 0)
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

        protected void lbtnadd_Click(object sender, EventArgs e)
        {
            if (PNewpr.Visible.Equals(false))
            {
                PNewpr.Visible = true;
                btnsDiv.Visible = true;
                gridDiv.Visible = false;
            }
            else
            {                
                PNewpr.Visible = false;
                btnsDiv.Visible = false;
                gridDiv.Visible = true;
            }

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {            
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "Insert into PropertyDetails(Lid,ApartmentType,TotalArea,Location,Rent,Lname,Interest,Tid,ContractStat,ContractAddress,Deposite) Values('" + lid + "','" + txtaprtp.Text + "','" + txttotar.Text + "','" + txtloc.Text + "','" + txtrent.Text + "','" + lname + "','NA','NA','NA','NA','NA')";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                con.Close();

                Page.ClientScript.RegisterStartupScript(GetType(), "msgType", "alert('Property Details Inserted successfully!!!')", true);
                id++;
                txtpid.Text = id.ToString();
                txtaprtp.Text = "";
                txttotar.Text = "";
                txtloc.Text = "";
                txtrent.Text = "";
                PNewpr.Visible = false;
            }
            GvBind();
            
        }
       
        protected void lbtnedit_Click(object sender, EventArgs e)
        {
            LinkButton lbtnview = sender as LinkButton;
            GridViewRow row = lbtnview.NamingContainer as GridViewRow;
            prid = row.Cells[0].Text;            
            aprtt = row.Cells[2].Text;
            tarea = row.Cells[3].Text;
            loctn = row.Cells[4].Text;
            rnt = row.Cells[5].Text;
            duratn = row.Cells[6].Text;

            txtpid.Text = prid;
            txtpid.ReadOnly = true;
            txtaprtp.Text = aprtt;
            txttotar.Text = tarea;
            txtloc.Text = loctn;
            txtrent.Text = rnt;

            PNewpr.Visible = true;
            btnadd.Visible = false;
            btnupdate.Visible = true;
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {            
            using(SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string query = "Update PropertyDetails set apartmentType='" + txtaprtp.Text + "', TotalArea='" + txttotar.Text + "', Location='" + txtloc.Text + "', Rent='" + txtrent.Text + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Page.ClientScript.RegisterStartupScript(GetType(), "msgtype", "alert('Details updated successfully!!!')", true);
                txtpid.Text = "";
                txtaprtp.Text = "";
                txttotar.Text = "";
                txtloc.Text = "";
                txtrent.Text = "";
                PNewpr.Visible = false;
               
            }
            GvBind();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if(btnadd.Visible)
            {
                txtaprtp.Text = "";
                txttotar.Text = "";
                txtloc.Text = "";
                txtrent.Text = "";
                PNewpr.Visible = false;
            }
            else if(btnupdate.Visible)
            {
                txtpid.Text = "";
                txtaprtp.Text = "";
                txttotar.Text = "";
                txtloc.Text = "";
                txtrent.Text = "";
                PNewpr.Visible = false;
            }
        }

        protected void lbtndelete_Click(object sender, EventArgs e)
        {
            LinkButton lbtnview = sender as LinkButton;
            GridViewRow row = lbtnview.NamingContainer as GridViewRow;
            string prid = row.Cells[0].Text;

            using(SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "Delete from PropertyDetails where Pid='" + prid + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                con.Close();

                Page.ClientScript.RegisterStartupScript(GetType(), "msgtype", "alert('Details Deleted Successfully!!!')", true);
               
            }
            GvBind();
        }
    }
}