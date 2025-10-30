using GroupProject.Models.Enum;
using GroupProject.Services;

namespace GroupProject
{
    public class Program
    {

        static void Main(string[] args)
        {
      
            ServicesSystem system = new ServicesSystem();

       
            var trainer1 = system.AddTrainer("Yousif Mohammed", "FullStack Web Developer", 17, "92978208", "youssif.mahammed@gmail.com");
            var trainer2 = system.AddTrainer("Kalthom", "Data Science", 3, "98765432", "Kalthom@gmail.com");
            var trainer3 = system.AddTrainer("Sultan", "Trainer", 30, "98765432", "Sultan@gmail.com ");


            var course1 = system.AddCourse("C# Basics", "Programming", 40,
                          new DateTime(2025, 11, 1), new DateTime(2024, 12, 30), 300, trainer1);
            var course2 = system.AddCourse("Python Basics", "Programming", 40,
                          new DateTime(2025, 11, 1), new DateTime(2025, 11, 30), 250, trainer2);

            var student1 = system.RegisterStudent("Faiza Alhandali", "1234567890", "91234567", "faiza@gmail.com", "Nizwa");
            var student2 = system.RegisterStudent("Raya Al Amri", "0987654321", "98765432",    "Raya@gmail.com", "Salalah");
            var student3 = system.RegisterStudent("Asma Al-Alawi", "0987654321", "98765432", "Asma@gmail.com", "Ibri");
            var student4 = system.RegisterStudent("Leema Al Raai", "0987654321", "98765432", "Leema@gmail.com", "Salalah");
            var student5 = system.RegisterStudent("Duaa Al Dahab", "0987654321", "98765432", "Duaa@gmail.com", "Salalah");

            var enrollment1 = system.EnrollStudentInCourse(student1, course1);
            var enrollment2 = system.EnrollStudentInCourse(student2, course2);
            var enrollment3 = system.EnrollStudentInCourse(student3, course1);
            var enrollment4 = system.EnrollStudentInCourse(student4, course2);
            var enrollment5 = system.EnrollStudentInCourse(student5, course1);


            var payment1 = system.RecordPayment(enrollment1, 300, PaymentMethod.Cash);
            var payment2 = system.RecordPayment(enrollment2, 300, PaymentMethod.Card);
            var payment3 = system.RecordPayment(enrollment3, 500, PaymentMethod.Card);
            var payment4 = system.RecordPayment(enrollment4, 900, PaymentMethod.BankTransfer);
            var payment5 = system.RecordPayment(enrollment5, 600, PaymentMethod.Cash);

            var studentsInC1 = system.GetStudentsInCourse(course1.CourseID);
            Console.WriteLine("Students in course " + course1.Title + ":");
            foreach (var s in studentsInC1)
            {
                Console.WriteLine($"- {s.FullName}");
            }

            Console.WriteLine("Total revenue for course " + course1.Title + ": " + system.GetRevenueForCourse(course1.CourseID));

            Console.WriteLine("Top students by completed courses:");
            var topStudents = system.GetTopStudents();
            foreach (var s in topStudents)
            {
                Console.WriteLine($"{s.FullName}: {s.CompletedCoursesCount} completed courses");
            }















        }
    }
}
