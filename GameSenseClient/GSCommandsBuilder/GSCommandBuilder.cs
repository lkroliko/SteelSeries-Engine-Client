using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public class GSCommandBuilder
    {
        public GSCommandProgramBuilder Program { get => new GSCommandProgramBuilder(); }
        public GSCommandEventBuilder Event { get => new GSCommandEventBuilder(); }

        public static GSCommandBuilder New => new GSCommandBuilder();
    }
}
