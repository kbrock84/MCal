
namespace MCal
{
    public class CalendarPresenter
    {
        public CalendarPresenter(IMainWindow mainWindow, IDateKeeper dateKeeper, ICalendar calendar)
        {
            _mainWindow = mainWindow;
            _dateKeeper = dateKeeper;
            _calendar = calendar;
        }
        
        private IMainWindow _mainWindow;
        private IDateKeeper _dateKeeper;
        private ICalendar _calendar;

        private int[] _dayArgb = { 255, 255, 0 , 0};

        private short _monthIncr = 0;

        public void InitializedCalendar()
        {   
            PushCalendarToView();
        }

        public void LastMonthButtonClicked()
        {
            _mainWindow.ClearCalendarChildren();
            _calendar.LoadCalendar(-1, _mainWindow);
            PushCalendarToView();
        }

        public void NextMonthButtonClicked()
        {
            _mainWindow.ClearCalendarChildren();
            _calendar.LoadCalendar(+1, _mainWindow);
            PushCalendarToView();
        }

        private void PushCalendarToView()
        {
            var calDates = _calendar.LoadCalendar(_monthIncr, _mainWindow);
            for (short dayOfWeek = 0; dayOfWeek < _calendar.Weekdays.Length; dayOfWeek++)
            {
                _mainWindow.AddDayLabelChild(_calendar.Weekdays[dayOfWeek], dayOfWeek);
            }
            for (short week = 0; week < calDates.Length; week++)
            {
                for (short day = 0; day < calDates[0].Length; day++)
                {
                    _mainWindow.AddLabel(day, week, calDates[week][day], _dayArgb);
                }
            }
        }
    }
}