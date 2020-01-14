using DPC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPC.DAL.View_Models
{
    public class PaymentVM
    {
        public int PaymentId { get; set; }
        public virtual Trainee Trainee { get; set; }
        public int TraineeId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaidTo { get; set; }
        public float AmountPaid { get; set; }
        public string PaymentDescription { get; set; }
    }
}
