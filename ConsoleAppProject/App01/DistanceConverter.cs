using ConsoleAppProject.Helpers;
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
        public const double FEET_IN_METRES = 3.28084;

        private double fromDistance;
        private double toDistance;

        private DistanceUnits fromUnit;
        private DistanceUnits toUnit;

        /// <summary>
        /// A method that allows the program class to call to the distance converter.
        /// </summary>
        public void Run()
        {
           ConsoleHelper.OutputHeading("App01 Distance Converter", "Jessica Leach");
            fromUnit = SelectUnit(" Please select your from unit");
            toUnit = SelectUnit(" Please select your to unit");
            Console.WriteLine($" \n You are converting from {fromUnit} to {toUnit} \n");
            
            fromDistance = ConsoleHelper.InputNumber($"Please enter the distance in {fromUnit} > !");
            ConvertDistance(); 
            OutputDistance();
        }

        private DistanceUnits SelectUnit(string prompt)
        {
            string[] choices =
                {
                    $" 1. {DistanceUnits.Miles}",
                    $" 2. {DistanceUnits.Feet}",
                    $" 3. {DistanceUnits.Metres}"
                };

            Console.WriteLine($"n/{prompt}/n");
            int choice = ConsoleHelper.SelectChoice(choices);
          

            if (choice == 1)
            {
                return DistanceUnits.Miles;
            }
            else if (choice == 2)
            {
                return DistanceUnits.Feet;
            }
            else if (choice == 3)
            {
                return DistanceUnits.Metres;
            }
            else return DistanceUnits.NoUnit;
        }


        private void OutputDistance()
        {
            Console.WriteLine($" {fromDistance} {fromUnit} = {toDistance} {toUnit}!");
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
                toDistance = fromDistance / METRES_IN_MILES;
            }
            else if (fromUnit == DistanceUnits.Miles &&
          toUnit == DistanceUnits.Metres)
            {
                toDistance = fromDistance * METRES_IN_MILES;
            }
            else if (fromUnit == DistanceUnits.Metres &&
         toUnit == DistanceUnits.Feet)
            {
                toDistance = fromDistance * FEET_IN_METRES;
            }
            else if (fromUnit == DistanceUnits.Feet &&
         toUnit == DistanceUnits.Metres)
            {
                toDistance = fromDistance / FEET_IN_METRES;
            }
        }
    }
}
