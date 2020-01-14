using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPC.DAL.View_Models;
using DPC.Data;
using DPC.Models.Entities;

namespace DPC.DAL
{
    public class TraineeRepository : ITraineeRepository
    {
        ApplicationDbContext context;
        public TraineeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public string AddTrainee(TraineeVM vm)
        {
            Trainee newTrainee = new Trainee
            {
                TraineeId = vm.TraineeId,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                MiddleName = vm.MiddleName,
                PhoneNumber = vm.PhoneNumber,
                Deanery = vm.Deanery,
                Parish = vm.Parish,
                Pathway = vm.Pathway,
                DateAdded = DateTime.Now
            };
            context.Trainees.Add(newTrainee);
            context.SaveChanges();
            return "success";
        }

        public string DeleteTrainee(int TraineeId)
        {
            try
            {
                Trainee trainee = context.Trainees.Where(f => f.TraineeId == TraineeId).FirstOrDefault();
                if (trainee != null)
                {
                    context.Trainees.Remove(trainee);
                    context.SaveChanges();
                    return "success";
                }
                return "Not Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<TraineeVM> GetTraineesByDeanery(Deanery deanery)
        {
            List<Trainee> trainees = context.Trainees.Where(f => f.Deanery == deanery).ToList();
            List<TraineeVM> models = new List<TraineeVM>();
            foreach (var trainee in trainees)
            {
                models.Add(new TraineeVM
                { 
                    TraineeId = trainee.TraineeId,
                    FirstName = trainee.FirstName,
                    LastName = trainee.LastName,
                    MiddleName = trainee.MiddleName,
                    PhoneNumber = trainee.PhoneNumber,
                    Deanery = trainee.Deanery,
                    Parish = trainee.Parish,
                    Pathway = trainee.Pathway,
                    DateAdded = trainee.DateAdded
                });
            }
            return models;
        }

        public TraineeVM GetTraineeByID(int TraineeId)
        {
            Trainee trainee = context.Trainees.Where(f => f.TraineeId == TraineeId).FirstOrDefault();
            var model = new TraineeVM
            {
                TraineeId = trainee.TraineeId,
                FirstName = trainee.FirstName,
                LastName = trainee.LastName,
                MiddleName = trainee.MiddleName,
                PhoneNumber = trainee.PhoneNumber,
                Deanery = trainee.Deanery,
                Parish = trainee.Parish,
                Pathway = trainee.Pathway,
                DateAdded = trainee.DateAdded
            };
            return model;
        }

        public TraineeVM GetTraineeByName(string name)
        {
            Trainee trainee = context.Trainees.Where(f => f.FirstName == name || f.LastName == name || f.MiddleName == name).FirstOrDefault();
            var model = new TraineeVM
            {
                TraineeId = trainee.TraineeId,
                FirstName = trainee.FirstName,
                LastName = trainee.LastName,
                MiddleName = trainee.MiddleName,
                PhoneNumber = trainee.PhoneNumber,
                Deanery = trainee.Deanery,
                Parish = trainee.Parish,
                Pathway = trainee.Pathway,
                DateAdded = trainee.DateAdded
            };
            return model;
        }

        public IEnumerable<TraineeVM> GetTraineesByParish(string parish)
        {
            List<Trainee> trainees = context.Trainees.Where(f => f.Parish.Contains(parish)).ToList();
            List<TraineeVM> models = new List<TraineeVM>();
            foreach (var trainee in trainees)
            {
                models.Add(new TraineeVM
                {
                    TraineeId = trainee.TraineeId,
                    FirstName = trainee.FirstName,
                    LastName = trainee.LastName,
                    MiddleName = trainee.MiddleName,
                    PhoneNumber = trainee.PhoneNumber,
                    Deanery = trainee.Deanery,
                    Parish = trainee.Parish,
                    Pathway = trainee.Pathway,
                    DateAdded = trainee.DateAdded
                });
            }
            return models;
        }

        public IEnumerable<TraineeVM> GetTraineesByPathway(Pathway pathway)
        {
            List<Trainee> trainees = context.Trainees.Where(f => f.Pathway == pathway).ToList();
            List<TraineeVM> models = new List<TraineeVM>();
            foreach (var trainee in trainees)
            {
                models.Add(new TraineeVM
                {
                    TraineeId = trainee.TraineeId,
                    FirstName = trainee.FirstName,
                    LastName = trainee.LastName,
                    MiddleName = trainee.MiddleName,
                    PhoneNumber = trainee.PhoneNumber,
                    Deanery = trainee.Deanery,
                    Parish = trainee.Parish,
                    Pathway = trainee.Pathway,
                    DateAdded = trainee.DateAdded
                });
            }
            return models;
        }

        public IEnumerable<TraineeVM> GetTrainees()
        {
            List<Trainee> trainees = context.Trainees.ToList();
            List<TraineeVM> models = new List<TraineeVM>();
            foreach (var trainee in trainees)
            {
                models.Add(new TraineeVM
                {
                    TraineeId = trainee.TraineeId,
                    FirstName = trainee.FirstName,
                    LastName = trainee.LastName,
                    MiddleName = trainee.MiddleName,
                    PhoneNumber = trainee.PhoneNumber,
                    Deanery = trainee.Deanery,
                    Parish = trainee.Parish,
                    Pathway = trainee.Pathway,
                    DateAdded = trainee.DateAdded
                });
            }
            return models;
        }

        public string UpdateTrainee(TraineeVM vm)
        {
            Trainee trainee = context.Trainees.Where(f => f.TraineeId == vm.TraineeId).FirstOrDefault();
            if (trainee != null)
            {
                trainee.FirstName = trainee.FirstName;
                trainee.LastName = trainee.LastName;
                trainee.MiddleName = trainee.MiddleName;
                trainee.PhoneNumber = trainee.PhoneNumber;
                trainee.Deanery = trainee.Deanery;
                trainee.Parish = trainee.Parish;
                trainee.Pathway = trainee.Pathway;
            }
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
        // ~TraineeRepository()
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
