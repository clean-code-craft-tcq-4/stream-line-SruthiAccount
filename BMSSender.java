import Sender.BMSLogger;
import Sender.BMSSenderService;
import Sender.BMSSenderServiceImpl;

public class BMSSender {
	private static BMSLogger log = new BMSLogger();

	public static void main(String[] args) {
		try {
			log.printMessage("Sender Data");
			BMSSenderService data = new BMSSenderServiceImpl();
			int count=50;
			data.generateBatteryParams(count);
			data.sendParamsToConsole();

		} catch (NullPointerException e) {
			log.printMessage(e.getLocalizedMessage());
		}
	}

}
