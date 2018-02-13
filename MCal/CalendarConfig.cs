
namespace MCal
{
    class CalendarConfig : ICalendarConfig
    {
        public int[] InMonthDaysBackgroundArgb { get; set; }
        public int[] OutOfMonthDaysBackgroundArgb { get; set; }
        public int[] InMonthDaysTextArgb { get; set; }
        public int[] OutOfMonthDaysTextArgb { get; set; }
        public int[] HighlightArgb { get; set; }
        
        public int[] GetDayTextArgb(short week, short day)
        {
            return DayIsPartOfCurrentMonth(week, day) ? InMonthDaysTextArgb : OutOfMonthDaysTextArgb;
        }
        public int[] GetDayBackgroundArgb(short week, short day)
        {
            return DayIsPartOfCurrentMonth(week, day) ? InMonthDaysBackgroundArgb : OutOfMonthDaysBackgroundArgb;
        }

        public bool DayIsPartOfCurrentMonth(short week, short day)
        {
            return !((week == 0 && day > 7) || (week >= 4 && day < 21));
        }
    }
}
