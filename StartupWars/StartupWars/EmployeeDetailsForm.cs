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
    public partial class EmployeeDetailsForm : Form
    {
        private Employee employee;
        public static bool Terminate { get; set; }
        public decimal Severance { get; set; }

        public EmployeeDetailsForm(Employee emp)
        {
            employee = emp;
            Terminate = false;
            Severance = 0.00M;

            InitializeComponent();
        }

        private void EmployeeDetailsForm_Load(object sender, EventArgs e)
        {
            CenterToParent();

            //Populate text box with employee details
            txtboxEmployeeDetails.Text = GetEmployeeDetails();

            //disable terminate button and make lblFinalMonth visible on final month
            if (StartupWars.months == StartupWars.gameLength)
            {
                btnTerminateEmployee.Enabled = false;
                lblFinalMonth.Text = "Employees cannot be terminated on the final month.";
                lblFinalMonth.Visible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTerminateEmployee_Click(object sender, EventArgs e)
        {
            SetSeveranceAmount(employee);

            PopupBoxForm popupTerminate = new PopupBoxForm(
                "Are you sure you would like to Terminate this employee?\r\n" +
                $"Severance: {Severance.ToString("C")}",
                "Terminate Employee", "YesNo"); // create new PopUpBox
            popupTerminate.ShowDialog(this); //display Popup box as child form

            //terminate employee if user clicks "OK"
            //this will occur in the StartupWars class
            if (popupTerminate.YesClick)
            {
                Terminate = true;
            }
            
            Close();
        }

        private string GetEmployeeDetails()
        {
            var empDetails = $" Job Title: {SetJobTitle(employee.JobTitle)}\r\n\r\n" +
                              $"Months Employed: {employee.MonthsEmployed}\r\n" +
                              $"           Wage: ${employee.Wage}/hr.\r\n" +
                              $"     Experience: {employee.Experience}\r\n" +
                              $"   Productivity: {employee.Productivity}";

            return empDetails;
        }

        private string SetJobTitle(string title)
        {
            var jobTitle = "";

            switch (title)
            {
                case "SD1":
                    jobTitle = "Software Developer I";
                    break;
                case "SD2":
                    jobTitle = "Software Developer II";
                    break;
                case "SWM":
                    jobTitle = "Software Manager";
                    break;
                case "CTO":
                    jobTitle = "Chief Tech Officer";
                    break;
            }

            return jobTitle;
        }

        private void SetSeveranceAmount(Employee employee)
        {
            switch (employee.JobTitle)
            {
                case "SD1":
                    Severance = employee.Wage * 320; //2 months pay
                    break;
                case "SD2":
                    Severance = (employee.Wage * 320) + 500; //2 months pay + 500
                    break;
                case "SWM":
                    Severance = (employee.Wage * 320) + 1000; //2 months pay + 1000
                    break;
                case "CTO":
                    Severance = (employee.Wage * 320) + 2500; //2 months pay + 2500
                    break;
            }
        }
    }
}