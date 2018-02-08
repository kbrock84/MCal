using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MCal
{
    public class CalendarController
    {
        
        private IMainWindow _mainWindow;
        private IDateKeeper _dateKeeper;
        private Brush _labelForeground;

        
        private const short CalendarDateRowCount = 5;
        private const short CalendarDateColumnCount = 7;
        private short _monthIncr = 0;
        
        private readonly string[] _months =
        {
            "Zero is not a valid month",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        };

        private readonly string[] _days =
        {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thrusday",
            "Friday",
            "Saturday",
        };

        
        public void InitializeCalendar(IMainWindow mainWindow, IDateKeeper dateKeeper)
        {
            _mainWindow = mainWindow;
            _dateKeeper = dateKeeper;
            LoadCalendar();
        }

        public void LoadCalendar()
        {
            _mainWindow.ClearCalendarChildren();
            
            if (_monthIncr != 0)
            {
                _dateKeeper.AddMonths(_monthIncr);
            }

            short startDay = _dateKeeper.DayOfWeek;
            bool monthIsStarted = false;

            _mainWindow.SetMonthLabelText($"{_months[_dateKeeper.Month]} {_dateKeeper.Year}") ;
            _labelForeground = Brushes.Blue;
            
            for (short weekOfMonth = 0; weekOfMonth <= CalendarDateRowCount; weekOfMonth++)
            {    
                for (short dayOfWeek = 0; dayOfWeek < CalendarDateColumnCount; dayOfWeek++ )
                {
                    if (weekOfMonth == 0)
                    {
                        Label dayName = new Label
                        {
                            Content = _days[dayOfWeek],
                            HorizontalAlignment = HorizontalAlignment.Center,
                        };
                    
                        Grid.SetColumn(dayName, dayOfWeek);
                        _mainWindow.AddDayLabelChild(dayName);
                    }
                    
                    if (!monthIsStarted && startDay == dayOfWeek)
                    {
                        monthIsStarted = true;
                    }
                    if (monthIsStarted)
                    {
                        if (weekOfMonth > 0 && (_dateKeeper.Day) == 1)
                        {
                            _labelForeground = Brushes.MediumVioletRed;
                        }
                        
                        AddBorder(dayOfWeek, weekOfMonth);
                        AddLabel(dayOfWeek, weekOfMonth);
                    }
                }
            }
            
            _dateKeeper.ResetToFirstDay();
        }
        
        public void LastMonthButtonClicked(object sender, RoutedEventArgs e)
        {
            _monthIncr = -1;
            LoadCalendar();
        }

        public void NextMonthButtonClicked(object sender, RoutedEventArgs e)
        {
            _monthIncr = 1;
            LoadCalendar();
        }

        void AddBorder(short dayOfWeek, short weekOfMonth)
        {
            Border dayCellBorder = new Border();
            dayCellBorder.Background = Brushes.AntiqueWhite;
            Grid.SetColumn(dayCellBorder, dayOfWeek);
            Grid.SetRow(dayCellBorder, weekOfMonth);
            _mainWindow.AddDateChild(dayCellBorder);
        }

        void AddLabel(short dayOfWeek, short weekOfMonth)
        {
            Label dateNumber = new Label
            {
                Content = _dateKeeper.Day,
                HorizontalAlignment = HorizontalAlignment.Right,
                Foreground = _labelForeground
            };
                        
            Grid.SetColumn(dateNumber, dayOfWeek);
            Grid.SetRow(dateNumber, weekOfMonth);
            _mainWindow.AddDateChild(dateNumber);
            _dateKeeper.AddDays(1);
        }

    }
}