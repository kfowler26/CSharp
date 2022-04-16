/*
Author: Kendall Fowler
Date: 03/12/2021
Class: CIS-2255
Description: Assignment 6 - Hotel Guest Application
*/

namespace CIS2225_Assignment6.BusinessObjects
{
    public class Guest
    {
        //Attributes
        private int guestID;
        private string lastName;
        private string firstName;
        private string street;
        private string city;
        private string state;
        private string zip;
        private string phone;
        private string email;
        private string lastVisitDate;
        private string room;

        //Default Constructor
        public Guest()
        {

        }

        //Custom Constructor for Combo Box
        public Guest(string fName, string lName, int id)
        {
            GuestID = id;
            FirstName = fName;
            LastName = lName;
        }

        public Guest(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
        }

        //Public Properties
        public int GuestID { get => guestID; set => guestID = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Street { get => street; set => street = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zip { get => zip; set => zip = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string LastVisitDate { get => lastVisitDate; set => lastVisitDate = value; }
        public string Room { get => room; set => room = value; }

        //Override toString to display Guests Name
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
