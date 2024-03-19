using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services.PaymentRequestValidator
{
    public interface IPaymentRequestValidator
    {
        bool IsPaymentRequestValid(MakePaymentRequest paymentRequest, Account debtorAccount);
    }
}
