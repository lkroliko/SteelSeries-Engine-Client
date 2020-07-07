using System.Text;
using System.Threading;
using GameSenseClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GameSenseClientTest
{
    [TestClass]
    public class GSClientTest
    {
        readonly string _programName = "TESTPROGRAM";
        readonly string _displayName = "Test porgram";
        readonly string _developerName = "lkroliko";
        readonly string _eventName = "TESTEVENT";
        GSClient _client;

        public GSClientTest()
        {
            _client = new GSClient(_programName);
        }

        [TestMethod]
        public void DisplayEvent()
        {
            Assert.IsTrue(_client.SendCommand(builder => builder.Program.Register(_developerName, _displayName)));

            Assert.IsTrue(_client.SendCommand(builder => builder.Event.Register(_eventName)));

            int value = 0;
            for (int i = 0; i < 200; i++)
            {
                Assert.IsTrue(_client.SendCommand(builder => builder.Event.Fire(_eventName, value)));
                Thread.Sleep(10);

                value++;
                if (value == 101)
                    value = 0;
            }
        }

        [TestMethod]
        public void RegisterProgram()
        {
            Assert.IsTrue(_client.SendCommand(builder => builder.Program.Register(_developerName, _displayName)));
        }

        [TestMethod]
        public void UnregisterProgram()
        {
            Assert.IsTrue(_client.SendCommand(builder => builder.Program.Unregister()));
        }

        [TestMethod]
        public void RegisterEvent()
        {
            Assert.IsTrue(_client.SendCommand(builder=> builder.Event.Register(_eventName)));
        }

        [TestMethod]
        public void UnegisterEvent()
        {
            Assert.IsTrue(_client.SendCommand(builder => builder.Event.Unregister(_eventName)));
        }

        [TestMethod]
        public void Event()
        {
            Assert.IsTrue(_client.SendCommand(builder => builder.Event.Fire(_eventName, 0)));
        }

    }
}
