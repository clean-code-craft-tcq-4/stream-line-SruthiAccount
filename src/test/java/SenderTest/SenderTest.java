package SenderTest;


import static org.junit.Assert.*;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

import Sender.BMSData;
import BMSSenderService;
import BMSSenderServiceImpl;



public class SenderTest {

@Test
	public void queryTestDataIsNotNull() {
		BMSSenderService data = new BMSSenderServiceImpl();
		List<BMSData> response=data.generateBatteryParams(50);
		assertNotNull(response);
	}
@Test
public void queryTestDataIsNull() {
	BMSSenderService data = new BMSSenderServiceImpl();
	List<BMSData> response=data.generateBatteryParams(0);
	assertNull(response);
}
@Test
public void queryTestDataHasCorrectCount() {
	BMSSenderService data = new BMSSenderServiceImpl();
	List<BMSData> response=data.generateBatteryParams(50);
	assertEquals(response.size(),50);
}
@Test
public void queryTestDataFailsForIncorrectCount() {
	BMSSenderService data = new BMSSenderServiceImpl();
	List<BMSData> response=data.generateBatteryParams(50);
	assertNotEquals(response.size(),49);
}
	

}

