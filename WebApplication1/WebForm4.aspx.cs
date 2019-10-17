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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select EmployeeId, Name, Gender, Salary from tblEmployees";
                cmd.Connection = con;
                con.Open();
                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    DataTable sourceTable = new DataTable();
                    sourceTable.Columns.Add("Id");
                    sourceTable.Columns.Add("Name");
                    sourceTable.Columns.Add("Gender");
                    sourceTable.Columns.Add("Salary");

                    while (rdr.Read())
                    {
                        //Calculate the 10% discounted price
                        int OriginalSalary = Convert.ToInt32(rdr["Salary"]);
                        double DiscountedSalary = OriginalSalary * 0.9;

                        // Populate datatable column values from the SqlDataReader
                        DataRow datarow = sourceTable.NewRow();
                        datarow["ID"] = Convert.ToInt32(rdr["EmployeeId"]);
                        datarow["Name"] = rdr["Name"];
                        datarow["Gender"] = rdr["Gender"];
                        datarow["Salary"] = DiscountedSalary;

                        //Add the DataRow to the DataTable
                        sourceTable.Rows.Add(datarow);
                    }
                    GridView1.DataSource = sourceTable;
                    GridView1.DataBind();
                }

            }
            }
    }
}