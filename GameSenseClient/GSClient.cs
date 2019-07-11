using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public class GSClient
    {
        public GSConnector GSConnector { get; }
        public GSCommandCreator GSCommandCreator { get; }

        public GSClient(bool useEncryption, string programName)
        {
            GSConnector = new GSConnector(useEncryption);
            GSCommandCreator = new GSCommandCreator(programName);
        }

        public bool RegisterProgram(string displayName, string developerName)
        {
            GSCommandRegisterProgram gSCommandRegisterProgram = GSCommandCreator.CreateGSCommandRegisterProgram();
            gSCommandRegisterProgram.DisplayName = displayName;
            gSCommandRegisterProgram.DeveloperName = developerName;
            return GSConnector.SendCommand(gSCommandRegisterProgram);
        }

        public bool UnregisterProgram()
        {
            GSCommandUnregisterProgram gSCommandUnregisterProgram = GSCommandCreator.CreateGSCommandUnregisterProgram();
            return GSConnector.SendCommand(gSCommandUnregisterProgram);
        }

        public bool UnregisterEvent(string name)
        {
            GSCommandUnregisterEvent gSCommandUnregisterEvent = GSCommandCreator.CreateGSCommandUnregisterEvent();
            gSCommandUnregisterEvent.Name = name;
            return GSConnector.SendCommand(gSCommandUnregisterEvent);
        }
    }
}
