using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public class GSCommandCreator
    {
        private readonly string programName;
        internal GSCommandCreator(string programName) => this.programName = programName;

        public GSCommandEvent CreateGSCommandEvent()
        {
            return new GSCommandEvent(programName);
        }
        public GSCommandRegisterEvent CreateGSCommandRegisterEvent()
        {
            return new GSCommandRegisterEvent(programName);
        }
        public GSCommandRegisterProgram CreateGSCommandRegisterProgram()
        {
            return new GSCommandRegisterProgram(programName);
        }
        public GSCommandUnregisterEvent CreateGSCommandUnregisterEvent()
        {
            return new GSCommandUnregisterEvent(programName);
        }
        public GSCommandUnregisterProgram CreateGSCommandUnregisterProgram()
        {
            return new GSCommandUnregisterProgram(programName);
        }
        public GSCommandBindEvent CreateGSCommandBindEvent()
        {
            return new GSCommandBindEvent(programName);
        }
    }
}
