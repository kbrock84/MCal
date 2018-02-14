using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MCal.CalendarUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IMainWindow
    {
        private readonly CalendarPresenter _presenter;
        private ICalendarConfig _calendarConfig;
        
        public MainWindow()
        {
            InitializeComponent();
            _presenter = new CalendarPresenter(this, new Calendar(new DateKeeper()));
            _presenter.InitializedCalendar();

            NextMonthButton.Click += OnNextMonthButtonClicked;
            LastMonthButton.Click += OnLastMonthButtonClicked;
        }
        
        private void OnLastMonthButtonClicked(object sender, RoutedEventArgs e)
        {
            _presenter.LastMonthButtonClicked();
        }

        private void OnNextMonthButtonClicked(object sender, RoutedEventArgs e)
        {
            _presenter.NextMonthButtonClicked();
        }

        public void SetConfiguration(ICalendarConfig calendarConfig)
        {
            _calendarConfig = calendarConfig;
        }
        
        public void ClearCalendarChildren()
        {
            CalendarGrid.Children.Clear();
        }
        
        public void AddDateChild(UIElement ctl)
        {
            CalendarGrid.Children.Add(ctl);
        }

        public void AddDayLabelChild(string dayText, int dayIndex)
        {
            Label dayLabel = new Label()
            {
                Content = dayText
            };
            Grid.SetColumn(dayLabel, dayIndex);

            DayLabelGrid.Children.Add(dayLabel);
        }

        public void SetMonthLabelText(string monthText)
        {
            MonthLabel.Content = monthText;
        }
        

        public void AddLabel(short dayOfWeek, short weekOfMonth, string content)
        {
            var dayCellBorder = new Border
            {
                Background = BrushMaker.MakeBrushFromARGB(_calendarConfig.GetDayBackgroundArgb(weekOfMonth, short.Parse(content))).GetBrush,
            };
            dayCellBorder.MouseEnter += (sender, args) =>
            {
                dayCellBorder.Background = BrushMaker.MakeBrushFromARGB(_calendarConfig.HighlightArgb).GetBrush;
            };
            dayCellBorder.MouseLeave += (sender, args) =>
            {
                dayCellBorder.Background = BrushMaker.MakeBrushFromARGB(_calendarConfig.GetDayBackgroundArgb(weekOfMonth, short.Parse(content))).GetBrush;
            };
            
            Grid.SetColumn(dayCellBorder, dayOfWeek);
            Grid.SetRow(dayCellBorder, weekOfMonth);
            AddDateChild(dayCellBorder);
            
            var dateNumber = new Label
            {
                Content = content,
                Foreground = BrushMaker.MakeBrushFromARGB(_calendarConfig.GetDayTextArgb(weekOfMonth, short.Parse(content))).GetBrush
            };

            dayCellBorder.Child = dateNumber;
        }
    }
}