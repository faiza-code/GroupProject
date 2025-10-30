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
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        // Is Primary key From Class Trainar and ForeignKey in Class Enrollment....
        [ForeignKey(nameof(Enrollment))]
        public Enrollment Enrollment { get; set; }
        public int EnrollmentId { get; set; }
        public ICollection<Enrollment> enrollments { get; set; } = new HashSet<Enrollment>();


    }
}
