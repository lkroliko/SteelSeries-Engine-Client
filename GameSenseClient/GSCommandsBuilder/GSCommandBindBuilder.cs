using GameSenseClient.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public class GSCommandBindBuilder
    {
        GSCommandBindEvent _command;
        internal GSCommandBindBuilder(GSCommandBindEvent command) => _command = command;

        public IGSCommand AddHandler(GSHandler handler)
        {
            _command.Handlers.Add(handler);
            return _command;
        }

        public IGSCommand AddHandlers(IEnumerable<GSHandler> handlers)
        {
            _command.Handlers.AddRange(handlers);
            return _command;
        }
    }
}
