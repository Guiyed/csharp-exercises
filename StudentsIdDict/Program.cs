using System;
using System.Collections.Generic;
using System.Linq;

namespace GradebookDict
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int,string> students = new Dictionary<int, string>();
            string newStudent;

            Console.WriteLine("Enter your students (or ENTER to finish):");
            do
            {
                Console.Write("name: ");
                newStudent = Console.ReadLine();
                if (newStudent != "")
                {
                    // Get the student's ID
                    Console.WriteLine("Students ID: ");
                    int newID = int.Parse(Console.ReadLine());

                    students.Add(newID, newStudent);
                }
            }
            while (newStudent != "");

            // Print class roster
            Console.WriteLine("\nClass roster:");
            foreach (KeyValuePair<int,string> student in students)
            {
                Console.WriteLine("ID: " + student.Key + ", Student name: " + student.Value);
            }

           
            Console.ReadLine();
        }
    }
}
