
namespace MCal.CalendarUI
{
    public interface IMainWindow
    {
        void ClearCalendarChildren();
        void AddDayLabelChild(string dayText, int dayIndex);
        void SetMonthLabelText(string s);
        void AddLabel(short dayOfWeek, short weekOfMonth, string content);
        void SetConfiguration(ICalendarConfig calendarConfig);
    }
}