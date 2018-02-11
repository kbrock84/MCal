
namespace MCal
{
    class CalendarConfig
    {
        int[] InMonthDaysBackgroundARGB { get; set; }
        int[] OutOfMonthDaysBackgroundARGB { get; set; }
        int[] InMonthDaysTextARGB { get; set; }
        int[] OutOfMonthDaysTextARGB { get; set; }

        public int[] GetDayTextARGB(short week, short day)
        {
            if (DayIsPartOfCurrentMonth(week, day))
            {
                return new int[] { 255, 0, 255, 0 };
            }
            else return new int[] { 255, 255, 0, 0 };
        }
        public int[] GetDayBackgroundARGB(short week, short day)
        {
            if (DayIsPartOfCurrentMonth(week, day))
            {
                return new int[] { 100, 0, 0, 255 };
            }
            else return new int[] { 100, 0, 255, 0 };
        }

        public bool DayIsPartOfCurrentMonth(short week, short day)
        {
            if (week == 0 && day > 7)
            {
                return false;
            }
            else if (week >= 4 && day < 21)
            {
                return false;
            }
            return true;
        }
    }
}
