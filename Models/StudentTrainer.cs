using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class StudentTrainer
    {

        // Is Primary key From Class Student and ForeignKey in Class StudentTrainer....
        [ForeignKey(nameof(student))]
        public Student student { get; set; }
        public int StudentID { get; set; }
        public ICollection<Student> students { get; set; } = new HashSet<Student>();



        // Is Primary key From Class Trainer and ForeignKey in Class StudentTrainer....
        [ForeignKey(nameof(trainer))]
        public Trainer trainer { get; set; }
        public int TrainerID { get; set; }
        public ICollection<Trainer> triainers { get; set; } = new HashSet<Trainer>();
    }
}
