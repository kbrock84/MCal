
namespace MCal
{
    public class CalendarPresenter
    {
        private readonly IMainWindow _mainWindow;
        private readonly ICalendar _calendar;
        
        private ICalendarConfig _config;
        private string[][] _calDates;
        
        public CalendarPresenter(IMainWindow mainWindow, ICalendar calendar)
        {
            _mainWindow = mainWindow;
            _calendar = calendar;
        }

        public void InitializedCalendar()
        {
            _calDates = _calendar.LoadCalendar(0);

            _config = new CalendarConfig()
            {
                InMonthDaysTextArgb = new[] {255, 0, 0, 0},
                OutOfMonthDaysTextArgb = new[] {255, 100, 100, 100},
                InMonthDaysBackgroundArgb = new[] {100, 152, 154, 158},
                OutOfMonthDaysBackgroundArgb = new[] {100, 91, 113, 165},
                HighlightArgb = new[] {175, 5, 75, 237}
            };
            _mainWindow.SetConfiguration(_config);
            PushCalendarToView(_config);
        }

        public void LastMonthButtonClicked()
        {
            _mainWindow.ClearCalendarChildren();
            _calDates = _calendar.LoadCalendar(-1);
            PushCalendarToView(_config);
        }

        public void NextMonthButtonClicked()
        {
            _mainWindow.ClearCalendarChildren();
            _calDates = _calendar.LoadCalendar(1);
            PushCalendarToView(_config);
        }

        private void PushCalendarToView(ICalendarConfig calendarConfig)
        {
            for (short dayOfWeek = 0; dayOfWeek < _calendar.Weekdays.Length; dayOfWeek++)
            {
                _mainWindow.AddDayLabelChild(_calendar.Weekdays[dayOfWeek], dayOfWeek);
            }
            for (short week = 0; week < _calDates.Length; week++)
            {
                for (short day = 0; day < _calDates[0].Length; day++)
                {
                    short.TryParse(_calDates[week][day], out var dayData);
                    var dayArgb = calendarConfig.GetDayTextArgb(week, dayData);
                    var bgArgb = calendarConfig.GetDayBackgroundArgb(week, dayData);
                    var hlArgb = calendarConfig.HighlightArgb;
                    //_mainWindow.AddBorder(day, week, bgArgb);
                    _mainWindow.AddLabel(day, week, _calDates[week][day]);
                }
            }
            
            _mainWindow.SetMonthLabelText(_calendar.Month);
        }
    }
}