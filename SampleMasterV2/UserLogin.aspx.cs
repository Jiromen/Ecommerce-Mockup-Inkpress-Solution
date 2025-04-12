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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string connstr = "Provider=Microsoft.Jet.Oledb.4.0; Data Source=";
            connstr += Server.MapPath("~/App_Data/inkpress_db.mdb");
            OleDbConnection connection = new OleDbConnection(connstr);
            connection.Open();

            string sqlsmt = "select * from users_tbl where user_email='" + txtemail.Text + "'and user_password='" + txtpassword.Text + "'and user_status='Active';";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, connection);
            OleDbDataReader dataReader = sqlcmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Response.Write("<script>alert('" + dataReader.GetValue(2).ToString() + "';</script>");
                    Session["user_email"] = dataReader.GetValue(5).ToString();
                    Session["user_password"] = dataReader.GetValue(6).ToString();
                    Session["user_id"] = dataReader.GetValue(0).ToString();
                    Session["user_fname"] = dataReader.GetValue(2).ToString();
                    Session["user_role"] = dataReader.GetValue(7).ToString();
                    txtemail.Text = "";
                    Label2.Visible = false;
                }
                    Response.Redirect("HomePage.aspx");
             }
            else
            {
                Label2.Visible = true;
            }
        }

    }
}