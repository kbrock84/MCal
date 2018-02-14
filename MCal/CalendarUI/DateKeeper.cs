using System;

namespace MCal.CalendarUI
{
    public class DateKeeper : IDateKeeper
    {
        private DateTime SwapTime { get; set; }
        
        public short DayOfWeek => (short) SwapTime.DayOfWeek;

        public int Day => SwapTime.Day;

        public int Month => SwapTime.Month;

        public int Year => SwapTime.Year;
        
        public DateKeeper()
        {
            var todaysDate = DateTime.Today;
            SwapTime = DateTime.Parse($@"{todaysDate.Month}/1/{todaysDate.Year}");
        }

        public void AddDays(int days)
        {
            SwapTime = SwapTime.AddDays(days);
        }

        public void AddMonths(short incrByValue)
        {
            SwapTime = SwapTime.AddMonths(incrByValue);
        }
        
        public void ResetToFirstDay()
        {
            SwapTime = DateTime.Parse($@"{SwapTime.Month}/1/{SwapTime.Year}");
        }
    }
}