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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            try
            {
                string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
                constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

                OleDbConnection conn = new OleDbConnection(constr);
                conn.Open();
                string sqlsmt = "select prod_id as [ID], prod_name as [Product Name],";
                sqlsmt += "prod_size as [Size], prod_gsm as [GSM],prod_price as [Price] ";
                sqlsmt += "from product_tbl;";

                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, constr);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                GridViewProducts.DataSource = dataTable;
                GridViewProducts.DataBind();
            }
            catch
            {
                Response.Write("<script>alert('Please Login Before Ordering')</script>");
                Response.Redirect("OrderForm.aspx");

            }

        }

        protected void addCart_Click(object sender, EventArgs e)
        {
            string connstr = "Provider=Microsoft.Jet.Oledb.4.0; Data Source=";
            connstr += Server.MapPath("~/App_Data/inkpress_db.mdb");
            OleDbConnection connection = new OleDbConnection(connstr);
            connection.Open();

            string sqlsmt = "select prod_status from product_tbl where prod_id=+" + drpdwnProduct.SelectedValue + ";";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, connection);
            OleDbDataReader dataReader = sqlcmd.ExecuteReader();

            dataReader.Read();
            string prod_status = dataReader["prod_status"].ToString();

            if (prod_status == "Available")
            {
                sqlsmt = "insert into orders_tbl(user_id,prod_id,order_qty,order_total,order_status) values(" + Session["user_id"] + "," + drpdwnProduct.SelectedValue + "," + txtquantity.Text + "," + txtTotal.Text + ",'Cart');";

                OleDbCommand insertcmd = new OleDbCommand(sqlsmt, connection);
                insertcmd.ExecuteNonQuery();

                txtquantity.Text = "";
                txtTotal.Text = "";
                addCart.Visible = false;
                Response.Write("<script>alert('Added to cart')</script>");
            }
            else
            {
                txtquantity.Text = "";
                txtTotal.Text = "";
                addCart.Visible = false;
                Response.Write("<script>alert('Product Out of Stock or Not Available')</script>");
            }


        }

        protected void txtquantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string connstr = "Provider=Microsoft.Jet.Oledb.4.0; Data Source=";
                connstr += Server.MapPath("~/App_Data/inkpress_db.mdb");
                OleDbConnection connection = new OleDbConnection(connstr);
                connection.Open();

                string sqlsmt = "Select prod_price from product_tbl where prod_id=" + drpdwnProduct.SelectedValue + ";";

                OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, connection);
                OleDbDataReader dataReader = sqlcmd.ExecuteReader();

                if (dataReader.HasRows && txtquantity.Text != "")
                {
                    dataReader.Read();
                    var num1 = dataReader["prod_price"].ToString();
                    int price = int.Parse(num1);
                    int qty = int.Parse(txtquantity.Text);
                    int total = price * qty;
                    txtTotal.Text = total.ToString();
                    addCart.Enabled = true;
                    txtTotal.Visible = true;
                    addCart.Visible = true;
                }
                else
                {
                    txtquantity.Text = "";
                    txtTotal.Text = "";
                    addCart.Enabled = false;
                    txtTotal.Visible = true;
                    addCart.Visible = true;
                }


                connection.Close();
            }
            catch
            {
                Response.Write("<script>alert('You have entered an invalid value, Try again')</script>");
            }
            
        }

        protected void goCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }
    }
}