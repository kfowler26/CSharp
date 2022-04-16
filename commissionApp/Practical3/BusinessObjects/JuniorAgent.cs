/*
Author: Kendall Fowler
Date: 04/12/2021
Class: CIS-2255
Description: Practical 3 - Sales Application
*/

namespace Practical3.BusinessObjects
{
    public class JuniorAgent : Agent
    {
        //Constructor
        public JuniorAgent(string firstName, string lastName, string email, int salesAmount) : base(firstName, lastName, email, salesAmount)
        {
        }

        //Calculates the Junior Agent Commission Rate
        public override double calculateCommissionRate()
        {
            double commissionRate;

            if (SalesAmount < 1000)
            {
                commissionRate = (0.02 - 0.005);
            }
            else if (SalesAmount >= 1000 && SalesAmount <= 5000)
            {
                commissionRate = (0.04 - 0.005);
            }
            else
            {
                commissionRate = (0.06 - 0.005);
            }

            return commissionRate;
        }
    }
}
