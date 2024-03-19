using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Tests
{
    public class FakeDataStore : IAccountDataStore
    {
        public IDictionary<string, Account> store = new Dictionary<string, Account>();

        public bool UpdateHasBeenInvoked { get; set; }

        public Account GetAccount(string accountNumber)
        {
            if (store.Keys.Contains(accountNumber))
            {
                return store[accountNumber];
            }
            else
            {
                //create dummy account
                var newAccount = new Account { AccountNumber = accountNumber, AllowedPaymentSchemes = PaymentScheme.FasterPayments, Balance = 100, Status = AccountStatus.Live };
                store[accountNumber] = newAccount;
                return newAccount;
            }
        }

        public void UpdateAccount(Account account)
        {
            UpdateHasBeenInvoked = true;
        }
    }
}
