using KpopZtation.Controller;
using KpopZtation.Handler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation
{
    public partial class AlbumDetail : System.Web.UI.Page
    {
        List<Album> albums;
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
            //Request URL Parser Artist ID
            if (Request["AlbumName"] != null)
            {
                String albumName = Request["AlbumName"].ToString();
                albums = AlbumHandler.GetOneByName(albumName);
                GridViewAlbum.DataSource = albums;
                GridViewAlbum.DataBind();
            }
        }

        protected void AddToCartBtn_Click(object sender, EventArgs e)
        {
            int quantity;
            int customerID = CustomerHandler.GetCustomerID(Request.Cookies["UserRole"].Value);
            int albumID = AlbumHandler.GetAlbumID(Request["AlbumName"].ToString());

            ErrorLabel.Text = AlbumController.CheckStringIsEmpty(QuantityText.Text, "quantity");
            if (ErrorLabel.Text == "")
            {
                quantity = Convert.ToInt32(QuantityText.Text);
            }
            else { return; }
            PurchaseController.Checker(customerID, albumID, quantity);
            if(ErrorLabel.Text == "Added items to cart")
            {

            }

        }
    }
}