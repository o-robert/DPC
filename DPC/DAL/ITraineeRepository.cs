using DPC.DAL.View_Models;
using DPC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPC.DAL
{
    interface ITraineeRepository :IDisposable
    {
        IEnumerable<TraineeVM> GetTrainees();
        TraineeVM GetTraineeByID(int TraineeId);
        IEnumerable<TraineeVM> GetTraineesByDeanery(Deanery deanery);
        IEnumerable<TraineeVM> GetTraineesByParish(string parish);
        TraineeVM GetTraineeByName(string name);
        IEnumerable<TraineeVM> GetTraineesByPathway(Pathway pathway);
        string AddTrainee(TraineeVM vm);
        string DeleteTrainee(int TraineeId);
        string UpdateTrainee(TraineeVM vm);
    }
}
