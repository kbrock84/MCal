
using System.Dynamic;

namespace MCal.CalendarUI
{
    public class Calendar : ICalendar
    {
        public string Month
        {
            get => $"{_months[_dateKeeper.Month]} {_dateKeeper.Year}";
        }
        public string[] Weekdays { get; } =
        {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thrusday",
            "Friday",
            "Saturday",
        };

        private readonly IDateKeeper _dateKeeper;

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

        public string[][] LoadCalendar(short monthIncr)
        {
            var calendarDays = new string[CalendarDateRowCount][];
            if (monthIncr != 0)
            {
                _dateKeeper.AddMonths(monthIncr);
            }

            var startDay = _dateKeeper.DayOfWeek;
            _dateKeeper.AddDays(startDay * -1);

            for (short weekOfMonth = 0; weekOfMonth < CalendarDateRowCount; weekOfMonth++)
            {
                calendarDays[weekOfMonth] = new string[7];
                for (short dayOfWeek = 0; dayOfWeek < CalendarDateColumnCount; dayOfWeek++)
                {
                    calendarDays[weekOfMonth][dayOfWeek] = _dateKeeper.Day.ToString();
                    _dateKeeper.AddDays(1);
                }
            }
            _dateKeeper.ResetToFirstDay();
            _dateKeeper.AddMonths(-1);
            return calendarDays;
        }
    }
}
