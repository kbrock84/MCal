using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MCal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IMainWindow
    {
        CalendarPresenter _presenter;
        
        public MainWindow()
        {
            InitializeComponent();
            _presenter = new CalendarPresenter(this, new DateKeeper(), new Calendar(new DateKeeper()));
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
        
        public void AddBorder(short dayOfWeek, short weekOfMonth, int[] backgroundARGB)
        {
            Border dayCellBorder = new Border();
            dayCellBorder.Background = BrushMaker.MakeBrushFromARGB(backgroundARGB).GetBrush;
            Grid.SetColumn(dayCellBorder, dayOfWeek);
            Grid.SetRow(dayCellBorder, weekOfMonth);
            AddDateChild(dayCellBorder);
        }

        public void AddLabel(short dayOfWeek, short weekOfMonth, string content, int[] labelARGB)
        {
            Label dateNumber = new Label
            {
                Content = content,
                HorizontalAlignment = HorizontalAlignment.Right,
                Foreground = BrushMaker.MakeBrushFromARGB(labelARGB).GetBrush
            };
                        
            Grid.SetColumn(dateNumber, dayOfWeek);
            Grid.SetRow(dateNumber, weekOfMonth);
            AddDateChild(dateNumber);
        }

    }
}