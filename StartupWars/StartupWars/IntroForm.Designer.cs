namespace StartupWars
{
    partial class IntroForm
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
            this.btnEasy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEasyCapital = new System.Windows.Forms.Label();
            this.lblEasyDebt = new System.Windows.Forms.Label();
            this.lblEasyGameLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEasy
            // 
            this.btnEasy.Font = new System.Drawing.Font("LCD Solid", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEasy.Location = new System.Drawing.Point(12, 63);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(124, 32);
            this.btnEasy.TabIndex = 0;
            this.btnEasy.Text = "EASY";
            this.btnEasy.UseVisualStyleBackColor = true;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(133, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Put Logo Here";
            // 
            // lblEasyCapital
            // 
            this.lblEasyCapital.AutoSize = true;
            this.lblEasyCapital.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasyCapital.ForeColor = System.Drawing.Color.White;
            this.lblEasyCapital.Location = new System.Drawing.Point(142, 63);
            this.lblEasyCapital.Name = "lblEasyCapital";
            this.lblEasyCapital.Size = new System.Drawing.Size(111, 13);
            this.lblEasyCapital.TabIndex = 2;
            this.lblEasyCapital.Text = "Capital - $100,000";
            // 
            // lblEasyDebt
            // 
            this.lblEasyDebt.AutoSize = true;
            this.lblEasyDebt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasyDebt.ForeColor = System.Drawing.Color.White;
            this.lblEasyDebt.Location = new System.Drawing.Point(259, 63);
            this.lblEasyDebt.Name = "lblEasyDebt";
            this.lblEasyDebt.Size = new System.Drawing.Size(92, 13);
            this.lblEasyDebt.TabIndex = 3;
            this.lblEasyDebt.Text = "Debt - $25,000";
            // 
            // lblEasyGameLength
            // 
            this.lblEasyGameLength.AutoSize = true;
            this.lblEasyGameLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasyGameLength.ForeColor = System.Drawing.Color.White;
            this.lblEasyGameLength.Location = new System.Drawing.Point(142, 78);
            this.lblEasyGameLength.Name = "lblEasyGameLength";
            this.lblEasyGameLength.Size = new System.Drawing.Size(153, 13);
            this.lblEasyGameLength.TabIndex = 4;
            this.lblEasyGameLength.Text = "Game Length - 24 Months";
            // 
            // IntroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(358, 180);
            this.Controls.Add(this.lblEasyGameLength);
            this.Controls.Add(this.lblEasyDebt);
            this.Controls.Add(this.lblEasyCapital);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEasy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IntroForm";
            this.Text = "IntroForm";
            this.Load += new System.EventHandler(this.IntroForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEasyCapital;
        private System.Windows.Forms.Label lblEasyDebt;
        private System.Windows.Forms.Label lblEasyGameLength;
    }
}