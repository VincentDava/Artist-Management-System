using KpopZtation.Handler;
using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation
{
    public partial class Home : System.Web.UI.Page
    {
        public List<Artist> artistRepo = ArtistHandler.GetAll();
        String roleCheck = "Guest";

        protected void Page_PreInit(object sender, EventArgs e)
        {
            //Get role from cookie if it exist
            if (Request.Cookies.AllKeys.Contains("UserRole"))
            {
                Debug.WriteLine("Tes");
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
            //Setup display artist cards
            GridViewHome.DataSource = ArtistHandler.GetAll();
            GridViewHome.DataBind();
            int count = GridViewHome.Rows[0].Cells.Count;

            //Role Checking
            if (roleCheck == "User" || roleCheck == "Guest")
            {
                GridViewHome.Columns[count - 1].Visible = false;
                GridViewHome.Columns[count - 2].Visible = false;
                InsertArtistBtn.Visible = false;
            }
        }
        protected void InsertArtistBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertArtist.aspx");
        }

        protected void GridViewHome_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            String artistName = ((HyperLink)GridViewHome.Rows[index].Cells[0].Controls[0]).Text;
            String imgPath = Server.MapPath(ArtistHandler.GetArtistPath(artistName));
            int artistID = ArtistHandler.GetArtistID(artistName);

            List<Album> albums = AlbumRepository.GetByID(artistID);
            foreach (var i in albums)
            {
                AlbumHandler.DeleteAlbum(i.AlbumName, Server.MapPath(AlbumHandler.GetAlbumPath(i.AlbumName)));
            }

            ArtistHandler.DeleteArtist(artistName, imgPath);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void GridViewHome_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            String artistName = ((HyperLink)GridViewHome.Rows[index].Cells[0].Controls[0]).Text;
            Response.Redirect("~/View/UpdateArtist.aspx?ArtistName=" + artistName);
        }
    }
}