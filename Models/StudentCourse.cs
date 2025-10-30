using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class StudentCourse
    {
        // Is Primary key From Class Student and ForeignKey in Class StudentCourse....

        [ForeignKey(nameof(student))]
        public Student student { get; set; }
        public int StudentID { get; set; }
        public ICollection<Student> students { get; set; } = new HashSet<Student>();




        // Is Primary key From Class Course and ForeignKey in Class StudentCourse....
        [ForeignKey(nameof(course))]
        public Course course { get; set; }
        public int CourseID { get; set; }
        public ICollection<Course> courses { get; set; } = new HashSet<Course>();
    }
}
