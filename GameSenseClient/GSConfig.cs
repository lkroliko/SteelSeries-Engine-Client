using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public class GSConfig
    {
        private string ConfigFilePath { get { return GetConfigFilePath(); } }
        public string Address { get; private set; }
        public int Port { get; private set; }
        public string EncryptedAddress { get; private set; }
        public int EncryptedPort { get; private set; }
        public Uri EventUri { get; private set; }
        public Uri RegisterProgramUri { get; private set; }
        public Uri BindEventUri { get; private set; }
        public Uri RegisterEventUri { get; private set; }
        public Uri UnregisterEventUri { get; private set; }
        public Uri UnregisterProgramUri { get; private set; }

        internal GSConfig(bool useEncryption)
        {
            string configContent = ReadConfigFile();
            ParseConfig(configContent);
            CreateUris(useEncryption);
        }

        private string ReadConfigFile()
        {
            if (!File.Exists(ConfigFilePath))
                throw new FileNotFoundException($"SteelSeries Engine 3 is not running. File not found {ConfigFilePath}");

            return File.ReadAllText(ConfigFilePath);
        }
        private string GetConfigFilePath()
        {
            string programdataPath = Environment.ExpandEnvironmentVariables("%PROGRAMDATA%");
            return $"{programdataPath}/SteelSeries/SteelSeries Engine 3/coreProps.json";
        }
        private void ParseConfig(string configContent)
        {
            dynamic config = JsonConvert.DeserializeObject(configContent);
            string[] tmpAddress = ((string)config.address).Split(':');
            string[] tmpEncryptedAddress = ((string)config.encrypted_address).Split(':');

            Address = tmpAddress[0];
            Port = int.Parse(tmpAddress[1]);
            EncryptedAddress = tmpEncryptedAddress[0];
            EncryptedPort = int.Parse(tmpEncryptedAddress[1]);
        }
        private void CreateUris(bool UseEncryptedAddress)
        {
            string tmpAddress;
            if (UseEncryptedAddress)
                tmpAddress = $"{EncryptedAddress}:{EncryptedPort}";
            else
                tmpAddress = $"{Address}:{Port}";

            EventUri = new Uri($"http://{tmpAddress}/game_event");
            RegisterProgramUri = new Uri($"http://{tmpAddress}/game_metadata");
            BindEventUri = new Uri($"http://{tmpAddress}/bind_game_event");
            RegisterEventUri = new Uri($"http://{tmpAddress}/register_game_event");
            UnregisterEventUri = new Uri($"http://{tmpAddress}/remove_game_event");
            UnregisterProgramUri = new Uri($"http://{tmpAddress}/remove_game");
        }
    }
}
