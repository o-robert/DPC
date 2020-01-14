using DPC.DAL.View_Models;
using DPC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPC.DAL
{
    interface IAttendanceRepository : IDisposable
    {
        IEnumerable<AttendanceVM> GetAttendance();
        AttendanceVM GeAttendanceByID(int traineeId);
        IEnumerable<AttendanceVM> GetAttendanceByDeanery(Deanery deanery);
        IEnumerable<AttendanceVM> GetAttendanceByParish(string parish);
        IEnumerable<AttendanceVM> GetAttendanceByPathway(Pathway pathway);
        string AddAttendance(AttendanceVM vm);
        string DeleteAttendance(int attendanceId);
        string UpdateAttendance(AttendanceVM vm);
    }
}
