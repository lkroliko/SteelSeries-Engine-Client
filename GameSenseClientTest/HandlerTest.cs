using GameSenseClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace GameSenseClientTest
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
        readonly GSClient gSClient;
        GSHandler _gSHandler;

        public HandlerTest()
        {
            redBlue = new GSGradientColor() { From = red, To = blue };
            blueGreen = new GSGradientColor() { From = blue, To = green };

            gSClient = new GSClient(programName);
            //gSClient.SendCommand(builder => builder.Program.Unregister());

            _gSHandler = new GSHandler() { Mode = mode, Zone = zone };

        }

        private void Loop(string eventName)
        {
            int i = 0;
            while (true)
            {
                gSClient.SendCommand(builder => GSCommandBuilder.New.Event.Fire(eventName, i));

                Thread.Sleep(sleep);
                i++;
                if (i == 101)
                    i = 0;
            }
        }

        private void Prepare(string eventName, GSHandler gSHandler)
        {
            gSClient.SendCommand(builder => builder.Event.Unregister(eventName));

            gSClient.SendCommand(builder =>
                builder.Event.Bind(eventName)
                .AddHandler(gSHandler)
            );
        }

        [TestMethod]
        public void StaticColor()
        {
            string eventName = "STATICCOLOR";
            _gSHandler.Colors.Add(red);

            Prepare(eventName, _gSHandler);
            Loop(eventName);
        }

        [TestMethod]
        public void GradientColor()
        {
            string eventName = "GRADIENTCOLOR";
            _gSHandler.Colors.Add(redBlue);

            Prepare(eventName, _gSHandler);
            Loop(eventName);
        }

        [TestMethod]
        public void RangeGradientColor()
        {
            string eventName = "RANGEGRADIENTCOLOR";
            GSRangeColor range1 = new GSRangeColor() { Low = 0, High = 49, Color = red };
            GSRangeColor range2 = new GSRangeColor() { Low = 50, High = 100, Color = blueGreen };

            _gSHandler.Colors.Add(range1);
            _gSHandler.Colors.Add(range2);

            Prepare(eventName, _gSHandler);
            Loop(eventName);
        }

        [TestMethod]
        public void RangeStaticColor()
        {
            string eventName = "RANGESTATICCOLOR";

            _gSHandler = new GSHandler() { Mode = GSEventMode.Color, Zone = GSDeviceZone.RgbZonedDevice_One };

            GSRangeColor range1 = new GSRangeColor() { Low = 0, High = 33, Color = red };
            GSRangeColor range2 = new GSRangeColor() { Low = 34, High = 66, Color = green };
            GSRangeColor range3 = new GSRangeColor() { Low = 67, High = 100, Color = blue };

            _gSHandler.Colors.AddRange(new []{ range1, range2, range3});

            Prepare(eventName, _gSHandler);
            Loop(eventName);
        }
    }
}
