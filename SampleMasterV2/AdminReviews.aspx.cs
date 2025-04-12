using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace SampleMasterV2
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string sqlsmt = "select a.rev_id as [Review ID], b.user_fname+' '+b.user_lname as [Name],";
            sqlsmt += "a.rev_msg as [Review Message], a.rev_status as [Review Status]";
            sqlsmt += "from reviews_tbl as a, users_tbl as b where a.user_id=b.user_id";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            GridViewReviews.DataSource = dataTable;
            GridViewReviews.DataBind();
            conn.Close();
        }

        protected void txtRevid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
                constr += Server.MapPath("~/App_Data/inkpress_db.mdb");
                OleDbConnection conn = new OleDbConnection(constr);
                conn.Open();
                string sqlsmt = "select a.rev_id,b.user_fname,b.user_lname,c.order_id, a.rev_msg from reviews_tbl as a, users_tbl as b, orders_tbl as c where a.rev_id=" + txtRevid.Text + "and a.user_id=b.user_id;";

                OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
                OleDbDataReader dataReader = sqlcmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    txtName.Text = dataReader["user_fname"].ToString() + " " + dataReader["user_lname"].ToString();
                    txtOrderid.Text = dataReader["order_id"].ToString();
                    txtRevmsg.Text = dataReader["rev_msg"].ToString();
                    drpdwnStatus.Enabled = true;
                    btnUpdate.Visible = true;

                }
                conn.Close();
            }
            catch
            {
                Response.Write("<script>alert('Invalid RevID')</script>");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();
            string sqlsmt = "update reviews_tbl set rev_status='" + drpdwnStatus.SelectedValue + "' where rev_id=" + txtRevid.Text + ";";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
            sqlcmd.ExecuteNonQuery();

            sqlsmt = "select a.rev_id as [Review ID], b.user_fname+' '+b.user_lname as [Name],";
            sqlsmt += "a.rev_msg as [Review Message], a.rev_status as [Review Status]";
            sqlsmt += "from reviews_tbl as a, users_tbl as b where a.user_id=b.user_id";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            GridViewReviews.DataSource = dataTable;
            GridViewReviews.DataBind();

            conn.Close();
            txtRevid.Text = "";
            txtName.Text = "";
            txtOrderid.Text = "";
            txtRevmsg.Text = "";
            drpdwnStatus.SelectedValue = "Show";
        }


    }
}