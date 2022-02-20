using System;
namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This class includes methods to convert a given distance in miles to the 
    /// equivalent distance in feet
    /// </summary>
    /// <author>
    /// Jessica Leach version 0.1
    /// </author>
    public class DistanceConverter
    {
        public const int FEET_IN_MILES = 5280;
        public const double METRES_IN_MILES = 1609.34;

        private double fromDistance;
        private double toDistance;

        private DistanceUnits fromUnit;
        private DistanceUnits toUnit;

        /// <summary>
        /// A method that allows the program class to call to the distance converter.
        /// </summary>
        public void Run()
        {
            OutputHeading();
            //SelectUnit();
            fromUnit = SelectUnit(" Please select your from unit");
            toUnit = SelectUnit(" Please select your to unit");
            Console.WriteLine($" \n You are converting from {fromUnit} to {toUnit} \n");
            
            fromDistance = InputDistance($"Please enter the distance in {fromUnit} > !");
            ConvertDistance(); 
            OutputDistance();
        }

        private DistanceUnits SelectUnit(string prompt)
        {
            Console.WriteLine(prompt);
            Console.WriteLine();

            Console.WriteLine($" 1. {DistanceUnits.Miles}");
            Console.WriteLine($" 2. {DistanceUnits.Feet}");
            Console.WriteLine($" 3. {DistanceUnits.Metres}");

            Console.WriteLine();
            Console.Write(" Please enter coice > ");


            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                return DistanceUnits.Miles;
            }
            else if (choice == "2")
            {
                return DistanceUnits.Feet;
            }
            else if (choice == "3")
            {
                return DistanceUnits.Metres;
            }
            else return DistanceUnits.NoUnit;
        }

        /// <summary>
        /// Prompt the user to enter miles
        /// Input the miles as a double number
        /// </summary>


        private void OutputHeading()
        {
            Console.WriteLine();
            Console.WriteLine("    ---------------------------");
            Console.WriteLine("        Distance Converter   ");
            Console.WriteLine("         By Jessica Leach      ");
            Console.WriteLine("    ---------------------------");
            Console.WriteLine();
        }

        private void OutputDistance()
        {
            Console.WriteLine($" {fromDistance} {fromUnit} = {toDistance} {toUnit}!");
        }

        /// <summary>
        /// Convert the input miles into feet
        /// </summary>
        private void CalculateFeet()
        {
            //feet = miles * FEET_IN_MILES; 
        }


        private void ConvertDistance()
        {
            if (fromUnit == DistanceUnits.Miles &&
               toUnit == DistanceUnits.Feet)
            {
                toDistance = fromDistance * FEET_IN_MILES;
            }
            else if (fromUnit == DistanceUnits.Feet &&
                     toUnit == DistanceUnits.Miles)
            {
                toDistance = fromDistance / FEET_IN_MILES;
            }
            else if (fromUnit == DistanceUnits.Metres &&
                      toUnit == DistanceUnits.Miles)
            {
                toDistance = fromDistance * METRES_IN_MILES;
            }
        }
            /// <summary>
            /// Output the convereted number 
            /// </summary>
            /// 
            private double InputDistance(string prompt)
        {
            Console.WriteLine(prompt);
            string number = Console.ReadLine();


            return Convert.ToDouble(number);
        }

    }
}
