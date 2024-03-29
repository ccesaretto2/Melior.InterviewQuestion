﻿using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services.PaymentRequestValidator
{
    public interface IPaymentValidationStrategy
    {
        bool ValidatePayment(MakePaymentRequest paymentRequest, Account debtorAccount);
    }
}
