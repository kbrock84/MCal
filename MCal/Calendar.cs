
namespace MCal
{
    public class Calendar : ICalendar
    {
        public string Month;
        public string[] Weekdays { get => _days; }
        public string[][] CalendarDays;

        IDateKeeper _dateKeeper;

        private const short CalendarDateRowCount = 6;
        private const short CalendarDateColumnCount = 7;

        public Calendar(IDateKeeper dateKeeper)
        {
            _dateKeeper = dateKeeper;
        }

        private readonly string[] _months =
        {
            "Zero is not a valid month",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        };
        private readonly string[] _days =
        {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thrusday",
            "Friday",
            "Saturday",
        };

        public string[][] LoadCalendar(short monthIncr, IMainWindow _mainWindow)
        {
            CalendarDays = new string[CalendarDateRowCount][];
            if (monthIncr != 0)
            {
                _dateKeeper.AddMonths(monthIncr);
            }

            _mainWindow.SetMonthLabelText($"{_months[_dateKeeper.Month]} {_dateKeeper.Year}");

            short startDay = _dateKeeper.DayOfWeek;
            _dateKeeper.AddDays(startDay * -1);

            for (short weekOfMonth = 0; weekOfMonth < CalendarDateRowCount; weekOfMonth++)
            {
                CalendarDays[weekOfMonth] = new string[7];
                for (short dayOfWeek = 0; dayOfWeek < CalendarDateColumnCount; dayOfWeek++)
                {
                    CalendarDays[weekOfMonth][dayOfWeek] = _dateKeeper.Day.ToString();
                    _dateKeeper.AddDays(1);
                }
            }
            _dateKeeper.ResetToFirstDay();
            _dateKeeper.AddMonths(-1);
            return CalendarDays;
        }
    }
}
