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
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string sqlsmt = "select a.prod_id as [Product ID], a.prod_name as [Product Name],";
            sqlsmt += "a.prod_category as [Category], a.prod_size as [Size], a.prod_gsm as [GSM], ";
            sqlsmt += "a.prod_price as [Price], b.stock_qty as [Stocks], ";
            sqlsmt += "b.stock_safetylvl as [Safety Level], a.prod_status as [Status]";
            sqlsmt += " from product_tbl as a,stocks_tbl as b where a.prod_id=b.prod_id;";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            GridViewProducts.DataSource = dataTable;
            GridViewProducts.DataBind();
            conn.Close();
        }
        protected void txtProdid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
                constr += Server.MapPath("~/App_Data/inkpress_db.mdb");
                OleDbConnection conn = new OleDbConnection(constr);
                conn.Open();
                string sqlsmt = "select a.prod_id,a.prod_name,a.prod_category,a.prod_size,a.prod_gsm,a.prod_price,b.stock_qty,b.stock_safetylvl, a.prod_status from product_tbl as a, stocks_tbl as b where  a.prod_id=b.prod_id and a.prod_id=" + txtProdid.Text + ";";

                OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
                OleDbDataReader dataReader = sqlcmd.ExecuteReader();
                if (dataReader.HasRows && txtProdid.Text != "")
                {
                    dataReader.Read();
                    txtName.Text = dataReader["prod_name"].ToString();
                    drpdwnCateg.SelectedValue = dataReader["prod_category"].ToString();
                    drpdwnSize.Text = dataReader["prod_size"].ToString();
                    txtGsm.Text = dataReader["prod_gsm"].ToString();
                    txtPrice.Text = dataReader["prod_price"].ToString();
                    txtStock.Text = dataReader["stock_qty"].ToString();
                    txtSafety.Text = dataReader["stock_safetylvl"].ToString();
                    drpdwnStatus.SelectedValue = dataReader["prod_status"].ToString();
                    btnUpdateProd.Visible = true;
                    btnUpdateStocks.Visible = true;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnAdd.Visible = false;
                }
                else
                {
                    txtName.Text = "";
                    drpdwnCateg.SelectedValue = "Bond Paper";
                    drpdwnSize.SelectedValue = "A4";
                    txtGsm.Text = "";
                    txtPrice.Text = "";
                    txtStock.Text = "";
                    txtSafety.Text = "";
                    drpdwnStatus.SelectedValue = "Available";
                    txtSupplier.Text = "";

                    txtName.Enabled = true;
                    drpdwnCateg.Enabled = true;
                    drpdwnSize.Enabled = true;
                    txtGsm.Enabled = true;
                    txtPrice.Enabled = true;
                    txtStock.Enabled = true;
                    txtSafety.Enabled = true;
                    txtsupp.Visible = true;
                    txtSupplier.Visible = true;
                    drpdwnStatus.Enabled = true;
                    btnUpdateProd.Visible = false;
                    btnUpdateStocks.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnAdd.Visible = true;

                }

                conn.Close();
            }
            catch
            {
                Response.Write("<script>alert('Invalid Order ID')</script>");
            }
        }

        protected void btnUpdateProd_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            drpdwnCateg.Enabled = true;
            drpdwnSize.Enabled = true;
            txtGsm.Enabled = true;
            txtPrice.Enabled = true;
            txtStock.Enabled = false;
            txtSupplier.Visible =false;
            txtSafety.Enabled = false;
            drpdwnStatus.Enabled = true;
            btnUpdateProd.Visible = true;
            btnUpdateStocks.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnAdd.Visible = false;
        }

        protected void btnUpdateStocks_Click(object sender, EventArgs e)
        {
            txtName.Enabled = false;
            drpdwnCateg.Enabled = false;
            drpdwnSize.Enabled = false;
            txtGsm.Enabled = false;
            txtPrice.Enabled = false;
            txtStock.Enabled = true;
            txtSafety.Enabled = true;
            drpdwnStatus.Enabled = false;
            btnUpdateProd.Visible = true;
            btnUpdateStocks.Visible = true;
            txtSupplier.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnAdd.Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();
            string sqlsmt = "update product_tbl set prod_name='" + txtName.Text + "',prod_category ='" + drpdwnCateg.SelectedValue + "',prod_size ='" + drpdwnSize.SelectedValue + "',prod_gsm = '" + txtGsm.Text + "',prod_price= '" + txtPrice.Text + "',prod_status= '" + drpdwnStatus.SelectedValue + "'where prod_id=" + txtProdid.Text + ";";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
            sqlcmd.ExecuteNonQuery();

            sqlsmt = "update stocks_tbl set stock_qty=" + txtStock.Text + ", stock_safetylvl="+txtSafety.Text+" where stock_id=" + txtProdid.Text + ";";
            sqlcmd = new OleDbCommand(sqlsmt, conn);
            sqlcmd.ExecuteNonQuery();

            sqlsmt = "select a.prod_id as [Product ID], a.prod_name as [Product Name],";
            sqlsmt += "a.prod_category as [Category], a.prod_size as [Size], a.prod_gsm as [GSM], ";
            sqlsmt += "a.prod_price as [Price], b.stock_qty as [Stocks], ";
            sqlsmt += "b.stock_safetylvl as [Safety Level], a.prod_status as [Status]";
            sqlsmt += " from product_tbl as a,stocks_tbl as b where a.prod_id=b.prod_id;";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            GridViewProducts.DataSource = dataTable;
            GridViewProducts.DataBind();


            conn.Close();
            txtProdid.Text = "";
            txtName.Text = "";
            drpdwnCateg.SelectedValue = "1";
            drpdwnSize.SelectedValue = "1";
            txtGsm.Text = "";
            txtPrice.Text = "";
            txtStock.Text = "";
            drpdwnStatus.SelectedValue = "1";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();
            string sqlsmt = "insert into product_tbl(prod_name,prod_category,prod_size,prod_gsm,prod_price,prod_status) values ('" + txtName.Text + "','" +drpdwnCateg.SelectedValue+"','"+ drpdwnSize.SelectedValue + "','" + txtGsm.Text + "'," + txtPrice.Text + ",'" + drpdwnStatus.SelectedValue + "');";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
            sqlcmd.ExecuteNonQuery();

            sqlsmt = "insert into stocks_tbl(prod_id,stock_qty,stock_safetylvl,supplier_id) values ("+txtProdid.Text+","+txtStock.Text + "," + txtSafety.Text + ","+txtSupplier.Text+")";
            sqlcmd = new OleDbCommand(sqlsmt, conn);
            sqlcmd.ExecuteNonQuery();

            conn.Close();
            txtProdid.Text = "";
            txtName.Text = "";
            txtGsm.Text = "";
            txtPrice.Text = "";
            txtSafety.Text = "";
            txtStock.Text = "";

            Response.Redirect("AdminProducts.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");
            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string sqlsmt = "delete from product_tbl where prod_id=" + txtProdid.Text + ";";
            OleDbCommand sqlcmd = new OleDbCommand(sqlsmt, conn);
            sqlcmd.ExecuteNonQuery();

            sqlsmt = "delete from stocks_tbl where prod_id=" + txtProdid.Text + ";";
            sqlcmd = new OleDbCommand(sqlsmt, conn);
            sqlcmd.ExecuteNonQuery();

            conn.Close();
            txtProdid.Text = "";
            txtName.Text = "";
            txtGsm.Text = "";
            txtPrice.Text = "";
            txtSafety.Text = "";
            txtStock.Text = "";

            Response.Redirect("AdminProducts.aspx");
        }
    }
}