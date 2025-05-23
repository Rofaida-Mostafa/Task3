using System.Xml.Linq;

namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManagementSystem studentManager = new StudentManagementSystem();
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                Console.WriteLine("\n Student Management System ");
                Console.WriteLine("a. Add a new Student");
                Console.WriteLine("b. Add a new Instructor");
                Console.WriteLine("c. Add a new Course");
                Console.WriteLine("d. Enroll Student in Course");
                Console.WriteLine("e. Show All Students:");
                Console.WriteLine("f. Show All Courses");
                Console.WriteLine("g. Show All Instructors ");
                Console.WriteLine("h. Find the student by id");
                Console.WriteLine("i. Fine the course by id");
                Console.WriteLine("j. Update Student Information:");
                Console.WriteLine("k. Delete Student");
                Console.WriteLine("l. Return the instructor name by course name");
                Console.WriteLine("0. Exit");

                Console.Write("Select a letter or Exit: ");
                string LetterSelected = Console.ReadLine();

                switch (LetterSelected)
                {
                    case "a":
                        Student student = new Student();

                        Console.Write("Enter Name: ");
                        student.Name = Console.ReadLine();

                        Console.Write("Your Age is: ");
                        int age = int.Parse(Console.ReadLine());

                        if (age >= 20)
                        {

                            student.Age = age;
                            studentManager.AddStudent(student);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Student added. You should remember your ID:" + student.StudentId
                                );
                            Console.ForegroundColor = ConsoleColor.White;
                          
                        }else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You are not a faculty student.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                  
                       
                        break;

                    case "b":
                        Instructor instructor = new Instructor();

                        Console.Write("Enter Name: ");
                        instructor.Name = Console.ReadLine();

                        Console.Write("Enter Specialization: ");
                        instructor.Specialization = Console.ReadLine();

                        studentManager.AddInstructor(instructor);
                        break;

                    case "c":
                        Course course = new Course();
                        studentManager.AddCourse(course);
                        break;
                    
                    case "d":
                        Console.Write("Enter Student ID: ");
                        string studentId = Console.ReadLine();

                        Console.Write("Enter Course ID: ");
                        string courseId = Console.ReadLine();

                        studentManager.EnrollStudentInCourse(studentId, courseId);
                        break;

                    case "e":
                        studentManager.ViewAllStudents();
                        break;

                    case "f":
                        studentManager.ViewAllCourses();
                        break;
                    
                    case "g":
                        studentManager.ViewAllInstructors();
                        break;
                    case "h":
                      

                        Console.Write("Enter Student Id: ");
                       string studentId1 = Console.ReadLine();
                        studentManager.FindStudent(studentId1);
                        break;

                    case "i":
                        Console.Write("Enter Student Id: ");
                        string InstructorId1 = Console.ReadLine();
                        studentManager.FindInstructor(InstructorId1);
                        break;
                    case "j":
                      
                        studentManager.UpdateStudent();
                        break;
                    case "k":
                        Console.Write("Enter Student Id: ");
                         InstructorId1 = Console.ReadLine();
                        studentManager.DeleteStudent(InstructorId1);
                        break;   
                    case "l":
                        Console.Write("Enter Course Title: ");
                        string CourseTitle = Console.ReadLine();
                        studentManager.GetInstructorNameByCourseTitle(CourseTitle);
                        break;

                    case "0":
                        Console.Write("Goodbye! ");
                        return;

                    default: Console.WriteLine("Try Again"); 
                        break;
                }
            
        }

    }
 
    }

    class StudentManagementSystem
    {
        List<Student> students = new List<Student>();
        List<Instructor> instructors = new List<Instructor>();
         List<Course> courses = new List<Course>();

        // AddStudent
       
        public bool AddStudent(Student student)
        {
            students.Add(student);
            return true;
        }

        // ========================================___================================___==================

        // AddInstructor
        public bool AddInstructor(Instructor instructor)
        {

            if (instructor.Name != "" && instructor.Specialization != "")
            {
                instructors.Add(instructor);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n Instructor added successfully");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n {instructor.PrintDetails()} \n" +
                    $"You should memorize your Instructor ID!");
                
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Instructor not added. Name or specialization is empty.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }

        // ========================================___================================___==================

        //  AddCourse
        public bool AddCourse(Course course)
        {

           
            Console.Write("Enter Course Title: ");
            course.Title = Console.ReadLine();

            Console.Write("Enter Instructor Name for this course: ");
            string? name = Console.ReadLine();

            for (int i = 0; i < instructors.Count; i++)
            {
                if (instructors[i].Name == name)
                {
             
                    course.Instructor = instructors[i];
                    courses.Add(course);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n Course added successfully");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n {course.PrintDetails()} \n" +
                      $"You should remember your Course ID!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return true;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Instructor not found, Course not added!");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }

        // ========================================___================================___==================

        //  Enroll Student In Course:

        public bool EnrollStudentInCourse(string studentId, string courseId)
        {

            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            if (student != null && course != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("You enrolled course successfully!");
                Console.ForegroundColor = ConsoleColor.White;
                return student.Enroll(course);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You enrolled course failed!");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }
        // ========================================___================================___==================

        // Find:

        public Student FindStudent(string stuudentId)
        {

          
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].StudentId == stuudentId)
                {Console.WriteLine(students[i].PrintDetails());
                    return students[i];
                }
            }

            Console.WriteLine($"\nThere is no Student by this Id");
            return null;
        }
        public Course FindCourse(string courseId)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].CourseId == courseId)
                {Console.WriteLine(courses[i].PrintDetails());
                    return courses[i];
                }
            }
            Console.WriteLine($"There is no Course by this Id");
            return null;
        }
        public Instructor FindInstructor(string InstructorId)
        {
            for (int i = 0; i < instructors.Count; i++)
            {
                if (instructors[i].InstructorId == InstructorId)
                 { 
                    Console.WriteLine(instructors[i].PrintDetails());
                    return instructors[i];
                 }
            }
            Console.WriteLine($"There is no instructor by this Id");

            return null;
        }

        // ========================================___================================___==================

        //  View All Students

        public void ViewAllStudents()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"All Students: ");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < students.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Students {i}: \n{students[i].PrintDetails()}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        // ViewAllInstructors
        public void ViewAllInstructors()
        {
            if (instructors.Count == 0)
            {
                Console.WriteLine("No instructors available.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("All Instructors:");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < instructors.Count; i++)
            {
                Console.WriteLine(instructors[i].PrintDetails());
            }
        }

        // ViewAllCourses
        public void ViewAllCourses()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses available.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("All Courses:");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine(courses[i].PrintDetails());
            }
        }

        // ========================================___================================___==================

        // UpdateStudent
        public void UpdateStudent()
        {
            bool found = false;
            Console.Write("Enter Student ID to update: ");
            string id = Console.ReadLine();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].StudentId == id)
                {
                    found = true;
                    Console.Write("Do you want to change your name? [yes / no]: ");
                    string? answer = Console.ReadLine();
                    if (answer == "yes")
                    {
                        Console.Write("Enter new name: ");
                        students[i].Name = Console.ReadLine();
                    }

                    Console.Write("Enter new age: ");
                    int newAge = int.Parse(Console.ReadLine());

                    if (newAge > 20)
                    {
                        students[i].Age = newAge;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Student age updated.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Age must be above 20.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                }
            }

                  if (!found)
                  {
                     Console.WriteLine("There is no student with this ID.");
                  }       
        }

        // DeleteStudent
        public bool DeleteStudent(string studentId)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].StudentId == studentId)
                {
                    students.RemoveAt(i);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Student deleted successfully.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return true;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Student not found.");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }
        public string GetInstructorNameByCourseTitle(string courseTitle)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Title == courseTitle && courses[i].Instructor != null)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(courses[i].PrintDetails());
                    Console.ForegroundColor = ConsoleColor.White;
                    return courses[i].Instructor.Name;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Not found");
           Console.ForegroundColor = ConsoleColor.White;

            return "Not found";
        }
    }
    class Student
    {
        public string StudentId = Guid.NewGuid().ToString();
        public string Name;
       public int Age;
       public List<Course> Courses = new List<Course>();

        public bool Enroll(Course course)
        {
            if (course != null)
            {
                Courses.Add(course);
                return true;
            }

            return false;
 
        }
        public string PrintDetails()
        {
            string courseTitles = "";

            if (Courses.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                courseTitles = "No courses enrolled";
            }
            else
            {
                for (int i = 0; i < Courses.Count; i++)
                {
                    courseTitles += Courses[i].Title;
                    if (i < Courses.Count - 1)
                        courseTitles += ", ";
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            return $"Student ID: {StudentId}, Name: {Name}, Age: {Age}, Courses: {courseTitles}";
          
        }

    }
 

     class Instructor
    {

        public string InstructorId = Guid.NewGuid().ToString();
        public string Name;
        public string Specialization;

        public string PrintDetails()
        {
            return $"[Instructor] ID: {InstructorId}, Name: {Name}, Specialization: {Specialization}";
        }
    }

    class Course
    {
        public string CourseId = Guid.NewGuid().ToString();
        public string Title;
        public Instructor Instructor;

        public string PrintDetails()
        {   
            return $"[Course] ID: {CourseId}, Title: {Title}, Instructor: {Instructor?.Name ?? "Not Available"}";
        }
    }



}
