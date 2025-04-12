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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string sqlsmt = "SELECT DISTINCT checkout_tbl.checkout_id AS [Order ID], users_tbl.[user_fname]+[user_lname] AS Name, checkout_tbl.checkout_total AS Total, checkout_tbl.checkout_date AS [Date], checkout_tbl.checkout_status AS [Order Status], payment_tbl.payment_method AS [Payment Method], payment_tbl.payment_status AS [Payment Status], orderaddress_tbl.street+', '+orderaddress_tbl.barangay+', '+orderaddress_tbl.city+', '+orderaddress_tbl.province+', '+orderaddress_tbl.zipcode AS Address, orderaddress_tbl.contact_number AS [Number] ";
            sqlsmt += "FROM(((orderaddress_tbl INNER JOIN checkout_tbl ON orderaddress_tbl.checkout_id = checkout_tbl.checkout_id) INNER JOIN orders_tbl ON checkout_tbl.checkout_id = orders_tbl.checkout_id) INNER JOIN payment_tbl ON checkout_tbl.checkout_id = payment_tbl.checkout_id) INNER JOIN users_tbl ON checkout_tbl.user_id = users_tbl.user_id;";

            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            GridViewOrders.DataSource = dataTable;
            GridViewOrders.DataBind();
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
                string sqlsmt = "select checkout_id,user_id,checkout_total, checkout_status from checkout_tbl as a where checkout_id=" + txtOrderid.Text + ";";

                OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
                OleDbDataReader dataReader = sqlcmd.ExecuteReader();
                if (dataReader.HasRows && txtOrderid.Text != "")
                {
                    dataReader.Read();
                    txtOrderid.Text = dataReader["checkout_id"].ToString();
                    txtUserid.Text = dataReader["user_id"].ToString();
                    drpdwnStatus.Text = dataReader["checkout_status"].ToString();

                    sqlsmt = "SELECT checkout_tbl.checkout_id as [Order ID], product_tbl.prod_name as [Product], product_tbl.prod_category as [Category],";
                    sqlsmt += "product_tbl.prod_size as [Size], product_tbl.prod_gsm as [GSM], product_tbl.prod_price as [Price], orders_tbl.order_qty as [Quantity], orders_tbl.order_total as [Total] FROM(checkout_tbl ";
                    sqlsmt += "INNER JOIN orders_tbl ON checkout_tbl.checkout_id = orders_tbl.checkout_id) INNER JOIN product_tbl ON orders_tbl.prod_id = product_tbl.prod_id ";
                    sqlsmt += "WHERE checkout_tbl.checkout_id=" + txtOrderid.Text + ";";
                    GridViewOrderD.Visible = true;
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    GridViewOrderD.DataSource = dataTable;
                    GridViewOrderD.DataBind();

                    drpdwnStatus.Enabled = true;
                    drpdwnPayment.Enabled = true;
                    btnUpdate.Visible = true;
                }
                else
                {
                    btnUpdate.Visible = false;
                    txtUserid.Text = "";

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

            string sqlsmt = "update checkout_tbl set checkout_status='"+drpdwnStatus.SelectedValue+"' where checkout_id="+txtOrderid.Text+";";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
            sqlcmd.ExecuteNonQuery();

            sqlsmt = "update payment_tbl set payment_status='" + drpdwnPayment.SelectedValue + "' where checkout_id=" + txtOrderid.Text + ";";
            sqlcmd = new OleDbCommand(sqlsmt, conn);
            sqlcmd.ExecuteNonQuery();

            txtOrderid.Text = "";
            txtUserid.Text = "";

            Response.Write("<script>alert('Order has been updated')</script>");

            sqlsmt = "select a.checkout_id as [Checkout ID], a.user_id as [User ID], a.checkout_total as [Total], a.checkout_date as [Date], a.checkout_status as [Order Status], b.payment_method as [Payment Method], b.payment_status as [Payment Status]from checkout_tbl as a, payment_tbl as b where a.checkout_id=b.checkout_id;";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            GridViewOrders.DataSource = dataTable;
            GridViewOrders.DataBind();
            conn.Close();
        }
    }
}