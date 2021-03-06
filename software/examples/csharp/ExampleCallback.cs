using System;
using Tinkerforge;

class Example
{
	private static string HOST = "localhost";
	private static int PORT = 4223;
	private static string UID = "XYZ"; // Change XYZ to the UID of your Real-Time Clock Bricklet 2.0

	// Callback function for date and time callback
	static void DateTimeCB(BrickletRealTimeClockV2 sender, int year, byte month, byte day,
	                       byte hour, byte minute, byte second, byte centisecond,
	                       byte weekday, long timestamp)
	{
		Console.WriteLine("Year: " + year);
		Console.WriteLine("Month: " + month);
		Console.WriteLine("Day: " + day);
		Console.WriteLine("Hour: " + hour);
		Console.WriteLine("Minute: " + minute);
		Console.WriteLine("Second: " + second);
		Console.WriteLine("Centisecond: " + centisecond);

		if(weekday == BrickletRealTimeClockV2.WEEKDAY_MONDAY)
		{
			Console.WriteLine("Weekday: Monday");
		}
		else if(weekday == BrickletRealTimeClockV2.WEEKDAY_TUESDAY)
		{
			Console.WriteLine("Weekday: Tuesday");
		}
		else if(weekday == BrickletRealTimeClockV2.WEEKDAY_WEDNESDAY)
		{
			Console.WriteLine("Weekday: Wednesday");
		}
		else if(weekday == BrickletRealTimeClockV2.WEEKDAY_THURSDAY)
		{
			Console.WriteLine("Weekday: Thursday");
		}
		else if(weekday == BrickletRealTimeClockV2.WEEKDAY_FRIDAY)
		{
			Console.WriteLine("Weekday: Friday");
		}
		else if(weekday == BrickletRealTimeClockV2.WEEKDAY_SATURDAY)
		{
			Console.WriteLine("Weekday: Saturday");
		}
		else if(weekday == BrickletRealTimeClockV2.WEEKDAY_SUNDAY)
		{
			Console.WriteLine("Weekday: Sunday");
		}

		Console.WriteLine("Timestamp: " + timestamp);
		Console.WriteLine("");
	}

	static void Main()
	{
		IPConnection ipcon = new IPConnection(); // Create IP connection
		BrickletRealTimeClockV2 rtc =
		  new BrickletRealTimeClockV2(UID, ipcon); // Create device object

		ipcon.Connect(HOST, PORT); // Connect to brickd
		// Don't use device before ipcon is connected

		// Register date and time callback to function DateTimeCB
		rtc.DateTimeCallback += DateTimeCB;

		// Set period for date and time callback to 5s (5000ms)
		rtc.SetDateTimeCallbackConfiguration(5000);

		Console.WriteLine("Press enter to exit");
		Console.ReadLine();
		ipcon.Disconnect();
	}
}
