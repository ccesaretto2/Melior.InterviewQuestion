using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services
{
    public class PaymentProcessor : IPaymentProcessor
    {
        public void MakePayment(IAccountDataStore dataStore, Account debtorAccount, decimal amount)
        {
            debtorAccount.Balance -= amount;
            dataStore.UpdateAccount(debtorAccount);
        }
    }
}
