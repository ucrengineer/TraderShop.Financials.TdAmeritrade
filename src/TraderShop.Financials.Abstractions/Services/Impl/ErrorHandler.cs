namespace TraderShop.Financials.Abstractions.Services.Impl
{
    public class ErrorHandler : IErrorHandler
    {
        public async Task CheckQueryErrorsAsync(HttpResponseMessage httpResponseMessage)
        {
            var responseObject = await httpResponseMessage.Content.ReadAsStringAsync();

            if (httpResponseMessage.IsSuccessStatusCode && !responseObject.Any())
            {
                throw new Exception($"Http Code : {httpResponseMessage?.StatusCode} but no content is returned");
            }

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseObject);
            }
        }
        public async Task CheckCommandErrorsAsync(HttpResponseMessage httpResponseMessage)
        {
            var responseObject = await httpResponseMessage.Content.ReadAsStringAsync();

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseObject);
            }
        }
    }
}
