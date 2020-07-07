using GameSenseClient.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public class GSCommandEventBuilder
    {
        public GSCommandBindBuilder Bind(string name, int minValue =0, int maxValue = 100)
        {
            GSCommandBindEvent command = new GSCommandBindEvent()
            { 
                Name = name,
                MinimumValue = minValue,
                MaximumValue = maxValue 
            };
            return new GSCommandBindBuilder(command);
        }

        public IGSCommand Fire(string name, int value = 0)
        {
            return new GSCommandEvent(value)
            {
                Name = name
            };
        }

        public IGSCommand Register(string name, int minValue =0, int maxValue = 100, int iconId = 0, bool valueOptional = false)
        {
            return new GSCommandRegisterEvent()
            {
                Name = name,
                MinValue = minValue,
                MaxValue = maxValue,
                IconId = iconId,
                ValueOptional = valueOptional
            };
        }

        public IGSCommand Unregister(string name)
        {
            return new GSCommandUnregisterEvent()
            {
                Name = name
            };
        }
    }
}
