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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies.AllKeys.Contains("UserLogged"))
            {
                if (CustomerHandler.GetEmail(Request.Cookies["UserLogged"].Value) != null)
                {
                    Response.Redirect("~/View/Home.aspx");
                }
            }



        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            String email = EmailText.Text;
            String password = PasswordText.Text;
            int id = CustomerHandler.GetCustomerID(email);

            ErrorLabel.Text = CustomerController.LoginChecker(email, password);
            if(ErrorLabel.Text == "Login Succesful")
            {
                if (RememberCheckbox.Checked)
                {
                    Response.Cookies.Add(CustomerHandler.CreateRememberCookie(email));
                }
                Response.Cookies.Add(CustomerHandler.CreateRoleCookie(email));
                Response.Redirect("~/View/Home.aspx");
            }

        }
    }
}