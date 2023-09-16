using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Factory
{
    public class CustomerFactory
    {
        public static Customer CreateCustomer(String name, String email, String gender, String address, String password)
        {

            int id = Convert.ToInt32(CustomerRepository.GetIdNotUsed() + 1);

            Customer customer = new Customer
            {
                CustomerID = id,
                CustomerName = name,
                CustomerEmail = email,
                CustomerGender = gender,
                CustomerAddresss = address,
                CustomerPassword = password,
                CustomerRole = "User"
            };


            return customer;
        }

        
        
        

    }
}