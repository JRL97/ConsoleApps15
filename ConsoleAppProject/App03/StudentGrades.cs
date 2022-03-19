using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// At the moment this class just tests the
    /// Grades enumeration names and descriptions
    /// </summary>
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

        public int Minimum { get; set; }
        public int Maximum { get; set; }





        public void Run()
        {
         bool repeat = true;
            while (repeat)
            {
                Students = new string[] { "Jessica", "Alastair", "Grace", "Emma", "Oliver",
                    "Leo", "Charlie", "Matthew", "Delilah", "Lily", };
                Marks = new int[Students.Length];

                ConsoleHelper.OutputHeading("App03 Student Marks", "Jessica Leach");
                CalculateGrades();
                repeat = ConsoleHelper.Repeat();
            }
        }

        public void CalculateGrades()
        {
            InputMarks();
            ConvertGrades();
            OutputMarks();
        }

        private void InputMarks()
        {
            Console.WriteLine("Please enter a mark for each student >\n");
            int i = 0;

            foreach (var student in Students)
            {

                int mark = (int)ConsoleHelper.InputNumber( $"Enter a mark for {student}", 0, 100);
                Marks[i] = mark;
                i++;
            }
        }

        private void ConvertGrades()

        {

        }

        private void OutputMarks()
        {
            for(int i = 0; i < Marks.Length; i++)
            {
                int mark = Marks[i];
                Grades grade = ConvertToGrades(mark);
                Console.WriteLine($"{Students[i]} mark = {Marks} grade = {grade}");
            }
        }
        public Grades ConvertToGrades(int mark)
        {
            if (mark >= 0 && mark <= MIN_D - 1)
                return Grades.F;

            if (mark >= 40 && mark <= MIN_C - 2)
                return Grades.D;

            if (mark >= 50 && mark <= MIN_B - 3)
                return Grades.C;

            if (mark >= 60 && mark <= MIN_A - 4)
                return Grades.B;

            if (mark >= 70 && mark <= MAX_PASS - 5)
                return Grades.A;

            else return Grades.X;
        }
    }
}
