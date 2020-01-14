using DPC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPC.DAL.View_Models
{
    public class TraineeVM
    {
        public int TraineeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public Deanery Deanery { get; set; }
        public string Parish { get; set; }
        public Pathway Pathway { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
