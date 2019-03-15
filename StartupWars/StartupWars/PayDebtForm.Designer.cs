namespace StartupWars
{
    partial class PayDebtForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.lblPayOffDebt = new System.Windows.Forms.Label();
            this.txtboxDebtInfo = new System.Windows.Forms.TextBox();
            this.lblTotalDebt = new System.Windows.Forms.Label();
            this.lblAmountToPay = new System.Windows.Forms.Label();
            this.txtboxAmountToPay = new System.Windows.Forms.TextBox();
            this.btnPayDebt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(12, 98);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 23);
            this.btnExit.TabIndex = 26;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblPayOffDebt
            // 
            this.lblPayOffDebt.AutoSize = true;
            this.lblPayOffDebt.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayOffDebt.Location = new System.Drawing.Point(12, 9);
            this.lblPayOffDebt.Name = "lblPayOffDebt";
            this.lblPayOffDebt.Size = new System.Drawing.Size(154, 23);
            this.lblPayOffDebt.TabIndex = 29;
            this.lblPayOffDebt.Text = "Pay Off Debt";
            // 
            // txtboxDebtInfo
            // 
            this.txtboxDebtInfo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxDebtInfo.Location = new System.Drawing.Point(98, 45);
            this.txtboxDebtInfo.Name = "txtboxDebtInfo";
            this.txtboxDebtInfo.ReadOnly = true;
            this.txtboxDebtInfo.Size = new System.Drawing.Size(134, 20);
            this.txtboxDebtInfo.TabIndex = 30;
            this.txtboxDebtInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalDebt
            // 
            this.lblTotalDebt.AutoSize = true;
            this.lblTotalDebt.Location = new System.Drawing.Point(32, 48);
            this.lblTotalDebt.Name = "lblTotalDebt";
            this.lblTotalDebt.Size = new System.Drawing.Size(60, 13);
            this.lblTotalDebt.TabIndex = 31;
            this.lblTotalDebt.Text = "Total Debt:";
            // 
            // lblAmountToPay
            // 
            this.lblAmountToPay.AutoSize = true;
            this.lblAmountToPay.Location = new System.Drawing.Point(13, 75);
            this.lblAmountToPay.Name = "lblAmountToPay";
            this.lblAmountToPay.Size = new System.Drawing.Size(79, 13);
            this.lblAmountToPay.TabIndex = 32;
            this.lblAmountToPay.Text = "Amount to Pay:";
            // 
            // txtboxAmountToPay
            // 
            this.txtboxAmountToPay.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxAmountToPay.Location = new System.Drawing.Point(98, 72);
            this.txtboxAmountToPay.Name = "txtboxAmountToPay";
            this.txtboxAmountToPay.Size = new System.Drawing.Size(134, 20);
            this.txtboxAmountToPay.TabIndex = 0;
            this.txtboxAmountToPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtboxAmountToPay.TextChanged += new System.EventHandler(this.txtboxAmountToPay_TextChanged);
            // 
            // btnPayDebt
            // 
            this.btnPayDebt.Enabled = false;
            this.btnPayDebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayDebt.Location = new System.Drawing.Point(98, 98);
            this.btnPayDebt.Name = "btnPayDebt";
            this.btnPayDebt.Size = new System.Drawing.Size(134, 23);
            this.btnPayDebt.TabIndex = 34;
            this.btnPayDebt.Text = "Pay Debt";
            this.btnPayDebt.UseVisualStyleBackColor = true;
            this.btnPayDebt.Click += new System.EventHandler(this.btnPayDebt_Click);
            // 
            // PayDebtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(244, 133);
            this.Controls.Add(this.btnPayDebt);
            this.Controls.Add(this.txtboxAmountToPay);
            this.Controls.Add(this.lblAmountToPay);
            this.Controls.Add(this.lblTotalDebt);
            this.Controls.Add(this.txtboxDebtInfo);
            this.Controls.Add(this.lblPayOffDebt);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PayDebtForm";
            this.Text = "PayDebtForm";
            this.Load += new System.EventHandler(this.PayDebtForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblPayOffDebt;
        private System.Windows.Forms.TextBox txtboxDebtInfo;
        private System.Windows.Forms.Label lblTotalDebt;
        private System.Windows.Forms.Label lblAmountToPay;
        private System.Windows.Forms.TextBox txtboxAmountToPay;
        private System.Windows.Forms.Button btnPayDebt;
    }
}