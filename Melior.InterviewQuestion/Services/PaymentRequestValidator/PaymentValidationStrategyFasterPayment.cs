using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services.PaymentRequestValidator
{
    public class PaymentValidationStrategyFasterPayment : BasePaymentValidationStrategy
    {
        public override bool ValidatePayment(MakePaymentRequest paymentRequest, Account debtorAccount)
        {
            if (!base.ValidatePayment(paymentRequest, debtorAccount)) return false;
            if (debtorAccount.Balance < paymentRequest.Amount) return false;
            return true;
        }
    }
}
