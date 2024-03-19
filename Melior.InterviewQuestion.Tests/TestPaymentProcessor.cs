using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Services;
using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public class TestPaymentProcessor
    {
        IPaymentProcessor paymentProcess;
        IAccountDataStore accountDataStore;

        [SetUp]
        public void Setup()
        {
            paymentProcess = new PaymentProcessor();
            accountDataStore = new FakeDataStore();
        }

        [Test]
        public void TestPaymentValueIsDeductedFromAccountBalance()
        {
            Account account = accountDataStore.GetAccount("ID1");
            var originalBalance = account.Balance;
            decimal paymentValue = 10;

            paymentProcess.MakePayment(accountDataStore, account, paymentValue);

            Assert.That(account.Balance, Is.EqualTo(originalBalance - paymentValue));
        }

        [Test]
        public void TestThatPaymentProcessUpdatesAccountInDatabase()
        {
            Account account = accountDataStore.GetAccount("ID1");
            decimal paymentValue = 10;

            paymentProcess.MakePayment(accountDataStore, account, paymentValue);

            Assert.That(((FakeDataStore)accountDataStore).UpdateHasBeenInvoked, Is.True);
        }
    }
}
