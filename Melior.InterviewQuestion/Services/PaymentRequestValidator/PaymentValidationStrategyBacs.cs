using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services.PaymentRequestValidator
{
    public class PaymentValidationStrategyBacs : BasePaymentValidationStrategy
    {
        public override bool ValidatePayment(MakePaymentRequest paymentRequest, Account debtorAccount)
        {
            return base.ValidatePayment(paymentRequest, debtorAccount);
        }
    }
}
