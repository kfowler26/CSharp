/*
Author: Kendall Fowler
Date: 03/12/2021
Class: CIS-2255
Description: Assignment 6 - Hotel Guest Application
*/
using System;
using System.Data.OleDb;
using System.Windows.Forms;
using CIS2225_Assignment6.BusinessObjects;

namespace CIS2225_Assignment6
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //Build DB Connection 
        string sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=Cottages.accdb";
        OleDbConnection dbConn;

        //---Control Events---//

        //When form loads the combo box will populate
        private void frmMain_Load(object sender, EventArgs e)
        {
            loadComboBox();
        }

        //When guest is selected causes information to load
        private void cmbSelectGuest_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGuest();
        }

        //When clicked a new Guest is added
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGuestID.Text))
            {
                addGuest();
            }
            else
            {
                clearForm();
            }
        }

        //When clicked a Guest is edited
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            editGuest();
        }

        //When clicked a Guest is deleted
        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteGuest();
        }

        //---Functions---//

        //Adds guest to Database
        public void addGuest()
        {
            if (validateForm())
            {
                try
                {
                    dbConn = new OleDbConnection(sConnection);
                    dbConn.Open();

                    string sql;

                    sql = "Insert into Guests(LastName, FirstName, Street, City, State, Zip, Phone, email, LastVisitDate, Room) " +
                        "Values (@LastName, @FirstName, @Street, @City, @State, @Zip, @Phone, @email, @LastVisitDate, @Room);";

                    OleDbCommand dbCmd = new OleDbCommand();

                    dbCmd.CommandText = sql;
                    dbCmd.Connection = dbConn;

                    //Paramater Binding
                    dbCmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    dbCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    dbCmd.Parameters.AddWithValue("@Street", txtStreet.Text);
                    dbCmd.Parameters.AddWithValue("@City", txtCity.Text);
                    dbCmd.Parameters.AddWithValue("@State", txtState.Text);
                    dbCmd.Parameters.AddWithValue("@Zip", txtZip.Text);
                    dbCmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    dbCmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    dbCmd.Parameters.AddWithValue("@LastVisitDate", txtDate.Text);
                    dbCmd.Parameters.AddWithValue("@Room", txtRoom.Text);

                    int rowCount = dbCmd.ExecuteNonQuery();

                    dbConn.Close();
                    if (rowCount == 1)
                    {
                        MessageBox.Show("Record inserted successfully");
                        loadComboBox();
                    }
                    else
                    {
                        MessageBox.Show("Error inserting record. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        //Clears Form
        private void clearForm()
        {
            cmbSelectGuest.Items.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtStreet.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtGuestID.Clear();
            txtRoom.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtZip.Clear();
            txtDate.Clear();
        }

        //deletes guest from Database
        public void deleteGuest()
        {
            try
            {
                dbConn = new OleDbConnection(sConnection);
                dbConn.Open();

                string sql;
                sql = "Delete from Guests where GuestID = @GuestID";

                //create database command
                OleDbCommand dbCmd = new OleDbCommand();
                dbCmd.CommandText = sql;
                dbCmd.Connection = dbConn;

                //Parameter Binding
                dbCmd.Parameters.AddWithValue("@GuestID", txtGuestID.Text);

                //execute update. Check to see how many rows were affected
                int rowCount = dbCmd.ExecuteNonQuery();

                dbConn.Close();
                clearForm();

                if (rowCount == 1)
                {
                    MessageBox.Show("Record deleted successfully");
                    loadComboBox();
                }
                else
                {
                    MessageBox.Show("Error deleting record. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Edits guest on Database
        public void editGuest()
        {
            if (validateForm())
            {
                try
                {
                    dbConn = new OleDbConnection(sConnection);
                    dbConn.Open();

                    string sql;
                    sql = "Update Guests set LastName = @LastName, FirstName = @FirstName, Street = @Street, City = @City, " +
                        "State = @State, Zip = @Zip, Phone = @Phone, email = @Email, LastVisitDate = @LastVisitDate, " +
                        "Room = @Room where GuestID = @GuestID;";

                    OleDbCommand dbCmd = new OleDbCommand();
                    dbCmd.CommandText = sql;
                    dbCmd.Connection = dbConn;

                    //Paramater Binding
                    dbCmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    dbCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    dbCmd.Parameters.AddWithValue("@Street", txtStreet.Text);
                    dbCmd.Parameters.AddWithValue("@City", txtCity.Text);
                    dbCmd.Parameters.AddWithValue("@State", txtState.Text);
                    dbCmd.Parameters.AddWithValue("@Zip", txtZip.Text);
                    dbCmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    dbCmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    dbCmd.Parameters.AddWithValue("@LastVisitDate", txtDate.Text);
                    dbCmd.Parameters.AddWithValue("@Room", txtRoom.Text);
                    dbCmd.Parameters.AddWithValue("@GuestId", txtGuestID.Text);

                    //execute update. Check to see how many rows were affected
                    int rowCount = dbCmd.ExecuteNonQuery();

                    //close database connection
                    dbConn.Close();

                    if (rowCount == 1)
                    {
                        MessageBox.Show("Record updated successfully");
                        loadComboBox();
                    }
                    else
                    {
                        MessageBox.Show("Error updating record. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        //Loads comboBox of guests from the DB
        public void loadComboBox()
        {
            clearForm();

            try
            {
                dbConn = new OleDbConnection(sConnection);
                dbConn.Open();

                string sql;
                sql = "SELECT GuestID, FirstName, LastName from Guests;";

                OleDbCommand dbCmd = new OleDbCommand();
                dbCmd.CommandText = sql;
                dbCmd.Connection = dbConn;
                OleDbDataReader dbReader;
                dbReader = dbCmd.ExecuteReader();
                while (dbReader.Read())
                {
                    Guest guest = new Guest(dbReader["FirstName"].ToString(), dbReader["LastName"].ToString(), (int)dbReader["GuestID"]);
                    cmbSelectGuest.Items.Add(guest);
                }
                dbReader.Close();
                dbConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        //Loads Guest Information
        private void loadGuest()
        {
            int selectedGuest = ((Guest)cmbSelectGuest.SelectedItem).GuestID;

            try
            {
                dbConn = new OleDbConnection(sConnection);
                dbConn.Open();

                string sql;
                sql = "SELECT(Select count(GuestID) from Guests where GuestID = " + selectedGuest + ")" +
                    " as rowCount, * from Guests where GuestID = " + selectedGuest + ";";

                //Open Connections
                OleDbCommand dbCmd = new OleDbCommand();
                dbCmd.CommandText = sql;
                dbCmd.Connection = dbConn;
                int numRows = (Int32)dbCmd.ExecuteScalar();
                OleDbDataReader dbReader;
                dbReader = dbCmd.ExecuteReader();

                dbReader.Read();
                if (dbReader.HasRows && numRows == 1)
                {
                    txtGuestID.Text = dbReader["GuestId"].ToString();
                    txtFirstName.Text = dbReader["FirstName"].ToString();
                    txtLastName.Text = dbReader["LastName"].ToString();
                    txtStreet.Text = dbReader["Street"].ToString();
                    txtCity.Text = dbReader["City"].ToString();
                    txtState.Text = dbReader["State"].ToString();
                    txtZip.Text = dbReader["Zip"].ToString();
                    txtPhone.Text = dbReader["Phone"].ToString();
                    txtEmail.Text = dbReader["email"].ToString();
                    txtDate.Text = dbReader["LastVisitDate"].ToString();
                    txtRoom.Text = dbReader["Room"].ToString();
                }
                //Close open connections
                dbReader.Close();
                dbConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        //Validates form inputs
        private bool validateForm()
        {
            string errorMsg = "";

            if (txtFirstName.Text == "")
            {
                errorMsg = "Please enter a First Name";
            }
            if (txtLastName.Text == "")
            {
                errorMsg = "Please enter a Last Name";
            }
            if (txtStreet.Text == "")
            {
                errorMsg = "Please enter a Street";
            }
            if (txtCity.Text == "")
            {
                errorMsg = "Please enter a City";
            }
            if (txtState.Text == "")
            {
                errorMsg = "Please enter a State";
            }
            if (txtZip.Text == "")
            {
                errorMsg = "Please enter a Zip Code";
            }
            if (txtPhone.Text == "")
            {
                errorMsg = "Please enter a Phone Number";
            }
            if (txtEmail.Text == "")
            {
                errorMsg = "Please enter an Email";
            }
            if (txtRoom.Text == "")
            {
                errorMsg = "Please enter a Room";
            }
            if (txtDate.Text == "")
            {
                errorMsg = "Please select a Date";
            }

            if (errorMsg.Length > 0)
            {
                MessageBox.Show(errorMsg);
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}


