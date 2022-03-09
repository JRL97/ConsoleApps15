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
        
        
        
        
        
        
        
        public void Run()
        {
         bool repeat = true;
            while (repeat)
            {
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
            foreach(var student in Students)
            {
                int mark = (int)ConsoleHelper.InputNumber(
                    $"Enter a mark for {student}", 0, 100);
            }
        }

        private void ConvertGrades()

        {

        }

        private void OutputMarks()
        {
            for(int i = 0; i < MarksLength; i++)
            {

            }
        }
    }
}
