using KpopZtation.Handler;
using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace KpopZtation.Controller
{
    public class CustomerController
    {
        private static String NameChecker(String name)
        {
            if(name == "")
            {
                return "Please enter an username";
            }
            else if (name.Length < 5 || name.Length > 50)
            {
                return "Length of username must be higher than 5 characters and less than 50 characters";
            }
            return "";
        }

        private static String EmailChecker(String email)
        {
            if (email == "")
            {
                return "Please enter an email address";
            }
            else if(CustomerHandler.GetCustomer(email) != null)
            {
                return "Email has been taken";
            }
            return "";
        }

        private static String GenderChecker(String gender)
        {
            if (gender == "")
            {
                return "Please fill this textbox";
            }
            return "";
        }

        private static String AddressChecker(String address)
        {
            String regexAddress = "[a-zA-Z0-9 ]*(?i)street$(?-i)";
            if (address == "")
            {
                return "Please fill your address";
            }
            else if (Regex.IsMatch(address, regexAddress) == false)
            {
                return "Address must end with Street";
            }
            return "";
        }

        private static String PasswordChecker(String password)
        {
            String regexPassword = "^[a-zA-Z0-9]*$";
            if (password == "")
            {
                return "Please enter a password";
            }
            else if (Regex.IsMatch(password, regexPassword) == false)
            {
                return "No Special characters";
            }
            return "";
        }

        public static String Checker(String name, String email, String gender, String address, String password)
        {
            String response = NameChecker(name);
            if(response != "")
            {
                return response;
            }
            response = EmailChecker(email);
            if (response != "")
            {
                return response;
            }
            response = GenderChecker(gender);
            if (response != "")
            {
                return response;
            }
            response = AddressChecker(address);
            if (response != "")
            {
                return response;
            }
            response = PasswordChecker(password);
            if (response != "")
            {
                return response;
            }

            CustomerRepository.CreateCustomer(name, email, gender, address, password);

            
            return "Registered Account Successfully";
        }

        private static String CheckEmailForUpdate(String newEmail, String oldEmail)
        {
            if (newEmail == "")
            {
                return "Please enter an email";
            }
            else if (CustomerHandler.GetCustomerID(newEmail) != -1 && CustomerHandler.GetCustomerID(oldEmail) != CustomerHandler.GetCustomerID(newEmail))
            {
                return "Email is in another row";
            }
            return "";
        }

        public static String UpdateChecker(String name, String newEmail, String oldEmail, String gender, String address, String password)
        {
            String response = NameChecker(name);
            if (response != "")
            {
                return response;
            }
            response = PasswordChecker(password);
            if (response != "")
            {
                return response;
            }
            response = CheckEmailForUpdate(newEmail, oldEmail);
            if (response != "")
            {
                return response;
            }
            response = GenderChecker(gender);
            if (response != "")
            {
                return response;
            }
            response = AddressChecker(address);
            if (response != "")
            {
                return response;
            }

            CustomerRepository.UpdateCustomer(name, newEmail, gender, address, password); 
            return "Updated Account Successfully";
        }

        private static String EmailCheckerForLogin(String email)
        {
            if (email == "")
            {
                return "Please enter an email address";
            }
            else if (CustomerHandler.GetEmail(email) == "")
            {
                return "Email not found";
            }
            return "";
        }

        private static String PasswordCheckerForLogin(String password, String email)
        {
            String oldPassword= CustomerHandler.GetPassword(email);
            String regexPassword = "^[a-zA-Z0-9]*$";
            if (password == "")
            {
                return "Please enter a password";
            }
            else if (Regex.IsMatch(password, regexPassword) == false)
            {
                return "No Special characters";
            }
            else if (oldPassword == "")
            {
                return "Email not found";
            }
            else if(password != oldPassword)
            {
                return "Wrong Password";
            }
            return "";
        }

        public static String LoginChecker(String email, String password)
        {
            String response = EmailCheckerForLogin(email);
            if (response != "")
            {
                return response;
            }
            response = PasswordCheckerForLogin(password, email);
            if (response != "")
            {
                return response;
            }
            if (CustomerHandler.GetCustomer(email) == null)
            {
                return "Account does not exist!";
            }
            return "Login Succesful";
        }
    }
}