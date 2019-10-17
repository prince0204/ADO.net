using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("select * from tblEmployees; select * from tblPerson", con);

                DataSet ds = new DataSet();
                da.Fill(ds);

                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();

                GridView2.DataSource = ds.Tables[1];
                GridView2.DataBind();
            }
            }
    }
}