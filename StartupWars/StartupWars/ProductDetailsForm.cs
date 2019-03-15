using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartupWars
{
    public partial class ProductDetailsForm : Form
    {
        private Product product;
        public static bool Discontinue { get; set; }

        public ProductDetailsForm(Product product)
        {
            this.product = product;
            Discontinue = false;

            InitializeComponent();
        }

        private void ProductDetailsForm_Load(object sender, EventArgs e)
        {
            CenterToParent();

            //Populate text box with product details
            txtboxProductDetails.Text = GetProductDetails();

            if (product.InDevelopment == true)
            {
                btnDiscontinueProduct.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDiscontinueProduct_Click(object sender, EventArgs e)
        {
            PopupBoxForm popupDiscontinue = new PopupBoxForm(
                "Are you sure you would like to Discontinue this product?",
                "Discontinue Product", "YesNo"); //create new Popup Box

            popupDiscontinue.ShowDialog(this); //display Popup Box as child form

            //discontinue product if user clicks "OK"
            //this will occur in the StartupWars class
            if (popupDiscontinue.YesClick)
            {
                Discontinue = true;
            }

            Close();
        }

        private string GetProductDetails()
        {
            var productDetails = "";
            var name = "";

            switch (product.ProductTitle)
            {
                case "MobileApp":
                    name = "Mobile Application";
                    break;
                case "PCGame":
                    name = "PC Game";
                    break;
                case "BusinessManagementSoftware":
                    name = "Business Management Software";
                    break;
                case "SocialMediaPlatform":
                    name = "Social Media Platform";
                    break;
                case "OperatingSystem":
                    name = "Operating System";
                    break;
            }


            if (product.InDevelopment == true)
            {
                productDetails = $"   Product Name: {name}\r\n\r\n" +
                                 $"  Product Level: {product.ProductLevel}\r\n" +
                                 $"     Popularity: [Undetermined]\r\n" +
                                 $"Monthly Revenue: [Undetermined]";
            }
            else
            {
                var revenue = "";

                if (product.Revenue < 0)
                {
                    revenue = $"-{Math.Abs(product.Revenue).ToString("C")}";
                }
                else
                {
                    revenue = $"{product.Revenue.ToString("C")}";
                }

                productDetails = $"   Product Name: {name}\r\n\r\n" +
                                 $"  Product Level: {product.ProductLevel}\r\n" +
                                 $"     Popularity: {product.Popularity}\r\n" +
                                 $"Monthly Revenue: {revenue}";
            }

            return productDetails;
        }
    }
}
