namespace TraderShop.Financials.Abstractions.Services
{
    public interface IErrorHandler
    {
        Task CheckForErrorsAsync(HttpResponseMessage httpResponseMessage);
        void CheckForNullOrEmpty(string[] mandatoryString, string[]? name = null);
    }
}
