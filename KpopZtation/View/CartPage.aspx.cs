using KpopZtation.Handler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View
{
    public partial class CartPage : System.Web.UI.Page
    {
        String roleCheck = "Guest";

        protected void Page_PreInit(object sender, EventArgs e)
        {
            //Get role from cookie if it exist
            if (Request.Cookies.AllKeys.Contains("UserRole"))
            {
                roleCheck = CustomerHandler.GetRole(Request.Cookies["UserRole"].Value);
            }

            //Role Checking
            if (roleCheck == "Admin")
            {
                this.MasterPageFile = "~/View/AdminNavigation.Master";
            }
            else if (roleCheck == "User")
            {
                this.MasterPageFile = "~/View/CustomerNavigation.Master";
            }
            else if (roleCheck == "Guest")
            {
                this.MasterPageFile = "~/View/GuestNavigation.Master";
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            int customerID = CustomerHandler.GetCustomerID(Request.Cookies["UserRole"].Value);
            List<DisplayPurchase> displayPurchases = PurchaseHandler.GetCartViewWithID(customerID);
            GridViewCart.DataSource = displayPurchases;
            GridViewCart.DataBind();
        }

        protected void GridViewCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            GridViewRow row = GridViewCart.Rows[index];
            String albumName = row.Cells[0].Text;
            int customerID = CustomerHandler.GetCustomerID(Request.Cookies["UserRole"].Value);
            int albumID = AlbumHandler.GetAlbumID(albumName);
            PurchaseHandler.DeleteCart(customerID, albumID);

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            int customerID = CustomerHandler.GetCustomerID(Request.Cookies["UserRole"].Value);
            PurchaseHandler.CreateTransaction(customerID);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}