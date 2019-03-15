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
    public partial class NewProductForm : Form
    {
        public string ProductTitle { get; set; }
        public int CurrentDevelopmentPoints { get; set; }
        public int RequiredDevelopmentPoints { get; set; }
        public int Popularity { get; set; }
        public int ProductLevel { get; set; }
        public static bool Cancel { get; set; }

        public NewProductForm()
        {
            InitializeComponent();
        }

        private void NewProductForm_Load(object sender, EventArgs e)
        {
            CenterToParent();

            //populate text boxes with position details
            txtboxMobileAppProduct.Text = "  Required Development Points: 15\r\n" +
                                          "                Product Level: 1\r\n";

            txtboxPCGameProduct.Text = "  Required Development Points: 30\r\n" +
                                       "                Product Level: 2\r\n";

            txtboxBusinessManagementSoftwareProduct.Text = "  Required Development Points: 55\r\n" +
                                                           "                Product Level: 3\r\n";

            txtboxSocialMediaPlatformProduct.Text = "  Required Development Points: 75\r\n" +
                                                    "                Product Level: 4\r\n";

            txtboxOperatingSystemProduct.Text = "  Required Development Points: 90\r\n" +
                                                "                Product Level: 5\r\n";
        }

        private void btnDevelopMobileApp_Click(object sender, EventArgs e)
        {
            ProductTitle = "MobileApp";
            CurrentDevelopmentPoints = 0;
            RequiredDevelopmentPoints = 15;
            Popularity = 10;
            ProductLevel = 1;
            Cancel = false;
            Close();
        }

        private void btnDevelopPCGame_Click(object sender, EventArgs e)
        {
            ProductTitle = "PCGame";
            CurrentDevelopmentPoints = 0;
            RequiredDevelopmentPoints = 30;
            Popularity = 10;
            ProductLevel = 2;
            Cancel = false;
            Close();
        }

        private void btnDevelopBusinessManagementSoftware_Click(object sender, EventArgs e)
        {
            ProductTitle = "BusinessManagementSoftware";
            CurrentDevelopmentPoints = 0;
            RequiredDevelopmentPoints = 55;
            Popularity = 10;
            ProductLevel = 3;
            Cancel = false;
            Close();
        }

        private void btnDevelopSocialMediaPlatform_Click(object sender, EventArgs e)
        {
            ProductTitle = "SocialMediaPlatform";
            CurrentDevelopmentPoints = 0;
            RequiredDevelopmentPoints = 75;
            Popularity = 10;
            ProductLevel = 4;
            Cancel = false;
            Close();
        }

        private void btnOperatingSystemProduct_Click(object sender, EventArgs e)
        {
            ProductTitle = "OperatingSystem";
            CurrentDevelopmentPoints = 0;
            RequiredDevelopmentPoints = 90;
            Popularity = 10;
            ProductLevel = 5;
            Cancel = false;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel = true;
            Close();
        }
    }
}
