using GameSenseClient.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public class GSCommandProgramBuilder
    {
        public IGSCommand Register(string developerName, string displayName)
        {
            return new GSCommandRegisterProgram()
            {
                DeveloperName = developerName,
                DisplayName = displayName
            };
        }

        public IGSCommand Unregister()
        {
            return new GSCommandUnregisterProgram();
        }
    }
}
