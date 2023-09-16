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
    public partial class ArtistDetail : System.Web.UI.Page
    {
        int artistID;
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
            if (Request["ArtistID"] != null)
            {
                artistID = Convert.ToInt32(Request["ArtistID"]);
                albums = AlbumHandler.GetByID(artistID);
                GridViewArtist.DataSource = albums;
                GridViewArtist.DataBind();
            }
            if(albums.Any()== true)
            {
                int count = GridViewArtist.Rows[0].Cells.Count;

                if (roleCheck == "User" || roleCheck == "Guest")
                {
                    GridViewArtist.Columns[count - 1].Visible = false;
                    GridViewArtist.Columns[count - 2].Visible = false;
                }
            }
            
        }

        protected void InsertAlbumBtn_Click(object sender, EventArgs e)
        {
            if (Request["ArtistID"] != null)
            {
                artistID = Convert.ToInt32(Request["ArtistID"]);
                Response.Redirect("~/View/InsertAlbum.aspx?ArtistID=" + artistID);
            }
        }
        
        protected void GridViewArtist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            String albumName = ((HyperLink)GridViewArtist.Rows[index].Cells[0].Controls[0]).Text;
            String imgPath = Server.MapPath(AlbumHandler.GetAlbumPath(albumName));

            AlbumHandler.DeleteAlbum(albumName, imgPath);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void GridViewArtist_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            String albumName = ((HyperLink)GridViewArtist.Rows[index].Cells[0].Controls[0]).Text;
            Response.Redirect("~/View/UpdateAlbum.aspx?ArtistID=" + artistID +"&AlbumName=" + albumName);
        }

        
    }
}