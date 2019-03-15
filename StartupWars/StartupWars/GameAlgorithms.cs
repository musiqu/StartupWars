using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartupWars
{
    public class GameAlgorithms
    {
        static Random random = new Random(); //create random number object

        //product algorithms
        public static void RunProductAlgorithms(Product[] products)
        {
            UpdatePopularityAndRevenue(products);
        }

        private static void UpdatePopularityAndRevenue(Product[] products)
        {
            //determine if popularity levels should be decreased
            //products with a higher product level are less likely to be decreased
            foreach (Product product in products)
            {
                if (product != null && product.InDevelopment == false)
                {
                    product.ProductMonthCounter++;

                    if (product.ProductMonthCounter > 1)
                    {
                        int number = random.Next(1, 100); //determine random number 
                        MessageBox.Show($"ProdLevel: {product.ProductLevel}\n" +
                            $"Pop: {product.Popularity}\nRand: {number.ToString()}\n" +
                            $"Revenue: {product.Revenue}");

                        if (product.Popularity >= 1)
                        {
                            switch (product.ProductLevel)
                            {
                                case 1:
                                    if (product.Popularity <= 4 && number <= 30)
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    else if (number <= 60)//popularity >= 5
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    else if (number <= 80)
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    break;
                                case 2:
                                    if (product.Popularity <= 4 && number <= 25)
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    else if (number <= 55) //popularity >= 5
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    else if (number <= 75)
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    break;
                                case 3:
                                    if (product.Popularity <= 4 && number <= 20)
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    else if (product.Popularity <= 7 && number <= 35)
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    else if (number <= 50)//popularity >= 8
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    else if (number <= 70)
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    break;
                                case 4:
                                    if (product.Popularity <= 4 && number <= 15)
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    else if (product.Popularity <= 7 && number <= 15)
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    else if (number <= 40) //popularity >= 8
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    else if (number <= 60)
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    break;
                                case 5:
                                    if (product.Popularity <= 4 && number <= 10)
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    else if (product.Popularity <= 7 && number <= 20)
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    else if (number <= 35) //popularity >= 8
                                    {
                                        DecreaseRevenueAndPopularity(product);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            Popularity1_DecreaseRevenue(product);
                        }
                    }      
                }
            }
        }

        private static void DecreaseRevenue(Product product)
        {
            product.Revenue *= 0.9M;
        }

        private static void DecreaseRevenueAndPopularity(Product product)
        {
            DecreaseRevenue(product);
            product.Popularity--;
        }

        private static void Popularity1_DecreaseRevenue(Product product)
        {
            if (product.Revenue >= 1000.00M)
            {
                DecreaseRevenue(product);
                product.Revenue -= 300.00M * product.ProductLevel; //subtract additional revenue
            }
            else
            {
                int number = random.Next(1, 1000); //determine random number
                MessageBox.Show($"Pop1 decrease random #: {number}");

                product.Revenue -= number * product.ProductLevel;
            }  
        }
    }
}
