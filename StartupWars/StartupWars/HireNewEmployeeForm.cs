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
    public partial class HireNewEmployeeForm : Form
    {
        public string JobTitle { get; set; }
        public decimal StartingWage { get; set; }
        public int Experience { get; set; }
        public int Productivity { get; set; }
        public static bool Cancel { get; set; }

        public HireNewEmployeeForm()
        {
            InitializeComponent();
        }

        private void HireNewEmployeeForm_Load(object sender, EventArgs e)
        { 
            CenterToParent();

            //populate text boxes with position details
            //disable Software Manager/CTO controls if these conditions are met
            txtboxSoftwareDeveloper1.Text = "  Starting Wage: $25.00/hr. - ($1,000 per week)\r\n" +
                                            "     Experience: 0\r\n" +
                                            "   Productivity: 2";

            txtboxSoftwareDeveloper2.Text = "  Starting Wage: $31.00/hr. - ($1,240 per week)\r\n" +
                                            "     Experience: 3\r\n" +
                                            "   Productivity: 4";

            if (StartupWars.employeeCount < 5 || StartupWars.managerCount >= 2)
            {
                txtboxSoftwareManager.Enabled = false;

                if (StartupWars.managerCount == 2)
                {
                    txtboxSoftwareManager.Text = "  You already have 2 Software Managers on staff.";
                }
                else
                {
                    txtboxSoftwareManager.Text = "";
                }

                btnHireSoftwareManager.Enabled = false;
                btnHireSoftwareManager.Visible = false;
            }
            else
            {
                txtboxSoftwareManager.Text = "  Starting Wage: $38.00/hr. - ($1,520 per week)\r\n" +
                                             "     Experience: 6\r\n" +
                                             "   Productivity: 5";
            }

            if (StartupWars.employeeCount < 8 || StartupWars.ctoHired == true)
            {
                txtboxChiefTechOfficer.Enabled = false;

                if (StartupWars.ctoHired == true)
                {
                    txtboxChiefTechOfficer.Text = "  You already have a CTO on staff.";
                }
                else
                {
                    txtboxChiefTechOfficer.Text = "";
                }

                btnHireChiefTechOfficer.Enabled = false;
                btnHireChiefTechOfficer.Visible = false;
            }
            else
            {
                txtboxChiefTechOfficer.Text = "  Starting Wage: $46.00/hr. - ($1,840 per week)\r\n" +
                                              "     Experience: 9\r\n" +
                                              "   Productivity: 6";
            }
        }

        private void btnHireSoftwareDeveloper1_Click(object sender, EventArgs e)
        {
            JobTitle = "SD1";
            StartingWage = 25.00M;
            Experience = 0;
            Productivity = 2;
            Cancel = false;
            Close();
        }

        private void btnHireSoftwareDeveloper2_Click(object sender, EventArgs e)
        {
            JobTitle = "SD2";
            StartingWage = 31.00M;
            Experience = 3;
            Productivity = 4;
            Cancel = false;
            Close();
        }

        private void btnHireSoftwareManager_Click(object sender, EventArgs e)
        {
            JobTitle = "SWM";
            StartingWage = 38.00M;
            Experience = 6;
            Productivity = 5;
            Cancel = false;
            Close();
        }

        private void btnHireChiefTechOfficer_Click(object sender, EventArgs e)
        {
            JobTitle = "CTO";
            StartingWage = 46.00M;
            Experience = 9;
            Productivity = 6;
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
