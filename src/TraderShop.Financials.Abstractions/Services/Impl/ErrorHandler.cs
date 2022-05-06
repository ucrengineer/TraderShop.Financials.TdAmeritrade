namespace TraderShop.Financials.Abstractions.Services.Impl
{
    public class ErrorHandler : IErrorHandler
    {
        public async Task CheckForErrorsAsync(HttpResponseMessage httpResponseMessage)
        {
            var responseObject = await httpResponseMessage.Content.ReadAsStringAsync();

            if (httpResponseMessage.IsSuccessStatusCode && !responseObject.Any())
            {
                if (httpResponseMessage?.RequestMessage?.Method == HttpMethod.Post)
                {
                    return;
                }

                throw new Exception($"Http Code : {httpResponseMessage?.StatusCode} but no content is returned");
            }
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseObject);
            }
        }

        public void CheckForNullOrEmpty(string[] mandatoryStrings)
        {
            for (var i = 0; i < mandatoryStrings.Length; i++)
            {
                if (!mandatoryStrings[i].Any())
                {
                    throw new Exception($"String input cannot be null or empty");
                }
            }
        }
    }
}
