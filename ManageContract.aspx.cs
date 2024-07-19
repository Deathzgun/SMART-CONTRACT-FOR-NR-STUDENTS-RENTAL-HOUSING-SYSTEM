using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PropertyRentalContarct
{
    public partial class ManageContract : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        string lid, contrStat, lwname, laccnm, lwpass, lwaddr, contractAddr;
        protected void Page_Load(object sender, EventArgs e)
        {
            lid = Session["Lid"].ToString();
            if (!IsPostBack)
            {
                gvBind();
            }
        }

        protected void gvBind()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PId");
            dt.Columns.Add("TId");
            dt.Columns.Add("Name");
            dt.Columns.Add("Mobile No");
            dt.Columns.Add("Rent");
            dt.Columns.Add("Location");
            dt.Columns.Add("Wallet");
            dt.Columns.Add("Wallet-Address");
            dt.Columns.Add("ContractStatus");
            using (SqlConnection con = new SqlConnection(cs))
            {
                string qu = "Select Pid, Tid, Rent, Location, ContractStat from PropertyDetails where  Lid = '" + lid + "' and (Interest='Shortlisted' or Interest='Selected')";
                SqlDataAdapter da = new SqlDataAdapter(qu, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int c = ds.Tables[0].Rows.Count;
                if (c > 0)
                {
                    for (int i = 0; i < c; i++)
                    {
                        string pid = ds.Tables[0].Rows[i][0].ToString();
                        string tid = ds.Tables[0].Rows[i][1].ToString();
                        string rent = ds.Tables[0].Rows[i][2].ToString();
                        string location = ds.Tables[0].Rows[i][3].ToString();
                        contrStat = ds.Tables[0].Rows[i][4].ToString();

                        string q = "Select t.Id, t.Name, t.MobileNo, w.WalletName, w.WalletAddr from Tenants t, WalletDetails w where t.Id = w.LidTid and t.Id = '" + tid + "' ";
                        SqlDataAdapter sda = new SqlDataAdapter(q, con);
                        DataSet dss = new DataSet();
                        sda.Fill(dss);
                        int cnt = dss.Tables[0].Rows.Count;
                        if (cnt > 0)
                        {
                            for (int j = 0; i < c; i++)
                            {
                                var dr = dt.NewRow();
                                dr["Pid"] = pid;
                                dr["Tid"] = tid;
                                dr["Name"] = dss.Tables[0].Rows[j][1].ToString();
                                dr["Mobile No"] = dss.Tables[0].Rows[j][2].ToString();
                                dr["Rent"] = rent;
                                dr["Location"] = location;
                                dr["Wallet"] = dss.Tables[0].Rows[j][3].ToString();
                                dr["Wallet-Address"] = dss.Tables[0].Rows[j][4].ToString();
                                dr["ContractStatus"] = contrStat;
                                dt.Rows.Add(dr);
                            }
                            GridView1.DataSource = dt;
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
        protected void btnPrpDet_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string pid = row.Cells[1].Text;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "Select ApartmentType, TotalArea, Location, Rent from PropertyDetails where Pid='" + pid + "'";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbpid.Text = pid;
                    lbaprt.Text = ds.Tables[0].Rows[0][0].ToString();
                    lbarea.Text = ds.Tables[0].Rows[0][1].ToString();
                    lbloc.Text = ds.Tables[0].Rows[0][2].ToString();
                    lbrent.Text = ds.Tables[0].Rows[0][3].ToString();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "$('#modal').modal({backdrop: 'static', keyboard: false},'show')", true);
                }
            }
        }

        protected void btnCContract_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            lbp.Text = row.Cells[1].Text;
            lbt.Text = row.Cells[2].Text;
            lblocatn.Text = row.Cells[6].Text;
            lbrnt.Text = row.Cells[5].Text;
            lbtwaddr.Text = row.Cells[8].Text;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "Select * from WalletDetails where LidTid='" + lid + "'";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lwname = ds.Tables[0].Rows[0][2].ToString();
                    lwpass = ds.Tables[0].Rows[0][4].ToString();
                    laccnm = ds.Tables[0].Rows[0][3].ToString();
                    lwaddr = ds.Tables[0].Rows[0][6].ToString();
                }
            }
            try
            {
                var client = new RestClient("http://localhost:38223/api/SmartContractWallet/create");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                var body = @"{" + "\n" +
    @"  ""amount"": ""0""," + "\n" +
    @"  ""contractCode"":""4D5A90000300000004000000FFFF0000B800000000000000400000000000000000000000000000000000000000000000000000000000000000000000800000000E1FBA0E00B409CD21B8014CCD21546869732070726F6772616D2063616E6E6F742062652072756E20696E20444F53206D6F64652E0D0D0A2400000000000000504500004C0102007526EDFA0000000000000000E00022200B013000001000000002000000000000562F0000002000000040000000000010002000000002000004000000000000000400000000000000006000000002000000000000030040850000100000100000000010000010000000000000100000000000000000000000042F00004F000000000000000000000000000000000000000000000000000000004000000C000000E82E00001C0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000200000080000000000000000000000082000004800000000000000000000002E746578740000005C0F0000002000000010000000020000000000000000000000000000200000602E72656C6F6300000C000000004000000002000000120000000000000000000000000000400000420000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000382F000000000000480000000200050044240000A40A00000100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000660203280500000A0202280600000A6F0700000A28030000062A4602280800000A72010000706F0900000A2A4A02280800000A7201000070036F0A00000A2A4602280800000A72130000706F0B00000A2A4A02280800000A7213000070036F0C00000A2A4602280800000A72310000706F0B00000A2A4A02280800000A7231000070036F0C00000A2A4602280800000A72430000706F0D00000A2A4A02280800000A7243000070036F0E00000A2A4602280800000A724D0000706F0B00000A2A4A02280800000A724D000070036F0C00000A2A4602280800000A725F0000706F0B00000A2A4A02280800000A725F000070036F0C00000A2A4602280800000A72730000706F0900000A2A4A02280800000A7273000070036F0A00000A2A4602280800000A72890000706F0D00000A2A4A02280800000A7289000070036F0E00000A2A7202280800000A729B000070038C08000001280F00000A6F0D00000A2A7602280800000A729B000070038C08000001280F00000A046F0E00000A2A0000001330020047000000000000000202280600000A6F0700000A280300000602032807000006020428090000060205280B000006020E04280D000006020E05280F000006020E062811000006020E0728050000062A001330040054010000010000110202280E00000602280600000A6F0700000A281000000A2D1802280200000602280600000A6F0700000A281000000A2B011772B7000070281100000A02280800000A72010000706F0900000A0A02280800000A72730000706F0900000A0B02280800000A72310000706F0B00000A0C02280800000A72430000706F0D00000A0D02280800000A724D0000706F0B00000A130402280800000A725F0000706F0B00000A130502280800000A72890000706F0D00000A130602280800000A72130000706F0B00000A13071F108D0C000001251672D5000070A22517068C08000001A2251872EB000070A2251908A2251A7205010070A2251B098C0D000001A2251C7217010070A2251D1104A2251E7231010070A2251F09078C08000001A2251F0A7247010070A2251F0B1105A2251F0C7267010070A2251F0D11068C0D000001A2251F0E7281010070A2251F0F1107A2281200000A2AE60202280600000A6F0700000A02280E000006281000000A72B7000070281100000A02022802000006022808000006281300000A6F1400000A2A00001330030044000000000000000202280600000A6F0700000A02280E000006281000000A72B7000070281100000A0272A9010070280500000602022802000006022810000006281300000A6F1400000A2ACE0202280200000602280600000A6F0700000A281000000A72B7000070281100000A0272B901007028050000060228040000062A42534A4201000100000000000C00000076342E302E33303331390000000005006C000000F0030000237E00005C0400007003000023537472696E677300000000CC070000D0010000235553009C090000100000002347554944000000AC090000F800000023426C6F6200000000000000020000014715A2010900000000FA013300160000010000000E00000002000000180000001300000014000000040000000100000001000000080000001000000001000000020000000000840101000000000006001C01360206004C0136020600080123020F00560200000A003C019F020A0016039F020A00A2009F020A008F029F020A0071009F020A00C9009F0206007D01960106002403960106000E0096010A002E039F020000000015000000000001000100010010001B03000019000100010050200000000086181902100001006A2000000000860839001B0002007C200000000081084600840002008F20000000008608C1028A000300A120000000008108D4028E000300B420000000008608C7018A000400C620000000008108D4018E000400D9200000000086083E0393000500EB20000000008108470397000500FE20000000008608AD018A0006001021000000008108BA018E000600232100000000860886008A000700352100000000810894008E0007004821000000008608E1011B0008005A21000000008108F001840008006D21000000008608EE00930009007F21000000008108FB0097000900922100000000860053009C000A00AF210000000081005E00A2000B00D021000000008600F502A9000D00242200000000860065028A00140084230000000086005F0377001400C0230000000086009D0177001400102400000000860004038A00140000000100B600000001006A01000001006A01000001006A01000001006A01000001006A01000001006A01000001006A01000001006A01000001009702000001009702000002006900000001001F02000002005003000003003500000004002B0300000500FF0100000600540300000700B602090019020100110019020600190019020A0029001902060031001902100031007A001600490005021B003100DA00200051008102250051008C022B0051007001320051007A013700510001003D0051000B0042005900EE024800410063035B003100580363005900E7026900310010026F007100750277002E000B00C2002E001300CB002E001B00EA0043002300F3004E000200010000004A00B5000000D802BA000000D801BA0000004B03BE000000BE01BA0000009800BA000000F401B5000000FF00BE0002000200030001000300030002000400050001000500050002000600070001000700070002000800090001000900090002000A000B0001000B000B0002000C000D0001000D000D0002000E000F0001000F000F00020010001100010011001100048000000000000000000000000000000000160300000500000000000000000000007B001E000000000002000000000000000000000000009F0200000000000000000047657455496E7436340053657455496E743634003C4D6F64756C653E0053797374656D2E507269766174652E436F72654C6962006C6F63006765745F4C616E646C6F7264007365745F4C616E646C6F72640047657442616C616E63650053657442616C616E63650062616C616E636500494D657373616765006765745F4D657373616765006765745F434461746554696D65007365745F434461746554696D650049536D617274436F6E7472616374537461746500736D617274436F6E74726163745374617465004950657273697374656E745374617465006765745F50657273697374656E745374617465006765745F4465706F73697465007365745F4465706F736974650044656275676761626C6541747472696275746500436F6D70696C6174696F6E52656C61786174696F6E73417474726962757465004465706C6F794174747269627574650052756E74696D65436F6D7061746962696C6974794174747269627574650076616C756500476574537472696E6700536574537472696E6700536D617274436F6E74726163742E646C6C0053797374656D00436F6E7472616374436F6E6669726D006765745F4C6F636174696F6E007365745F4C6F636174696F6E006765745F4475726174696F6E007365745F4475726174696F6E006765745F54656E616E7441646472007365745F54656E616E7441646472007461646472006765745F53656E646572005472616E73666572002E63746F72006475720053797374656D2E446961676E6F73746963730053797374656D2E52756E74696D652E436F6D70696C6572536572766963657300446562756767696E674D6F64657300436F6E747261637444657461696C73006765745F5375636365737300476574416464726573730053657441646472657373006164647265737300537472617469732E536D617274436F6E74726163747300636E7472537461747573006765745F436F6E7472616374537461747573007365745F436F6E747261637453746174757300436F6E63617400466F726D617400437265617465436F6E7472616374005465726D696E617465436F6E747261637400536D617274436F6E7472616374004F626A65637400647400495472616E73666572526573756C74006765745F52656E74007365745F52656E7400726E74006470740041737365727400506179006F705F457175616C697479000000114C0061006E0064006C006F0072006400001D43006F006E007400720061006300740053007400610074007500730000114400750072006100740069006F006E000009520065006E00740000114C006F0063006100740069006F006E00001343004400610074006500540069006D0065000015540065006E0061006E007400410064006400720000114400650070006F007300690074006500001B420061006C0061006E006300650073005B007B0030007D005D00001D41007300730065007200740020006600610069006C00650064002E0000154C0061006E0064006C006F007200640020003A0000192C0020004400750072006100740069006F006E0020003A0000112C002000520065006E00740020003A0000192C0020004C006F0063006100740069006F006E0020003A0000152C002000540065006E0061006E00740020003A00001F2C0020004300720065006100740065002000440061007400650020003A0000192C0020004400650070006F00730069007400650020003A0000272C00200043006F006E0074007200610063007400200073007400610074007500730020003A00000F530074006100720074006500640000155400650072006D0069006E0061007400650064000000945FF44F37B9F54FB0A0178F20C205330004200101080320000105200101111105200101121D04200012250420001121042000122905200111210E062002010E11210420010E0E052002010E0E0420010B0E052002010E0B0500020E0E1C0C0708112111210E0B0E0E0B0E070002021121112105200201020E0500010E1D1C072002123911210B03200002087CEC85D7BEA7798E0520010111210320000E042001010E0320000B042001010B0520010B11210620020111210B0B2007010E0B0E0E11210B0E04280011210328000E0328000B0801000800000000001E01000100540216577261704E6F6E457863657074696F6E5468726F7773010801000200000000000401000000000000000000000000000000100000000000000000000000000000002C2F00000000000000000000462F0000002000000000000000000000000000000000000000000000382F0000000000000000000000005F436F72446C6C4D61696E006D73636F7265652E646C6C0000000000FF25002000100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000C000000583F00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000""," + "\n" +
    @"  ""password"": """ + lwpass + "\"," + "\n" +
    @"  ""sender"": """ + lwaddr + "\"," + "\n" +
    @"  ""walletName"": """ + lwname + "\"," + "\n" +
    @"  ""accountName"": """ + laccnm + "\"," + "\n" +
    @"  ""outpoints"": null," + "\n" +
    @"  ""feeAmount"": ""0.001""," + "\n" +
    @"  ""gasPrice"": 100," + "\n" +
    @"  ""gasLimit"": 100000," + "\n" +
    @"  ""parameters"":null" + "\n" +
    @"}";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                //request.AddParameter("application/octet-stream", file, ParameterType.RequestBody);
                request.AddJsonBody(body);
                RestResponse response = client.Post(request);
                string res = response.StatusCode.ToString();
                if (res.Contains("OK"))
                {
                    //Get Hash value And Pass to API to get Contract Address
                    string contracthash = response.Content;
                    string[] cnh = contracthash.Split('"');
                    contracthash = cnh[1];

                again:
                    System.Threading.Thread.Sleep(5000);

                    client = new RestClient("http://localhost:38223/api/SmartContracts/receipt?txHash=" + contracthash + "");
                    request = new RestRequest("http://localhost:38223/api/SmartContracts/receipt?txHash=" + contracthash + "", Method.Get);
                    //request.AddParameter("application/octet-stream", file, ParameterType.RequestBody);
                    response = client.Execute(request);
                    res = response.StatusCode.ToString();
                    // Lbstatus.Text = res;
                    if (res.Contains("BadRequest"))
                    {
                        goto again;
                    }
                    else if (res.Contains("OK"))
                    {
                        //Get New Contract Address in response....
                        dynamic array = JsonConvert.DeserializeObject(response.Content);

                        contractAddr = array.newContractAddress;

                        lbcontrAddr.Text = contractAddr;


                        using (SqlConnection con = new SqlConnection(cs))
                        {
                            con.Open();
                            string qu = "update PropertyDetails set ContractAddress = '" + lbcontrAddr.Text + "' where Pid='" + lbp.Text + "' and Tid='" + lbt.Text + "'";
                            SqlCommand cmd = new SqlCommand(qu, con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "$('#Createmodal').modal({backdrop: 'static', keyboard: false},'show')", true);
                    }
                }
            }
            catch (Exception exxc)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msg", "alert('" + exxc + "')", true);
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "Select * from WalletDetails where LidTid='" + lid + "'";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lwname = ds.Tables[0].Rows[0][2].ToString();
                    lwpass = ds.Tables[0].Rows[0][4].ToString();
                    laccnm = ds.Tables[0].Rows[0][3].ToString();
                    lwaddr = ds.Tables[0].Rows[0][6].ToString();
                }
            }
            string date = DateTime.Now.ToString("dd MMMM yyyy");
            string contrAddr = lbcontrAddr.Text;
            var client = new RestClient("http://localhost:38223/api/SmartContracts/build-and-send-call");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");

            var body = @"{" + "\n" +
