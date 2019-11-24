using System.Collections.Generic;

namespace BerlinClock.Classes
{
    public class BerlinClock
    {
        #region Clock Lights structure
        private LightIndicator SecondsIndicator { get; set; }
        private List<LightIndicator> FiveHoursRow { get; set; }
        private List<LightIndicator> OneHourRow { get; set; }
        private List<LightIndicator> FiveMinutesRow { get; set; }
        private List<LightIndicator> OneMinuteRow { get; set; }
        #endregion        
        public BerlinClock()
        {
            //color pattern:
            //Y
            //RRRR
            //RRRR
            //YYRYYRYYRYY
            //YYYY
            SecondsIndicator = new LightIndicator("Y");
            FiveHoursRow = new List<LightIndicator>();
            foreach (char colorInPattern in "RRRR")
            {
                FiveHoursRow.Add(new LightIndicator(colorInPattern.ToString()));
            }
            OneHourRow = new List<LightIndicator>();
            foreach (char colorInPattern in "RRRR")
            {
                OneHourRow.Add(new LightIndicator(colorInPattern.ToString()));
            }
            FiveMinutesRow = new List<LightIndicator>();
            foreach (char colorInPattern in "YYRYYRYYRYY")
            {
                FiveMinutesRow.Add(new LightIndicator(colorInPattern.ToString()));
            }
            OneMinuteRow = new List<LightIndicator>();
            foreach (char colorInPattern in "YYYY")
            {
                OneMinuteRow.Add(new LightIndicator(colorInPattern.ToString()));
            }
        }

        public void SetTime(string time)
        {

            #region reset state
            SecondsIndicator.IsON = false;
            foreach (LightIndicator indicator in FiveHoursRow)
            {
                indicator.IsON = false;
            }
            foreach (LightIndicator indicator in OneHourRow)
            {
                indicator.IsON = false;
            }
            foreach (LightIndicator indicator in FiveMinutesRow)
            {
                indicator.IsON = false;
            }
            foreach (LightIndicator indicator in OneMinuteRow)
            {
                indicator.IsON = false;
            }
            #endregion

            int hours, minutes, seconds;

            #region parsing time
            {
                string[] timeSplit = time.Split(':');
                hours = int.Parse(timeSplit[0]);
                minutes = int.Parse(timeSplit[1]);
                seconds = int.Parse(timeSplit[2]);
            }
            #endregion

            // sec indicator is on then seconds%2=0

            SecondsIndicator.IsON = (seconds % 2 == 0);

            #region settins Hours
            {
                int everyFiveHours = hours / 5;
                int hoursLeft = hours % 5;

                for (int i = 0; i < everyFiveHours; i++)
                {
                    FiveHoursRow[i].IsON = true;
                }
                for (int i = 0; i < hoursLeft; i++)
                {
                    OneHourRow[i].IsON = true;
                }
            }
            #endregion

            #region settins Minutes
            {
                int everyFiveMinutes = minutes / 5;
                int minutesLeft = minutes % 5;

                for (int i = 0; i < everyFiveMinutes; i++)
                {
                    FiveMinutesRow[i].IsON = true;
                }
                for (int i = 0; i < minutesLeft; i++)
                {
                    OneMinuteRow[i].IsON = true;
                }
            }
            #endregion
        }

        public override string ToString()
        {
            string ret = string.Empty;
            ret += SecondsIndicator.ToString() + "\r\n";
            foreach (LightIndicator indicator in FiveHoursRow)
            {
                ret += indicator.ToString();
            }
            ret += "\r\n";
            foreach (LightIndicator indicator in OneHourRow)
            {
                ret += indicator.ToString();
            }
            ret += "\r\n";
            foreach (LightIndicator indicator in FiveMinutesRow)
            {
                ret += indicator.ToString();
            }
            ret += "\r\n";
            foreach (LightIndicator indicator in OneMinuteRow)
            {
                ret += indicator.ToString();
            }

            return ret;
        }
    }
}
