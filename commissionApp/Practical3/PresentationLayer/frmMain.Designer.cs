
namespace Practical3
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label lblFirstName;
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblSales = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSales = new System.Windows.Forms.TextBox();
            this.grbAgent = new System.Windows.Forms.GroupBox();
            this.rdbSenior = new System.Windows.Forms.RadioButton();
            this.rdbAgent = new System.Windows.Forms.RadioButton();
            this.rdbJunior = new System.Windows.Forms.RadioButton();
            this.lblCommEarned = new System.Windows.Forms.Label();
            this.lblCommRate = new System.Windows.Forms.Label();
            this.lblBonusReduction = new System.Windows.Forms.Label();
            this.txtCommEarned = new System.Windows.Forms.TextBox();
            this.txtCommRate = new System.Windows.Forms.TextBox();
            this.txtBonusReduction = new System.Windows.Forms.TextBox();
            lblFirstName = new System.Windows.Forms.Label();
            this.grbAgent.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new System.Drawing.Point(42, 86);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new System.Drawing.Size(106, 25);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "First Name:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(47, 474);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(114, 51);
            this.btnCalculate.TabIndex = 6;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(198, 474);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(116, 51);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(42, 150);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(104, 25);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(42, 214);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(62, 25);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Email:";
            // 
            // lblSales
            // 
            this.lblSales.AutoSize = true;
            this.lblSales.Location = new System.Drawing.Point(42, 278);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(131, 25);
            this.lblSales.TabIndex = 5;
            this.lblSales.Text = "Sales Amount:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(184, 77);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(230, 33);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(184, 141);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(230, 33);
            this.txtLastName.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(184, 205);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(230, 33);
            this.txtEmail.TabIndex = 3;
            // 
            // txtSales
            // 
            this.txtSales.Location = new System.Drawing.Point(184, 269);
            this.txtSales.Name = "txtSales";
            this.txtSales.Size = new System.Drawing.Size(230, 33);
            this.txtSales.TabIndex = 4;
            // 
            // grbAgent
            // 
            this.grbAgent.Controls.Add(this.rdbSenior);
            this.grbAgent.Controls.Add(this.rdbAgent);
            this.grbAgent.Controls.Add(this.rdbJunior);
            this.grbAgent.Location = new System.Drawing.Point(473, 77);
            this.grbAgent.Name = "grbAgent";
            this.grbAgent.Size = new System.Drawing.Size(296, 231);
            this.grbAgent.TabIndex = 5;
            this.grbAgent.TabStop = false;
            this.grbAgent.Text = "Agent Type";
            // 
            // rdbSenior
            // 
            this.rdbSenior.AutoSize = true;
            this.rdbSenior.Location = new System.Drawing.Point(21, 162);
            this.rdbSenior.Name = "rdbSenior";
            this.rdbSenior.Size = new System.Drawing.Size(139, 29);
            this.rdbSenior.TabIndex = 2;
            this.rdbSenior.TabStop = true;
            this.rdbSenior.Text = "Senior Agent";
            this.rdbSenior.UseVisualStyleBackColor = true;
            this.rdbSenior.CheckedChanged += new System.EventHandler(this.rdbSenior_CheckedChanged);
            // 
            // rdbAgent
            // 
            this.rdbAgent.AutoSize = true;
            this.rdbAgent.Location = new System.Drawing.Point(21, 104);
            this.rdbAgent.Name = "rdbAgent";
            this.rdbAgent.Size = new System.Drawing.Size(80, 29);
            this.rdbAgent.TabIndex = 1;
            this.rdbAgent.TabStop = true;
            this.rdbAgent.Text = "Agent";
            this.rdbAgent.UseVisualStyleBackColor = true;
            this.rdbAgent.CheckedChanged += new System.EventHandler(this.rdbAgent_CheckedChanged);
            // 
            // rdbJunior
            // 
            this.rdbJunior.AutoSize = true;
            this.rdbJunior.Location = new System.Drawing.Point(21, 47);
            this.rdbJunior.Name = "rdbJunior";
            this.rdbJunior.Size = new System.Drawing.Size(137, 29);
            this.rdbJunior.TabIndex = 0;
            this.rdbJunior.TabStop = true;
            this.rdbJunior.Text = "Junior Agent";
            this.rdbJunior.UseVisualStyleBackColor = true;
            this.rdbJunior.CheckedChanged += new System.EventHandler(this.rdbJunior_CheckedChanged);
            // 
            // lblCommEarned
            // 
            this.lblCommEarned.AutoSize = true;
            this.lblCommEarned.Location = new System.Drawing.Point(388, 426);
            this.lblCommEarned.Name = "lblCommEarned";
            this.lblCommEarned.Size = new System.Drawing.Size(183, 25);
            this.lblCommEarned.TabIndex = 0;
            this.lblCommEarned.Text = "Commission Earned:";
            // 
            // lblCommRate
            // 
            this.lblCommRate.AutoSize = true;
            this.lblCommRate.Location = new System.Drawing.Point(388, 485);
            this.lblCommRate.Name = "lblCommRate";
            this.lblCommRate.Size = new System.Drawing.Size(161, 25);
            this.lblCommRate.TabIndex = 0;
            this.lblCommRate.Text = "Commission Rate:";
            // 
            // lblBonusReduction
            // 
            this.lblBonusReduction.AutoSize = true;
            this.lblBonusReduction.Location = new System.Drawing.Point(388, 546);
            this.lblBonusReduction.Name = "lblBonusReduction";
            this.lblBonusReduction.Size = new System.Drawing.Size(159, 25);
            this.lblBonusReduction.TabIndex = 0;
            this.lblBonusReduction.Text = "Bonus/Reduction:";
            // 
            // txtCommEarned
            // 
            this.txtCommEarned.Location = new System.Drawing.Point(604, 423);
            this.txtCommEarned.Name = "txtCommEarned";
            this.txtCommEarned.ReadOnly = true;
            this.txtCommEarned.Size = new System.Drawing.Size(106, 33);
            this.txtCommEarned.TabIndex = 0;
            // 
            // txtCommRate
            // 
            this.txtCommRate.Location = new System.Drawing.Point(604, 484);
            this.txtCommRate.Name = "txtCommRate";
            this.txtCommRate.ReadOnly = true;
            this.txtCommRate.Size = new System.Drawing.Size(106, 33);
            this.txtCommRate.TabIndex = 0;
            // 
            // txtBonusReduction
            // 
            this.txtBonusReduction.Location = new System.Drawing.Point(604, 545);
            this.txtBonusReduction.Name = "txtBonusReduction";
            this.txtBonusReduction.ReadOnly = true;
            this.txtBonusReduction.Size = new System.Drawing.Size(106, 33);
            this.txtBonusReduction.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(822, 688);
            this.Controls.Add(this.txtBonusReduction);
            this.Controls.Add(this.txtCommRate);
            this.Controls.Add(this.txtCommEarned);
            this.Controls.Add(this.lblBonusReduction);
            this.Controls.Add(this.lblCommRate);
            this.Controls.Add(this.lblCommEarned);
            this.Controls.Add(this.grbAgent);
            this.Controls.Add(this.txtSales);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblSales);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(lblFirstName);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCalculate);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmMain";
            this.Text = "Sales";
            this.grbAgent.ResumeLayout(false);
            this.grbAgent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblSales;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSales;
        private System.Windows.Forms.GroupBox grbAgent;
        private System.Windows.Forms.RadioButton rdbSenior;
        private System.Windows.Forms.RadioButton rdbAgent;
        private System.Windows.Forms.RadioButton rdbJunior;
        private System.Windows.Forms.Label lblCommEarned;
        private System.Windows.Forms.Label lblCommRate;
        private System.Windows.Forms.Label lblBonusReduction;
        private System.Windows.Forms.TextBox txtCommEarned;
        private System.Windows.Forms.TextBox txtCommRate;
        private System.Windows.Forms.TextBox txtBonusReduction;
    }
}

