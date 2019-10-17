using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] == null)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = new SqlCommand("select * from tblEmployees", con);

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    Cache["Data"] = ds;

                    GridView1.DataSource = Cache["Data"];
                    GridView1.DataBind();
                    Label1.Text = "Data is loaded from database";

                }
            }
            else
            {
                GridView1.DataSource = Cache["Data"];
                GridView1.DataBind();
                Label1.Text = "Data is loaded from Cache";
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] != null)
            {
                Cache.Remove("Data");
                Label1.Text = "Cache is cleared";
            }
            else
            {
                Label1.Text = "No Data is present in cache";
            }
        }
    }
}