@"  ""amount"": ""0""," + "\n" +
@"  ""contractAddress"": """ + contrAddr + "\"," + "\n" +
@"  ""methodName"": ""CreateContract""," + "\n" +
@"  ""password"": """ + lwpass + "\"," + "\n" +
@"  ""sender"": """ + lwaddr + "\"," + "\n" +
@"  ""walletName"": """ + lwname + "\"," + "\n" +
@"  ""accountName"":""" + laccnm + "\"," + "\n" +
@"  ""outpoints"": null," + "\n" +
@"  ""feeAmount"": ""0.01""," + "\n" +
@"  ""gasPrice"": 100," + "\n" +
@"  ""gasLimit"": 250000," + "\n" +
@"  ""recipients"":null," + "\n" +
@"  ""parameters"":[" + "\n" +
@"      ""4#" + txtdur.Text + "\"," + "\n" +
@"      ""7#" + lbrnt.Text + "\"," + "\n" +
@"      ""4#" + lblocatn.Text + "\"," + "\n" +
@"      ""4#" + date + "\"," + "\n" +
@"      ""9#" + lbtwaddr.Text + "\"," + "\n" +
@"      ""7#" + txtdpst.Text + "\"," + "\n" +
@"      ""4# Created"" " + "\n" +
@"  ]," + "\n" +
@"  ""isInteropFeeForMultisig"": false" + "\n" +
@"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            //request.AddParameter("application/octet-stream", file, ParameterType.RequestBody);
            request.AddJsonBody(body);
            RestResponse response = client.Post(request);
            string res = response.StatusCode.ToString();
            // Lbstatus.Text = res;
            if (res.Contains("OK"))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgtype", "alert('Contract is Created!!!!')", true);
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string qu = "update PropertyDetails set Interest = 'Selected', ContractStat='Created', Deposite='" + txtdpst.Text + "' ,ContractAddress='" + lbcontrAddr.Text + "' where Pid='" + lbp.Text + "' and Tid='" + lbt.Text + "'";
                SqlCommand cmd = new SqlCommand(qu, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            gvBind();
        }

        protected void btnVContract_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string pid = row.Cells[1].Text;
            lbltid.Text = row.Cells[2].Text;
            lbltwadd.Text = row.Cells[8].Text;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "Select * from WalletDetails where LidTid='" + lid + "'";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lwname = ds.Tables[0].Rows[0][2].ToString();
                    lwpass = ds.Tables[0].Rows[0][4].ToString();
                    laccnm = ds.Tables[0].Rows[0][3].ToString();
                    lwaddr = ds.Tables[0].Rows[0][6].ToString();
                }

                q = "Select ContractAddress from PropertyDetails where Pid='" + pid + "'";
                da = new SqlDataAdapter(q, con);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    contractAddr = ds.Tables[0].Rows[0][0].ToString();

                }
            }
            var client = new RestClient("http://localhost:38223/api/SmartContracts/build-and-send-call");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");

            var body = @"{" + "\n" +
