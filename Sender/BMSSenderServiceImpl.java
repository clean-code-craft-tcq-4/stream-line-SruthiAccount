package Sender;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class BMSSenderServiceImpl implements BMSSenderService {
	private static BMSLogger log = new BMSLogger();
	Random random = new Random();
	List<BMSData> bmsData;
	public static float MAX_TEMPERATURE = 40f;
	public static float MIN_TEMPERATURE = 0f;
	public static float MAX_SOC = 80f;
	public static float MIN_SOC = 20f;
	public static final float MAX_CHARGE_RATE = 0.8f;
	public static final float MIN_CHARGE_RATE = 0.0f;

	public List<BMSData> generateBatteryParams(int count) {

		for (int i = 0; i < count; i++) {
			if (bmsData == null)
				bmsData = new ArrayList<BMSData>();
			float temperatureValue = generateValue(MAX_TEMPERATURE, MIN_TEMPERATURE);
			float SocValue = generateValue(MAX_SOC, MIN_SOC);
			float ChargeValue = generateValue(MAX_CHARGE_RATE, MIN_CHARGE_RATE);
			bmsData.add(new BMSData(temperatureValue, SocValue, ChargeValue));
		}
		return bmsData;
	}

	public void sendParamsToConsole() {
		log.printMessage("Temperature--SOC--ChargeRate");
		for (BMSData data : bmsData) {
			log.printMessage(data.temperature + "--" + data.stateOfCharge + "--" + data.chargeRate);
		}
	}

	private Float generateValue(Float min, Float max) {
		float value = Math.round(((Math.random() * (max - min)) + min) * 100);
		return (value / 100.0f);
	}

}