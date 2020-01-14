using DPC.DAL.View_Models;
using DPC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPC.DAL
{
    interface IPaymentRepository : IDisposable
    {
        IEnumerable<PaymentVM> GetPayments();
        PaymentVM GetPaymentByID(int paymentId);
        IEnumerable<PaymentVM> GetPaymentByDeanery(Deanery deanery);
        IEnumerable<PaymentVM> GetPaymentByParish(string parish);
        PaymentVM GetPaymentByName(string name);
        IEnumerable<PaymentVM> GetPaymentByPathway(Pathway pathway);
        string AddPayment(PaymentVM vm);
        string DeletePayment(int paymentId);
        string UpdatePayment(PaymentVM vm);
    }
}
