using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DPC.Models.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        public virtual Trainee Trainee { get; set; }
        public int TraineeId { get; set; }
        public DateTime PaymentDate { get; set; }
        [Required]
        public string PaidTo { get; set; }
        [Required]
        public float AmountPaid { get; set; }
        [Required]
        public string PaymentDescription { get; set; }
    }
}
