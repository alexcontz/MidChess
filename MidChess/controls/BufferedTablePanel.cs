using System.Windows.Forms;

namespace MidChess.controls
{
    public class BufferedTablePanel : TableLayoutPanel
    {
        public BufferedTablePanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }
    }
}