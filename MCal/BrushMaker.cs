using System.Windows.Media;

namespace MCal
{
    class BrushMaker
    {
        public Brush GetBrush;
        private BrushMaker(Brush brush)
        {
            GetBrush = brush;
        }

        public static BrushMaker MakeBrushFromARGB(int[] ARGB)
        {
            return new BrushMaker(new SolidColorBrush(
                Color.FromArgb((byte)ARGB[0], (byte)ARGB[1], (byte)ARGB[2], (byte)ARGB[3])));
        }
    }
}
