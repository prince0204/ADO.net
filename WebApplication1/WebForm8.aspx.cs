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
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetEmployee_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string sqlQuery = "select * from tblEmployees where EmployeeId =" + txtEmployeeID.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlQuery, con);

                DataSet ds = new DataSet();
                da.Fill(ds, "Employees");

                ViewState["SQL_QUERY"] = sqlQuery;
                ViewState["DATASET"] = ds;

                if (ds.Tables["Employees"].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables["Employees"].Rows[0];
                    txtEmployeeName.Text = dr["Name"].ToString();
                    txtSalary.Text = dr["Salary"].ToString();
                    ddlGender.SelectedValue = dr["Gender"].ToString();

                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = ds.Tables["Employees"].Rows.Count.ToString() + " row(s) affected"; 
                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "No Record with Id = " + txtEmployeeID.Text;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand((string)ViewState["SQL_QUERY"], con);

                SqlCommandBuilder builder = new SqlCommandBuilder(da);

                DataSet ds = (DataSet)ViewState["DATASET"];

                if (ds.Tables["Employees"].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables["Employees"].Rows[0];
                    dr["Name"] = txtEmployeeName.Text;
                    dr["Salary"] = txtSalary.Text;
                    dr["Gender"] = ddlGender.SelectedValue;
                }
                int rowsUpdated = da.Update(ds, "Employees");
                if (rowsUpdated > 0)
                {
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = rowsUpdated.ToString() + " row(s) updated";
                }

                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = rowsUpdated.ToString() + " row(s) updated";
                }
            }
        }
    }
}