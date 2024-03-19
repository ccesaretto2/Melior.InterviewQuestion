using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services.PaymentRequestValidator
{
    public class PaymentRequestValidator : IPaymentRequestValidator
    {
        public bool IsPaymentRequestValid(MakePaymentRequest paymentRequest, Account debtorAccount)
        {
            //I have different validation strategies because the original code was performing different validation steps based on the type of payment.
            //Not sure if it was wanted or not but I am mantaining the same behaviour
            var validationStrategy = GetValidationStrategy(paymentRequest.PaymentScheme);
            return validationStrategy.ValidatePayment(paymentRequest, debtorAccount);
        }

        /// <summary>
        /// Return validation strategy based on payment type.
        /// If in the future a new payment scheme is available, derive from this class and override this method.
        /// </summary>
        /// <param name="paymentScheme"></param>
        /// <returns>IPaymentValidationStrategy</returns>
        /// <exception cref="ApplicationException"></exception>
        public virtual IPaymentValidationStrategy GetValidationStrategy(PaymentScheme paymentScheme)
        {
            switch (paymentScheme)
            {
                case PaymentScheme.FasterPayments:
                    return new PaymentValidationStrategyFasterPayment();
                case PaymentScheme.Bacs:
                    return new PaymentValidationStrategyBacs();
                case PaymentScheme.Chaps:
                    return new PaymentValidationStrategyChaps();
            }
            throw new ApplicationException("Invalid payment scheme");
        }
    }
}
