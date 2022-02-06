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
        private double miles;

        private double feet; 

        /// <summary>
        /// A method that allows the program class to call to the distance converter.
        /// </summary>
        public void Run()
        {
            InputMiles();
            CalculateFeet();
            OutputFeet();
        }

        /// <summary>
        /// Prompt the user to enter miles
        /// Input the miles as a double number
        /// </summary>
        
        private void InputMiles()
        {
            Console.Write("Please Enter the Number of Miles > ");
            string value = Console.ReadLine();
            miles = Convert.ToDouble(value);
        }

        /// <summary>
        /// Convert the input miles into feet
        /// </summary>
        private void CalculateFeet()
        {

        }

        /// <summary>
        /// Output the convereted number 
        /// </summary>
        private void OutputFeet()
        {

        }
    
    }
}
