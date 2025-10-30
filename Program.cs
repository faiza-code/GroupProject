using GroupProject.Models;
using GroupProject.Models.Enum;
using GroupProject.Services;

namespace GroupProject
{
    public class Program
    {

        static void Main(string[] args)
        {
      
            ServicesSystem system = new ServicesSystem();

            Trainer trainer1 = system.AddTrainer("Yousif Mohammed", "FullStack Web Developer", 17, "92978208", "youssif.mahammed@gmail.com");
            Trainer trainer2 = system.AddTrainer("Kalthom", "Data Science", 3, "98765432", "Kalthom@gmail.com");
            Trainer trainer3 = system.AddTrainer("Sultan", "Trainer", 30, "98765432", "Sultan@gmail.com ");

            
            Course course = system.AddCourse("C# Basic", "Data Science", 30, DateTime.Today.AddDays(1), DateTime.Today.AddDays(30), 400, trainer1);
            Course course2 = system.AddCourse("Python Basic", "", 30, DateTime.Today.AddDays(1), DateTime.Today.AddDays(30), 400, trainer1);



            Student student1 = system.RegisterStudent("Faiza Alhandali", "1234567890", "91234567", "faiza@gmail.com", "Nizwa");
            Student student2 = system.RegisterStudent("Raya Al Amri", "0987654321", "98765432", "Raya@gmail.com", "Salalah");
            Student student3 = system.RegisterStudent("Asma Al-Alawi", "0987654321", "98765432", "Asma@gmail.com", "Ibri");
            Student student4 = system.RegisterStudent("Leema Al Raai", "0987654321", "98765432", "Leema@gmail.com", "Salalah");
            Student student5 = system.RegisterStudent("Duaa Al Dahab", "0987654321", "98765432", "Duaa@gmail.com", "Salalah");

            
            Enrollment e1 = system.EnrollStudent(student1, course);
            Enrollment e2 = system.EnrollStudent(student2, course);
            Enrollment e3 = system.EnrollStudent(student3, course);
            Enrollment e4 = system.EnrollStudent(student4, course);
            Enrollment e5 = system.EnrollStudent(student5, course);

            
            if (e1 != null) system.RecordPayment(e1, 200, PaymentMethod.Cash);
            if (e2 != null) system.RecordPayment(e2, 500, PaymentMethod.Card);
            if (e3 != null) system.RecordPayment(e3, 400, PaymentMethod.BankTransfer);
            if (e4 != null) system.RecordPayment(e4, 600, PaymentMethod.BankTransfer);
            if (e5 != null) system.RecordPayment(e5, 500, PaymentMethod.Card);

            
            system.DisplayStudentsInCourse(course);
            system.DisplayRevenueForCourse(course);
            system.DisplayTopStudents();














        }
    }
}
