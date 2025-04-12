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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string sqlsmt = "select checkout_id as [Order ID],checkout_total as [Total], checkout_status as [Status] from checkout_tbl where checkout_status='Done';";

            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            GridViewOrder.DataSource = dataTable;
            GridViewOrder.DataBind();
            conn.Close();

        }

        protected void txtOrderid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
                constr += Server.MapPath("~/App_Data/inkpress_db.mdb");
                OleDbConnection conn = new OleDbConnection(constr);
                conn.Open();
                string sqlsmt = "select a.checkout_id from checkout_tbl as a where a.checkout_id=" + txtOrderid.Text + "and a.user_id=" + Session["user_id"] + ";";

                OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
                OleDbDataReader dataReader = sqlcmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    txtRevmsg.Enabled = true;
                }
                else
                {
                    txtRevmsg.Enabled = false;
                }
                conn.Close();
            }
            catch
            {
                Response.Write("<script>alert('Invalid value')</script>");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
                string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();
            string sqlsmt = "insert into reviews_tbl(user_id,order_id,rev_msg,rev_status)values ("+Session["user_id"]+",'"+txtOrderid.Text+"','"+txtRevmsg.Text+"','Hidden');";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
            sqlcmd.ExecuteNonQuery();


            conn.Close();
            txtOrderid.Text = "";
            txtRevmsg.Text = "";
        }
    }
}