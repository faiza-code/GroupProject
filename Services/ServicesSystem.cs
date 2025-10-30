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
        private List<Student> students = new List<Student>();
        private List<Trainer> trainers = new List<Trainer>();
        private List<Course> courses = new List<Course>();
        private List<Enrollment> enrollments = new List<Enrollment>();
        private List<Payment> payments = new List<Payment>();

        private int nextStudentId = 1;
        private int nextTrainerId = 1;
        private int nextCourseId = 1;
        private int nextEnrollmentId = 1;
        private int nextPaymentId = 1;

        public Student RegisterStudent(string fullName, string civilId, string phone,
                                       string email, string city)
        {
            Student student = new Student
            {
                StudentID = nextStudentId++,
                FullName = fullName,
                CivilID = civilId,
                Phone = phone,
                Email = email,
                City = city,
                RegistrationDate = DateTime.Now
            };
            students.Add(student);
            return student;
        }

        public Trainer AddTrainer(string name, string specialty, int yearsOfExperience,
                                  string phone, string email)
        {
            Trainer trainer = new Trainer
            {
                TrainerID = nextTrainerId++,
                Name = name,
                Specialty = specialty,
                YearsOfExperience = yearsOfExperience,
                Phone = phone,
                Email = email
            };
            trainers.Add(trainer);
            return trainer;
        }

        public Course AddCourse(string title, string category, int duration,
                                DateTime startDate, DateTime endDate,
                                decimal fee, Trainer trainer)
        {
            if (trainer.ActiveCoursesCount >= 3)
                throw new InvalidOperationException("Trainer cannot handle more than 3 active courses.");

            Course course = new Course
            {
                CourseID = nextCourseId++,
                Title = title,
                Category = category,
                Duration = duration,
                StartDate = startDate,
                EndDate = endDate,
                Fee = fee,
                Trainer = trainer
            };
            courses.Add(course);
            trainer.Courses.Add(course);
            return course;
        }

       
        private bool IsOverlapping(Course c1, Course c2)
        {
            return c1.StartDate < c2.EndDate && c2.StartDate < c1.EndDate;
        }

        public Enrollment EnrollStudentInCourse(Student student, Course course)
        {
            
            var activeEnrollments = student.Enrollments
                .Where(e => e.Status == EnrollmentStatus.Active)
                .Select(e => e.Course);

            foreach (var c in activeEnrollments)
            {
                if (IsOverlapping(c, course))
                    throw new InvalidOperationException("Student cannot enroll in overlapping courses.");
            }

         
            decimal feeToPay = course.Fee;
            if (student.CompletedCoursesCount >= 3)
            {
                feeToPay = feeToPay * 0.9m; 
            }

            Enrollment enrollment = new Enrollment
            {
                EnrollmentID = nextEnrollmentId++,
                Student = student,
                Course = course,
                EnrollmentDate = DateTime.Now,
                Status = EnrollmentStatus.Active
            };
            enrollments.Add(enrollment);
            student.Enrollments.Add(enrollment);
            course.Enrollments.Add(enrollment);

            return enrollment;
        }

        public Payment RecordPayment(Enrollment enrollment, decimal amountPaid, PaymentMethod method)
        {
            if (!enrollments.Contains(enrollment))
                throw new InvalidOperationException("Enrollment does not exist.");

            if (amountPaid <= 0)
                throw new ArgumentException("Amount paid must be positive.");

            var remaining = enrollment.Course.Fee - enrollment.TotalPaid;
            if (amountPaid > remaining)
                throw new InvalidOperationException("Amount paid exceeds remaining balance.");

            var payment = new Payment
            {
                PaymentID = nextPaymentId++,
                Enrollment = enrollment,
                AmountPaid = amountPaid,
                PaymentDate = DateTime.Now,
                PaymentMethod = method
            };
            payments.Add(payment);
            enrollment.Payments.Add(payment);

            return payment;
        }

      
        public List<Student> GetStudentsInCourse(int courseId)
        {
            return enrollments
                .Where(e => e.Course.CourseID == courseId && e.Status == EnrollmentStatus.Active)
                .Select(e => e.Student)
                .ToList();
        }

        public decimal GetRevenueForCourse(int courseId)
        {
            return enrollments
                .Where(e => e.Course.CourseID == courseId)
                .Sum(e => e.TotalPaid);
        }

        public List<Student> GetTopStudents(int topCount = 3)
        {
            return students
                .OrderByDescending(s => s.CompletedCoursesCount)
                .Take(topCount)
                .ToList();
        }
    }

}
