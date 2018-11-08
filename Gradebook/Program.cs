using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gradebook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> students = new List<string>();
            List<double> grades = new List<double>();
            string newStudent;

            Console.WriteLine("Enter your students (or ENTER to finish):");
            do
            {
                newStudent = Console.ReadLine();
                if (newStudent != "")
                {
                    students.Add(newStudent);
                }
            }
            while (newStudent != "");

            // Get student grades
            foreach (string student in students)
            {
                Console.WriteLine("Grade for " + student + ": ");
                double newGrade = double.Parse(Console.ReadLine());
                grades.Add(newGrade);
            }

            /*
            // Print class roster
            Console.WriteLine("\nClass roster:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i] + " (" + grades[i] + ")");
            }
            */

            // Print class roster with String Builder
            Console.WriteLine("\nClass roster:");

            StringBuilder myString = new StringBuilder();
            for (int i = 0; i < students.Count; i++)
            {
                myString.Append(students[i]);
                myString.Append(" (");
                myString.Append(grades[i]);
                myString.Append(")\n");                
            }
            Console.WriteLine(myString);

            double sum = grades.Sum();
            double avg = sum / grades.Count;
            Console.WriteLine("Average grade: " + avg);

            Console.ReadLine();
        }
    }
}
