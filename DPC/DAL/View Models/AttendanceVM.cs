using DPC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPC.DAL.View_Models
{
    public class AttendanceVM
    {
        public int AttendanceId { get; set; }
        public int TraineeId { get; set; }
        public virtual Trainee Trainee { get; set; }
        public string MarkedBy { get; set; }
        public Status February { get; set; }
        public Status March { get; set; }
        public Status April { get; set; }
        public Status May { get; set; }
        public Status June { get; set; }
        public Status July { get; set; }
        public Status August { get; set; }
        public Status September { get; set; }
        public Status October { get; set; }
        public Status November { get; set; }
    }
}
