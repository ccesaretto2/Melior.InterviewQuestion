using Melior.InterviewQuestion.Services.PaymentRequestValidator;
using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Tests
{
    public class TestPaymentRequestValidationStrategies
    {
        //the following test verify the validation of FasterPayments transfers.
        //Similar tests can be written for the other payment schemes.

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFasterPaymentValidationFailsIfBalanceNotEnough()
        {
            MakePaymentRequest paymentRequest = new MakePaymentRequest { PaymentScheme = PaymentScheme.FasterPayments, Amount = 100 };
            Account debtorAccout = new Account { AllowedPaymentSchemes = PaymentScheme.FasterPayments, Balance = 50 };
            IPaymentValidationStrategy validationStrategy = new PaymentValidationStrategyFasterPayment();

            Assert.That(validationStrategy.ValidatePayment(paymentRequest, debtorAccout), Is.False);
        }

        [Test]
        public void TestFasterPaymentValidationFailsIfPaymentSchemeIsNotAllowed()
        {
            MakePaymentRequest paymentRequest = new MakePaymentRequest { PaymentScheme = PaymentScheme.FasterPayments, Amount = 100 };
            Account debtorAccout = new Account { AllowedPaymentSchemes = PaymentScheme.Bacs, Balance = 100 };
            IPaymentValidationStrategy validationStrategy = new PaymentValidationStrategyFasterPayment();

            Assert.That(validationStrategy.ValidatePayment(paymentRequest, debtorAccout), Is.False);
        }

        [Test]
        public void TestFasterPaymentValidationFailsIfDebtorAccountIsNull()
        {
            MakePaymentRequest paymentRequest = new MakePaymentRequest { PaymentScheme = PaymentScheme.FasterPayments, Amount = 100 };
            Account debtorAccout = null;
            IPaymentValidationStrategy validationStrategy = new PaymentValidationStrategyFasterPayment();

            Assert.That(validationStrategy.ValidatePayment(paymentRequest, debtorAccout), Is.False);
        }

        [Test]
        public void TestFasterPaymentValidationPass()
        {
            MakePaymentRequest paymentRequest = new MakePaymentRequest { PaymentScheme = PaymentScheme.FasterPayments, Amount = 100 };
            Account debtorAccout = new Account { AllowedPaymentSchemes = PaymentScheme.FasterPayments, Balance = 100 };
            IPaymentValidationStrategy validationStrategy = new PaymentValidationStrategyFasterPayment();

            Assert.That(validationStrategy.ValidatePayment(paymentRequest, debtorAccout), Is.True);
        }
    }
}
