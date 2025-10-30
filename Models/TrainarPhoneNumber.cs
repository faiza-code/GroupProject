using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class TrainarPhoneNumber
    {
        public int PhoneNumber { get; set; }


        // Is Primary key From Class Trainer and ForeignKey in Class TrainerPhoneNumber....
        [ForeignKey(nameof(traininer))]
        public Trainer traininer { get; set; }
        public int TrainerID { get; set; }
        public ICollection<Trainer> triainers { get; set; } = new HashSet<Trainer>();
    }
}
