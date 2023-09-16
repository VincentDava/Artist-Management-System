using KpopZtation.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View
{
    public partial class TransactionHistory : System.Web.UI.Page
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
            String customerName = CustomerHandler.GetCustomer(Request.Cookies["UserRole"].Value).CustomerName;
            List<DisplayTransaction> transactions = PurchaseHandler.GetTrWithName(customerName);
            GridViewTransaction.DataSource = transactions;
            GridViewTransaction.DataBind();
        }
    }
}