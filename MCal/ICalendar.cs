
namespace MCal
{
    public interface ICalendar
    {
        string[][] LoadCalendar(short monthIncr, IMainWindow mainWindow);
        string[] Weekdays { get; }
    }
}
