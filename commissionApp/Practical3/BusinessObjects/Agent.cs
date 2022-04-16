/*
Author: Kendall Fowler
Date: 04/12/2021
Class: CIS-2255
Description: Practical 3 - Sales Application
*/

namespace Practical3.BusinessObjects
{
    public class Agent
    {
        //Private Attributes
        private string firstName;
        private string lastName;
        private string email;
        private int salesAmount;

        //Getters/Setters
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public int SalesAmount { get => salesAmount; set => salesAmount = value; }

        //Constructor
        public Agent(string firstName, string lastName, string email, int salesAmount)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            SalesAmount = salesAmount;
        }

        //Calculates the Commission Rate
        public virtual double calculateCommissionRate()
        {
            double commissionRate;

            if (SalesAmount < 1000)
            {
                commissionRate = 0.02;
            }
            else if (SalesAmount >= 1000 && SalesAmount <= 5000)
            {
                commissionRate = 0.04;
            }
            else
            {
                commissionRate = 0.06;
            }
            return commissionRate;

        }
    }
}
