using GroupProject.Models.Enum;
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
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public string CivilID { get; set; }
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string City { get; set; }
        public DateTime RegistrationDate { get; set; }

        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

       // Funtionn 
        public int CompletedCoursesCount => Enrollments.Count(e => e.Status == EnrollmentStatus.Completed);
    }
}
