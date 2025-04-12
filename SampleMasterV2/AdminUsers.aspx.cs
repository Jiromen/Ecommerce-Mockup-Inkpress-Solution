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
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string sqlsmt = "select a.user_id as [User Number], a.user_fname as [First Name], a.user_lname as [Last Name],";
            sqlsmt += "a.user_telnum as [Telephone Number], b.add_street+','+b.add_barangay+','+b.add_city+','+b.add_province+','+b.add_zip as [Address],";
            sqlsmt += "a.user_email as [Email], a.user_status as [Status] ";
            sqlsmt += "from users_tbl as a, useraddress_tbl as b where a.user_id=b.add_id";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            GridViewUsers.DataSource = dataTable;
            GridViewUsers.DataBind();
            conn.Close();
        }

        protected void txtUserid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
                constr += Server.MapPath("~/App_Data/inkpress_db.mdb");
                OleDbConnection conn = new OleDbConnection(constr);
                conn.Open();
                string sqlsmt = "select user_id,user_fname,user_lname,user_telnum,user_email,user_role from users_tbl where user_id=" + txtUserid.Text + ";";

                OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
                OleDbDataReader dataReader = sqlcmd.ExecuteReader();
                if (dataReader.HasRows && txtUserid.Text != "")
                {
                    dataReader.Read();
                    txtUsername.Text = dataReader["user_fname"].ToString() + " " + dataReader["user_lname"].ToString();
                    txtTelnum.Text = dataReader["user_telnum"].ToString();
                    txtEmail.Text = dataReader["user_email"].ToString();
                    txtRole.Text = dataReader["user_role"].ToString();
                    drpdwnStatus.Enabled = true;
                    btnUpdate.Visible = true;

                }
                else
                {
                    txtUserid.Text = "";
                    txtUsername.Text = "";
                    txtTelnum.Text = "";
                    txtEmail.Text = "";
                    txtRole.Text = "";
                }
                conn.Close();
            }
            catch
            {
                Response.Write("<script>alert('Invalid Order ID')</script>");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string sqlsmt = "update users_tbl set user_status='" + drpdwnStatus.SelectedValue + "' where user_id=" + txtUserid.Text + ";";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
            sqlcmd.ExecuteNonQuery();

            sqlsmt = "select a.user_id as [User Number], a.user_fname as [First Name], a.user_lname as [Last Name],";
            sqlsmt += "a.user_telnum as [Telephone Number], b.add_street+','+b.add_barangay+','+b.add_city+','+b.add_province+','+b.add_zip as [Address],";
            sqlsmt += "a.user_email as [Email], a.user_status as [Status] ";
            sqlsmt += "from users_tbl as a, useraddress_tbl as b where a.user_id=b.add_id";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            GridViewUsers.DataSource = dataTable;
            GridViewUsers.DataBind();

            conn.Close();
            txtUserid.Text = "";
            txtUsername.Text = "";
            txtTelnum.Text = "";
            txtEmail.Text = "";
            txtRole.Text = "";
        }
    }
}