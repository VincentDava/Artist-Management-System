using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation
{
    public partial class GuestNavigation : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void HomeBtn_Click(object sender, EventArgs e) { Response.Redirect("~/View/Home.aspx"); }
        protected void LoginBtn_Click(object sender, EventArgs e) { Response.Redirect("~/View/Login.aspx"); }
        protected void RegisterBtn_Click(object sender, EventArgs e) { Response.Redirect("~/View/Register.aspx"); }
    }
}