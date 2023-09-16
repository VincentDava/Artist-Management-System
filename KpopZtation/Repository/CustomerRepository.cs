using KpopZtation.Factory;
using System;
using KpopZtation.Repository;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace KpopZtation.Repository
{
    public class CustomerRepository
    {
        static DatabaseEntities1 db = SingletonDatabase.GetInstance();
        
        public static HttpCookie CreateRememberCookie(String email)
        {
            Customer customer = GetCustomer(email);
            HttpCookie cookie = new HttpCookie("UserLogged")
            {
                Value = customer.CustomerEmail.ToString(),
                Expires = DateTime.Now.AddDays(14)
            };
            return cookie;
        }

        public static HttpCookie DeleteRememberCookie()
        {
            HttpCookie cookie = new HttpCookie("UserLogged")
            {
                Expires = DateTime.Now.AddDays(-100)
            };
            return cookie;
        }
        public static HttpCookie CreateRoleWithCookie(String email)
        {
            Customer customer = GetCustomer(email);
            HttpCookie cookie = new HttpCookie("UserRole")
            {
                Value = customer.CustomerEmail.ToString(),
                Expires = DateTime.Now.AddDays(14)
            };
            return cookie;
        }

        public static HttpCookie DeleteRoleCookie()
        {
            HttpCookie cookie = new HttpCookie("UserRole")
            {
                Expires = DateTime.Now.AddDays(-100)
            };
            return cookie;
        }

        public static Customer GetCustomer(String email)
        {
            return (from i in db.Customers where email.Equals(i.CustomerEmail) select i).FirstOrDefault();
        }

        public static int GetIdNotUsed()
        {
            return db.Customers.OrderByDescending(i => i.CustomerID).First().CustomerID;
        }

        public static void CreateCustomer(string name, string email, string gender, string address, string password)
        {
            Customer newCustomer = CustomerFactory.CreateCustomer(name, email, gender, address, password);
            db.Customers.Add(newCustomer);
            db.SaveChanges();
        }

        public static void UpdateCustomer(string name, string email, string gender, string address, string password)
        {
            Customer customer = GetCustomer(email);
            customer.CustomerName = name;
            customer.CustomerEmail = email;
            customer.CustomerGender = gender;
            customer.CustomerAddresss = address;
            customer.CustomerPassword = password;

            db.SaveChanges();
        }
    }
}