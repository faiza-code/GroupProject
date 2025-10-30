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
        public string PaymentMethod { get; set; }
        public decimal RemainingBalance { get; set; }

        public Payment payment { get; set; }

        // this id a forinKey of class Enrollment....
        [ForeignKey(nameof(enrollment))]
        public Enrollment enrollment { get; set; }
        public int EnrollmentId { get; set; }
        public ICollection<Enrollment> enrollments { get; set; } = new HashSet<Enrollment>();





    
}
}
