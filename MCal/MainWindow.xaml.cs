using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Media.Converters;

namespace MCal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IMainWindow
    {
        CalendarController _controller = new CalendarController();
        
        public MainWindow()
        {
            InitializeComponent();
            _controller.InitializeCalendar(this, new DateKeeper());

            NextMonthButton.Click += _controller.NextMonthButtonClicked;
            LastMonthButton.Click += _controller.LastMonthButtonClicked;
        }

        public void ClearCalendarChildren()
        {
            //CalendarGrid.ShowGridLines = true;//TODO For testing only
            CalendarGrid.Children.Clear();
        }
        
        public void AddDateChild(UIElement ctl)
        {
            CalendarGrid.Children.Add(ctl);
        }

        public void AddDayLabelChild(Label lbl)
        {
            DayLabelGrid.Children.Add(lbl);
        }

        public void SetMonthLabelText(string monthText)
        {
            MonthLabel.Content = monthText;
        }
    }
}