/*
Author: Kendall Fowler
Date: 04/12/2021
Class: CIS-2255
Description: Practical 3 - Sales Application
*/
using System;
using System.Windows.Forms;
using Practical3.BusinessObjects;

namespace Practical3
{
    public partial class frmMain : Form
    {
        //Validates if radio boxes are checked
        private bool agentChecked = false;

        public frmMain()
        {
            InitializeComponent();
        }

        //Used to clear form
        private void clearform()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtSales.Clear();
            txtCommEarned.Clear();
            txtCommRate.Clear();
            txtBonusReduction.Clear();
            rdbAgent.Checked = false;
            rdbJunior.Checked = false;
            rdbSenior.Checked = false;
        }

        //Used to ensure form input is valid
        private bool validateForm()
        {
            string errors = "";
            int.TryParse(txtSales.Text, out int sale);

            if (txtFirstName.Text == "")
            {
                errors += "Please enter a first name.\r";
            }
            if (txtLastName.Text == "")
            {
                errors += "Please enter a last name.\r";
            }
            if (txtEmail.Text == "")
            {
                errors += "Please enter an email.\r";
            }
            if (sale == 0)
            {
                errors += "Please enter a dollar amount.\r";
            }
            if (agentChecked == false)
            {
                errors += "Please select an agent type.\r";
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors);
                return false;
            }
            else
            {
                return true;
            }
        }

        //Control event to calculate agent comission
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double commissionEarned = 0.00;

            if (validateForm())
            {
                if (rdbJunior.Checked)
                {
                    //Adds Junior Agent
                    JuniorAgent junior = new JuniorAgent(txtFirstName.Text, txtLastName.Text, txtEmail.Text, int.Parse(txtSales.Text));
                    //Pulls commission rate from class
                    txtCommRate.Text = junior.calculateCommissionRate().ToString();
                    //Calculates earnings
                    commissionEarned = (int.Parse(txtSales.Text) * junior.calculateCommissionRate());
                    //Assigns and Formats Output
                    txtCommEarned.Text = string.Format("${0:#,0.00}", commissionEarned);
                    txtBonusReduction.Text = "-0.005";
                }
                else if (rdbSenior.Checked)
                {
                    //Adds Senior Agent
                    SeniorAgent senior = new SeniorAgent(txtFirstName.Text, txtLastName.Text, txtEmail.Text, int.Parse(txtSales.Text));
                    //Pulls commission rate from class
                    txtCommRate.Text = senior.calculateCommissionRate().ToString();
                    //Calculates earnings
                    commissionEarned = (int.Parse(txtSales.Text) * senior.calculateCommissionRate());
                    //Assigns and Formats Output
                    txtCommEarned.Text = string.Format("${0:#,0.00}", commissionEarned);
                    txtBonusReduction.Text = "+0.015";
                }
                else
                {
                    //Adds Agent
                    Agent agent = new Agent(txtFirstName.Text, txtLastName.Text, txtEmail.Text, int.Parse(txtSales.Text));
                    //Pulls commission rate from class
                    txtCommRate.Text = agent.calculateCommissionRate().ToString();
                    //Calculates earnings
                    commissionEarned = (int.Parse(txtSales.Text) * agent.calculateCommissionRate());
                    //Assigns and Formats Output
                    txtCommEarned.Text = string.Format("${0:#,0.00}", commissionEarned);
                    txtBonusReduction.Text = "0.00";
                }

            }
        }

        //Control event to clear form
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearform();
        }

        //Three events to validate if radio boxes are checked
        private void rdbJunior_CheckedChanged(object sender, EventArgs e)
        {
            agentChecked = true;
        }

        private void rdbAgent_CheckedChanged(object sender, EventArgs e)
        {
            agentChecked = true;
        }

        private void rdbSenior_CheckedChanged(object sender, EventArgs e)
        {
            agentChecked = true;
        }
    }
}
