using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace GameSenseClient
{
    class GSConnector
    {
        private readonly GSConfig _config;
        private readonly HttpClient _httpClient = new HttpClient();
        internal string LastResult { get; private set; }
        internal GSConnector(bool useEncryption)
        {
            _config = new GSConfig(useEncryption);
        }

        /// <returns>IsSended</returns>
        internal bool SendCommand(IGSCommand command)
        {
            Uri commandUri = GetCommandUri(command);
            StringContent stringContent = GetCommandContent(command);
            HttpResponseMessage result = _httpClient.PostAsync(commandUri, stringContent).Result;

            if (result.StatusCode == HttpStatusCode.OK)
                return true;

            LastResult = result.Content.ReadAsStringAsync().Result;

            return false;
        }

        private StringContent GetCommandContent(IGSCommand command)
        {
            return new StringContent(command.GetCommand(), Encoding.UTF8, "application/json");
        }

        private Uri GetCommandUri(IGSCommand command)
        {
            return new Uri($"http://{_config.Address}/{command.Uri}");
        }
    }
}
