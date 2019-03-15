using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Levels of Employment and their requirements:
    1. Software Developer I  - Experience >= 0
    2. Software Developer II - Experience >= 3
    3. Software Manager      - Experience >= 6
    4. Chief Tech Officer    - Experience >= 9
*/

namespace StartupWars
{
    public class Employee
    {
        public int EmployeeIndex { get; set; }
        public string JobTitle { get; set; }
        public int MonthsEmployed { get; set; }
        public decimal Wage { get; set; }
        public int Experience { get; set; }     
        public int Productivity { get; set; }
        public int ProductivityKiller { get; set; } //value used to adjust Productivity
        public int ProjectPoints { get; set; } //earned when a project is completed
        public int MonthsSinceLastRaise { get; set; }
        public bool PromotionGiven { get; set; }
        public bool RaiseGiven { get; set; }

        //Employee constructor
        public Employee(int employeeIndex, string jobTitle, decimal wage, int experience,
            int productivity)
        {
            EmployeeIndex = employeeIndex;
            JobTitle = jobTitle;
            MonthsEmployed = 0;
            Wage = wage;
            Experience = experience;        
            Productivity = productivity;
            ProductivityKiller = 0;
            ProjectPoints = 0;
            MonthsSinceLastRaise = 0;
            PromotionGiven = false;
            RaiseGiven = false;
        }
    }
}
