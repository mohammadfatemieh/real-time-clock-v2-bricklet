var Tinkerforge = require('tinkerforge');

var HOST = 'localhost';
var PORT = 4223;
var UID = 'XYZ'; // Change XYZ to the UID of your Real-Time Clock Bricklet 2.0

var ipcon = new Tinkerforge.IPConnection(); // Create IP connection
var rtc = new Tinkerforge.BrickletRealTimeClockV2(UID, ipcon); // Create device object

ipcon.connect(HOST, PORT,
    function (error) {
        console.log('Error: ' + error);
    }
); // Connect to brickd
// Don't use device before ipcon is connected

ipcon.on(Tinkerforge.IPConnection.CALLBACK_CONNECTED,
    function (connectReason) {
        // Get current date and time
        rtc.getDateTime(
            function (year, month, day, hour, minute, second, centisecond, weekday, timestamp) {
                console.log('Year: ' + year);
                console.log('Month: ' + month);
                console.log('Day: ' + day);
                console.log('Hour: ' + hour);
                console.log('Minute: ' + minute);
                console.log('Second: ' + second);
                console.log('Centisecond: ' + centisecond);

                if(weekday === Tinkerforge.BrickletRealTimeClockV2.WEEKDAY_MONDAY) {
                    console.log('Weekday: Monday');
                }
                else if(weekday === Tinkerforge.BrickletRealTimeClockV2.WEEKDAY_TUESDAY) {
                    console.log('Weekday: Tuesday');
                }
                else if(weekday === Tinkerforge.BrickletRealTimeClockV2.WEEKDAY_WEDNESDAY) {
                    console.log('Weekday: Wednesday');
                }
                else if(weekday === Tinkerforge.BrickletRealTimeClockV2.WEEKDAY_THURSDAY) {
                    console.log('Weekday: Thursday');
                }
                else if(weekday === Tinkerforge.BrickletRealTimeClockV2.WEEKDAY_FRIDAY) {
                    console.log('Weekday: Friday');
                }
                else if(weekday === Tinkerforge.BrickletRealTimeClockV2.WEEKDAY_SATURDAY) {
                    console.log('Weekday: Saturday');
                }
                else if(weekday === Tinkerforge.BrickletRealTimeClockV2.WEEKDAY_SUNDAY) {
                    console.log('Weekday: Sunday');
                }

                console.log('Timestamp: ' + timestamp + ' ms');
            },
            function (error) {
                console.log('Error: ' + error);
            }
        );
    }
);

console.log('Press key to exit');
process.stdin.on('data',
    function (data) {
        ipcon.disconnect();
        process.exit(0);
    }
);
