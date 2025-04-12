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
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = ";
            constr += Server.MapPath("~/App_Data/inkpress_db.mdb");

            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();

            string sqlsmt = "select b.user_fname+' '+b.user_lname as [Name],";
            sqlsmt += "a.order_id as [Order ID], a.rev_msg as [Reviews]";
            sqlsmt += "from reviews_tbl as a, users_tbl as b where a.user_id=b.user_id and a.rev_status='Show'";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlsmt, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            GridViewR.DataSource = dataTable;
            GridViewR.DataBind();
            conn.Close();
        }
    }
}