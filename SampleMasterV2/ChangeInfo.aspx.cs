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
    public partial class ChangeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
                constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

                OleDbConnection conn = new OleDbConnection(constr);
                string sqlsmt;
                UpdateBtn.Enabled = false;
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                try
                {
                    constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
                    constr += Server.MapPath("~/App_Data/inkpress_db.mdb");
                    conn = new OleDbConnection(constr);
                    conn.Open();
                    sqlsmt = "select a.user_fname,a.user_lname,a.user_telnum,a.user_email,b.add_street,b.add_barangay,b.add_city,b.add_province,b.add_zip from users_tbl as a, useraddress_tbl as b where a.user_id = b.user_id and a.user_id=" + Session["user_id"] + ";";

                    OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
                    OleDbDataReader dataReader = sqlcmd.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        txtfirstname.Text = dataReader["user_fname"].ToString();
                        txtlastname.Text = dataReader["user_lname"].ToString();

                        txtfirstname.Enabled = false;
                        txtlastname.Enabled = false;
                        txtnumber.Enabled = false;
                        txtemail.Enabled = false;
                        txtstreet.Enabled = false;
                        txtbrgy.Enabled = false;
                        txtcity.Enabled = false;
                        txtprovince.Enabled = false;
                        txtzip.Enabled = false;
                        UpdateBtn.Visible = false;

                    }
                    conn.Close();
                }
                catch
                {
                    Response.Write("<script>alert('Please Login Before Ordering')</script>");

                }

            }
           
        }
        protected void ChangeBtn_Click(object sender, EventArgs e)
        {
            txtstreet.Enabled = true;
            txtbrgy.Enabled = true;
            txtcity.Enabled = true;
            txtprovince.Enabled = true;
            txtzip.Enabled = true;
            txtemail.Enabled = true;
            txtnumber.Enabled = true;
            UpdateBtn.Visible = true;
            UpdateBtn.Enabled = true;
        }
        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string sqlsmt = "update users_tbl set user_telnum='" + txtnumber.Text+ "',user_email= '"+txtemail.Text+"' where user_id=" + Session["user_id"] + ";";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
            sqlcmd.ExecuteNonQuery();

            sqlsmt = "update useraddress_tbl set add_street='" + txtstreet.Text + "',add_barangay= '" + txtbrgy.Text + "',add_city='"+txtcity.Text+"',add_province='"+txtcity.Text+"',add_zip='"+txtzip.Text+"' where user_id=" + Session["user_id"] + ";";
            sqlcmd = new OleDbCommand(sqlsmt, conn);
            sqlcmd.ExecuteNonQuery();

            conn.Close();

            Response.Write("<script>alert('Your information has been updated!')</script>");
        }
    }
   
}