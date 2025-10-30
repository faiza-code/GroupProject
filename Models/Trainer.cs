using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class Trainer
    {
        [Key]
        public int TrainerID { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public int YearsOfExperience { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

        public int ActiveCoursesCount => Courses.Count(c => c.IsActive());



    }
}