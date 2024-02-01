using DCR.ViewModel.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IPaymentRepos
    {
        Task<IEnumerable<object>> GetPayments();
        Task<object> GetPayment(int Paymentid);
        Task<PaymentViewModel> AddPayment(PaymentViewModel model);

        Task<PaymentViewModel> UpdatePayment(int Paymentid,PaymentViewModel model);
        Task<object> DeletePayment(int Paymentid);
    }
}
