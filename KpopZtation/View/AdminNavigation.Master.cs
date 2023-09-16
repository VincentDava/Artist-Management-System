using KpopZtation.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation
{
    public partial class AdminNavigation : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void HomeBtn_Click(object sender, EventArgs e) { Response.Redirect("~/View/Home.aspx"); }
        protected void TransactionBtn_Click(object sender, EventArgs e) { Response.Redirect("~/View/Reporting.aspx"); }
        protected void UpdateProfileBtn_Click(object sender, EventArgs e) { Response.Redirect("~/View/UpdateProfile.aspx"); }
        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Response.Cookies.Add(CustomerHandler.DeleteRememberCookie());
            Response.Cookies.Add(CustomerHandler.DeleteRoleCookie());
            Response.Redirect("~/View/Login.aspx");
        }
    }
}