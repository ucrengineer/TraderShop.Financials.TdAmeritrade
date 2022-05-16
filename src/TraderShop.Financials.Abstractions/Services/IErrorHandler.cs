namespace TraderShop.Financials.Abstractions.Services
{
    public interface IErrorHandler
    {
        /// <summary>
        /// check for errors in service actions that use http GET
        /// </summary>
        /// <param name="httpResponseMessage"></param>
        /// <returns></returns>
        Task CheckQueryErrorsAsync(HttpResponseMessage httpResponseMessage);
        /// <summary>
        /// check for errors in service actions that use http POST, PUT
        /// </summary>
        /// <param name="httpResponseMessage"></param>
        /// <returns></returns>
        Task CheckCommandErrorsAsync(HttpResponseMessage httpResponseMessage);
        void CheckForNullOrEmpty(string[] mandatoryString, string[]? name = null);

    }
}
