using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABB_2
{
    internal class Customer
    {

        public string FirstName;
        public string UserName;
        public string Pass;

        public Customer(string firstName, string userName, string pass)
        {
            FirstName = firstName;
            Pass = pass;
            UserName = userName;
        }

        private List<Customer> Customers;
        public Customer(List<Customer> customers)
        {
            Customers = customers;
        }
        public override string ToString()
        {
            return string.Format("First Name is: {0}, Last name is: {1}, Username is: {2}, Password is: {3}", GetFirstName(), GetUserName(), GetPassword());

        }

        public string GetFirstName()
        {
            return FirstName;

        }
       
        public string GetUserName()
        {
            return UserName;

        }
        public string GetPassword()
        {
            return Pass;
        }
    }


}

