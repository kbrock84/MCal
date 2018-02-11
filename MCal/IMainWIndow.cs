
namespace MCal
{
    public interface IMainWindow
    {
        void ClearCalendarChildren();
        void AddDayLabelChild(string dayText, int dayIndex);
        void SetMonthLabelText(string s);
        void AddLabel(short dayOfWeek, short weekOfMonth, string content, int[] labelARGB);
        void AddBorder(short dayOfWeek, short weekOfMonth, int[] backgroundARGB);
    }
}