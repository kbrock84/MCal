namespace MCal
{
    public interface IDateKeeper
    {
        void AddDays(int days);
        void AddMonths(short monthIncr);
        short DayOfWeek{ get; }
        int Day { get; }
        int Month { get; }
        int Year{ get; }
        void ResetToFirstDay();
    }
}