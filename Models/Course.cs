using GroupProject.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class Course
    {   
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int Duration { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Fee { get; set; }


        // Is Primary key From Class Trainar and ForeignKey in Class Course....
        [ForeignKey(nameof(Trainer))]
        public Trainer Trainer { get; set; }
        public int TrainerID { get; set; }
        public ICollection<Trainer> triainers { get; set; } = new HashSet<Trainer>();



        //Function
        public object FullName { get; private set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public bool IsActive()
        {
            var now = DateTime.Now;
            return now >= StartDate && now <= EndDate;
        }

        }

}

