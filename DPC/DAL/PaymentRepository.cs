using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPC.DAL.View_Models;
using DPC.Data;
using DPC.Models.Entities;

namespace DPC.DAL
{
    public class PaymentRepository : IPaymentRepository
    {
        ApplicationDbContext context;
        public PaymentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string Reference()
        {
            string txt = "DPC";
            var currentYear = DateTime.Today.Year;

            Random random = new Random();
            var refNo = random.Next(11111, 99999);

            string referenceNo = txt + "-" + currentYear + "-" + refNo;

            return referenceNo;
        }

        public string AddPayment(PaymentVM vm)
        {
            try
            {
                Payment newPayment = new Payment
                {
                    PaymentId = vm.PaymentId,
                    TraineeId = vm.Trainee.TraineeId,
                    PaymentDate = DateTime.Now,
                    AmountPaid = vm.AmountPaid,
                    PaidTo = vm.PaidTo,
                    PaymentDescription = vm.PaymentDescription
                    //PaymentReference = Reference()
                };
                context.Payments.Add(newPayment);
                context.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeletePayment(int paymentId)
        {
            try
            {
                Payment payment = context.Payments.Where(f => f.PaymentId == paymentId).FirstOrDefault();
                if (payment != null)
                {
                    context.Payments.Remove(payment);
                    context.SaveChanges();
                    return "success";
                }
                return "not found";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<PaymentVM> GetPaymentByDeanery(Deanery deanery)
        {
            List<Payment> payments = context.Payments.Where(f => f.Trainee.Deanery == deanery).ToList();
            List<PaymentVM> models = new List<PaymentVM>();

            foreach (var payment in payments)
            {
                models.Add(new PaymentVM
                {
                    PaymentId = payment.PaymentId,
                    TraineeId = payment.TraineeId,
                    PaymentDate = payment.PaymentDate,
                    AmountPaid = payment.AmountPaid,
                    PaidTo = payment.PaidTo,
                    PaymentDescription = payment.PaymentDescription
                });
            }
            return models;
        }

        public PaymentVM GetPaymentByID(int paymentId)
        {
            Payment payment = context.Payments.Where(f => f.PaymentId == paymentId).FirstOrDefault();
            PaymentVM model = new PaymentVM
            {
                PaymentId = payment.PaymentId,
                TraineeId = payment.TraineeId,
                PaymentDate = payment.PaymentDate,
                AmountPaid = payment.AmountPaid,
                PaidTo = payment.PaidTo,
                PaymentDescription = payment.PaymentDescription
            };
            return model;
        }
        
        public PaymentVM GetPaymentByTraineeID(int traineeId)
        {
            Payment payment = context.Payments.Where(f => f.TraineeId == traineeId).FirstOrDefault();
            PaymentVM model = new PaymentVM
            {
                PaymentId = payment.PaymentId,
                TraineeId = payment.TraineeId,
                PaymentDate = payment.PaymentDate,
                AmountPaid = payment.AmountPaid,
                PaidTo = payment.PaidTo,
                PaymentDescription = payment.PaymentDescription
            };
            return model;
        }

        public PaymentVM GetPaymentByName(string name)
        {
            Payment payment = context.Payments.Where(f => f.Trainee.FirstName == name || f.Trainee.MiddleName == name || f.Trainee.LastName == name).FirstOrDefault();
            PaymentVM model = new PaymentVM
            {
                PaymentId = payment.PaymentId,
                TraineeId = payment.TraineeId,
                PaymentDate = payment.PaymentDate,
                AmountPaid = payment.AmountPaid,
                PaidTo = payment.PaidTo,
                PaymentDescription = payment.PaymentDescription
            };
            return model;
        }

        public IEnumerable<PaymentVM> GetPaymentByParish(string parish)
        {
            List<Payment> payments = context.Payments.Where(f => f.Trainee.Parish.Contains(parish)).ToList();
            List<PaymentVM> models = new List<PaymentVM>();

            foreach (var payment in payments)
            {
                models.Add(new PaymentVM
                {
                    PaymentId = payment.PaymentId,
                    TraineeId = payment.TraineeId,
                    PaymentDate = payment.PaymentDate,
                    AmountPaid = payment.AmountPaid,
                    PaidTo = payment.PaidTo,
                    PaymentDescription = payment.PaymentDescription
                });
            }
            return models;
        }

        public IEnumerable<PaymentVM> GetPaymentByPathway(Pathway pathway)
        {
            List<Payment> payments = context.Payments.Where(f => f.Trainee.Pathway == pathway).ToList();
            List<PaymentVM> models = new List<PaymentVM>();

            foreach (var payment in payments)
            {
                models.Add(new PaymentVM
                {
                    PaymentId = payment.PaymentId,
                    TraineeId = payment.TraineeId,
                    PaymentDate = payment.PaymentDate,
                    AmountPaid = payment.AmountPaid,
                    PaidTo = payment.PaidTo,
                    PaymentDescription = payment.PaymentDescription
                });
            }
            return models;
        }

        public IEnumerable<PaymentVM> GetPayments()
        {
            List<Payment> payments = context.Payments.ToList();
            List<PaymentVM> models = new List<PaymentVM>();

            foreach (var payment in payments)
            {
                models.Add(new PaymentVM
                {
                    PaymentId = payment.PaymentId,
                    TraineeId = payment.TraineeId,
                    PaymentDate = payment.PaymentDate,
                    AmountPaid = payment.AmountPaid,
                    PaidTo = payment.PaidTo,
                    PaymentDescription = payment.PaymentDescription
                });
            }
            return models;
        }

        public string UpdatePayment(PaymentVM vm)
        {
            throw new NotImplementedException();
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
        // ~PaymentRepository()
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
