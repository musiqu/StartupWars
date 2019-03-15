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
    public partial class StartupWars : Form
    {
        //Game variables
        private decimal bank;
        private decimal debt;
        public static int months = 1;
        public static int gameLength; //total game months (determined by difficulty level)
        private static decimal monthlyPropertyCost;
        private static decimal profit;
        private PictureBox iconLocation;

        //Employee array and variables
        private Employee[] employees = new Employee[12];
        public static int employeeCount = 0;
        public static int managerCount = 0;
        public static bool ctoHired = false;
        private static decimal totalWagesPerHour;

        //Product array and variables
        private Product[] products = new Product[8];
        private int productCount = 0;
        private int inDevelopmentCount = 0;
        private static decimal totalMonthlyRevenue;

        public string StaffInfo { get; set; } //used by StaffForm
        public string EmployeeDetails { get; set; } //used by EmployeeDetailsForm
        
        //constructor
        public StartupWars()
        {
            InitializeComponent();
        }

        //form load
        private void StartupWars_Load(object sender, EventArgs e)
        {
            CenterToScreen(); //center main form
            Show(); //show main form behind intro form

            //clear text boxes
            txtboxBank.Text = "";
            txtboxDebt.Text = "";
            txtboxMonths.Text = "";

            //initialize progress bars (visibility is off)
            pnlProgressBar1.Width = 0;
            pnlProgressBar2.Width = 0;
            pnlProgressBar3.Width = 0;
            pnlProgressBar4.Width = 0;

            //initialize Budget text boxes
            UpdateBudget_Revenue();
            UpdateBudget_Wages();

            //Launch IntroForm (User will determine game difficutly)
            IntroForm introForm = new IntroForm();
            introForm.ShowDialog(this);

            //Initialize starting values for game based on selected difficutly
            if (introForm.Difficulty == "Easy")
            {
                bank = introForm.StartBank;
                debt = introForm.StartDebt;
                gameLength = introForm.GameLength;
                monthlyPropertyCost = 1950.00M;
            }
            
            UpdateBudget_PropertyCost(); //set property cost text box

            //set starting game values (bank, debt, duration)
            Update_Bank_Debt_Month_TextBoxes();
        }

        //Hire New Employee Button
        private void btnHireNewEmployee_Click(object sender, EventArgs e)
        { 
            if (employeeCount < 12) //check for open position
            {
                HireNewEmployeeForm hireNewEmployeeForm = new HireNewEmployeeForm(); //create Form
                hireNewEmployeeForm.ShowDialog(this); //display hireNewEmployeeForm as child form

                if (!HireNewEmployeeForm.Cancel)
                {
                    //create new employee at first open position
                    for (int i = 0; i < employees.Length; i++)
                    {
                        if (employees[i] == null)
                        {
                            //create employee object
                            Employee employee = new Employee(i, hireNewEmployeeForm.JobTitle,
                                hireNewEmployeeForm.StartingWage, hireNewEmployeeForm.Experience,
                                hireNewEmployeeForm.Productivity);

                            employees[i] = employee; //add employee to employees array
                            
                            //set employee icon
                            SetIconLocation(i);
                            iconLocation.Image =
                                (Image)(Properties.Resources.ResourceManager.GetObject(
                                    $"EmployeeIcon_{employee.JobTitle}"));

                            iconLocation.Enabled = true; //enable icon for click events

                            //turn on "New Product" button after first employee is hired
                            if (employeeCount == 0)
                            {
                                btnNewProduct.Enabled = true;
                            }

                            break; //end for loop
                        }
                    }

                    //show staff icon instructions
                    if (employeeCount == 0)
                    {
                        lblStaffIconInstructions.Text = "Click any of the \n" +
                                                        "employee icons above \n" +
                                                        "to view information, \n" +
                                                        "give a raise, or to \n" +
                                                        "terminate that \n" +
                                                        "employee";

                        lblStaffIconInstructions.Visible = true;
                    }

                    employeeCount++; //increment total employee count

                    //increment manager count or set ctoHired to true
                    if (hireNewEmployeeForm.JobTitle == "SWM")
                    {
                        managerCount++;
                    }
                    else if (hireNewEmployeeForm.JobTitle == "CTO")
                    {
                        ctoHired = true;
                    }

                    UpdateBudget_Wages(); //update Budget_Wages text box
                }
            }
            else
            {
                PopupBoxForm popup = new PopupBoxForm("No open positions remain.",
                    "All Positions Full", "OK"); // create new PopUpBox
                popup.ShowDialog(this); //display Popup box as child form
            }
        }

        //Cancel Development Button events
        private void btnCancelProject1_Click(object sender, EventArgs e)
        {
            CancelDevelopment(1);
        }

        private void btnCancelProject2_Click(object sender, EventArgs e)
        {
            CancelDevelopment(2);
        }

        private void btnCancelProject3_Click(object sender, EventArgs e)
        {
            CancelDevelopment(3);
        }

        private void btnCancelProject4_Click(object sender, EventArgs e)
        {
            CancelDevelopment(4);
        }

        //New Product Button
        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            // check for open product and development positions
            if (productCount < 8 && inDevelopmentCount < 4)
            {
                NewProductForm newProduct = new NewProductForm(); //create NewProductForm
                newProduct.ShowDialog(this); //show NewProduct form

                if (!NewProductForm.Cancel)
                {
                    //create new product at first open position
                    for (int i = 0; i < products.Length; i++)
                    {
                        if (products[i] == null)
                        {
                            //create product object
                            Product product = new Product(i, newProduct.ProductTitle,
                                newProduct.RequiredDevelopmentPoints, newProduct.ProductLevel);

                            products[i] = product; //add product to products array

                            //set product in development icon
                            SetIconLocation(i + 12);
                            iconLocation.Image =
                                (Image)(Properties.Resources.ResourceManager.GetObject(
                                "ProductInDevelopmentIcon"));

                            iconLocation.Enabled = true; //enable icon for click events

                            //set Development panel icon, progress bar, and Cancel button
                            if (pnlDevelopment1.BackgroundImage == null)
                            {
                                pnlDevelopment1.BackgroundImage =
                                    (Image)(Properties.Resources.ResourceManager.GetObject(
                                        "ProductInDevelopmentIcon_DevoCone"));

                                product.ProgressBarAssignment = 1;
                                pnlProgressBar1.Visible = true;
                                btnCancelProject1.Enabled = true;
                            }
                            else if (pnlDevelopment2.BackgroundImage == null)
                            {
                                pnlDevelopment2.BackgroundImage =
                                    (Image)(Properties.Resources.ResourceManager.GetObject(
                                        "ProductInDevelopmentIcon_DevoCone"));

                                product.ProgressBarAssignment = 2;
                                pnlProgressBar2.Visible = true;
                                btnCancelProject2.Enabled = true;
                            }
                            else if (pnlDevelopment3.BackgroundImage == null)
                            {
                                pnlDevelopment3.BackgroundImage =
                                    (Image)(Properties.Resources.ResourceManager.GetObject(
                                        "ProductInDevelopmentIcon_DevoCone"));

                                product.ProgressBarAssignment = 3;
                                pnlProgressBar3.Visible = true;
                                btnCancelProject3.Enabled = true;
                            }
                            else
                            {
                                pnlDevelopment4.BackgroundImage =
                                    (Image)(Properties.Resources.ResourceManager.GetObject(
                                        "ProductInDevelopmentIcon_DevoCone"));

                                product.ProgressBarAssignment = 4;
                                pnlProgressBar4.Visible = true;
                                btnCancelProject4.Enabled = true;
                            }

                            inDevelopmentCount++; //increment development count
                            break;
                        }
                    }

                    //show staff icon instructions
                    if (productCount == 0)
                    {
                        lblProductInfo.Text = "Click any product\n" +
                                              "icon to view info\n" +
                                              "or discontinue\n" +
                                              "a product.";

                        lblProductInfo.Visible = true;
                    }

                    productCount++; //increment product count
                }
            }
            else
            {
                PopupBoxForm popup = new PopupBoxForm("No new products can be developed.",
                    "All Product Positions Full", "OK"); // create new PopUpBox
                popup.ShowDialog(this); //display Popup box as child form
            }
        }

        //Pay Debt button
        private void btnPayDebt_Click(object sender, EventArgs e)
        {
            if (debt > 0.0M)
            {
                PayDebtForm payDebtForm = new PayDebtForm(debt);
                payDebtForm.ShowDialog(this); //Show payDebtForm

                //update debt after form has been closed
                debt = payDebtForm.Debt;

                //round debt amount down
                if (debt < 0.01M)
                {
                    debt = 0.00M;
                }

                bank -= payDebtForm.AmountPaid;
                Update_Bank_Debt_Month_TextBoxes();
            }
            else
            {
                PopupBoxForm popup = new PopupBoxForm("All debts have been paid.",
                   "No Debt", "OK"); // create new PopUpBox
                popup.ShowDialog(this); //display Popup box as child form
            }
        }

        //End Month button - This progresses the game
        private void btnEndMonth_Click(object sender, EventArgs e)
        {
            //Update all necessary fields/controls
            bank += profit;

            if (bank < 0.00M)
            {
                GetLoan();
            }

            debt *= 1.07M; //increase dept by 7% (interest)
            debt = Math.Round(debt, 2); //round debt value       
            months++; //increment month count
            Update_Bank_Debt_Month_TextBoxes(); //updates text boxes

            //run if products are in development
            if (inDevelopmentCount > 0)
            {
                MonthlyProductDevelopment();
                UpdateProgressBars();
                
                //everything below is for testing/debugging
                var bugString = "";
                foreach (Product product in products)
                {
                    if (product != null)
                    {
                        bugString += $"{product.ProductTitle} - " +
                        $"currentPoints = {product.CurrentDevelopmentPoints} " +
                        $"requiredPoints = {product.RequiredDevelopmentPoints}\r\n";
                    }
                }

                MessageBox.Show(bugString);
            }

            //run product algorithms
            GameAlgorithms.RunProductAlgorithms(products);

            UpdateBudget_Revenue(); //update total montly revenue
            UpdateBudget_Wages(); //update total monthly wages              
            UpdateBudget_PropertyCost(); //update property cost

            //if game has finished
            if (months == gameLength)
            {
                EndGame();
            }
        }

        //StartupWars Methods
        private void CancelDevelopment(int location)
        {
            PopupBoxForm popup = new PopupBoxForm("Are you sure you would like to end " +
                "development for this product?", 
                "Cancel Development?", "YesNo"); // create new PopUpBox
            popup.ShowDialog(this); //display Popup box as child form

            if (popup.YesClick == true) //set cancel to true if Yes was clicked
            {
                //remove Development Panel icon, reset progress bar, and disable Cancel button
                switch (location)
                {
                    case 1:
                        pnlDevelopment1.BackgroundImage = null;
                        pnlProgressBar1.Width = 0;
                        btnCancelProject1.Enabled = false;
                        break;
                    case 2:
                        pnlDevelopment2.BackgroundImage = null;
                        pnlProgressBar2.Width = 0;
                        btnCancelProject2.Enabled = false;
                        break;
                    case 3:
                        pnlDevelopment3.BackgroundImage = null;
                        pnlProgressBar3.Width = 0;
                        btnCancelProject3.Enabled = false;
                        break;
                    case 4:
                        pnlDevelopment4.BackgroundImage = null;
                        pnlProgressBar4.Width = 0;
                        btnCancelProject4.Enabled = false;
                        break;
                }

                //remove product from products array and remove product icon
                foreach (Product product in products)
                {
                    if (product != null && product.ProgressBarAssignment == location && 
                        product.InDevelopment == true)
                    {
                        //remove Product icon
                        switch (product.ProductIndex)
                        {
                            case 0:
                                picboxProduct1.Image = null;
                                picboxProduct1.Enabled = false;
                                break;
                            case 1:
                                picboxProduct2.Image = null;
                                picboxProduct2.Enabled = false;
                                break;
                            case 2:
                                picboxProduct3.Image = null;
                                picboxProduct3.Enabled = false;
                                break;
                            case 3:
                                picboxProduct4.Image = null;
                                picboxProduct4.Enabled = false;
                                break;
                            case 4:
                                picboxProduct5.Image = null;
                                picboxProduct5.Enabled = false;
                                break;
                            case 5:
                                picboxProduct6.Image = null;
                                picboxProduct6.Enabled = false;
                                break;
                            case 6:
                                picboxProduct7.Image = null;
                                picboxProduct7.Enabled = false;
                                break;
                            case 7:
                                picboxProduct8.Image = null;
                                picboxProduct8.Enabled = false;
                                break;
                        }

                        //remove product from products array
                        products[product.ProductIndex] = null;
                        break; //end foreach loop (product was found)
                    }
                }

                inDevelopmentCount--; //decrement in development count
                productCount--; //decrement product count

                if (productCount == 0)
                {
                    lblProductInfo.Text = "";
                }
            }
        }

        private void DevelopmentCompleted(Product product)
        {
            //update development icon, disable Cancel button, and reset progress bar
            switch (product.ProgressBarAssignment)
            {
                case 1:
                    pnlDevelopment1.BackgroundImage = null;
                    btnCancelProject1.Enabled = false;
                    pnlProgressBar1.Width = 0;
                    break;
                case 2:
                    pnlDevelopment2.BackgroundImage = null;
                    btnCancelProject2.Enabled = false;
                    pnlProgressBar2.Width = 0;
                    break;
                case 3:
                    pnlDevelopment3.BackgroundImage = null;
                    btnCancelProject3.Enabled = false;
                    pnlProgressBar3.Width = 0;
                    break;
                case 4:
                    pnlDevelopment4.BackgroundImage = null;
                    btnCancelProject4.Enabled = false;
                    pnlProgressBar4.Width = 0;
                    break;
            }

            //update product icon
            var image = (Image)Properties.Resources.ResourceManager.
                        GetObject($"ProductIcon_{product.ProductTitle}");

            switch (product.ProductIndex)
            {
                case 0:
                    picboxProduct1.Image = image;
                    break;
                case 1:
                    picboxProduct2.Image = image;
                    break;
                case 2:
                    picboxProduct3.Image = image;
                    break;
                case 3:
                    picboxProduct4.Image = image;
                    break;
                case 4:
                    picboxProduct5.Image = image;
                    break;
                case 5:
                    picboxProduct6.Image = image;
                    break;
                case 6:
                    picboxProduct7.Image = image;
                    break;
                case 7:
                    picboxProduct8.Image = image;
                    break;
            }

            product.InDevelopment = false;
            inDevelopmentCount--; //decrement in development count
            UpdateBudget_Revenue(); //update total monthly revenue
        }

        private void EndGame()
        {
            var score = "";

            if ((bank - debt) < 0)
            {
                score = $"-{Math.Abs(bank - debt).ToString("C")}";
            }
            else
            {
                score = $"{Math.Abs(bank - debt).ToString("C")}";
            }

            PopupBoxForm popupEnd = new PopupBoxForm("The Game has ended.\r\n\r\n" +
                $"Score: {score}",
                "Game Over", "OK"); // create new PopUpBox
            popupEnd.ShowDialog(this); //display Popup box as child form
            Application.Exit();
        }

        private void GetLoan()
        {
            decimal loan = Math.Abs(bank) * 2;

            PopupBoxForm loanPopup = new PopupBoxForm("A loan has been granted for the " +
                $"following amount: {loan.ToString("C")}", "You ran out of money!", "OK");
            loanPopup.ShowDialog(this);

            bank += loan;
            debt += loan;
            Update_Bank_Debt_Month_TextBoxes();
        }

        private void LaunchEmployeeDetails(int empIndex)
        {
            Employee emp = employees[empIndex]; //get employee object from array

            //launch employee info form
            EmployeeDetailsForm empDetailsForm = new EmployeeDetailsForm(emp); //create EmpDetailsForm
            empDetailsForm.ShowDialog(this); //Show EmployeeDetailsForm

            if (EmployeeDetailsForm.Terminate == true)
            {
                TerminateEmployee(empIndex, empDetailsForm.Severance);
            }
        }

        private void LaunchProductDetails(int productIndex)
        {
            Product product = products[productIndex]; //get product object from array

            //create ProductDetailsForm
            ProductDetailsForm productDetailsForm = new ProductDetailsForm(product);
            productDetailsForm.ShowDialog(this); //Show ProductDetailsForm

            if (ProductDetailsForm.Discontinue == true)
            {
                products[productIndex] = null; //remove product from products array

                //remove icon and disable control
                SetIconLocation(productIndex + 12);
                iconLocation.Image = null;
                iconLocation.Enabled = false;

                productCount--; //decrement product count
                UpdateBudget_Revenue(); //update Budget_Wages text box

                if (productCount == 0) //hide product instructions if no products remain
                {
                    lblProductInfo.Visible = false;
                }
            }
        }

        private void MonthlyProductDevelopment()
        {
            var monthlyProductivity = 0;
            var pointsPerProduct = 0;
            var remainder = 0;
            var extraPoints = 0;
            var firstPass = true;

            foreach (Employee employee in employees)
            {
                if (employee != null)
                {
                    monthlyProductivity += employee.Productivity; //determine total productivity
                }
            }

            //determine how many development points go to each product
            pointsPerProduct = monthlyProductivity / inDevelopmentCount;
            remainder = monthlyProductivity % inDevelopmentCount;

            do
            {
                foreach (Product product in products)
                {
                    if (product != null && product.InDevelopment == true)
                    {
                        if (firstPass == true) //add points to each product on first pass
                        {
                            product.CurrentDevelopmentPoints += pointsPerProduct;
                        }

                        if (remainder > 0) //add a remainder point if available
                        {
                            product.CurrentDevelopmentPoints += 1; //add one point from remainder
                            remainder--; //decrement remainder
                        }

                        if (extraPoints > 0) //add an extra point if available
                        {
                            product.CurrentDevelopmentPoints += 1; // add on point from extraPoints
                            extraPoints--; //decrement extraPoints
                        }

                        //if development for product has been completed
                        if (product.CurrentDevelopmentPoints >= product.RequiredDevelopmentPoints)
                        {
                            DevelopmentCompleted(product); //updates icons, counts, and buttons

                            //add any remaining points to extraPoints
                            var extra = product.CurrentDevelopmentPoints -
                                product.RequiredDevelopmentPoints;
                            extraPoints += extra;
                        }

                        if (firstPass == false && extraPoints == 0) //break from foreach loop 
                        {
                            break;
                        }
                    }
                }

                firstPass = false; // end initial pass through do-while loop

            } while (extraPoints > 0 && inDevelopmentCount > 0);
        }

        private string SetIcon(int iconIndex, string iconType, bool hover)
        {
            var hoverIconString = "";

            if (iconType == "employee")
            {
                switch (employees[iconIndex].JobTitle) //set hover icon filename
                {
                    case "SD1":
                        if (hover == true)
                            hoverIconString = "EmployeeIcon_SD1_Hover";
                        else
                            hoverIconString = "EmployeeIcon_SD1";
                        break;

                    case "SD2":
                        if (hover == true)
                            hoverIconString = "EmployeeIcon_SD2_Hover";
                        else
                            hoverIconString = "EmployeeIcon_SD2";
                        break;

                    case "SWM":
                        if (hover == true)
                            hoverIconString = "EmployeeIcon_SWM_Hover";
                        else
                            hoverIconString = "EmployeeIcon_SWM";
                        break;

                    case "CTO":
                        if (hover == true)
                            hoverIconString = "EmployeeIcon_CTO_Hover";
                        else
                            hoverIconString = "EmployeeIcon_CTO";
                        break;
                }
            }
            else if (iconType == "product")
            {
                switch (products[iconIndex].ProductTitle) //set hover icon filename
                {
                    case "MobileApp":
                        if (hover == true)
                            hoverIconString = "ProductIcon_MobileApp_Hover";
                        else
                            hoverIconString = "ProductIcon_MobileApp";
                        break;
                    case "PCGame":
                        if (hover == true)
                            hoverIconString = "ProductIcon_PCGame_Hover";
                        else
                            hoverIconString = "ProductIcon_PCGame";
                        break;
                    case "BusinessManagementSoftware":
                        if (hover == true)
                            hoverIconString = "ProductIcon_BusinessManagementSoftware_Hover";
                        else
                            hoverIconString = "ProductIcon_BusinessManagementSoftware";
                        break;
                    case "SocialMediaPlatform":
                        if (hover == true)
                            hoverIconString = "ProductIcon_SocialMediaPlatform_Hover";
                        else
                            hoverIconString = "ProductIcon_SocialMediaPlatform";
                        break;
                    case "OperatingSystem":
                        if (hover == true)
                            hoverIconString = "ProductIcon_OperatingSystem_Hover";
                        else
                            hoverIconString = "ProductIcon_OperatingSystem";
                        break;
                }
            }

            return hoverIconString;
        }

        private void SetIconLocation(int position)
        {
            switch (position) //set iconLocation
            {
                case 0:
                    iconLocation = picboxEmployee1;
                    break;
                case 1:
                    iconLocation = picboxEmployee2;
                    break;
                case 2:
                    iconLocation = picboxEmployee3;
                    break;
                case 3:
                    iconLocation = picboxEmployee4;
                    break;
                case 4:
                    iconLocation = picboxEmployee5;
                    break;
                case 5:
                    iconLocation = picboxEmployee6;
                    break;
                case 6:
                    iconLocation = picboxEmployee7;
                    break;
                case 7:
                    iconLocation = picboxEmployee8;
                    break;
                case 8:
                    iconLocation = picboxEmployee9;
                    break;
                case 9:
                    iconLocation = picboxEmployee10;
                    break;
                case 10:
                    iconLocation = picboxEmployee11;
                    break;
                case 11:
                    iconLocation = picboxEmployee12;
                    break;

                //product icon locations start here
                case 12:
                    iconLocation = picboxProduct1;
                    break;
                case 13:
                    iconLocation = picboxProduct2;
                    break;
                case 14:
                    iconLocation = picboxProduct3;
                    break;
                case 15:
                    iconLocation = picboxProduct4;
                    break;
                case 16:
                    iconLocation = picboxProduct5;
                    break;
                case 17:
                    iconLocation = picboxProduct6;
                    break;
                case 18:
                    iconLocation = picboxProduct7;
                    break;
                case 19:
                    iconLocation = picboxProduct8;
                    break;
            }
        }

        private void TerminateEmployee(int empIndex, decimal severance)
        {
            //remove icon and disable control
            SetIconLocation(empIndex);
            iconLocation.Image = null;
            iconLocation.Enabled = false;

            //pay out severance
            bank -= severance;
            Update_Bank_Debt_Month_TextBoxes();

            if (employees[empIndex].JobTitle == "SWM")
            {
                managerCount--;
            }
            else if (employees[empIndex].JobTitle == "CTO")
            {
                ctoHired = false;
            }

            employees[empIndex] = null; //remove employee from employees array
            employeeCount--; //decrement employee count 

            UpdateBudget_Wages(); //update Budget_Wages text box

            if (employeeCount == 0) //hide staffIconInstructions if no employees remain
            {
                lblStaffIconInstructions.Visible = false; //hide staff instructions
                btnNewProduct.Enabled = false; //disable new product button
            }
        }

        private void UpdateProgressBars()
        {
            //increment progress bars
            foreach (Product product in products)
            {
                if (product != null && product.InDevelopment == true)
                {
                    var steps = 90.0M / product.RequiredDevelopmentPoints;
                    var width = product.CurrentDevelopmentPoints * steps;

                    switch (product.ProgressBarAssignment)
                    {
                        case 1:
                            pnlProgressBar1.Width = (int) width;
                            break;
                        case 2:
                            pnlProgressBar2.Width = (int) width;
                            break;
                        case 3:
                            pnlProgressBar3.Width = (int) width;
                            break;
                        case 4:
                            pnlProgressBar4.Width = (int) width;
                            break;
                    }
                }
            }
        }
        
        private void Update_Bank_Debt_Month_TextBoxes()
        {
            if (bank < 0.00M)
            {
                //force user to take out loan
                //we don't want this value to be negative

                txtboxBank.Text = $"-{Math.Abs(bank).ToString("C")}";
            }
            else
            {
                txtboxBank.Text = $"{bank.ToString("C")}";
            }
      
            txtboxDebt.Text = $"{debt.ToString("C")}";
            txtboxMonths.Text = $"{months.ToString()}/{gameLength.ToString()}";
        }      

        private void UpdateBudget_Revenue()
        {
            totalMonthlyRevenue = 0.00M;

            foreach (Product product in products) //sum all product revenues
            {
                if (product != null && product.InDevelopment == false)
                {
                    totalMonthlyRevenue += product.Revenue;
                }
            }

            if (totalMonthlyRevenue < 0)
            {
                txtboxRevenue.Text = $"-{Math.Abs(totalMonthlyRevenue).ToString("C")}";
            }
            else
            {
                txtboxRevenue.Text = $"{totalMonthlyRevenue.ToString("C")}";
            }
        }

        private void UpdateBudget_Wages()
        {
            totalWagesPerHour = 0.00M;

            foreach (Employee employee in employees) //sum all employee wages
            {
                if (employee != null)
                {
                    totalWagesPerHour += employee.Wage;
                }
            }

            txtboxWages.Text = $"-{(totalWagesPerHour * 160).ToString("C")}";
            //UpdateBudget_Profit();
        }

        private void UpdateBudget_PropertyCost()
        {
            //rent will increase every 12 months
            if (months != 0 && months != gameLength && months % 12 == 0)
            {
                Random random = new Random();
                int randomPercentage = random.Next(1, 25); //determines random rental increase percentage

                //this is for testing
                MessageBox.Show($"Rent is going to increase.\r\n" +
                                $"percentage: {randomPercentage}");

                monthlyPropertyCost *= ((decimal)randomPercentage / 100) + 1;
            }

            // set property cost textbox
            txtboxProperty.Text = $"-{monthlyPropertyCost.ToString("C")}";
            //UpdateBudget_Profit();
        }

        private void UpdateBudget_Profit()
        {
            profit = totalMonthlyRevenue - (totalWagesPerHour * 160) - monthlyPropertyCost;

            if (profit < 0)
            {
                txtboxProfit.Text = $"-{Math.Abs(profit).ToString("C")}";
            }
            else
            {
                txtboxProfit.Text = $"{profit.ToString("C")}";
            }    
        }

        //Update the Profit text box when any other "Budget" text box is altered
        private void txtboxRevenue_TextChanged(object sender, EventArgs e)
        {
            UpdateBudget_Profit();
        }

        private void txtboxWages_TextChanged(object sender, EventArgs e)
        {
            UpdateBudget_Profit();
        }

        private void txtboxProperty_TextChanged(object sender, EventArgs e)
        {
            UpdateBudget_Profit();
        }



        //These events set the employee icon images when hovered over
        private void picboxEmployee1_MouseEnter(object sender, EventArgs e)
        {
            //set employee icon (hover)
            picboxEmployee1.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(0, "employee", true)));
        }

        private void picboxEmployee1_MouseLeave(object sender, EventArgs e)
        {
            //set employee icon (original)
            picboxEmployee1.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(0, "employee", false)));
        }

        private void picboxEmployee2_MouseEnter(object sender, EventArgs e)
        {
            //set employee icon (hover)
            picboxEmployee2.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(1, "employee", true)));
        }

        private void picboxEmployee2_MouseLeave(object sender, EventArgs e)
        {
            //set employee icon (original)
            picboxEmployee2.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(1, "employee", false)));
        }

        private void picboxEmployee3_MouseEnter(object sender, EventArgs e)
        {
            //set employee icon (hover)
            picboxEmployee3.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(2, "employee", true)));
        }

        private void picboxEmployee3_MouseLeave(object sender, EventArgs e)
        {
            //set employee icon (original)
            picboxEmployee3.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(2, "employee", false)));
        }

        private void picboxEmployee4_MouseEnter(object sender, EventArgs e)
        {
            //set employee icon (hover)
            picboxEmployee4.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(3, "employee", true)));
        }

        private void picboxEmployee4_MouseLeave(object sender, EventArgs e)
        {
            //set employee icon (original)
            picboxEmployee4.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(3, "employee", false)));
        }

        private void picboxEmployee5_MouseEnter(object sender, EventArgs e)
        {
            //set employee icon (hover)
            picboxEmployee5.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(4, "employee", true)));
        }

        private void picboxEmployee5_MouseLeave(object sender, EventArgs e)
        {
            //set employee icon (original)
            picboxEmployee5.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(4, "employee", false)));
        }

        private void picboxEmployee6_MouseEnter(object sender, EventArgs e)
        {
            //set employee icon (hover)
            picboxEmployee6.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(5, "employee", true)));
        }

        private void picboxEmployee6_MouseLeave(object sender, EventArgs e)
        {
            //set employee icon (original)
            picboxEmployee6.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(5, "employee", false)));
        }

        private void picboxEmployee7_MouseEnter(object sender, EventArgs e)
        {
            //set employee icon (hover)
            picboxEmployee7.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(6, "employee", true)));
        }

        private void picboxEmployee7_MouseLeave(object sender, EventArgs e)
        {
            //set employee icon (original)
            picboxEmployee7.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(6, "employee", false)));
        }

        private void picboxEmployee8_MouseEnter(object sender, EventArgs e)
        {
            //set employee icon (hover)
            picboxEmployee8.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(7, "employee", true)));
        }

        private void picboxEmployee8_MouseLeave(object sender, EventArgs e)
        {
            //set employee icon (original)
            picboxEmployee8.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(7, "employee", false)));
        }

        private void picboxEmployee9_MouseEnter(object sender, EventArgs e)
        {
            //set employee icon (hover)
            picboxEmployee9.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(8, "employee", true)));
        }

        private void picboxEmployee9_MouseLeave(object sender, EventArgs e)
        {
            //set employee icon (original)
            picboxEmployee9.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(8, "employee", false)));
        }

        private void picboxEmployee10_MouseEnter(object sender, EventArgs e)
        {
            //set employee icon (hover)
            picboxEmployee10.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(9, "employee", true)));
        }

        private void picboxEmployee10_MouseLeave(object sender, EventArgs e)
        {
            //set employee icon (original)
            picboxEmployee10.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(9, "employee", false)));
        }

        private void picboxEmployee11_MouseEnter(object sender, EventArgs e)
        {
            //set employee icon (hover)
            picboxEmployee11.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(10, "employee", true)));
        }

        private void picboxEmployee11_MouseLeave(object sender, EventArgs e)
        {
            //set employee icon (original)
            picboxEmployee11.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(10, "employee", false)));
        }

        private void picboxEmployee12_MouseEnter(object sender, EventArgs e)
        {
            //set employee icon (hover)
            picboxEmployee12.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(11, "employee", true)));
        }

        private void picboxEmployee12_MouseLeave(object sender, EventArgs e)
        {
            //set employee icon (original)
            picboxEmployee12.Image =
                (Image)(Properties.Resources.ResourceManager.GetObject(
                    SetIcon(11, "employee", false)));
        }


        //These events set the product icon images when hovered over
        private void picboxProduct1_MouseEnter(object sender, EventArgs e)
        {
            if (products[0].InDevelopment == true) //if product is in development...
            {
                picboxProduct1.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon_Hover");
            }
            else
            {
                picboxProduct1.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(0, "product", true)));
            }
        }

        private void picboxProduct1_MouseLeave(object sender, EventArgs e)
        {
            if (products[0].InDevelopment == true) //if product is in development...
            {
                picboxProduct1.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon");
            }
            else
            {
                picboxProduct1.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(0, "product", false)));
            } 
        }

        private void picboxProduct2_MouseEnter(object sender, EventArgs e)
        {
            if (products[1].InDevelopment == true) //if product is in development...
            {
                picboxProduct2.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon_Hover");
            }
            else
            {
                picboxProduct2.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(1, "product", true)));
            }
        }

        private void picboxProduct2_MouseLeave(object sender, EventArgs e)
        {
            if (products[1].InDevelopment == true) //if product is in development...
            {
                picboxProduct2.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon");
            }
            else
            {
                picboxProduct2.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(1, "product", false)));
            }
        }

        private void picboxProduct3_MouseEnter(object sender, EventArgs e)
        {
            if (products[2].InDevelopment == true) //if product is in development...
            {
                picboxProduct3.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon_Hover");
            }
            else
            {
                picboxProduct3.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(2, "product", true)));
            }
        }

        private void picboxProduct3_MouseLeave(object sender, EventArgs e)
        {
            if (products[2].InDevelopment == true) //if product is in development...
            {
                picboxProduct3.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon");
            }
            else
            {
                picboxProduct3.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(2, "product", false)));
            }
        }

        private void picboxProduct4_MouseEnter(object sender, EventArgs e)
        {
            if (products[3].InDevelopment == true) //if product is in development...
            {
                picboxProduct4.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon_Hover");
            }
            else
            {
                picboxProduct4.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(3, "product", true)));
            }
        }

        private void picboxProduct4_MouseLeave(object sender, EventArgs e)
        {
            if (products[3].InDevelopment == true) //if product is in development...
            {
                picboxProduct4.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon");
            }
            else
            {
                picboxProduct4.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(3, "product", false)));
            }
        }

        private void picboxProduct5_MouseEnter(object sender, EventArgs e)
        {
            if (products[4].InDevelopment == true) //if product is in development...
            {
                picboxProduct5.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon_Hover");
            }
            else
            {
                picboxProduct5.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(4, "product", true)));
            }
        }

        private void picboxProduct5_MouseLeave(object sender, EventArgs e)
        {
            if (products[4].InDevelopment == true) //if product is in development...
            {
                picboxProduct5.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon");
            }
            else
            {
                picboxProduct5.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(4, "product", false)));
            }
        }

        private void picboxProduct6_MouseEnter(object sender, EventArgs e)
        {
            if (products[5].InDevelopment == true) //if product is in development...
            {
                picboxProduct6.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon_Hover");
            }
            else
            {
                picboxProduct6.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(5, "product", true)));
            }
        }

        private void picboxProduct6_MouseLeave(object sender, EventArgs e)
        {
            if (products[5].InDevelopment == true) //if product is in development...
            {
                picboxProduct6.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon");
            }
            else
            {
                picboxProduct6.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(5, "product", false)));
            }
        }

        private void picboxProduct7_MouseEnter(object sender, EventArgs e)
        {
            if (products[6].InDevelopment == true) //if product is in development...
            {
                picboxProduct7.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon_Hover");
            }
            else
            {
                picboxProduct7.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(6, "product", true)));
            }
        }

        private void picboxProduct7_MouseLeave(object sender, EventArgs e)
        {
            if (products[6].InDevelopment == true) //if product is in development...
            {
                picboxProduct7.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon");
            }
            else
            {
                picboxProduct7.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(6, "product", false)));
            }
        }

        private void picboxProduct8_MouseEnter(object sender, EventArgs e)
        {
            if (products[7].InDevelopment == true) //if product is in development...
            {
                picboxProduct8.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon_Hover");
            }
            else
            {
                picboxProduct8.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(7, "product", true)));
            }
        }

        private void picboxProduct8_MouseLeave(object sender, EventArgs e)
        {
            if (products[7].InDevelopment == true) //if product is in development...
            {
                picboxProduct8.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(
                        "ProductInDevelopmentIcon");
            }
            else
            {
                picboxProduct8.Image =
                    (Image)(Properties.Resources.ResourceManager.GetObject(
                        SetIcon(7, "product", false)));
            }
        }
   
        //These events launch the employeeDetailsForm
        private void picboxEmployee1_Click(object sender, EventArgs e)
        {
            LaunchEmployeeDetails(0); //Launch EmployeeDetailsForm
        }

        private void picboxEmployee2_Click(object sender, EventArgs e)
        {
            LaunchEmployeeDetails(1); //Launch EmployeeDetailsForm
        }

        private void picboxEmployee3_Click(object sender, EventArgs e)
        {
            LaunchEmployeeDetails(2); //Launch EmployeeDetailsForm
        }

        private void picboxEmployee4_Click(object sender, EventArgs e)
        {
            LaunchEmployeeDetails(3); //Launch EmployeeDetailsForm
        }

        private void picboxEmployee5_Click(object sender, EventArgs e)
        {
            LaunchEmployeeDetails(4); //Launch EmployeeDetailsForm
        }

        private void picboxEmployee6_Click(object sender, EventArgs e)
        {
            LaunchEmployeeDetails(5); //Launch EmployeeDetailsForm
        }

        private void picboxEmployee7_Click(object sender, EventArgs e)
        {
            LaunchEmployeeDetails(6); //Launch EmployeeDetailsForm
        }

        private void picboxEmployee8_Click(object sender, EventArgs e)
        {
            LaunchEmployeeDetails(7); //Launch EmployeeDetailsForm
        }

        private void picboxEmployee9_Click(object sender, EventArgs e)
        {
            LaunchEmployeeDetails(8); //Launch EmployeeDetailsForm
        }

        private void picboxEmployee10_Click(object sender, EventArgs e)
        {
            LaunchEmployeeDetails(9); //Launch EmployeeDetailsForm
        }

        private void picboxEmployee11_Click(object sender, EventArgs e)
        {
            LaunchEmployeeDetails(10); //Launch EmployeeDetailsForm
        }

        private void picboxEmployee12_Click(object sender, EventArgs e)
        {
            LaunchEmployeeDetails(11); //Launch EmployeeDetailsForm
        }

        //These events launch the productDetailsForm
        private void picboxProduct1_Click(object sender, EventArgs e)
        {
            LaunchProductDetails(0); //Launch ProductDetailsForm
        }

        private void picboxProduct2_Click(object sender, EventArgs e)
        {
            LaunchProductDetails(1); //Launch ProductDetailsForm
        }

        private void picboxProduct3_Click(object sender, EventArgs e)
        {
            LaunchProductDetails(2); //Launch ProductDetailsForm
        }

        private void picboxProduct4_Click(object sender, EventArgs e)
        {
            LaunchProductDetails(3); //Launch ProductDetailsForm
        }

        private void picboxProduct5_Click(object sender, EventArgs e)
        {
            LaunchProductDetails(4); //Launch ProductDetailsForm
        }

        private void picboxProduct6_Click(object sender, EventArgs e)
        {
            LaunchProductDetails(5); //Launch ProductDetailsForm
        }

        private void picboxProduct7_Click(object sender, EventArgs e)
        {
            LaunchProductDetails(6); //Launch ProductDetailsForm
        }

        private void picboxProduct8_Click(object sender, EventArgs e)
        {
            LaunchProductDetails(7); //Launch ProductDetailsForm
        }
    }
}