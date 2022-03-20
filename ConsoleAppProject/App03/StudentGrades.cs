using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConsoleAppProject.Helpers;
using System.Linq;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// This App will allow a user to input grades for 10 students and have then converted to a letter 
    /// grade. Then it will calculate statistics for the inputted grades as well as a percentage for each 
    /// grade level.
    /// </summary>
    /// <author>
    /// Jessica Leach version 4
    /// </author>
    public class StudentGrades
    {

        public const int MIN_FAIL = 0;
        public const int MIN_D = 40;
        public const int MIN_C = 50;
        public const int MIN_B = 60;
        public const int MIN_A = 70;
        public const int MAX_PASS = 100;

        public string[] Students { get; set; }
        public int[] Marks { get; set; }
        public int[] GradeProfile { get; set; }
        public double Mean { get; set; }
        public int Minimum { get; set; } = 0;
        public int Maximum { get; set; } = 100;
        public int MinMark { get; set; }
        public int MaxMark { get; set; }
        public int Percentage { get; set; } = 100;




        /// <summary>
        /// A method to run the programme. It includes 10 students. 
        /// </summary>
        public void Run()
        {
         bool repeat = true;
            while (repeat)
            {
                Students = new string[] { "Jessica", "Alastair", "Grace", "Emma", "Oliver",
                    "Leo", "Charlie", "Matthew", "Delilah", "Lily", };
                Marks = new int[Students.Length];
                GradeProfile = new int[5];

                ConsoleHelper.OutputHeading("App03 Student Marks", "Jessica Leach");
                CalculateGrades();
                repeat = ConsoleHelper.Repeat();
            }
        }
        public void CalculateGrades()
        {
            InputMarks();
            OutputMarks();
            OutputStatistics();
        }

        /// <summary>
        /// Provides the user with a prompt to enter grades for each student in the array
        /// </summary>
        private void InputMarks()
        {
            Console.WriteLine("Please enter a mark for each student >\n");
            int i = 0;

            foreach (string name in Students)
            {

                int mark = (int)ConsoleHelper.InputNumber( $"Enter a mark for student {name} > ", Minimum, Maximum);
                Marks[i] = mark;
                i++;
            }
        }

        /// <summary>
        /// Outputs a student and mark list along with their converted grade.  
        /// </summary>

        private void OutputMarks()
        {

            ConsoleHelper.OutputTitle("List of Student Marks and Grades:");

            for (int i = 0; i < Marks.Length; i++)
            {
               
                Grades outputGrade = CalculateGradeProfile(Marks[i]);
                Console.WriteLine($"{Students[i]} mark = {Marks[i]} grade = {outputGrade}");
            }
        }

        /// <summary>
        /// Converts the inputted marks to grades.
        /// </summary>
        /// <param name="mark"></param>
        /// <returns></returns>
        public Grades ConvertToGrades(int mark)
        {
            if (mark >= 0 && mark <= MIN_D - 1)
                return Grades.F;

            if (mark >= 40 && mark <= MIN_C - 1)
                return Grades.D;

            if (mark >= 50 && mark <= MIN_B - 1)
                return Grades.C;

            if (mark >= 60 && mark <= MIN_A - 1)
                return Grades.B;

            if (mark >= 70 && mark <= MAX_PASS)
                return Grades.A;

            else return Grades.X;
        }

     /// <summary>
     /// Calculates the percentage total of students in each grade group
     /// </summary>
     /// <param name="mark"></param>
     /// <returns></returns>
        public Grades CalculateGradeProfile(int mark)
        { 
            Grades grade = ConvertToGrades(mark);
            GradeProfile[(int)grade - 1] = GradeProfile[(int)grade - 1] + (Percentage / Marks.Length);
            return grade;
        }


        /// <summary>
        /// Calculates and Outputs the minimum, maximum and mean mark. 
        /// </summary>
        public void OutputStatistics()
        {
            Mean = (double)Marks.Sum() / (double)Marks.Length;
            MinMark = Marks.Min();
            MaxMark = Marks.Max();

            ConsoleHelper.OutputTitle("Statistics:");
            Console.WriteLine($"Mean Mark: {Mean} \nMinimum Mark: {MinMark} \nMaximum Mark: {MaxMark}");
            ConsoleHelper.OutputTitle("Overall Grades:");
          
            for (int i = 0; i < GradeProfile.Length; i++)
            {
                Console.WriteLine($"Grade {Enum.GetName(typeof(Grades), i + 1)}-- {GradeProfile[i]}%");
            }

        }
    
    }
}
