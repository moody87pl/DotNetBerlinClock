namespace BerlinClock.Classes
{
    public class LightIndicator
    {
        public LightIndicator(string color)
        {
            Color = color;
        }
        /// <summary>
        /// "Y" - yellow
        /// "R" - red
        /// </summary>
        public string Color { get; }
        public bool IsON { get; set; }
        public override string ToString()
        {
            return IsON ? Color : "O";
        }
    }
}
