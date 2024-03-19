using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services.PaymentRequestValidator
{
    public class PaymentValidationStrategyChaps : BasePaymentValidationStrategy
    {
        public override bool ValidatePayment(MakePaymentRequest paymentRequest, Account debtorAccount)
        {
            if (!base.ValidatePayment(paymentRequest, debtorAccount)) return false;
            if (debtorAccount.Status != AccountStatus.Live) return false;
            return true;
        }
    }
}
