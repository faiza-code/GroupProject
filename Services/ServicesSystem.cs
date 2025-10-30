using GroupProject.Models;
using GroupProject.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Services
{
    public class ServicesSystem
    {
        
        public List<Student> Students = new List<Student>();
        public List<Trainer> Trainers = new List<Trainer>();
        public List<Course> Courses = new List<Course>();
        public List<Enrollment> Enrollments = new List<Enrollment>();
        public List<Payment> Payments = new List<Payment>();

        private int nextStudentId = 1;
        private int nextTrainerId = 1;
        private int nextCourseId = 1;
        private int nextEnrollmentId = 1;
        private int nextPaymentId = 1;

       
        public Student RegisterStudent(string name, string civilId, string phone, string email, string city)
        {
            Student student = new Student
            {
                StudentID = nextStudentId++,
                FullName = name,
                CivilID = civilId,
                Phone = phone,
                Email = email,
                City = city,
                RegistrationDate = DateTime.Now,
                Enrollments = new List<Enrollment>()
            };
            Students.Add(student);
            return student;
        }

       
        public Trainer AddTrainer(string name, string specialty, int experience, string phone, string email)
        {
            Trainer trainer = new Trainer
            {
                TrainerID = nextTrainerId++,
                Name = name,
                Specialty = specialty,
                YearsOfExperience = experience,
                Phone = phone,
                Email = email,
                Courses = new List<Course>()
            };
            Trainers.Add(trainer);
            return trainer;
        }

       
        public Course AddCourse(string title, string category, int durationHours, DateTime start, DateTime end, decimal fee, Trainer trainer)
        {
            
            int activeCourses = trainer.Courses.Count(c => DateTime.Now >= c.StartDate && DateTime.Now <= c.EndDate);
            if (activeCourses >= 3)
            {
                Console.WriteLine("This trainer already has 3 active courses. Cannot add more.");
                return null;
            }

            Course course = new Course
            {
                CourseID = nextCourseId++,
                Title = title,
                Category = category,
                Duration = durationHours,
                StartDate = start,
                EndDate = end,
                Fee = fee,
                Trainer = trainer,
                Enrollments = new List<Enrollment>()
            };
            Courses.Add(course);
            trainer.Courses.Add(course);
            return course;
        }

        
        public Enrollment EnrollStudent(Student student, Course course)
        {
            
            foreach (var enrollment1 in student.Enrollments)
            {
                if (enrollment1.Status == EnrollmentStatus.Active &&
                    course.StartDate < enrollment1.Course.EndDate &&
                    course.EndDate > enrollment1.Course.StartDate)
                {
                    Console.WriteLine("Error: Student is already enrolled in a course that overlaps in time.");
                    return null;
                }
            }

            
            decimal fee = course.Fee;
            int completedCourses = student.Enrollments.Count(e => e.Status == EnrollmentStatus.Completed);
            if (completedCourses >= 3)
            {
                fee = fee * 90 / 100;
            }

            Enrollment enrollment = new Enrollment
            {
                EnrollmentID = nextEnrollmentId++,
                Student = student,
                Course = course,
                EnrollmentDate = DateTime.Now,
                Status = EnrollmentStatus.Active,
                Payments = new List<Payment>()
            };
            Enrollments.Add(enrollment);
            student.Enrollments.Add(enrollment);
            course.Enrollments.Add(enrollment);
            Console.WriteLine($"Student {student.FullName} enrolled in {course.Title} with fee {fee}.");
            return enrollment;
        }

       
        public Payment RecordPayment(Enrollment enrollment, decimal amount, PaymentMethod method)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Payment amount must be positive.");
                return null;
            }

            decimal totalPaid = enrollment.Payments.Sum(p => p.AmountPaid);
            decimal remaining = enrollment.Course.Fee - totalPaid;
            if (amount > remaining)
            {
                Console.WriteLine("Payment exceeds remaining balance.");
                return null;
            }

            Payment payment = new Payment
            {
                PaymentID = nextPaymentId++,
                Enrollment = enrollment,
                AmountPaid = amount,
                PaymentDate = DateTime.Now,
                PaymentMethod = method
            };
            Payments.Add(payment);
            enrollment.Payments.Add(payment);
            Console.WriteLine($"Payment of {amount} recorded for {enrollment.Student.FullName}.");
            return payment;
        }

    
        public void DisplayStudentsInCourse(Course course)
        {
            Console.WriteLine($"Students enrolled in {course.Title}:");
            foreach (var enrollment in course.Enrollments.Where(e => e.Status == EnrollmentStatus.Active))
            {
                Console.WriteLine($"- {enrollment.Student.FullName}");
            }
        }

        
        public void DisplayRevenueForCourse(Course course)
        {
            decimal revenue = course.Enrollments.Sum(e => e.Payments.Sum(p => p.AmountPaid));
            Console.WriteLine($"Total revenue for {course.Title}: {revenue}");
        }

        
        public void DisplayTopStudents()
        {
            var topStudents = Students.OrderByDescending(s => s.CompletedCoursesCount).Take(3);
            Console.WriteLine("Top 3 students with most completed courses:");
            foreach (var student in topStudents)
            {
                Console.WriteLine($"{student.FullName} - Completed Courses: {student.CompletedCoursesCount}");
            }

        }
    }
}
