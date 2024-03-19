using Melior.InterviewQuestion.Services.PaymentRequestValidator;
using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Tests
{
    public class TestPaymentRequestValidator
    {
        PaymentRequestValidator paymentRequestValidator;

        [SetUp]
        public void Setup()
        {
            paymentRequestValidator = new PaymentRequestValidator();
        }


        [Test]
        public void TestThatTheCorrectValidationStrategyIsReturnedBasedOnPaymentScheme()
        {
            Assert.That(paymentRequestValidator.GetValidationStrategy(PaymentScheme.FasterPayments), Is.InstanceOf<PaymentValidationStrategyFasterPayment>());
            Assert.That(paymentRequestValidator.GetValidationStrategy(PaymentScheme.Bacs), Is.InstanceOf<PaymentValidationStrategyBacs>());
            Assert.That(paymentRequestValidator.GetValidationStrategy(PaymentScheme.Chaps), Is.InstanceOf<PaymentValidationStrategyChaps>());

        }
    }
}
