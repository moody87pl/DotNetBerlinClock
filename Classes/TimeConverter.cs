using System;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            DateTime time;
            //try to parse to DateTime - to make sure, that given string contain time. Important: 24:00:00 will not parse, have to change to standard Midnight
            try
            {
                time = DateTime.ParseExact(aTime == "24:00:00" ? "00:00:00" : aTime, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new FormatException("Unexpected time format");
            }

            Classes.BerlinClock BerlinClockObj = new BerlinClock.Classes.BerlinClock();

            BerlinClockObj.SetTime(aTime);

            return BerlinClockObj.ToString();
        }
    }
}
