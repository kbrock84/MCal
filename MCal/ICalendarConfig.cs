namespace MCal
{
    public interface ICalendarConfig
    {
        int[] InMonthDaysBackgroundArgb { get; set; }
        int[] OutOfMonthDaysBackgroundArgb { get; set; }
        int[] InMonthDaysTextArgb { get; set; }
        int[] OutOfMonthDaysTextArgb { get; set; }
        int[] HighlightArgb { get; set; }
        int[] GetDayTextArgb(short week, short day);
        int[] GetDayBackgroundArgb(short week, short day);
        bool DayIsPartOfCurrentMonth(short week, short day);
    }
}