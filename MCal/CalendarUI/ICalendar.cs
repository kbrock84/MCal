﻿
namespace MCal.CalendarUI
{
    public interface ICalendar
    {
        string[][] LoadCalendar(short monthIncr);
        string[] Weekdays { get; }
        string Month { get; }
    }
}
