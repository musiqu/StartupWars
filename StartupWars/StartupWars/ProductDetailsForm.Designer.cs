namespace StartupWars
{
    partial class ProductDetailsForm
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
            this.btnDiscontinueProduct = new System.Windows.Forms.Button();
            this.txtboxProductDetails = new System.Windows.Forms.TextBox();
            this.lblProductInformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(12, 173);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 23);
            this.btnExit.TabIndex = 25;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDiscontinueProduct
            // 
            this.btnDiscontinueProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscontinueProduct.Location = new System.Drawing.Point(218, 173);
            this.btnDiscontinueProduct.Name = "btnDiscontinueProduct";
            this.btnDiscontinueProduct.Size = new System.Drawing.Size(124, 23);
            this.btnDiscontinueProduct.TabIndex = 30;
            this.btnDiscontinueProduct.Text = "Discontinue Product";
            this.btnDiscontinueProduct.UseVisualStyleBackColor = true;
            this.btnDiscontinueProduct.Click += new System.EventHandler(this.btnDiscontinueProduct_Click);
            // 
            // txtboxProductDetails
            // 
            this.txtboxProductDetails.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxProductDetails.Location = new System.Drawing.Point(12, 41);
            this.txtboxProductDetails.Multiline = true;
            this.txtboxProductDetails.Name = "txtboxProductDetails";
            this.txtboxProductDetails.ReadOnly = true;
            this.txtboxProductDetails.Size = new System.Drawing.Size(330, 118);
            this.txtboxProductDetails.TabIndex = 29;
            // 
            // lblProductInformation
            // 
            this.lblProductInformation.AutoSize = true;
            this.lblProductInformation.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductInformation.Location = new System.Drawing.Point(12, 9);
            this.lblProductInformation.Name = "lblProductInformation";
            this.lblProductInformation.Size = new System.Drawing.Size(238, 23);
            this.lblProductInformation.TabIndex = 28;
            this.lblProductInformation.Text = "Product Information";
            // 
            // ProductDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(354, 208);
            this.Controls.Add(this.btnDiscontinueProduct);
            this.Controls.Add(this.txtboxProductDetails);
            this.Controls.Add(this.lblProductInformation);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductDetailsForm";
            this.Text = "ProductDetailsForm";
            this.Load += new System.EventHandler(this.ProductDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDiscontinueProduct;
        private System.Windows.Forms.TextBox txtboxProductDetails;
        private System.Windows.Forms.Label lblProductInformation;
    }
}