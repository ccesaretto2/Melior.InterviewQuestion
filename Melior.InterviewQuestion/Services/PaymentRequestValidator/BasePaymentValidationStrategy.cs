using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services.PaymentRequestValidator
{
    public abstract class BasePaymentValidationStrategy : IPaymentValidationStrategy
    {
        public virtual bool ValidatePayment(MakePaymentRequest paymentRequest, Account debtorAccount)
        {
            //All the strategies perform these steps
            if (debtorAccount == null) return false;
            if (!debtorAccount.AllowedPaymentSchemes.HasFlag(paymentRequest.PaymentScheme)) return false;
            return true;
        }
    }
}
