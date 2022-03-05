using ConsoleAppProject.Helpers;
using System;
namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This application calculates BMI through the input of either metric or imperial units by a user and outputs the associated BMI status. 
    /// </summary>
    /// <author>
    /// Jessica Leach version 
    /// </author>
    public class BMI
    {
        public const string IMPERIAL = "Imperial";
        public const string METRIC = "Metric";

        public const string FEET = "Feet";
        public const string INCHES = "Inches";

        public const int INCHES_IN_FEET = 12;
        public const int POUNDS_IN_STONE = 14;
        public const int IMPERIAL_FACTOR = 703;

        public double BMI_Index { get; set; }
        public BMI_Enum Status { get; set; }

        public double Height { get; set; }
        public double Weight { get; set; }


        private string unitChoice;

        /// <summary>
        /// This method will run the program, outputting a
        /// heading, closing the program if the user does
        /// not wish to run it again
        /// </summary>
        public void Run()
        {
            bool repeat = true;
            while (repeat)
            {
                ConsoleHelper.OutputHeading("App02 BMI Calculator", "Jessica Leach");
                ConvertBMI();
                repeat = ConsoleHelper.Repeat();
            }
        }

        /// <summary>
        ///This method allows a user to choose between an imperial or metric conversion, 
        ///then calculates the results from the users input and outputs 
        ///the BMI and the BMI class the results belong to
        /// </summary>
        public void ConvertBMI()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" Selecting units");

            string[] choices = new string[]
            {
                IMPERIAL, METRIC
            };

            Console.WriteLine($"\n Please select a unit to convert from\n");
            int choice = ConsoleHelper.SelectChoice(choices);
            unitChoice = choices[choice - 1];

            Console.WriteLine($"\n You have selected {unitChoice}! ");

            if (unitChoice == IMPERIAL)
            {
                InputImperial();
                CalculateImperial();
            }
            else if (unitChoice == METRIC)
            {
                InputMetric();
                CalculateMetric();
            }

            OutputBMI_Index();
        }

        /// <summary>
        //This method allows a user to input weight in stones and pounds and
        //height in feet and inches in order to calculate an associated BMI. 
        /// </summary>
        private void InputImperial()
        {
            Console.WriteLine($"\n Enter your height" +
                            " to the nearest feet & inches");

            Height = ConsoleHelper.InputNumber($"\n Enter your height in feet > ");
            int inches = (int)ConsoleHelper.InputNumber($" Enter your height in inches > ", 0, INCHES_IN_FEET);
            Height = Height * INCHES_IN_FEET + inches;

            Console.WriteLine($"\n Enter your weight" +
            " to the nearest stones & pounds");

            Weight = ConsoleHelper.InputNumber($"\n Enter your weight in stone > ");
            int pounds = (int)ConsoleHelper.InputNumber($" Enter your weight in pounds > ", 0, POUNDS_IN_STONE);
            Weight = Weight * POUNDS_IN_STONE + pounds;
        }

        /// <summary>
        ///This method allows a user to input weight in kilograms and
        ///height in metres in order to calculate an associated BMI. 
        /// </summary>
        private void InputMetric()
        {
            Console.WriteLine($"\n Enter your height " +
                "in metres");

            Height = ConsoleHelper.InputNumber($"\n Enter your height in metres > ");

            Console.WriteLine($"\n Enter your weight " +
            "to the nearest kilogram");

            Weight = ConsoleHelper.InputNumber($"\n Enter your weight in kilograms > ");
        }

        /// <summary>
        /// Calculates BMI using following
        /// BMI = (weight in pounds) x 703 / (height in inches)2 for imperial units
        /// </summary>
        public void CalculateImperial()
        {
            BMI_Index = (Weight * IMPERIAL_FACTOR) / (Height * Height);
        }

        /// <summary>
        /// Calculates BMI using following 
        /// BMI = (weight in kg) / (height in metres)2 for metric units
        /// </summary>
        public void CalculateMetric()
        {
            BMI_Index = Weight / (Height * Height);
        }

        /// <summary>
        /// This method sorts calculated results into their associated bands in order to output a class for a user
        /// </summary>
        private void OutputBMI_Index()
        {
            if (BMI_Index < 18.50)
            {
                Status = BMI_Enum.Underweight;
            }
            else if (BMI_Index > 18.5 && BMI_Index < 24.9)
            {
                Status = BMI_Enum.Normalweight;
            }
            else if (BMI_Index > 25.0 && BMI_Index < 29.9)
            {
                Status = BMI_Enum.Overweight;
            }
            else if (BMI_Index > 30.00 && BMI_Index < 34.9)
            {
                Status = BMI_Enum.Obese1;
            }
            else if (BMI_Index > 35.0 && BMI_Index < 39.9)
            {
                Status = BMI_Enum.Obese2;
            }
            else if (BMI_Index >= 40.0)
            {
                Status = BMI_Enum.Obese3;
            }

            Console.WriteLine($"\n Your BMI index is {BMI_Index: 0.00}");
            Console.WriteLine($"Your BMI status is {Status}");

            Console.WriteLine("\n 23.0 or more are at increased risk " +
                "\n 27.5 or more are at high risk");
        }


    }
}
