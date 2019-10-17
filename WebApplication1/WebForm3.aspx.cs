using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spAddEmployee";
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Gender", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@Salary", TextBox2.Text);

                SqlParameter outPutParam = new SqlParameter();
                outPutParam.ParameterName = "@EmployeeId";
                outPutParam.SqlDbType = System.Data.SqlDbType.Int;
                outPutParam.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outPutParam);
                con.Open();
                cmd.ExecuteNonQuery();

                string EmployeeId = outPutParam.Value.ToString();
                Label4.Text = "Employee Id = " + EmployeeId;
            }
            }
    }
}