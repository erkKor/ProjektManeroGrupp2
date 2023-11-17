namespace Manero.Models.ViewModels
{
    public class MyPromoViewModel
    {
        public string CompanyName_1 { get; set; } = null!;
        public string CompanyName_2 { get; set; } = null!;
        public string CompanyName_3 { get; set; } = null!;
        public int DiscountPercentage_1 { get; set; }
        public int DiscountPercentage_2 { get; set; }
        public int DiscountPercentage_3 { get; set; }
        public int VaildYear_1 { get; set; }
        public int VaildYear_2 { get; set; }
        public int VaildYear_3 { get; set; }
        public string Month_1 { get; set; } = null!;
        public string Month_2 { get; set; } = null!;
        public string Month_3 { get; set; } = null!;

        public void GenerateRandomCompanyName()
        {
            List<string> companyOption = new List<string> { "Acme Co.", "Abstergo Ltd.", "Barone LLC." };

            Random random = new Random();
            int randomIndex_1 = random.Next(0, companyOption.Count);
            int randomIndex_2 = random.Next(0, companyOption.Count);
            int randomIndex_3 = random.Next(0, companyOption.Count);

            CompanyName_1 = companyOption[randomIndex_1];
            CompanyName_2 = companyOption[randomIndex_2];
            CompanyName_3 = companyOption[randomIndex_3];
        }

        public void GenerateRandomDiscountPercentage()
        {
            int[] percentageOptions = { 10, 30, 50 };

            Random random = new Random();
            int randomIndex_1 = random.Next(percentageOptions.Length);
            int randomIndex_2 = random.Next(percentageOptions.Length);
            int randomIndex_3 = random.Next(percentageOptions.Length);

            DiscountPercentage_1 = percentageOptions[randomIndex_1];
            DiscountPercentage_2 = percentageOptions[randomIndex_2];
            DiscountPercentage_3 = percentageOptions[randomIndex_3];

        }
        public void GenerateRandomValidYearAndMonth()
        {
            List<string> monthOption = new List<string> { "June", "May", "Mars" };

            Random random = new Random();
            int randomIndex_1 = random.Next(0, monthOption.Count);
            int randomIndex_2 = random.Next(0, monthOption.Count);
            int randomIndex_3 = random.Next(0, monthOption.Count);

            Month_1 = monthOption[randomIndex_1];
            Month_2 = monthOption[randomIndex_2];
            Month_3 = monthOption[randomIndex_3];

            Random _random = new Random();
            VaildYear_1 = _random.Next(2023, 2030);
            VaildYear_2 = _random.Next(2023, 2030);
            VaildYear_3 = _random.Next(2023, 2030);
        }
    }
}
