using GameSenseClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameSenseClientTest
{
    [TestClass]
    public class GSCommandTest
    {
        readonly string programName = "TESTPROGRAM";
        readonly GSClient gSClient;

        public GSCommandTest()
        {
            gSClient = new GSClient(false,programName);
        }

        [TestMethod]
        public void RegisterProgram()
        {
            string displayName = "Test_program";
            string developerName = "Test_developer";
            string pattern;

            GSCommandRegisterProgram command = gSClient.GSCommandCreator.CreateGSCommandRegisterProgram();

            pattern = $"{{\"game\":\"{programName}\"}}";
            Assert.IsTrue(TestCommand(command, pattern));

            command.DisplayName = displayName;
            pattern = $"{{\"game\":\"{programName}\",\"game_display_name\":\"{displayName}\"}}";
            Assert.IsTrue(TestCommand(command, pattern));

            command.DeveloperName = developerName;
            pattern = $"{{\"game\":\"{programName}\",\"game_display_name\":\"{displayName}\",\"developer\":\"{developerName}\"}}";
            Assert.IsTrue(TestCommand(command, pattern));
        }

        [TestMethod]
        public void UnegisterProgram()
        {
            GSCommandUnregisterProgram command = gSClient.GSCommandCreator.CreateGSCommandUnregisterProgram();
            Assert.IsTrue(TestCommand(command, $"{{\"game\":\"{programName}\"}}"));
        }

        private bool TestCommand(GSCommand gSCommand, string pattern)
        {
            string command = gSCommand.GetCommand();
            command = RemoveWhitespaces(command);
            return Regex.Match(command, pattern).Success;
        }

        private string RemoveWhitespaces(string value)
        {
            return Regex.Replace(value, @"\s+", "");
        }
    }
}
