using KpopZtation.Controller;
using KpopZtation.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies.AllKeys.Contains("UserRole"))
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string name = NameText.Text;
            string email = EmailText.Text;
            string gender = GenderText.Text;
            string address = AddressText.Text;
            string password = PasswordText.Text;

            ErrorLabel.Text = CustomerController.Checker(name, email, gender, address, password);
            if(ErrorLabel.Text == "Registered Account Successfully")
            {
                Response.Redirect("~/View/Login.aspx");
            }

        }
    }
}