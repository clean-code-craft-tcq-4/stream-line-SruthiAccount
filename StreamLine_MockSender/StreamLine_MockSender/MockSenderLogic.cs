using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLine_MockSender
{
    public class MockSenderLogic
    {
        public struct SensorParameters
        {
            public List<string> Temperature;
            public List<string> StateOfCharge;

        }

        public string fileName { get; set; }

        public Tuple<List<string>, List<string>> GetSensorReadings()
        {
            SensorParameters sensorParameters = new SensorParameters();

            sensorParameters = GetReadingsFromRandomArray();

            return Tuple.Create(sensorParameters.Temperature, sensorParameters.StateOfCharge);
        }


        public SensorParameters GetReadingsFromRandomArray()
        {
            SensorParameters sensorParameters = new SensorParameters();
            Random random = new Random();

            sensorParameters.Temperature = new List<string>();
            sensorParameters.StateOfCharge = new List<string>();

            sensorParameters.Temperature.Add("Temperature");
            sensorParameters.StateOfCharge.Add("StateOfCharge");


            int i = 0;
            while (i < 50)
            {
                sensorParameters.Temperature.Add((random.Next(10, 45)).ToString());
                sensorParameters.StateOfCharge.Add((random.Next(20, 80)).ToString());
                i++;
            }

            return sensorParameters;

        }
    }
}
