using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLine_MockSender
{
    class Mocksender
    {
        static void Main(string[] args)
        {
            MockSenderLogic mockSenderlogic = new MockSenderLogic();

            List<string> Temperature = new List<string>();
            List<string> StateOfCharge = new List<string>();

            var data = mockSenderlogic.GetSensorReadings();


            foreach (var i in (data.Item1)) Temperature.Add(i);
            foreach (var i in (data.Item2)) StateOfCharge.Add(i);

            for (int k = 0; k < data.Item1.Count; k++)
            {
                string BMS_Sender = $"{Temperature[k]}--{StateOfCharge[k]}";
                Console.WriteLine(BMS_Sender);
            }
        }
    }
}

