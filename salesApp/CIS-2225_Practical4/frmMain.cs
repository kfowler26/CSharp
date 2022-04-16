/*
Author: Kendall Fowler
Date: 11/12/2021
Class: CIS-2255
Description: Practical 4 - Sales Application
*/
using System;
using System.Data.OleDb;
using System.Windows.Forms;
using CIS_2225_Practical4.BusinessObjects;

namespace CIS_2225_Practical4
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //String to connect to Database
        string sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=Product.accdb";

        //Create DB connection
        OleDbConnection dbConn;

        //---Control Events---//

        //Loads combobox with Product Ids
        private void frmMain_Load(object sender, EventArgs e)
        {
            loadComboBox();
        }

        //Event to load information into the form
        private void cmbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadProduct();
        }

        //Event to clear form to insert product into database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearForm();
            loadComboBox();
        }

        //Event to insert product in database
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbID.Text))
            {
                insertProduct();
            }
            else
            {
                MessageBox.Show("There is already a record selected. Clear the form first");
            }

        }

        //Event to delete product from database
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbID.Text))
            {
                MessageBox.Show("Please select a record to delete");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    deleteProduct();
                }
            }
        }

        //---Functions---//

        //Inserts product into database
        public void insertProduct()
        {
            if (validateForm())
            {
                try
                {
                    //DB Connection
                    dbConn = new OleDbConnection(sConnection);

                    //Open DB connection
                    dbConn.Open();

                    //Set Variable
                    string sql;

                    //Insert Query
                    sql = "Insert into Product(Description, Retail_Price, Quantity, MarkUP) " +
                        "Values (@Description, @RetailPrice, @MarkUp, @Quantity);";

                    //Create DB command
                    OleDbCommand dbCmd = new OleDbCommand();

                    //Set query string
                    dbCmd.CommandText = sql;

                    //Set the command connection
                    dbCmd.Connection = dbConn;

                    //Paramater Binding
                    dbCmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    dbCmd.Parameters.AddWithValue("@RetailPrice", txtRetailPrice.Text);
                    dbCmd.Parameters.AddWithValue("@MarkUp", txtMarkUp.Text);
                    dbCmd.Parameters.AddWithValue("@Quanity", txtQuantity.Text);

                    //Int to test for a result
                    int rowCount = dbCmd.ExecuteNonQuery();

                    //Error Handling
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
                finally
                {
                    //Close DB Connection
                    dbConn.Close();
                }

            }
        }

        //Clears form fields
        public void clearForm()
        {
            cmbID.Items.Clear();
            txtDescription.Clear();
            txtRetailPrice.Clear();
            txtQuantity.Clear();
            txtMarkUp.Clear();
        }

        //Delete product from database
        public void deleteProduct()
        {
            try
            {
                //DB Connection
                dbConn = new OleDbConnection(sConnection);

                //Open DB connection
                dbConn.Open();

                //Set Variable
                string sql;

                //Delete Query
                sql = "Delete from Product where Product_ID = @ProductID";

                //Create DB command
                OleDbCommand dbCmd = new OleDbCommand();

                //Set query string
                dbCmd.CommandText = sql;

                //Set the command connection
                dbCmd.Connection = dbConn;

                //Parameter Binding
                dbCmd.Parameters.AddWithValue("@ProductID", cmbID.Text);

                //Int to test for a result
                int rowCount = dbCmd.ExecuteNonQuery();

                clearForm();

                //Error Handling
                if (rowCount == 1)
                {
                    MessageBox.Show("Product deleted.");
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
            finally
            {
                //Close DB Connection
                dbConn.Close();
            }
        }

        //Loads comboBox from the DB
        public void loadComboBox()
        {
            clearForm();

            try
            {
                //DB Connection
                dbConn = new OleDbConnection(sConnection);

                //Open DB connection
                dbConn.Open();

                //Set Variable
                string sql;

                //Select Query
                sql = "SELECT Product_ID from Product;";

                //Create DB command
                OleDbCommand dbCmd = new OleDbCommand();

                //Set query string
                dbCmd.CommandText = sql;

                //Set the command connection
                dbCmd.Connection = dbConn;

                //Create the dbReader
                OleDbDataReader dbReader;

                //Reads data into the dbReader
                dbReader = dbCmd.ExecuteReader();

                while (dbReader.Read())
                {
                    //Creates Product object
                    Product product = new Product((int)dbReader["Product_ID"]);

                    //Loads information into combobox
                    cmbID.Items.Add(product);
                }
                //Close dbReader connection
                dbReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //Close DB Connection
                dbConn.Close();
            }

        }

        //Loads information to form
        public void loadProduct()
        {
            //Variable
            int selectedProduct = ((Product)cmbID.SelectedItem).ProductID;

            try
            {
                //DB Connection
                dbConn = new OleDbConnection(sConnection);

                //Open DB connection
                dbConn.Open();

                //Set Variable
                string sql;

                //Select Query
                sql = "SELECT(Select count(Product_ID) from Product where Product_ID = " + selectedProduct + ")" +
                    " as rowCount, * from Product where Product_ID = " + selectedProduct + ";";

                //Create DB command
                OleDbCommand dbCmd = new OleDbCommand();

                //Set query string
                dbCmd.CommandText = sql;

                //Set the command connection
                dbCmd.Connection = dbConn;

                //Create the dbReader
                OleDbDataReader dbReader;

                //Int to get a row count
                int numRows = (Int32)dbCmd.ExecuteScalar();

                //Reads data into the dbReader
                dbReader = dbCmd.ExecuteReader();

                //Reads record
                dbReader.Read();
                if (dbReader.HasRows && numRows == 1)
                {
                    //Assigns date to textboxes
                    txtDescription.Text = dbReader["Description"].ToString();
                    txtRetailPrice.Text = dbReader["Retail_Price"].ToString();
                    txtQuantity.Text = dbReader["Quantity"].ToString();
                    txtMarkUp.Text = dbReader["MarkUp"].ToString();
                }

                //Close dbReader connection
                dbReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //Close DB Connection
                dbConn.Close();
            }
        }

        //Validates form inputs
        private bool validateForm()
        {
            //Variables
            string errorMsg = "";
            int retailPrice;
            int quantity;
            int markUp;

            if (String.IsNullOrEmpty(txtDescription.Text))
            {
                errorMsg = "Please enter a Description";
            }

            if ((int.TryParse(txtRetailPrice.Text, out retailPrice) == false) || string.IsNullOrEmpty(txtRetailPrice.Text))
            {
                errorMsg = "Please enter a Retail Price in numeric format";
            }

            if ((int.TryParse(txtQuantity.Text, out quantity) == false) || string.IsNullOrEmpty(txtQuantity.Text))
            {
                errorMsg = "Please enter a Quantity in numeric format";
            }
            if ((int.TryParse(txtMarkUp.Text, out markUp) == false) || string.IsNullOrEmpty(txtMarkUp.Text))
            {
                errorMsg = "Please enter a Markup in numeric format";
            }

            //Displays error messages if error variable is populated
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

