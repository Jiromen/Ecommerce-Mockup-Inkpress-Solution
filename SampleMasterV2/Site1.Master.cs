using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleMasterV2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["user_role"]==null) //nobody is logged in
                {
                   
                    OrderLink.Visible = true;
                    ReviewLink.Visible = true;
                    RegisterLink.Visible = true;
                    LoginLink.Visible = true;
                    ProfileLink.Visible = false;
                    LogoutButton.Visible = false;
                    AdminOrdersLink.Visible = false;
                    AdminProductsLink.Visible = false;
                    AdminReviewsLink.Visible = false;
                    AdminUsersLink.Visible = false;
                }
                else if(Session["user_role"].Equals("User"))
                {
                   
                    OrderLink.Visible = true;
                    ReviewLink.Visible = true;
                    RegisterLink.Visible = false;
                    LoginLink.Visible = false;
                    ProfileLink.Text = "Hello "+ Session["user_fname"].ToString();
                    LogoutButton.Visible = true;
                    AdminOrdersLink.Visible = false;
                    AdminProductsLink.Visible = false;
                    AdminReviewsLink.Visible = false;
                    AdminUsersLink.Visible = false;
                }
                else if (Session["user_role"].Equals("Admin"))
                {
                    OrderLink.Visible = false;
                    ReviewLink.Visible = true;
                    RegisterLink.Visible = false;
                    LoginLink.Visible = false;
                    ProfileLink.Text = "Hello " + Session["user_fname"].ToString();
                    LogoutButton.Visible = true;
                    AdminOrdersLink.Visible = true;
                    AdminProductsLink.Visible = true;
                    AdminReviewsLink.Visible = true;
                    AdminUsersLink.Visible = true;
                }
            }
            catch
            {

            }
        }
        protected void AdminOrdersLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminOrders.aspx");
        }
        protected void AdminProductsLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminProducts.aspx");
        }
        protected void AdminReviewsLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminReviews.aspx");
        }
        protected void AdminUsersLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUsers.aspx");
        }
        protected void OrderLink_Click(object sender, EventArgs e)
        {
            if (Session["user_role"] == null)
            {
               
                Response.Write("<script>alert('Please Login Before Ordering')</script>");
            }
            else
            {
                Response.Redirect("OrderForm.aspx");
            }
        }
        protected void LoginLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }
        protected void ReviewLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReviewPage.aspx");
        }
        protected void RegisterLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("HomePage.aspx");
        }


    }
}