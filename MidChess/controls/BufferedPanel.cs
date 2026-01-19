using System.Windows.Forms;

namespace MidChess.controls
{
    public class BufferedPanel : Panel
    {
        public BufferedPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }
    }
}