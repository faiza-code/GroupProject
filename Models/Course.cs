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
        [Key]
        public int CourseID { get; set; }
        public string Titel { get; set; }
        public string Category { get; set; }
        public string Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Fee { get; set; }
        public Course course { get; set; }


        [ForeignKey(nameof(triainer))]
        public Triainer triainer { get; set; }
        public int TrainerID { get; set; }
        public ICollection<Triainer>triainers { get; set; } = new HashSet<Triainer>();



        //Function
        public ICollection<Enrollment> enrollment { get; set; } = new HashSet<Enrollment>();
        public ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();

        public bool IsActive()
        {
            var now = DateTime.Now;
            return now >= StartDate && now <= EndDate;
        }

        public decimal TotalRevenue()
        {
            decimal total = 0;
            foreach (var enrollment in Enrollment)
            {
                foreach (var payment in enrollment.payment)
                {
                    total += payment.AmountPaid;
                }
            }
            return total;
        }

        public decimal ApplyDiscount(decimal courseFee)
        {
            int completedCourses = Enrollment.Count(e => e.Status == "Completed");
            if (completedCourses >= 3)
            {
                decimal discountedFee = courseFee * .10m; 
                Console.WriteLine($" {FullName}.New Fee: {discountedFee}");
                return discountedFee;
            }
            return courseFee;
        }


    }

}

