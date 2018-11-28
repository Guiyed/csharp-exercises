using System;
using System.Collections.Generic;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    class Student
    {
        private static int nextStudentId = 1;
        public string Name { get; set; }
        private int studentId;
        public int StudentId
        {
            get { return studentId; }
            internal set { studentId = value; }
        }
        public int NumberOfCredits { get; set; }
        public double Gpa { get; set; }


                             

        public Student(string name, int numberOfCredits, double gpa)
        {
            this.Name = name;
            this.StudentId = nextStudentId++;
            this.NumberOfCredits = numberOfCredits;
            this.Gpa = gpa;
        }

        public Student(string name) : this(name, 0, 0) { }

    
         /* Old Constructors
        public Student(string name, int studentId, int numberOfCredits, double gpa)
        {
            this.Name = name;
            this.StudentId = studentId;
            this.NumberOfCredits = numberOfCredits;
            this.Gpa = gpa;
        }

        public Student(string name, int studentId) : this(name, studentId, 0, 0) { }

        public Student(string name) : this(name, nextStudentId)
        {
            nextStudentId++;
        }
        */
            
    

        public void AddGrade(int courseCredits, double grade)
        {
            // Update the appropriate properties: NumberOfCredits, Gpa
            double actualQualityScore = this.Gpa*this.NumberOfCredits;
            double newGradeQualityScore = grade * courseCredits;
        
            double totalQualityScore = actualQualityScore + newGradeQualityScore;
            this.NumberOfCredits = this.NumberOfCredits + courseCredits;    
        
            this.Gpa = totalQualityScore / this.NumberOfCredits;
        }

        public string GetGradeLevel()
        {
            // Determine the grade level of the student based on NumberOfCredits
            if(0<this.NumberOfCredits<=29 ){ 
                return "freshman";
            }
            else if(29<this.NumberOfCredits<=59 ){ 
                return "sophomore";
            }
            else if(59<this.NumberOfCredits<=89 ){ 
                return "junior";
            } 
            else if(89<this.NumberOfCredits ){ 
                return "senior";
            } 
            else{
                return "error";
            }   
        }
        
        public override String ToString()
        {
            return Name + " (Credits: " + NumberOfCredits + ", GPA: " + Gpa + ")";
        }


        public bool Equals(Object o)
        {
            if (o == this)
            {
                return true;
            }
            if (o == null)
            {
                return false;
            }
            if (o.GetType() != GetType())
            {
                return false;
            }
            Student studentObj = o as Student;
            return StudentId == studentObj.StudentId;
        }
    }

       

    class Course
    {
        private static int nextCourseId = 1;
        private int CourseId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }        
        public int Credits { get; set; }
        public List<Student> Students{ get; set; }
        public Dictionary<Student,int> StudentsAndGrades { get; set; }

        public Course(string name, int courseId, string department,  int credits)
        {
            this.Name = name;
            this.CourseId = courseId;
            this.Department = department;
            this.Credits = credits;
            
        }

        public Course(string name, int courseId) : this(name, courseId, "Default", 0) { }

        public Course(string name) : this(name, nextCourseId)
        {
            nextCourseId++;
        }


        public override String ToString()
        {
            return Name + " (Department: " + Department + ", Credits: " + Credits + ")";
        }


        public bool Equals(Object o)
        {
            if (o == this)
            {
                return true;
            }
            if (o == null)
            {
                return false;
            }
            if (o.GetType() != GetType())
            {
                return false;
            }
            Course courseObj = o as Course;
            return CourseId == courseObj.CourseId;
        }

    }

}
