using GroupProject.Models;

namespace GroupProject
{
    public class Program
    {

        static void Main(string[] args)
        {
            Triainer trainer1 = new Triainer
            {
                TrinaerID = 1,
                Name = "Ahmed",
                Specialty = "Programming",
                YearOfExperience = 5,
                Email = "ahmed@mail.com"
            };
            Course course1 = new Course
            {
                CourseID = 101,
                Titel = "C# Basics",
                Category = "Programming",
                StartDate = new DateTime(2025, 11, 1),
                EndDate = new DateTime(2025, 11, 10),
                Fee = 200
            };
            trainer1.Courses.Add(course1);


            Student student1 = new Student
            {
                StudentID = 1,
                FullName = "Raya Al Amri",
                CivilID = "1234567890",
                Email = "raya@mail.com",
                RegistrationData = DateTime.Now
            };


            Student student2 = new Student
            {
                StudentID = 1,
                FullName = "Tafool",
                CivilID = "1234567890",
                Email = "raya@mail.com",
                RegistrationData = DateTime.Now
            };
            student1.EnrollInCourse(course1);
            Payment payment1 = new Payment
            {
                PaymentID = 1,
               // enrollment = student1.,
                AmountPaid = student1.
                PaymentDate = DateTime.Now,
                PaymentMethod = "Card",
                RemainingBalance = 0
            };















        }
    }
}
