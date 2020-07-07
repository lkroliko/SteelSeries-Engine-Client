using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    class GSConfig
    {
        string _address;
        int _port;
        string _encryptedAddress;
        int _encryptedPort;
        bool _useEncryption;
        internal string Address { get => GetAddress(); }

        internal GSConfig(bool useEncryption)
        {
            _useEncryption = useEncryption;
            string configContent = ReadConfigFile();
            ParseConfig(configContent);
        }

        private string ReadConfigFile()
        {
            string file = GetConfigFilePath();
            if (!File.Exists(file))
                throw new FileNotFoundException($"SteelSeries Engine 3 is not running. File not found {file}");

            return File.ReadAllText(file);
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

            _address = tmpAddress[0];
            _port = int.Parse(tmpAddress[1]);
            _encryptedAddress = tmpEncryptedAddress[0];
            _encryptedPort = int.Parse(tmpEncryptedAddress[1]);
        }

        private string GetAddress()
        {
            if (_useEncryption)
                return $"{_encryptedAddress}:{_encryptedPort}";
            else
                return $"{_address}:{_port}";
        }
    }
}
