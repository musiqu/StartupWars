using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartupWars
{
    public class Product
    {
        public int ProductIndex { get; set; }
        public string ProductTitle { get; set; }
        public int CurrentDevelopmentPoints { get; set; }
        public int RequiredDevelopmentPoints { get; set; }
        public int Popularity { get; set; } //Alg created
        public int ProductLevel { get; set; }
        public decimal Revenue { get; set; } //determined by popularity points
        public bool InDevelopment { get; set; }
        public int ProgressBarAssignment { get; set; }
        public int ProductMonthCounter { get; set; }

        //Prodcut constructor
        public Product(int productIndex, string productName, int requiredDevelopmentPoints,
            int productLevel)
        {
            ProductIndex = productIndex;
            ProductTitle = productName;
            CurrentDevelopmentPoints = 0;
            RequiredDevelopmentPoints = requiredDevelopmentPoints;
            Popularity = 10;
            ProductLevel = productLevel;
            Revenue = SetInitialRevenue(ProductLevel);
            InDevelopment = true;
            ProductMonthCounter = 0;
        }

        private decimal SetInitialRevenue(int productLevel)
        {
            var startingRevenue = 0.00M;
            Random random = new Random();

            MessageBox.Show($"Popularity: {Popularity}");

            switch (productLevel)
            {
                case 1:
                    startingRevenue = random.Next(5000, 10000);
                    break;
                case 2:
                    startingRevenue = random.Next(10000, 17500);
                    break;
                case 3:
                    startingRevenue = random.Next(15000, 30000);
                    break;
                case 4:
                    startingRevenue = random.Next(25000, 50000);
                    break;
                case 5:
                    startingRevenue = random.Next(40000, 100000);
                    break;
            }

            MessageBox.Show($"Initial Revenue: {startingRevenue:C}");

            return startingRevenue;
        }
    }
}
