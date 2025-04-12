using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Threading;

namespace SampleMasterV2
{
    public partial class Cart: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string sqlsmt = "SELECT orders_tbl.order_id as [Order ID], product_tbl.prod_name as [Product Name], product_tbl.prod_category as [Category],";
            sqlsmt += "product_tbl.prod_size as [Size], product_tbl.prod_gsm as [GSM], orders_tbl.order_qty as [Quantity], orders_tbl.order_total as [Total] ";
            sqlsmt += "FROM orders_tbl INNER JOIN product_tbl ON orders_tbl.prod_id = product_tbl.prod_id WHERE orders_tbl.user_id="+Session["user_id"]+" and orders_tbl.order_status='Cart';";

            /*string sqlsmt = "select order_id as [Order ID], prod_id as [Product ID], order_qty as [Quantity],";
            sqlsmt += "order_total as [Total] ";
            sqlsmt += "from orders_tbl where user_id=" + Session["user_id"] +" and order_status='Cart';";*/

            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
            OleDbDataReader dataReader = sqlcmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, constr);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                GridViewCart.DataSource = dataTable;
                GridViewCart.DataBind();
                UpdateBtn.Visible = false;
                DeleteBtn.Visible = false;

            }
            else
            {
                Response.Write("<script>alert('Please add items to your cart before proceeding to checkout')</script>");
                Response.Redirect("OrderForm.aspx");
            }


            conn.Close();
        }

        protected void txtprodid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
                constr += Server.MapPath("~/App_Data/inkpress_db.mdb");
                OleDbConnection conn = new OleDbConnection(constr);
                conn.Open();
                //add where user_id=Session["user_id"], order_status = Cart
                string sqlsmt = "select order_qty,order_total from orders_tbl where order_id=" + txtprodid.Text + " and user_id = " + Session["user_id"] + "and order_status='Cart';";

                OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
                OleDbDataReader dataReader = sqlcmd.ExecuteReader();

                if (dataReader.HasRows && txtprodid.Text != "")
                {
                    dataReader.Read();
                    txtqty.Text = dataReader["order_qty"].ToString();
                    txttotal.Text = dataReader["order_total"].ToString();
                    txtqty.Enabled = true;
                    DeleteBtn.Visible = true;
                    UpdateBtn.Visible = true;
                    CheckOutBtn.Visible = true;

                }
                else
                {
                    txtqty.Text = "";
                    txttotal.Text = "";
                    txtqty.Enabled = false;
                    CheckOutBtn.Visible = false;
                }
                conn.Close();
            }
            catch
            {
                Response.Write("<script>alert('Invalid Order ID')</script>");
            }
        }

        protected void txtqty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
                constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

                OleDbConnection conn = new OleDbConnection(constr);
                conn.Open();

                //add where user_id=Session["user_id"]
                string sqlsmt1 = "select prod_price from product_tbl where prod_id in (select prod_id from orders_tbl where order_id=" + txtprodid.Text + ");";
                OleDbCommand sqlcmd1 = new OleDbCommand(sqlsmt1, conn);
                OleDbDataReader dataReader = sqlcmd1.ExecuteReader();
                if (dataReader.HasRows && txtqty.Text != "")
                {
                    dataReader.Read();
                    string prd_price = dataReader["prod_price"].ToString();

                    int prod_price = int.Parse(prd_price);
                    int qty = int.Parse(txtqty.Text);
                    int total = prod_price * qty;
                    txttotal.Text = total.ToString();

                    CheckOutBtn.Visible = true;
                    UpdateBtn.Visible = true;
                    DeleteBtn.Visible = true;
                }
                else
                {
                    txtqty.Text = "";
                    txttotal.Text = "";
                    txtqty.Enabled = false;
                    CheckOutBtn.Visible = false;
                    UpdateBtn.Visible = false;
                    DeleteBtn.Visible = false;
                }

                conn.Close();

                UpdateBtn.Enabled = true;
            }
            catch
            {
                Response.Write("<script>alert('Invalid Value')</script>");
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            //add where user_id=Session["user_id"]
            string updatesql = "update orders_tbl set order_qty=" + txtqty.Text + ", order_total=" + txttotal.Text + " where order_id=" + txtprodid.Text + ";";

            OleDbCommand updatecmd = new OleDbCommand(updatesql, conn);
            updatecmd.ExecuteNonQuery();

            conn.Close();

            txtprodid.Text = "";
            txtqty.Text = "";
            txttotal.Text = "";
            txtqty.Enabled = false;

            Response.Redirect("Cart.aspx");
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            //add where user_id=Session["user_id"]
            string deletesql = "delete from orders_tbl where order_id=" + txtprodid.Text + " and user_id = " + Session["user_id"] + ";";

            OleDbCommand deletecmd = new OleDbCommand(deletesql, conn);
            deletecmd.ExecuteNonQuery();

            //add where user_id=Session["user_id"]
            string sqlsmt = "select prod_id as [Product Number], order_qty as [Quantity],";
            sqlsmt += "order_total as [Total]";
            sqlsmt += "from orders_tbl where user_id = " + Session["user_id"] + ";";

            conn.Close();

            txtprodid.Text = "";
            txtqty.Text = "";
            txttotal.Text = "";
            txtqty.Enabled = false;

            Response.Redirect("Cart.aspx");
        }

        protected void CheckOutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckOut.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderForm.aspx");
        }
    }
}