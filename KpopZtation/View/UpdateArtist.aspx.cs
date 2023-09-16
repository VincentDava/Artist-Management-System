using KpopZtation.Controller;
using KpopZtation.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation
{
    public partial class UpdateArtist : System.Web.UI.Page
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

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            String name = Request["ArtistName"].ToString();
            String updatedName = ArtistNameText.Text;
            String imgPath = "/Assets/Artist/" + ArtistImageInput.FileName;
            String oldImgPath = Server.MapPath(ArtistHandler.GetArtistPath(name));
            HttpPostedFile file = ArtistImageInput.PostedFile;

            ErrorLabel.Text = ArtistController.UpdateChecker(name, updatedName, imgPath, oldImgPath, file);
            if (ErrorLabel.Text == "Update Artist Successful")
            {
                ArtistImageInput.SaveAs(Server.MapPath("/Assets/Artist/" + ArtistImageInput.FileName));
                Response.Redirect("~/View/Home.aspx");
            }
        }
    }
}