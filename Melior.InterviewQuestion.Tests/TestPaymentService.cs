using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Services;
using Melior.InterviewQuestion.Services.PaymentRequestValidator;
using Melior.InterviewQuestion.Types;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Tests
{
    public class TestPaymentServiceEndToEnd
    {
        Mock<IAccountDataStoreLoader> mockAccountDataStoreLoader;
        Mock<IPaymentRequestValidator> mockPaymentRequestValidatorThatAlwaysFails;
        Mock<IPaymentRequestValidator> mockPaymentRequestValidatorThatAlwaysSucceeds;

        IPaymentProcessor paymentProcessor = new PaymentProcessor();

        [SetUp]
        public void Setup()
        {
            mockAccountDataStoreLoader = new Mock<IAccountDataStoreLoader>(MockBehavior.Strict);
            mockAccountDataStoreLoader.Setup(ds => ds.GetCurrentAccountDataStore())
                .Returns(new FakeDataStore());

            mockPaymentRequestValidatorThatAlwaysFails = new Mock<IPaymentRequestValidator>(MockBehavior.Strict);
            mockPaymentRequestValidatorThatAlwaysFails.Setup(v => v.IsPaymentRequestValid(It.IsAny<MakePaymentRequest>(), It.IsAny<Account>())).Returns(false);

            mockPaymentRequestValidatorThatAlwaysSucceeds = new Mock<IPaymentRequestValidator>(MockBehavior.Strict);
            mockPaymentRequestValidatorThatAlwaysSucceeds.Setup(v => v.IsPaymentRequestValid(It.IsAny<MakePaymentRequest>(), It.IsAny<Account>())).Returns(true);

        }

        [Test]
        public void TestAccountBalanceIsUpdatedIfTransactionSuccessful()
        {
            MakePaymentRequest paymentRequest = new MakePaymentRequest
            {
                CreditorAccountNumber = "ID1",
                DebtorAccountNumber = "ID2",
                Amount = 10,
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.FasterPayments
            };

            var originalBalance = mockAccountDataStoreLoader.Object.GetCurrentAccountDataStore().GetAccount(paymentRequest.DebtorAccountNumber).Balance;

            IPaymentService paymentService = new PaymentService(mockAccountDataStoreLoader.Object, mockPaymentRequestValidatorThatAlwaysSucceeds.Object, paymentProcessor);
            var result = paymentService.MakePayment(paymentRequest);
            var finalBalance = mockAccountDataStoreLoader.Object.GetCurrentAccountDataStore().GetAccount(paymentRequest.DebtorAccountNumber).Balance;

            Assert.That(result.Success, Is.True);
            Assert.That(finalBalance, Is.EqualTo(originalBalance - paymentRequest.Amount));

        }

        [Test]
        public void TestAccountBalanceIsNotUpdatedIfTransactionFails()
        {
            MakePaymentRequest paymentRequest = new MakePaymentRequest
            {
                CreditorAccountNumber = "ID1",
                DebtorAccountNumber = "ID2",
                Amount = 10,
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.FasterPayments
            };

            var originalBalance = mockAccountDataStoreLoader.Object.GetCurrentAccountDataStore().GetAccount(paymentRequest.DebtorAccountNumber).Balance;

            IPaymentService paymentService = new PaymentService(mockAccountDataStoreLoader.Object, mockPaymentRequestValidatorThatAlwaysFails.Object, paymentProcessor);
            var result = paymentService.MakePayment(paymentRequest);
            var finalBalance = mockAccountDataStoreLoader.Object.GetCurrentAccountDataStore().GetAccount(paymentRequest.DebtorAccountNumber).Balance;

            Assert.That(result.Success, Is.False);
            Assert.That(finalBalance, Is.EqualTo(originalBalance));

        }
    }
}
