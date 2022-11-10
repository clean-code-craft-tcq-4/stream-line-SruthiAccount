package Sender;

public class BMSData {

	public float temperature;
	public float stateOfCharge;
	public float chargeRate;

	public BMSData(float temperatureValue, float socValue, float chargeRate) {
		this.temperature = temperatureValue;
		this.stateOfCharge = socValue;
		this.chargeRate = chargeRate;
	}
}