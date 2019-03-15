namespace StartupWars
{
    partial class EmployeeDetailsForm
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
            this.lblEmployeeInformation = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtboxEmployeeDetails = new System.Windows.Forms.TextBox();
            this.btnTerminateEmployee = new System.Windows.Forms.Button();
            this.lblFinalMonth = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEmployeeInformation
            // 
            this.lblEmployeeInformation.AutoSize = true;
            this.lblEmployeeInformation.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeInformation.Location = new System.Drawing.Point(12, 9);
            this.lblEmployeeInformation.Name = "lblEmployeeInformation";
            this.lblEmployeeInformation.Size = new System.Drawing.Size(250, 23);
            this.lblEmployeeInformation.TabIndex = 23;
            this.lblEmployeeInformation.Text = "Employee Information";
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(12, 200);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 23);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtboxEmployeeDetails
            // 
            this.txtboxEmployeeDetails.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxEmployeeDetails.Location = new System.Drawing.Point(12, 41);
            this.txtboxEmployeeDetails.Multiline = true;
            this.txtboxEmployeeDetails.Name = "txtboxEmployeeDetails";
            this.txtboxEmployeeDetails.ReadOnly = true;
            this.txtboxEmployeeDetails.Size = new System.Drawing.Size(251, 118);
            this.txtboxEmployeeDetails.TabIndex = 25;
            // 
            // btnTerminateEmployee
            // 
            this.btnTerminateEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminateEmployee.Location = new System.Drawing.Point(149, 200);
            this.btnTerminateEmployee.Name = "btnTerminateEmployee";
            this.btnTerminateEmployee.Size = new System.Drawing.Size(114, 23);
            this.btnTerminateEmployee.TabIndex = 27;
            this.btnTerminateEmployee.Text = "Terminate Employee";
            this.btnTerminateEmployee.UseVisualStyleBackColor = true;
            this.btnTerminateEmployee.Click += new System.EventHandler(this.btnTerminateEmployee_Click);
            // 
            // lblFinalMonth
            // 
            this.lblFinalMonth.AutoSize = true;
            this.lblFinalMonth.Location = new System.Drawing.Point(12, 162);
            this.lblFinalMonth.Name = "lblFinalMonth";
            this.lblFinalMonth.Size = new System.Drawing.Size(69, 13);
            this.lblFinalMonth.TabIndex = 28;
            this.lblFinalMonth.Text = "lblFinalMonth";
            this.lblFinalMonth.Visible = false;
            // 
            // EmployeeDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(275, 235);
            this.Controls.Add(this.lblFinalMonth);
            this.Controls.Add(this.btnTerminateEmployee);
            this.Controls.Add(this.txtboxEmployeeDetails);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblEmployeeInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeDetailsForm";
            this.Text = "EmployeeDetailsForm";
            this.Load += new System.EventHandler(this.EmployeeDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmployeeInformation;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtboxEmployeeDetails;
        private System.Windows.Forms.Button btnTerminateEmployee;
        private System.Windows.Forms.Label lblFinalMonth;
    }
}