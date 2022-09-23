package Sender;

import java.util.List;

public interface BMSSenderService {
		public List<BMSData> generateBatteryParams(int count);
		public void sendParamsToConsole();

}