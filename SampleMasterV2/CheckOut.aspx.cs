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
    public partial class CheckOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string sqlsmt = "select a.prod_id as [Product ID], b.prod_name as [Product Name], a.order_qty as [Order Qty], a.order_total as [Order Total] from orders_tbl as a, product_tbl as b where a.prod_id=b.prod_id and order_status='Cart';";

            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, constr);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            GridViewCart.DataSource = dataTable;
            GridViewCart.DataBind();

            sqlsmt = "select sum(order_total) as [total] from orders_tbl where user_id=" + Session["user_id"] + "and order_status='Cart';";

            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
            OleDbDataReader dataReader = sqlcmd.ExecuteReader();

            dataReader.Read();
            txtTotal.Text = dataReader["total"].ToString();


            try
            {
                sqlsmt = "select a.user_fname,a.user_lname,a.user_telnum,b.add_street,b.add_barangay,b.add_city,b.add_province,b.add_zip from users_tbl as a, useraddress_tbl as b where a.user_id = b.user_id and a.user_id=" + Session["user_id"] + ";";

                sqlcmd = new OleDbCommand(sqlsmt, conn);
                dataReader = sqlcmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    txtfirstname.Text = dataReader["user_fname"].ToString();
                    txtlastname.Text = dataReader["user_lname"].ToString();
                    txtnumber.Text = dataReader["user_telnum"].ToString();
                    txtstreet.Text = dataReader["add_street"].ToString();
                    txtbrgy.Text = dataReader["add_barangay"].ToString();
                    txtcity.Text = dataReader["add_city"].ToString();
                    txtprovince.Text = dataReader["add_province"].ToString();
                    txtzip.Text = dataReader["add_zip"].ToString();

                }
                conn.Close();
            }
            catch
            {
                Response.Write("<script>alert('Please Login Before Placing Order')</script>");
            }

            conn.Close();
        }

        protected void PlaceOrderBtn_Click(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();
            DateTime now = DateTime.Now;
            string datenow = now.ToString("MM/dd/yyyy h:mm:ss tt");

            string sqlsmt = "select sum(order_total) as [total] from orders_tbl where user_id=" + Session["user_id"] + "and order_status='Cart';";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
            OleDbDataReader dataReader = sqlcmd.ExecuteReader();

            dataReader.Read();
            string total = dataReader["total"].ToString();

            int totalint = int.Parse(total);
            string insertsql = "insert into checkout_tbl(checkout_date,user_id,checkout_total,checkout_status) values('";
            insertsql += datenow + "'," + Session["user_id"] + "," + totalint + ",'Processing');";

            OleDbCommand insertcmd = new OleDbCommand(insertsql, conn);
            insertcmd.ExecuteNonQuery();

            string selectsql = "select top 1 checkout_id from checkout_tbl where user_id =" +Session["user_id"]+ " order by checkout_date desc;";
            sqlcmd = new OleDbCommand(selectsql, conn);
            dataReader = sqlcmd.ExecuteReader();

            dataReader.Read();
            string checkout_id = dataReader["checkout_id"].ToString();

            string insertsql1 = "insert into  orderaddress_tbl(checkout_id,firstname,lastname,street,barangay,city,province,zipcode,contact_number) values(";
            insertsql1 += checkout_id + ",'" + txtfirstname.Text + "','" + txtlastname.Text + "','" + txtstreet.Text + "','";
            insertsql1 += txtbrgy.Text + "','" + txtcity.Text + "','" + txtprovince.Text + "','" + txtzip.Text + "','" + txtnumber.Text + "');";

            OleDbCommand insertcmd1 = new OleDbCommand(insertsql1, conn);
            insertcmd1.ExecuteNonQuery();

            int ch = int.Parse(checkout_id);
            insertsql1 = "insert into payment_tbl (checkout_id, user_id, payment_method, payment_accnum, payment_status) values (" + ch + "," + Session["user_id"] + ",'" + drpdwnPayment.SelectedValue+ "','" + txtaccnum.Text + "','Processing');";
            insertcmd1 = new OleDbCommand(insertsql1, conn);
            insertcmd1.ExecuteNonQuery();

            string updatesql = "update stocks_tbl as s inner join orders_tbl as o on s.prod_id = o.prod_id set s.stock_qty = s.stock_qty - o.order_qty where s.prod_id = o.prod_id and o.order_status = 'Cart' and user_id = " + Session["user_id"] + "; ";

            OleDbCommand updatecmd = new OleDbCommand(updatesql, conn);
            updatecmd.ExecuteNonQuery();

            /* Code that will update product to not available when less than or equal to stocks_safetylvl"*/

            updatesql = "update product_tbl as p inner join stocks_tbl as s on p.prod_id=s.prod_id set p.prod_status='Not Available' where p.prod_id=s.prod_id and s.stock_qty<=s.stock_safetylvl;";

            updatecmd = new OleDbCommand(updatesql, conn);
            updatecmd.ExecuteNonQuery();

            updatesql = "update orders_tbl set checkout_id=" + checkout_id + ", order_status='Check Out' where user_id=" + Session["user_id"] + " and order_status='Cart';";

            updatecmd = new OleDbCommand(updatesql, conn);
            updatecmd.ExecuteNonQuery();

            Response.Write("<script>alert('Order Placed Successfuly')</script>");
            Response.Redirect("Profile.aspx");

        }

        protected void drpdwnPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

            OleDbConnection conn = new OleDbConnection(constr);
            var pmethod = drpdwnPayment.SelectedValue.ToString();

            if (pmethod == "Cash")
            {
                txtaccnum.Enabled = false;
                txtaccnum.Text = "None";

            }
            else
            {
                txtaccnum.Text = "";
                txtaccnum.Enabled = true;

            }

        }
    }
}