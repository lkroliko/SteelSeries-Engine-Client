using System.Text;
using System.Threading;
using GameSenseClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class GameSenseClientTest
    {
        string programName = "TESTPROGRAM";
        string programDisplayName = "Test porgram";
        string developerName = "lkroliko";
        string eventName = "TESTEVENT";

        [TestMethod]
        public void ReadConfig()
        {
            GSConfig gameSenseConfigTest = new GSConfig(false);
            Assert.IsTrue(gameSenseConfigTest.Address == "127.0.0.1" && gameSenseConfigTest.EncryptedAddress == "127.0.0.1");
            Assert.IsTrue(gameSenseConfigTest.Port > 0 && gameSenseConfigTest.EncryptedPort > 0);
        }

        [TestMethod]
        public void DisplayEvent()
        {
            GSClient gSClient = new GSClient(false, programName);

            Assert.IsTrue(gSClient.RegisterProgram(programDisplayName, developerName));

            GSCommandRegisterEvent gSCommandRegisterEvent = gSClient.GSCommandCreator.CreateGSCommandRegisterEvent();
            gSCommandRegisterEvent.Name = eventName;
            gSCommandRegisterEvent.MinValue = 0;
            gSCommandRegisterEvent.MaxValue = 100;
            Assert.IsTrue(gSClient.GSConnector.SendCommand(gSCommandRegisterEvent));

            GSCommandEvent gSCommandEvent = gSClient.GSCommandCreator.CreateGSCommandEvent();
            gSCommandEvent.Name = eventName;
            Assert.IsTrue(gSClient.GSConnector.SendCommand(gSCommandEvent));

            int value = 0;
            for(int i = 0; i < 500; i++)
            {
                gSCommandEvent.Data.Value = i;
                Assert.IsTrue(gSClient.GSConnector.SendCommand(gSCommandEvent));
                Thread.Sleep(100);

                value++;
                if (value == 101)
                    value = 0;
            }
        }

        [TestMethod]
        public void RegisterProgram()
        {
            GSClient gSClient = new GSClient(false, programName);

            Assert.IsTrue(gSClient.RegisterProgram(programDisplayName, developerName));
        }

        [TestMethod]
        public void UnregisterProgram()
        {
            GSClient gSClient = new GSClient(false, programName);

            Assert.IsTrue(gSClient.UnregisterProgram());
        }

        [TestMethod]
        public void RegisterEvent()
        {
            GSClient gSClient = new GSClient(false, programName);

            GSCommandRegisterEvent gSCommandRegisterEvent = gSClient.GSCommandCreator.CreateGSCommandRegisterEvent();
            gSCommandRegisterEvent.Name = eventName;
            gSCommandRegisterEvent.MinValue = 0;
            gSCommandRegisterEvent.MaxValue = 100;
            Assert.IsTrue(gSClient.GSConnector.SendCommand(gSCommandRegisterEvent));
        }

        [TestMethod]
        public void UnegisterEvent()
        {
            GSClient gSClient = new GSClient(false, programName);
            GSCommandUnregisterEvent gSCommandUnregisterEvent = gSClient.GSCommandCreator.CreateGSCommandUnregisterEvent();
            gSCommandUnregisterEvent.Name = eventName;
            Assert.IsTrue(gSClient.GSConnector.SendCommand(gSCommandUnregisterEvent));
        }

        [TestMethod]
        public void Event()
        {
            GSClient gSClient = new GSClient(false, programName);
            GSCommandEvent gSCommandEvent = gSClient.GSCommandCreator.CreateGSCommandEvent();
            gSCommandEvent.Name = eventName;
            Assert.IsTrue(gSClient.GSConnector.SendCommand(gSCommandEvent));
        }

    }
}
