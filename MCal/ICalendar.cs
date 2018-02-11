using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCal
{
    public interface ICalendar
    {
        int[] MonthDayRGBA { get; set; }
        int[] OutsideOfMonthDayRGBA { get; set; }
        string[][] LoadCalendar(short monthIncr, IMainWindow mainWindow);
        string[] Weekdays { get; }
    }
}
