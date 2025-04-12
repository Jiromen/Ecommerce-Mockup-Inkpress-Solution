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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string connstr = "Provider=Microsoft.Jet.Oledb.4.0; Data Source=";
            connstr += Server.MapPath("~/App_Data/inkpress_db.mdb");
            OleDbConnection connection = new OleDbConnection(connstr);
            connection.Open();

            string insertsql = "insert into  users_tbl(user_lname,user_fname,user_telnum,user_email,user_password,user_status,user_role) values('";
            insertsql += txtlastname.Text + "','" + txtfirstname.Text + "','" + txtnumber.Text + "','";
            insertsql += txtemail.Text + "','" + txtpassword.Text + "' ,'Active','User');";
            
            OleDbCommand insertcmd = new OleDbCommand(insertsql, connection);
            insertcmd.ExecuteNonQuery();

            string sqlsmt = "select user_id from users_tbl where user_email='" + txtemail.Text + "'and user_password='" + txtpassword.Text + "';";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, connection);
            OleDbDataReader dataReader = sqlcmd.ExecuteReader();

            dataReader.Read();
            string user_id = dataReader["user_id"].ToString();

            string insertsql1 = "insert into  useraddress_tbl(user_id,add_street,add_city,add_province,add_zip,add_barangay) values('";
            insertsql1 += user_id + "','" + txtstreet.Text + "','" +  txtcity.Text + "','";
            insertsql1 += txtprovince.Text + "','" + txtzip.Text+ "','" + txtbrgy.Text + "');";

            OleDbCommand insertcmd1 = new OleDbCommand(insertsql1, connection);
            insertcmd1.ExecuteNonQuery();

            connection.Close();

            txtlastname.Text = "";
            txtbrgy.Text = "";
            txtcity.Text = "";
            txtemail.Text = "";
            txtfirstname.Text = "";
            txtnumber.Text = "";
            txtprovince.Text = "";
            txtpassword.Text = "";
            txtstreet.Text = "";
            txtzip.Text = "";
            Response.Write("<script>alert('Success! You may now login')</script>");

           
        }
        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            txtlastname.Text = "";
            txtbrgy.Text = "";
            txtcity.Text = "";
            txtemail.Text = "";
            txtfirstname.Text = "";
            txtpassword.Text = "";
            txtnumber.Text = "";
            txtprovince.Text = "";
            txtstreet.Text = "";
            txtzip.Text = "";
        }
    }
   
}