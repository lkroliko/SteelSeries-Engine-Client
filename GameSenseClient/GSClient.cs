using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameSenseClient
{
    public class GSClient
    {
        string _programName;
        GSConnector _connector;
        
        public GSClient(string programName, bool useEncryption = false)
        {
            _programName = programName;
            _connector = new GSConnector(useEncryption);
        }

        public bool SendCommand(Func<GSCommandBuilder,IGSCommand> builder)
        {
            IGSCommand command = builder.Invoke(new GSCommandBuilder());
            command.ProgramName = _programName;
            return _connector.SendCommand(command);
        }

        public bool SendCommand(Func<IGSCommand> builder)
        {
            IGSCommand command = builder.Invoke();
            command.ProgramName = _programName;
            return _connector.SendCommand(command);
        }

        public bool SendCommand(IGSCommand command)
        {
            command.ProgramName = _programName;
            return _connector.SendCommand(command);
        }
    }
}
