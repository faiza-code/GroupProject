using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public  class Student
    {
        [Key]
        public int StudentID{ get; set; }
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string CivilID { get; set; }
        public DateTime RegistrationData { get; set; }
        public Student student { get; set; }



        
        public ICollection<Enrollment> enrollments { get; set; } = new HashSet<Enrollment>();
        public int CoursesCount => enrollments.Count(e => e.Status == "Completed");
        public bool EnrollInCourse(Course course)
        {
            foreach (var enrollment in Enrollment)
            {
                if (enrollment.Status == "Active" &&
                    enrollment.Course.StartDate < course.EndDate &&
                    course.StartDate < enrollment.Course.EndDate)
                {
                    Console.WriteLine($"{FullName} Full rejester in {course.Titel} ");
                    return false;
                }
            }

            Enrollment.Add(newEnrollment);
            course.Enrollments.Add(newEnrollment);
            Console.WriteLine($"{FullName} you rigester in   {course.Titel}");
            return true;
        }
    }









}

