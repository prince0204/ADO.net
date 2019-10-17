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
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetDataFromDB()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string sqlQuery = "select * from tblEmployees";
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlQuery, con);

                DataSet ds = new DataSet();
                da.Fill(ds, "Employees");

                ds.Tables["Employees"].PrimaryKey = new DataColumn[] { ds.Tables["Employees"].Columns["EmployeeId"] };
                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);

                gvEmployees.DataSource = ds;
                gvEmployees.DataBind();

                lblStatus.Text = "Data loaded from Database";

            }

        }
        public void GetDataFromCache()
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                gvEmployees.DataSource = ds;
                gvEmployees.DataBind();
            }
        }

        protected void btnGetDataFromDB_Click(object sender, EventArgs e)
        {
            GetDataFromDB();
        }

        protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmployees.EditIndex = e.NewEditIndex;
            GetDataFromCache();
        }

        protected void gvEmployees_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEmployees.EditIndex = -1;
            GetDataFromCache();
        }

        protected void gvEmployees_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                DataRow dr = ds.Tables["Employees"].Rows.Find(e.Keys["EmployeeId"]);
                dr["Name"] = e.NewValues["Name"];
                dr["Gender"] = e.NewValues["Gender"];
                dr["Salary"] = e.NewValues["Salary"];

                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                gvEmployees.EditIndex = -1;
                GetDataFromCache();
            }
        }

        protected void gvEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            DataRow dr = ds.Tables["Employees"].Rows.Find(e.Keys["EmployeeId"]);
            dr.Delete();

            Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
            GetDataFromCache();
        }

        protected void btnUpdateDatabaseTable_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string sqlQuery = "select * from tblEmployees";
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlQuery, con);

                DataSet ds = (DataSet)Cache["DATASET"];

                string strUpdateCommand = "update tblEmployees set Name= @Name, Gender=@Gender, Salary=@Salary where EmployeeId = @EmployeeId";
                SqlCommand updateCommand = new SqlCommand(strUpdateCommand, con);
                updateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
                updateCommand.Parameters.Add("@Gender", SqlDbType.NVarChar, 20, "Gender");
                updateCommand.Parameters.Add("@Salary", SqlDbType.Int, 0, "Salary");
                updateCommand.Parameters.Add("@EmployeeId", SqlDbType.Int, 0, "EmployeeId");
                da.UpdateCommand = updateCommand;

                string strDeleteCommand = "Delete from tblEmployees where EmployeeId = @EmployeeId";
                SqlCommand deleteCommand = new SqlCommand(strDeleteCommand, con);
                deleteCommand.Parameters.Add("@EmployeeId", SqlDbType.Int, 0, "EmployeeId");
                da.DeleteCommand = deleteCommand;

                da.Update(ds, "Employees");


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            //DataRow newDataRow = ds.Tables["Employees"].NewRow();
            //newDataRow["EmployeeId"] = 101;
            //ds.Tables["Employees"].Rows.Add(newDataRow);
            /*foreach(DataRow dr in ds.Tables["Employees"].Rows)
            {
                if (dr.RowState == DataRowState.Deleted)
                {
                    Response.Write(dr["EmployeeId",DataRowVersion.Original].ToString() + "-" + dr.RowState.ToString() + "<br/>");
                }
                else
                {
                    Response.Write(dr["EmployeeId"].ToString() + "-" + dr.RowState.ToString() + "<br/>");
                }
                }
            Response.Write(newDataRow.RowState.ToString());*/
            /*if (ds.HasChanges())
            {
                ds.RejectChanges();
                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                GetDataFromCache();
                lblStatus.Text = "Changes Undone";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = "No Changes to undo";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }*/
             if (ds.HasChanges())
            {
                ds.AcceptChanges();
                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                GetDataFromCache();
            }
            }
        
    }
}