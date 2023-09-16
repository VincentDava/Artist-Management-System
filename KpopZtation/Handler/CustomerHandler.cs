using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace KpopZtation.Handler
{
    public class CustomerHandler
    {
        public static Customer GetCustomer(String email)
        {
            Customer customer = CustomerRepository.GetCustomer(email);
            return customer;
        }

        public static String GetEmail(String email)
        {
            Customer customer = CustomerRepository.GetCustomer(email);
            if(customer == null)
            {
                return "";
            }
            return customer.CustomerEmail;
        }

        public static String GetPassword(String email)
        {
            Customer customer = CustomerRepository.GetCustomer(email);
            if(customer == null)
            {
                return "";
            }
            return customer.CustomerPassword;
        }

        public static String GetRole(String email)
        {
            Customer customer = CustomerRepository.GetCustomer(email);
            return customer.CustomerRole;
        }

        public static int GetCustomerID(String email)
        {
            Customer customer = CustomerRepository.GetCustomer(email);
            if (customer == null)
            {
                return -1;
            }
            return customer.CustomerID;
        }

        public static HttpCookie CreateRememberCookie(String email)
        {
            HttpCookie cookie = CustomerRepository.CreateRememberCookie(email);
            return cookie;
        }

        public static HttpCookie DeleteRememberCookie()
        {
            HttpCookie cookie = CustomerRepository.DeleteRememberCookie();
            return cookie;
        }
        public static HttpCookie DeleteRoleCookie()
        {
            HttpCookie cookie = CustomerRepository.DeleteRoleCookie();
            return cookie;
        }

        public static HttpCookie CreateRoleCookie(String email)
        {
            HttpCookie cookie = CustomerRepository.CreateRoleWithCookie(email);
            return cookie;
        }

    }
}