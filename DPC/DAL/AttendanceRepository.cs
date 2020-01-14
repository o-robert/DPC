using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPC.DAL.View_Models;
using DPC.Data;
using DPC.Models.Entities;

namespace DPC.DAL
{
    public class AttendanceRepository : IAttendanceRepository
    {
        ApplicationDbContext context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public string AddAttendance(AttendanceVM vm)
        {
            Attendance newAttendance = new Attendance() 
            { 
                AttendanceId = vm.AttendanceId,
                TraineeId = vm.Trainee.TraineeId,
                MarkedBy = vm.MarkedBy,
                February = vm.February,
                March = vm.March,
                April = vm.April,
                May = vm.May,
                June = vm.June,
                July = vm.July,
                August = vm.August,
                September = vm.September,
                October = vm.October,
                November = vm.November
            };
            context.Attendances.Add(newAttendance);
            context.SaveChanges();
            return "success";
        }

        public string DeleteAttendance(int attendanceId)
        {
            Attendance attendance = context.Attendances.Where(f => f.AttendanceId == attendanceId).FirstOrDefault();
            context.Attendances.Remove(attendance);
            context.SaveChanges();
            return "success";
        }

        public AttendanceVM GeAttendanceByID(int traineeId)
        {
            Attendance attendance = context.Attendances.Where(f => f.TraineeId == traineeId).FirstOrDefault();
            AttendanceVM model = new AttendanceVM()
            {
                TraineeId = attendance.TraineeId,
                MarkedBy = attendance.MarkedBy,
                February = attendance.February,
                March = attendance.March,
                April = attendance.April,
                May = attendance.May,
                June = attendance.June,
                July = attendance.July,
                August = attendance.August,
                September = attendance.September,
                October = attendance.October,
                November = attendance.November
            };
            return model;
        }

        public IEnumerable<AttendanceVM> GetAttendance()
        {
            List<Attendance> attendances = new List<Attendance>().ToList();
            List<AttendanceVM> models = new List<AttendanceVM>();

            foreach (var attendance in attendances)
            {
                models.Add(new AttendanceVM
                {
                    TraineeId = attendance.TraineeId,
                    MarkedBy = attendance.MarkedBy,
                    February = attendance.February,
                    March = attendance.March,
                    April = attendance.April,
                    May = attendance.May,
                    June = attendance.June,
                    July = attendance.July,
                    August = attendance.August,
                    September = attendance.September,
                    October = attendance.October,
                    November = attendance.November

                });
            }
            return models;
        }

        public IEnumerable<AttendanceVM> GetAttendanceByDeanery(Deanery deanery)
        {
            List<Attendance> attendances = new List<Attendance>().Where(f => f.Trainee.Deanery == deanery).ToList();
            List<AttendanceVM> models = new List<AttendanceVM>();

            foreach (var attendance in attendances)
            {
                models.Add(new AttendanceVM
                {
                    TraineeId = attendance.TraineeId,
                    MarkedBy = attendance.MarkedBy,
                    February = attendance.February,
                    March = attendance.March,
                    April = attendance.April,
                    May = attendance.May,
                    June = attendance.June,
                    July = attendance.July,
                    August = attendance.August,
                    September = attendance.September,
                    October = attendance.October,
                    November = attendance.November

                });
            }
            return models;
        }

        public IEnumerable<AttendanceVM> GetAttendanceByParish(string parish)
        {
            List<Attendance> attendances = new List<Attendance>().Where(f => f.Trainee.Parish.Contains(parish)).ToList();
            List<AttendanceVM> models = new List<AttendanceVM>();

            foreach (var attendance in attendances)
            {
                models.Add(new AttendanceVM
                {
                    TraineeId = attendance.TraineeId,
                    MarkedBy = attendance.MarkedBy,
                    February = attendance.February,
                    March = attendance.March,
                    April = attendance.April,
                    May = attendance.May,
                    June = attendance.June,
                    July = attendance.July,
                    August = attendance.August,
                    September = attendance.September,
                    October = attendance.October,
                    November = attendance.November

                });
            }
            return models;
        }

        public IEnumerable<AttendanceVM> GetAttendanceByPathway(Pathway pathway)
        {
            List<Attendance> attendances = new List<Attendance>().Where(f => f.Trainee.Pathway == pathway).ToList();
            List<AttendanceVM> models = new List<AttendanceVM>();

            foreach (var attendance in attendances)
            {
                models.Add(new AttendanceVM
                {
                    TraineeId = attendance.TraineeId,
                    MarkedBy = attendance.MarkedBy,
                    February = attendance.February,
                    March = attendance.March,
                    April = attendance.April,
                    May = attendance.May,
                    June = attendance.June,
                    July = attendance.July,
                    August = attendance.August,
                    September = attendance.September,
                    October = attendance.October,
                    November = attendance.November

                });
            }
            return models;
        }

        public string UpdateAttendance(AttendanceVM vm)
        {
            Attendance attendance = context.Attendances.Where(f => f.AttendanceId == vm.AttendanceId).FirstOrDefault();

            if(attendance != null)
            {
                attendance.MarkedBy = attendance.MarkedBy;
                attendance.February = attendance.February;
                attendance.March = attendance.March;
                attendance.April = attendance.April;
                attendance.May = attendance.May;
                attendance.June = attendance.June;
                attendance.July = attendance.July;
                attendance.August = attendance.August;
                attendance.September = attendance.September;
                attendance.October = attendance.October;
                attendance.November = attendance.November;
            };
            context.SaveChanges();
            return "success";
         
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AttendanceRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
