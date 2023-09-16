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
    public partial class InsertAlbum : System.Web.UI.Page
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
            
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            int artistID = Convert.ToInt32(Request["ArtistID"]);
            String name = AlbumNameText.Text;
            String imgPath = "/Assets/Album/" + AlbumImageInput.FileName;
            HttpPostedFile file = AlbumImageInput.PostedFile;
            String desc = AlbumDescText.Text;
            int price;
            int stock;

            ErrorLabel.Text = AlbumController.CheckStringIsEmpty(AlbumPriceText.Text, "price");
            if(ErrorLabel.Text == "")
            {
                price = Convert.ToInt32(AlbumPriceText.Text);
            }
            else { return; }
            ErrorLabel.Text = AlbumController.CheckStringIsEmpty(AlbumStockText.Text, "stock");
            if (ErrorLabel.Text == "")
            {
                stock = Convert.ToInt32(AlbumStockText.Text);
            }
            else { return; }
            

            ErrorLabel.Text = AlbumController.Checker(artistID, name, imgPath, file, price, stock, desc);
            if (ErrorLabel.Text == "Insert Album Successful")
            {
                AlbumImageInput.SaveAs(Server.MapPath("/Assets/Album/" + AlbumImageInput.FileName));
                Response.Redirect("~/View/ArtistDetail.aspx?ArtistID=" + artistID);
            }
        }
    }
}