using GameSenseClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace UnitTest
{
    [TestClass]
    public class HandlerTest
    {
        readonly string programName = "HANDLERTEST";
        readonly GSEventMode mode = GSEventMode.Percent;
        readonly GSDeviceZone zone = GSDeviceZone.RgbZonedDevice_Twenty;
        readonly int sleep = 50;

        readonly GSStaticColor red = new GSStaticColor() { R = 255 };
        readonly GSStaticColor blue = new GSStaticColor() { B = 255 };
        readonly GSStaticColor green = new GSStaticColor() { G = 255 };
        readonly GSGradientColor redBlue;
        readonly GSGradientColor blueGreen;
        readonly GSCommandBindEvent gSCommandBindEvent;
        readonly GSCommandEvent gSCommandEvent;
        readonly GSClient gSClient;
        readonly GSHandler gSHandler;

        public HandlerTest()
        {
            redBlue = new GSGradientColor() { From = red, To = blue };
            blueGreen = new GSGradientColor() { From = blue, To = green };

            gSClient = new GSClient(false, programName);
            gSClient.UnregisterProgram();

            gSHandler = new GSHandler() { Mode = mode, Zone = zone };
            gSCommandBindEvent = gSClient.GSCommandCreator.CreateGSCommandBindEvent();
            gSCommandBindEvent.Handlers.Add(gSHandler);

            gSCommandEvent = gSClient.GSCommandCreator.CreateGSCommandEvent();
        }

        [TestMethod]
        public void StaticColor()
        {
            string eventName = "STATICCOLOR";

            gSClient.UnregisterEvent(eventName);

            gSHandler.Colors.Add(red);

            gSCommandBindEvent.Name = eventName;

            Assert.IsTrue(gSClient.GSConnector.SendCommand(gSCommandBindEvent));

            gSCommandEvent.Name = eventName;

            int i = 0;
            while (true)
            {
                gSCommandEvent.Data.Value = i;
                gSClient.GSConnector.SendCommand(gSCommandEvent);

                Thread.Sleep(sleep);
                i++;
                if (i == 101)
                    i = 0;
            }
        }

        [TestMethod]
        public void GradientColor()
        {
            string eventName = "GRADIENTCOLOR";

            gSClient.UnregisterEvent(eventName);

            gSHandler.Colors.Add(redBlue);

            gSCommandBindEvent.Name = eventName;
            gSCommandBindEvent.Handlers.Add(gSHandler);

            Assert.IsTrue(gSClient.GSConnector.SendCommand(gSCommandBindEvent));

            gSCommandEvent.Name = eventName;

            int i = 0;
            while (true)
            {
                gSCommandEvent.Data.Value = i;
                gSClient.GSConnector.SendCommand(gSCommandEvent);

                Thread.Sleep(50);
                i++;
                if (i == 101)
                    i = 0;
            }
        }

        [TestMethod]
        public void RangeGradientColor()
        {
            string eventName = "RANGEGRADIENTCOLOR";

            gSClient.UnregisterEvent(eventName);

            GSRangeColor range1 = new GSRangeColor() { Low = 0, High = 49, Color = red };
            GSRangeColor range2 = new GSRangeColor() { Low = 50, High = 100, Color = blueGreen };

            gSHandler.Colors.Add(range1);
            gSHandler.Colors.Add(range2);

            gSCommandBindEvent.Name = eventName;
            gSCommandBindEvent.Handlers.Add(gSHandler);

            Assert.IsTrue(gSClient.GSConnector.SendCommand(gSCommandBindEvent));

            gSCommandEvent.Name = eventName;

            int i = 0;
            while (true)
            {
                gSCommandEvent.Data.Value = i;
                gSClient.GSConnector.SendCommand(gSCommandEvent);

                Thread.Sleep(50);
                i++;
                if (i == 101)
                    i = 0;
            }
        }

        [TestMethod]
        public void RangeStaticColor()
        {
            string eventName = "RANGESTATICCOLOR";

            gSClient.UnregisterEvent(eventName);

            GSCommandBindEvent gSCommandBindEvent = gSClient.GSCommandCreator.CreateGSCommandBindEvent();
            GSHandler gSHandler = new GSHandler() { Mode = GSEventMode.Color, Zone = GSDeviceZone.RgbZonedDevice_One };

            GSRangeColor range1 = new GSRangeColor() { Low = 0, High = 33, Color = red };
            GSRangeColor range2 = new GSRangeColor() { Low = 34, High = 66, Color = green };
            GSRangeColor range3 = new GSRangeColor() { Low = 67, High = 100, Color = blue };

            gSHandler.Colors.Add(range1);
            gSHandler.Colors.Add(range2);
            gSHandler.Colors.Add(range3);

            gSCommandBindEvent.Name = eventName;
            gSCommandBindEvent.Handlers.Add(gSHandler);

            Assert.IsTrue(gSClient.GSConnector.SendCommand(gSCommandBindEvent));

            GSCommandEvent gSCommandEvent = gSClient.GSCommandCreator.CreateGSCommandEvent();
            gSCommandEvent.Name = eventName;

            int i = 0;
            while (true)
            {
                gSCommandEvent.Data.Value = i;
                gSClient.GSConnector.SendCommand(gSCommandEvent);

                Thread.Sleep(50);
                i++;
                if (i == 101)
                    i = 0;
            }
        }
    }
}
