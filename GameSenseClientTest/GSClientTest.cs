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
        readonly string programName = "TESTPROGRAM";
        readonly string displayName = "Test porgram";
        readonly string developerName = "lkroliko";
        readonly string eventName = "TESTEVENT";
        GSClient gSClient;

        public GSClientTest()
        {
            gSClient = new GSClient(programName);
        }

        [TestMethod]
        public void DisplayEvent()
        {
            Assert.IsTrue(gSClient.SendCommand(builder => builder.Program.Register(developerName, displayName)));

            Assert.IsTrue(gSClient.SendCommand(builder => builder.Event.Register(eventName)));

            int value = 0;
            for (int i = 0; i < 200; i++)
            {
                Assert.IsTrue(gSClient.SendCommand(builder => builder.Event.Fire(eventName, value)));
                Thread.Sleep(10);

                value++;
                if (value == 101)
                    value = 0;
            }
        }

        [TestMethod]
        public void RegisterProgram()
        {
            Assert.IsTrue(gSClient.SendCommand(builder => builder.Program.Register(developerName, displayName)));
        }

        [TestMethod]
        public void UnregisterProgram()
        {
            Assert.IsTrue(gSClient.SendCommand(builder => builder.Program.Unregister()));
        }

        [TestMethod]
        public void RegisterEvent()
        {
            Assert.IsTrue(gSClient.SendCommand(builder=> builder.Event.Register(eventName)));
        }

        [TestMethod]
        public void UnegisterEvent()
        {
            Assert.IsTrue(gSClient.SendCommand(builder => builder.Event.Unregister(eventName)));
        }

        [TestMethod]
        public void Event()
        {
            Assert.IsTrue(gSClient.SendCommand(builder => builder.Event.Fire(eventName, 0)));
        }

    }
}