@"  ""amount"": ""0""," + "\n" +
@"  ""contractAddress"": """ + contractAddr + "\"," + "\n" +
@"  ""methodName"": ""ContractDetails""," + "\n" +
@"  ""password"": """ + lwpass + "\"," + "\n" +
@"  ""sender"": """ + lwaddr + "\"," + "\n" +
@"  ""walletName"":""" + lwname + "\"," + "\n" +
@"  ""accountName"":""" + laccnm + "\"," + "\n" +
@"  ""outpoints"": null," + "\n" +
@"  ""feeAmount"": ""0.01""," + "\n" +
@"  ""gasPrice"": 100," + "\n" +
@"  ""gasLimit"": 250000," + "\n" +
@"  ""recipients"":null," + "\n" +
@"  ""parameters"": null," + "\n" +
@"  ""isInteropFeeForMultisig"": false" + "\n" +
@"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            //request.AddParameter("application/octet-stream", file, ParameterType.RequestBody);
            request.AddJsonBody(body);
            RestResponse response = client.Post(request);
            string res = response.StatusCode.ToString();
            // Lbstatus.Text = res;
            if (res.Contains("OK"))
            {
                dynamic array = JsonConvert.DeserializeObject(response.Content);

                string transId = array.transactionId;

            again:
                System.Threading.Thread.Sleep(5000);

                //Get Contract Details
                client = new RestClient("http://localhost:38223/api/SmartContracts/receipt?txHash=" + transId + "");
                request = new RestRequest("http://localhost:38223/api/SmartContracts/receipt?txHash=" + transId + "", Method.Get);
                //request.AddParameter("application/octet-stream", file, ParameterType.RequestBody);
                response = client.Execute(request);
                res = response.StatusCode.ToString();
                // Lbstatus.Text = res;
                if (res.Contains("BadRequest"))
                {
                    goto again;
                }
                else if (res.Contains("OK"))
                {
                    //Get New Contract Address in response....
                    array = JsonConvert.DeserializeObject(response.Content);

                    string contractDetail = array.returnValue;
                    lbcnaddress.Text = contractAddr;

                    string[] cntrDet = contractDetail.Split(',');
                    Label[] lb = { lbl, lbldet1, lbldet2, lbldet3, lbl4, lbldet5, lbldet6, lbldet7, lbl1, lbldetail1, lbldetail2, lbldetail3, lbl4, lbldetail5, lbldetail6, lbldetail7 };
                    for (int i = 1; i < cntrDet.Length; i++)
                    {
                        string detail = cntrDet[i];
                        if (detail == "" || i == 4)
                        {
                            continue;
                        }
                        else
                        {
                            lb[i].Text = detail.Trim().Split(':')[0];
                            lb[i + 8].Text = detail.Trim().Split(':')[1];

                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "$('#Viewmodal').modal({backdrop: 'static', keyboard: false},'show')", true);

                }
            }
        }

        protected void btnTContract_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string lid = Session["Lid"].ToString();
                string q = "Select * from WalletDetails where LidTid='" + lid + "'";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lwname = ds.Tables[0].Rows[0][2].ToString();
                    lwpass = ds.Tables[0].Rows[0][4].ToString();
                    laccnm = ds.Tables[0].Rows[0][3].ToString();
                    lwaddr = ds.Tables[0].Rows[0][6].ToString();
                }
            }

            string contrAddr = "PEaCVKtrFsvGKYG4XZ7dTgbuXXeoHkLVuk";
            var client = new RestClient("http://localhost:38223/api/SmartContracts/build-and-send-call");
            var request = new RestRequest();

            request.AddHeader("Ocp-Apim-Subscription-Key", "a51697007d1b4ccab0b6a396e916b390");
            request.AddHeader("Content-Type", "application/json");

            var body = @"{" + "\n" +
