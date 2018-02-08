using System.Windows;
using System.Windows.Controls;

namespace MCal
{
    public interface IMainWindow
    {
        void ClearCalendarChildren();
        void AddDateChild(UIElement clt);
        void AddDayLabelChild(Label dateNumber);
        void SetMonthLabelText(string s);
    }
}