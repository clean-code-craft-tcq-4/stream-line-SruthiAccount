using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace StreamLine_Receiver
{
    public class SensorParameter
    {
        public List<int> Temperature = new List<int>();

        public List<int> StateOfCharge = new List<int>();


    }

    public class ReceiverMain
    {
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            
            
            SensorParameter SensorParameters = ReadSensorData();
            
            int maxTemp = GetMaximumValue(SensorParameters.Temperature);
            int minTemp = GetMinimumValue(SensorParameters.Temperature);
            int minSOC = GetMaximumValue(SensorParameters.StateOfCharge);
            int maxSOC = GetMinimumValue(SensorParameters.StateOfCharge);
            double socAverage = AverageOfLast5Values(SensorParameters.StateOfCharge);
            double temperatureAverage = AverageOfLast5Values(SensorParameters.Temperature);
            printOnConsole(maxTemp, minTemp, minSOC, maxSOC, socAverage, temperatureAverage);


        }
        [ExcludeFromCodeCoverage]
        private static void printOnConsole(int maxTemperature, int minTemperature, int minSOC, int maxSOC, double socAverage, double temperatureAverage)
        {
            Console.WriteLine($"Maximum temperature:{maxTemperature}");
            Console.WriteLine($"Minimum temperature:{minTemperature}");
            Console.WriteLine($"Maximum SOC:{maxSOC}");
            Console.WriteLine($"Minimum SOC:{minSOC}");
            Console.WriteLine($"Average temperature:{temperatureAverage}");
            Console.WriteLine($"Average SOC:{socAverage}");

        }


        public static Double AverageOfLast5Values(List<int> Input_Data)
        {
            float AverageOfLast5Values = 0;
            if (Input_Data.Count > 1)
            {
                for (int i = Input_Data.Count; i > Input_Data.Count - 5; i--)
                {
                    AverageOfLast5Values += Input_Data[i - 1];
                }

                return AverageOfLast5Values / 5;
            }
            return 0.0;

        }

        [ExcludeFromCodeCoverage]
        private static SensorParameter ReadSensorData()
        {
            
            List<string> consoleData = new List<string>();
            string summa = " ";
            for (int i = 0; i < 51; i++)
            {
                
                consoleData.Add(Console.ReadLine());
                
            }

            SensorParameter sensorParameters = DataParser(consoleData);
            return sensorParameters;
        }

        public static SensorParameter DataParser(List<string> Input_data)
        {
            
            SensorParameter sensorParameters = new SensorParameter();
            
            string[] Seperated_String_Data;
            for (int i = 1; i < Input_data.Count; i++)
            {
                Seperated_String_Data = Input_data[i].Split("--");

                sensorParameters.Temperature.Add(Int32.Parse(Seperated_String_Data[0].ToString()));
                sensorParameters.StateOfCharge.Add(Int32.Parse(Seperated_String_Data[1].ToString()));



            }          

            return sensorParameters;
        }


        public static int GetMinimumValue(List<int> parameterList)
        {
            if (CheckNonEmptyList(parameterList))
            {
                return parameterList.Min();
            }
            else
            {
                return 0;    
            }
        }

        public static int GetMaximumValue(List<int> parameterList)
        {
            if (CheckNonEmptyList(parameterList))
            {
                return parameterList.Max();
            }
            else
            {
                return 0;    
            }
        }
        
        public static int CheckNonEmptyList(List<int> data)
        {
            if(data.Count < 1)
            {
                return 0;
            }
            else
            {
                return 1;
            }
           
        }
    }
}
