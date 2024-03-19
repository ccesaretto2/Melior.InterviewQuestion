using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Services.PaymentRequestValidator;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services
{
    public class PaymentService : IPaymentService
    {
        private IAccountDataStoreLoader accountDataLoader;
        private IPaymentRequestValidator paymentValidator;
        private IPaymentProcessor paymentProcessor;
        public PaymentService(IAccountDataStoreLoader accountDataLoader, IPaymentRequestValidator paymentValidator, IPaymentProcessor paymentProcessor)
        {
            this.accountDataLoader = accountDataLoader;
            this.paymentValidator = paymentValidator;
            this.paymentProcessor = paymentProcessor;
        }
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var accountDataStore = accountDataLoader.GetCurrentAccountDataStore();

            Account debtorAccount = accountDataStore.GetAccount(request.DebtorAccountNumber);

            if (paymentValidator.IsPaymentRequestValid(request, debtorAccount))
            {
                paymentProcessor.MakePayment(accountDataStore, debtorAccount, request.Amount);
                return new MakePaymentResult() { Success = true };
            }
            else
            {
                return new MakePaymentResult() { Success=false };
            }
        }
    }
}