@"  ""amount"": ""0""," + "\n" +
@"  ""contractAddress"": """ + contrAddr + "\"," + "\n" +
@"  ""methodName"": ""TerminateContract""," + "\n" +
@"  ""password"": """ + lwpass + "\"," + "\n" +
@"  ""sender"": """ + lwaddr + "\"," + "\n" +
@"  ""walletName"": " + lwname + "\"," + "\n" +
@"  ""accountName"": " + laccnm + "\"," + "\n" +
@"  ""outpoints"": null," + "\n" +
@"  ""feeAmount"": ""0.01""," + "\n" +
@"  ""gasPrice"": 100," + "\n" +
@"  ""gasLimit"": 250000," + "\n" +
@"  ""recipients"":null," + "\n" +
@"  ""parameters"":"": null," + "\n" +
@"  ""isInteropFeeForMultisig"": false" + "\n" +
@"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            //request.AddParameter("application/octet-stream", file, ParameterType.RequestBody);
            request.AddJsonBody(body);
            RestResponse response = client.Post(request);
            string res = response.StatusCode.ToString();
            // Lbstatus.Text = res;
            if (res.Contains("OK"))
            {
                //Get Contract Details
                Page.ClientScript.RegisterStartupScript(GetType(), "msgtype", "alert('Contract is Terminated!!!!')", true);
            }
        }
    }
}
