using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public  class Triainer
    {
        [Key]
        public int TrinaerID { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public int YearOfExperience { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public Triainer triainer{ get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();
        public int ActiveCourses => Courses.Count(c => c.IsActive());

    }
}
