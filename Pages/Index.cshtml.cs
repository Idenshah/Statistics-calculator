using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Eventing.Reader;

namespace Statistics_calculator.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string NumberOne { get; set; }

        [BindProperty]
        public string NumberTwo { get; set; }

        [BindProperty]
        public string NumberThree { get; set; }

        [BindProperty]
        public string NumberFour { get; set; }

        public double Maximum { get; set; }

        public double Minimum { get; set; }

        public double Average { get; set; }

        public double Total { get; set; }


        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ViewData["StatisticStyleDisplay"] = "none";
        }

        public IActionResult OnPost()
        {
            int EnteredNumber = 0;
            int EnteredWrong = 0;
            double[] inputValues = new double[4];

            if (double.TryParse(NumberOne, out double resultOne))
            {
                inputValues[0] = resultOne;
                EnteredNumber++;
            }
            else if (NumberOne == null)
            {
                ViewData["MessageForNumberOne"] = "";
            }
            else
            {
                ViewData["MessageForNumberOne"] = $"Number one should be a numeric data.";
                EnteredWrong++;
            }

            if (double.TryParse(NumberTwo, out double resultTwo))
            {
                inputValues[1] = resultTwo;
                EnteredNumber++;
            }
            else if (NumberTwo == null)
            {
                ViewData["MessageForNumberTwo"] = "";
            }
            else
            {
                ViewData["MessageForNumberTwo"] = $"Number two should be a numeric data.";
                EnteredWrong++;
            }

            if (double.TryParse(NumberThree, out double resultThree))
            {
                inputValues[2] = resultThree;
                EnteredNumber++;
            }
            else if (NumberThree == null)
            {
                ViewData["MessageForNumberThree"] = "";
            }
            else
            {
                ViewData["MessageForNumberThree"] = "Number three should be a numeric data.";
                EnteredWrong++;
            }

            if (double.TryParse(NumberFour, out double resultFour))
            {
                inputValues[3] = resultFour;
                EnteredNumber++;
            }
            else if (NumberFour == null)
            {
                ViewData["MessageForNumberFour"] = "";
            }
            else
            {
                ViewData["MessageForNumberFour"] = "Number four should be a numeric data.";
                EnteredWrong++;
            }

            if (EnteredNumber >= 2 && EnteredWrong == 0)
            {
                Total = inputValues[0] + inputValues[1] + inputValues[2] + inputValues[3];
                Average = Total / EnteredNumber;

                ViewData["FormattedTotal"] = Total.ToString("N2");
                ViewData["FormattedAverage"] = Average.ToString("N2");

                Minimum = inputValues.Min();
                Maximum = inputValues.Max();
                ViewData["StatisticStyleDisplay"] = "block";
            }

            else if (EnteredNumber <= 1 && EnteredWrong == 0)
            {
                ViewData["MessageForGeneral"] = "Minimum two numbers should be entered.";
                ViewData["StatisticStyleDisplay"] = "none";
            }

            else
            {
                ViewData["StatisticStyleDisplay"] = "none"; 
            }

            return Page();
        }
    }
}