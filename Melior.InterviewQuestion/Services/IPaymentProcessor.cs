using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services
{
    /// <summary>
    /// Moves money between accounts
    /// </summary>
    public interface IPaymentProcessor
    {
        void MakePayment(IAccountDataStore dataStore, Account debtorAccount, decimal amount);
    }
}
