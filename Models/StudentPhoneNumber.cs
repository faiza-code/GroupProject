using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class StudentPhoneNumber
    {
        public int StudentPhone { get; set; }

        // Is Primary key From Class Student and ForeignKey in Class StudentPhoneNumber....
        [ForeignKey(nameof(student))]
        public Student student { get; set; }
        public int StudentID { get; set; }
        public ICollection<Student> students { get; set; } = new HashSet<Student>();


    }
}
