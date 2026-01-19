using System.Windows.Forms;

namespace MidChess.controls
{
    public class BufferedListView : ListView
    {
        public BufferedListView()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }
    }
}