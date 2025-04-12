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
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string sqlsmt = "SELECT checkout_tbl.checkout_id as [Order ID], checkout_tbl.checkout_total as [Total], payment_tbl.payment_method as [Payment Method], checkout_tbl.checkout_date as [Date], checkout_tbl.checkout_status as [Status] FROM checkout_tbl INNER JOIN payment_tbl ON checkout_tbl.checkout_id = payment_tbl.checkout_id WHERE checkout_tbl.user_id="+Session["user_id"]+";";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);
            DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
            GridViewOrder.DataSource = dataTable;
            GridViewOrder.DataBind();
            conn.Close();
        }

        protected void btnReview_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReviewForm.aspx");
        }

        protected void btnInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeInfo.aspx");
        }

        protected void txtOrderid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
                constr += Server.MapPath("~/App_Data/inkpress_db.mdb");
                OleDbConnection conn = new OleDbConnection(constr);
                conn.Open();
                string sqlsmt = "select checkout_id from checkout_tbl where checkout_id=" + txtOrderid.Text + " and user_id=" + Session["user_id"] + ";";

                OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
                OleDbDataReader dataReader = sqlcmd.ExecuteReader();
                if (dataReader.HasRows && txtOrderid.Text != "")
                {
                    sqlsmt = "SELECT checkout_tbl.checkout_id as [Order ID], product_tbl.prod_name as [Product], product_tbl.prod_category as [Category],";
                    sqlsmt += "product_tbl.prod_size as [Size], product_tbl.prod_gsm as [GSM], product_tbl.prod_price as [Price], orders_tbl.order_qty as [Quantity], orders_tbl.order_total as [Total] FROM(checkout_tbl ";
                    sqlsmt += "INNER JOIN orders_tbl ON checkout_tbl.checkout_id = orders_tbl.checkout_id) INNER JOIN product_tbl ON orders_tbl.prod_id = product_tbl.prod_id ";
                    sqlsmt += "WHERE checkout_tbl.user_id=" + Session["user_id"] + " and checkout_tbl.checkout_id=" + txtOrderid.Text + ";";
                    GridViewOrderD.Visible = true;
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    GridViewOrderD.DataSource = dataTable;
                    GridViewOrderD.DataBind();
                }
                else
                {
                    txtOrderid.Text = "";
                    GridViewOrderD.Visible = false;
                }
                conn.Close();
            }
            catch
            {
                Response.Write("<script>alert('Invalid Order ID')</script>");
            }
        }
    }
}