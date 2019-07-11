using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public abstract class GSCommand
    {
        public static explicit operator GSCommandType(GSCommand gSCommand)
        {
            if (gSCommand is GSCommandEvent)
                return GSCommandType.Event;
            if (gSCommand is GSCommandRegisterEvent)
                return GSCommandType.RegisterEvent;
            if (gSCommand is GSCommandRegisterProgram)
                return GSCommandType.RegisterProgram;
            if (gSCommand is GSCommandUnregisterEvent)
                return GSCommandType.UnregisterEvent;
            if (gSCommand is GSCommandUnregisterProgram)
                return GSCommandType.UnregisterProgram;
            if (gSCommand is GSCommandBindEvent)
                return GSCommandType.BindEvent;
            throw new NotImplementedException();
        }

        public string GetCommand()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
