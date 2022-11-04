using System;
using System.Collections.Generic;
using Xunit;
using StreamLine_Receiver;

namespace StreamLine_Receiver_TestCase
{
    public class UnitTest1
    {
        readonly List<string> SampleConsoleData = new List<string>()
        {
            "Temperature--StateOfCharge",
            "24--21",
            "29--31",
            "36--20",
            "11--27",
            "30--76",
            "30--74",
            "20--26",
        };

        readonly List<string> SampleConsoleNullData = new List<string>()
        {

        };

        readonly List<int> SampleTemperatureData = new List<int>()
        {
            30,40,50,60,70,80
        };

        readonly List<int> SampleNullData = new List<int>()
        {

        };

        
        public void CheckValidInputIntegerList()
        {
            bool Feedback;
            
            Feedback = StreamLine_Receiver.ReceiverMain.CheckNonEmptyList(SampleTemperatureData);
            Assert.True(Feedback);
            
            Feedback = StreamLine_Receiver.ReceiverMain.CheckNonEmptyList(SampleNullData);
            Assert.False(Feedback);
            
        }
        
        [Fact]
        public void DataParserTest()
        {
            SensorParameter sensorDataList = StreamLine_Receiver.ReceiverMain.DataParser(SampleConsoleData);
            Assert.Equal(24, sensorDataList.Temperature[0]);
            Assert.Equal(29, sensorDataList.Temperature[1]);
            Assert.Equal(36, sensorDataList.Temperature[2]);
            Assert.Equal(11, sensorDataList.Temperature[3]);
            Assert.Equal(30, sensorDataList.Temperature[4]);

            Assert.Equal(21, sensorDataList.StateOfCharge[0]);
            Assert.Equal(31, sensorDataList.StateOfCharge[1]);
            Assert.Equal(20, sensorDataList.StateOfCharge[2]);
            Assert.Equal(27, sensorDataList.StateOfCharge[3]);
            Assert.Equal(76, sensorDataList.StateOfCharge[4]);


            SensorParameter sensorDataList1 = StreamLine_Receiver.ReceiverMain.DataParser(SampleConsoleNullData);
            Assert.Equal(new List<Int32>(), sensorDataList1.Temperature);
            Assert.Equal(new List<Int32>(), sensorDataList1.StateOfCharge);
        }

        [Fact]
        public void AverageOfLast5ValuesTest()
        {
            double AverageOfSoc1 = StreamLine_Receiver.ReceiverMain.AverageOfLast5Values(SampleTemperatureData);
            Assert.Equal(60, AverageOfSoc1);

            double AverageOfSoc2 = StreamLine_Receiver.ReceiverMain.AverageOfLast5Values(SampleNullData);
            Assert.Equal(0.00, AverageOfSoc2);

        }


        [Fact]
        public void GetMaximumValueTest()
        {
            float maximum = StreamLine_Receiver.ReceiverMain.GetMaximumValue(SampleTemperatureData);
            Assert.Equal(80, maximum);
        }

        [Fact]
        public void GetMinimumSOCTest()
        {
            float minimum = StreamLine_Receiver.ReceiverMain.GetMinimumValue(SampleTemperatureData);
            Assert.Equal(30, minimum);

        }
    }
}
