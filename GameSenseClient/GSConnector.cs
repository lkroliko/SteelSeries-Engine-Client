using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public class GSConnector
    {
        private GSConfig gSConfig;
        private HttpClient httpClient = new HttpClient();
        public string LastResult { get; private set; }
        internal GSConnector(bool useEncryption)
        {
            gSConfig = new GSConfig(useEncryption);
        }
        
        /// <returns>IsSended</returns>
        public bool SendCommand(GSCommand gSCommand)
        {
            Uri commandUri = GetCommandUri(gSCommand);
            StringContent stringContent = GetCommandContent(gSCommand);
            HttpResponseMessage result = httpClient.PostAsync(commandUri, stringContent).Result;
            
            if (result.StatusCode == HttpStatusCode.OK)
                return true;

            LastResult = result.Content.ReadAsStringAsync().Result;

            return false;
        }

        private StringContent GetCommandContent(GSCommand gSCommand)
        { 
            return new StringContent(gSCommand.GetCommand(), Encoding.UTF8, "application/json");
        }

        private Uri GetCommandUri(GSCommand gSCommand)
        {
            switch ((GSCommandType)gSCommand)
            {
                case GSCommandType.Event:
                    return gSConfig.EventUri;
                case GSCommandType.RegisterEvent:
                    return gSConfig.RegisterEventUri;
                case GSCommandType.RegisterProgram:
                    return gSConfig.RegisterProgramUri;
                case GSCommandType.UnregisterEvent:
                    return gSConfig.UnregisterEventUri;
                case GSCommandType.UnregisterProgram:
                    return gSConfig.UnregisterProgramUri;
                case GSCommandType.BindEvent:
                    return gSConfig.BindEventUri;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
