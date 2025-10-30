using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public double Grade { get; set; }
        public string Status { get; set; }

        public Enrollment enrollment { get; set; }

        // this id a forinKey of class Student....
        [ForeignKey(nameof(student))]
        public Student student { get; set; }
        public int StudentID { get; set; }
        public ICollection<Student> students { get; set; } = new HashSet<Student>();


        // this id a forinKey of class Course....
        [ForeignKey(nameof(course))]
        public Course course { get; set; }
        public int CourseID { get; set; }
        public ICollection<Course> courses { get; set; } = new HashSet<Course>();


        //function :
        public ICollection<Payment> payments { get; set; } = new HashSet<Payment>();
        public decimal TotalPaid => payments.Sum(p => p.AmountPaid);

        internal static int count(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public decimal RemainingBalance (decimal amount)
        {
            amount = courses.Fee - TotalPaid;
            return amount;
        }

    }
}

